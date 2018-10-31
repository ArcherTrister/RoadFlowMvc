// Decompiled with JetBrains decompiler
// Type: WebMvc.Controllers.LoginController
// Assembly: WebMvc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 43FD7615-6DC3-49FB-B263-7F7CC91AFA77
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\WebMvc.dll

using RoadFlow.Utility;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
  public class LoginController : MyController
  {
    [MyAttribute(CheckApp = false, CheckLogin = false, CheckUrl = false)]
    public ActionResult Index()
    {
      return (ActionResult) this.View();
    }

    [MyAttribute(CheckApp = false, CheckLogin = false, CheckUrl = false)]
    public ActionResult Login()
    {
      return (ActionResult) this.View();
    }

    [HttpPost]
    [MyAttribute(CheckApp = false, CheckLogin = false, CheckUrl = false)]
    public string ValidateLogin()
    {
      string str1 = this.Request.Form["Account"];
      string str2 = this.Request.Form["Password"];
      if (str1.IsNullOrEmpty() || str2.IsNullOrEmpty())
        return "{\"id\":\"\",\"status\":0,\"msg\":\"帐号或密码不能为空\"}";
      RoadFlow.Platform.Users users = new RoadFlow.Platform.Users();
      RoadFlow.Data.Model.Users byAccount = users.GetByAccount(str1.Trim());
      if (byAccount == null || string.Compare(byAccount.Password, users.GetUserEncryptionPassword(byAccount.ID.ToString(), str2.Trim()), false) != 0)
        return "{\"id\":\"\",\"status\":0,\"msg\":\"帐号或密码错误\"}";
      if (byAccount.Status == 1)
        return "{\"id\":\"\",\"status\":0,\"msg\":\"帐号已被冻结\"}";
      this.Session[Keys.SessionKeys.UserID.ToString()] = (object) byAccount.ID;
      this.Session[Keys.SessionKeys.BaseUrl.ToString()] = (object) this.Url.Content("~/");
      this.Session[Keys.SessionKeys.UserName.ToString()] = (object) byAccount.Name;
      this.Response.Cookies.Add(new HttpCookie(Keys.SessionKeys.UserID.ToString(), byAccount.ID.ToString())
      {
        Expires = MyController.CurrentDateTime.AddDays(7.0)
      });
      RoadFlow.Platform.Log.Add("用户登录成功-test(帐号:" + str1 + ")", "", RoadFlow.Platform.Log.Types.用户登录, "", "", (RoadFlow.Data.Model.Users) null);
      return "{\"id\":\"" + byAccount.ID.ToString() + "\",\"token\":\"" + RoadFlow.Utility.Config.GetTokenByUserId(byAccount.ID) + "\",\"status\":1,\"msg\":\"用户登录成功\"}";
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [MyAttribute(CheckApp = false, CheckLogin = false, CheckUrl = false)]
    public string CheckLogin()
    {
      string name1 = Keys.SessionKeys.IsValidateCode.ToString();
      string index1 = Keys.SessionKeys.ValidateCode.ToString();
      string str1 = this.Request.Form["Account"];
      string str2 = this.Request.Form["Password"];
      string str3 = this.Request.Form["VCode"];
      string str4 = this.Request.Form["Force"];
      string str5 = "(帐号:" + str1 + " 密码:" + str2 + " 验证码:" + str3 + ")";
      if (str1.IsNullOrEmpty() || str2.IsNullOrEmpty())
      {
        RoadFlow.Platform.Log.Add("用户登录失败(帐号或密码为空)" + str5, "", RoadFlow.Platform.Log.Types.用户登录, "", "", (RoadFlow.Data.Model.Users) null);
        return "{\"status\":0,\"msg\":\"帐号或密码不能为空!\"}";
      }
      if (this.Session[name1] != null && "1" == this.Session[name1].ToString() && (this.Session[index1] == null || string.Compare(this.Session[index1].ToString(), str3.Trim1(), true) != 0))
      {
        RoadFlow.Platform.Log.Add("用户登录失败(验证码错误)" + str5, "", RoadFlow.Platform.Log.Types.用户登录, "", "", (RoadFlow.Data.Model.Users) null);
        return "{\"status\":0,\"msg\":\"验证码错误!\"}";
      }
      RoadFlow.Platform.Users users = new RoadFlow.Platform.Users();
      RoadFlow.Data.Model.Users byAccount = users.GetByAccount(str1.Trim());
      if (byAccount == null || string.Compare(byAccount.Password, users.GetUserEncryptionPassword(byAccount.ID.ToString(), str2.Trim()), false) != 0)
      {
        this.Session[name1] = (object) "1";
        RoadFlow.Platform.Log.Add("用户登录失败(帐号或密码错误)" + str5, "", RoadFlow.Platform.Log.Types.用户登录, "", "", (RoadFlow.Data.Model.Users) null);
        return "{\"status\":0,\"msg\":\"帐号或密码错误!\"}";
      }
      if (byAccount.Status == 1)
      {
        this.Session[name1] = (object) "1";
        RoadFlow.Platform.Log.Add("用户登录失败(帐号已被冻结)" + str5, "", RoadFlow.Platform.Log.Types.用户登录, "", "", (RoadFlow.Data.Model.Users) null);
        return "{\"status\":0,\"msg\":\"帐号已被冻结!\"}";
      }
      RoadFlow.Platform.OnlineUsers onlineUsers1 = new RoadFlow.Platform.OnlineUsers();
      RoadFlow.Data.Model.OnlineUsers onlineUsers2 = onlineUsers1.Get(byAccount.ID);
      if (onlineUsers2 != null && "1" != str4)
      {
        string ip = onlineUsers2.IP;
        this.Session.Remove(name1);
        return "{\"status\":2,\"msg\":\"当前帐号已经在" + ip + "登录,您要强行登录吗?\"}";
      }
      Guid uniqueID = Guid.NewGuid();
      this.Session[Keys.SessionKeys.UserID.ToString()] = (object) byAccount.ID;
      HttpSessionStateBase session1 = this.Session;
      Keys.SessionKeys sessionKeys = Keys.SessionKeys.UserUniqueID;
      string index2 = sessionKeys.ToString();
      // ISSUE: variable of a boxed type
      __Boxed<Guid> local = (ValueType) uniqueID;
      session1[index2] = (object) local;
      HttpSessionStateBase session2 = this.Session;
      sessionKeys = Keys.SessionKeys.BaseUrl;
      string index3 = sessionKeys.ToString();
      string str6 = this.Url.Content("~/");
      session2[index3] = (object) str6;
      HttpSessionStateBase session3 = this.Session;
      sessionKeys = Keys.SessionKeys.UserName;
      string index4 = sessionKeys.ToString();
      string name2 = byAccount.Name;
      session3[index4] = (object) name2;
      HttpCookieCollection cookies = this.Response.Cookies;
      sessionKeys = Keys.SessionKeys.UserID;
      cookies.Add(new HttpCookie(sessionKeys.ToString(), byAccount.ID.ToString())
      {
        Expires = MyController.CurrentDateTime.AddDays(7.0)
      });
      onlineUsers1.Add(byAccount, uniqueID);
      this.Session.Remove(name1);
      RoadFlow.Platform.Log.Add("用户登录成功(帐号:" + str1 + ")", "", RoadFlow.Platform.Log.Types.用户登录, "", "", (RoadFlow.Data.Model.Users) null);
      return "{\"status\":1,\"msg\":\"成功!\"}";
    }

    [MyAttribute(CheckApp = false, CheckLogin = false)]
    public void VCode()
    {
      string code;
      MemoryStream validateImg = Tools.GetValidateImg(out code, this.Url.Content("~/Images/vcodebg.png"));
      HttpContext.Current.Session[Keys.SessionKeys.ValidateCode.ToString()] = (object) code;
      this.Response.ClearContent();
      this.Response.ContentType = "image/gif";
      this.Response.BinaryWrite(validateImg.ToArray());
    }

    [MyAttribute(CheckApp = false, CheckLogin = false, CheckUrl = false)]
    public ActionResult Quit()
    {
      new RoadFlow.Platform.OnlineUsers().Remove(RoadFlow.Platform.Users.CurrentUserID);
      this.Session.RemoveAll();
      string index = Keys.SessionKeys.UserID.ToString();
      this.Response.Cookies[index].Expires = DateTime.Now.AddDays(-1.0);
      this.Response.Cookies[index].Value = "";
      return (ActionResult) this.Redirect("~/Login");
    }
  }
}
