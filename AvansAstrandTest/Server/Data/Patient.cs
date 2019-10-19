using ServerProgram.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerProgram.Data
{
	public class Patient
	{
		public ServerClient Client { get; set; }
		public string Name { get; set; }
		public int Age { get; set; }
		public Gender Gender { get; set; }
		public int Weight { get; set; }
		public List<Session> Sessions { get; set; }
		public Session CurrentSession { get; set; }
		private bool canAdd;

		public Patient(ServerClient client, string name, int age, string gender, int weight)
		{
			this.Client = client;
			this.Name = name;
			this.Age = age;
			this.Gender = gender == "M" ? Gender.Male : Gender.Female;
			this.Weight = weight;
			this.Sessions = new List<Session>();
			this.canAdd = false;
		}

		public void AddDataHeartRate(string timestamp, string heartrate)
		{
			if (this.canAdd)
			{
				this.CurrentSession.HeartrateDataPoints.Add(new DataPoint(heartrate, timestamp));
			}
		}

		public void AddDataCadence(string timestamp, string instantaneousCadence)
		{
			if (this.canAdd)
			{
				this.CurrentSession.InstantaniousCadenceDataPoints.Add(new DataPoint(instantaneousCadence, timestamp));
			}
		}

		public void BeginSession()
		{
			this.CurrentSession = new Session();
			this.canAdd = true;
		}

		public void EndSession()
		{
			this.canAdd = false;
			this.Sessions.Add(this.CurrentSession);
		}

	}
}
