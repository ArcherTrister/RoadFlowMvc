// Decompiled with JetBrains decompiler
// Type: RoadFlow.Platform.WeiXin.Cryptography
// Assembly: RoadFlow.Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07F26AFD-DE3B-4003-89AF-01A62494BA58
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Platform.dll

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
      uint num = 0;
      for (int index = 0; index < 4; ++index)
        num = (uint) (((int) num << 8) + ((int) (inval >> index * 8) & (int) byte.MaxValue));
      return num;
    }

    public static int HostToNetworkOrder(int inval)
    {
      int num = 0;
      for (int index = 0; index < 4; ++index)
        num = (num << 8) + (inval >> index * 8 & (int) byte.MaxValue);
      return num;
    }

    public static string AES_decrypt(string Input, string EncodingAESKey, ref string corpid)
    {
      byte[] Key = Convert.FromBase64String(EncodingAESKey + "=");
      byte[] Iv = new byte[16];
      Array.Copy((Array) Key, (Array) Iv, 16);
      byte[] numArray = RoadFlow.Platform.WeiXin.Cryptography.AES_decrypt(Input, Iv, Key);
      int hostOrder = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(numArray, 16));
      byte[] bytes1 = new byte[hostOrder];
      byte[] bytes2 = new byte[numArray.Length - 20 - hostOrder];
      Array.Copy((Array) numArray, 20, (Array) bytes1, 0, hostOrder);
      Array.Copy((Array) numArray, 20 + hostOrder, (Array) bytes2, 0, numArray.Length - 20 - hostOrder);
      string str = Encoding.UTF8.GetString(bytes1);
      corpid = Encoding.UTF8.GetString(bytes2);
      return str;
    }

    public static string AES_encrypt(string Input, string EncodingAESKey, string corpid)
    {
      byte[] Key = Convert.FromBase64String(EncodingAESKey + "=");
      byte[] Iv = new byte[16];
      Array.Copy((Array) Key, (Array) Iv, 16);
      byte[] bytes1 = Encoding.UTF8.GetBytes(RoadFlow.Platform.WeiXin.Cryptography.CreateRandCode(16));
      byte[] bytes2 = Encoding.UTF8.GetBytes(corpid);
      byte[] bytes3 = Encoding.UTF8.GetBytes(Input);
      byte[] bytes4 = BitConverter.GetBytes(RoadFlow.Platform.WeiXin.Cryptography.HostToNetworkOrder(bytes3.Length));
      byte[] Input1 = new byte[bytes1.Length + bytes4.Length + bytes2.Length + bytes3.Length];
      Array.Copy((Array) bytes1, (Array) Input1, bytes1.Length);
      Array.Copy((Array) bytes4, 0, (Array) Input1, bytes1.Length, bytes4.Length);
      Array.Copy((Array) bytes3, 0, (Array) Input1, bytes1.Length + bytes4.Length, bytes3.Length);
      Array.Copy((Array) bytes2, 0, (Array) Input1, bytes1.Length + bytes4.Length + bytes3.Length, bytes2.Length);
      return RoadFlow.Platform.WeiXin.Cryptography.AES_encrypt(Input1, Iv, Key);
    }

    private static string CreateRandCode(int codeLen)
    {
      string str1 = "2,3,4,5,6,7,a,c,d,e,f,h,i,j,k,m,n,p,r,s,t,A,C,D,E,F,G,H,J,K,M,N,P,Q,R,S,U,V,W,X,Y,Z";
      if (codeLen == 0)
        codeLen = 16;
      char[] chArray = new char[1]{ ',' };
      string[] strArray = str1.Split(chArray);
      string str2 = "";
      Random random = new Random((int) DateTime.Now.Ticks);
      for (int index1 = 0; index1 < codeLen; ++index1)
      {
        int index2 = random.Next(0, strArray.Length - 1);
        str2 += strArray[index2];
      }
      return str2;
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
      ICryptoTransform encryptor = rijndaelManaged.CreateEncryptor(rijndaelManaged.Key, rijndaelManaged.IV);
      byte[] inArray = (byte[]) null;
      using (MemoryStream memoryStream = new MemoryStream())
      {
        using (CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, encryptor, CryptoStreamMode.Write))
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
      ICryptoTransform encryptor = rijndaelManaged.CreateEncryptor(rijndaelManaged.Key, rijndaelManaged.IV);
      byte[] inArray = (byte[]) null;
      byte[] buffer = new byte[Input.Length + 32 - Input.Length % 32];
      Array.Copy((Array) Input, (Array) buffer, Input.Length);
      byte[] numArray = RoadFlow.Platform.WeiXin.Cryptography.KCS7Encoder(Input.Length);
      Array.Copy((Array) numArray, 0, (Array) buffer, Input.Length, numArray.Length);
      using (MemoryStream memoryStream = new MemoryStream())
      {
        using (CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, encryptor, CryptoStreamMode.Write))
          cryptoStream.Write(buffer, 0, buffer.Length);
        inArray = memoryStream.ToArray();
      }
      return Convert.ToBase64String(inArray);
    }

    private static byte[] KCS7Encoder(int text_length)
    {
      int num = 32;
      int a = num - text_length % num;
      if (a == 0)
        a = num;
      char ch = RoadFlow.Platform.WeiXin.Cryptography.chr(a);
      string s = "";
      for (int index = 0; index < a; ++index)
        s += ch.ToString();
      return Encoding.UTF8.GetBytes(s);
    }

    private static char chr(int a)
    {
      return (char) (byte) (a & (int) byte.MaxValue);
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
      ICryptoTransform decryptor = rijndaelManaged.CreateDecryptor(rijndaelManaged.Key, rijndaelManaged.IV);
      using (MemoryStream memoryStream = new MemoryStream())
      {
        using (CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, decryptor, CryptoStreamMode.Write))
        {
          byte[] buffer = Convert.FromBase64String(Input);
          byte[] numArray = new byte[buffer.Length + 32 - buffer.Length % 32];
          Array.Copy((Array) buffer, (Array) numArray, buffer.Length);
          cryptoStream.Write(buffer, 0, buffer.Length);
        }
        return RoadFlow.Platform.WeiXin.Cryptography.decode2(memoryStream.ToArray());
      }
    }

    private static byte[] decode2(byte[] decrypted)
    {
      int num = (int) decrypted[decrypted.Length - 1];
      if (num < 1 || num > 32)
        num = 0;
      byte[] numArray = new byte[decrypted.Length - num];
      Array.Copy((Array) decrypted, 0, (Array) numArray, 0, decrypted.Length - num);
      return numArray;
    }
  }
}
