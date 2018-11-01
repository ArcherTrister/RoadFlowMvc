using LitJson;
using RoadFlow.Data.Model;
using RoadFlow.Platform;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
	public class ShortMessageController : MyController
	{
		[MyAttribute(CheckApp = false)]
		public ActionResult Index()
		{
			return View();
		}

		[MyAttribute(CheckApp = false)]
		public ActionResult NoRead()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[MyAttribute(CheckApp = false)]
		public string QueryNoRead()
		{
			string title = base.Request.Form["Title1"];
			string contents = base.Request.Form["Contents"];
			string text = base.Request.Form["SenderID"];
			string date = base.Request.Form["Date1"];
			string date2 = base.Request.Form["Date2"];
			string text2 = base.Request.Form["sidx"];
			string text3 = base.Request.Form["sord"];
			int num = base.Request.Form["status"].ToInt(0);
			string receiveID = RoadFlow.Platform.Users.CurrentUserID.ToString();
			int[] status = new int[1];
			if (2 == num)
			{
				status = new int[2]
				{
					0,
					1
				};
				text = "'" + MyController.CurrentUserID.ToString() + "'";
				receiveID = "";
			}
			else if (1 == num)
			{
				status = new int[1]
				{
					1
				};
				text = Tools.GetSqlInString(new RoadFlow.Platform.Organize().GetAllUsersIdList(text).ToArray());
			}
			new List<RoadFlow.Data.Model.ShortMessage>();
			int pageSize = Tools.GetPageSize();
			int pageNumber = Tools.GetPageNumber();
			string order = (text2.IsNullOrEmpty() ? "SenderTime" : text2) + " " + (text3.IsNullOrEmpty() ? "asc" : text3);
			long count;
			List<RoadFlow.Data.Model.ShortMessage> list = new RoadFlow.Platform.ShortMessage().GetList(out count, status, pageSize, pageNumber, title, contents, text, date, date2, receiveID, order);
			JsonData jsonData = new JsonData();
			foreach (RoadFlow.Data.Model.ShortMessage item in list)
			{
				JsonData jsonData2 = new JsonData();
				jsonData2["id"] = item.ID.ToString();
				jsonData2["Title"] = "<a href=\"javascript:show('" + item.ID + "');\" class=\"blue1\">" + item.Title + "</a><input type=\"hidden\" id=\"status_" + item.ID.ToString() + "\" value=\"" + item.Status + "\"/>";
				jsonData2["Contents"] = Tools.RemoveHTML(item.Contents).CutString(100);
				jsonData2["SendUserName"] = item.SendUserName;
				jsonData2["SendTime"] = item.SendTime.ToDateTimeStringS();
				jsonData.Add(jsonData2);
			}
			return "{\"userdata\":{\"total\":" + count + ",\"pagesize\":" + pageSize + ",\"pagenumber\":" + pageNumber + "},\"rows\":" + jsonData.ToJson() + "}";
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[MyAttribute(CheckApp = false)]
		public string NoReadToRead()
		{
			string obj = base.Request.Form["ids"] ?? "";
			RoadFlow.Platform.ShortMessage shortMessage = new RoadFlow.Platform.ShortMessage();
			string[] array = obj.Split(',');
			foreach (string str in array)
			{
				if (str.IsGuid())
				{
					shortMessage.UpdateStatus(str.ToGuid());
				}
			}
			return "操作成功!";
		}

		[MyAttribute(CheckApp = false)]
		public void UpdateStatus()
		{
			string str = base.Request.QueryString["id"];
			if (str.IsGuid())
			{
				new RoadFlow.Platform.ShortMessage().UpdateStatus(str.ToGuid());
			}
		}

		[MyAttribute(CheckApp = false)]
		public ActionResult Send()
		{
			return Send(null);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[MyAttribute(CheckApp = false)]
		public ActionResult Send(FormCollection collection)
		{
			if (collection != null)
			{
				string text = base.Request.Form["Title1"];
				string text2 = base.Request.Form["Contents"];
				string text3 = base.Request.Form["ReceiveUserID"];
				string files = base.Request.Form["Files"];
				string b = base.Request.Form["sendtoseixin"];
				if (text.IsNullOrEmpty() || text2.IsNullOrEmpty() || text3.IsNullOrEmpty())
				{
					base.ViewBag.script = "alert('数据验证错误!')";
					return View();
				}
				List<RoadFlow.Data.Model.Users> allUsers = new RoadFlow.Platform.Organize().GetAllUsers(text3);
				StringBuilder stringBuilder = new StringBuilder();
				StringBuilder stringBuilder2 = new StringBuilder();
				RoadFlow.Data.Model.ShortMessage shortMessage = null;
				RoadFlow.Platform.ShortMessage shortMessage2 = new RoadFlow.Platform.ShortMessage();
				foreach (RoadFlow.Data.Model.Users item in allUsers)
				{
					RoadFlow.Data.Model.ShortMessage shortMessage3 = new RoadFlow.Data.Model.ShortMessage();
					shortMessage3.Contents = text2;
					shortMessage3.ID = Guid.NewGuid();
					shortMessage3.ReceiveUserID = item.ID;
					shortMessage3.ReceiveUserName = item.Name;
					shortMessage3.SendTime = DateTimeNew.Now;
					shortMessage3.SendUserID = RoadFlow.Platform.Users.CurrentUserID;
					shortMessage3.SendUserName = RoadFlow.Platform.Users.CurrentUserName;
					shortMessage3.Status = 0;
					shortMessage3.Title = text;
					shortMessage3.Type = 0;
					shortMessage3.Files = files;
					shortMessage2.Add(shortMessage3);
					RoadFlow.Platform.ShortMessage.SiganalR(item.ID, shortMessage3.ID.ToString(), text, text2.RemoveHTML());
					stringBuilder.Append(item.Name);
					stringBuilder.Append(",");
					stringBuilder2.Append(item.Account);
					stringBuilder2.Append('|');
					if (shortMessage == null)
					{
						shortMessage = shortMessage3;
					}
				}
				if ("1" == b && shortMessage != null && stringBuilder2.Length > 0)
				{
					shortMessage2.SendToWeiXin(shortMessage, stringBuilder2.ToString().TrimEnd('|'));
				}
				base.ViewBag.script = string.Format("alert('成功将消息发送给了：{0}!');window.location=window.location;", stringBuilder.ToString());
			}
			return View();
		}

		[MyAttribute(CheckApp = false, CheckLogin = false, CheckUrl = false)]
		public ActionResult Show()
		{
			return View();
		}

		[MyAttribute(CheckApp = false, CheckUrl = false)]
		public ActionResult Read()
		{
			return View();
		}

		[MyAttribute(CheckApp = false)]
		public ActionResult SendList()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[MyAttribute(CheckApp = false)]
		public string Delete()
		{
			string text = base.Request.Form["ids"] ?? "";
			RoadFlow.Platform.ShortMessage shortMessage = new RoadFlow.Platform.ShortMessage();
			if (text.IsNullOrEmpty())
			{
				return "没有选择要删除的消息!";
			}
			string[] array = text.Split(',');
			foreach (string str in array)
			{
				if (str.IsGuid())
				{
					RoadFlow.Data.Model.ShortMessage shortMessage2 = shortMessage.Get(str.ToGuid());
					if (shortMessage2 != null)
					{
						shortMessage.Delete(shortMessage2.ID);
						RoadFlow.Platform.Log.Add("删除了站内消息", shortMessage2.Serialize(), RoadFlow.Platform.Log.Types.信息管理);
					}
				}
			}
			return "操作成功!";
		}
	}
}
