﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using ServerProgram.Data;
using System.Timers;

namespace ServerProgram.Communication
{
	public class Server
	{
		private TcpListener listener;
		public List<ServerClient> Clients { get; set; }
		public List<Patient> Patients { get; set; }
		public Patient CurrentPatient { get; set; }
		public Timer TimerWarmingUp { get; set; }
		public Timer TimerRealTest { get; set; }
		public Timer TimerCoolingDown { get; set; }
		public Test CurrentTest { get; set; }

		// Male:   VO2max = (0.00212 * Workload + 0.299) / (0.769 * Heart Rate - 48.5) x 1000
		// Female: VO2max = (0.00193 * Workload + 0.326) / (0.769 * Heart Rate - 56.1) x 1000

		public Server(int port)
		{
			FileIO.CreateLogFile();
			this.listener = new TcpListener(IPAddress.Any, port);
			this.Clients = new List<ServerClient>();
			this.Patients = FileIO.ReadFromBinaryFile<List<Patient>>();
			this.CurrentPatient = null;

			this.CurrentTest = Test.Before;

			this.TimerWarmingUp = new Timer(2 * 60 * 1000);
			this.TimerRealTest = new Timer(4 * 60 * 1000);
			this.TimerCoolingDown = new Timer(60 * 1000);

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

		public void SentToPatient(string message)
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
			if (this.CurrentTest == Test.RealTest)
			{
				this.CurrentPatient.Session.HeartrateDataPoints.Add(new DataPoint(timestamp, heartrate));

				//TODO: Calculations and user feedback about the session
			}
		}

		public void AddDataCadenceAndPower(DateTime timestamp, double instantaneousCadence, double instantaneousPower)
		{
			if (this.CurrentTest == Test.RealTest)
			{
				this.CurrentPatient.Session.InstantaniousCadenceDataPoints.Add(new DataPoint(timestamp, instantaneousCadence));
				this.CurrentPatient.Session.InstantaniousPowerDataPoints.Add(new DataPoint(timestamp, instantaneousPower));

				//TODO: Calculations and user feedback about the session
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
			this.SentToPatient($"<{Tag.MT.ToString()}>patient<{Tag.AC.ToString()}>resistance<{Tag.SR.ToString()}>{percentage}<{Tag.EOF.ToString()}>");
		}

		public void SendMessageToPatient(string message)
		{
			this.SentToPatient($"<{Tag.MT.ToString()}>patient<{Tag.AC.ToString()}>message<{Tag.DM.ToString()}>{message}<{Tag.EOF.ToString()}>");
		}

		public void SavePatient(Patient patient)
		{
			this.Patients.Add(patient);
			FileIO.WriteToBinaryFile(this.Patients);
		}

		public void BeginSession()
		{
			this.CurrentPatient.Session = new Session();
			this.TimerWarmingUp.Start();
			this.CurrentTest = Test.WarmingUp;
		}

		public void EndSession()
		{
			this.SavePatient(this.CurrentPatient);
		}

		private void OnWarmingUpDone(object sender, ElapsedEventArgs e)
		{
			this.CurrentTest = Test.RealTest;
			this.TimerRealTest.Start();
			this.TimerWarmingUp.Stop();
		}

		private void OnRealTestDone(object sender, ElapsedEventArgs e)
		{
			this.CurrentTest = Test.CoolingDown;
			this.TimerCoolingDown.Start();
			this.TimerRealTest.Stop();
		}

		private void OnCoolingDownDone(object sender, ElapsedEventArgs e)
		{
			this.CurrentTest = Test.After;
			this.EndSession();
			this.TimerCoolingDown.Stop();
		}
	}
}
