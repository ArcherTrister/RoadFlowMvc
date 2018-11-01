using RoadFlow.Data.Model;
using RoadFlow.Platform;
using RoadFlow.Platform.WeiXin;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace WebMvc.Areas.WeiXin.Controllers
{
	public class StartFlowsController : Controller
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
			new RoadFlow.Platform.Users();
			string s_searchkey = base.Request.QueryString["searchkey"];
			if (coll != null)
			{
				s_searchkey = base.Request.Form["searchkey"];
			}
			List<WorkFlowStart> list = new RoadFlow.Platform.WorkFlow().GetUserStartFlows(RoadFlow.Platform.WeiXin.Organize.CurrentUserID);
			if (!s_searchkey.IsNullOrEmpty())
			{
				list = list.FindAll((WorkFlowStart p) => p.Name.Contains(s_searchkey.Trim1(), StringComparison.CurrentCultureIgnoreCase));
			}
			return View(list);
		}
	}
}
