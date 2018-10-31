// Decompiled with JetBrains decompiler
// Type: WebMvc.Controllers.WorkFlowRunController
// Assembly: WebMvc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 43FD7615-6DC3-49FB-B263-7F7CC91AFA77
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\WebMvc.dll

using Microsoft.CSharp.RuntimeBinder;
using RoadFlow.Data.Model;
using RoadFlow.Data.Model.WorkFlowInstalledSub;
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
  public class WorkFlowRunController : MyController
  {
    [MyAttribute(CheckApp = false, CheckUrl = false)]
    public ActionResult Index()
    {
      return (ActionResult) this.View();
    }

    [MyAttribute(CheckApp = false, CheckLogin = false, CheckUrl = false)]
    public ActionResult Index_App()
    {
      return (ActionResult) this.View();
    }

    [MyAttribute(CheckApp = false, CheckUrl = false)]
    public ActionResult ShowComment()
    {
      return (ActionResult) this.View();
    }

    [MyAttribute(CheckApp = false, CheckLogin = false, CheckUrl = false)]
    public ActionResult Print()
    {
      return (ActionResult) this.View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [MyAttribute(CheckApp = false, CheckLogin = false)]
    public ActionResult Execute()
    {
      return (ActionResult) this.View();
    }

    [MyAttribute(CheckApp = false, CheckLogin = false)]
    public ActionResult FlowBack()
    {
      return (ActionResult) this.View();
    }

    [MyAttribute(CheckApp = false, CheckLogin = false)]
    public ActionResult FlowRedirect()
    {
      return (ActionResult) this.View();
    }

    [MyAttribute(CheckApp = false, CheckLogin = false)]
    public ActionResult FlowSend()
    {
      return (ActionResult) this.View();
    }

    [MyAttribute(CheckApp = false, CheckLogin = false, CheckUrl = false)]
    public ActionResult Process()
    {
      return (ActionResult) this.View();
    }

    [MyAttribute(CheckApp = false, CheckLogin = false, CheckUrl = false)]
    public ActionResult Sign()
    {
      return (ActionResult) this.View();
    }

    [MyAttribute(CheckApp = false, CheckLogin = false)]
    public ActionResult SaveData()
    {
      return (ActionResult) this.View();
    }

    [MyAttribute(CheckApp = false, CheckLogin = false)]
    public ActionResult ShowDesign()
    {
      return (ActionResult) this.View();
    }

    [MyAttribute(CheckApp = false, CheckLogin = false)]
    public ActionResult SubTableEdit()
    {
      return (ActionResult) this.View();
    }

    [MyAttribute(CheckApp = false, CheckLogin = false)]
    public string SubTableDelete()
    {
      return new RoadFlow.Platform.DBConnection().DeleteData(this.Request.QueryString["secondtableconnid"].ToGuid(), this.Request.QueryString["secondtable"], this.Request.QueryString["secondtableprimarykey"], this.Request.QueryString["secondtablepkvalue"]) > 0 ? "删除成功!" : "删除失败!";
    }

    [MyAttribute(CheckApp = false, CheckLogin = false)]
    public ActionResult FlowFreedomSend()
    {
      return (ActionResult) this.View();
    }

    [MyAttribute(CheckApp = false)]
    public ActionResult TaskEnd()
    {
      string str1 = this.Request.QueryString["taskid"];
      string str2 = str1.IsGuid() ? new RoadFlow.Platform.WorkFlowTask().EndTask(str1.ToGuid()) : "参数错误";
      RoadFlow.Platform.Log.Add("终止的流程任务", str1, RoadFlow.Platform.Log.Types.流程相关, "", "", (RoadFlow.Data.Model.Users) null);
      if ("1" != str2)
      {
        // ISSUE: reference to a compiler-generated field
        if (WorkFlowRunController.\u003C\u003Eo__15.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          WorkFlowRunController.\u003C\u003Eo__15.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "script", typeof (WorkFlowRunController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = WorkFlowRunController.\u003C\u003Eo__15.\u003C\u003Ep__0.Target((CallSite) WorkFlowRunController.\u003C\u003Eo__15.\u003C\u003Ep__0, this.ViewBag, "alert('" + str2 + "')");
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        if (WorkFlowRunController.\u003C\u003Eo__15.\u003C\u003Ep__1 == null)
        {
          // ISSUE: reference to a compiler-generated field
          WorkFlowRunController.\u003C\u003Eo__15.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "script", typeof (WorkFlowRunController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = WorkFlowRunController.\u003C\u003Eo__15.\u003C\u003Ep__1.Target((CallSite) WorkFlowRunController.\u003C\u003Eo__15.\u003C\u003Ep__1, this.ViewBag, "alert('终止成功!'); try{top.mainDialog.close();}catch(e){} try{top.mainTab.closeTab();}catch(e){parent.close();}");
      }
      return (ActionResult) this.View();
    }

    [MyAttribute(CheckApp = false, CheckLogin = false, CheckUrl = false)]
    public string GetLinkageOptions()
    {
      string str1 = this.Request["linkagesource"];
      string sql = this.Request["linkagesourcetext"];
      string str2 = this.Request["linkagesourceconn"];
      string str3 = this.Request["value"];
      if ("sql" == str1)
      {
        Guid test;
        if (!str2.IsGuid(out test))
          return "";
        return new RoadFlow.Platform.DBConnection().GetOptionsFromSql(test, sql, (IDbDataParameter[]) null, "");
      }
      if ("dict" == str1)
        return new RoadFlow.Platform.Dictionary().GetOptionsByID(str3.ToGuid(), RoadFlow.Platform.Dictionary.OptionValueField.ID, "", false);
      return "";
    }

    [MyAttribute(CheckApp = false)]
    public ActionResult FlowCopyFor()
    {
      return this.FlowCopyFor((FormCollection) null);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [MyAttribute(CheckApp = false)]
    public ActionResult FlowCopyFor(FormCollection collection)
    {
      RoadFlow.Platform.WorkFlow workFlow = new RoadFlow.Platform.WorkFlow();
      RoadFlow.Platform.WorkFlowTask workFlowTask1 = new RoadFlow.Platform.WorkFlowTask();
      string str1 = this.Request.QueryString["flowid"];
      string stepid = this.Request.QueryString["stepid"];
      string str2 = this.Request.QueryString["groupid"];
      string str3 = this.Request.QueryString["instanceid"];
      string flowID = str1;
      int num = 1;
      WorkFlowInstalled workFlowRunModel = workFlow.GetWorkFlowRunModel(flowID, num != 0);
      if (workFlowRunModel == null)
      {
        this.Response.Write("未找到流程运行实体");
        this.Response.End();
        return (ActionResult) null;
      }
      if (workFlowRunModel.Steps.Where<Step>((Func<Step, bool>) (p => p.ID == stepid.ToGuid())).Count<Step>() == 0)
      {
        this.Response.Write("未找到当前步骤");
        this.Response.End();
        return (ActionResult) null;
      }
      RoadFlow.Data.Model.WorkFlowTask workFlowTask2 = workFlowTask1.Get(this.Request.QueryString["taskid"].ToGuid());
      if (workFlowTask2 == null)
      {
        this.Response.Write("当前任务为空,请先保存再抄送!");
        this.Response.End();
        return (ActionResult) null;
      }
      if (collection != null)
      {
        List<RoadFlow.Data.Model.WorkFlowTask> taskList = workFlowTask1.GetTaskList(workFlowTask2.ID, true);
        List<RoadFlow.Data.Model.Users> allUsers = new RoadFlow.Platform.Organize().GetAllUsers(this.Request.Form["user"] ?? "");
        StringBuilder stringBuilder = new StringBuilder();
        foreach (RoadFlow.Data.Model.Users users in allUsers)
        {
          RoadFlow.Data.Model.Users user = users;
          if (taskList.Find((Predicate<RoadFlow.Data.Model.WorkFlowTask>) (p => p.ReceiveID == user.ID)) == null)
          {
            Step step = workFlowRunModel.Steps.Where<Step>((Func<Step, bool>) (p => p.ID == this.Request.QueryString["stepid"].ToGuid())).First<Step>();
            RoadFlow.Data.Model.WorkFlowTask model = new RoadFlow.Data.Model.WorkFlowTask();
            if (step.WorkTime > Decimal.Zero)
              model.CompletedTime = new DateTime?(DateTimeNew.Now.AddHours((double) step.WorkTime));
            model.FlowID = workFlowTask2.FlowID;
            model.GroupID = workFlowTask2.GroupID;
            model.ID = Guid.NewGuid();
            model.Type = 5;
            model.InstanceID = workFlowTask2.InstanceID;
            model.Note = "抄送任务";
            model.PrevID = workFlowTask2.PrevID;
            model.PrevStepID = workFlowTask2.PrevStepID;
            model.ReceiveID = user.ID;
            model.ReceiveName = user.Name;
            model.ReceiveTime = DateTimeNew.Now;
            model.SenderID = workFlowTask2.ReceiveID;
            model.SenderName = workFlowTask2.ReceiveName;
            model.SenderTime = model.ReceiveTime;
            model.Status = 0;
            model.StepID = workFlowTask2.StepID;
            model.StepName = workFlowTask2.StepName;
            model.Sort = workFlowTask2.Sort;
            model.Title = workFlowTask2.Title;
            workFlowTask1.Add(model);
            stringBuilder.Append(model.ReceiveName);
            stringBuilder.Append(",");
          }
        }
        // ISSUE: reference to a compiler-generated field
        if (WorkFlowRunController.\u003C\u003Eo__18.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          WorkFlowRunController.\u003C\u003Eo__18.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "script", typeof (WorkFlowRunController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = WorkFlowRunController.\u003C\u003Eo__18.\u003C\u003Ep__0.Target((CallSite) WorkFlowRunController.\u003C\u003Eo__18.\u003C\u003Ep__0, this.ViewBag, "alert('成功抄送给：" + stringBuilder.ToString().TrimEnd(',') + "');new RoadUI.Window().close();");
      }
      return (ActionResult) this.View();
    }

    [MyAttribute(CheckApp = false)]
    public ActionResult ShowForm()
    {
      string str = this.Request.QueryString["taskid"];
      if (str.IsGuid())
      {
        RoadFlow.Platform.WorkFlowTask workFlowTask1 = new RoadFlow.Platform.WorkFlowTask();
        RoadFlow.Data.Model.WorkFlowTask workFlowTask2 = workFlowTask1.Get(str.ToGuid());
        if (workFlowTask2 != null)
        {
          List<RoadFlow.Data.Model.WorkFlowTask> bySubFlowGroupId = workFlowTask1.GetBySubFlowGroupID(workFlowTask2.GroupID);
          if (bySubFlowGroupId.Count > 0)
          {
            RoadFlow.Data.Model.WorkFlowTask workFlowTask3 = bySubFlowGroupId.OrderByDescending<RoadFlow.Data.Model.WorkFlowTask, int>((Func<RoadFlow.Data.Model.WorkFlowTask, int>) (p => p.Sort)).FirstOrDefault<RoadFlow.Data.Model.WorkFlowTask>();
            return (ActionResult) this.Redirect(("1" == this.Request.QueryString["ismobile"] ? (object) "Index_App" : (object) "Index").ToString() + "?flowid=" + (object) workFlowTask3.FlowID + "&stepid=" + (object) workFlowTask3.StepID + "&instanceid=" + workFlowTask3.InstanceID + "&taskid=" + (object) workFlowTask3.ID + "&groupid=" + (object) workFlowTask3.GroupID + "&appid=" + this.Request.QueryString["appid"] + "&display=1&tabid=" + this.Request.QueryString["tabid"]);
          }
        }
      }
      return (ActionResult) this.View();
    }

    [MyAttribute(CheckApp = false)]
    public ActionResult AddWrite()
    {
      return this.AddWrite((FormCollection) null);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [MyAttribute(CheckApp = false)]
    public ActionResult AddWrite(FormCollection collection)
    {
      if (collection != null)
      {
        string str1 = this.Request.Form["addtype"];
        string str2 = this.Request.Form["writetype"];
        string writeUsers = this.Request.Form["writeuser"];
        string note = this.Request.Form["note"];
        string msg;
        string str3 = "alert('" + (new RoadFlow.Platform.WorkFlowTask().AddWrite(this.Request.QueryString["taskid"].ToGuid(), str1.ToInt(), str2.ToInt(), writeUsers, note, out msg) ? "加签成功!" : msg) + "');";
        if (str1.ToInt() == 1)
          str3 += "try{if(top.refreshPage){top.refreshPage();}if(top.mainTab){top.mainTab.closeTab();}else{top.close();}}catch(e){}";
        string str4 = str3 + "try{new RoadUI.Window().close();}catch(e){}";
        // ISSUE: reference to a compiler-generated field
        if (WorkFlowRunController.\u003C\u003Eo__21.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          WorkFlowRunController.\u003C\u003Eo__21.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "script", typeof (WorkFlowRunController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = WorkFlowRunController.\u003C\u003Eo__21.\u003C\u003Ep__0.Target((CallSite) WorkFlowRunController.\u003C\u003Eo__21.\u003C\u003Ep__0, this.ViewBag, str4);
      }
      return (ActionResult) this.View();
    }

    [MyAttribute(CheckApp = false)]
    public ActionResult StartFlow()
    {
      return this.StartFlow((FormCollection) null);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [MyAttribute(CheckApp = false)]
    public ActionResult StartFlow(FormCollection collection)
    {
      string s_FlowName = this.Request.QueryString["FlowName"];
      if (collection != null)
        s_FlowName = this.Request.Form["FlowName"];
      List<WorkFlowStart> workFlowStartList = new RoadFlow.Platform.WorkFlow().GetUserStartFlows(RoadFlow.Platform.Users.CurrentUserID);
      if (!s_FlowName.IsNullOrEmpty())
        workFlowStartList = workFlowStartList.FindAll((Predicate<WorkFlowStart>) (p => p.Name.Contains(s_FlowName.Trim1(), StringComparison.CurrentCultureIgnoreCase)));
      // ISSUE: reference to a compiler-generated field
      if (WorkFlowRunController.\u003C\u003Eo__23.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        WorkFlowRunController.\u003C\u003Eo__23.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "FlowName", typeof (WorkFlowRunController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj = WorkFlowRunController.\u003C\u003Eo__23.\u003C\u003Ep__0.Target((CallSite) WorkFlowRunController.\u003C\u003Eo__23.\u003C\u003Ep__0, this.ViewBag, s_FlowName);
      return (ActionResult) this.View((object) workFlowStartList);
    }

    [MyAttribute(CheckApp = false, CheckLogin = false, CheckUrl = false)]
    public ActionResult AutoSubmit()
    {
      return (ActionResult) this.View();
    }
  }
}
