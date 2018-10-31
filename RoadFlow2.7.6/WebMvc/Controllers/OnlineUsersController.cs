// Decompiled with JetBrains decompiler
// Type: WebMvc.Controllers.OnlineUsersController
// Assembly: WebMvc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 43FD7615-6DC3-49FB-B263-7F7CC91AFA77
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\WebMvc.dll

using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
  public class OnlineUsersController : MyController
  {
    [MyAttribute(CheckApp = false)]
    public ActionResult Index()
    {
      return this.query((FormCollection) null);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [MyAttribute(CheckApp = false)]
    public ActionResult Index(FormCollection collection)
    {
      RoadFlow.Platform.OnlineUsers onlineUsers = new RoadFlow.Platform.OnlineUsers();
      if (!this.Request.Form["ClearAll"].IsNullOrEmpty())
        onlineUsers.RemoveAll();
      if (!this.Request.Form["ClearSelect"].IsNullOrEmpty())
      {
        string str1 = this.Request.Form["checkbox_app"];
        if (!str1.IsNullOrEmpty())
        {
          string str2 = str1;
          char[] chArray = new char[1]{ ',' };
          foreach (string str3 in str2.Split(chArray))
          {
            Guid test;
            if (str3.IsGuid(out test))
              onlineUsers.Remove(test);
          }
        }
      }
      return this.query(collection);
    }

    [MyAttribute(CheckApp = false)]
    private ActionResult query(FormCollection collection)
    {
      RoadFlow.Platform.OnlineUsers onlineUsers = new RoadFlow.Platform.OnlineUsers();
      string name = string.Empty;
      name = collection == null ? this.Request.QueryString["Name"] : this.Request.Form["Name"];
      // ISSUE: reference to a compiler-generated field
      if (OnlineUsersController.\u003C\u003Eo__2.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        OnlineUsersController.\u003C\u003Eo__2.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Name", typeof (OnlineUsersController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj = OnlineUsersController.\u003C\u003Eo__2.\u003C\u003Ep__0.Target((CallSite) OnlineUsersController.\u003C\u003Eo__2.\u003C\u003Ep__0, this.ViewBag, name);
      List<RoadFlow.Data.Model.OnlineUsers> source = onlineUsers.GetAll();
      if (!name.IsNullOrEmpty())
        source = source.Where<RoadFlow.Data.Model.OnlineUsers>((Func<RoadFlow.Data.Model.OnlineUsers, bool>) (p => p.UserName.IndexOf(name) >= 0)).ToList<RoadFlow.Data.Model.OnlineUsers>();
      return (ActionResult) this.View((object) source);
    }
  }
}
