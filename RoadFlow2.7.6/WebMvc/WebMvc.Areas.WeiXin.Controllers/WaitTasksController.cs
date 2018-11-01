using LitJson;
using RoadFlow.Data.Model;
using RoadFlow.Platform;
using RoadFlow.Platform.WeiXin;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace WebMvc.Areas.WeiXin.Controllers
{
	public class WaitTasksController : Controller
	{
		public ActionResult Index()
		{
			return Index(null);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Index(FormCollection coll)
		{
			RoadFlow.Platform.WeiXin.Organize.CheckLogin();
			Guid currentUserID = RoadFlow.Platform.WeiXin.Organize.CurrentUserID;
			RoadFlow.Platform.WorkFlowTask workFlowTask = new RoadFlow.Platform.WorkFlowTask();
			List<RoadFlow.Data.Model.WorkFlowTask> list = new List<RoadFlow.Data.Model.WorkFlowTask>();
			string text = base.Request.QueryString["searchkey"];
			if (coll != null)
			{
				text = base.Request.Form["searchkey"];
			}
			long count;
			list = workFlowTask.GetTasks(currentUserID, out count, 15, 1, text);
			base.ViewBag.Count = count;
			base.ViewBag.SearchTitle = text;
			return View(list);
		}

		public string GetTasks()
		{
			string str = base.Request.QueryString["pagenumber"];
			string str2 = base.Request.QueryString["pagesize"];
			string title = base.Request.QueryString["SearchTitle"];
			Guid currentUserID = RoadFlow.Platform.WeiXin.Organize.CurrentUserID;
			long count;
			List<RoadFlow.Data.Model.WorkFlowTask> tasks = new RoadFlow.Platform.WorkFlowTask().GetTasks(currentUserID, out count, str2.ToInt(15), str.ToInt(2), title);
			JsonData jsonData = new JsonData();
			if (tasks.Count == 0)
			{
				return "[]";
			}
			foreach (RoadFlow.Data.Model.WorkFlowTask item in tasks)
			{
				JsonData jsonData2 = new JsonData();
				jsonData2["id"] = item.ID.ToString();
				jsonData2["title"] = item.Title;
				jsonData2["time"] = item.ReceiveTime.ToDateTimeString();
				jsonData2["sender"] = item.SenderName;
				jsonData2["flowid"] = item.FlowID.ToString();
				jsonData2["stepid"] = item.StepID.ToString();
				jsonData2["instanceid"] = item.InstanceID;
				jsonData2["groupid"] = item.GroupID.ToString();
				jsonData.Add(jsonData2);
			}
			return jsonData.ToJson();
		}
	}
}
