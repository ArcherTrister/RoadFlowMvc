using LitJson;
using RoadFlow.Data.Model;
using RoadFlow.Platform;
using RoadFlow.Utility;
using System.Data;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
	public class WorkFlowArchivesController : MyController
	{
		public ActionResult Index()
		{
			RoadFlow.Platform.WorkFlow workFlow = new RoadFlow.Platform.WorkFlow();
			base.ViewBag.flowOptions = workFlow.GetOptions();
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public string Query()
		{
			string text = base.Request.Form["sidx"];
			string text2 = base.Request.Form["sord"];
			string title = base.Request.Form["Title"];
			string flowIDString = base.Request.Form["FlowID"];
			string date = base.Request.Form["Date1"];
			string date2 = base.Request.Form["Date2"];
			RoadFlow.Platform.WorkFlowArchives workFlowArchives = new RoadFlow.Platform.WorkFlowArchives();
			new RoadFlow.Platform.WorkFlow();
			int pageSize = Tools.GetPageSize();
			int pageNumber = Tools.GetPageNumber();
			string order = (text.IsNullOrEmpty() ? "WriteTime" : text) + " " + (text2.IsNullOrEmpty() ? "asc" : text2);
			long count;
			DataTable pagerData = workFlowArchives.GetPagerData(out count, pageSize, pageNumber, title, flowIDString, date, date2, order);
			JsonData jsonData = new JsonData();
			foreach (DataRow row in pagerData.Rows)
			{
				JsonData jsonData2 = new JsonData();
				jsonData2["id"] = row["ID"].ToString();
				jsonData2["Title"] = "<a href=\"javascript:show('" + row["ID"].ToString() + "');\" class=\"blue\">" + row["Title"].ToString() + "</a>";
				jsonData2["FlowName"] = row["FlowName"].ToString();
				jsonData2["StepName"] = row["StepName"].ToString();
				jsonData2["WriteTime"] = row["WriteTime"].ToString().ToDateTimeString();
				jsonData.Add(jsonData2);
			}
			return "{\"userdata\":{\"total\":" + count + ",\"pagesize\":" + pageSize + ",\"pagenumber\":" + pageNumber + "},\"rows\":" + jsonData.ToJson() + "}";
		}

		public ActionResult Show()
		{
			string str = base.Request.QueryString["id"];
			if (!str.IsGuid())
			{
				return View();
			}
			RoadFlow.Data.Model.WorkFlowArchives workFlowArchives = new RoadFlow.Platform.WorkFlowArchives().Get(str.ToGuid());
			if (workFlowArchives == null)
			{
				return View();
			}
			return View(workFlowArchives);
		}
	}
}
