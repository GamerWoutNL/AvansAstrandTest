﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client;
using ErgoConnect.BluetoothLowEnergy;
using System.Threading;
using ServerProgram.Data;

namespace ErgoConnect
{
    /// <summary>
    /// The Program class starts up the application. You can use the simulator to receive data without having physical access to an Ergometer / HR-sensor.
    /// </summary>
    public class Program : ISim
    {
		private Client.Client client;
		private string ergoID;
		public BLEConnect ergo;
        public BLESimulator bLESimulator;

		static void Main(string[] args)
        {
            Console.WriteLine("Patient name: ");
            string patientName = Console.ReadLine();
            Console.WriteLine("Patient age: ");
            string patientAge = Console.ReadLine();
			Console.WriteLine("Patient gender (M/F): ");
			string patientGender = Console.ReadLine();
			Console.WriteLine("Patient weight: ");
			string patientWeight = Console.ReadLine();

			new Program("01249", patientName, patientAge, patientGender, patientWeight); 
        }

		public Program(string ergoID, string patientName, string patientAge, string patientGender, string patientWeight)
		{
			this.ergoID = ergoID;

			this.client = new Client.Client();
			client.Connect("localhost", 5678, ergoID);
			client.Write($"<{Tag.MT.ToString()}>patient<{Tag.AC.ToString()}>login<{Tag.PNA.ToString()}>{patientName}<{Tag.PAG.ToString()}>{patientAge}<{Tag.PGE.ToString()}>{patientGender}<{Tag.PWE.ToString()}>{patientWeight}<{Tag.EOF.ToString()}>");

			this.ergo = new BLEConnect(ergoID, client, this);
			client.bleConnect = ergo;
			this.ergo.Connect();

            Console.Read();
			client.Disconnect();
		}

        public void Create()
		{
			Console.WriteLine("No connection with bike, using simulator.");
			bLESimulator = new BLESimulator(ergoID, client);
            //new Thread(new ThreadStart(bLESimulator.RunSimulator)).Start();
		}
	}
}
