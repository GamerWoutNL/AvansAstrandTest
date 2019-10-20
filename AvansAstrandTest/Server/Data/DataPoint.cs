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
		public DateTime Time { get; set; }
		public double Data { get; set; }

		public DataPoint(DateTime time, double data)
		{
			this.Time = time;
			this.Data = data;
		}
	}
}
