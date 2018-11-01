// Decompiled with JetBrains decompiler
// Type: UECrawler
// Assembly: WebMvc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 43FD7615-6DC3-49FB-B263-7F7CC91AFA77
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\WebMvc.dll

using System;
using System.IO;
using System.Net;
using System.Web;

public class UECrawler
{
  public string SourceUrl { get; set; }

  public string ServerUrl { get; set; }

  public string State { get; set; }

  private HttpServerUtility Server { get; set; }

  public UECrawler(string sourceUrl, HttpServerUtility server)
  {
    this.SourceUrl = sourceUrl;
    this.Server = server;
  }

  public UECrawler Fetch()
  {
    using (HttpWebResponse response = (WebRequest.Create(this.SourceUrl) as HttpWebRequest).GetResponse() as HttpWebResponse)
    {
      if (response.StatusCode != HttpStatusCode.OK)
      {
        this.State = "Url returns " + (object) response.StatusCode + ", " + response.StatusDescription;
        return this;
      }
      if (response.ContentType.IndexOf("image") == -1)
      {
        this.State = "Url is not an image";
        return this;
      }
      this.ServerUrl = UEPathFormatter.Format(Path.GetFileName(this.SourceUrl), UEConfig.GetString("catcherPathFormat"));
      string path = this.Server.MapPath(this.ServerUrl);
      if (!Directory.Exists(Path.GetDirectoryName(path)))
        Directory.CreateDirectory(Path.GetDirectoryName(path));
      try
      {
        BinaryReader binaryReader = new BinaryReader(response.GetResponseStream());
        byte[] array;
        using (MemoryStream memoryStream = new MemoryStream())
        {
          byte[] buffer = new byte[4096];
          int count;
          while ((count = binaryReader.Read(buffer, 0, buffer.Length)) != 0)
            memoryStream.Write(buffer, 0, count);
          array = memoryStream.ToArray();
        }
        System.IO.File.WriteAllBytes(path, array);
        this.State = "SUCCESS";
      }
      catch (Exception ex)
      {
        this.State = "抓取错误：" + ex.Message;
      }
      return this;
    }
  }
}
