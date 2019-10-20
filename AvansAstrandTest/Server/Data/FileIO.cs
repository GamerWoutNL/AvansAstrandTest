using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServerProgram.Data
{
	public class FileIO
	{
		public static string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\AvansAstrand\log.txt";

		public static void WriteToBinaryFile<T>(T objectToWrite)
		{
			using (Stream stream = File.Open(path, FileMode.Create))
			{
				var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
				binaryFormatter.Serialize(stream, objectToWrite);
			}
		}

		public static T ReadFromBinaryFile<T>() where T : new()
		{
			try
			{
				using (Stream stream = File.Open(path, FileMode.Open))
				{
					var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
					return (T)binaryFormatter.Deserialize(stream);
				}
			}
			catch (SerializationException)
			{
				return new T();
			}
		}

		public static void CreateLogFile()
		{
			if (!File.Exists(path))
			{
				Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\AvansAstrand");

				using (Stream stream = File.Create(path)) { }
			}
		}
	}
}
