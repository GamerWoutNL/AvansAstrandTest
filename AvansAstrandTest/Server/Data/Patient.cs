using ServerProgram.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Xml.Serialization;

namespace ServerProgram.Data
{
	[Serializable]
	public class Patient
	{
		public string Name { get; set; }
		public int Age { get; set; }
		public Gender Gender { get; set; }
		public int Weight { get; set; }
		public Session Session { get; set; }

		public Patient(string name, int age, Gender gender, int weight)
		{
			this.Name = name;
			this.Age = age;
			this.Gender = gender;
			this.Weight = weight;
		}

	}
}
