// Decompiled with JetBrains decompiler
// Type: WebMvc.Areas.WeiXin.WeiXinAreaRegistration
// Assembly: WebMvc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 43FD7615-6DC3-49FB-B263-7F7CC91AFA77
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\WebMvc.dll

using System.Web.Mvc;

namespace WebMvc.Areas.WeiXin
{
  public class WeiXinAreaRegistration : AreaRegistration
  {
    public override string AreaName
    {
      get
      {
        return "WeiXin";
      }
    }

    public override void RegisterArea(AreaRegistrationContext context)
    {
      context.MapRoute("WeiXin_default", "WeiXin/{controller}/{action}/{id}", (object) new
      {
        action = "Index",
        id = UrlParameter.Optional
      });
    }
  }
}
