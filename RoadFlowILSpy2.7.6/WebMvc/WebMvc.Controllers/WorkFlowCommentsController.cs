using LitJson;
using RoadFlow.Data.Model;
using RoadFlow.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
	public class WorkFlowCommentsController : MyController
	{
		public ActionResult Index()
		{
			return Index(null);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Index(FormCollection collection)
		{
			RoadFlow.Platform.WorkFlowComment workFlowComment = new RoadFlow.Platform.WorkFlowComment();
			RoadFlow.Platform.Organize organize = new RoadFlow.Platform.Organize();
			IEnumerable<RoadFlow.Data.Model.WorkFlowComment> source = workFlowComment.GetAll();
			if ("1" == base.Request.QueryString["isoneself"])
			{
				source = from p in source
				where p.MemberID == "u_" + RoadFlow.Platform.Users.CurrentUserID.ToString()
				select p;
			}
			JsonData jsonData = new JsonData();
			foreach (RoadFlow.Data.Model.WorkFlowComment item in from p in source
			orderby p.Type, p.Sort
			select p)
			{
				JsonData jsonData2 = new JsonData();
				jsonData2["id"] = item.ID.ToString();
				jsonData2["Comment"] = item.Comment;
				jsonData2["MemberID"] = (item.MemberID.IsNullOrEmpty() ? "所有人员" : organize.GetNames(item.MemberID));
				jsonData2["Type"] = ((item.Type == 0) ? "管理员" : "个人");
				jsonData2["Sort"] = item.Sort;
				jsonData2["Opation"] = "<a class=\"editlink\" href=\"javascript:edit('" + item.ID.ToString() + "');\">编辑</a>";
				jsonData.Add(jsonData2);
			}
			base.ViewBag.list = jsonData.ToJson();
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public string Delete()
		{
			RoadFlow.Platform.WorkFlowComment workFlowComment = new RoadFlow.Platform.WorkFlowComment();
			string[] array = base.Request.Form["ids"].Split(',');
			for (int i = 0; i < array.Length; i++)
			{
				Guid test;
				if (array[i].IsGuid(out test))
				{
					RoadFlow.Data.Model.WorkFlowComment workFlowComment2 = workFlowComment.Get(test);
					if (workFlowComment2 != null)
					{
						workFlowComment.Delete(test);
						RoadFlow.Platform.Log.Add("删除了流程意见", workFlowComment2.Serialize(), RoadFlow.Platform.Log.Types.流程相关);
					}
				}
			}
			workFlowComment.RefreshCache();
			return "删除成功!";
		}

		public ActionResult Edit()
		{
			return Edit(null);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(FormCollection collection)
		{
			RoadFlow.Platform.WorkFlowComment workFlowComment = new RoadFlow.Platform.WorkFlowComment();
			RoadFlow.Data.Model.WorkFlowComment workFlowComment2 = null;
			string str = base.Request.QueryString["id"];
			string empty = string.Empty;
			string empty2 = string.Empty;
			string empty3 = string.Empty;
			bool flag = "1" == base.Request.QueryString["isoneself"];
			Guid test;
			if (str.IsGuid(out test))
			{
				workFlowComment2 = workFlowComment.Get(test);
				empty = workFlowComment2.MemberID;
				empty2 = workFlowComment2.Comment;
				empty3 = workFlowComment2.Sort.ToString();
			}
			string oldXML = workFlowComment2.Serialize();
			if (collection != null)
			{
				empty = (flag ? ("u_" + RoadFlow.Platform.Users.CurrentUserID.ToString()) : base.Request.Form["Member"]);
				empty2 = base.Request.Form["Comment"];
				empty3 = base.Request.Form["Sort"];
				bool num = !str.IsGuid();
				if (workFlowComment2 == null)
				{
					workFlowComment2 = new RoadFlow.Data.Model.WorkFlowComment
					{
						ID = Guid.NewGuid(),
						Type = (flag ? 1 : 0)
					};
				}
				workFlowComment2.MemberID = (empty.IsNullOrEmpty() ? "" : empty.Trim());
				workFlowComment2.Comment = (empty2.IsNullOrEmpty() ? "" : empty2.Trim());
				workFlowComment2.Sort = (empty3.IsInt() ? empty3.ToInt() : workFlowComment.GetManagerMaxSort());
				if (num)
				{
					workFlowComment.Add(workFlowComment2);
					RoadFlow.Platform.Log.Add("添加了流程意见", workFlowComment2.Serialize(), RoadFlow.Platform.Log.Types.流程相关);
				}
				else
				{
					workFlowComment.Update(workFlowComment2);
					RoadFlow.Platform.Log.Add("修改了流程意见", "", RoadFlow.Platform.Log.Types.流程相关, oldXML, workFlowComment2.Serialize());
				}
				workFlowComment.RefreshCache();
				base.ViewBag.Script = "new RoadUI.Window().reloadOpener();alert('保存成功!');";
			}
			if (workFlowComment2 == null)
			{
				workFlowComment2 = new RoadFlow.Data.Model.WorkFlowComment();
				workFlowComment2.Sort = workFlowComment.GetManagerMaxSort() + 5;
			}
			return View(workFlowComment2);
		}
	}
}
