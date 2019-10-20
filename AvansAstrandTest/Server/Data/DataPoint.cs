using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerProgram.Data
{
	[Serializable]
	public class DataPoint
	{
		public string Data { get; set; }
		public string Time { get; set; }

		public DataPoint(string data, string time)
		{
			this.Data = data;
			this.Time = time;
		}
	}
}
