using LitJson;
using RoadFlow.Data.Model;
using RoadFlow.Platform;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
	public class WorkFlowDelegationController : MyController
	{
		public ActionResult Index()
		{
			new RoadFlow.Platform.WorkFlowDelegation();
			string.Format("&appid={0}&tabid={1}&isoneself={2}", base.Request.QueryString["appid"], base.Request.QueryString["tabid"], base.Request.QueryString["isoneself"]);
			base.ViewBag.Query = "&isoneself=" + base.Request.QueryString["isoneself"] + "&appid=" + base.Request.QueryString["appid"] + "&tabid=" + base.Request.QueryString["tabid"];
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public string Delete()
		{
			RoadFlow.Platform.WorkFlowDelegation workFlowDelegation = new RoadFlow.Platform.WorkFlowDelegation();
			string[] array = base.Request.Form["ids"].Split(',');
			for (int i = 0; i < array.Length; i++)
			{
				Guid test;
				if (array[i].IsGuid(out test))
				{
					RoadFlow.Data.Model.WorkFlowDelegation workFlowDelegation2 = workFlowDelegation.Get(test);
					if (workFlowDelegation2 != null)
					{
						workFlowDelegation.Delete(test);
						RoadFlow.Platform.Log.Add("删除了流程意见", workFlowDelegation2.Serialize(), RoadFlow.Platform.Log.Types.流程相关);
					}
				}
			}
			workFlowDelegation.RefreshCache();
			return "删除成功!";
		}

		[ValidateAntiForgeryToken]
		public string Query()
		{
			RoadFlow.Platform.WorkFlowDelegation workFlowDelegation = new RoadFlow.Platform.WorkFlowDelegation();
			new RoadFlow.Platform.Organize();
			RoadFlow.Platform.Users users = new RoadFlow.Platform.Users();
			RoadFlow.Platform.WorkFlow workFlow = new RoadFlow.Platform.WorkFlow();
			string startTime = base.Request.Form["S_StartTime"];
			string endTime = base.Request.Form["S_EndTime"];
			string id = base.Request.Form["S_UserID"];
			string text = base.Request.Form["sidx"];
			string text2 = base.Request.Form["sord"];
			string text3 = base.Request.Form["typeid"];
			int pageSize = Tools.GetPageSize();
			int pageNumber = Tools.GetPageNumber();
			string order = (text.IsNullOrEmpty() ? "SenderTime" : text) + " " + (text2.IsNullOrEmpty() ? "asc" : text2);
			long count;
			IEnumerable<RoadFlow.Data.Model.WorkFlowDelegation> enumerable = (!("1" == base.Request.QueryString["isoneself"])) ? workFlowDelegation.GetPagerData(out count, pageSize, pageNumber, RoadFlow.Platform.Users.RemovePrefix(id), startTime, endTime, order) : workFlowDelegation.GetPagerData(out count, pageSize, pageNumber, MyController.CurrentUserID.ToString(), startTime, endTime, order);
			JsonData jsonData = new JsonData();
			foreach (RoadFlow.Data.Model.WorkFlowDelegation item in enumerable)
			{
				string data = "委托中";
				if (item.StartTime > DateTimeNew.Now)
				{
					data = "未开始";
				}
				else if (item.EndTime < DateTimeNew.Now)
				{
					data = "已失效";
				}
				JsonData jsonData2 = new JsonData();
				jsonData2["id"] = item.ID.ToString();
				jsonData2["UserID"] = users.GetName(item.UserID);
				jsonData2["ToUserID"] = users.GetName(item.ToUserID);
				jsonData2["FlowID"] = (item.FlowID.HasValue ? workFlow.GetFlowName(item.FlowID.Value) : "");
				jsonData2["StartTime"] = item.StartTime.ToDateTimeString();
				jsonData2["EndTime"] = item.EndTime.ToDateTimeString();
				jsonData2["Note"] = item.Note;
				jsonData2["Status"] = data;
				jsonData2["Edit"] = "<a class=\"editlink\" href=\"javascript:edit('" + item.ID.ToString() + "');\">编辑</a>";
				jsonData.Add(jsonData2);
			}
			return "{\"userdata\":{\"total\":" + count + ",\"pagesize\":" + pageSize + ",\"pagenumber\":" + pageNumber + "},\"rows\":" + jsonData.ToJson() + "}";
		}

		public ActionResult Edit()
		{
			return Edit(null);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(FormCollection collection)
		{
			RoadFlow.Platform.WorkFlowDelegation workFlowDelegation = new RoadFlow.Platform.WorkFlowDelegation();
			RoadFlow.Data.Model.WorkFlowDelegation workFlowDelegation2 = null;
			string str = base.Request.QueryString["id"];
			string empty = string.Empty;
			string empty2 = string.Empty;
			string empty3 = string.Empty;
			string empty4 = string.Empty;
			string text = string.Empty;
			string empty5 = string.Empty;
			bool flag = "1" == base.Request.QueryString["isoneself"];
			Guid test;
			if (str.IsGuid(out test))
			{
				workFlowDelegation2 = workFlowDelegation.Get(test);
				if (workFlowDelegation2 != null)
				{
					text = workFlowDelegation2.FlowID.ToString();
				}
			}
			string oldXML = workFlowDelegation2.Serialize();
			if (collection != null)
			{
				empty = base.Request.Form["UserID"];
				empty2 = base.Request.Form["ToUserID"];
				empty3 = base.Request.Form["StartTime"];
				empty4 = base.Request.Form["EndTime"];
				text = base.Request.Form["FlowID"];
				empty5 = base.Request.Form["Note"];
				bool num = !str.IsGuid();
				if (workFlowDelegation2 == null)
				{
					workFlowDelegation2 = new RoadFlow.Data.Model.WorkFlowDelegation
					{
						ID = Guid.NewGuid()
					};
				}
				workFlowDelegation2.UserID = (flag ? RoadFlow.Platform.Users.CurrentUserID : RoadFlow.Platform.Users.RemovePrefix(empty).ToGuid());
				workFlowDelegation2.EndTime = empty4.ToDateTime();
				if (text.IsGuid())
				{
					workFlowDelegation2.FlowID = text.ToGuid();
				}
				else
				{
					workFlowDelegation2.FlowID = null;
				}
				workFlowDelegation2.Note = (empty5.IsNullOrEmpty() ? null : empty5);
				workFlowDelegation2.StartTime = empty3.ToDateTime();
				workFlowDelegation2.ToUserID = RoadFlow.Platform.Users.RemovePrefix(empty2).ToGuid();
				workFlowDelegation2.WriteTime = DateTimeNew.Now;
				if (num)
				{
					workFlowDelegation.Add(workFlowDelegation2);
					RoadFlow.Platform.Log.Add("添加了工作委托", workFlowDelegation2.Serialize(), RoadFlow.Platform.Log.Types.流程相关);
				}
				else
				{
					workFlowDelegation.Update(workFlowDelegation2);
					RoadFlow.Platform.Log.Add("修改了工作委托", "", RoadFlow.Platform.Log.Types.流程相关, oldXML, workFlowDelegation2.Serialize());
				}
				workFlowDelegation.RefreshCache();
				base.ViewBag.Script = "alert('保存成功!');new RoadUI.Window().getOpenerWindow().query();new RoadUI.Window().close();";
			}
			base.ViewBag.FlowOptions = new RoadFlow.Platform.WorkFlow().GetOptions(text);
			return View((workFlowDelegation2 == null) ? new RoadFlow.Data.Model.WorkFlowDelegation
			{
				UserID = RoadFlow.Platform.Users.CurrentUserID
			} : workFlowDelegation2);
		}
	}
}
