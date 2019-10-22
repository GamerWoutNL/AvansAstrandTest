﻿using ServerProgram.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerProgram.Data
{
	public class TestLogics
	{
		private Server server;
		public List<DataPoint> HeartrateDataPoints { get; set; }
		public List<DataPoint> InstantaniousCadenceDataPoints { get; set; }
		public List<DataPoint> InstantaniousPowerDataPoints { get; set; }

		public TestLogics(Server server)
		{
			this.server = server;
			this.HeartrateDataPoints = new List<DataPoint>();
			this.InstantaniousCadenceDataPoints = new List<DataPoint>();
			this.InstantaniousPowerDataPoints = new List<DataPoint>();
		}
	}
}
