// Decompiled with JetBrains decompiler
// Type: WebMvc.MyController
// Assembly: WebMvc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 43FD7615-6DC3-49FB-B263-7F7CC91AFA77
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\WebMvc.dll

using RoadFlow.Utility;
using System;
using System.Web;
using System.Web.Mvc;

namespace WebMvc
{
  public class MyController : Controller
  {
    protected override void OnActionExecuting(ActionExecutingContext filterContext)
    {
      base.OnActionExecuting(filterContext);
      object[] customAttributes = filterContext.ActionDescriptor.GetCustomAttributes(typeof (MyAttributeAttribute), false);
      bool flag1 = true;
      bool flag2 = true;
      bool flag3 = true;
      if (customAttributes.Length == 1)
      {
        MyAttributeAttribute attributeAttribute = (MyAttributeAttribute) customAttributes[0];
        flag1 = attributeAttribute.CheckLogin;
        flag2 = attributeAttribute.CheckApp;
        flag3 = attributeAttribute.CheckUrl;
      }
      if (flag3 && !WebMvc.Common.Tools.CheckReferrer(false))
      {
        filterContext.Result = (ActionResult) this.Content("地址验证错误");
      }
      else
      {
        string msg1;
        if (flag1 && !this.CheckLogin(out msg1))
        {
          if (filterContext.HttpContext.Request.IsAjaxRequest())
          {
            filterContext.Result = (ActionResult) this.Content("{\"loginstatus\":-1, \"url\":\"\"}");
          }
          else
          {
            string str = HttpContext.Current.Request.Url.PathAndQuery.UrlEncode();
            filterContext.Result = (ActionResult) this.Content("<script>" + (msg1.IsNullOrEmpty() ? "" : string.Format("alert('{0}');", (object) msg1)) + (string.Compare(filterContext.Controller.ToString(), "WebMvc.Controllers.HomeController", true) == 0 ? "top.location='" + this.Url.Content("~/Login") + "'" : "top.lastURL='" + str + "';top.currentWindow=window;top.login();") + "</script>", "text/html");
          }
        }
        else
        {
          string msg2;
          if (!flag2 || WebMvc.Common.Tools.CheckApp(out msg2, ""))
            return;
          filterContext.Result = (ActionResult) this.Content("权限验证错误");
        }
      }
    }

    protected virtual bool CheckLogin(out string msg)
    {
      return WebMvc.Common.Tools.CheckLogin(out msg);
    }

    public static Guid CurrentUserID
    {
      get
      {
        return RoadFlow.Platform.Users.CurrentUserID;
      }
    }

    public static RoadFlow.Data.Model.Users CurrentUser
    {
      get
      {
        return RoadFlow.Platform.Users.CurrentUser;
      }
    }

    public static string CurrentUserName
    {
      get
      {
        return RoadFlow.Platform.Users.CurrentUserName;
      }
    }

    public static RoadFlow.Data.Model.Organize CurrentUserDept
    {
      get
      {
        return RoadFlow.Platform.Users.CurrentDept;
      }
    }

    public static Guid CurrentUserDeptID
    {
      get
      {
        return RoadFlow.Platform.Users.CurrentDeptID;
      }
    }

    public static string CurrentUserDeptName
    {
      get
      {
        return RoadFlow.Platform.Users.CurrentDeptName;
      }
    }

    public static RoadFlow.Data.Model.Organize CurrentUserUnit
    {
      get
      {
        return RoadFlow.Platform.Users.CurrentUnit;
      }
    }

    public static Guid CurrentUserUnitID
    {
      get
      {
        return RoadFlow.Platform.Users.CurrentUnitID;
      }
    }

    public static string CurrentUserUnitName
    {
      get
      {
        return RoadFlow.Platform.Users.CurrentUnitName;
      }
    }

    public static DateTime CurrentDateTime
    {
      get
      {
        return DateTimeNew.Now;
      }
    }
  }
}
