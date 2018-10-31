// Decompiled with JetBrains decompiler
// Type: WebMvc.Controllers.WorkFlowCommentsController
// Assembly: WebMvc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 43FD7615-6DC3-49FB-B263-7F7CC91AFA77
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\WebMvc.dll

using LitJson;
using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
  public class WorkFlowCommentsController : MyController
  {
    public ActionResult Index()
    {
      return this.Index((FormCollection) null);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Index(FormCollection collection)
    {
      RoadFlow.Platform.WorkFlowComment workFlowComment1 = new RoadFlow.Platform.WorkFlowComment();
      RoadFlow.Platform.Organize organize = new RoadFlow.Platform.Organize();
      IEnumerable<RoadFlow.Data.Model.WorkFlowComment> source = (IEnumerable<RoadFlow.Data.Model.WorkFlowComment>) workFlowComment1.GetAll();
      if ("1" == this.Request.QueryString["isoneself"])
        source = source.Where<RoadFlow.Data.Model.WorkFlowComment>((Func<RoadFlow.Data.Model.WorkFlowComment, bool>) (p => p.MemberID == "u_" + RoadFlow.Platform.Users.CurrentUserID.ToString()));
      JsonData jsonData = new JsonData();
      foreach (RoadFlow.Data.Model.WorkFlowComment workFlowComment2 in (IEnumerable<RoadFlow.Data.Model.WorkFlowComment>) source.OrderBy<RoadFlow.Data.Model.WorkFlowComment, int>((Func<RoadFlow.Data.Model.WorkFlowComment, int>) (p => p.Type)).ThenBy<RoadFlow.Data.Model.WorkFlowComment, int>((Func<RoadFlow.Data.Model.WorkFlowComment, int>) (p => p.Sort)))
        jsonData.Add((object) new JsonData()
        {
          ["id"] = (JsonData) workFlowComment2.ID.ToString(),
          ["Comment"] = (JsonData) workFlowComment2.Comment,
          ["MemberID"] = (JsonData) (workFlowComment2.MemberID.IsNullOrEmpty() ? "所有人员" : organize.GetNames(workFlowComment2.MemberID, ",")),
          ["Type"] = (JsonData) (workFlowComment2.Type == 0 ? "管理员" : "个人"),
          ["Sort"] = (JsonData) workFlowComment2.Sort,
          ["Opation"] = (JsonData) ("<a class=\"editlink\" href=\"javascript:edit('" + workFlowComment2.ID.ToString() + "');\">编辑</a>")
        });
      // ISSUE: reference to a compiler-generated field
      if (WorkFlowCommentsController.\u003C\u003Eo__1.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        WorkFlowCommentsController.\u003C\u003Eo__1.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "list", typeof (WorkFlowCommentsController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj = WorkFlowCommentsController.\u003C\u003Eo__1.\u003C\u003Ep__0.Target((CallSite) WorkFlowCommentsController.\u003C\u003Eo__1.\u003C\u003Ep__0, this.ViewBag, jsonData.ToJson(true));
      return (ActionResult) this.View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public string Delete()
    {
      RoadFlow.Platform.WorkFlowComment workFlowComment1 = new RoadFlow.Platform.WorkFlowComment();
      string str1 = this.Request.Form["ids"];
      char[] chArray = new char[1]{ ',' };
      foreach (string str2 in str1.Split(chArray))
      {
        Guid test;
        if (str2.IsGuid(out test))
        {
          RoadFlow.Data.Model.WorkFlowComment workFlowComment2 = workFlowComment1.Get(test);
          if (workFlowComment2 != null)
          {
            workFlowComment1.Delete(test);
            RoadFlow.Platform.Log.Add("删除了流程意见", workFlowComment2.Serialize(), RoadFlow.Platform.Log.Types.流程相关, "", "", (RoadFlow.Data.Model.Users) null);
          }
        }
      }
      workFlowComment1.RefreshCache();
      return "删除成功!";
    }

    public ActionResult Edit()
    {
      return this.Edit((FormCollection) null);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(FormCollection collection)
    {
      RoadFlow.Platform.WorkFlowComment workFlowComment = new RoadFlow.Platform.WorkFlowComment();
      RoadFlow.Data.Model.WorkFlowComment model = (RoadFlow.Data.Model.WorkFlowComment) null;
      string str1 = this.Request.QueryString["id"];
      string str2 = string.Empty;
      string str3 = string.Empty;
      string empty = string.Empty;
      bool flag = "1" == this.Request.QueryString["isoneself"];
      Guid test;
      if (str1.IsGuid(out test))
      {
        model = workFlowComment.Get(test);
        str2 = model.MemberID;
        str3 = model.Comment;
        empty = model.Sort.ToString();
      }
      string oldXML = model.Serialize();
      if (collection != null)
      {
        string str4 = flag ? "u_" + RoadFlow.Platform.Users.CurrentUserID.ToString() : this.Request.Form["Member"];
        string str5 = this.Request.Form["Comment"];
        string str6 = this.Request.Form["Sort"];
        int num = !str1.IsGuid() ? 1 : 0;
        if (model == null)
        {
          model = new RoadFlow.Data.Model.WorkFlowComment();
          model.ID = Guid.NewGuid();
          model.Type = flag ? 1 : 0;
        }
        model.MemberID = str4.IsNullOrEmpty() ? "" : str4.Trim();
        model.Comment = str5.IsNullOrEmpty() ? "" : str5.Trim();
        model.Sort = str6.IsInt() ? str6.ToInt() : workFlowComment.GetManagerMaxSort();
        if (num != 0)
        {
          workFlowComment.Add(model);
          RoadFlow.Platform.Log.Add("添加了流程意见", model.Serialize(), RoadFlow.Platform.Log.Types.流程相关, "", "", (RoadFlow.Data.Model.Users) null);
        }
        else
        {
          workFlowComment.Update(model);
          RoadFlow.Platform.Log.Add("修改了流程意见", "", RoadFlow.Platform.Log.Types.流程相关, oldXML, model.Serialize(), (RoadFlow.Data.Model.Users) null);
        }
        workFlowComment.RefreshCache();
        // ISSUE: reference to a compiler-generated field
        if (WorkFlowCommentsController.\u003C\u003Eo__4.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          WorkFlowCommentsController.\u003C\u003Eo__4.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Script", typeof (WorkFlowCommentsController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = WorkFlowCommentsController.\u003C\u003Eo__4.\u003C\u003Ep__0.Target((CallSite) WorkFlowCommentsController.\u003C\u003Eo__4.\u003C\u003Ep__0, this.ViewBag, "new RoadUI.Window().reloadOpener();alert('保存成功!');");
      }
      if (model == null)
      {
        model = new RoadFlow.Data.Model.WorkFlowComment();
        model.Sort = workFlowComment.GetManagerMaxSort() + 5;
      }
      return (ActionResult) this.View((object) model);
    }
  }
}
