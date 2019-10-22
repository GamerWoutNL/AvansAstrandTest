using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Specialist.Communication;

namespace Specialist
{
	class Program
	{
		static void Main(string[] args)
		{
			SpecialistClient client = new SpecialistClient();
			client.Connect("localhost", 5678);

            DokterView dokterView = new DokterView(client);
            client.AttachPatientReceivedCallback(dokterView);
            dokterView.ShowDialog();

			Console.ReadKey();
			client.Disconnect();
		}
	}
}
