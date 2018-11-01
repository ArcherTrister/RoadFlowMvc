using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace RoadFlow.Platform.WeiXin
{
	public class Cryptography
	{
		public static uint HostToNetworkOrder(uint inval)
		{
			uint num = 0u;
			for (int i = 0; i < 4; i++)
			{
				num = (num << 8) + ((inval >> i * 8) & 0xFF);
			}
			return num;
		}

		public static int HostToNetworkOrder(int inval)
		{
			int num = 0;
			for (int i = 0; i < 4; i++)
			{
				num = (num << 8) + ((inval >> i * 8) & 0xFF);
			}
			return num;
		}

		public static string AES_decrypt(string Input, string EncodingAESKey, ref string corpid)
		{
			byte[] array = Convert.FromBase64String(EncodingAESKey + "=");
			byte[] array2 = new byte[16];
			Array.Copy(array, array2, 16);
			byte[] array3 = AES_decrypt(Input, array2, array);
			int network = BitConverter.ToInt32(array3, 16);
			network = IPAddress.NetworkToHostOrder(network);
			byte[] array4 = new byte[network];
			byte[] array5 = new byte[array3.Length - 20 - network];
			Array.Copy(array3, 20, array4, 0, network);
			Array.Copy(array3, 20 + network, array5, 0, array3.Length - 20 - network);
			string @string = Encoding.UTF8.GetString(array4);
			corpid = Encoding.UTF8.GetString(array5);
			return @string;
		}

		public static string AES_encrypt(string Input, string EncodingAESKey, string corpid)
		{
			byte[] array = Convert.FromBase64String(EncodingAESKey + "=");
			byte[] array2 = new byte[16];
			Array.Copy(array, array2, 16);
			string s = CreateRandCode(16);
			byte[] bytes = Encoding.UTF8.GetBytes(s);
			byte[] bytes2 = Encoding.UTF8.GetBytes(corpid);
			byte[] bytes3 = Encoding.UTF8.GetBytes(Input);
			byte[] bytes4 = BitConverter.GetBytes(HostToNetworkOrder(bytes3.Length));
			byte[] array3 = new byte[bytes.Length + bytes4.Length + bytes2.Length + bytes3.Length];
			Array.Copy(bytes, array3, bytes.Length);
			Array.Copy(bytes4, 0, array3, bytes.Length, bytes4.Length);
			Array.Copy(bytes3, 0, array3, bytes.Length + bytes4.Length, bytes3.Length);
			Array.Copy(bytes2, 0, array3, bytes.Length + bytes4.Length + bytes3.Length, bytes2.Length);
			return AES_encrypt(array3, array2, array);
		}

		private static string CreateRandCode(int codeLen)
		{
			if (codeLen == 0)
			{
				codeLen = 16;
			}
			string[] array = "2,3,4,5,6,7,a,c,d,e,f,h,i,j,k,m,n,p,r,s,t,A,C,D,E,F,G,H,J,K,M,N,P,Q,R,S,U,V,W,X,Y,Z".Split(',');
			string text = "";
			int num = -1;
			Random random = new Random((int)DateTime.Now.Ticks);
			for (int i = 0; i < codeLen; i++)
			{
				num = random.Next(0, array.Length - 1);
				text += array[num];
			}
			return text;
		}

		private static string AES_encrypt(string Input, byte[] Iv, byte[] Key)
		{
			RijndaelManaged rijndaelManaged = new RijndaelManaged();
			rijndaelManaged.KeySize = 256;
			rijndaelManaged.BlockSize = 128;
			rijndaelManaged.Padding = PaddingMode.PKCS7;
			rijndaelManaged.Mode = CipherMode.CBC;
			rijndaelManaged.Key = Key;
			rijndaelManaged.IV = Iv;
			ICryptoTransform transform = rijndaelManaged.CreateEncryptor(rijndaelManaged.Key, rijndaelManaged.IV);
			byte[] inArray = null;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write))
				{
					byte[] bytes = Encoding.UTF8.GetBytes(Input);
					cryptoStream.Write(bytes, 0, bytes.Length);
				}
				inArray = memoryStream.ToArray();
			}
			return Convert.ToBase64String(inArray);
		}

		private static string AES_encrypt(byte[] Input, byte[] Iv, byte[] Key)
		{
			RijndaelManaged rijndaelManaged = new RijndaelManaged();
			rijndaelManaged.KeySize = 256;
			rijndaelManaged.BlockSize = 128;
			rijndaelManaged.Padding = PaddingMode.None;
			rijndaelManaged.Mode = CipherMode.CBC;
			rijndaelManaged.Key = Key;
			rijndaelManaged.IV = Iv;
			ICryptoTransform transform = rijndaelManaged.CreateEncryptor(rijndaelManaged.Key, rijndaelManaged.IV);
			byte[] inArray = null;
			byte[] array = new byte[Input.Length + 32 - Input.Length % 32];
			Array.Copy(Input, array, Input.Length);
			byte[] array2 = KCS7Encoder(Input.Length);
			Array.Copy(array2, 0, array, Input.Length, array2.Length);
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write))
				{
					cryptoStream.Write(array, 0, array.Length);
				}
				inArray = memoryStream.ToArray();
			}
			return Convert.ToBase64String(inArray);
		}

		private static byte[] KCS7Encoder(int text_length)
		{
			int num = 32;
			int num2 = num - text_length % num;
			if (num2 == 0)
			{
				num2 = num;
			}
			char c = chr(num2);
			string text = "";
			for (int i = 0; i < num2; i++)
			{
				text += c.ToString();
			}
			return Encoding.UTF8.GetBytes(text);
		}

		private static char chr(int a)
		{
			return (char)(byte)(a & 0xFF);
		}

		private static byte[] AES_decrypt(string Input, byte[] Iv, byte[] Key)
		{
			RijndaelManaged rijndaelManaged = new RijndaelManaged();
			rijndaelManaged.KeySize = 256;
			rijndaelManaged.BlockSize = 128;
			rijndaelManaged.Mode = CipherMode.CBC;
			rijndaelManaged.Padding = PaddingMode.None;
			rijndaelManaged.Key = Key;
			rijndaelManaged.IV = Iv;
			ICryptoTransform transform = rijndaelManaged.CreateDecryptor(rijndaelManaged.Key, rijndaelManaged.IV);
			byte[] array = null;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write))
				{
					byte[] array2 = Convert.FromBase64String(Input);
					byte[] destinationArray = new byte[array2.Length + 32 - array2.Length % 32];
					Array.Copy(array2, destinationArray, array2.Length);
					cryptoStream.Write(array2, 0, array2.Length);
				}
				return decode2(memoryStream.ToArray());
			}
		}

		private static byte[] decode2(byte[] decrypted)
		{
			int num = decrypted[decrypted.Length - 1];
			if (num < 1 || num > 32)
			{
				num = 0;
			}
			byte[] array = new byte[decrypted.Length - num];
			Array.Copy(decrypted, 0, array, 0, decrypted.Length - num);
			return array;
		}
	}
}
