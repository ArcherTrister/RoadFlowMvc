// Decompiled with JetBrains decompiler
// Type: WebMvc.Controllers.WorkCalendarController
// Assembly: WebMvc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 43FD7615-6DC3-49FB-B263-7F7CC91AFA77
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\WebMvc.dll

using Microsoft.CSharp.RuntimeBinder;
using RoadFlow.Cache.IO;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Transactions;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
  public class WorkCalendarController : MyController
  {
    public ActionResult Index()
    {
      return this.Index((FormCollection) null);
    }

    [HttpPost]
    public ActionResult Index(FormCollection collection)
    {
      RoadFlow.Data.MSSQL.WorkCalendar workCalendar = new RoadFlow.Data.MSSQL.WorkCalendar();
      int year = this.Request.Form["DropDownList1"].IsNullOrEmpty() ? DateTimeNew.Now.Year : this.Request.Form["DropDownList1"].ToInt();
      if (!this.Request.Form["saveBut"].IsNullOrEmpty())
      {
        string contents = this.Request.Form["workdate"] ?? "";
        string str1 = this.Request.Form["year1"];
        using (TransactionScope transactionScope = new TransactionScope())
        {
          workCalendar.Delete(str1.ToInt());
          foreach (string str2 in ((IEnumerable<string>) contents.Split(new char[1]{ ',' }, StringSplitOptions.RemoveEmptyEntries)).Distinct<string>())
          {
            if (str2.IsDateTime())
              workCalendar.Add(new RoadFlow.Data.Model.WorkCalendar()
              {
                WorkDate = str2.ToDateTime()
              });
          }
          transactionScope.Complete();
        }
        Opation.Remove("WorkCalendar_" + str1);
        RoadFlow.Platform.Log.Add("设置了工作日历", contents, RoadFlow.Platform.Log.Types.系统管理, "", "", (RoadFlow.Data.Model.Users) null);
        // ISSUE: reference to a compiler-generated field
        if (WorkCalendarController.\u003C\u003Eo__1.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          WorkCalendarController.\u003C\u003Eo__1.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "script", typeof (WorkCalendarController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = WorkCalendarController.\u003C\u003Eo__1.\u003C\u003Ep__0.Target((CallSite) WorkCalendarController.\u003C\u003Eo__1.\u003C\u003Ep__0, this.ViewBag, "alert('保存成功!')");
      }
      StringBuilder stringBuilder = new StringBuilder();
      for (int index = 2016; index < 2099; ++index)
        stringBuilder.Append("<option value='" + (object) index + "'" + (index == year ? (object) "selected='selected'" : (object) "") + ">" + (object) index + "</option>");
      List<RoadFlow.Data.Model.WorkCalendar> all = workCalendar.GetAll(year);
      // ISSUE: reference to a compiler-generated field
      if (WorkCalendarController.\u003C\u003Eo__1.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        WorkCalendarController.\u003C\u003Eo__1.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, StringBuilder, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "options", typeof (WorkCalendarController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = WorkCalendarController.\u003C\u003Eo__1.\u003C\u003Ep__1.Target((CallSite) WorkCalendarController.\u003C\u003Eo__1.\u003C\u003Ep__1, this.ViewBag, stringBuilder);
      // ISSUE: reference to a compiler-generated field
      if (WorkCalendarController.\u003C\u003Eo__1.\u003C\u003Ep__2 == null)
      {
        // ISSUE: reference to a compiler-generated field
        WorkCalendarController.\u003C\u003Eo__1.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "year", typeof (WorkCalendarController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = WorkCalendarController.\u003C\u003Eo__1.\u003C\u003Ep__2.Target((CallSite) WorkCalendarController.\u003C\u003Eo__1.\u003C\u003Ep__2, this.ViewBag, year);
      return (ActionResult) this.View((object) all);
    }
  }
}
