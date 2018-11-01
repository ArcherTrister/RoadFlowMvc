using LitJson;
using RoadFlow.Data.Model;
using RoadFlow.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
	public class WorkFlowButtonsController : MyController
	{
		public ActionResult Index()
		{
			string empty = string.Empty;
			base.ViewBag.Query1 = string.Format("&appid={0}&tabid={1}", base.Request.QueryString["appid"], base.Request.QueryString["tabid"]);
			List<RoadFlow.Data.Model.WorkFlowButtons> all = new RoadFlow.Platform.WorkFlowButtons().GetAll();
			JsonData jsonData = new JsonData();
			foreach (RoadFlow.Data.Model.WorkFlowButtons item in from p in all
			orderby p.Sort, p.Title
			select p)
			{
				JsonData jsonData2 = new JsonData();
				jsonData2["id"] = item.ID.ToString();
				jsonData2["Title"] = item.Title;
				if (!item.Ico.IsNullOrEmpty())
				{
					if (item.Ico.IsFontIco())
					{
						jsonData2["Ico"] = "<i class=\"fa " + item.Ico + "\" style=\"font-size:14px;\"></i>";
					}
					else
					{
						jsonData2["Ico"] = "<img src=\"" + base.Url.Content("~" + item.Ico) + "\" alt=\"\" />";
					}
				}
				else
				{
					jsonData2["Ico"] = "";
				}
				jsonData2["Note"] = item.Note;
				jsonData2["Sort"] = item.Sort.ToString();
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
			RoadFlow.Platform.WorkFlowButtons workFlowButtons = new RoadFlow.Platform.WorkFlowButtons();
			string[] array = base.Request.Form["ids"].Split(',');
			for (int i = 0; i < array.Length; i++)
			{
				Guid test;
				if (array[i].IsGuid(out test))
				{
					RoadFlow.Data.Model.WorkFlowButtons workFlowButtons2 = workFlowButtons.Get(test);
					if (workFlowButtons2 != null)
					{
						workFlowButtons.Delete(test);
						RoadFlow.Platform.Log.Add("删除了流程按钮", workFlowButtons2.Serialize(), RoadFlow.Platform.Log.Types.流程相关);
					}
				}
			}
			workFlowButtons.ClearCache();
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
			RoadFlow.Platform.WorkFlowButtons workFlowButtons = new RoadFlow.Platform.WorkFlowButtons();
			RoadFlow.Data.Model.WorkFlowButtons workFlowButtons2 = null;
			string str = base.Request.QueryString["id"];
			string empty = string.Empty;
			string empty2 = string.Empty;
			string empty3 = string.Empty;
			string empty4 = string.Empty;
			string empty5 = string.Empty;
			Guid test;
			if (str.IsGuid(out test))
			{
				workFlowButtons2 = workFlowButtons.Get(test);
			}
			string oldXML = workFlowButtons2.Serialize();
			if (collection != null)
			{
				empty = base.Request.Form["Title"];
				empty2 = base.Request.Form["Ico"];
				empty3 = base.Request.Form["Script"];
				empty4 = base.Request.Form["Note"];
				empty5 = base.Request.Form["Sort"];
				bool num = !str.IsGuid();
				if (workFlowButtons2 == null)
				{
					workFlowButtons2 = new RoadFlow.Data.Model.WorkFlowButtons
					{
						ID = Guid.NewGuid(),
						Sort = workFlowButtons.GetMaxSort()
					};
				}
				workFlowButtons2.Ico = (empty2.IsNullOrEmpty() ? null : empty2.Trim());
				workFlowButtons2.Note = (empty4.IsNullOrEmpty() ? null : empty4.Trim());
				workFlowButtons2.Script = (empty3.IsNullOrEmpty() ? null : empty3);
				workFlowButtons2.Title = empty.Trim();
				if (empty5.IsInt())
				{
					workFlowButtons2.Sort = empty5.ToInt();
				}
				else
				{
					workFlowButtons2.Sort = workFlowButtons.GetMaxSort();
				}
				if (num)
				{
					workFlowButtons.Add(workFlowButtons2);
					RoadFlow.Platform.Log.Add("添加了流程按钮", workFlowButtons2.Serialize(), RoadFlow.Platform.Log.Types.流程相关);
				}
				else
				{
					workFlowButtons.Update(workFlowButtons2);
					RoadFlow.Platform.Log.Add("修改了流程按钮", "", RoadFlow.Platform.Log.Types.流程相关, oldXML, workFlowButtons2.Serialize());
				}
				workFlowButtons.ClearCache();
				base.ViewBag.Script = "new RoadUI.Window().reloadOpener();alert('保存成功!');new RoadUI.Window().close();";
			}
			if (workFlowButtons2 == null)
			{
				workFlowButtons2 = new RoadFlow.Data.Model.WorkFlowButtons();
				workFlowButtons2.Sort = workFlowButtons.GetMaxSort();
			}
			return View(workFlowButtons2);
		}
	}
}
