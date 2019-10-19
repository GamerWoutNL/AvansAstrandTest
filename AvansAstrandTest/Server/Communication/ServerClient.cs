using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using ServerProgram.Data;
using System.IO;

namespace ServerProgram.Communication
{
	public class ServerClient
	{
		private TcpClient client;
		private Server server;
		private NetworkStream stream;
		private byte[] buffer;

		public ServerClient(TcpClient client, Server server)
		{
			this.client = client;
			this.server = server;
			this.stream = this.client.GetStream();
			this.buffer = new byte[1024];

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
				this.server.Clients.Remove(this);
				Console.WriteLine("Client disconnected");
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
