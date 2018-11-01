using RoadFlow.Data.Model;
using RoadFlow.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
	public class OnlineUsersController : MyController
	{
		[MyAttribute(CheckApp = false)]
		public ActionResult Index()
		{
			return query(null);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[MyAttribute(CheckApp = false)]
		public ActionResult Index(FormCollection collection)
		{
			RoadFlow.Platform.OnlineUsers onlineUsers = new RoadFlow.Platform.OnlineUsers();
			if (!base.Request.Form["ClearAll"].IsNullOrEmpty())
			{
				onlineUsers.RemoveAll();
			}
			if (!base.Request.Form["ClearSelect"].IsNullOrEmpty())
			{
				string text = base.Request.Form["checkbox_app"];
				if (!text.IsNullOrEmpty())
				{
					string[] array = text.Split(',');
					for (int i = 0; i < array.Length; i++)
					{
						Guid test;
						if (array[i].IsGuid(out test))
						{
							onlineUsers.Remove(test);
						}
					}
				}
			}
			return query(collection);
		}

		[MyAttribute(CheckApp = false)]
		private ActionResult query(FormCollection collection)
		{
			RoadFlow.Platform.OnlineUsers onlineUsers = new RoadFlow.Platform.OnlineUsers();
			string name = string.Empty;
			if (collection != null)
			{
				name = base.Request.Form["Name"];
			}
			else
			{
				name = base.Request.QueryString["Name"];
			}
			base.ViewBag.Name = name;
			List<RoadFlow.Data.Model.OnlineUsers> list = onlineUsers.GetAll();
			if (!name.IsNullOrEmpty())
			{
				list = (from p in list
				where p.UserName.IndexOf(name) >= 0
				select p).ToList();
			}
			return View(list);
		}
	}
}
