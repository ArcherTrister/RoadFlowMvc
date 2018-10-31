// Decompiled with JetBrains decompiler
// Type: RoadFlow.Utility.HttpHelper
// Assembly: RoadFlow.Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E4D91F62-39BF-4125-A013-6EDB7CF1B4EC
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Utility.dll

using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace RoadFlow.Utility
{
  public class HttpHelper
  {
    private static bool RemoteCertificateValidate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
    {
      return true;
    }

    public static string SendPost(string url, string data)
    {
      return HttpHelper.Send(url, "POST", data, (HttpConfig) null);
    }

    public static string SendGet(string url)
    {
      return HttpHelper.Send(url, "GET", (string) null, (HttpConfig) null);
    }

    public static string Send(string url, string method, string data, HttpConfig config)
    {
      if (config == null)
        config = new HttpConfig();
      using (HttpWebResponse response = HttpHelper.GetResponse(url, method, data, config))
      {
        Stream stream = response.GetResponseStream();
        if (!string.IsNullOrEmpty(response.ContentEncoding))
        {
          if (response.ContentEncoding.Contains("gzip"))
            stream = (Stream) new GZipStream(stream, CompressionMode.Decompress);
          else if (response.ContentEncoding.Contains("deflate"))
            stream = (Stream) new DeflateStream(stream, CompressionMode.Decompress);
        }
        byte[] bytes = (byte[]) null;
        using (MemoryStream memoryStream = new MemoryStream())
        {
          byte[] buffer = new byte[4096];
          int count;
          while ((count = stream.Read(buffer, 0, buffer.Length)) > 0)
            memoryStream.Write(buffer, 0, count);
          bytes = memoryStream.ToArray();
        }
        Encoding encoding;
        if (!string.IsNullOrEmpty(response.CharacterSet) && response.CharacterSet.ToUpper() != "ISO-8859-1")
        {
          encoding = Encoding.GetEncoding(response.CharacterSet == "utf8" ? "utf-8" : response.CharacterSet);
        }
        else
        {
          Match match = Regex.Match(Encoding.Default.GetString(bytes), "<meta.*charset=\"?([\\w-]+)\"?.*>", RegexOptions.IgnoreCase);
          encoding = !match.Success ? Encoding.GetEncoding(config.CharacterSet) : Encoding.GetEncoding(match.Groups[1].Value);
        }
        return encoding.GetString(bytes);
      }
    }

    private static HttpWebResponse GetResponse(string url, string method, string data, HttpConfig config)
    {
      HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create(url);
      httpWebRequest.Method = method;
      httpWebRequest.Referer = config.Referer;
      httpWebRequest.UserAgent = config.UserAgent;
      httpWebRequest.Timeout = config.Timeout;
      httpWebRequest.Accept = config.Accept;
      httpWebRequest.Headers.Set("Accept-Encoding", config.AcceptEncoding);
      httpWebRequest.ContentType = config.ContentType;
      httpWebRequest.KeepAlive = config.KeepAlive;
      if (url.ToLower().StartsWith("https"))
        ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(HttpHelper.RemoteCertificateValidate);
      if (method.ToUpper() == "POST")
      {
        if (!string.IsNullOrEmpty(data))
        {
          byte[] buffer = Encoding.UTF8.GetBytes(data);
          if (config.GZipCompress)
          {
            using (MemoryStream memoryStream = new MemoryStream())
            {
              using (GZipStream gzipStream = new GZipStream((Stream) memoryStream, CompressionMode.Compress))
                gzipStream.Write(buffer, 0, buffer.Length);
              buffer = memoryStream.ToArray();
            }
          }
          httpWebRequest.ContentLength = (long) buffer.Length;
          httpWebRequest.GetRequestStream().Write(buffer, 0, buffer.Length);
        }
        else
          httpWebRequest.ContentLength = 0L;
      }
      return (HttpWebResponse) httpWebRequest.GetResponse();
    }

    public static string SendFile(string url, HttpPostedFile file)
    {
      byte[] numArray = new byte[file.InputStream.Length];
      file.InputStream.Read(numArray, 0, (int) file.InputStream.Length);
      return HttpHelper.SendFile(url, file.FileName, numArray);
    }

    public static string SendFile(string url, string path, byte[] bf)
    {
      HttpWebRequest httpWebRequest = WebRequest.Create(url) as HttpWebRequest;
      httpWebRequest.CookieContainer = new CookieContainer();
      httpWebRequest.AllowAutoRedirect = true;
      httpWebRequest.Method = "POST";
      string str = DateTime.Now.Ticks.ToString("X");
      httpWebRequest.ContentType = "multipart/form-data;charset=utf-8;boundary=" + str;
      byte[] bytes1 = Encoding.UTF8.GetBytes("\r\n--" + str + "\r\n");
      byte[] bytes2 = Encoding.UTF8.GetBytes("\r\n--" + str + "--\r\n");
      byte[] bytes3 = Encoding.UTF8.GetBytes(new StringBuilder(string.Format("Content-Disposition:form-data;name=\"media\";filename=\"{0}\"\r\nContent-Type:application/octet-stream\r\n\r\n", (object) Path.GetFileName(path))).ToString());
      Stream requestStream = httpWebRequest.GetRequestStream();
      requestStream.Write(bytes1, 0, bytes1.Length);
      requestStream.Write(bytes3, 0, bytes3.Length);
      requestStream.Write(bf, 0, bf.Length);
      requestStream.Write(bytes2, 0, bytes2.Length);
      requestStream.Close();
      return new StreamReader((httpWebRequest.GetResponse() as HttpWebResponse).GetResponseStream(), Encoding.UTF8).ReadToEnd();
    }

    public static string DownloadFile(string url, string filePath)
    {
      HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create(url);
      httpWebRequest.Method = "GET";
      using (httpWebRequest.GetResponse())
      {
        string address = httpWebRequest.GetResponse().ResponseUri.ToString();
        WebClient webClient = new WebClient();
        try
        {
          webClient.DownloadFile(address, filePath);
        }
        catch (Exception ex)
        {
          return ex.Message;
        }
      }
      return "";
    }
  }
}
