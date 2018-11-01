// Decompiled with JetBrains decompiler
// Type: WebMvc.Areas.Controls.ControlsAreaRegistration
// Assembly: WebMvc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 43FD7615-6DC3-49FB-B263-7F7CC91AFA77
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\WebMvc.dll

using System.Web.Mvc;

namespace WebMvc.Areas.Controls
{
  public class ControlsAreaRegistration : AreaRegistration
  {
    public override string AreaName
    {
      get
      {
        return "Controls";
      }
    }

    public override void RegisterArea(AreaRegistrationContext context)
    {
      context.MapRoute("Controls_default", "Controls/{controller}/{action}/{id}", (object) new
      {
        action = "Index",
        id = UrlParameter.Optional
      });
    }
  }
}
