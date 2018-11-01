// Decompiled with JetBrains decompiler
// Type: WebMvc.Controllers.WorkFlowTasksController
// Assembly: WebMvc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 43FD7615-6DC3-49FB-B263-7F7CC91AFA77
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\WebMvc.dll

using LitJson;
using Microsoft.CSharp.RuntimeBinder;
using RoadFlow.Data.Model;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
  public class WorkFlowTasksController : MyController
  {
    public ActionResult Index()
    {
      return (ActionResult) this.View();
    }

    public ActionResult Instance()
    {
      return (ActionResult) this.View();
    }

    public ActionResult InstanceTree()
    {
      return (ActionResult) this.View();
    }

    public ActionResult InstanceList()
    {
      RoadFlow.Platform.WorkFlowTask workFlowTask = new RoadFlow.Platform.WorkFlowTask();
      RoadFlow.Platform.WorkFlow workFlow = new RoadFlow.Platform.WorkFlow();
      string str1 = this.Request.QueryString["typeid"];
      string options = workFlow.GetOptions(workFlow.GetInstanceManageFlowIDList(RoadFlow.Platform.Users.CurrentUserID, str1), str1, "");
      string str2 = string.Format("&appid={0}&tabid={1}&typeid={2}", (object) this.Request.QueryString["appid"], (object) this.Request.QueryString["tabid"], (object) str1);
      List<SelectListItem> selectListItemList = new List<SelectListItem>();
      selectListItemList.Add(new SelectListItem()
      {
        Text = "==全部==",
        Value = "0"
      });
      selectListItemList.Add(new SelectListItem()
      {
        Text = "未完成",
        Value = "1"
      });
      selectListItemList.Add(new SelectListItem()
      {
        Text = "已完成",
        Value = "2"
      });
      // ISSUE: reference to a compiler-generated field
      if (WorkFlowTasksController.\u003C\u003Eo__3.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        WorkFlowTasksController.\u003C\u003Eo__3.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Query", typeof (WorkFlowTasksController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = WorkFlowTasksController.\u003C\u003Eo__3.\u003C\u003Ep__0.Target((CallSite) WorkFlowTasksController.\u003C\u003Eo__3.\u003C\u003Ep__0, this.ViewBag, str2);
      // ISSUE: reference to a compiler-generated field
      if (WorkFlowTasksController.\u003C\u003Eo__3.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        WorkFlowTasksController.\u003C\u003Eo__3.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, List<SelectListItem>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "StatusItems", typeof (WorkFlowTasksController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = WorkFlowTasksController.\u003C\u003Eo__3.\u003C\u003Ep__1.Target((CallSite) WorkFlowTasksController.\u003C\u003Eo__3.\u003C\u003Ep__1, this.ViewBag, selectListItemList);
      // ISSUE: reference to a compiler-generated field
      if (WorkFlowTasksController.\u003C\u003Eo__3.\u003C\u003Ep__2 == null)
      {
        // ISSUE: reference to a compiler-generated field
        WorkFlowTasksController.\u003C\u003Eo__3.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "FlowOptions", typeof (WorkFlowTasksController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj3 = WorkFlowTasksController.\u003C\u003Eo__3.\u003C\u003Ep__2.Target((CallSite) WorkFlowTasksController.\u003C\u003Eo__3.\u003C\u003Ep__2, this.ViewBag, options);
      return (ActionResult) this.View();
    }

    public ActionResult InstanceManage()
    {
      RoadFlow.Platform.WorkFlowTask workFlowTask1 = new RoadFlow.Platform.WorkFlowTask();
      RoadFlow.Platform.WorkFlow workFlow = new RoadFlow.Platform.WorkFlow();
      string str1 = this.Request.QueryString["flowid1"];
      string str2 = this.Request.QueryString["groupid"];
      WorkFlowInstalled workFlowRunModel = workFlow.GetWorkFlowRunModel(str1, true);
      IOrderedEnumerable<RoadFlow.Data.Model.WorkFlowTask> orderedEnumerable = workFlowTask1.GetTaskList(str1.ToGuid(), str2.ToGuid()).OrderBy<RoadFlow.Data.Model.WorkFlowTask, int>((Func<RoadFlow.Data.Model.WorkFlowTask, int>) (p => p.Sort));
      JsonData jsonData1 = new JsonData();
      foreach (RoadFlow.Data.Model.WorkFlowTask workFlowTask2 in (IEnumerable<RoadFlow.Data.Model.WorkFlowTask>) orderedEnumerable)
      {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append("<a style=\"background:url(" + this.Url.Content("~/Images/ico/permission.gif") + ") no-repeat left center; padding-left:18px;\" href=\"javascript:void(0);\" onclick=\"cngStatus('" + (object) workFlowTask2.ID + "');\">状态</a>");
        if (workFlowTask2.Status.In(0, 1))
        {
          stringBuilder.Append("<a style=\"background:url(" + this.Url.Content("~/Images/ico/arrow_medium_lower_left.png") + ") no-repeat left center; padding-left:16px;\" href=\"javascript:void(0);\" onclick=\"designate('" + (object) workFlowTask2.ID + "');\">指派</a>");
          stringBuilder.Append("<a style=\"background:url(" + this.Url.Content("~/Images/ico/arrow_medium_lower_right.png") + ") no-repeat left center; padding-left:16px;\" href=\"javascript:void(0);\" onclick=\"goTo('" + (object) workFlowTask2.ID + "');\">跳转</a>");
        }
        JsonData jsonData2 = new JsonData();
        jsonData2["id"] = (JsonData) workFlowTask2.ID.ToString();
        jsonData2["StepID"] = (JsonData) workFlow.GetStepName(workFlowTask2.StepID, workFlowRunModel, false);
        jsonData2["SenderName"] = (JsonData) workFlowTask2.SenderName;
        jsonData2["ReceiveTime"] = (JsonData) workFlowTask2.ReceiveTime.ToDateTimeStringS();
        jsonData2["ReceiveName"] = (JsonData) workFlowTask2.ReceiveName;
        JsonData jsonData3 = jsonData2;
        string index = "CompletedTime1";
        DateTime? completedTime1 = workFlowTask2.CompletedTime1;
        string str3;
        if (!completedTime1.HasValue)
        {
          str3 = "";
        }
        else
        {
          completedTime1 = workFlowTask2.CompletedTime1;
          str3 = completedTime1.Value.ToDateTimeStringS();
        }
        JsonData jsonData4 = (JsonData) str3;
        jsonData3[index] = jsonData4;
        jsonData2["Status"] = (JsonData) workFlowTask1.GetStatusTitle(workFlowTask2.Status);
        jsonData2["Comment"] = (JsonData) workFlowTask2.Comment;
        jsonData2["Opation"] = (JsonData) stringBuilder.ToString();
        jsonData1.Add((object) jsonData2);
      }
      // ISSUE: reference to a compiler-generated field
      if (WorkFlowTasksController.\u003C\u003Eo__4.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        WorkFlowTasksController.\u003C\u003Eo__4.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "list", typeof (WorkFlowTasksController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj = WorkFlowTasksController.\u003C\u003Eo__4.\u003C\u003Ep__0.Target((CallSite) WorkFlowTasksController.\u003C\u003Eo__4.\u003C\u003Ep__0, this.ViewBag, jsonData1.ToJson(true));
      return (ActionResult) this.View();
    }

    [MyAttribute(CheckApp = false, CheckLogin = false)]
    public ActionResult Designate()
    {
      return (ActionResult) this.View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [MyAttribute(CheckApp = false, CheckLogin = false)]
    public ActionResult Designate(FormCollection collection)
    {
      Guid test;
      if (this.Request.QueryString["taskid"].IsGuid(out test))
      {
        string idString = this.Request.Form["user"];
        string str1 = this.Request.QueryString["openerid"];
        RoadFlow.Platform.WorkFlowTask workFlowTask = new RoadFlow.Platform.WorkFlowTask();
        List<RoadFlow.Data.Model.Users> allUsers = new RoadFlow.Platform.Organize().GetAllUsers(idString);
        StringBuilder stringBuilder = new StringBuilder();
        foreach (RoadFlow.Data.Model.Users user in allUsers)
        {
          workFlowTask.DesignateTask(test, user);
          RoadFlow.Platform.Log.Add("管理员指派了流程任务", "将任务" + (object) test + "指派给了：" + user.Name + (object) user.ID, RoadFlow.Platform.Log.Types.流程相关, "", "", (RoadFlow.Data.Model.Users) null);
          stringBuilder.Append(user.Name);
          stringBuilder.Append(",");
        }
        string str2 = stringBuilder.ToString().TrimEnd(',');
        // ISSUE: reference to a compiler-generated field
        if (WorkFlowTasksController.\u003C\u003Eo__6.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          WorkFlowTasksController.\u003C\u003Eo__6.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Script", typeof (WorkFlowTasksController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = WorkFlowTasksController.\u003C\u003Eo__6.\u003C\u003Ep__0.Target((CallSite) WorkFlowTasksController.\u003C\u003Eo__6.\u003C\u003Ep__0, this.ViewBag, "alert('已成功指派给：" + str2 + "!');new RoadUI.Window().reloadOpener();new RoadUI.Window().close();");
      }
      return (ActionResult) this.View();
    }

    public string Delete()
    {
      string str1 = this.Request.QueryString["flowid1"];
      string str2 = this.Request.QueryString["groupid"];
      Guid flowID;
      ref Guid local = ref flowID;
      Guid test;
      if (!str1.IsGuid(out local) || !str2.IsGuid(out test))
        return "参数错误!";
      StringBuilder stringBuilder = new StringBuilder();
      foreach (RoadFlow.Data.Model.WorkFlowTask task in new RoadFlow.Platform.WorkFlowTask().GetTaskList(flowID, test))
        stringBuilder.Append(task.Serialize());
      new RoadFlow.Platform.WorkFlowTask().DeleteInstance(flowID, test, false);
      RoadFlow.Platform.Log.Add("管理员删除了流程实例", stringBuilder.ToString(), RoadFlow.Platform.Log.Types.流程相关, "", "", (RoadFlow.Data.Model.Users) null);
      return "删除成功!";
    }

    [MyAttribute(CheckApp = false)]
    public ActionResult WaitList()
    {
      RoadFlow.Platform.WorkFlow workFlow = new RoadFlow.Platform.WorkFlow();
      // ISSUE: reference to a compiler-generated field
      if (WorkFlowTasksController.\u003C\u003Eo__8.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        WorkFlowTasksController.\u003C\u003Eo__8.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "flowOptions", typeof (WorkFlowTasksController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = WorkFlowTasksController.\u003C\u003Eo__8.\u003C\u003Ep__0.Target((CallSite) WorkFlowTasksController.\u003C\u003Eo__8.\u003C\u003Ep__0, this.ViewBag, workFlow.GetOptions(""));
      string str = string.Format("&appid={0}&tabid={1}", (object) this.Request.QueryString["appid"], (object) this.Request.QueryString["tabid"]);
      // ISSUE: reference to a compiler-generated field
      if (WorkFlowTasksController.\u003C\u003Eo__8.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        WorkFlowTasksController.\u003C\u003Eo__8.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "query", typeof (WorkFlowTasksController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = WorkFlowTasksController.\u003C\u003Eo__8.\u003C\u003Ep__1.Target((CallSite) WorkFlowTasksController.\u003C\u003Eo__8.\u003C\u003Ep__1, this.ViewBag, str);
      return (ActionResult) this.View();
    }

    [MyAttribute(CheckApp = false)]
    public ActionResult CompletedList()
    {
      RoadFlow.Platform.WorkFlowTask workFlowTask = new RoadFlow.Platform.WorkFlowTask();
      RoadFlow.Platform.WorkFlow workFlow = new RoadFlow.Platform.WorkFlow();
      string str = string.Format("&appid={0}&tabid={1}", (object) this.Request.QueryString["appid"], (object) this.Request.QueryString["tabid"]);
      // ISSUE: reference to a compiler-generated field
      if (WorkFlowTasksController.\u003C\u003Eo__9.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        WorkFlowTasksController.\u003C\u003Eo__9.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "flowOptions", typeof (WorkFlowTasksController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = WorkFlowTasksController.\u003C\u003Eo__9.\u003C\u003Ep__0.Target((CallSite) WorkFlowTasksController.\u003C\u003Eo__9.\u003C\u003Ep__0, this.ViewBag, workFlow.GetOptions(""));
      // ISSUE: reference to a compiler-generated field
      if (WorkFlowTasksController.\u003C\u003Eo__9.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        WorkFlowTasksController.\u003C\u003Eo__9.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "query", typeof (WorkFlowTasksController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = WorkFlowTasksController.\u003C\u003Eo__9.\u003C\u003Ep__1.Target((CallSite) WorkFlowTasksController.\u003C\u003Eo__9.\u003C\u003Ep__1, this.ViewBag, str);
      return (ActionResult) this.View();
    }

    [MyAttribute(CheckApp = false, CheckLogin = false)]
    public ActionResult Detail()
    {
      RoadFlow.Platform.WorkFlowTask workFlowTask1 = new RoadFlow.Platform.WorkFlowTask();
      RoadFlow.Platform.WorkFlow workFlow = new RoadFlow.Platform.WorkFlow();
      string str1 = this.Request.QueryString["flowid1"] ?? this.Request.QueryString["flowid"];
      string str2 = this.Request.QueryString["groupid"];
      string str3 = this.Request.QueryString["displaymodel"];
      string flowID = str1;
      int num = 1;
      WorkFlowInstalled workFlowRunModel = workFlow.GetWorkFlowRunModel(flowID, num != 0);
      IOrderedEnumerable<RoadFlow.Data.Model.WorkFlowTask> orderedEnumerable = workFlowTask1.GetTaskList(str1.ToGuid(), str2.ToGuid()).Where<RoadFlow.Data.Model.WorkFlowTask>((Func<RoadFlow.Data.Model.WorkFlowTask, bool>) (p => p.Status != -1)).OrderBy<RoadFlow.Data.Model.WorkFlowTask, int>((Func<RoadFlow.Data.Model.WorkFlowTask, int>) (p => p.Sort)).ThenBy<RoadFlow.Data.Model.WorkFlowTask, int>((Func<RoadFlow.Data.Model.WorkFlowTask, int>) (p => p.StepSort));
      string str4 = string.Format("&flowid1={0}&groupid={1}&appid={2}&tabid={3}&iframeid={4}&openerid={5}", (object) str1, (object) str2, (object) this.Request.QueryString["appid"], (object) this.Request.QueryString["tabid"], (object) this.Request.QueryString["iframeid"], (object) this.Request.QueryString["openerid"]);
      string str5 = string.Format("&groupid={0}&appid={1}&tabid={2}&ismobile={3}", (object) str2, (object) this.Request.QueryString["appid"], (object) this.Request.QueryString["tabid"], (object) this.Request.QueryString["ismobile"]);
      // ISSUE: reference to a compiler-generated field
      if (WorkFlowTasksController.\u003C\u003Eo__10.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        WorkFlowTasksController.\u003C\u003Eo__10.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "flowid", typeof (WorkFlowTasksController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = WorkFlowTasksController.\u003C\u003Eo__10.\u003C\u003Ep__0.Target((CallSite) WorkFlowTasksController.\u003C\u003Eo__10.\u003C\u003Ep__0, this.ViewBag, str1);
      // ISSUE: reference to a compiler-generated field
      if (WorkFlowTasksController.\u003C\u003Eo__10.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        WorkFlowTasksController.\u003C\u003Eo__10.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "groupid", typeof (WorkFlowTasksController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = WorkFlowTasksController.\u003C\u003Eo__10.\u003C\u003Ep__1.Target((CallSite) WorkFlowTasksController.\u003C\u003Eo__10.\u003C\u003Ep__1, this.ViewBag, str2);
      // ISSUE: reference to a compiler-generated field
      if (WorkFlowTasksController.\u003C\u003Eo__10.\u003C\u003Ep__2 == null)
      {
        // ISSUE: reference to a compiler-generated field
        WorkFlowTasksController.\u003C\u003Eo__10.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "displayModel", typeof (WorkFlowTasksController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj3 = WorkFlowTasksController.\u003C\u003Eo__10.\u003C\u003Ep__2.Target((CallSite) WorkFlowTasksController.\u003C\u003Eo__10.\u003C\u003Ep__2, this.ViewBag, str3);
      // ISSUE: reference to a compiler-generated field
      if (WorkFlowTasksController.\u003C\u003Eo__10.\u003C\u003Ep__3 == null)
      {
        // ISSUE: reference to a compiler-generated field
        WorkFlowTasksController.\u003C\u003Eo__10.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, WorkFlowInstalled, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "wfInstall", typeof (WorkFlowTasksController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj4 = WorkFlowTasksController.\u003C\u003Eo__10.\u003C\u003Ep__3.Target((CallSite) WorkFlowTasksController.\u003C\u003Eo__10.\u003C\u003Ep__3, this.ViewBag, workFlowRunModel);
      // ISSUE: reference to a compiler-generated field
      if (WorkFlowTasksController.\u003C\u003Eo__10.\u003C\u003Ep__4 == null)
      {
        // ISSUE: reference to a compiler-generated field
        WorkFlowTasksController.\u003C\u003Eo__10.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "query", typeof (WorkFlowTasksController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj5 = WorkFlowTasksController.\u003C\u003Eo__10.\u003C\u003Ep__4.Target((CallSite) WorkFlowTasksController.\u003C\u003Eo__10.\u003C\u003Ep__4, this.ViewBag, str4);
      // ISSUE: reference to a compiler-generated field
      if (WorkFlowTasksController.\u003C\u003Eo__10.\u003C\u003Ep__5 == null)
      {
        // ISSUE: reference to a compiler-generated field
        WorkFlowTasksController.\u003C\u003Eo__10.\u003C\u003Ep__5 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "query1", typeof (WorkFlowTasksController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj6 = WorkFlowTasksController.\u003C\u003Eo__10.\u003C\u003Ep__5.Target((CallSite) WorkFlowTasksController.\u003C\u003Eo__10.\u003C\u003Ep__5, this.ViewBag, str5);
      JsonData jsonData1 = new JsonData();
      foreach (RoadFlow.Data.Model.WorkFlowTask workFlowTask2 in (IEnumerable<RoadFlow.Data.Model.WorkFlowTask>) orderedEnumerable)
      {
        JsonData jsonData2 = new JsonData();
        jsonData2["StepName"] = (JsonData) workFlowTask2.StepName;
        jsonData2["SenderName"] = (JsonData) workFlowTask2.SenderName;
        jsonData2["SenderTime"] = (JsonData) workFlowTask2.SenderTime.ToDateTimeStringS();
        jsonData2["ReceiveName"] = (JsonData) workFlowTask2.ReceiveName;
        JsonData jsonData3 = jsonData2;
        string index = "CompletedTime1";
        DateTime? completedTime1 = workFlowTask2.CompletedTime1;
        string str6;
        if (!completedTime1.HasValue)
        {
          str6 = "";
        }
        else
        {
          completedTime1 = workFlowTask2.CompletedTime1;
          str6 = completedTime1.Value.ToDateTimeStringS();
        }
        JsonData jsonData4 = (JsonData) str6;
        jsonData3[index] = jsonData4;
        jsonData2["StatusTitle"] = (JsonData) workFlowTask1.GetStatusTitle(workFlowTask2.Status);
        jsonData2["Comment"] = (JsonData) workFlowTask2.Comment;
        jsonData2["Note"] = (JsonData) workFlowTask2.Note;
        jsonData1.Add((object) jsonData2);
      }
      // ISSUE: reference to a compiler-generated field
      if (WorkFlowTasksController.\u003C\u003Eo__10.\u003C\u003Ep__6 == null)
      {
        // ISSUE: reference to a compiler-generated field
        WorkFlowTasksController.\u003C\u003Eo__10.\u003C\u003Ep__6 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "list", typeof (WorkFlowTasksController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj7 = WorkFlowTasksController.\u003C\u003Eo__10.\u003C\u003Ep__6.Target((CallSite) WorkFlowTasksController.\u003C\u003Eo__10.\u003C\u003Ep__6, this.ViewBag, jsonData1.IsArray ? jsonData1.ToJson(true) : "{}");
      return (ActionResult) this.View((object) orderedEnumerable);
    }

    [MyAttribute(CheckApp = false, CheckLogin = false)]
    public ActionResult DetailSubFlow()
    {
      RoadFlow.Platform.WorkFlowTask workFlowTask1 = new RoadFlow.Platform.WorkFlowTask();
      RoadFlow.Platform.WorkFlow workFlow = new RoadFlow.Platform.WorkFlow();
      string str1 = string.Format("&flowid1={0}&groupid={1}&appid={2}&tabid={3}&title={4}&flowid={5}&sender={6}&date1={7}&date2={8}&iframeid={9}&openerid={10}&taskid={11}", (object) this.Request.QueryString["flowid"], (object) this.Request.QueryString["groupid"], (object) this.Request.QueryString["appid"], (object) this.Request.QueryString["tabid"], (object) this.Request.QueryString["title"].UrlEncode(), (object) this.Request.QueryString["flowid"], (object) this.Request.QueryString["sender"], (object) this.Request.QueryString["date1"], (object) this.Request.QueryString["date2"], (object) this.Request.QueryString["iframeid"], (object) this.Request.QueryString["openerid"], (object) this.Request.QueryString["taskid"]);
      // ISSUE: reference to a compiler-generated field
      if (WorkFlowTasksController.\u003C\u003Eo__11.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        WorkFlowTasksController.\u003C\u003Eo__11.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "flowid", typeof (WorkFlowTasksController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = WorkFlowTasksController.\u003C\u003Eo__11.\u003C\u003Ep__0.Target((CallSite) WorkFlowTasksController.\u003C\u003Eo__11.\u003C\u003Ep__0, this.ViewBag, this.Request.QueryString["flowid"]);
      // ISSUE: reference to a compiler-generated field
      if (WorkFlowTasksController.\u003C\u003Eo__11.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        WorkFlowTasksController.\u003C\u003Eo__11.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "groupid", typeof (WorkFlowTasksController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = WorkFlowTasksController.\u003C\u003Eo__11.\u003C\u003Ep__1.Target((CallSite) WorkFlowTasksController.\u003C\u003Eo__11.\u003C\u003Ep__1, this.ViewBag, this.Request.QueryString["groupid"]);
      // ISSUE: reference to a compiler-generated field
      if (WorkFlowTasksController.\u003C\u003Eo__11.\u003C\u003Ep__2 == null)
      {
        // ISSUE: reference to a compiler-generated field
        WorkFlowTasksController.\u003C\u003Eo__11.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "displayModel", typeof (WorkFlowTasksController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj3 = WorkFlowTasksController.\u003C\u003Eo__11.\u003C\u003Ep__2.Target((CallSite) WorkFlowTasksController.\u003C\u003Eo__11.\u003C\u003Ep__2, this.ViewBag, this.Request.QueryString["displaymodel"]);
      // ISSUE: reference to a compiler-generated field
      if (WorkFlowTasksController.\u003C\u003Eo__11.\u003C\u003Ep__3 == null)
      {
        // ISSUE: reference to a compiler-generated field
        WorkFlowTasksController.\u003C\u003Eo__11.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "wfInstall", typeof (WorkFlowTasksController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj4 = WorkFlowTasksController.\u003C\u003Eo__11.\u003C\u003Ep__3.Target((CallSite) WorkFlowTasksController.\u003C\u003Eo__11.\u003C\u003Ep__3, this.ViewBag, (object) null);
      // ISSUE: reference to a compiler-generated field
      if (WorkFlowTasksController.\u003C\u003Eo__11.\u003C\u003Ep__4 == null)
      {
        // ISSUE: reference to a compiler-generated field
        WorkFlowTasksController.\u003C\u003Eo__11.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "query", typeof (WorkFlowTasksController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj5 = WorkFlowTasksController.\u003C\u003Eo__11.\u003C\u003Ep__4.Target((CallSite) WorkFlowTasksController.\u003C\u003Eo__11.\u003C\u003Ep__4, this.ViewBag, str1);
      string str2 = this.Request.QueryString["taskid"];
      string str3 = this.Request.QueryString["displaymodel"];
      if (!str2.IsGuid())
        return (ActionResult) this.View((object) new List<RoadFlow.Data.Model.WorkFlowTask>());
      RoadFlow.Data.Model.WorkFlowTask workFlowTask2 = workFlowTask1.Get(str2.ToGuid());
      if (workFlowTask2 == null || workFlowTask2.SubFlowGroupID.IsNullOrEmpty())
        return (ActionResult) this.View((object) new List<RoadFlow.Data.Model.WorkFlowTask>());
      List<RoadFlow.Data.Model.WorkFlowTask> source = new List<RoadFlow.Data.Model.WorkFlowTask>();
      string subFlowGroupId = workFlowTask2.SubFlowGroupID;
      char[] chArray = new char[1]{ ',' };
      foreach (string str4 in subFlowGroupId.Split(chArray))
        source.AddRange((IEnumerable<RoadFlow.Data.Model.WorkFlowTask>) workFlowTask1.GetTaskList(Guid.Empty, str4.ToGuid()));
      if (source.Count == 0)
      {
        this.Response.Write("未找到任务");
        this.Response.End();
        return (ActionResult) null;
      }
      WorkFlowInstalled workFlowRunModel = workFlow.GetWorkFlowRunModel(source.FirstOrDefault<RoadFlow.Data.Model.WorkFlowTask>().FlowID, true);
      // ISSUE: reference to a compiler-generated field
      if (WorkFlowTasksController.\u003C\u003Eo__11.\u003C\u003Ep__5 == null)
      {
        // ISSUE: reference to a compiler-generated field
        WorkFlowTasksController.\u003C\u003Eo__11.\u003C\u003Ep__5 = CallSite<Func<CallSite, object, WorkFlowInstalled, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "wfInstall", typeof (WorkFlowTasksController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj6 = WorkFlowTasksController.\u003C\u003Eo__11.\u003C\u003Ep__5.Target((CallSite) WorkFlowTasksController.\u003C\u003Eo__11.\u003C\u003Ep__5, this.ViewBag, workFlowRunModel);
      // ISSUE: reference to a compiler-generated field
      if (WorkFlowTasksController.\u003C\u003Eo__11.\u003C\u003Ep__6 == null)
      {
        // ISSUE: reference to a compiler-generated field
        WorkFlowTasksController.\u003C\u003Eo__11.\u003C\u003Ep__6 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "flowid", typeof (WorkFlowTasksController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj7 = WorkFlowTasksController.\u003C\u003Eo__11.\u003C\u003Ep__6.Target((CallSite) WorkFlowTasksController.\u003C\u003Eo__11.\u003C\u003Ep__6, this.ViewBag, source.FirstOrDefault<RoadFlow.Data.Model.WorkFlowTask>().FlowID.ToString());
      return (ActionResult) this.View((object) source);
    }

    [MyAttribute(CheckApp = false)]
    public string Withdraw()
    {
      string msg;
      if (!WebMvc.Common.Tools.CheckLogin(out msg) && !RoadFlow.Platform.WeiXin.Organize.CheckLogin())
        return "";
      string str = this.Request.QueryString["taskid"];
      Guid test;
      if (!str.IsGuid(out test))
        return "参数错误!";
      if (!new RoadFlow.Platform.WorkFlowTask().HasWithdraw(test))
        return "该任务不能收回!";
      if (!new RoadFlow.Platform.WorkFlowTask().WithdrawTask(test))
        return "收回失败!";
      RoadFlow.Platform.Log.Add("收回了任务", "任务ID：" + str, RoadFlow.Platform.Log.Types.流程相关, "", "", (RoadFlow.Data.Model.Users) null);
      return "收回成功!";
    }

    [MyAttribute(CheckApp = false, CheckLogin = false)]
    public ActionResult ChangeStatus()
    {
      RoadFlow.Platform.WorkFlowTask workFlowTask1 = new RoadFlow.Platform.WorkFlowTask();
      RoadFlow.Data.Model.WorkFlowTask workFlowTask2 = (RoadFlow.Data.Model.WorkFlowTask) null;
      string empty = string.Empty;
      string str1 = this.Request.QueryString["taskid"];
      if (str1.IsGuid())
        workFlowTask2 = workFlowTask1.Get(str1.ToGuid());
      string str2 = "";
      if (workFlowTask2 != null)
        str2 = workFlowTask2.Status.ToString();
      // ISSUE: reference to a compiler-generated field
      if (WorkFlowTasksController.\u003C\u003Eo__13.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        WorkFlowTasksController.\u003C\u003Eo__13.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Status", typeof (WorkFlowTasksController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj = WorkFlowTasksController.\u003C\u003Eo__13.\u003C\u003Ep__0.Target((CallSite) WorkFlowTasksController.\u003C\u003Eo__13.\u003C\u003Ep__0, this.ViewBag, str2);
      return (ActionResult) this.View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [MyAttribute(CheckApp = false, CheckLogin = false)]
    public ActionResult ChangeStatus(FormCollection collection)
    {
      RoadFlow.Platform.WorkFlowTask workFlowTask = new RoadFlow.Platform.WorkFlowTask();
      RoadFlow.Data.Model.WorkFlowTask model = (RoadFlow.Data.Model.WorkFlowTask) null;
      string empty1 = string.Empty;
      string empty2 = string.Empty;
      string str = this.Request.QueryString["taskid"];
      if (str.IsGuid())
        model = workFlowTask.Get(str.ToGuid());
      if (model != null)
      {
        empty1 = this.Request.Form["Status"];
        if (empty1.IsInt())
        {
          string oldXML = model.Serialize();
          model.Status = empty1.ToInt();
          workFlowTask.Update(model);
          RoadFlow.Platform.Log.Add("改变了流程任务状态", "改变了流程任务状态", RoadFlow.Platform.Log.Types.流程相关, oldXML, model.Serialize(), (RoadFlow.Data.Model.Users) null);
          // ISSUE: reference to a compiler-generated field
          if (WorkFlowTasksController.\u003C\u003Eo__14.\u003C\u003Ep__0 == null)
          {
            // ISSUE: reference to a compiler-generated field
            WorkFlowTasksController.\u003C\u003Eo__14.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Script", typeof (WorkFlowTasksController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj = WorkFlowTasksController.\u003C\u003Eo__14.\u003C\u003Ep__0.Target((CallSite) WorkFlowTasksController.\u003C\u003Eo__14.\u003C\u003Ep__0, this.ViewBag, "alert('设置成功!');new RoadUI.Window().reloadOpener();new RoadUI.Window().close();");
        }
      }
      // ISSUE: reference to a compiler-generated field
      if (WorkFlowTasksController.\u003C\u003Eo__14.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        WorkFlowTasksController.\u003C\u003Eo__14.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Status", typeof (WorkFlowTasksController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = WorkFlowTasksController.\u003C\u003Eo__14.\u003C\u003Ep__1.Target((CallSite) WorkFlowTasksController.\u003C\u003Eo__14.\u003C\u003Ep__1, this.ViewBag, empty1);
      return (ActionResult) this.View();
    }

    [MyAttribute(CheckApp = false)]
    public ActionResult Hasten()
    {
      return this.Hasten((FormCollection) null);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [MyAttribute(CheckApp = false)]
    public ActionResult Hasten(FormCollection collection)
    {
      if (collection != null)
      {
        string str1 = this.Request.Form["HastenUsers"];
        string types = this.Request.Form["HastenType"];
        string str2 = this.Request.Form["Contents"];
        RoadFlow.Data.Model.WorkFlowTask workFlowTask = new RoadFlow.Platform.WorkFlowTask().Get(this.Request.QueryString["taskid"].ToGuid());
        string users = str1;
        string contents = str2;
        RoadFlow.Data.Model.WorkFlowTask task = workFlowTask;
        string othersParams = "";
        RoadFlow.Platform.HastenLog.Hasten(types, users, contents, task, othersParams);
        // ISSUE: reference to a compiler-generated field
        if (WorkFlowTasksController.\u003C\u003Eo__16.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          WorkFlowTasksController.\u003C\u003Eo__16.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "script", typeof (WorkFlowTasksController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = WorkFlowTasksController.\u003C\u003Eo__16.\u003C\u003Ep__0.Target((CallSite) WorkFlowTasksController.\u003C\u003Eo__16.\u003C\u003Ep__0, this.ViewBag, "alert('催办成功!');new RoadUI.Window().close()");
      }
      return (ActionResult) this.View();
    }

    [MyAttribute(CheckApp = false)]
    public ActionResult GoTo()
    {
      return this.GoTo((FormCollection) null);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [MyAttribute(CheckApp = false)]
    public ActionResult GoTo(FormCollection collection)
    {
      if (collection != null)
      {
        string[] strArray = (this.Request.Form["step"] ?? "").Split(',');
        System.Collections.Generic.Dictionary<Guid, string> gotoSteps = new System.Collections.Generic.Dictionary<Guid, string>();
        foreach (string str1 in strArray)
        {
          if (str1.IsGuid())
          {
            string str2 = this.Request.Form["member_" + str1];
            if (!str2.IsNullOrEmpty())
              gotoSteps.Add(str1.ToGuid(), str2);
          }
        }
        RoadFlow.Platform.WorkFlowTask workFlowTask = new RoadFlow.Platform.WorkFlowTask();
        bool task = workFlowTask.GoToTask(workFlowTask.Get(this.Request.QueryString["taskid"].ToGuid()), gotoSteps);
        // ISSUE: reference to a compiler-generated field
        if (WorkFlowTasksController.\u003C\u003Eo__18.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          WorkFlowTasksController.\u003C\u003Eo__18.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "script", typeof (WorkFlowTasksController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = WorkFlowTasksController.\u003C\u003Eo__18.\u003C\u003Ep__0.Target((CallSite) WorkFlowTasksController.\u003C\u003Eo__18.\u003C\u003Ep__0, this.ViewBag, "alert('跳转" + (task ? "成功" : "失败") + "');new RoadUI.Window().reloadOpener();new RoadUI.Window().close();");
      }
      return (ActionResult) this.View();
    }

    [HttpPost]
    [MyAttribute(CheckApp = false)]
    public string deleteTask()
    {
      string str1 = this.Request.QueryString["flowid"];
      string str2 = this.Request.QueryString["groupid"];
      RoadFlow.Data.Model.WorkFlowTask workFlowTask = new RoadFlow.Platform.WorkFlowTask().Get(this.Request.QueryString["taskid"].ToGuid());
      if (workFlowTask == null)
        return "未找到当前任务!";
      new RoadFlow.Platform.WorkFlowTask().DeleteInstance(workFlowTask.FlowID, workFlowTask.GroupID, false);
      RoadFlow.Platform.Log.Add("作废了流程实例-" + workFlowTask.Title, workFlowTask.Serialize(), RoadFlow.Platform.Log.Types.流程相关, "", "", (RoadFlow.Data.Model.Users) null);
      return "作废成功!";
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [MyAttribute(CheckApp = false)]
    public string QueryWaitList()
    {
      RoadFlow.Platform.WorkFlowTask workFlowTask1 = new RoadFlow.Platform.WorkFlowTask();
      RoadFlow.Platform.WorkFlow workFlow = new RoadFlow.Platform.WorkFlow();
      RoadFlow.Platform.AppLibrary appLibrary = new RoadFlow.Platform.AppLibrary();
      string str1 = this.Request.Form["title"];
      string str2 = this.Request.Form["flowid"];
      string str3 = this.Request.Form["sender"];
      string str4 = this.Request.Form["date1"];
      string str5 = this.Request.Form["date2"];
      string str6 = this.Request.Form["sidx"];
      string str7 = this.Request.Form["sord"];
      string str8 = "";
      int pageSize = RoadFlow.Utility.Tools.GetPageSize();
      int pageNumber = RoadFlow.Utility.Tools.GetPageNumber();
      string str9 = (str6.IsNullOrEmpty() ? "ReceiveTime" : str6) + " " + (str7.IsNullOrEmpty() ? "asc" : str7);
      Guid currentUserId1 = MyController.CurrentUserID;
      long num1;
      ref long local = ref num1;
      int size = pageSize;
      int number = pageNumber;
      string title = str1.Trim1();
      string flowid = str2;
      string sender = str3;
      string date1 = str4;
      string date2 = str5;
      int type = 0;
      string order = str9;
      List<RoadFlow.Data.Model.WorkFlowTask> tasks = workFlowTask1.GetTasks(currentUserId1, out local, size, number, title, flowid, sender, date1, date2, type, order);
      JsonData jsonData1 = new JsonData();
      Guid currentUserId2 = MyController.CurrentUserID;
      foreach (RoadFlow.Data.Model.WorkFlowTask workFlowTask2 in tasks)
      {
        RoadFlow.Data.Model.AppLibrary byCode = appLibrary.GetByCode(workFlowTask2.FlowID.ToString(), true);
        int num2 = 0;
        int num3 = 1000;
        int num4 = 500;
        if (byCode != null)
        {
          num2 = byCode.OpenMode;
          int? nullable = byCode.Width;
          int num5;
          if (!nullable.HasValue)
          {
            num5 = 1000;
          }
          else
          {
            nullable = byCode.Width;
            num5 = nullable.Value;
          }
          num3 = num5;
          nullable = byCode.Height;
          int num6;
          if (!nullable.HasValue)
          {
            num6 = 500;
          }
          else
          {
            nullable = byCode.Height;
            num6 = nullable.Value;
          }
          num4 = num6;
        }
        WorkFlowInstalled workFlowRunModel = workFlow.GetWorkFlowRunModel(workFlowTask2.FlowID, true);
        JsonData jsonData2 = new JsonData();
        jsonData2["id"] = (JsonData) workFlowTask2.ID.ToString();
        jsonData2["FlowName"] = (JsonData) workFlow.GetFlowName(workFlowTask2.FlowID);
        jsonData2["StepName"] = (JsonData) workFlowTask2.StepName;
        jsonData2["Note"] = (JsonData) workFlowTask2.Note;
        jsonData2["ReceiveTime"] = (JsonData) workFlowTask2.ReceiveTime.ToDateTimeString();
        jsonData2["SenderName"] = (JsonData) workFlowTask2.SenderName;
        jsonData2["StatusTitle"] = !workFlowTask2.CompletedTime.HasValue ? (JsonData) "<i title=\"正常\" class=\"fa fa-bell\" style=\"color:#666;font-weight:bold;\"></i><span title=\"要求完成时间：无时间要求\">正常</span></i>" : (!(workFlowTask2.CompletedTime.Value < DateTimeNew.Now) ? ((workFlowTask2.CompletedTime.Value - DateTimeNew.Now).Days > 3 ? (JsonData) ("<i title=\"正常\" class=\"fa fa-bell\" style=\"color:#666;font-weight:bold;\"></i><span title=\"要求完成时间：" + workFlowTask2.CompletedTime.Value.ToDateTimeString() + "\">正常</span></i>") : (JsonData) ("<i title=\"即将过期\" class=\"fa fa-bell\" style=\"color:#fd8a02;font-weight:bold;\"><span title=\"要求完成时间：" + workFlowTask2.CompletedTime.Value.ToDateTimeString() + "\">即将到期</span></i>")) : (JsonData) ("<i title=\"已过期\" class=\"fa fa-bell\" style=\"color:red;font-weight:bold;\"><span title=\"要求完成时间：" + workFlowTask2.CompletedTime.Value.ToDateTimeString() + "\">已过期</span></i>"));
        jsonData2["Title"] = (JsonData) ("<a href=\"javascript:void(0);\" class=\"blue\" onclick=\"openTask('/WorkFlowRun/Index?" + string.Format("flowid={0}&stepid={1}&instanceid={2}&taskid={3}&groupid={4}&appid={5}", (object) workFlowTask2.FlowID, (object) workFlowTask2.StepID, (object) workFlowTask2.InstanceID, (object) workFlowTask2.ID, (object) workFlowTask2.GroupID, (object) str8) + "','" + workFlowTask2.Title.RemoveHTML().UrlEncode() + "','" + (object) workFlowTask2.ID + "'," + (object) num2 + "," + (object) num3 + "," + (object) num4 + ");return false;\">" + workFlowTask2.Title.HtmlEncode() + "</a>");
        string str10 = "<a href=\"javascript:void(0);\" class=\"editlink\" onclick=\"openTask('/WorkFlowRun/Index?" + string.Format("flowid={0}&stepid={1}&instanceid={2}&taskid={3}&groupid={4}&appid={5}", (object) workFlowTask2.FlowID, (object) workFlowTask2.StepID, (object) workFlowTask2.InstanceID, (object) workFlowTask2.ID, (object) workFlowTask2.GroupID, (object) str8) + "','" + workFlowTask2.Title.RemoveHTML().UrlEncode() + "','" + (object) workFlowTask2.ID + "'," + (object) num2 + "," + (object) num3 + "," + (object) num4 + ");return false;\">处理</a>&nbsp;&nbsp;<a class=\"viewlink\" href=\"javascript:void(0);\" onclick=\"detail('" + (object) workFlowTask2.FlowID + "','" + (object) workFlowTask2.GroupID + "','" + (object) workFlowTask2.ID + "');return false;\">查看</a>";
        if (workFlowRunModel != null && workFlowRunModel.FirstStepID == workFlowTask2.StepID && workFlowTask2.SenderID == currentUserId2)
          str10 = str10 + "&nbsp;&nbsp;<a class=\"deletelink\" href=\"javascript:void(0);\" onclick=\"delTask('" + (object) workFlowTask2.FlowID + "','" + (object) workFlowTask2.GroupID + "','" + (object) workFlowTask2.ID + "');return false;\">作废</a>";
        jsonData2["Opation"] = (JsonData) str10;
        jsonData1.Add((object) jsonData2);
      }
      return "{\"userdata\":{\"total\":" + (object) num1 + ",\"pagesize\":" + (object) pageSize + ",\"pagenumber\":" + (object) pageNumber + "},\"rows\":" + jsonData1.ToJson(true) + "}";
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [MyAttribute(CheckApp = false)]
    public string QueryCompletedList()
    {
      RoadFlow.Platform.WorkFlowTask workFlowTask1 = new RoadFlow.Platform.WorkFlowTask();
      RoadFlow.Platform.WorkFlow workFlow = new RoadFlow.Platform.WorkFlow();
      RoadFlow.Platform.AppLibrary appLibrary = new RoadFlow.Platform.AppLibrary();
      string str1 = this.Request.Form["title"];
      string flowid = this.Request.Form["flowid"];
      string sender = this.Request.Form["sender"];
      string date1 = this.Request.Form["date1"];
      string date2 = this.Request.Form["date2"];
      string str2 = this.Request.Form["sidx"];
      string str3 = this.Request.Form["sord"];
      string str4 = "";
      int pageSize = RoadFlow.Utility.Tools.GetPageSize();
      int pageNumber = RoadFlow.Utility.Tools.GetPageNumber();
      string order = (str2.IsNullOrEmpty() ? "CompletedTime1" : str2) + " " + (str3.IsNullOrEmpty() ? "asc" : str3);
      long count;
      List<RoadFlow.Data.Model.WorkFlowTask> tasks = workFlowTask1.GetTasks(MyController.CurrentUserID, out count, pageSize, pageNumber, str1.Trim1(), flowid, sender, date1, date2, 1, order);
      JsonData jsonData1 = new JsonData();
      foreach (RoadFlow.Data.Model.WorkFlowTask workFlowTask2 in tasks)
      {
        bool isHasten = false;
        RoadFlow.Data.Model.AppLibrary byCode = appLibrary.GetByCode(workFlowTask2.FlowID.ToString(), true);
        int num1 = 0;
        int num2 = 1000;
        int num3 = 500;
        if (byCode != null)
        {
          num1 = byCode.OpenMode;
          int? nullable = byCode.Width;
          int num4;
          if (!nullable.HasValue)
          {
            num4 = 1000;
          }
          else
          {
            nullable = byCode.Width;
            num4 = nullable.Value;
          }
          num2 = num4;
          nullable = byCode.Height;
          int num5;
          if (!nullable.HasValue)
          {
            num5 = 500;
          }
          else
          {
            nullable = byCode.Height;
            num5 = nullable.Value;
          }
          num3 = num5;
        }
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append("<a class=\"viewlink\" href=\"javascript:void(0);\" onclick=\"detail('" + (object) workFlowTask2.FlowID + "','" + (object) workFlowTask2.GroupID + "','" + (object) workFlowTask2.ID + "');return false;\">查看</a>");
        if (workFlowTask2.Status == 2 && workFlowTask1.HasWithdraw(workFlowTask2.ID, out isHasten))
          stringBuilder.Append("<a style=\"background:url(" + this.Url.Content("~/Images/ico/back.gif") + ") no-repeat left center; padding-left:18px;margin-left:5px;\" href=\"javascript:void(0);\" onclick=\"withdraw('" + (object) workFlowTask2.ID + "');\">收回</a>");
        if (isHasten)
          stringBuilder.Append("<a style=\"background:url(" + this.Url.Content("~/Images/ico/comment_reply.png") + ") no-repeat left center; padding-left:18px;margin-left:5px;\" href=\"javascript:void(0);\" onclick=\"hasten('" + (object) workFlowTask2.ID + "');\">催办</a>");
        JsonData jsonData2 = new JsonData();
        jsonData2["id"] = (JsonData) workFlowTask2.ID.ToString();
        jsonData2["FlowName"] = (JsonData) workFlow.GetFlowName(workFlowTask2.FlowID);
        jsonData2["Note"] = (JsonData) workFlowTask2.Note;
        jsonData2["ReceiveTime"] = (JsonData) workFlowTask2.ReceiveTime.ToDateTimeString();
        JsonData jsonData3 = jsonData2;
        string index = "CompletedTime";
        DateTime? completedTime1 = workFlowTask2.CompletedTime1;
        string str5;
        if (!completedTime1.HasValue)
        {
          str5 = "";
        }
        else
        {
          completedTime1 = workFlowTask2.CompletedTime1;
          str5 = completedTime1.Value.ToDateTimeString();
        }
        JsonData jsonData4 = (JsonData) str5;
        jsonData3[index] = jsonData4;
        jsonData2["SenderName"] = (JsonData) workFlowTask2.SenderName;
        jsonData2["StepName"] = (JsonData) workFlowTask2.StepName;
        jsonData2["Title"] = (JsonData) ("<a href=\"javascript:void(0);\" onclick=\"openTask('/WorkFlowRun/Index?" + string.Format("flowid={0}&stepid={1}&instanceid={2}&taskid={3}&groupid={4}&appid={5}&display=1", (object) workFlowTask2.FlowID, (object) workFlowTask2.StepID, (object) workFlowTask2.InstanceID, (object) workFlowTask2.ID, (object) workFlowTask2.GroupID, (object) str4) + "','" + workFlowTask2.Title.RemoveHTML().UrlEncode() + "','" + (object) workFlowTask2.ID + "'," + (object) num1 + "," + (object) num2 + "," + (object) num3 + ");return false;\">" + workFlowTask2.Title.HtmlEncode() + "</a>");
        jsonData2["Opation"] = (JsonData) stringBuilder.ToString();
        jsonData1.Add((object) jsonData2);
      }
      return "{\"userdata\":{\"total\":" + (object) count + ",\"pagesize\":" + (object) pageSize + ",\"pagenumber\":" + (object) pageNumber + "},\"rows\":" + jsonData1.ToJson(true) + "}";
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public string QueryInstanceList()
    {
      RoadFlow.Platform.WorkFlowTask workFlowTask1 = new RoadFlow.Platform.WorkFlowTask();
      RoadFlow.Platform.WorkFlow workFlow = new RoadFlow.Platform.WorkFlow();
      string str1 = this.Request.Form["Title"];
      string str2 = this.Request.Form["FlowID"];
      string str3 = this.Request.Form["SenderID"];
      string str4 = this.Request.Form["Date1"];
      string str5 = this.Request.Form["Date2"];
      string str6 = this.Request.Form["Status"];
      string str7 = this.Request.Form["sidx"];
      string str8 = this.Request.Form["sord"];
      string typeID = this.Request.Form["typeid"];
      string str9 = this.Request.Form["appid"];
      System.Collections.Generic.Dictionary<Guid, string> manageFlowIdList = workFlow.GetInstanceManageFlowIDList(RoadFlow.Platform.Users.CurrentUserID, typeID);
      List<Guid> guidList = new List<Guid>();
      foreach (KeyValuePair<Guid, string> keyValuePair in (IEnumerable<KeyValuePair<Guid, string>>) manageFlowIdList.OrderBy<KeyValuePair<Guid, string>, string>((Func<KeyValuePair<Guid, string>, string>) (p => p.Value)))
        guidList.Add(keyValuePair.Key);
      Guid[] array = guidList.ToArray();
      int pageSize = RoadFlow.Utility.Tools.GetPageSize();
      int pageNumber = RoadFlow.Utility.Tools.GetPageNumber();
      string str10 = (str7.IsNullOrEmpty() ? "SenderTime" : str7) + " " + (str8.IsNullOrEmpty() ? "asc" : str8);
      RoadFlow.Platform.WorkFlowTask workFlowTask2 = workFlowTask1;
      Guid[] flowID = array;
      Guid[] senderID = new Guid[0];
      Guid[] receiveID;
      if (!str3.IsNullOrEmpty())
        receiveID = new Guid[1]
        {
          str3.Replace("u_", "").ToGuid()
        };
      else
        receiveID = new Guid[0];
      long num;
      ref long local = ref num;
      int size = pageSize;
      int number = pageNumber;
      string title = str1.Trim1();
      string flowid = str2;
      string date1 = str4;
      string date2 = str5;
      int status = str6.ToInt();
      string order = str10;
      DataTable instances1 = workFlowTask2.GetInstances1(flowID, senderID, receiveID, out local, size, number, title, flowid, date1, date2, status, order);
      JsonData jsonData1 = new JsonData();
      foreach (DataRow row in (InternalDataCollectionBase) instances1.Rows)
      {
        RoadFlow.Data.Model.WorkFlowTask lastTask = workFlowTask1.GetLastTask(row["FlowID"].ToString().ToGuid(), row["GroupID"].ToString().ToGuid());
        if (lastTask != null)
        {
          string flowName;
          string stepName = workFlow.GetStepName(lastTask.StepID, lastTask.FlowID, out flowName, false);
          string str11 = string.Format("flowid={0}&stepid={1}&instanceid={2}&taskid={3}&groupid={4}&appid={5}&display=1", (object) lastTask.FlowID, (object) lastTask.StepID, (object) lastTask.InstanceID, (object) lastTask.ID, (object) lastTask.GroupID, (object) str9);
          StringBuilder stringBuilder1 = new StringBuilder();
          StringBuilder stringBuilder2 = stringBuilder1;
          string[] strArray1 = new string[7]{ "<a style=\"margin-right:5px; background:url(", this.Url.Content("~/Images/ico/mouse.png"), ") no-repeat left center; padding-left:18px;\" href=\"javascript:void(0);\" onclick=\"manage('", null, null, null, null };
          int index1 = 3;
          Guid guid = lastTask.FlowID;
          string str12 = guid.ToString();
          strArray1[index1] = str12;
          strArray1[4] = "','";
          int index2 = 5;
          guid = lastTask.GroupID;
          string str13 = guid.ToString();
          strArray1[index2] = str13;
          strArray1[6] = "');\">管理</a>";
          string str14 = string.Concat(strArray1);
          stringBuilder2.Append(str14);
          if (lastTask.Status.In(-1, 0, 1))
          {
            StringBuilder stringBuilder3 = stringBuilder1;
            string[] strArray2 = new string[7]{ "<a style=\"background:url(", this.Url.Content("~/Images/ico/trash.gif"), ") no-repeat left center; padding-left:18px;\" href=\"javascript:void(0);\" onclick=\"delete1('", null, null, null, null };
            int index3 = 3;
            guid = lastTask.FlowID;
            string str15 = guid.ToString();
            strArray2[index3] = str15;
            strArray2[4] = "','";
            int index4 = 5;
            guid = lastTask.GroupID;
            string str16 = guid.ToString();
            strArray2[index4] = str16;
            strArray2[6] = "');\">删除</a>";
            string str17 = string.Concat(strArray2);
            stringBuilder3.Append(str17);
          }
          JsonData jsonData2 = new JsonData();
          JsonData jsonData3 = jsonData2;
          string index5 = "id";
          guid = lastTask.ID;
          JsonData jsonData4 = (JsonData) guid.ToString();
          jsonData3[index5] = jsonData4;
          jsonData2["Title"] = (JsonData) ("<a href=\"javascript:void(0);\" onclick=\"openTask('/WorkFlowRun/Index?" + str11 + "','" + lastTask.Title.RemoveHTML().UrlEncode() + "','" + (object) lastTask.ID + "');return false;\" class=\"blue\">" + lastTask.Title.HtmlEncode() + "</a>");
          jsonData2["FlowName"] = (JsonData) flowName;
          jsonData2["StepName"] = (JsonData) stepName;
          jsonData2["ReceiveName"] = (JsonData) lastTask.ReceiveName;
          jsonData2["ReceiveTime"] = (JsonData) lastTask.ReceiveTime.ToDateTimeStringS();
          jsonData2["StatusTitle"] = (JsonData) lastTask.Status;
          jsonData2["Opation"] = (JsonData) stringBuilder1.ToString();
          jsonData1.Add((object) jsonData2);
        }
      }
      return "{\"userdata\":{\"total\":" + (object) num + ",\"pagesize\":" + (object) pageSize + ",\"pagenumber\":" + (object) pageNumber + "},\"rows\":" + jsonData1.ToJson(true) + "}";
    }
  }
}
