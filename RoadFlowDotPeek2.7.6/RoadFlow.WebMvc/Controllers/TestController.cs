// Decompiled with JetBrains decompiler
// Type: WebMvc.Controllers.TestController
// Assembly: WebMvc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 43FD7615-6DC3-49FB-B263-7F7CC91AFA77
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\WebMvc.dll

using Microsoft.CSharp.RuntimeBinder;
using RoadFlow.Data.MSSQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
  public class TestController : MyController
  {
    [MyAttribute(CheckApp = false, CheckLogin = false, CheckUrl = false)]
    public ActionResult Index()
    {
      return (ActionResult) this.View();
    }

    [MyAttribute(CheckApp = false, CheckUrl = false)]
    public ActionResult CustomForm()
    {
      return this.CustomForm((FormCollection) null);
    }

    [HttpPost]
    [MyAttribute(CheckApp = false, CheckUrl = false)]
    [ValidateAntiForgeryToken]
    public ActionResult CustomForm(FormCollection coll)
    {
      string str1 = this.Request.QueryString["instanceid"];
      if (coll != null)
      {
        string str2 = this.Request.Form["Title"];
        string str3 = this.Request.Form["Contents"];
        string empty = string.Empty;
        int num = new DBHelper().Execute(str1.IsNullOrEmpty() ? "insert into TempTest_CustomForm(Title,Contents) values(@Title,@Contents)" : "update TempTest_CustomForm set Title=@Title,Contents=@Contents where id=" + str1, new SqlParameter[2]{ new SqlParameter("@Title", (object) str2), new SqlParameter("@Contents", (object) str3) }, true);
        // ISSUE: reference to a compiler-generated field
        if (TestController.\u003C\u003Eo__2.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          TestController.\u003C\u003Eo__2.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "title1", typeof (TestController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj1 = TestController.\u003C\u003Eo__2.\u003C\u003Ep__0.Target((CallSite) TestController.\u003C\u003Eo__2.\u003C\u003Ep__0, this.ViewBag, str2);
        // ISSUE: reference to a compiler-generated field
        if (TestController.\u003C\u003Eo__2.\u003C\u003Ep__1 == null)
        {
          // ISSUE: reference to a compiler-generated field
          TestController.\u003C\u003Eo__2.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "contents", typeof (TestController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj2 = TestController.\u003C\u003Eo__2.\u003C\u003Ep__1.Target((CallSite) TestController.\u003C\u003Eo__2.\u003C\u003Ep__1, this.ViewBag, str3);
        // ISSUE: reference to a compiler-generated field
        if (TestController.\u003C\u003Eo__2.\u003C\u003Ep__2 == null)
        {
          // ISSUE: reference to a compiler-generated field
          TestController.\u003C\u003Eo__2.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "script", typeof (TestController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj3 = TestController.\u003C\u003Eo__2.\u003C\u003Ep__2.Target((CallSite) TestController.\u003C\u003Eo__2.\u003C\u003Ep__2, this.ViewBag, "$('#instanceid',parent.document).val('" + (object) num + "');$('#customformtitle',parent.document).val('" + str2 + "');parent.flowSaveAndSendIframe(true);");
      }
      else if (!str1.IsNullOrEmpty())
      {
        DataTable dataTable = new DBHelper().GetDataTable("select * from TempTest_CustomForm where id=" + str1);
        if (dataTable.Rows.Count > 0)
        {
          // ISSUE: reference to a compiler-generated field
          if (TestController.\u003C\u003Eo__2.\u003C\u003Ep__3 == null)
          {
            // ISSUE: reference to a compiler-generated field
            TestController.\u003C\u003Eo__2.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "title1", typeof (TestController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj1 = TestController.\u003C\u003Eo__2.\u003C\u003Ep__3.Target((CallSite) TestController.\u003C\u003Eo__2.\u003C\u003Ep__3, this.ViewBag, dataTable.Rows[0]["Title"].ToString());
          // ISSUE: reference to a compiler-generated field
          if (TestController.\u003C\u003Eo__2.\u003C\u003Ep__4 == null)
          {
            // ISSUE: reference to a compiler-generated field
            TestController.\u003C\u003Eo__2.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "contents", typeof (TestController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj2 = TestController.\u003C\u003Eo__2.\u003C\u003Ep__4.Target((CallSite) TestController.\u003C\u003Eo__2.\u003C\u003Ep__4, this.ViewBag, dataTable.Rows[0]["Contents"].ToString());
        }
      }
      return (ActionResult) this.View();
    }

    [MyAttribute(CheckApp = false, CheckUrl = false)]
    public ActionResult CustomForm1()
    {
      string str = this.Request.QueryString["instanceid"];
      if (!str.IsNullOrEmpty())
      {
        DataTable dataTable = new DBHelper().GetDataTable("select * from TempTest_CustomForm where id=" + str);
        if (dataTable.Rows.Count > 0)
        {
          // ISSUE: reference to a compiler-generated field
          if (TestController.\u003C\u003Eo__3.\u003C\u003Ep__0 == null)
          {
            // ISSUE: reference to a compiler-generated field
            TestController.\u003C\u003Eo__3.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "title1", typeof (TestController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj1 = TestController.\u003C\u003Eo__3.\u003C\u003Ep__0.Target((CallSite) TestController.\u003C\u003Eo__3.\u003C\u003Ep__0, this.ViewBag, dataTable.Rows[0]["Title"].ToString());
          // ISSUE: reference to a compiler-generated field
          if (TestController.\u003C\u003Eo__3.\u003C\u003Ep__1 == null)
          {
            // ISSUE: reference to a compiler-generated field
            TestController.\u003C\u003Eo__3.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "contents", typeof (TestController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj2 = TestController.\u003C\u003Eo__3.\u003C\u003Ep__1.Target((CallSite) TestController.\u003C\u003Eo__3.\u003C\u003Ep__1, this.ViewBag, dataTable.Rows[0]["Contents"].ToString());
        }
      }
      return (ActionResult) this.View();
    }

    [MyAttribute(CheckApp = false, CheckUrl = false)]
    public string saveCustomForm1()
    {
      string str1 = this.Request.QueryString["instanceid"];
      string str2 = this.Request.Form["Title"];
      string str3 = this.Request.Form["Contents"];
      string empty = string.Empty;
      return "{\"msg\":\"保存成功\",\"instanceid\":\"" + (object) new DBHelper().Execute(str1.IsNullOrEmpty() ? "insert into TempTest_CustomForm(Title,Contents) values(@Title,@Contents)" : "update TempTest_CustomForm set Title=@Title,Contents=@Contents where id=" + str1, new SqlParameter[2]{ new SqlParameter("@Title", (object) str2), new SqlParameter("@Contents", (object) str3) }, true) + "\"}";
    }
  }
}
