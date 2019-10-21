using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ServerProgram.Data
{
	public static class Encrypter
	{
		private static byte[] IV = { 187, 165, 69, 255, 230, 174, 56, 74, 46, 87, 255, 203, 93, 21, 168, 114 };

		public static byte[] Encrypt(string plainText, string key)
		{
			byte[] encrypted;
			byte[] keyBytes = GetKeyBytes(key);

			using (AesManaged aes = new AesManaged())
			{
				ICryptoTransform encryptor = aes.CreateEncryptor(keyBytes, IV);
				using (MemoryStream ms = new MemoryStream())
				{
					using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
					{
						using (StreamWriter sw = new StreamWriter(cs))
						{
							sw.Write(plainText);
						}
						encrypted = ms.ToArray();
					}
				}
			}
			return encrypted;
		}

		public static string Decrypt(byte[] cipherText, string key)
		{
			string plaintext = null;

			try
			{
				byte[] keyBytes = GetKeyBytes(key);

				using (AesManaged aes = new AesManaged())
				{
					ICryptoTransform decryptor = aes.CreateDecryptor(keyBytes, IV);
					using (MemoryStream ms = new MemoryStream(cipherText))
					{
						using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
						{
							using (StreamReader reader = new StreamReader(cs))
							{
								plaintext = reader.ReadToEnd();
							}
						}
					}
				}
			}
			catch (CryptographicException)
			{
				throw;
			}
			

			return plaintext;
		}

		private static byte[] GetKeyBytes(string key)
		{
			byte[] result = new byte[32];

			int i = 0;
			foreach (byte b in Encoding.ASCII.GetBytes(key))
			{
				result[i++] = b;
			}

			return result;
		}

		public static T[] SubArray<T>(this T[] data, int index, int length)
		{
			T[] result = new T[length];
			Array.Copy(data, index, result, 0, length);
			return result;
		}

		public static byte[] SerializeToByteArray(this object obj)
		{
			if (obj == null)
			{
				return null;
			}
			var bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
			using (var ms = new MemoryStream())
			{
				bf.Serialize(ms, obj);
				return ms.ToArray();
			}
		}

		public static T Deserialize<T>(this byte[] byteArray) where T : class
		{
			if (byteArray == null)
			{
				return null;
			}
			using (var memStream = new MemoryStream())
			{
				var binForm = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
				memStream.Write(byteArray, 0, byteArray.Length);
				memStream.Seek(0, SeekOrigin.Begin);
				var obj = (T)binForm.Deserialize(memStream);
				return obj;
			}
		}

		//public static T Deserialize<T>(this string toDeserialize)
		//{
		//	XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
		//	using (StringReader textReader = new StringReader(toDeserialize))
		//	{
		//		return (T)xmlSerializer.Deserialize(textReader);
		//	}
		//}

		//public static string Serialize<T>(this T toSerialize)
		//{
		//	XmlSerializer xmlSerializer = new XmlSerializer(toSerialize.GetType());
		//	using (StringWriter textWriter = new StringWriter())
		//	{
		//		xmlSerializer.Serialize(textWriter, toSerialize);
		//		return textWriter.ToString();
		//	}
		//}

	}
}
