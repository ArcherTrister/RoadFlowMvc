// Decompiled with JetBrains decompiler
// Type: WebMvc.Controllers.WorkFlowButtonsController
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
  public class WorkFlowButtonsController : MyController
  {
    public ActionResult Index()
    {
      string empty = string.Empty;
      // ISSUE: reference to a compiler-generated field
      if (WorkFlowButtonsController.\u003C\u003Eo__0.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        WorkFlowButtonsController.\u003C\u003Eo__0.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Query1", typeof (WorkFlowButtonsController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = WorkFlowButtonsController.\u003C\u003Eo__0.\u003C\u003Ep__0.Target((CallSite) WorkFlowButtonsController.\u003C\u003Eo__0.\u003C\u003Ep__0, this.ViewBag, string.Format("&appid={0}&tabid={1}", (object) this.Request.QueryString["appid"], (object) this.Request.QueryString["tabid"]));
      List<RoadFlow.Data.Model.WorkFlowButtons> all = new RoadFlow.Platform.WorkFlowButtons().GetAll(false);
      JsonData jsonData = new JsonData();
      foreach (RoadFlow.Data.Model.WorkFlowButtons workFlowButtons in (IEnumerable<RoadFlow.Data.Model.WorkFlowButtons>) all.OrderBy<RoadFlow.Data.Model.WorkFlowButtons, int>((Func<RoadFlow.Data.Model.WorkFlowButtons, int>) (p => p.Sort)).ThenBy<RoadFlow.Data.Model.WorkFlowButtons, string>((Func<RoadFlow.Data.Model.WorkFlowButtons, string>) (p => p.Title)))
        jsonData.Add((object) new JsonData()
        {
          ["id"] = (JsonData) workFlowButtons.ID.ToString(),
          ["Title"] = (JsonData) workFlowButtons.Title,
          ["Ico"] = (workFlowButtons.Ico.IsNullOrEmpty() ? (JsonData) "" : (!workFlowButtons.Ico.IsFontIco() ? (JsonData) ("<img src=\"" + this.Url.Content("~" + workFlowButtons.Ico) + "\" alt=\"\" />") : (JsonData) ("<i class=\"fa " + workFlowButtons.Ico + "\" style=\"font-size:14px;\"></i>"))),
          ["Note"] = (JsonData) workFlowButtons.Note,
          ["Sort"] = (JsonData) workFlowButtons.Sort.ToString(),
          ["Opation"] = (JsonData) ("<a class=\"editlink\" href=\"javascript:edit('" + workFlowButtons.ID.ToString() + "');\">编辑</a>")
        });
      // ISSUE: reference to a compiler-generated field
      if (WorkFlowButtonsController.\u003C\u003Eo__0.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        WorkFlowButtonsController.\u003C\u003Eo__0.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "list", typeof (WorkFlowButtonsController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = WorkFlowButtonsController.\u003C\u003Eo__0.\u003C\u003Ep__1.Target((CallSite) WorkFlowButtonsController.\u003C\u003Eo__0.\u003C\u003Ep__1, this.ViewBag, jsonData.ToJson(true));
      return (ActionResult) this.View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public string Delete()
    {
      RoadFlow.Platform.WorkFlowButtons workFlowButtons1 = new RoadFlow.Platform.WorkFlowButtons();
      string str1 = this.Request.Form["ids"];
      char[] chArray = new char[1]{ ',' };
      foreach (string str2 in str1.Split(chArray))
      {
        Guid test;
        if (str2.IsGuid(out test))
        {
          RoadFlow.Data.Model.WorkFlowButtons workFlowButtons2 = workFlowButtons1.Get(test, false);
          if (workFlowButtons2 != null)
          {
            workFlowButtons1.Delete(test);
            RoadFlow.Platform.Log.Add("删除了流程按钮", workFlowButtons2.Serialize(), RoadFlow.Platform.Log.Types.流程相关, "", "", (RoadFlow.Data.Model.Users) null);
          }
        }
      }
      workFlowButtons1.ClearCache();
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
      RoadFlow.Platform.WorkFlowButtons workFlowButtons = new RoadFlow.Platform.WorkFlowButtons();
      RoadFlow.Data.Model.WorkFlowButtons model = (RoadFlow.Data.Model.WorkFlowButtons) null;
      string str1 = this.Request.QueryString["id"];
      string empty1 = string.Empty;
      string empty2 = string.Empty;
      string empty3 = string.Empty;
      string empty4 = string.Empty;
      string empty5 = string.Empty;
      Guid test;
      if (str1.IsGuid(out test))
        model = workFlowButtons.Get(test, false);
      string oldXML = model.Serialize();
      if (collection != null)
      {
        string str2 = this.Request.Form["Title"];
        string str3 = this.Request.Form["Ico"];
        string str4 = this.Request.Form["Script"];
        string str5 = this.Request.Form["Note"];
        string str6 = this.Request.Form["Sort"];
        int num = !str1.IsGuid() ? 1 : 0;
        if (model == null)
        {
          model = new RoadFlow.Data.Model.WorkFlowButtons();
          model.ID = Guid.NewGuid();
          model.Sort = workFlowButtons.GetMaxSort();
        }
        model.Ico = str3.IsNullOrEmpty() ? (string) null : str3.Trim();
        model.Note = str5.IsNullOrEmpty() ? (string) null : str5.Trim();
        model.Script = str4.IsNullOrEmpty() ? (string) null : str4;
        model.Title = str2.Trim();
        model.Sort = !str6.IsInt() ? workFlowButtons.GetMaxSort() : str6.ToInt();
        if (num != 0)
        {
          workFlowButtons.Add(model);
          RoadFlow.Platform.Log.Add("添加了流程按钮", model.Serialize(), RoadFlow.Platform.Log.Types.流程相关, "", "", (RoadFlow.Data.Model.Users) null);
        }
        else
        {
          workFlowButtons.Update(model);
          RoadFlow.Platform.Log.Add("修改了流程按钮", "", RoadFlow.Platform.Log.Types.流程相关, oldXML, model.Serialize(), (RoadFlow.Data.Model.Users) null);
        }
        workFlowButtons.ClearCache();
        // ISSUE: reference to a compiler-generated field
        if (WorkFlowButtonsController.\u003C\u003Eo__3.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          WorkFlowButtonsController.\u003C\u003Eo__3.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Script", typeof (WorkFlowButtonsController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = WorkFlowButtonsController.\u003C\u003Eo__3.\u003C\u003Ep__0.Target((CallSite) WorkFlowButtonsController.\u003C\u003Eo__3.\u003C\u003Ep__0, this.ViewBag, "new RoadUI.Window().reloadOpener();alert('保存成功!');new RoadUI.Window().close();");
      }
      if (model == null)
      {
        model = new RoadFlow.Data.Model.WorkFlowButtons();
        model.Sort = workFlowButtons.GetMaxSort();
      }
      return (ActionResult) this.View((object) model);
    }
  }
}
