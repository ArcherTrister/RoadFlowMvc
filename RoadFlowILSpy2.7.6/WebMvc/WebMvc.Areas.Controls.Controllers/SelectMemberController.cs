using RoadFlow.Platform;
using System;
using System.Web.Mvc;

namespace WebMvc.Areas.Controls.Controllers
{
	public class SelectMemberController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public string GetNames()
		{
			string idString = base.Request.Form["values"];
			return new Organize().GetNames(idString);
		}

		public string GetNote()
		{
			string text = base.Request.QueryString["id"];
			if (text.IsNullOrEmpty())
			{
				return "";
			}
			Organize organize = new Organize();
			Users users = new Users();
			if (text.StartsWith("u_"))
			{
				Guid guid = users.RemovePrefix1(text).ToGuid();
				return organize.GetAllParentNames(users.GetMainStation(guid)) + " / " + users.GetName(guid);
			}
			if (text.StartsWith("w_"))
			{
				return new WorkGroup().GetUsersNames(WorkGroup.RemovePrefix(text).ToGuid(), '、');
			}
			Guid test;
			if (text.IsGuid(out test))
			{
				return organize.GetAllParentNames(test);
			}
			return "";
		}

		public ActionResult Index_App()
		{
			return View();
		}
	}
}
