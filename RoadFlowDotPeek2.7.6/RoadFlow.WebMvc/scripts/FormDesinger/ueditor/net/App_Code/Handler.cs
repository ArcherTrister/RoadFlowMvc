// Decompiled with JetBrains decompiler
// Type: Handler
// Assembly: WebMvc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 43FD7615-6DC3-49FB-B263-7F7CC91AFA77
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\WebMvc.dll

using Newtonsoft.Json;
using System.Web;

public abstract class Handler
{
  public Handler(HttpContext context)
  {
    this.Request = context.Request;
    this.Response = context.Response;
    this.Context = context;
    this.Server = context.Server;
  }

  public abstract void Process();

  protected void WriteJson(object response)
  {
    string str = this.Request["callback"];
    string s = JsonConvert.SerializeObject(response);
    if (string.IsNullOrWhiteSpace(str))
    {
      this.Response.AddHeader("Content-Type", "text/plain");
      this.Response.Write(s);
    }
    else
    {
      this.Response.AddHeader("Content-Type", "application/javascript");
      this.Response.Write(string.Format("{0}({1});", (object) str, (object) s));
    }
    this.Response.End();
  }

  public HttpRequest Request { get; private set; }

  public HttpResponse Response { get; private set; }

  public HttpContext Context { get; private set; }

  public HttpServerUtility Server { get; private set; }
}
