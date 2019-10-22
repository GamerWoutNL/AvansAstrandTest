using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using ServerProgram.Data;
using System.Threading;
using Timer = System.Timers.Timer;
using System.Timers;

namespace ServerProgram.Communication
{
	public class Server
	{
		private TcpListener listener;
		public List<ServerClient> Clients { get; set; }
		public List<Patient> Patients { get; set; }
		public Patient CurrentPatient { get; set; }
		public TestLogics TestLogics { get; set; }
		public Timer TimerWarmingUp { get; set; }
		public Timer TimerRealTest { get; set; }
		public Timer TimerCoolingDown { get; set; }
		public Test CurrentTest { get; set; }
		public BoolWrapper BoolWrapper { get; set; }

		public Server(int port)
		{
			this.BoolWrapper = new BoolWrapper();
			this.BoolWrapper.CanAccess = true;

			FileIO.CreateLogFile();
			this.listener = new TcpListener(IPAddress.Any, port);
			this.Clients = new List<ServerClient>();
			this.Patients = this.GetPatients();
			this.CurrentPatient = null;
			this.TestLogics = new TestLogics(this);
			this.CurrentTest = Test.Before;

			//this.TimerWarmingUp = new Timer(2 * 60 * 1000);
			//this.TimerRealTest = new Timer(4 * 60 * 1000);
			//this.TimerCoolingDown = new Timer(60 * 1000);

			this.TimerWarmingUp = new Timer(15 * 1000);
			this.TimerRealTest = new Timer(30 * 1000);
			this.TimerCoolingDown = new Timer(15 * 1000);

			this.TimerWarmingUp.Elapsed += new ElapsedEventHandler(OnWarmingUpDone);
			this.TimerRealTest.Elapsed += new ElapsedEventHandler(OnRealTestDone);
			this.TimerCoolingDown.Elapsed += new ElapsedEventHandler(OnCoolingDownDone);
		}

		public void Start()
		{
			this.listener.Start();
			this.listener.BeginAcceptTcpClient(new AsyncCallback(OnConnect), null);
			Console.WriteLine("Listening..");
		}

		private void OnConnect(IAsyncResult ar)
		{
			TcpClient newClient = this.listener.EndAcceptTcpClient(ar);
			this.Clients.Add(new ServerClient(newClient, this));
			Console.WriteLine("New client connected");

			this.listener.BeginAcceptTcpClient(new AsyncCallback(OnConnect), null);
		}

		public void SendToPatient(string message)
		{
			foreach (var client in this.Clients)
			{
				if (client.IsPatient)
				{
					client.Write(message);
				}
			}
		}

		public void AddDataHeartRate(DateTime timestamp, double heartrate)
		{
			if (this.CurrentTest == Test.WarmingUp || this.CurrentTest == Test.RealTest || this.CurrentTest == Test.CoolingDown)
			{
				this.CurrentPatient.Session.HeartrateDataPoints.Add(new DataPoint(timestamp, heartrate));
				this.TestLogics.HeartrateDataPoints.Add(new DataPoint(timestamp, heartrate));
			}
		}

		public void AddDataCadenceAndPower(DateTime timestamp, double instantaneousCadence, double instantaneousPower)
		{
			if (this.CurrentTest == Test.WarmingUp || this.CurrentTest == Test.RealTest || this.CurrentTest == Test.CoolingDown)
			{
				this.CurrentPatient.Session.InstantaniousCadenceDataPoints.Add(new DataPoint(timestamp, instantaneousCadence));
				this.CurrentPatient.Session.InstantaniousPowerDataPoints.Add(new DataPoint(timestamp, instantaneousPower));
				
				this.TestLogics.InstantaniousCadenceDataPoints.Add(new DataPoint(timestamp, instantaneousCadence));
				this.TestLogics.InstantaniousPowerDataPoints.Add(new DataPoint(timestamp, instantaneousPower));
			}
		}

		public void Stop()
		{
			foreach (var client in this.Clients)
			{
				client.Disconnect();
			}
			this.listener.Stop();
		}

		public void SendResistance(int percentage)
		{
			this.SendToPatient($"<{Tag.MT.ToString()}>patient<{Tag.AC.ToString()}>resistance<{Tag.SR.ToString()}>{percentage}<{Tag.EOF.ToString()}>");
		}

		public void SendMessageToPatient(string message)
		{
			this.SendToPatient($"<{Tag.MT.ToString()}>patient<{Tag.AC.ToString()}>message<{Tag.DM.ToString()}>{message}<{Tag.EOF.ToString()}>");
		}

		public void SavePatient(Patient patient)
		{
			this.BoolWrapper.CanAccess = false;

			Console.WriteLine("Saving data..");
			this.Patients.Add(patient);
			FileIO.WriteToBinaryFile(this.Patients);

			Thread.Sleep(1000);
			this.BoolWrapper.CanAccess = true;
		}

		public List<Patient> GetPatients()
		{
			this.BoolWrapper.CanAccess = false;
			List<Patient> patients = FileIO.ReadFromBinaryFile<List<Patient>>();

			Thread.Sleep(1000);
			this.BoolWrapper.CanAccess = true;

			return patients;
		}

		public void BeginSession()
		{
			this.CurrentPatient.Session = new Session();
			this.TimerWarmingUp.Start();
			this.CurrentTest = Test.WarmingUp;

			this.SendResistance(10);
			Console.WriteLine("Session begins");
		}

		public void EndSession()
		{
			this.SavePatient(this.CurrentPatient);
			Console.WriteLine("Session is done");
		}

		public double CalculateVO2Max(double workload, double heartrate)
		{
			// Male:   VO2max = (0.00212 * Workload + 0.299) / (0.769 * Heart Rate - 48.5) x 1000
			// Female: VO2max = (0.00193 * Workload + 0.326) / (0.769 * Heart Rate - 56.1) x 1000
			if (this.CurrentPatient.Gender == Gender.Male)
			{
				return (0.00212 * workload + 0.299) / (0.769 * heartrate - 48.5) * 1000.0;
			}
			else
			{
				return (0.00193 * workload + 0.326) / (0.769 * heartrate - 56.1) * 1000.0;
			}
		}

		private void OnWarmingUpDone(object sender, ElapsedEventArgs e)
		{
			this.CurrentTest = Test.RealTest;
			this.TimerRealTest.Start();
			this.TimerWarmingUp.Stop();
			Console.WriteLine("Warming up done");
		}

		private void OnRealTestDone(object sender, ElapsedEventArgs e)
		{
			this.CurrentTest = Test.CoolingDown;
			this.TimerCoolingDown.Start();
			this.TimerRealTest.Stop();
			Console.WriteLine("Test done");
		}

		private void OnCoolingDownDone(object sender, ElapsedEventArgs e)
		{
			this.CurrentTest = Test.After;
			this.EndSession();
			this.TimerCoolingDown.Stop();
			Console.WriteLine("Cooling down done");
		}
	}
}
