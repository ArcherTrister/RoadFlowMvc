using LitJson;
using RoadFlow.Data.Model;
using RoadFlow.Platform;
using RoadFlow.Platform.WeiXin;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebMvc.Common;

namespace WebMvc.Controllers
{
	public class WorkFlowDesignerController : MyController
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Index1()
		{
			return View();
		}

		public ActionResult Open()
		{
			return View();
		}

		[MyAttribute(CheckApp = false)]
		public ActionResult Open_Tree()
		{
			return View();
		}

		[MyAttribute(CheckApp = false)]
		public ActionResult Open_Tree1()
		{
			return View();
		}

		[MyAttribute(CheckApp = false)]
		public ActionResult Open_List()
		{
			return View();
		}

		[MyAttribute(CheckApp = false)]
		public ActionResult Open_List1()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public string Query()
		{
			new List<RoadFlow.Data.Model.WorkFlow>();
			RoadFlow.Platform.Users users = new RoadFlow.Platform.Users();
			RoadFlow.Platform.WorkFlow workFlow = new RoadFlow.Platform.WorkFlow();
			string name = base.Request.Form["flow_name"];
			string str = base.Request.Form["typeid"];
			string text = base.Request.Form["sidx"];
			string text2 = base.Request.Form["sord"];
			bool flag = "1" == base.Request.Form["openlist"];
			string typeid = "";
			if (str.IsGuid())
			{
				typeid = new RoadFlow.Platform.Dictionary().GetAllChildsIDString(str.ToGuid());
			}
			int num = flag ? 10 : RoadFlow.Utility.Tools.GetPageSize();
			int pageNumber = RoadFlow.Utility.Tools.GetPageNumber();
			string order = (text.IsNullOrEmpty() ? "CreateDate" : text) + " " + (text2.IsNullOrEmpty() ? "asc" : text2);
			long count;
			List<RoadFlow.Data.Model.WorkFlow> pagerData = workFlow.GetPagerData(out count, num, pageNumber, RoadFlow.Platform.Users.CurrentUserID.ToString(), typeid, name, order);
			JsonData jsonData = new JsonData();
			foreach (RoadFlow.Data.Model.WorkFlow item in pagerData)
			{
				JsonData jsonData2 = new JsonData();
				jsonData2["id"] = item.ID.ToString();
				jsonData2["Name"] = item.Name;
				jsonData2["CreateDate"] = item.CreateDate.ToDateTimeString();
				jsonData2["CreateUserID"] = users.GetName(item.CreateUserID);
				jsonData2["Status"] = workFlow.GetStatusTitle(item.Status);
				if (flag)
				{
					jsonData2["Edit"] = "<a href=\"javascript:void(0);\" onclick=\"openflow('" + item.ID + "');return false;\"><img src=\"" + base.Url.Content("~/Images/ico/topic_edit.gif") + "\" alt=\"\" style=\"vertical-align:middle; border:0;\" /><span style=\"vertical-align:middle; margin-left:3px;\">编辑</span></a>";
				}
				else
				{
					jsonData2["Edit"] = "<a class=\"editlink\" href=\"javascript:void(0);\" onclick=\"openflow('" + item.ID + "','" + item.Name + "');return false;\"><span style=\"vertical-align:middle;\">编辑</span></a><a class=\"deletelink\" href=\"javascript:void(0);\" style=\"margin-left:5px\" onclick=\"delflow('" + item.ID + "'); return false;\"><span style=\"vertical-align:middle;\">删除</span></a><a href=\"javascript:void(0);\" style=\"margin-left:5px\" onclick=\"ExportFlow('" + item.ID + "'); return false;\"><span style=\"vertical-align:middle; background:url(../Images/ico/arrow_medium_right.png) no-repeat;padding-left:18px;\">导出</span></a>";
				}
				jsonData.Add(jsonData2);
			}
			return "{\"userdata\":{\"total\":" + count + ",\"pagesize\":" + num + ",\"pagenumber\":" + pageNumber + "},\"rows\":" + jsonData.ToJson() + "}";
		}

		[MyAttribute(CheckApp = false, CheckLogin = false, CheckUrl = false)]
		public string GetJSON()
		{
			string msg;
			if (!WebMvc.Common.Tools.CheckLogin(out msg) && !RoadFlow.Platform.WeiXin.Organize.CheckLogin())
			{
				return "{}";
			}
			string str = base.Request.QueryString["flowid"];
			string b = base.Request.QueryString["type"];
			if (!str.IsGuid())
			{
				return "{}";
			}
			RoadFlow.Data.Model.WorkFlow workFlow = new RoadFlow.Platform.WorkFlow().Get(str.ToGuid());
			if (workFlow == null)
			{
				return "{}";
			}
			if (!("0" == b))
			{
				return workFlow.DesignJSON;
			}
			return workFlow.RunJSON;
		}

		[MyAttribute(CheckApp = false)]
		public ActionResult Set_Flow()
		{
			return View();
		}

		[MyAttribute(CheckApp = false)]
		public string GetTables()
		{
			string msg;
			if (!WebMvc.Common.Tools.CheckLogin(out msg))
			{
				return "";
			}
			base.Response.Charset = "utf-8";
			string str = base.Request.QueryString["connid"];
			if (!str.IsGuid())
			{
				return "[]";
			}
			List<string> tables = new RoadFlow.Platform.DBConnection().GetTables(str.ToGuid());
			StringBuilder stringBuilder = new StringBuilder("[", 1000);
			foreach (string item in tables)
			{
				stringBuilder.Append("{\"name\":");
				stringBuilder.AppendFormat("\"{0}\"", item);
				stringBuilder.Append("},");
			}
			return stringBuilder.ToString().TrimEnd(',') + "]";
		}

		[MyAttribute(CheckApp = false)]
		public string GetFields()
		{
			string msg;
			if (!WebMvc.Common.Tools.CheckLogin(out msg))
			{
				return "";
			}
			string text = base.Request.QueryString["table"];
			string str = base.Request.QueryString["connid"];
			if (text.IsNullOrEmpty() || !str.IsGuid())
			{
				return "[]";
			}
			Dictionary<string, string> fields = new RoadFlow.Platform.DBConnection().GetFields(str.ToGuid(), text);
			StringBuilder stringBuilder = new StringBuilder("[", 1000);
			foreach (KeyValuePair<string, string> item in fields)
			{
				stringBuilder.Append("{");
				stringBuilder.AppendFormat("\"name\":\"{0}\",\"note\":\"{1}\"", item.Key, item.Value);
				stringBuilder.Append("},");
			}
			return stringBuilder.ToString().TrimEnd(',') + "]";
		}

		[MyAttribute(CheckApp = false)]
		public ActionResult Set_Step()
		{
			return View();
		}

		[MyAttribute(CheckApp = false)]
		public ActionResult Set_SubFlow()
		{
			return View();
		}

		[MyAttribute(CheckApp = false)]
		public ActionResult Set_Line()
		{
			return View();
		}

		public ActionResult Opation()
		{
			return View();
		}

		[MyAttribute(CheckApp = false)]
		public ActionResult Save()
		{
			return View();
		}

		[MyAttribute(CheckApp = false)]
		public ActionResult Install()
		{
			return View();
		}

		[MyAttribute(CheckApp = false)]
		public ActionResult UnInstall()
		{
			return View();
		}

		[MyAttribute(CheckApp = false)]
		public ActionResult SaveAs()
		{
			return View();
		}

		[MyAttribute(CheckApp = false)]
		public string TestLineSqlWhere()
		{
			string msg;
			if (!WebMvc.Common.Tools.CheckLogin(out msg))
			{
				return "";
			}
			string str = base.Request["connid"];
			string str2 = base.Request["table"];
			string text = base.Request["tablepk"];
			string str3 = base.Request["where"] ?? "";
			RoadFlow.Platform.DBConnection dBConnection = new RoadFlow.Platform.DBConnection();
			if (!str.IsGuid())
			{
				return "流程未设置数据连接!";
			}
			RoadFlow.Data.Model.DBConnection dBConnection2 = dBConnection.Get(str.ToGuid());
			if (dBConnection2 == null)
			{
				return "未找到连接!";
			}
			string sql = "SELECT * FROM " + str2 + " WHERE 1=1 AND " + str3.FilterWildcard();
			if (dBConnection.TestSql(dBConnection2, sql))
			{
				return "SQL条件正确!";
			}
			return "SQL条件错误!";
		}

		[MyAttribute(CheckApp = false)]
		public void Export()
		{
			string msg;
			if (WebMvc.Common.Tools.CheckLogin(out msg))
			{
				string str = new RoadFlow.Platform.WorkFlow().Export(base.Request.QueryString["flowid"].ToGuid(), 1);
				if (!str.IsNullOrEmpty())
				{
					base.Response.Redirect("../Files/Show?id=" + str.DesEncrypt() + "&appid=" + base.Request.QueryString["appid"] + "&tabid=" + base.Request.QueryString["tabid"]);
				}
				else
				{
					base.Response.Write("导出失败");
					base.Response.End();
				}
			}
		}

		[MyAttribute(CheckApp = false)]
		public ActionResult Import()
		{
			return Import(null);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[MyAttribute(CheckApp = false)]
		public ActionResult Import(FormCollection collection)
		{
			if (collection != null)
			{
				HttpPostedFileBase httpPostedFileBase = base.Request.Files["FileUpload1"];
				if (httpPostedFileBase == null || httpPostedFileBase.FileName.IsNullOrEmpty())
				{
					base.ViewBag.script = "alert('请选择要导入的文件!');";
					return View();
				}
				string text = RoadFlow.Utility.Config.FilePath + "WorkFlowImportFiles\\" + Guid.NewGuid().ToString("N");
				if (!Directory.Exists(text))
				{
					Directory.CreateDirectory(text);
				}
				string text2 = text + "\\" + httpPostedFileBase.FileName;
				httpPostedFileBase.SaveAs(text2);
				string text3 = new RoadFlow.Platform.WorkFlow().Import(text2, 1);
				if ("1" == text3)
				{
					base.ViewBag.script = "alert('导入成功!');new RoadUI.Window().reloadOpener();";
				}
				else
				{
					base.ViewBag.script = "alert('" + text3 + "');new RoadUI.Window().reloadOpener();";
				}
			}
			return View();
		}
	}
}
