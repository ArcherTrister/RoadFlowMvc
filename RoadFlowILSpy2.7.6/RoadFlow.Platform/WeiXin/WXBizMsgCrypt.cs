using System;
using System.Collections;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace RoadFlow.Platform.WeiXin
{
	public class WXBizMsgCrypt
	{
		private enum WXBizMsgCryptErrorCode
		{
			WXBizMsgCrypt_OK = 0,
			WXBizMsgCrypt_ValidateSignature_Error = -40001,
			WXBizMsgCrypt_ParseXml_Error = -40002,
			WXBizMsgCrypt_ComputeSignature_Error = -40003,
			WXBizMsgCrypt_IllegalAesKey = -40004,
			WXBizMsgCrypt_ValidateCorpid_Error = -40005,
			WXBizMsgCrypt_EncryptAES_Error = -40006,
			WXBizMsgCrypt_DecryptAES_Error = -40007,
			WXBizMsgCrypt_IllegalBuffer = -40008,
			WXBizMsgCrypt_EncodeBase64_Error = -40009,
			WXBizMsgCrypt_DecodeBase64_Error = -40010
		}

		public class DictionarySort : IComparer
		{
			public int Compare(object oLeft, object oRight)
			{
				string text = oLeft as string;
				string text2 = oRight as string;
				int length = text.Length;
				int length2 = text2.Length;
				for (int i = 0; i < length && i < length2; i++)
				{
					if (text[i] < text2[i])
					{
						return -1;
					}
					if (text[i] > text2[i])
					{
						return 1;
					}
				}
				return length - length2;
			}
		}

		private string m_sToken;

		private string m_sEncodingAESKey;

		private string m_sCorpID;

		public WXBizMsgCrypt(string sToken, string sEncodingAESKey, string sCorpID)
		{
			m_sToken = sToken;
			m_sCorpID = sCorpID;
			m_sEncodingAESKey = sEncodingAESKey;
		}

		public int VerifyURL(string sMsgSignature, string sTimeStamp, string sNonce, string sEchoStr, ref string sReplyEchoStr)
		{
			int num = 0;
			if (m_sEncodingAESKey.Length != 43)
			{
				return -40004;
			}
			num = VerifySignature(m_sToken, sTimeStamp, sNonce, sEchoStr, sMsgSignature);
			if (num != 0)
			{
				return num;
			}
			sReplyEchoStr = "";
			string corpid = "";
			try
			{
				sReplyEchoStr = Cryptography.AES_decrypt(sEchoStr, m_sEncodingAESKey, ref corpid);
			}
			catch (Exception)
			{
				sReplyEchoStr = "";
				return -40007;
			}
			if (corpid != m_sCorpID)
			{
				sReplyEchoStr = "";
				return -40005;
			}
			return 0;
		}

		public int DecryptMsg(string sMsgSignature, string sTimeStamp, string sNonce, string sPostData, ref string sMsg)
		{
			if (m_sEncodingAESKey.Length != 43)
			{
				return -40004;
			}
			XmlDocument xmlDocument = new XmlDocument();
			string innerText;
			try
			{
				xmlDocument.LoadXml(sPostData);
				innerText = xmlDocument.FirstChild["Encrypt"].InnerText;
			}
			catch (Exception)
			{
				return -40002;
			}
			int num = 0;
			num = VerifySignature(m_sToken, sTimeStamp, sNonce, innerText, sMsgSignature);
			if (num != 0)
			{
				return num;
			}
			string corpid = "";
			try
			{
				sMsg = Cryptography.AES_decrypt(innerText, m_sEncodingAESKey, ref corpid);
			}
			catch (FormatException)
			{
				sMsg = "";
				return -40010;
			}
			catch (Exception)
			{
				sMsg = "";
				return -40007;
			}
			if (corpid != m_sCorpID)
			{
				return -40005;
			}
			return 0;
		}

		public int EncryptMsg(string sReplyMsg, string sTimeStamp, string sNonce, ref string sEncryptMsg)
		{
			if (m_sEncodingAESKey.Length != 43)
			{
				return -40004;
			}
			string text = "";
			try
			{
				text = Cryptography.AES_encrypt(sReplyMsg, m_sEncodingAESKey, m_sCorpID);
			}
			catch (Exception)
			{
				return -40006;
			}
			string sMsgSignature = "";
			int num = 0;
			num = GenarateSinature(m_sToken, sTimeStamp, sNonce, text, ref sMsgSignature);
			if (num != 0)
			{
				return num;
			}
			sEncryptMsg = "";
			string text2 = "<Encrypt><![CDATA[";
			string text3 = "]]></Encrypt>";
			string str = "<MsgSignature><![CDATA[";
			string str2 = "]]></MsgSignature>";
			string str3 = "<TimeStamp><![CDATA[";
			string str4 = "]]></TimeStamp>";
			string str5 = "<Nonce><![CDATA[";
			string str6 = "]]></Nonce>";
			sEncryptMsg = sEncryptMsg + "<xml>" + text2 + text + text3;
			sEncryptMsg = sEncryptMsg + str + sMsgSignature + str2;
			sEncryptMsg = sEncryptMsg + str3 + sTimeStamp + str4;
			sEncryptMsg = sEncryptMsg + str5 + sNonce + str6;
			sEncryptMsg += "</xml>";
			return 0;
		}

		private static int VerifySignature(string sToken, string sTimeStamp, string sNonce, string sMsgEncrypt, string sSigture)
		{
			string sMsgSignature = "";
			int num = 0;
			num = GenarateSinature(sToken, sTimeStamp, sNonce, sMsgEncrypt, ref sMsgSignature);
			if (num != 0)
			{
				return num;
			}
			if (sMsgSignature == sSigture)
			{
				return 0;
			}
			return -40001;
		}

		public static int GenarateSinature(string sToken, string sTimeStamp, string sNonce, string sMsgEncrypt, ref string sMsgSignature)
		{
			ArrayList arrayList = new ArrayList();
			arrayList.Add(sToken);
			arrayList.Add(sTimeStamp);
			arrayList.Add(sNonce);
			arrayList.Add(sMsgEncrypt);
			arrayList.Sort(new DictionarySort());
			string text = "";
			for (int i = 0; i < arrayList.Count; i++)
			{
				text += arrayList[i];
			}
			string text2 = "";
			try
			{
				SHA1CryptoServiceProvider sHA1CryptoServiceProvider = new SHA1CryptoServiceProvider();
				byte[] bytes = new ASCIIEncoding().GetBytes(text);
				text2 = BitConverter.ToString(sHA1CryptoServiceProvider.ComputeHash(bytes)).Replace("-", "");
				text2 = text2.ToLower();
			}
			catch (Exception)
			{
				return -40003;
			}
			sMsgSignature = text2;
			return 0;
		}
	}
}
