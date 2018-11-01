using RoadFlow.Cache.IO;
using RoadFlow.Data.Model;
using RoadFlow.Data.MSSQL;
using RoadFlow.Platform;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
	public class WorkCalendarController : MyController
	{
		public ActionResult Index()
		{
			return Index(null);
		}

		[HttpPost]
		public ActionResult Index(FormCollection collection)
		{
			RoadFlow.Data.MSSQL.WorkCalendar workCalendar = new RoadFlow.Data.MSSQL.WorkCalendar();
			int num = base.Request.Form["DropDownList1"].IsNullOrEmpty() ? DateTimeNew.Now.Year : base.Request.Form["DropDownList1"].ToInt();
			if (!base.Request.Form["saveBut"].IsNullOrEmpty())
			{
				string text = base.Request.Form["workdate"] ?? "";
				string text2 = base.Request.Form["year1"];
				using (TransactionScope transactionScope = new TransactionScope())
				{
					workCalendar.Delete(text2.ToInt());
					foreach (string item in text.Split(new char[1]
					{
						','
					}, StringSplitOptions.RemoveEmptyEntries).Distinct())
					{
						if (item.IsDateTime())
						{
							RoadFlow.Data.Model.WorkCalendar workCalendar2 = new RoadFlow.Data.Model.WorkCalendar();
							workCalendar2.WorkDate = item.ToDateTime();
							workCalendar.Add(workCalendar2);
						}
					}
					transactionScope.Complete();
				}
				Opation.Remove("WorkCalendar_" + text2);
				RoadFlow.Platform.Log.Add("设置了工作日历", text, RoadFlow.Platform.Log.Types.系统管理);
				base.ViewBag.script = "alert('保存成功!')";
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 2016; i < 2099; i++)
			{
				stringBuilder.Append("<option value='" + i + "'" + ((i == num) ? "selected='selected'" : "") + ">" + i + "</option>");
			}
			List<RoadFlow.Data.Model.WorkCalendar> all = workCalendar.GetAll(num);
			base.ViewBag.options = stringBuilder;
			base.ViewBag.year = num;
			return View(all);
		}
	}
}
