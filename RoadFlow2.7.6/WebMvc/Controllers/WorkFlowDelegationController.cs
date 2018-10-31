// Decompiled with JetBrains decompiler
// Type: WebMvc.Controllers.WorkFlowDelegationController
// Assembly: WebMvc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 43FD7615-6DC3-49FB-B263-7F7CC91AFA77
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\WebMvc.dll

using LitJson;
using Microsoft.CSharp.RuntimeBinder;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
  public class WorkFlowDelegationController : MyController
  {
    public ActionResult Index()
    {
      RoadFlow.Platform.WorkFlowDelegation workFlowDelegation = new RoadFlow.Platform.WorkFlowDelegation();
      string.Format("&appid={0}&tabid={1}&isoneself={2}", (object) this.Request.QueryString["appid"], (object) this.Request.QueryString["tabid"], (object) this.Request.QueryString["isoneself"]);
      // ISSUE: reference to a compiler-generated field
      if (WorkFlowDelegationController.\u003C\u003Eo__0.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        WorkFlowDelegationController.\u003C\u003Eo__0.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Query", typeof (WorkFlowDelegationController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj = WorkFlowDelegationController.\u003C\u003Eo__0.\u003C\u003Ep__0.Target((CallSite) WorkFlowDelegationController.\u003C\u003Eo__0.\u003C\u003Ep__0, this.ViewBag, "&isoneself=" + this.Request.QueryString["isoneself"] + "&appid=" + this.Request.QueryString["appid"] + "&tabid=" + this.Request.QueryString["tabid"]);
      return (ActionResult) this.View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public string Delete()
    {
      RoadFlow.Platform.WorkFlowDelegation workFlowDelegation1 = new RoadFlow.Platform.WorkFlowDelegation();
      string str1 = this.Request.Form["ids"];
      char[] chArray = new char[1]{ ',' };
      foreach (string str2 in str1.Split(chArray))
      {
        Guid test;
        if (str2.IsGuid(out test))
        {
          RoadFlow.Data.Model.WorkFlowDelegation workFlowDelegation2 = workFlowDelegation1.Get(test);
          if (workFlowDelegation2 != null)
          {
            workFlowDelegation1.Delete(test);
            RoadFlow.Platform.Log.Add("删除了流程意见", workFlowDelegation2.Serialize(), RoadFlow.Platform.Log.Types.流程相关, "", "", (RoadFlow.Data.Model.Users) null);
          }
        }
      }
      workFlowDelegation1.RefreshCache();
      return "删除成功!";
    }

    [ValidateAntiForgeryToken]
    public string Query()
    {
      RoadFlow.Platform.WorkFlowDelegation workFlowDelegation1 = new RoadFlow.Platform.WorkFlowDelegation();
      RoadFlow.Platform.Organize organize = new RoadFlow.Platform.Organize();
      RoadFlow.Platform.Users users = new RoadFlow.Platform.Users();
      RoadFlow.Platform.WorkFlow workFlow1 = new RoadFlow.Platform.WorkFlow();
      string startTime = this.Request.Form["S_StartTime"];
      string endTime = this.Request.Form["S_EndTime"];
      string id1 = this.Request.Form["S_UserID"];
      string str1 = this.Request.Form["sidx"];
      string str2 = this.Request.Form["sord"];
      string str3 = this.Request.Form["typeid"];
      int pageSize = Tools.GetPageSize();
      int pageNumber = Tools.GetPageNumber();
      string order = (str1.IsNullOrEmpty() ? "SenderTime" : str1) + " " + (str2.IsNullOrEmpty() ? "asc" : str2);
      long count;
      IEnumerable<RoadFlow.Data.Model.WorkFlowDelegation> workFlowDelegations = !("1" == this.Request.QueryString["isoneself"]) ? (IEnumerable<RoadFlow.Data.Model.WorkFlowDelegation>) workFlowDelegation1.GetPagerData(out count, pageSize, pageNumber, RoadFlow.Platform.Users.RemovePrefix(id1), startTime, endTime, order) : (IEnumerable<RoadFlow.Data.Model.WorkFlowDelegation>) workFlowDelegation1.GetPagerData(out count, pageSize, pageNumber, MyController.CurrentUserID.ToString(), startTime, endTime, order);
      JsonData jsonData1 = new JsonData();
      foreach (RoadFlow.Data.Model.WorkFlowDelegation workFlowDelegation2 in workFlowDelegations)
      {
        string str4 = "委托中";
        if (workFlowDelegation2.StartTime > DateTimeNew.Now)
          str4 = "未开始";
        else if (workFlowDelegation2.EndTime < DateTimeNew.Now)
          str4 = "已失效";
        JsonData jsonData2 = new JsonData();
        JsonData jsonData3 = jsonData2;
        string index1 = "id";
        Guid id2 = workFlowDelegation2.ID;
        JsonData jsonData4 = (JsonData) id2.ToString();
        jsonData3[index1] = jsonData4;
        jsonData2["UserID"] = (JsonData) users.GetName(workFlowDelegation2.UserID);
        jsonData2["ToUserID"] = (JsonData) users.GetName(workFlowDelegation2.ToUserID);
        JsonData jsonData5 = jsonData2;
        string index2 = "FlowID";
        Guid? flowId = workFlowDelegation2.FlowID;
        string str5;
        if (!flowId.HasValue)
        {
          str5 = "";
        }
        else
        {
          RoadFlow.Platform.WorkFlow workFlow2 = workFlow1;
          flowId = workFlowDelegation2.FlowID;
          Guid flowID = flowId.Value;
          str5 = workFlow2.GetFlowName(flowID);
        }
        JsonData jsonData6 = (JsonData) str5;
        jsonData5[index2] = jsonData6;
        jsonData2["StartTime"] = (JsonData) workFlowDelegation2.StartTime.ToDateTimeString();
        jsonData2["EndTime"] = (JsonData) workFlowDelegation2.EndTime.ToDateTimeString();
        jsonData2["Note"] = (JsonData) workFlowDelegation2.Note;
        jsonData2["Status"] = (JsonData) str4;
        JsonData jsonData7 = jsonData2;
        string index3 = "Edit";
        string str6 = "<a class=\"editlink\" href=\"javascript:edit('";
        id2 = workFlowDelegation2.ID;
        string str7 = id2.ToString();
        string str8 = "');\">编辑</a>";
        JsonData jsonData8 = (JsonData) (str6 + str7 + str8);
        jsonData7[index3] = jsonData8;
        jsonData1.Add((object) jsonData2);
      }
      return "{\"userdata\":{\"total\":" + (object) count + ",\"pagesize\":" + (object) pageSize + ",\"pagenumber\":" + (object) pageNumber + "},\"rows\":" + jsonData1.ToJson(true) + "}";
    }

    public ActionResult Edit()
    {
      return this.Edit((FormCollection) null);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(FormCollection collection)
    {
      RoadFlow.Platform.WorkFlowDelegation workFlowDelegation1 = new RoadFlow.Platform.WorkFlowDelegation();
      RoadFlow.Data.Model.WorkFlowDelegation model = (RoadFlow.Data.Model.WorkFlowDelegation) null;
      string str1 = this.Request.QueryString["id"];
      string empty1 = string.Empty;
      string empty2 = string.Empty;
      string empty3 = string.Empty;
      string empty4 = string.Empty;
      string empty5 = string.Empty;
      string empty6 = string.Empty;
      bool flag = "1" == this.Request.QueryString["isoneself"];
      Guid test;
      Guid? nullable1;
      if (str1.IsGuid(out test))
      {
        model = workFlowDelegation1.Get(test);
        if (model != null)
        {
          nullable1 = model.FlowID;
          empty5 = nullable1.ToString();
        }
      }
      string oldXML = model.Serialize();
      if (collection != null)
      {
        string id1 = this.Request.Form["UserID"];
        string id2 = this.Request.Form["ToUserID"];
        string str2 = this.Request.Form["StartTime"];
        string str3 = this.Request.Form["EndTime"];
        empty5 = this.Request.Form["FlowID"];
        string str4 = this.Request.Form["Note"];
        int num = !str1.IsGuid() ? 1 : 0;
        if (model == null)
        {
          model = new RoadFlow.Data.Model.WorkFlowDelegation();
          model.ID = Guid.NewGuid();
        }
        model.UserID = flag ? RoadFlow.Platform.Users.CurrentUserID : RoadFlow.Platform.Users.RemovePrefix(id1).ToGuid();
        model.EndTime = str3.ToDateTime();
        if (empty5.IsGuid())
        {
          model.FlowID = new Guid?(empty5.ToGuid());
        }
        else
        {
          RoadFlow.Data.Model.WorkFlowDelegation workFlowDelegation2 = model;
          nullable1 = new Guid?();
          Guid? nullable2 = nullable1;
          workFlowDelegation2.FlowID = nullable2;
        }
        model.Note = str4.IsNullOrEmpty() ? (string) null : str4;
        model.StartTime = str2.ToDateTime();
        model.ToUserID = RoadFlow.Platform.Users.RemovePrefix(id2).ToGuid();
        model.WriteTime = DateTimeNew.Now;
        if (num != 0)
        {
          workFlowDelegation1.Add(model);
          RoadFlow.Platform.Log.Add("添加了工作委托", model.Serialize(), RoadFlow.Platform.Log.Types.流程相关, "", "", (RoadFlow.Data.Model.Users) null);
        }
        else
        {
          workFlowDelegation1.Update(model);
          RoadFlow.Platform.Log.Add("修改了工作委托", "", RoadFlow.Platform.Log.Types.流程相关, oldXML, model.Serialize(), (RoadFlow.Data.Model.Users) null);
        }
        workFlowDelegation1.RefreshCache();
        // ISSUE: reference to a compiler-generated field
        if (WorkFlowDelegationController.\u003C\u003Eo__4.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          WorkFlowDelegationController.\u003C\u003Eo__4.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Script", typeof (WorkFlowDelegationController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = WorkFlowDelegationController.\u003C\u003Eo__4.\u003C\u003Ep__0.Target((CallSite) WorkFlowDelegationController.\u003C\u003Eo__4.\u003C\u003Ep__0, this.ViewBag, "alert('保存成功!');new RoadUI.Window().getOpenerWindow().query();new RoadUI.Window().close();");
      }
      // ISSUE: reference to a compiler-generated field
      if (WorkFlowDelegationController.\u003C\u003Eo__4.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        WorkFlowDelegationController.\u003C\u003Eo__4.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "FlowOptions", typeof (WorkFlowDelegationController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = WorkFlowDelegationController.\u003C\u003Eo__4.\u003C\u003Ep__1.Target((CallSite) WorkFlowDelegationController.\u003C\u003Eo__4.\u003C\u003Ep__1, this.ViewBag, new RoadFlow.Platform.WorkFlow().GetOptions(empty5));
      RoadFlow.Data.Model.WorkFlowDelegation workFlowDelegation3;
      if (model != null)
      {
        workFlowDelegation3 = model;
      }
      else
      {
        workFlowDelegation3 = new RoadFlow.Data.Model.WorkFlowDelegation();
        workFlowDelegation3.UserID = RoadFlow.Platform.Users.CurrentUserID;
      }
      return (ActionResult) this.View((object) workFlowDelegation3);
    }
  }
}
