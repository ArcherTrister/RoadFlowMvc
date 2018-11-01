using RoadFlow.Data.Model;
using RoadFlow.Platform;
using RoadFlow.Utility;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
	public class LogController : MyController
	{
		public ActionResult Index()
		{
			RoadFlow.Platform.Log log = new RoadFlow.Platform.Log();
			base.ViewBag.TypeOptions = log.GetTypeOptions();
			string text = string.Format("&appid={0}&tabid={1}", base.Request.QueryString["appid"], base.Request.QueryString["tabid"]);
			base.ViewBag.Query = text;
			return View();
		}

		public ActionResult Detail()
		{
			string str = base.Request.QueryString["id"];
			if (str.IsGuid())
			{
				return View(new RoadFlow.Platform.Log().Get(str.ToGuid()));
			}
			return View(new RoadFlow.Data.Model.Log());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public string Query()
		{
			string title = base.Request.Form["Title"];
			string userID = base.Request.Form["UserID"];
			string type = base.Request.Form["Type"];
			string date = base.Request.Form["Date1"];
			string date2 = base.Request.Form["Date2"];
			string text = base.Request.Form["sidx"];
			string text2 = base.Request.Form["sord"];
			int pageSize = Tools.GetPageSize();
			int pageNumber = Tools.GetPageNumber();
			string order = (text.IsNullOrEmpty() ? "WriteTime" : text) + " " + (text2.IsNullOrEmpty() ? "asc" : text2);
			long count;
			DataTable pagerData = new RoadFlow.Platform.Log().GetPagerData(out count, pageSize, pageNumber, title, type, date, date2, userID, order);
			List<object> list = new List<object>();
			foreach (DataRow row in pagerData.Rows)
			{
				list.Add(new
				{
					ID = row["ID"].ToString(),
					Title = row["Title"].ToString(),
					Type = row["Type"].ToString(),
					WriteTime = row["WriteTime"].DateFormat("yyyy-MM-dd HH:mm:ss"),
					UserName = row["UserName"].ToString(),
					IPAddress = row["IPAddress"].ToString(),
					Opation = "<a class=\"viewlink\" href=\"javascript:void(0);\" onclick=\"detail('" + row["ID"].ToString() + "');return false;\">查看</a>"
				});
			}
			return "{\"userdata\":{\"total\":" + count + ",\"pagesize\":" + pageSize + ",\"pagenumber\":" + pageNumber + "},\"rows\":" + list.ToJsonString() + "}";
		}
	}
}
