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
		public List<DataPoint> SpeedDataPoints { get; set; }
		public List<DataPoint> DistanceDataPoints { get; set; }
		public List<DataPoint> InstantaniousCadenceDataPoints { get; set; }
		public List<DataPoint> AccumulatedPowerDataPoints { get; set; }
		public List<DataPoint> InstantaniousPowerDataPoints { get; set; }

		public Session()
		{
			this.HeartrateDataPoints = new List<DataPoint>();
			this.SpeedDataPoints = new List<DataPoint>();
			this.DistanceDataPoints = new List<DataPoint>();
			this.InstantaniousCadenceDataPoints = new List<DataPoint>();
			this.AccumulatedPowerDataPoints = new List<DataPoint>();
			this.InstantaniousPowerDataPoints = new List<DataPoint>();
		}
	}
}
