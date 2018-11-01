using RoadFlow.Data.Model;
using RoadFlow.Platform;
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
			return View();
		}

		[MyAttribute(CheckApp = false, CheckLogin = false, CheckUrl = false)]
		public ActionResult Login()
		{
			return View();
		}

		[HttpPost]
		[MyAttribute(CheckApp = false, CheckLogin = false, CheckUrl = false)]
		public string ValidateLogin()
		{
			string text = base.Request.Form["Account"];
			string text2 = base.Request.Form["Password"];
			if (text.IsNullOrEmpty() || text2.IsNullOrEmpty())
			{
				return "{\"id\":\"\",\"status\":0,\"msg\":\"帐号或密码不能为空\"}";
			}
			RoadFlow.Platform.Users users = new RoadFlow.Platform.Users();
			RoadFlow.Data.Model.Users byAccount = users.GetByAccount(text.Trim());
			if (byAccount == null || string.Compare(byAccount.Password, users.GetUserEncryptionPassword(byAccount.ID.ToString(), text2.Trim()), false) != 0)
			{
				return "{\"id\":\"\",\"status\":0,\"msg\":\"帐号或密码错误\"}";
			}
			if (byAccount.Status == 1)
			{
				return "{\"id\":\"\",\"status\":0,\"msg\":\"帐号已被冻结\"}";
			}
			base.Session[0.ToString()] = byAccount.ID;
			base.Session[7.ToString()] = base.Url.Content("~/");
			base.Session[1.ToString()] = byAccount.Name;
			base.Response.Cookies.Add(new HttpCookie(0.ToString(), byAccount.ID.ToString())
			{
				Expires = MyController.CurrentDateTime.AddDays(7.0)
			});
			RoadFlow.Platform.Log.Add("用户登录成功-test(帐号:" + text + ")", "", RoadFlow.Platform.Log.Types.用户登录);
			return "{\"id\":\"" + byAccount.ID.ToString() + "\",\"token\":\"" + RoadFlow.Utility.Config.GetTokenByUserId(byAccount.ID) + "\",\"status\":1,\"msg\":\"用户登录成功\"}";
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[MyAttribute(CheckApp = false, CheckLogin = false, CheckUrl = false)]
		public string CheckLogin()
		{
			string name = 5.ToString();
			string name2 = 4.ToString();
			string text = base.Request.Form["Account"];
			string text2 = base.Request.Form["Password"];
			string text3 = base.Request.Form["VCode"];
			string b = base.Request.Form["Force"];
			string str = "(帐号:" + text + " 密码:" + text2 + " 验证码:" + text3 + ")";
			if (text.IsNullOrEmpty() || text2.IsNullOrEmpty())
			{
				RoadFlow.Platform.Log.Add("用户登录失败(帐号或密码为空)" + str, "", RoadFlow.Platform.Log.Types.用户登录);
				return "{\"status\":0,\"msg\":\"帐号或密码不能为空!\"}";
			}
			if (base.Session[name] != null && "1" == base.Session[name].ToString() && (base.Session[name2] == null || string.Compare(base.Session[name2].ToString(), text3.Trim1(), true) != 0))
			{
				RoadFlow.Platform.Log.Add("用户登录失败(验证码错误)" + str, "", RoadFlow.Platform.Log.Types.用户登录);
				return "{\"status\":0,\"msg\":\"验证码错误!\"}";
			}
			RoadFlow.Platform.Users users = new RoadFlow.Platform.Users();
			RoadFlow.Data.Model.Users byAccount = users.GetByAccount(text.Trim());
			if (byAccount == null || string.Compare(byAccount.Password, users.GetUserEncryptionPassword(byAccount.ID.ToString(), text2.Trim()), false) != 0)
			{
				base.Session[name] = "1";
				RoadFlow.Platform.Log.Add("用户登录失败(帐号或密码错误)" + str, "", RoadFlow.Platform.Log.Types.用户登录);
				return "{\"status\":0,\"msg\":\"帐号或密码错误!\"}";
			}
			if (byAccount.Status == 1)
			{
				base.Session[name] = "1";
				RoadFlow.Platform.Log.Add("用户登录失败(帐号已被冻结)" + str, "", RoadFlow.Platform.Log.Types.用户登录);
				return "{\"status\":0,\"msg\":\"帐号已被冻结!\"}";
			}
			RoadFlow.Platform.OnlineUsers onlineUsers = new RoadFlow.Platform.OnlineUsers();
			RoadFlow.Data.Model.OnlineUsers onlineUsers2 = onlineUsers.Get(byAccount.ID);
			if (onlineUsers2 != null && "1" != b)
			{
				string iP = onlineUsers2.IP;
				base.Session.Remove(name);
				return "{\"status\":2,\"msg\":\"当前帐号已经在" + iP + "登录,您要强行登录吗?\"}";
			}
			Guid guid = Guid.NewGuid();
			base.Session[0.ToString()] = byAccount.ID;
			base.Session[2.ToString()] = guid;
			base.Session[7.ToString()] = base.Url.Content("~/");
			base.Session[1.ToString()] = byAccount.Name;
			base.Response.Cookies.Add(new HttpCookie(0.ToString(), byAccount.ID.ToString())
			{
				Expires = MyController.CurrentDateTime.AddDays(7.0)
			});
			onlineUsers.Add(byAccount, guid);
			base.Session.Remove(name);
			RoadFlow.Platform.Log.Add("用户登录成功(帐号:" + text + ")", "", RoadFlow.Platform.Log.Types.用户登录);
			return "{\"status\":1,\"msg\":\"成功!\"}";
		}

		[MyAttribute(CheckApp = false, CheckLogin = false)]
		public void VCode()
		{
			string code;
			MemoryStream validateImg = Tools.GetValidateImg(out code, base.Url.Content("~/Images/vcodebg.png"));
			System.Web.HttpContext.Current.Session[4.ToString()] = code;
			base.Response.ClearContent();
			base.Response.ContentType = "image/gif";
			base.Response.BinaryWrite(validateImg.ToArray());
		}

		[MyAttribute(CheckApp = false, CheckLogin = false, CheckUrl = false)]
		public ActionResult Quit()
		{
			new RoadFlow.Platform.OnlineUsers().Remove(RoadFlow.Platform.Users.CurrentUserID);
			base.Session.RemoveAll();
			string name = 0.ToString();
			base.Response.Cookies[name].Expires = DateTime.Now.AddDays(-1.0);
			base.Response.Cookies[name].Value = "";
			return Redirect("~/Login");
		}
	}
}
