// Decompiled with JetBrains decompiler
// Type: WebMvc.Areas.WeiXin.Controllers.DocumentsController
// Assembly: WebMvc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 43FD7615-6DC3-49FB-B263-7F7CC91AFA77
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\WebMvc.dll

using LitJson;
using Microsoft.CSharp.RuntimeBinder;
using RoadFlow.Platform;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace WebMvc.Areas.WeiXin.Controllers
{
  public class DocumentsController : Controller
  {
    public ActionResult Index()
    {
      return (ActionResult) this.View();
    }

    public ActionResult Search()
    {
      return this.Search((FormCollection) null);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Search(FormCollection coll)
    {
      string empty = string.Empty;
      if (coll != null)
        empty = this.Request.Form["searchkey"];
      // ISSUE: reference to a compiler-generated field
      if (DocumentsController.\u003C\u003Eo__2.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        DocumentsController.\u003C\u003Eo__2.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "searchText", typeof (DocumentsController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj = DocumentsController.\u003C\u003Eo__2.\u003C\u003Ep__0.Target((CallSite) DocumentsController.\u003C\u003Eo__2.\u003C\u003Ep__0, this.ViewBag, empty);
      return (ActionResult) this.View();
    }

    public ActionResult List()
    {
      return this.List((FormCollection) null);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult List(FormCollection coll)
    {
      string empty = string.Empty;
      if (coll != null)
        empty = this.Request.Form["searchkey"];
      // ISSUE: reference to a compiler-generated field
      if (DocumentsController.\u003C\u003Eo__4.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        DocumentsController.\u003C\u003Eo__4.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "searchText", typeof (DocumentsController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj = DocumentsController.\u003C\u003Eo__4.\u003C\u003Ep__0.Target((CallSite) DocumentsController.\u003C\u003Eo__4.\u003C\u003Ep__0, this.ViewBag, empty);
      return (ActionResult) this.View();
    }

    public string GetDocs()
    {
      string str1 = this.Request.QueryString["pagenumber"];
      string str2 = this.Request.QueryString["pagesize"];
      string title = this.Request.QueryString["SearchTitle"];
      string dirID = this.Request.QueryString["dirid"];
      Guid currentUserId = RoadFlow.Platform.WeiXin.Organize.CurrentUserID;
      long count;
      DataTable list = new Documents().GetList(out count, str2.ToInt(), str1.ToInt(), dirID, currentUserId.ToString(), title, "", "", false, "");
      JsonData jsonData = new JsonData();
      if (list.Rows.Count == 0)
        return "[]";
      foreach (DataRow row in (InternalDataCollectionBase) list.Rows)
        jsonData.Add((object) new JsonData()
        {
          ["id"] = (JsonData) row["ID"].ToString(),
          ["title"] = (JsonData) row["Title"].ToString(),
          ["writetime"] = (JsonData) row["WriteTime"].ToString().ToDateTime().ToDateTimeString(),
          ["writeuser"] = (JsonData) row["WriteUserName"].ToString()
        });
      return jsonData.ToJson(true);
    }
  }
}
