using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerProgram.Communication;
using ServerProgram.Data;

namespace ServerProgram
{
	class Program
	{
		static void Main(string[] args)
		{
			Server server = new Server(5678);
			server.Start();

			Console.ReadKey();
			server.Stop();
		}
	}
}
