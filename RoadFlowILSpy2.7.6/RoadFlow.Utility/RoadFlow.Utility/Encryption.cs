using System;
using System.Security.Cryptography;
using System.Text;

namespace RoadFlow.Utility
{
	public class Encryption
	{
		private static string encryptKey = "4h!@w$rng,i#$@x1%)5^3(7*5P31/Ee0";

		private static byte[] Keys = new byte[16]
		{
			65,
			114,
			101,
			121,
			111,
			117,
			109,
			121,
			83,
			110,
			111,
			119,
			109,
			97,
			110,
			63
		};

		public static string Encrypt(string encryptString)
		{
			if (string.IsNullOrEmpty(encryptString))
			{
				return string.Empty;
			}
			ICryptoTransform cryptoTransform = new RijndaelManaged
			{
				Key = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 32)),
				IV = Keys
			}.CreateEncryptor();
			byte[] bytes = Encoding.UTF8.GetBytes(encryptString);
			return Convert.ToBase64String(cryptoTransform.TransformFinalBlock(bytes, 0, bytes.Length));
		}

		public static string Decrypt(string decryptString)
		{
			if (!string.IsNullOrEmpty(decryptString))
			{
				try
				{
					ICryptoTransform cryptoTransform = new RijndaelManaged
					{
						Key = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 32)),
						IV = Keys
					}.CreateDecryptor();
					byte[] array = Convert.FromBase64String(decryptString);
					byte[] bytes = cryptoTransform.TransformFinalBlock(array, 0, array.Length);
					return Encoding.UTF8.GetString(bytes);
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
