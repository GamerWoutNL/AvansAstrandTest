using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ServerProgram.Communication
{
	public class Server
	{
		private TcpListener listener;
		public List<ServerClient> Clients { get; set; }
		public ServerClient Patient { get; set; }

		public Server(int port)
		{
			this.listener = new TcpListener(IPAddress.Any, port);
			this.Clients = new List<ServerClient>();
			this.Patient = null;
		}

		public void Start()
		{
			this.listener.Start();
			this.listener.BeginAcceptTcpClient(new AsyncCallback(OnConnect), null);
			Console.WriteLine("Listening..");
		}

		private void OnConnect(IAsyncResult ar)
		{
			TcpClient newClient = this.listener.EndAcceptTcpClient(ar);
			this.Clients.Add(new ServerClient(newClient, this));
			Console.WriteLine("New client connected");

			this.listener.BeginAcceptTcpClient(new AsyncCallback(OnConnect), null);
		}

		public void SentToPatient(string message)
		{
			this.Patient.Write(message);
		}

		public void Stop()
		{
			foreach (var client in this.Clients)
			{
				client.Disconnect();
			}
			this.listener.Stop();
		}

	}
}
