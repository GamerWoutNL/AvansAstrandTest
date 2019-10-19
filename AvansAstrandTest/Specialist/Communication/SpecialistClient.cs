using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;
using ServerProgram.Data;

namespace Specialist.Communication
{
	public class SpecialistClient
	{
		private TcpClient client;
		private NetworkStream stream;
		private byte[] buffer;

		public SpecialistClient()
		{
			this.client = new TcpClient();
			this.buffer = new byte[1024];
		}

		public void Connect(string host, int port)
		{
			this.client.Connect(host, port);
			this.stream = this.client.GetStream();

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
				Console.WriteLine("Server has shut down");
			}
		}

		private void HandlePacket(string packet)
		{
			Console.WriteLine(packet);
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
	}
}
