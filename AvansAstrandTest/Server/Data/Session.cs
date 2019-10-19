using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerProgram.Data
{
	public class Session
	{
		public List<DataPoint> HeartrateDataPoints { get; set; }
		public List<DataPoint> InstantaniousCadenceDataPoints { get; set; }

		public Session()
		{
			this.HeartrateDataPoints = new List<DataPoint>();
			this.InstantaniousCadenceDataPoints = new List<DataPoint>();
		}
	}
}
