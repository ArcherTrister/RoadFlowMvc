// Decompiled with JetBrains decompiler
// Type: RoadFlow.Utility.HashEncrypt
// Assembly: RoadFlow.Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E4D91F62-39BF-4125-A013-6EDB7CF1B4EC
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Utility.dll

using System.Security.Cryptography;
using System.Text;
using System.Web.Security;

namespace RoadFlow.Utility
{
  public class HashEncrypt
  {
    private bool isCaseSensitive = true;
    private bool isReturnNum;

    public HashEncrypt()
    {
    }

    public HashEncrypt(bool IsCaseSensitive, bool IsReturnNum)
    {
      this.isReturnNum = IsReturnNum;
      this.isCaseSensitive = IsCaseSensitive;
    }

    private string getstrIN(string strIN)
    {
      if (strIN.Length == 0)
        strIN = "~NULL~";
      if (!this.isCaseSensitive)
        strIN = strIN.ToUpper();
      return strIN;
    }

    public string MD5Encrypt(string strIN)
    {
      if (strIN.IsNullOrEmpty())
        return string.Empty;
      MD5CryptoServiceProvider cryptoServiceProvider = new MD5CryptoServiceProvider();
      byte[] hash = cryptoServiceProvider.ComputeHash(this.GetKeyByteArray(this.getstrIN(strIN)));
      cryptoServiceProvider.Clear();
      return this.GetStringValue(hash);
    }

    public string SHA1Encrypt(string strIN)
    {
      if (strIN.IsNullOrEmpty())
        return string.Empty;
      SHA1CryptoServiceProvider cryptoServiceProvider = new SHA1CryptoServiceProvider();
      byte[] hash = cryptoServiceProvider.ComputeHash(this.GetKeyByteArray(strIN));
      cryptoServiceProvider.Clear();
      return this.GetStringValue(hash);
    }

    public string SHA256Encrypt(string strIN)
    {
      if (strIN.IsNullOrEmpty())
        return string.Empty;
      SHA256Managed shA256Managed = new SHA256Managed();
      byte[] hash = shA256Managed.ComputeHash(this.GetKeyByteArray(strIN));
      shA256Managed.Clear();
      return this.GetStringValue(hash);
    }

    public string SHA512Encrypt(string strIN)
    {
      if (strIN.IsNullOrEmpty())
        return string.Empty;
      SHA512Managed shA512Managed = new SHA512Managed();
      byte[] hash = shA512Managed.ComputeHash(this.GetKeyByteArray(strIN));
      shA512Managed.Clear();
      return this.GetStringValue(hash);
    }

    private string GetStringValue(byte[] Byte)
    {
      string str = "";
      if (!this.isReturnNum)
      {
        str = new ASCIIEncoding().GetString(Byte);
      }
      else
      {
        for (int index = 0; index < Byte.Length; ++index)
          str += Byte[index].ToString();
      }
      return str;
    }

    private byte[] GetKeyByteArray(string strKey)
    {
      ASCIIEncoding asciiEncoding = new ASCIIEncoding();
      byte[] numArray = new byte[strKey.Length - 1];
      string s = strKey;
      return asciiEncoding.GetBytes(s);
    }

    public string MD5System(string strIN)
    {
      if (!strIN.IsNullOrEmpty())
        return FormsAuthentication.HashPasswordForStoringInConfigFile(strIN, "MD5");
      return "";
    }
  }
}
