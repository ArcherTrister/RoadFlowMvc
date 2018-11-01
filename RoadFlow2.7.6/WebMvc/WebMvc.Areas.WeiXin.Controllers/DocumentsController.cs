using LitJson;
using RoadFlow.Platform;
using RoadFlow.Platform.WeiXin;
using System;
using System.Data;
using System.Web.Mvc;

namespace WebMvc.Areas.WeiXin.Controllers
{
	public class DocumentsController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Search()
		{
			return Search(null);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Search(FormCollection coll)
		{
			string text = string.Empty;
			if (coll != null)
			{
				text = base.Request.Form["searchkey"];
			}
			base.ViewBag.searchText = text;
			return View();
		}

		public ActionResult List()
		{
			return List(null);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult List(FormCollection coll)
		{
			string text = string.Empty;
			if (coll != null)
			{
				text = base.Request.Form["searchkey"];
			}
			base.ViewBag.searchText = text;
			return View();
		}

		public string GetDocs()
		{
			string str = base.Request.QueryString["pagenumber"];
			string str2 = base.Request.QueryString["pagesize"];
			string title = base.Request.QueryString["SearchTitle"];
			string dirID = base.Request.QueryString["dirid"];
			Guid currentUserID = RoadFlow.Platform.WeiXin.Organize.CurrentUserID;
			long count;
			DataTable list = new Documents().GetList(out count, str2.ToInt(), str.ToInt(), dirID, currentUserID.ToString(), title);
			JsonData jsonData = new JsonData();
			if (list.Rows.Count == 0)
			{
				return "[]";
			}
			foreach (DataRow row in list.Rows)
			{
				JsonData jsonData2 = new JsonData();
				jsonData2["id"] = row["ID"].ToString();
				jsonData2["title"] = row["Title"].ToString();
				jsonData2["writetime"] = row["WriteTime"].ToString().ToDateTime().ToDateTimeString();
				jsonData2["writeuser"] = row["WriteUserName"].ToString();
				jsonData.Add(jsonData2);
			}
			return jsonData.ToJson();
		}
	}
}
