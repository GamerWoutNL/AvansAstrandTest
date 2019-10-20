using ServerProgram.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		private bool canAdd;

		public Patient(ServerClient client, string name, int age, string gender, int weight)
		{
			this.Client = client;
			this.Name = name;
			this.Age = age;
			this.Gender = gender == "M" ? Gender.Male : Gender.Female;
			this.Weight = weight;
			this.canAdd = false;
		}

		public void AddDataHeartRate(DateTime timestamp, double heartrate)
		{
			if (this.canAdd)
			{
				this.Session.HeartrateDataPoints.Add(new DataPoint(timestamp, heartrate));

				//TODO: Calculations
			}
		}

		public void AddDataCadence(DateTime timestamp, double instantaneousCadence)
		{
			if (this.canAdd)
			{
				this.Session.InstantaniousCadenceDataPoints.Add(new DataPoint(timestamp, instantaneousCadence));

				//TODO: Calculations
			}
		}

		public void BeginSession()
		{
			this.Session = new Session();
			this.canAdd = true;
		}

		public void EndSession()
		{
			this.canAdd = false;
			this.Client.Server.SavePatient(this);
		}

	}
}
