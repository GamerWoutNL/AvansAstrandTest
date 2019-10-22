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
		private int oneMinuteCount;
		private bool readHR;
		private bool setResistance;
		private bool setResistanceMk2;
		public List<ServerClient> Clients { get; set; }
		public List<Patient> Patients { get; set; }
		public List<double> Heartrates { get; set; }
		public List<double> Watts { get; set; }
		public Patient CurrentPatient { get; set; }
		public Timer TimerWarmingUp { get; set; }
		public Timer TimerRealTest { get; set; }
		public Timer TimerCoolingDown { get; set; }
		public Timer TimerHROneMinute { get; set; }
		public Timer TimerHRFifteenSec { get; set; }
		public Timer TimerResistanceFiveSec { get; set; }
		public Test CurrentTest { get; set; }
		public BoolWrapper BoolWrapper { get; set; }
		public int CurrentResistance { get; set; }

		public Server(int port)
		{
			this.BoolWrapper = new BoolWrapper();
			this.BoolWrapper.CanAccess = true;

			FileIO.CreateLogFile();
			this.listener = new TcpListener(IPAddress.Any, port);
			this.Clients = new List<ServerClient>();
			this.Heartrates = new List<double>();
			this.Watts = new List<double>();
			this.Patients = this.GetPatients();
			this.CurrentPatient = null;
			this.CurrentTest = Test.Before;
			this.oneMinuteCount = 0;
			this.CurrentResistance = 0;
			this.readHR = false;
			this.setResistance = false;
			this.setResistanceMk2 = true;

			this.TimerWarmingUp = new Timer(2 * 60 * 1000);
			this.TimerRealTest = new Timer(4 * 60 * 1000);
			this.TimerCoolingDown = new Timer(60 * 1000);

			this.TimerHROneMinute = new Timer(60 * 1000);
			this.TimerHRFifteenSec = new Timer(15 * 1000);

			this.TimerResistanceFiveSec = new Timer(5 * 1000);

			this.TimerWarmingUp.Elapsed += new ElapsedEventHandler(OnWarmingUpDone);
			this.TimerRealTest.Elapsed += new ElapsedEventHandler(OnRealTestDone);
			this.TimerCoolingDown.Elapsed += new ElapsedEventHandler(OnCoolingDownDone);

			this.TimerHROneMinute.Elapsed += new ElapsedEventHandler(OnHROneMinuteDone);
			this.TimerHRFifteenSec.Elapsed += new ElapsedEventHandler(OnHRFifteenSecondsDone);

			this.TimerResistanceFiveSec.Elapsed += new ElapsedEventHandler(OnResistanceFiveSecDone);
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

				if (heartrate > 220 - this.CurrentPatient.Age)
				{
					this.SendMessageToPatient("HARTSLAG TE HOOG, ga van de fiets af");
				}

				if (this.readHR)
				{
					this.Heartrates.Add(heartrate);
					this.readHR = false;
				}

				if (heartrate >= 130)
				{
					this.setResistanceMk2 = false;
				}

				if (this.CurrentTest == Test.RealTest && heartrate < 130 && this.setResistance && this.setResistanceMk2)
				{
					this.SendResistance(this.CurrentResistance + 5);
					this.setResistance = false;
				}

			}
		}

		public void AddDataCadenceAndPower(DateTime timestamp, double instantaneousCadence, double instantaneousPower)
		{
			if (this.CurrentTest == Test.WarmingUp || this.CurrentTest == Test.RealTest || this.CurrentTest == Test.CoolingDown)
			{
				this.CurrentPatient.Session.InstantaniousCadenceDataPoints.Add(new DataPoint(timestamp, instantaneousCadence));
				this.CurrentPatient.Session.InstantaniousPowerDataPoints.Add(new DataPoint(timestamp, instantaneousPower));

				this.Watts.Add(instantaneousPower);

				if (instantaneousCadence < 50)
				{
					this.SendMessageToPatient("Fiets harder");
				}
				else if (instantaneousCadence > 60)
				{
					this.SendMessageToPatient("Fiets zachter");
				}
				else
				{
					this.SendMessageToPatient("");
				}
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
			if (percentage > 100)
			{
				return;
			}

			this.CurrentResistance = percentage;
			this.SendToPatient($"<{Tag.MT.ToString()}>patient<{Tag.AC.ToString()}>resistance<{Tag.SR.ToString()}>{percentage}<{Tag.EOF.ToString()}>");
			this.SendMessageToPatient($"Resistance naar {percentage}% gezet");
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

			this.SendResistance(this.CurrentResistance + 10);
			Console.WriteLine("Session begins");
		}

		public void EndSession()
		{
			double averageHeartrate = this.GetAverageHeartrate(this.Heartrates);
			double averagePower = this.GetAverageWatts(this.Watts);

			this.CurrentPatient.Session.VO2Max = this.GetMultiplier(this.CurrentPatient.Age) * this.CalculateVO2Max(averagePower, averageHeartrate);

			if (this.IsSteadyState(this.Heartrates))
			{
				this.SendMessageToPatient($"Steady state. VO2 max: {Math.Round(this.CurrentPatient.Session.VO2Max, 2, MidpointRounding.AwayFromZero)} ml/kg/min");
				this.CurrentPatient.Session.SteadyState = true;
			}
			else
			{
				this.SendMessageToPatient($"Geen steady state. VO2 max: {Math.Round(this.CurrentPatient.Session.VO2Max, 2, MidpointRounding.AwayFromZero)} ml/kg/min");
				this.CurrentPatient.Session.SteadyState = true;
			}
			this.SavePatient(this.CurrentPatient);
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

		public bool IsSteadyState(List<double> values)
		{
			double[] lastThreeValues = values.ToArray().SubArray(values.Count - 4, 4);
			return (lastThreeValues.Max() - lastThreeValues.Min()) < 5;
		}

		public double GetAverageHeartrate(List<double> values)
		{
			double[] lastTwoMinutesValues = values.ToArray().SubArray(values.Count - 8, 8);

			return this.Average(lastTwoMinutesValues);
		}

		public double GetAverageWatts(List<double> values)
		{
			double[] tempValues = values.ToArray().SubArray(values.Count - 8, 8);

			return this.Average(tempValues);
		}

		public double GetMultiplier(int age)
		{
			if (age >= 15 && age < 25)
			{
				return 1.1;
			}
			else if (age >= 25 && age < 35)
			{
				return 1.0;
			}
			else if (age >= 35 && age < 40)
			{
				return 0.87;
			}
			else if (age >= 40 && age < 45)
			{
				return 0.83;
			}
			else if (age >= 45 && age < 50)
			{
				return 0.78;
			}
			else if (age >= 50 && age < 55)
			{
				return 0.75;
			}
			else if (age >= 55 && age < 60)
			{
				return 0.71;
			}
			else if (age >= 60 && age < 65)
			{
				return 0.68;
			}
			else if (age >= 65)
			{
				return 0.65;
			}


			return 0.0;
		}

		public double Average(double[] values)
		{
			double total = 0.0;

			foreach (double v in values)
			{
				total += v;
			}
			return total / values.Length;
		}

		private void OnWarmingUpDone(object sender, ElapsedEventArgs e)
		{
			this.CurrentTest = Test.RealTest;
			this.TimerRealTest.Start();
			this.TimerHROneMinute.Start();
			this.TimerResistanceFiveSec.Start();
			this.TimerWarmingUp.Stop();
			Console.WriteLine("Warming up is done");
		}

		private void OnRealTestDone(object sender, ElapsedEventArgs e)
		{
			this.CurrentTest = Test.CoolingDown;
			this.TimerCoolingDown.Start();
			this.TimerRealTest.Stop();
			this.TimerHRFifteenSec.Stop();

			this.Heartrates.ForEach(Console.WriteLine);

			this.SendResistance(10);
			Console.WriteLine("Test is done");
		}

		private void OnCoolingDownDone(object sender, ElapsedEventArgs e)
		{
			this.CurrentTest = Test.After;
			this.EndSession();
			this.TimerCoolingDown.Stop();
			Console.WriteLine("Cooling down is done");
		}

		private void OnHRFifteenSecondsDone(object sender, ElapsedEventArgs e)
		{
			this.readHR = true;
		}

		private void OnHROneMinuteDone(object sender, ElapsedEventArgs e)
		{
			this.readHR = true;

			this.oneMinuteCount++;

			if (this.oneMinuteCount == 2)
			{
				this.TimerHROneMinute.Stop();
				this.TimerHRFifteenSec.Start();
			}
		}

		private void OnResistanceFiveSecDone(object sender, ElapsedEventArgs e)
		{
			this.setResistance = true;
		}
	}
}
