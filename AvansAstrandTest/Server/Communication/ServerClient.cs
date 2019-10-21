using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using ServerProgram.Data;
using System.IO;
using System.Timers;
using System.Threading;

namespace ServerProgram.Communication
{
	public class ServerClient
	{
		private TcpClient client;
		private NetworkStream stream;
		private byte[] buffer;
		public bool IsPatient { get; set; }
		public Server Server { get; set; }

		public ServerClient(TcpClient client, Server server)
		{
			this.client = client;
			this.stream = this.client.GetStream();
			this.buffer = new byte[1024];
			this.IsPatient = false;
			this.Server = server;

			this.stream.BeginRead(this.buffer, 0, this.buffer.Length, new AsyncCallback(OnRead), null);
		}

		private void OnRead(IAsyncResult ar)
		{
			try
			{
				int count = this.stream.EndRead(ar);
				string read = Encrypter.Decrypt(this.buffer.SubArray(0, count), "password123");

				string eof = $"<{Tag.EOF.ToString()}>";
				while (read.Contains(eof))
				{
					string packet = read.Substring(0, read.IndexOf(eof) + eof.Length);
					read = read.Substring(packet.IndexOf(eof) + eof.Length);

					this.HandlePacket(packet);
				}
				this.stream.BeginRead(this.buffer, 0, this.buffer.Length, new AsyncCallback(OnRead), null);
			}
			catch (IOException)
			{
				this.Disconnect();
				this.Server.Clients.Remove(this);
				Console.WriteLine("Client disconnected");
			}
		}

		private void HandlePacket(string packet)
		{
			string messageType = TagDecoder.GetValueByTag(Tag.MT, packet);

			if (messageType == "patient")
			{
				this.HandlePatientPacket(packet);
			}
		}

		private void HandlePatientPacket(string packet)
		{
			string action = TagDecoder.GetValueByTag(Tag.AC, packet);

			if (action == "login")
			{
				this.HandlePatientLogin(packet);
			}
			else if (action == "data")
			{
				this.HandlePatientData(packet);
			}
			else if (action == "sessionstart")
			{
				this.HandleStartSession();
			}
		}

		private void HandleStartSession()
		{
			this.Server.BeginSession();
		}

		private void HandlePatientLogin(string packet)
		{
			string name = TagDecoder.GetValueByTag(Tag.PNA, packet);
			string age = TagDecoder.GetValueByTag(Tag.PAG, packet);
			string gender = TagDecoder.GetValueByTag(Tag.PGE, packet);
			string weight = TagDecoder.GetValueByTag(Tag.PWE, packet);

			this.Server.CurrentPatient = new Patient(name, int.Parse(age), gender == "M" ? Gender.Male : Gender.Female, int.Parse(weight));
			this.IsPatient = true;
		}

		private void HandlePatientData(string packet)
		{
			string pageNumber = TagDecoder.GetValueByTag(Tag.PA, packet);

			if (pageNumber == "page16")
			{
				this.HandlePatientDataPage16(packet);
			}
			else if (pageNumber == "page25")
			{
				this.HandlePatientDataPage25(packet);
			}
		}

		private void HandlePatientDataPage16(string packet)
		{
			string timestamp = TagDecoder.GetValueByTag(Tag.TS, packet);
			string heartRate = TagDecoder.GetValueByTag(Tag.HR, packet);

			this.Server.AddDataHeartRate(DateTime.Parse(timestamp), double.Parse(heartRate));

			this.Server.SentToPatient($"<{Tag.MT.ToString()}>patient<{Tag.AC.ToString()}>data<{Tag.PA.ToString()}>page16<{Tag.HR.ToString()}>{heartRate}<{Tag.EOF.ToString()}>");
		}

		private void HandlePatientDataPage25(string packet)
		{
			string timestamp = TagDecoder.GetValueByTag(Tag.TS, packet);
			string instantaneousCadence = TagDecoder.GetValueByTag(Tag.IC, packet);
			string instantaneousPower = TagDecoder.GetValueByTag(Tag.IP, packet);

			this.Server.AddDataCadenceAndPower(DateTime.Parse(timestamp), double.Parse(instantaneousCadence), double.Parse(instantaneousPower));

			this.Server.SentToPatient($"<{Tag.MT.ToString()}>patient<{Tag.AC.ToString()}>data<{Tag.PA.ToString()}>page25<{Tag.IC.ToString()}>{instantaneousCadence}<{Tag.IP.ToString()}>{instantaneousPower}<{Tag.EOF.ToString()}>");
		}

		public void WriteObject<T>(T obj)
		{
			byte[] objectBytes = obj.SerializeToByteArray();
			this.stream.Write(BitConverter.GetBytes(objectBytes.Length), 0, 4);
			this.stream.Write(objectBytes, 0, objectBytes.Length);
			this.stream.Flush();
			Thread.Sleep(1000);
		}
		
		public void Write(string message)
		{
			byte[] encrypted = Encrypter.Encrypt(message, "password123");
			this.stream.Write(encrypted, 0, encrypted.Length);
			this.stream.Flush();
		}

		public void Disconnect()
		{
			this.stream.Close();
			this.client.Close();
		}

		public static byte[] Combine(byte[] first, byte[] second)
		{
			byte[] ret = new byte[first.Length + second.Length];
			Buffer.BlockCopy(first, 0, ret, 0, first.Length);
			Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);
			return ret;
		}
	}
}
