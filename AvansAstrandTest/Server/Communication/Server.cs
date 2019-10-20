using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using ServerProgram.Data;

namespace ServerProgram.Communication
{
	public class Server
	{
		private TcpListener listener;
		public List<ServerClient> Clients { get; set; }
		public List<Patient> Patients { get; set; }
		public Patient CurrentPatient { get; set; }

		public Server(int port)
		{
			FileIO.CreateLogFile();
			this.listener = new TcpListener(IPAddress.Any, port);
			this.Clients = new List<ServerClient>();
			this.Patients = FileIO.ReadFromBinaryFile<List<Patient>>();
			this.CurrentPatient = null;
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
			this.CurrentPatient.Client.Write(message);
		}

		public void Stop()
		{
			foreach (var client in this.Clients)
			{
				client.Disconnect();
			}
			this.listener.Stop();
		}

		public void SendResistance(int percentage)
		{
			this.SentToPatient($"<{Tag.MT.ToString()}>patient<{Tag.AC.ToString()}>resistance<{Tag.SR.ToString()}>{percentage}<{Tag.EOF.ToString()}>");
		}

		public void SendMessageToPatient(string message)
		{
			this.SentToPatient($"<{Tag.MT.ToString()}>patient<{Tag.AC.ToString()}>message<{Tag.DM.ToString()}>{message}<{Tag.EOF.ToString()}>");
		}

		public void SavePatient(Patient patient)
		{
			this.Patients.Add(patient);
			FileIO.WriteToBinaryFile(this.Patients);
		}
	}
}
