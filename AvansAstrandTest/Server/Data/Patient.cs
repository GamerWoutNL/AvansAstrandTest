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

		public void AddDataHeartRate(string timestamp, string heartrate)
		{
			if (this.canAdd)
			{
				this.Session.HeartrateDataPoints.Add(new DataPoint(heartrate, timestamp));

				//TODO: Calculations
			}
		}

		public void AddDataCadence(string timestamp, string instantaneousCadence)
		{
			if (this.canAdd)
			{
				this.Session.InstantaniousCadenceDataPoints.Add(new DataPoint(instantaneousCadence, timestamp));

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
