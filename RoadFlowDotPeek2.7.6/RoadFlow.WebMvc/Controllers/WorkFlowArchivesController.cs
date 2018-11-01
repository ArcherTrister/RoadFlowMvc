// Decompiled with JetBrains decompiler
// Type: WebMvc.Controllers.WorkFlowArchivesController
// Assembly: WebMvc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 43FD7615-6DC3-49FB-B263-7F7CC91AFA77
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\WebMvc.dll

using LitJson;
using Microsoft.CSharp.RuntimeBinder;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
  public class WorkFlowArchivesController : MyController
  {
    public ActionResult Index()
    {
      RoadFlow.Platform.WorkFlow workFlow = new RoadFlow.Platform.WorkFlow();
      // ISSUE: reference to a compiler-generated field
      if (WorkFlowArchivesController.\u003C\u003Eo__0.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        WorkFlowArchivesController.\u003C\u003Eo__0.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "flowOptions", typeof (WorkFlowArchivesController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj = WorkFlowArchivesController.\u003C\u003Eo__0.\u003C\u003Ep__0.Target((CallSite) WorkFlowArchivesController.\u003C\u003Eo__0.\u003C\u003Ep__0, this.ViewBag, workFlow.GetOptions(""));
      return (ActionResult) this.View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public string Query()
    {
      string str1 = this.Request.Form["sidx"];
      string str2 = this.Request.Form["sord"];
      string str3 = this.Request.Form["Title"];
      string str4 = this.Request.Form["FlowID"];
      string str5 = this.Request.Form["Date1"];
      string str6 = this.Request.Form["Date2"];
      RoadFlow.Platform.WorkFlowArchives workFlowArchives = new RoadFlow.Platform.WorkFlowArchives();
      RoadFlow.Platform.WorkFlow workFlow = new RoadFlow.Platform.WorkFlow();
      int pageSize1 = Tools.GetPageSize();
      int pageNumber1 = Tools.GetPageNumber();
      string str7 = (str1.IsNullOrEmpty() ? "WriteTime" : str1) + " " + (str2.IsNullOrEmpty() ? "asc" : str2);
      long num;
      ref long local = ref num;
      int pageSize2 = pageSize1;
      int pageNumber2 = pageNumber1;
      string title = str3;
      string flowIDString = str4;
      string date1 = str5;
      string date2 = str6;
      string order = str7;
      DataTable pagerData = workFlowArchives.GetPagerData(out local, pageSize2, pageNumber2, title, flowIDString, date1, date2, order);
      JsonData jsonData = new JsonData();
      foreach (DataRow row in (InternalDataCollectionBase) pagerData.Rows)
        jsonData.Add((object) new JsonData()
        {
          ["id"] = (JsonData) row["ID"].ToString(),
          ["Title"] = (JsonData) ("<a href=\"javascript:show('" + row["ID"].ToString() + "');\" class=\"blue\">" + row["Title"].ToString() + "</a>"),
          ["FlowName"] = (JsonData) row["FlowName"].ToString(),
          ["StepName"] = (JsonData) row["StepName"].ToString(),
          ["WriteTime"] = (JsonData) row["WriteTime"].ToString().ToDateTimeString()
        });
      return "{\"userdata\":{\"total\":" + (object) num + ",\"pagesize\":" + (object) pageSize1 + ",\"pagenumber\":" + (object) pageNumber1 + "},\"rows\":" + jsonData.ToJson(true) + "}";
    }

    public ActionResult Show()
    {
      string str = this.Request.QueryString["id"];
      if (!str.IsGuid())
        return (ActionResult) this.View();
      RoadFlow.Data.Model.WorkFlowArchives workFlowArchives = new RoadFlow.Platform.WorkFlowArchives().Get(str.ToGuid());
      if (workFlowArchives == null)
        return (ActionResult) this.View();
      return (ActionResult) this.View((object) workFlowArchives);
    }
  }
}
