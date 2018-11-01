// Decompiled with JetBrains decompiler
// Type: WebMvc.Controllers.LogController
// Assembly: WebMvc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 43FD7615-6DC3-49FB-B263-7F7CC91AFA77
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\WebMvc.dll

using Microsoft.CSharp.RuntimeBinder;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
  public class LogController : MyController
  {
    public ActionResult Index()
    {
      RoadFlow.Platform.Log log = new RoadFlow.Platform.Log();
      // ISSUE: reference to a compiler-generated field
      if (LogController.\u003C\u003Eo__0.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        LogController.\u003C\u003Eo__0.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "TypeOptions", typeof (LogController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = LogController.\u003C\u003Eo__0.\u003C\u003Ep__0.Target((CallSite) LogController.\u003C\u003Eo__0.\u003C\u003Ep__0, this.ViewBag, log.GetTypeOptions(""));
      string str = string.Format("&appid={0}&tabid={1}", (object) this.Request.QueryString["appid"], (object) this.Request.QueryString["tabid"]);
      // ISSUE: reference to a compiler-generated field
      if (LogController.\u003C\u003Eo__0.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        LogController.\u003C\u003Eo__0.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Query", typeof (LogController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = LogController.\u003C\u003Eo__0.\u003C\u003Ep__1.Target((CallSite) LogController.\u003C\u003Eo__0.\u003C\u003Ep__1, this.ViewBag, str);
      return (ActionResult) this.View();
    }

    public ActionResult Detail()
    {
      string str = this.Request.QueryString["id"];
      if (str.IsGuid())
        return (ActionResult) this.View((object) new RoadFlow.Platform.Log().Get(str.ToGuid()));
      return (ActionResult) this.View((object) new RoadFlow.Data.Model.Log());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public string Query()
    {
      string title = this.Request.Form["Title"];
      string userID = this.Request.Form["UserID"];
      string type = this.Request.Form["Type"];
      string date1 = this.Request.Form["Date1"];
      string date2 = this.Request.Form["Date2"];
      string str1 = this.Request.Form["sidx"];
      string str2 = this.Request.Form["sord"];
      int pageSize = Tools.GetPageSize();
      int pageNumber = Tools.GetPageNumber();
      string order = (str1.IsNullOrEmpty() ? "WriteTime" : str1) + " " + (str2.IsNullOrEmpty() ? "asc" : str2);
      long count;
      DataTable pagerData = new RoadFlow.Platform.Log().GetPagerData(out count, pageSize, pageNumber, title, type, date1, date2, userID, order);
      List<object> objectList = new List<object>();
      foreach (DataRow row in (InternalDataCollectionBase) pagerData.Rows)
        objectList.Add((object) new
        {
          ID = row["ID"].ToString(),
          Title = row["Title"].ToString(),
          Type = row["Type"].ToString(),
          WriteTime = row["WriteTime"].DateFormat("yyyy-MM-dd HH:mm:ss"),
          UserName = row["UserName"].ToString(),
          IPAddress = row["IPAddress"].ToString(),
          Opation = ("<a class=\"viewlink\" href=\"javascript:void(0);\" onclick=\"detail('" + row["ID"].ToString() + "');return false;\">查看</a>")
        });
      return "{\"userdata\":{\"total\":" + (object) count + ",\"pagesize\":" + (object) pageSize + ",\"pagenumber\":" + (object) pageNumber + "},\"rows\":" + objectList.ToJsonString() + "}";
    }
  }
}
