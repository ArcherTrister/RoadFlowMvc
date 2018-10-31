// Decompiled with JetBrains decompiler
// Type: UENotSupportedHandler
// Assembly: WebMvc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 43FD7615-6DC3-49FB-B263-7F7CC91AFA77
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\WebMvc.dll

using System.Web;

public class UENotSupportedHandler : UEHandler
{
  public UENotSupportedHandler(HttpContext context)
    : base(context)
  {
  }

  public override void Process()
  {
    this.WriteJson((object) new
    {
      state = "action 参数为空或者 action 不被支持。"
    });
  }
}
