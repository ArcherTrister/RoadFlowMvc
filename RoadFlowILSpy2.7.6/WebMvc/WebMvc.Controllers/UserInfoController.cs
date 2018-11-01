using RoadFlow.Data.Model;
using RoadFlow.Platform;
using RoadFlow.Utility;
using System;
using System.IO;
using System.Transactions;
using System.Web.Mvc;
using WebMvc.Common;

namespace WebMvc.Controllers
{
	public class UserInfoController : MyController
	{
		public ActionResult Index()
		{
			return View();
		}

		[MyAttribute(CheckApp = false)]
		public ActionResult EditUserInfo()
		{
			return EditUserInfo(null);
		}

		[HttpPost]
		[MyAttribute(CheckApp = false)]
		public ActionResult EditUserInfo(FormCollection collection)
		{
			RoadFlow.Platform.Users users = new RoadFlow.Platform.Users();
			RoadFlow.Data.Model.Users users2 = null;
			Guid currentUserID = RoadFlow.Platform.Users.CurrentUserID;
			users2 = users.Get(currentUserID);
			if (collection != null)
			{
				string tel = base.Request.Form["Tel"];
				string mobile = base.Request.Form["MobilePhone"];
				string weiXin = base.Request.Form["WeiXin"];
				string email = base.Request.Form["Email"];
				string qQ = base.Request.Form["QQ"];
				string otherTel = base.Request.Form["OtherTel"];
				string note = base.Request.Form["Note"];
				users2.Tel = tel;
				users2.Mobile = mobile;
				users2.WeiXin = weiXin;
				users2.Email = email;
				users2.QQ = qQ;
				users2.OtherTel = otherTel;
				users2.Note = note;
				if (false)
				{
					users.Add(users2);
				}
				else
				{
					users.Update(users2);
				}
				base.ViewBag.script = "alert('保存成功!');window.location=window.location;";
			}
			return View(users2);
		}

		[HttpPost]
		[MyAttribute(CheckApp = false)]
		public string SaveUserHead()
		{
			string str = base.Request.Form["x"];
			string str2 = base.Request.Form["y"];
			string text3 = base.Request.Form["x2"];
			string text4 = base.Request.Form["y2"];
			string str3 = base.Request.Form["w"];
			string str4 = base.Request.Form["h"];
			string text = (base.Request.Form["img"] ?? "").DesDecrypt();
			Guid currentUserID = RoadFlow.Platform.Users.CurrentUserID;
			if (!text.IsNullOrEmpty() && System.IO.File.Exists(text))
			{
				try
				{
					string text2 = ImgHelper.CutAvatar(text, WebMvc.Common.Tools.BaseUrl + "/Content/UserHeads/" + currentUserID + ".jpg", str.ToInt(), str2.ToInt(), str3.ToInt(), str4.ToInt());
					if (!text2.IsNullOrEmpty())
					{
						RoadFlow.Platform.Users users = new RoadFlow.Platform.Users();
						RoadFlow.Data.Model.Users users2 = users.Get(currentUserID);
						if (users2 != null)
						{
							users2.HeadImg = text2;
							users.Update(users2);
						}
						return "保存成功!";
					}
					return "保存失败!";
				}
				catch
				{
					return "保存失败!";
				}
			}
			return "文件不存在!";
		}

		[MyAttribute(CheckApp = false)]
		public ActionResult ShortcutSet()
		{
			return ShortcutSet(null);
		}

		[HttpPost]
		[MyAttribute(CheckApp = false)]
		public ActionResult ShortcutSet(FormCollection collection)
		{
			RoadFlow.Platform.UserShortcut userShortcut = new RoadFlow.Platform.UserShortcut();
			if (collection != null)
			{
				if (!base.Request.Form["issort"].IsNullOrEmpty())
				{
					string[] array = (base.Request.Form["sort"] ?? "").Split(',');
					for (int i = 0; i < array.Length; i++)
					{
						RoadFlow.Data.Model.UserShortcut userShortcut2 = userShortcut.Get(array[i].ToGuid());
						if (userShortcut2 != null)
						{
							userShortcut2.Sort = i;
							userShortcut.Update(userShortcut2);
						}
					}
					base.ViewBag.script = "alert('排序保存成功!');window.location=window.location;";
				}
				else
				{
					Guid currentUserID = RoadFlow.Platform.Users.CurrentUserID;
					string text = base.Request.Form["menuid"] ?? "";
					using (TransactionScope transactionScope = new TransactionScope())
					{
						userShortcut.DeleteByUserID(currentUserID);
						int num = 0;
						string[] array2 = text.Split(',');
						foreach (string str in array2)
						{
							if (str.IsGuid())
							{
								RoadFlow.Data.Model.UserShortcut userShortcut3 = new RoadFlow.Data.Model.UserShortcut();
								userShortcut3.ID = Guid.NewGuid();
								userShortcut3.MenuID = str.ToGuid();
								userShortcut3.Sort = num++;
								userShortcut3.UserID = currentUserID;
								userShortcut.Add(userShortcut3);
							}
						}
						transactionScope.Complete();
						base.ViewBag.script = "alert('保存成功!');window.location=window.location;";
					}
				}
				userShortcut.ClearCache();
			}
			return View();
		}

		public ActionResult EditUserHeader()
		{
			return View();
		}
	}
}
