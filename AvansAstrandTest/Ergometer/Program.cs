using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ergometer.Communication;

namespace Ergometer
{
	class Program
	{
		static void Main(string[] args)
		{
			ErgoClient client = new ErgoClient();
			client.Connect("localhost", 5678);

			Console.ReadKey();
			client.Disconnect();
		}
	}
}
