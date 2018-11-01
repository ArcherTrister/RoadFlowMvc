using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace RoadFlow.Utility
{
	public class EncryptionDes
	{
		private static string Key = "X!xO@kA)";

		public static string Encrypt(string pToEncrypt)
		{
			if (!string.IsNullOrWhiteSpace(pToEncrypt))
			{
				try
				{
					DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
					byte[] bytes = Encoding.Default.GetBytes(pToEncrypt);
					dESCryptoServiceProvider.Key = Encoding.ASCII.GetBytes(Key);
					dESCryptoServiceProvider.IV = Encoding.ASCII.GetBytes(Key);
					MemoryStream memoryStream = new MemoryStream();
					CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateEncryptor(), CryptoStreamMode.Write);
					cryptoStream.Write(bytes, 0, bytes.Length);
					cryptoStream.FlushFinalBlock();
					StringBuilder stringBuilder = new StringBuilder();
					byte[] array = memoryStream.ToArray();
					foreach (byte b in array)
					{
						stringBuilder.AppendFormat("{0:X2}", b);
					}
					stringBuilder.ToString();
					return stringBuilder.ToString();
				}
				catch
				{
					return "";
				}
			}
			return string.Empty;
		}

		public static string Decrypt(string pToDecrypt)
		{
			if (!string.IsNullOrWhiteSpace(pToDecrypt))
			{
				try
				{
					DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
					byte[] array = new byte[pToDecrypt.Length / 2];
					for (int i = 0; i < pToDecrypt.Length / 2; i++)
					{
						int num = Convert.ToInt32(pToDecrypt.Substring(i * 2, 2), 16);
						array[i] = (byte)num;
					}
					dESCryptoServiceProvider.Key = Encoding.ASCII.GetBytes(Key);
					dESCryptoServiceProvider.IV = Encoding.ASCII.GetBytes(Key);
					MemoryStream memoryStream = new MemoryStream();
					CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateDecryptor(), CryptoStreamMode.Write);
					cryptoStream.Write(array, 0, array.Length);
					cryptoStream.FlushFinalBlock();
					new StringBuilder();
					return Encoding.Default.GetString(memoryStream.ToArray());
				}
				catch
				{
					return "";
				}
			}
			return string.Empty;
		}
	}
}
