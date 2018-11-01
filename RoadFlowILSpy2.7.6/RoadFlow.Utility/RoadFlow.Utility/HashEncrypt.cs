using System.Security.Cryptography;
using System.Text;
using System.Web.Security;

namespace RoadFlow.Utility
{
	public class HashEncrypt
	{
		private bool isReturnNum;

		private bool isCaseSensitive = true;

		public HashEncrypt()
		{
		}

		public HashEncrypt(bool IsCaseSensitive, bool IsReturnNum)
		{
			isReturnNum = IsReturnNum;
			isCaseSensitive = IsCaseSensitive;
		}

		private string getstrIN(string strIN)
		{
			if (strIN.Length == 0)
			{
				strIN = "~NULL~";
			}
			if (!isCaseSensitive)
			{
				strIN = strIN.ToUpper();
			}
			return strIN;
		}

		public string MD5Encrypt(string strIN)
		{
			if (strIN.IsNullOrEmpty())
			{
				return string.Empty;
			}
			MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
			byte[] @byte = mD5CryptoServiceProvider.ComputeHash(GetKeyByteArray(getstrIN(strIN)));
			mD5CryptoServiceProvider.Clear();
			return GetStringValue(@byte);
		}

		public string SHA1Encrypt(string strIN)
		{
			if (strIN.IsNullOrEmpty())
			{
				return string.Empty;
			}
			SHA1CryptoServiceProvider sHA1CryptoServiceProvider = new SHA1CryptoServiceProvider();
			byte[] @byte = sHA1CryptoServiceProvider.ComputeHash(GetKeyByteArray(strIN));
			sHA1CryptoServiceProvider.Clear();
			return GetStringValue(@byte);
		}

		public string SHA256Encrypt(string strIN)
		{
			if (strIN.IsNullOrEmpty())
			{
				return string.Empty;
			}
			SHA256Managed sHA256Managed = new SHA256Managed();
			byte[] @byte = sHA256Managed.ComputeHash(GetKeyByteArray(strIN));
			sHA256Managed.Clear();
			return GetStringValue(@byte);
		}

		public string SHA512Encrypt(string strIN)
		{
			if (strIN.IsNullOrEmpty())
			{
				return string.Empty;
			}
			SHA512Managed sHA512Managed = new SHA512Managed();
			byte[] @byte = sHA512Managed.ComputeHash(GetKeyByteArray(strIN));
			sHA512Managed.Clear();
			return GetStringValue(@byte);
		}

		private string GetStringValue(byte[] Byte)
		{
			string text = "";
			if (!isReturnNum)
			{
				text = new ASCIIEncoding().GetString(Byte);
			}
			else
			{
				for (int i = 0; i < Byte.Length; i++)
				{
					text += Byte[i].ToString();
				}
			}
			return text;
		}

		private byte[] GetKeyByteArray(string strKey)
		{
			ASCIIEncoding aSCIIEncoding = new ASCIIEncoding();
			byte[] array = new byte[strKey.Length - 1];
			return aSCIIEncoding.GetBytes(strKey);
		}

		public string MD5System(string strIN)
		{
			if (!strIN.IsNullOrEmpty())
			{
				return FormsAuthentication.HashPasswordForStoringInConfigFile(strIN, "MD5");
			}
			return "";
		}
	}
}
