// Decompiled with JetBrains decompiler
// Type: WebMvc.Areas.Controls.Controllers.SelectMemberController
// Assembly: WebMvc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 43FD7615-6DC3-49FB-B263-7F7CC91AFA77
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\WebMvc.dll

using RoadFlow.Platform;
using System;
using System.Web.Mvc;

namespace WebMvc.Areas.Controls.Controllers
{
  public class SelectMemberController : Controller
  {
    public ActionResult Index()
    {
      return (ActionResult) this.View();
    }

    public string GetNames()
    {
      return new Organize().GetNames(this.Request.Form["values"], ",");
    }

    public string GetNote()
    {
      string str = this.Request.QueryString["id"];
      if (str.IsNullOrEmpty())
        return "";
      Organize organize = new Organize();
      Users users = new Users();
      if (str.StartsWith("u_"))
      {
        Guid guid = users.RemovePrefix1(str).ToGuid();
        return organize.GetAllParentNames(users.GetMainStation(guid), false, " / ") + " / " + users.GetName(guid);
      }
      if (str.StartsWith("w_"))
        return new WorkGroup().GetUsersNames(WorkGroup.RemovePrefix(str).ToGuid(), '、');
      Guid test;
      if (str.IsGuid(out test))
        return organize.GetAllParentNames(test, false, " / ");
      return "";
    }

    public ActionResult Index_App()
    {
      return (ActionResult) this.View();
    }
  }
}
