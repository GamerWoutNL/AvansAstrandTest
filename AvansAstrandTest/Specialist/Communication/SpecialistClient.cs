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
		private int length;
        private PatientReceivedCallback callback;
		public List<Patient> Patients { get; set; }

		public SpecialistClient()
		{
			this.client = new TcpClient();
			this.buffer = new byte[65536];
		}

		public void Connect(string host, int port)
		{
			this.client.Connect(host, port);
			this.stream = this.client.GetStream();

			this.stream.BeginRead(this.buffer, 0, this.buffer.Length, new AsyncCallback(OnRead), null);

			this.RefreshPatients();
		}

        public void AttachPatientReceivedCallback(PatientReceivedCallback callback)
        {
            this.callback = callback;
        }

		private void OnRead(IAsyncResult ar)
		{
			try
			{
				int count = this.stream.EndRead(ar);

				if (count == 4)
				{
					this.length = BitConverter.ToInt32(this.buffer, 0);
				}
				else
				{
					object obj = this.buffer.SubArray(0, this.length).Deserialize<object>();
					this.HandleObject(obj);
				}

				this.stream.BeginRead(this.buffer, 0, this.buffer.Length, new AsyncCallback(OnRead), null);
			}
			catch (IOException)
			{
				this.Disconnect();
				Console.WriteLine("Server has shut down");
			}
		}

		private void HandleObject(object obj)
		{
			if (obj is List<Patient>)
			{
				this.Patients = (List<Patient>)obj;
                if (this.callback != null) this.callback.PatientsReceived();
			}
			else if (obj is BoolWrapper boolWrapper)
			{
				if (!boolWrapper.CanAccess)
				{
					this.RefreshPatients();
				}
			}
		}

		public void RefreshPatients()
		{
			this.Write($"<{Tag.MT.ToString()}>specialist<{Tag.AC.ToString()}>getaccess<{Tag.EOF.ToString()}>");
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
