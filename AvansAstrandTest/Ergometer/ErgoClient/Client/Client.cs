using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ErgoConnect;
using ServerProgram.Data;
using System.IO;

namespace Client
{
    class Client : IClient
    {
		private TcpClient _tcpClient;
        private NetworkStream _stream;
		private byte[] _buffer;
		private string totalBuffer;
		private string _ergoID;
		public BLEConnect bleConnect { get; set; }

		public Client()
		{
			this._tcpClient = new TcpClient();
			this._buffer = new byte[1024];
			this.totalBuffer = string.Empty;
		}

		public void Connect(string server, int port, string ergoID)
		{
			this._tcpClient.Connect(server, port);
			this._stream = this._tcpClient.GetStream();
			this._ergoID = ergoID;

			this._stream.BeginRead(this._buffer, 0, this._buffer.Length, new AsyncCallback(OnRead), null);
		}

		public void Disconnect()
		{
			this._stream.Close();
			this._tcpClient.Close();
		}

        private void OnRead(IAsyncResult ar)
        {
			try
			{
				int count = this._stream.EndRead(ar);
				this.totalBuffer += Encrypter.Decrypt(this._buffer.SubArray(0, count), "password123");

				string eof = $"<{Tag.EOF.ToString()}>";
				while (totalBuffer.Contains(eof))
				{
					string packet = totalBuffer.Substring(0, totalBuffer.IndexOf(eof) + eof.Length);
					totalBuffer = totalBuffer.Substring(packet.IndexOf(eof) + eof.Length);

					this.HandlePacket(packet);
				}

				this._stream.BeginRead(this._buffer, 0, this._buffer.Length, new AsyncCallback(OnRead), null);
			} 
			catch (IOException)
			{
				this.Disconnect();
				Console.WriteLine("Server has shut down");
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
			if (action == "resistance")
			{
				this.HandleSetResistance(packet);
			}
			else if (action == "data")
			{
				this.HandleDataPacket(packet);
			}
			else if (action == "message")
			{
				this.HandleMessage(packet);
			}
		}

		private void HandleMessage(string packet)
		{
			string message = TagDecoder.GetValueByTag(Tag.DM, packet);
			Console.WriteLine($"Message: {message}");

			//TODO: Make this visual to the patient
		}

		private void HandleDataPacket(string packet)
		{
			string pageNumber = TagDecoder.GetValueByTag(Tag.PA, packet);

			if (pageNumber == "page16")
			{
				string heartRate = TagDecoder.GetValueByTag(Tag.HR, packet);
				Console.WriteLine($"Heart rate: {heartRate} bpm");
			}
			else if (pageNumber == "page25")
			{
				string instantaneousCadence = TagDecoder.GetValueByTag(Tag.IC, packet);
				string instantaneousPower = TagDecoder.GetValueByTag(Tag.IP, packet);
				Console.WriteLine($"\t\tCadence: {instantaneousCadence} rpm");
				Console.WriteLine($"\t\t\t\tPower: {instantaneousPower} watt");
			}

			//TODO: Make this visual to the patient
		}

		private void HandleSetResistance(string packet)
		{
			int resistancePercentage = int.Parse(TagDecoder.GetValueByTag(Tag.SR, packet));
			Console.WriteLine($"Resistance: {resistancePercentage}");

			this.bleConnect.SetResistance(resistancePercentage);

			//TODO: Make this visual to the patient
		}

		public void Write(string message)
		{
            //Console.WriteLine(message);
			byte[] encrypted = Encrypter.Encrypt(message, "password123");
			this._stream.Write(encrypted, 0, encrypted.Length);
			this._stream.Flush();
		}
	}
}
