using LitJson;
using RoadFlow.Data.Model;
using RoadFlow.Platform;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
	public class HomeController : MyController
	{
		[MyAttribute(CheckApp = false, CheckUrl = false)]
		public ActionResult Index()
		{
			RoadFlow.Data.Model.Users currentUser = MyController.CurrentUser;
			base.ViewBag.UserName = ((currentUser == null) ? "" : currentUser.Name);
			base.ViewBag.DateTime = MyController.CurrentDateTime.ToDateWeekString();
			List<RoadFlow.Data.Model.ShortMessage> allNoReadByUserID = new RoadFlow.Platform.ShortMessage().GetAllNoReadByUserID(currentUser.ID);
			if (allNoReadByUserID.Count > 0)
			{
				JsonData jsonData = new JsonData();
				string empty = string.Empty;
				RoadFlow.Data.Model.ShortMessage shortMessage = (from p in allNoReadByUserID
				orderby p.SendTime descending
				select p).FirstOrDefault();
				empty = (shortMessage.LinkUrl.IsNullOrEmpty() ? shortMessage.Contents.RemoveHTML() : ("<a class=\"blue1\" href=\"" + shortMessage.LinkUrl + "\">" + shortMessage.Contents.RemoveHTML() + "</a>"));
				jsonData["title"] = shortMessage.Title;
				jsonData["contents"] = empty;
				jsonData["count"] = allNoReadByUserID.Count;
				base.ViewBag.NoReadMsgJson = jsonData.ToJson();
			}
			string text = base.Url.Content("~/Content/UserHeads/default.jpg");
			if (!currentUser.HeadImg.IsNullOrEmpty() && System.IO.File.Exists(base.Server.MapPath(base.Url.Content("~" + currentUser.HeadImg))))
			{
				text = base.Url.Content("~" + currentUser.HeadImg);
			}
			base.ViewBag.HeadImg = text;
			return View();
		}

		[MyAttribute(CheckApp = false)]
		public ActionResult Home()
		{
			return View();
		}

		[MyAttribute(CheckApp = false)]
		public string Menu()
		{
			string str = base.Request.QueryString["userid"];
			Guid guid = str.IsGuid() ? str.ToGuid() : RoadFlow.Platform.Users.CurrentUserID;
			bool showSource = "1" == base.Request.QueryString["showsource"];
			if (guid.IsEmptyGuid())
			{
				return "[]";
			}
			return new RoadFlow.Platform.Menu().GetUserMenuJsonString(guid, base.Url.Content("~/").TrimEnd('/'), showSource);
		}

		[MyAttribute(CheckApp = false)]
		public string MenuRefresh()
		{
			string text = base.Request.QueryString["userid"];
			string str = base.Request.QueryString["refreshid"];
			bool showSource = "1" == base.Request.QueryString["showsource"];
			Guid currentUserID = RoadFlow.Platform.Users.CurrentUserID;
			Guid test;
			if (!str.IsGuid(out test))
			{
				return "[]";
			}
			if (!test.IsEmptyGuid())
			{
				return new RoadFlow.Platform.Menu().GetUserMenuRefreshJsonString(currentUserID, test, base.Url.Content("~/").TrimEnd('/'), showSource);
			}
			return "[]";
		}

		[MyAttribute(CheckApp = false)]
		public string MenuRefresh1()
		{
			string str = base.Request.QueryString["refreshid"];
			string isrefresh = base.Request.QueryString["isrefresh1"];
			Guid currentUserID = RoadFlow.Platform.Users.CurrentUserID;
			Guid test;
			if (!str.IsGuid(out test))
			{
				return "";
			}
			if (!test.IsEmptyGuid())
			{
				return new RoadFlow.Platform.Menu().GetUserMenuChilds(currentUserID, test, base.Url.Content("~/").TrimEnd('/'), isrefresh);
			}
			return "";
		}

		public ActionResult SetList()
		{
			RoadFlow.Platform.HomeItems homeItems = new RoadFlow.Platform.HomeItems();
			base.ViewBag.TypeOptions = homeItems.getTypeOptions();
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public string Query()
		{
			RoadFlow.Platform.HomeItems homeItems = new RoadFlow.Platform.HomeItems();
			RoadFlow.Platform.Organize organize = new RoadFlow.Platform.Organize();
			new List<RoadFlow.Data.Model.HomeItems>();
			string name = base.Request.Form["Name1"];
			string title = base.Request.Form["Title1"];
			string type = base.Request.Form["Type"];
			string text = base.Request.Form["sidx"];
			string text2 = base.Request.Form["sord"];
			int pageSize = Tools.GetPageSize();
			int pageNumber = Tools.GetPageNumber();
			string order = (text.IsNullOrEmpty() ? "Type" : text) + " " + (text2.IsNullOrEmpty() ? "asc" : text2);
			long count;
			List<RoadFlow.Data.Model.HomeItems> list = homeItems.GetList(out count, pageSize, pageNumber, name, title, type, order);
			JsonData jsonData = new JsonData();
			foreach (RoadFlow.Data.Model.HomeItems item in list)
			{
				StringBuilder stringBuilder = new StringBuilder();
				if (!item.Ico.IsNullOrEmpty())
				{
					if (item.Ico.IsFontIco())
					{
						stringBuilder.Append("<i class='fa " + item.Ico + "' style='font-size:14px;vertical-align:middle;margin-right:3px;'></i>");
					}
					else
					{
						stringBuilder.Append("<img src='" + base.Url.Content("~" + item.Ico) + "' style='vertical-align:middle;margin-right:3px;'/>");
					}
				}
				stringBuilder.Append(item.Title);
				JsonData jsonData2 = new JsonData();
				jsonData2["id"] = item.ID.ToString();
				jsonData2["Name"] = item.Name;
				jsonData2["Title"] = stringBuilder.ToString();
				jsonData2["Type"] = homeItems.GetTypeTitle(item.Type);
				jsonData2["DataSourceType"] = homeItems.GetDataSourceTitle(item.DataSourceType);
				jsonData2["UseOrganizes"] = organize.GetNames(item.UseOrganizes);
				jsonData2["Note"] = item.Note;
				jsonData2["Opation"] = "<a class=\"editlink\" href=\"javascript:void(0);\" onclick=\"edit('" + item.ID + "');return false;\">编辑</a>";
				jsonData.Add(jsonData2);
			}
			return "{\"userdata\":{\"total\":" + count + ",\"pagesize\":" + pageSize + ",\"pagenumber\":" + pageNumber + "},\"rows\":" + jsonData.ToJson() + "}";
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public string Delete()
		{
			RoadFlow.Platform.HomeItems homeItems = new RoadFlow.Platform.HomeItems();
			string[] array = (base.Request.Form["ids"] ?? "").Split(',');
			foreach (string text in array)
			{
				homeItems.Delete(text.ToGuid());
				RoadFlow.Platform.Log.Add("删除了首页模块设置", text);
			}
			homeItems.ClearCache();
			return "删除成功!";
		}

		public ActionResult SetAdd()
		{
			return SetAdd(null);
		}

		[HttpPost]
		public ActionResult SetAdd(FormCollection collection)
		{
			RoadFlow.Platform.HomeItems homeItems = new RoadFlow.Platform.HomeItems();
			RoadFlow.Data.Model.HomeItems homeItems2 = null;
			string str = base.Request.QueryString["id"];
			if (str.IsGuid())
			{
				homeItems2 = homeItems.Get(str.ToGuid());
			}
			if (collection != null)
			{
				string name = base.Request.Form["Name1"];
				string title = base.Request.Form["Title1"];
				string str2 = base.Request.Form["Type"];
				string str3 = base.Request.Form["DataSourceType"];
				string dataSource = base.Request.Form["DataSource"];
				string ico = base.Request.Form["Ico"];
				string bgColor = base.Request.Form["BgColor"];
				string useOrganizes = base.Request.Form["UseOrganizes"];
				string str4 = base.Request.Form["DBConnID"];
				string linkURL = base.Request.Form["LinkURL"];
				string note = base.Request.Form["Note"];
				string str5 = base.Request.Form["Sort"];
				bool flag = false;
				if (homeItems2 == null)
				{
					homeItems2 = new RoadFlow.Data.Model.HomeItems();
					homeItems2.ID = Guid.NewGuid();
					flag = true;
				}
				homeItems2.Title = title;
				homeItems2.Name = name;
				homeItems2.Type = str2.ToInt();
				homeItems2.DataSourceType = str3.ToInt();
				homeItems2.DataSource = dataSource;
				homeItems2.Ico = ico;
				homeItems2.BgColor = bgColor;
				homeItems2.UseOrganizes = useOrganizes;
				homeItems2.Sort = (str5.IsInt() ? str5.ToInt() : homeItems.GetMaxSort(homeItems2.Type));
				if (str4.IsGuid())
				{
					homeItems2.DBConnID = str4.ToGuid();
				}
				else
				{
					homeItems2.DBConnID = null;
				}
				homeItems2.LinkURL = linkURL;
				homeItems2.Note = note;
				if (flag)
				{
					homeItems.Add(homeItems2);
				}
				else
				{
					homeItems.Update(homeItems2);
				}
				homeItems.ClearCache();
				base.ViewBag.script = "alert('保存成功!');window.location='SetList" + base.Request.Url.Query + "';";
			}
			base.ViewBag.TypeOptions = homeItems.getTypeOptions((homeItems2 == null) ? "" : homeItems2.Type.ToString());
			base.ViewBag.DataSourceTypeOptions = homeItems.getDataSourceOptions((homeItems2 == null) ? "" : homeItems2.DataSourceType.ToString());
			base.ViewBag.DBConnIDOptions = new RoadFlow.Platform.DBConnection().GetAllOptions((homeItems2 == null) ? "" : homeItems2.DBConnID.ToString());
			if (homeItems2 == null)
			{
				homeItems2 = new RoadFlow.Data.Model.HomeItems();
			}
			return View(homeItems2);
		}
	}
}
