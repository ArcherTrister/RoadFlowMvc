// Decompiled with JetBrains decompiler
// Type: RoadFlow.Utility.HttpConfig
// Assembly: RoadFlow.Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E4D91F62-39BF-4125-A013-6EDB7CF1B4EC
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Utility.dll

using System.Text;

namespace RoadFlow.Utility
{
  public class HttpConfig
  {
    public string Referer { get; set; }

    public string ContentType { get; set; }

    public string Accept { get; set; }

    public string AcceptEncoding { get; set; }

    public int Timeout { get; set; }

    public string UserAgent { get; set; }

    public bool GZipCompress { get; set; }

    public bool KeepAlive { get; set; }

    public string CharacterSet { get; set; }

    public HttpConfig()
    {
      this.Timeout = 100000;
      this.ContentType = "text/html; charset=" + Encoding.UTF8.WebName;
      this.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.117 Safari/537.36";
      this.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
      this.AcceptEncoding = "gzip,deflate";
      this.GZipCompress = false;
      this.KeepAlive = true;
      this.CharacterSet = "UTF-8";
    }
  }
}
