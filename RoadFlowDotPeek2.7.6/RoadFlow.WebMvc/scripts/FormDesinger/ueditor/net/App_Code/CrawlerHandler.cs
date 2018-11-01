// Decompiled with JetBrains decompiler
// Type: CrawlerHandler
// Assembly: WebMvc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 43FD7615-6DC3-49FB-B263-7F7CC91AFA77
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\WebMvc.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class CrawlerHandler : Handler
{
  private string[] Sources;
  private Crawler[] Crawlers;

  public CrawlerHandler(HttpContext context)
    : base(context)
  {
  }

  public override void Process()
  {
    this.Sources = this.Request.Form.GetValues("source[]");
    if (this.Sources == null || this.Sources.Length == 0)
    {
      this.WriteJson((object) new{ state = "参数错误：没有指定抓取源" });
    }
    else
    {
      this.Crawlers = ((IEnumerable<string>) this.Sources).Select<string, Crawler>((Func<string, Crawler>) (x => new Crawler(x, this.Server).Fetch())).ToArray<Crawler>();
      this.WriteJson((object) new
      {
        state = "SUCCESS",
        list = ((IEnumerable<Crawler>) this.Crawlers).Select(x => new
        {
          state = x.State,
          source = x.SourceUrl,
          url = x.ServerUrl
        })
      });
    }
  }
}
