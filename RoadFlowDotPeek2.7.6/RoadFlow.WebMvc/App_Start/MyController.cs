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

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            object[] customAttributes = filterContext.ActionDescriptor.GetCustomAttributes(typeof(MyAttributeAttribute), false);
            bool flag = true;
            bool flag2 = true;
            bool flag3 = true;
            if (customAttributes.Length == 1)
            {
                MyAttributeAttribute obj = (MyAttributeAttribute)customAttributes[0];
                flag = obj.CheckLogin;
                flag2 = obj.CheckApp;
                flag3 = obj.CheckUrl;
            }
            string msg;
            string msg2;
            if (flag3 && !WebMvc.Common.Tools.CheckReferrer(false))
            {
                filterContext.Result = Content("地址验证错误");
            }
            else if (flag && !CheckLogin(out msg))
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.Result = Content("{\"loginstatus\":-1, \"url\":\"\"}");
                }
                else
                {
                    string str = MyExtensions.UrlEncode(System.Web.HttpContext.Current.Request.Url.PathAndQuery);
                    filterContext.Result = Content("<script>" + (MyExtensions.IsNullOrEmpty(msg) ? "" : string.Format("alert('{0}');", msg)) + ((string.Compare(filterContext.Controller.ToString(), "WebMvc.Controllers.HomeController", true) == 0) ? ("top.location='" + base.Url.Content("~/Login") + "'") : ("top.lastURL='" + str + "';top.currentWindow=window;top.login();")) + "</script>", "text/html");
                }
            }
            else if (flag2 && !WebMvc.Common.Tools.CheckApp(out msg2))
            {
                filterContext.Result = Content("权限验证错误");
            }
        }

        protected virtual bool CheckLogin(out string msg)
        {
            return WebMvc.Common.Tools.CheckLogin(out msg);
        }
    }
}
