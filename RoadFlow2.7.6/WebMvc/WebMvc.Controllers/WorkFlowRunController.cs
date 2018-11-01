using RoadFlow.Data.Model;
using RoadFlow.Data.Model.WorkFlowInstalledSub;
using RoadFlow.Platform;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
	public class WorkFlowRunController : MyController
	{
		[MyAttribute(CheckApp = false, CheckUrl = false)]
		public ActionResult Index()
		{
			return View();
		}

		[MyAttribute(CheckApp = false, CheckUrl = false, CheckLogin = false)]
		public ActionResult Index_App()
		{
			return View();
		}

		[MyAttribute(CheckApp = false, CheckUrl = false)]
		public ActionResult ShowComment()
		{
			return View();
		}

		[MyAttribute(CheckApp = false, CheckLogin = false, CheckUrl = false)]
		public ActionResult Print()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[MyAttribute(CheckApp = false, CheckLogin = false)]
		public ActionResult Execute()
		{
			return View();
		}

		[MyAttribute(CheckApp = false, CheckLogin = false)]
		public ActionResult FlowBack()
		{
			return View();
		}

		[MyAttribute(CheckApp = false, CheckLogin = false)]
		public ActionResult FlowRedirect()
		{
			return View();
		}

		[MyAttribute(CheckApp = false, CheckLogin = false)]
		public ActionResult FlowSend()
		{
			return View();
		}

		[MyAttribute(CheckApp = false, CheckUrl = false, CheckLogin = false)]
		public ActionResult Process()
		{
			return View();
		}

		[MyAttribute(CheckApp = false, CheckLogin = false, CheckUrl = false)]
		public ActionResult Sign()
		{
			return View();
		}

		[MyAttribute(CheckApp = false, CheckLogin = false)]
		public ActionResult SaveData()
		{
			return View();
		}

		[MyAttribute(CheckApp = false, CheckLogin = false)]
		public ActionResult ShowDesign()
		{
			return View();
		}

		[MyAttribute(CheckApp = false, CheckLogin = false)]
		public ActionResult SubTableEdit()
		{
			return View();
		}

		[MyAttribute(CheckApp = false, CheckLogin = false)]
		public string SubTableDelete()
		{
			string str = base.Request.QueryString["secondtableconnid"];
			string table = base.Request.QueryString["secondtable"];
			string pkFiled = base.Request.QueryString["secondtableprimarykey"];
			string pkValue = base.Request.QueryString["secondtablepkvalue"];
			if (new RoadFlow.Platform.DBConnection().DeleteData(str.ToGuid(), table, pkFiled, pkValue) > 0)
			{
				return "删除成功!";
			}
			return "删除失败!";
		}

		[MyAttribute(CheckApp = false, CheckLogin = false)]
		public ActionResult FlowFreedomSend()
		{
			return View();
		}

		[MyAttribute(CheckApp = false)]
		public ActionResult TaskEnd()
		{
			string text = base.Request.QueryString["taskid"];
			string text2 = text.IsGuid() ? new RoadFlow.Platform.WorkFlowTask().EndTask(text.ToGuid()) : "参数错误";
			RoadFlow.Platform.Log.Add("终止的流程任务", text, RoadFlow.Platform.Log.Types.流程相关);
			if ("1" != text2)
			{
				base.ViewBag.script = "alert('" + text2 + "')";
			}
			else
			{
				base.ViewBag.script = "alert('终止成功!'); try{top.mainDialog.close();}catch(e){} try{top.mainTab.closeTab();}catch(e){parent.close();}";
			}
			return View();
		}

		[MyAttribute(CheckApp = false, CheckLogin = false, CheckUrl = false)]
		public string GetLinkageOptions()
		{
			string b = base.Request["linkagesource"];
			string sql = base.Request["linkagesourcetext"];
			string str = base.Request["linkagesourceconn"];
			string str2 = base.Request["value"];
			if ("sql" == b)
			{
				Guid test;
				if (!str.IsGuid(out test))
				{
					return "";
				}
				return new RoadFlow.Platform.DBConnection().GetOptionsFromSql(test, sql);
			}
			if ("dict" == b)
			{
				return new RoadFlow.Platform.Dictionary().GetOptionsByID(str2.ToGuid(), RoadFlow.Platform.Dictionary.OptionValueField.ID, "", false);
			}
			return "";
		}

		[MyAttribute(CheckApp = false)]
		public ActionResult FlowCopyFor()
		{
			return FlowCopyFor(null);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[MyAttribute(CheckApp = false)]
		public ActionResult FlowCopyFor(FormCollection collection)
		{
			RoadFlow.Platform.WorkFlow workFlow = new RoadFlow.Platform.WorkFlow();
			RoadFlow.Platform.WorkFlowTask workFlowTask = new RoadFlow.Platform.WorkFlowTask();
			WorkFlowInstalled workFlowInstalled = null;
			RoadFlow.Data.Model.WorkFlowTask workFlowTask2 = null;
			string flowID = base.Request.QueryString["flowid"];
			string stepid = base.Request.QueryString["stepid"];
			string text = base.Request.QueryString["groupid"];
			string text2 = base.Request.QueryString["instanceid"];
			workFlowInstalled = workFlow.GetWorkFlowRunModel(flowID);
			if (workFlowInstalled == null)
			{
				base.Response.Write("未找到流程运行实体");
				base.Response.End();
				return null;
			}
			if ((from p in workFlowInstalled.Steps
			where p.ID == stepid.ToGuid()
			select p).Count() == 0)
			{
				base.Response.Write("未找到当前步骤");
				base.Response.End();
				return null;
			}
			workFlowTask2 = workFlowTask.Get(base.Request.QueryString["taskid"].ToGuid());
			if (workFlowTask2 == null)
			{
				base.Response.Write("当前任务为空,请先保存再抄送!");
				base.Response.End();
				return null;
			}
			if (collection != null)
			{
				List<RoadFlow.Data.Model.WorkFlowTask> taskList = workFlowTask.GetTaskList(workFlowTask2.ID);
				List<RoadFlow.Data.Model.Users> allUsers = new RoadFlow.Platform.Organize().GetAllUsers(base.Request.Form["user"] ?? "");
				StringBuilder stringBuilder = new StringBuilder();
				foreach (RoadFlow.Data.Model.Users item in allUsers)
				{
					if (taskList.Find((RoadFlow.Data.Model.WorkFlowTask p) => p.ReceiveID == item.ID) == null)
					{
						Step step = (from p in workFlowInstalled.Steps
						where p.ID == base.Request.QueryString["stepid"].ToGuid()
						select p).First();
						RoadFlow.Data.Model.WorkFlowTask workFlowTask3 = new RoadFlow.Data.Model.WorkFlowTask();
						if (step.WorkTime > decimal.Zero)
						{
							workFlowTask3.CompletedTime = DateTimeNew.Now.AddHours((double)step.WorkTime);
						}
						workFlowTask3.FlowID = workFlowTask2.FlowID;
						workFlowTask3.GroupID = workFlowTask2.GroupID;
						workFlowTask3.ID = Guid.NewGuid();
						workFlowTask3.Type = 5;
						workFlowTask3.InstanceID = workFlowTask2.InstanceID;
						workFlowTask3.Note = "抄送任务";
						workFlowTask3.PrevID = workFlowTask2.PrevID;
						workFlowTask3.PrevStepID = workFlowTask2.PrevStepID;
						workFlowTask3.ReceiveID = item.ID;
						workFlowTask3.ReceiveName = item.Name;
						workFlowTask3.ReceiveTime = DateTimeNew.Now;
						workFlowTask3.SenderID = workFlowTask2.ReceiveID;
						workFlowTask3.SenderName = workFlowTask2.ReceiveName;
						workFlowTask3.SenderTime = workFlowTask3.ReceiveTime;
						workFlowTask3.Status = 0;
						workFlowTask3.StepID = workFlowTask2.StepID;
						workFlowTask3.StepName = workFlowTask2.StepName;
						workFlowTask3.Sort = workFlowTask2.Sort;
						workFlowTask3.Title = workFlowTask2.Title;
						workFlowTask.Add(workFlowTask3);
						stringBuilder.Append(workFlowTask3.ReceiveName);
						stringBuilder.Append(",");
					}
				}
				base.ViewBag.script = "alert('成功抄送给：" + stringBuilder.ToString().TrimEnd(',') + "');new RoadUI.Window().close();";
			}
			return View();
		}

		[MyAttribute(CheckApp = false)]
		public ActionResult ShowForm()
		{
			string str = base.Request.QueryString["taskid"];
			if (str.IsGuid())
			{
				RoadFlow.Platform.WorkFlowTask workFlowTask = new RoadFlow.Platform.WorkFlowTask();
				RoadFlow.Data.Model.WorkFlowTask workFlowTask2 = workFlowTask.Get(str.ToGuid());
				if (workFlowTask2 != null)
				{
					List<RoadFlow.Data.Model.WorkFlowTask> bySubFlowGroupID = workFlowTask.GetBySubFlowGroupID(workFlowTask2.GroupID);
					if (bySubFlowGroupID.Count > 0)
					{
						RoadFlow.Data.Model.WorkFlowTask workFlowTask3 = (from p in bySubFlowGroupID
						orderby p.Sort descending
						select p).FirstOrDefault();
						string url = (("1" == base.Request.QueryString["ismobile"]) ? "Index_App" : "Index") + "?flowid=" + workFlowTask3.FlowID + "&stepid=" + workFlowTask3.StepID + "&instanceid=" + workFlowTask3.InstanceID + "&taskid=" + workFlowTask3.ID + "&groupid=" + workFlowTask3.GroupID + "&appid=" + base.Request.QueryString["appid"] + "&display=1&tabid=" + base.Request.QueryString["tabid"];
						return Redirect(url);
					}
				}
			}
			return View();
		}

		[MyAttribute(CheckApp = false)]
		public ActionResult AddWrite()
		{
			return AddWrite(null);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[MyAttribute(CheckApp = false)]
		public ActionResult AddWrite(FormCollection collection)
		{
			if (collection != null)
			{
				string str = base.Request.Form["addtype"];
				string str2 = base.Request.Form["writetype"];
				string writeUsers = base.Request.Form["writeuser"];
				string note = base.Request.Form["note"];
				string str3 = base.Request.QueryString["taskid"];
				string msg;
				string str4 = "alert('" + (new RoadFlow.Platform.WorkFlowTask().AddWrite(str3.ToGuid(), str.ToInt(), str2.ToInt(), writeUsers, note, out msg) ? "加签成功!" : msg) + "');";
				if (str.ToInt() == 1)
				{
					str4 += "try{if(top.refreshPage){top.refreshPage();}if(top.mainTab){top.mainTab.closeTab();}else{top.close();}}catch(e){}";
				}
				str4 += "try{new RoadUI.Window().close();}catch(e){}";
				base.ViewBag.script = str4;
			}
			return View();
		}

		[MyAttribute(CheckApp = false)]
		public ActionResult StartFlow()
		{
			return StartFlow(null);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[MyAttribute(CheckApp = false)]
		public ActionResult StartFlow(FormCollection collection)
		{
			string s_FlowName = base.Request.QueryString["FlowName"];
			if (collection != null)
			{
				s_FlowName = base.Request.Form["FlowName"];
			}
			List<WorkFlowStart> list = new RoadFlow.Platform.WorkFlow().GetUserStartFlows(RoadFlow.Platform.Users.CurrentUserID);
			if (!s_FlowName.IsNullOrEmpty())
			{
				list = list.FindAll((WorkFlowStart p) => p.Name.Contains(s_FlowName.Trim1(), StringComparison.CurrentCultureIgnoreCase));
			}
			base.ViewBag.FlowName = s_FlowName;
			return View(list);
		}

		[MyAttribute(CheckApp = false, CheckLogin = false, CheckUrl = false)]
		public ActionResult AutoSubmit()
		{
			return View();
		}
	}
}
