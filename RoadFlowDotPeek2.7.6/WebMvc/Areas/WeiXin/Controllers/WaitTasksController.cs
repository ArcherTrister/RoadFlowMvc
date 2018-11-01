// Decompiled with JetBrains decompiler
// Type: WebMvc.Areas.WeiXin.Controllers.WaitTasksController
// Assembly: WebMvc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 43FD7615-6DC3-49FB-B263-7F7CC91AFA77
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\WebMvc.dll

using LitJson;
using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace WebMvc.Areas.WeiXin.Controllers
{
  public class WaitTasksController : Controller
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
      Guid currentUserId = RoadFlow.Platform.WeiXin.Organize.CurrentUserID;
      RoadFlow.Platform.WorkFlowTask workFlowTask = new RoadFlow.Platform.WorkFlowTask();
      List<RoadFlow.Data.Model.WorkFlowTask> workFlowTaskList = new List<RoadFlow.Data.Model.WorkFlowTask>();
      string str = this.Request.QueryString["searchkey"];
      if (coll != null)
        str = this.Request.Form["searchkey"];
      Guid userID = currentUserId;
      long num;
      ref long local = ref num;
      int size = 15;
      int number = 1;
      string title = str;
      string flowid = "";
      string sender = "";
      string date1 = "";
      string date2 = "";
      int type = 0;
      string order = "";
      List<RoadFlow.Data.Model.WorkFlowTask> tasks = workFlowTask.GetTasks(userID, out local, size, number, title, flowid, sender, date1, date2, type, order);
      // ISSUE: reference to a compiler-generated field
      if (WaitTasksController.\u003C\u003Eo__1.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        WaitTasksController.\u003C\u003Eo__1.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, long, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Count", typeof (WaitTasksController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = WaitTasksController.\u003C\u003Eo__1.\u003C\u003Ep__0.Target((CallSite) WaitTasksController.\u003C\u003Eo__1.\u003C\u003Ep__0, this.ViewBag, num);
      // ISSUE: reference to a compiler-generated field
      if (WaitTasksController.\u003C\u003Eo__1.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        WaitTasksController.\u003C\u003Eo__1.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "SearchTitle", typeof (WaitTasksController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = WaitTasksController.\u003C\u003Eo__1.\u003C\u003Ep__1.Target((CallSite) WaitTasksController.\u003C\u003Eo__1.\u003C\u003Ep__1, this.ViewBag, str);
      return (ActionResult) this.View((object) tasks);
    }

    public string GetTasks()
    {
      string str1 = this.Request.QueryString["pagenumber"];
      string str2 = this.Request.QueryString["pagesize"];
      string title = this.Request.QueryString["SearchTitle"];
      long count;
      List<RoadFlow.Data.Model.WorkFlowTask> tasks = new RoadFlow.Platform.WorkFlowTask().GetTasks(RoadFlow.Platform.WeiXin.Organize.CurrentUserID, out count, str2.ToInt(15), str1.ToInt(2), title, "", "", "", "", 0, "");
      JsonData jsonData1 = new JsonData();
      if (tasks.Count == 0)
        return "[]";
      foreach (RoadFlow.Data.Model.WorkFlowTask workFlowTask in tasks)
      {
        JsonData jsonData2 = new JsonData();
        JsonData jsonData3 = jsonData2;
        string index1 = "id";
        Guid guid = workFlowTask.ID;
        JsonData jsonData4 = (JsonData) guid.ToString();
        jsonData3[index1] = jsonData4;
        jsonData2["title"] = (JsonData) workFlowTask.Title;
        jsonData2["time"] = (JsonData) workFlowTask.ReceiveTime.ToDateTimeString();
        jsonData2["sender"] = (JsonData) workFlowTask.SenderName;
        JsonData jsonData5 = jsonData2;
        string index2 = "flowid";
        guid = workFlowTask.FlowID;
        JsonData jsonData6 = (JsonData) guid.ToString();
        jsonData5[index2] = jsonData6;
        JsonData jsonData7 = jsonData2;
        string index3 = "stepid";
        guid = workFlowTask.StepID;
        JsonData jsonData8 = (JsonData) guid.ToString();
        jsonData7[index3] = jsonData8;
        jsonData2["instanceid"] = (JsonData) workFlowTask.InstanceID;
        JsonData jsonData9 = jsonData2;
        string index4 = "groupid";
        guid = workFlowTask.GroupID;
        JsonData jsonData10 = (JsonData) guid.ToString();
        jsonData9[index4] = jsonData10;
        jsonData1.Add((object) jsonData2);
      }
      return jsonData1.ToJson(true);
    }
  }
}
