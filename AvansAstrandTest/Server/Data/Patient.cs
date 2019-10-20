using ServerProgram.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ServerProgram.Data
{
	[Serializable]
	public class Patient
	{
		public ServerClient Client { get; set; }
		public string Name { get; set; }
		public int Age { get; set; }
		public Gender Gender { get; set; }
		public int Weight { get; set; }
		public Session Session { get; set; }
		public Timer TimerWarmingUp { get; set; }
		public Timer TimerRealTest { get; set; }
		public Timer TimerCoolingDown { get; set; }
		public Test CurrentTest { get; set; }

		public Patient(ServerClient client, string name, int age, string gender, int weight)
		{
			this.Client = client;
			this.Name = name;
			this.Age = age;
			this.Gender = gender == "M" ? Gender.Male : Gender.Female;
			this.Weight = weight;
			this.CurrentTest = Test.Before;

			this.TimerWarmingUp = new Timer(2 * 60 * 1000);
			this.TimerRealTest = new Timer(4 * 60 * 1000);
			this.TimerCoolingDown = new Timer(60 * 1000);

			this.TimerWarmingUp.Elapsed += new ElapsedEventHandler(OnWarmingUpDone);
			this.TimerRealTest.Elapsed += new ElapsedEventHandler(OnRealTestDone);
			this.TimerCoolingDown.Elapsed += new ElapsedEventHandler(OnCoolingDownDone);
		}

		public void AddDataHeartRate(DateTime timestamp, double heartrate)
		{
			if (this.CurrentTest == Test.RealTest)
			{
				this.Session.HeartrateDataPoints.Add(new DataPoint(timestamp, heartrate));

				//TODO: Calculations
			}
		}

		public void AddDataCadenceAndPower(DateTime timestamp, double instantaneousCadence, double instantaneousPower)
		{
			if (this.CurrentTest == Test.RealTest)
			{
				this.Session.InstantaniousCadenceDataPoints.Add(new DataPoint(timestamp, instantaneousCadence));
				this.Session.InstantaniousPowerDataPoints.Add(new DataPoint(timestamp, instantaneousPower));
				//TODO: Calculations
			}
		}

		public void BeginSession()
		{
			this.Session = new Session();
			this.TimerWarmingUp.Start();
			this.CurrentTest = Test.WarmingUp;
		}

		public void EndSession()
		{
			this.Client.Server.SavePatient(this);
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
