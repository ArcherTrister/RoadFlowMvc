// Decompiled with JetBrains decompiler
// Type: RoadFlow.Platform.WeiXin.WXBizMsgCrypt
// Assembly: RoadFlow.Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07F26AFD-DE3B-4003-89AF-01A62494BA58
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Platform.dll

using System;
using System.Collections;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace RoadFlow.Platform.WeiXin
{
  public class WXBizMsgCrypt
  {
    private string m_sToken;
    private string m_sEncodingAESKey;
    private string m_sCorpID;

    public WXBizMsgCrypt(string sToken, string sEncodingAESKey, string sCorpID)
    {
      this.m_sToken = sToken;
      this.m_sCorpID = sCorpID;
      this.m_sEncodingAESKey = sEncodingAESKey;
    }

    public int VerifyURL(string sMsgSignature, string sTimeStamp, string sNonce, string sEchoStr, ref string sReplyEchoStr)
    {
      if (this.m_sEncodingAESKey.Length != 43)
        return -40004;
      int num = WXBizMsgCrypt.VerifySignature(this.m_sToken, sTimeStamp, sNonce, sEchoStr, sMsgSignature);
      if (num != 0)
        return num;
      sReplyEchoStr = "";
      string corpid = "";
      try
      {
        sReplyEchoStr = RoadFlow.Platform.WeiXin.Cryptography.AES_decrypt(sEchoStr, this.m_sEncodingAESKey, ref corpid);
      }
      catch (Exception ex)
      {
        sReplyEchoStr = "";
        return -40007;
      }
      if (!(corpid != this.m_sCorpID))
        return 0;
      sReplyEchoStr = "";
      return -40005;
    }

    public int DecryptMsg(string sMsgSignature, string sTimeStamp, string sNonce, string sPostData, ref string sMsg)
    {
      if (this.m_sEncodingAESKey.Length != 43)
        return -40004;
      XmlDocument xmlDocument = new XmlDocument();
      string innerText;
      try
      {
        xmlDocument.LoadXml(sPostData);
        innerText = xmlDocument.FirstChild["Encrypt"].InnerText;
      }
      catch (Exception ex)
      {
        return -40002;
      }
      int num = WXBizMsgCrypt.VerifySignature(this.m_sToken, sTimeStamp, sNonce, innerText, sMsgSignature);
      if (num != 0)
        return num;
      string corpid = "";
      try
      {
        sMsg = RoadFlow.Platform.WeiXin.Cryptography.AES_decrypt(innerText, this.m_sEncodingAESKey, ref corpid);
      }
      catch (FormatException ex)
      {
        sMsg = "";
        return -40010;
      }
      catch (Exception ex)
      {
        sMsg = "";
        return -40007;
      }
      return corpid != this.m_sCorpID ? -40005 : 0;
    }

    public int EncryptMsg(string sReplyMsg, string sTimeStamp, string sNonce, ref string sEncryptMsg)
    {
      if (this.m_sEncodingAESKey.Length != 43)
        return -40004;
      string sMsgEncrypt;
      try
      {
        sMsgEncrypt = RoadFlow.Platform.WeiXin.Cryptography.AES_encrypt(sReplyMsg, this.m_sEncodingAESKey, this.m_sCorpID);
      }
      catch (Exception ex)
      {
        return -40006;
      }
      string sMsgSignature = "";
      int num = WXBizMsgCrypt.GenarateSinature(this.m_sToken, sTimeStamp, sNonce, sMsgEncrypt, ref sMsgSignature);
      if (num != 0)
        return num;
      sEncryptMsg = "";
      string str1 = "<Encrypt><![CDATA[";
      string str2 = "]]></Encrypt>";
      string str3 = "<MsgSignature><![CDATA[";
      string str4 = "]]></MsgSignature>";
      string str5 = "<TimeStamp><![CDATA[";
      string str6 = "]]></TimeStamp>";
      string str7 = "<Nonce><![CDATA[";
      string str8 = "]]></Nonce>";
      sEncryptMsg = sEncryptMsg + "<xml>" + str1 + sMsgEncrypt + str2;
      sEncryptMsg = sEncryptMsg + str3 + sMsgSignature + str4;
      sEncryptMsg = sEncryptMsg + str5 + sTimeStamp + str6;
      sEncryptMsg = sEncryptMsg + str7 + sNonce + str8;
      sEncryptMsg += "</xml>";
      return 0;
    }

    private static int VerifySignature(string sToken, string sTimeStamp, string sNonce, string sMsgEncrypt, string sSigture)
    {
      string sMsgSignature = "";
      int num = WXBizMsgCrypt.GenarateSinature(sToken, sTimeStamp, sNonce, sMsgEncrypt, ref sMsgSignature);
      if (num != 0)
        return num;
      return sMsgSignature == sSigture ? 0 : -40001;
    }

    public static int GenarateSinature(string sToken, string sTimeStamp, string sNonce, string sMsgEncrypt, ref string sMsgSignature)
    {
      ArrayList arrayList = new ArrayList();
      arrayList.Add((object) sToken);
      arrayList.Add((object) sTimeStamp);
      arrayList.Add((object) sNonce);
      arrayList.Add((object) sMsgEncrypt);
      arrayList.Sort((IComparer) new WXBizMsgCrypt.DictionarySort());
      string s = "";
      for (int index = 0; index < arrayList.Count; ++index)
        s += (string) arrayList[index];
      string lower;
      try
      {
        lower = BitConverter.ToString(new SHA1CryptoServiceProvider().ComputeHash(new ASCIIEncoding().GetBytes(s))).Replace("-", "").ToLower();
      }
      catch (Exception ex)
      {
        return -40003;
      }
      sMsgSignature = lower;
      return 0;
    }

    private enum WXBizMsgCryptErrorCode
    {
      WXBizMsgCrypt_DecodeBase64_Error = -40010, // -0x00009C4A
      WXBizMsgCrypt_EncodeBase64_Error = -40009, // -0x00009C49
      WXBizMsgCrypt_IllegalBuffer = -40008, // -0x00009C48
      WXBizMsgCrypt_DecryptAES_Error = -40007, // -0x00009C47
      WXBizMsgCrypt_EncryptAES_Error = -40006, // -0x00009C46
      WXBizMsgCrypt_ValidateCorpid_Error = -40005, // -0x00009C45
      WXBizMsgCrypt_IllegalAesKey = -40004, // -0x00009C44
      WXBizMsgCrypt_ComputeSignature_Error = -40003, // -0x00009C43
      WXBizMsgCrypt_ParseXml_Error = -40002, // -0x00009C42
      WXBizMsgCrypt_ValidateSignature_Error = -40001, // -0x00009C41
      WXBizMsgCrypt_OK = 0,
    }

    public class DictionarySort : IComparer
    {
      public int Compare(object oLeft, object oRight)
      {
        string str1 = oLeft as string;
        string str2 = oRight as string;
        int length1 = str1.Length;
        int length2 = str2.Length;
        for (int index = 0; index < length1 && index < length2; ++index)
        {
          if ((int) str1[index] < (int) str2[index])
            return -1;
          if ((int) str1[index] > (int) str2[index])
            return 1;
        }
        return length1 - length2;
      }
    }
  }
}
