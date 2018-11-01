// Decompiled with JetBrains decompiler
// Type: WebMvc.Areas.WeiXin.Controllers.StartFlowsController
// Assembly: WebMvc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 43FD7615-6DC3-49FB-B263-7F7CC91AFA77
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\WebMvc.dll

using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace WebMvc.Areas.WeiXin.Controllers
{
  public class StartFlowsController : Controller
  {
    public ActionResult Index()
    {
      return this.Index((FormCollection) null);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Index(FormCollection coll)
    {
      RoadFlow.Platform.WeiXin.Organize.CheckLogin();
      RoadFlow.Platform.Users users = new RoadFlow.Platform.Users();
      string s_searchkey = this.Request.QueryString["searchkey"];
      if (coll != null)
        s_searchkey = this.Request.Form["searchkey"];
      List<WorkFlowStart> workFlowStartList = new RoadFlow.Platform.WorkFlow().GetUserStartFlows(RoadFlow.Platform.WeiXin.Organize.CurrentUserID);
      if (!s_searchkey.IsNullOrEmpty())
        workFlowStartList = workFlowStartList.FindAll((Predicate<WorkFlowStart>) (p => p.Name.Contains(s_searchkey.Trim1(), StringComparison.CurrentCultureIgnoreCase)));
      return (ActionResult) this.View((object) workFlowStartList);
    }
  }
}
