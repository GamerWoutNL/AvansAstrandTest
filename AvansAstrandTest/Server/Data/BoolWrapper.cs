﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerProgram.Data
{
	public class BoolWrapper
	{
		public bool CanAccess { get; set; }

		public BoolWrapper(bool canAcces)
		{
			this.CanAccess = canAcces;
		}
	}
}