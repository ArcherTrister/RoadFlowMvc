// Decompiled with JetBrains decompiler
// Type: WebMvc.Controllers.UserInfoController
// Assembly: WebMvc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 43FD7615-6DC3-49FB-B263-7F7CC91AFA77
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\WebMvc.dll

using Microsoft.CSharp.RuntimeBinder;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Transactions;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
  public class UserInfoController : MyController
  {
    public ActionResult Index()
    {
      return (ActionResult) this.View();
    }

    [MyAttribute(CheckApp = false)]
    public ActionResult EditUserInfo()
    {
      return this.EditUserInfo((FormCollection) null);
    }

    [HttpPost]
    [MyAttribute(CheckApp = false)]
    public ActionResult EditUserInfo(FormCollection collection)
    {
      RoadFlow.Platform.Users users = new RoadFlow.Platform.Users();
      Guid currentUserId = RoadFlow.Platform.Users.CurrentUserID;
      RoadFlow.Data.Model.Users model = users.Get(currentUserId);
      if (collection != null)
      {
        string str1 = this.Request.Form["Tel"];
        string str2 = this.Request.Form["MobilePhone"];
        string str3 = this.Request.Form["WeiXin"];
        string str4 = this.Request.Form["Email"];
        string str5 = this.Request.Form["QQ"];
        string str6 = this.Request.Form["OtherTel"];
        string str7 = this.Request.Form["Note"];
        int num = 0;
        model.Tel = str1;
        model.Mobile = str2;
        model.WeiXin = str3;
        model.Email = str4;
        model.QQ = str5;
        model.OtherTel = str6;
        model.Note = str7;
        if (num != 0)
          users.Add(model);
        else
          users.Update(model);
        // ISSUE: reference to a compiler-generated field
        if (UserInfoController.\u003C\u003Eo__2.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          UserInfoController.\u003C\u003Eo__2.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "script", typeof (UserInfoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = UserInfoController.\u003C\u003Eo__2.\u003C\u003Ep__0.Target((CallSite) UserInfoController.\u003C\u003Eo__2.\u003C\u003Ep__0, this.ViewBag, "alert('保存成功!');window.location=window.location;");
      }
      return (ActionResult) this.View((object) model);
    }

    [HttpPost]
    [MyAttribute(CheckApp = false)]
    public string SaveUserHead()
    {
      string str1 = this.Request.Form["x"];
      string str2 = this.Request.Form["y"];
      string str3 = this.Request.Form["x2"];
      string str4 = this.Request.Form["y2"];
      string str5 = this.Request.Form["w"];
      string str6 = this.Request.Form["h"];
      string str7 = (this.Request.Form["img"] ?? "").DesDecrypt();
      Guid currentUserId = RoadFlow.Platform.Users.CurrentUserID;
      if (!str7.IsNullOrEmpty())
      {
        if (File.Exists(str7))
        {
          try
          {
            string str8 = ImgHelper.CutAvatar(str7, WebMvc.Common.Tools.BaseUrl + "/Content/UserHeads/" + (object) currentUserId + ".jpg", str1.ToInt(), str2.ToInt(), str5.ToInt(), str6.ToInt());
            if (str8.IsNullOrEmpty())
              return "保存失败!";
            RoadFlow.Platform.Users users = new RoadFlow.Platform.Users();
            RoadFlow.Data.Model.Users model = users.Get(currentUserId);
            if (model != null)
            {
              model.HeadImg = str8;
              users.Update(model);
            }
            return "保存成功!";
          }
          catch
          {
            return "保存失败!";
          }
        }
      }
      return "文件不存在!";
    }

    [MyAttribute(CheckApp = false)]
    public ActionResult ShortcutSet()
    {
      return this.ShortcutSet((FormCollection) null);
    }

    [HttpPost]
    [MyAttribute(CheckApp = false)]
    public ActionResult ShortcutSet(FormCollection collection)
    {
      RoadFlow.Platform.UserShortcut userShortcut = new RoadFlow.Platform.UserShortcut();
      if (collection != null)
      {
        if (!this.Request.Form["issort"].IsNullOrEmpty())
        {
          string[] strArray = (this.Request.Form["sort"] ?? "").Split(',');
          for (int index = 0; index < strArray.Length; ++index)
          {
            RoadFlow.Data.Model.UserShortcut model = userShortcut.Get(strArray[index].ToGuid());
            if (model != null)
            {
              model.Sort = index;
              userShortcut.Update(model);
            }
          }
          // ISSUE: reference to a compiler-generated field
          if (UserInfoController.\u003C\u003Eo__5.\u003C\u003Ep__0 == null)
          {
            // ISSUE: reference to a compiler-generated field
            UserInfoController.\u003C\u003Eo__5.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "script", typeof (UserInfoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj = UserInfoController.\u003C\u003Eo__5.\u003C\u003Ep__0.Target((CallSite) UserInfoController.\u003C\u003Eo__5.\u003C\u003Ep__0, this.ViewBag, "alert('排序保存成功!');window.location=window.location;");
        }
        else
        {
          Guid currentUserId = RoadFlow.Platform.Users.CurrentUserID;
          string str1 = this.Request.Form["menuid"] ?? "";
          using (TransactionScope transactionScope = new TransactionScope())
          {
            userShortcut.DeleteByUserID(currentUserId);
            int num = 0;
            string str2 = str1;
            char[] chArray = new char[1]{ ',' };
            foreach (string str3 in str2.Split(chArray))
            {
              if (str3.IsGuid())
                userShortcut.Add(new RoadFlow.Data.Model.UserShortcut()
                {
                  ID = Guid.NewGuid(),
                  MenuID = str3.ToGuid(),
                  Sort = num++,
                  UserID = currentUserId
                });
            }
            transactionScope.Complete();
            // ISSUE: reference to a compiler-generated field
            if (UserInfoController.\u003C\u003Eo__5.\u003C\u003Ep__1 == null)
            {
              // ISSUE: reference to a compiler-generated field
              UserInfoController.\u003C\u003Eo__5.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "script", typeof (UserInfoController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            object obj = UserInfoController.\u003C\u003Eo__5.\u003C\u003Ep__1.Target((CallSite) UserInfoController.\u003C\u003Eo__5.\u003C\u003Ep__1, this.ViewBag, "alert('保存成功!');window.location=window.location;");
          }
        }
        userShortcut.ClearCache();
      }
      return (ActionResult) this.View();
    }

    public ActionResult EditUserHeader()
    {
      return (ActionResult) this.View();
    }
  }
}
