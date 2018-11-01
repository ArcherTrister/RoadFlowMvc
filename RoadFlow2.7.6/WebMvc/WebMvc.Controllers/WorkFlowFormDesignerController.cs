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
	public class WorkFlowFormDesignerController : MyController
	{
		[MyAttribute(CheckApp = false)]
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Index1()
		{
			return View();
		}

		public ActionResult Open_Tree1()
		{
			return View();
		}

		public ActionResult Open_List1(FormCollection collection)
		{
			return View();
		}

		[HttpPost]
		[MyAttribute(CheckApp = false)]
		public string Query()
		{
			new List<RoadFlow.Data.Model.WorkFlowForm>();
			RoadFlow.Platform.WorkFlowForm workFlowForm = new RoadFlow.Platform.WorkFlowForm();
			string text = base.Request.Form["form_name"];
			string text2 = base.Request.Form["typeid"];
			string text3 = base.Request.Form["sidx"];
			string text4 = base.Request.Form["sord"];
			bool flag = "1" == base.Request.Form["openlist"];
			string typeid = "";
			if (text2.IsGuid())
			{
				typeid = new RoadFlow.Platform.Dictionary().GetAllChildsIDString(text2.ToGuid());
			}
			int num = flag ? 10 : RoadFlow.Utility.Tools.GetPageSize();
			int pageNumber = RoadFlow.Utility.Tools.GetPageNumber();
			string order = (text3.IsNullOrEmpty() ? "WriteTime" : text3) + " " + (text4.IsNullOrEmpty() ? "asc" : text4);
			string text5 = "&appid=" + base.Request.QueryString["appid"] + "&typeid=" + text2 + "&name=" + text.UrlEncode();
			long count;
			List<RoadFlow.Data.Model.WorkFlowForm> pagerData = workFlowForm.GetPagerData(out count, num, pageNumber, "", typeid, text, order);
			JsonData jsonData = new JsonData();
			foreach (RoadFlow.Data.Model.WorkFlowForm item in pagerData)
			{
				JsonData jsonData2 = new JsonData();
				jsonData2["id"] = item.ID.ToString();
				jsonData2["Name"] = item.Name;
				jsonData2["CreateUserName"] = item.CreateUserName;
				jsonData2["CreateTime"] = item.CreateTime.ToDateTimeString();
				jsonData2["LastModifyTime"] = item.LastModifyTime.ToDateTimeString();
				if (flag)
				{
					jsonData2["Edit"] = string.Format("<a href=\"javascript:void(0);\" onclick=\"openform('{0}');return false;\"><img src=\"{1}/Images/ico/topic_edit.gif\" alt=\"\" style=\"vertical-align:middle; border:0;\" /><span style=\"vertical-align:middle;margin-left:2px;\">编辑</span></a><a href=\"javascript:void(0);\" onclick=\"delform('{0}');return false;\"><img src=\"{1}/Images/ico/topic_del.gif\" alt=\"\" style=\"vertical-align:middle; border:0; margin-left:5px;\" /><span style=\"vertical-align:middle;margin-left:2px;\">删除</span></a>", item.ID.ToString(), WebMvc.Common.Tools.BaseUrl);
				}
				else
				{
					jsonData2["Edit"] = "<a class=\"editlink\" href=\"javascript:void(0);\" onclick=\"openform('" + item.ID.ToString() + "','" + item.Name + "');return false;\"><span style=\"vertical-align:middle;\">编辑</span></a><a class=\"deletelink\" href=\"javascript:void(0);\" style=\"margin-left:5px;\" onclick=\"delform('" + item.ID.ToString() + "'); return false;\"><span style=\"vertical-align:middle;\">删除</span></a><a href=\"javascript:void(0);\" style=\"margin-left:5px;\" onclick=\"ExportForm('" + item.ID.ToString() + "'); return false;\"><span style=\"vertical-align:middle; background:url(../Images/ico/arrow_medium_right.png) no-repeat;padding-left:18px;\">导出</span></a>";
				}
				jsonData.Add(jsonData2);
			}
			return "{\"userdata\":{\"total\":" + count + ",\"pagesize\":" + num + ",\"pagenumber\":" + pageNumber + "},\"rows\":" + jsonData.ToJson() + "}";
		}

		[MyAttribute(CheckApp = false)]
		public string GetHtml()
		{
			Guid test;
			if (!base.Request["id"].IsGuid(out test))
			{
				return "";
			}
			RoadFlow.Data.Model.WorkFlowForm workFlowForm = new RoadFlow.Platform.WorkFlowForm().Get(test);
			if (workFlowForm == null)
			{
				return "";
			}
			return workFlowForm.Html;
		}

		[MyAttribute(CheckApp = false)]
		public string GetAttribute()
		{
			Guid test;
			if (!base.Request["id"].IsGuid(out test))
			{
				return "";
			}
			RoadFlow.Data.Model.WorkFlowForm workFlowForm = new RoadFlow.Platform.WorkFlowForm().Get(test);
			if (workFlowForm == null)
			{
				return "";
			}
			return workFlowForm.Attribute;
		}

		[MyAttribute(CheckApp = false)]
		public string Getsubtable()
		{
			Guid test;
			if (!base.Request["id"].IsGuid(out test))
			{
				return "";
			}
			RoadFlow.Data.Model.WorkFlowForm workFlowForm = new RoadFlow.Platform.WorkFlowForm().Get(test);
			if (workFlowForm == null)
			{
				return "";
			}
			return workFlowForm.SubTableJson;
		}

		[MyAttribute(CheckApp = false)]
		public string GetEvents()
		{
			Guid test;
			if (!base.Request["id"].IsGuid(out test))
			{
				return "";
			}
			RoadFlow.Data.Model.WorkFlowForm workFlowForm = new RoadFlow.Platform.WorkFlowForm().Get(test);
			if (workFlowForm == null)
			{
				return "";
			}
			return workFlowForm.EventsJson;
		}

		[MyAttribute(CheckApp = false)]
		public string TestSql()
		{
			string str = base.Request["sql"];
			string str2 = base.Request["dbconn"];
			if (str.IsNullOrEmpty() || !str2.IsGuid())
			{
				return "SQL语句为空或未设置数据连接";
			}
			RoadFlow.Platform.DBConnection dBConnection = new RoadFlow.Platform.DBConnection();
			RoadFlow.Data.Model.DBConnection dbconn = dBConnection.Get(str2.ToGuid());
			if (dBConnection.TestSql(dbconn, str.ReplaceSelectSql().FilterWildcard()))
			{
				return "SQL语句测试正确";
			}
			return "SQL语句测试错误";
		}

		[MyAttribute(CheckApp = false)]
		public string Save()
		{
			string html = base.Request["html"];
			string text = base.Request["name"];
			string attribute = base.Request["att"];
			string str = base.Request["id"];
			string str2 = base.Request["type"];
			string subTableJson = base.Request["subtable"];
			string eventsJson = base.Request["formEvents"];
			if (text.IsNullOrEmpty())
			{
				return "表单名称不能为空!";
			}
			Guid test;
			if (!str.IsGuid(out test))
			{
				return "表单ID无效!";
			}
			RoadFlow.Platform.WorkFlowForm workFlowForm = new RoadFlow.Platform.WorkFlowForm();
			RoadFlow.Data.Model.WorkFlowForm workFlowForm2 = workFlowForm.Get(test);
			bool flag = false;
			string oldXML = string.Empty;
			if (workFlowForm2 == null)
			{
				workFlowForm2 = new RoadFlow.Data.Model.WorkFlowForm();
				workFlowForm2.ID = test;
				workFlowForm2.CreateUserID = RoadFlow.Platform.Users.CurrentUserID;
				workFlowForm2.CreateUserName = RoadFlow.Platform.Users.CurrentUserName;
				workFlowForm2.CreateTime = DateTimeNew.Now;
				workFlowForm2.Status = 0;
				flag = true;
			}
			else
			{
				oldXML = workFlowForm2.Serialize();
			}
			workFlowForm2.Attribute = attribute;
			workFlowForm2.Html = html;
			workFlowForm2.LastModifyTime = DateTimeNew.Now;
			workFlowForm2.Name = text;
			workFlowForm2.Type = str2.ToGuid();
			workFlowForm2.SubTableJson = subTableJson;
			workFlowForm2.EventsJson = eventsJson;
			if (flag)
			{
				workFlowForm.Add(workFlowForm2);
				RoadFlow.Platform.Log.Add("添加了流程表单", workFlowForm2.Serialize(), RoadFlow.Platform.Log.Types.流程相关);
			}
			else
			{
				workFlowForm.Update(workFlowForm2);
				RoadFlow.Platform.Log.Add("修改了流程表单", "", RoadFlow.Platform.Log.Types.流程相关, oldXML, workFlowForm2.Serialize());
			}
			return "保存成功!";
		}

		[HttpPost]
		[MyAttribute(CheckApp = false, CheckLogin = false)]
		public string GetSubTableData()
		{
			string msg;
			if (!WebMvc.Common.Tools.CheckLogin(out msg) && !RoadFlow.Platform.WeiXin.Organize.CheckLogin())
			{
				return "{}";
			}
			string secondTable = base.Request["secondtable"];
			string text3 = base.Request["primarytablefiled"];
			string text = base.Request["secondtableprimarykey"];
			string fieldValue = base.Request["primarytablefiledvalue"];
			string relationField = base.Request["secondtablerelationfield"];
			string connID = base.Request["dbconnid"];
			string fieldFormat = base.Request["subtableformat"];
			string text2 = base.Request["sortstring"];
			string sortField = text2.IsNullOrEmpty() ? text : text2;
			return new RoadFlow.Platform.WorkFlow().GetSubTableData(connID, secondTable, relationField, fieldValue, sortField, fieldFormat).ToJson();
		}

		[MyAttribute(CheckApp = false)]
		public string Publish()
		{
			string text = base.Request["html"];
			string text2 = base.Request["name"];
			string text3 = base.Request["att"];
			string text4 = base.Request["id"];
			string str = base.Request["formats"];
			Guid test;
			if (!text4.IsGuid(out test) || text2.IsNullOrEmpty() || text3.IsNullOrEmpty())
			{
				return "参数错误!";
			}
			RoadFlow.Platform.WorkFlowForm workFlowForm = new RoadFlow.Platform.WorkFlowForm();
			RoadFlow.Data.Model.WorkFlowForm workFlowForm2 = workFlowForm.Get(test);
			if (workFlowForm2 == null)
			{
				return "请先保存表单再发布!";
			}
			string str2 = text4 + ".cshtml";
			StringBuilder stringBuilder = new StringBuilder("@{\r\n");
			JsonData jsonData = JsonMapper.ToObject(text3);
			stringBuilder.Append("\tstring FlowID = Request.QueryString[\"flowid\"];\r\n");
			stringBuilder.Append("\tstring StepID = Request.QueryString[\"stepid\"];\r\n");
			stringBuilder.Append("\tstring GroupID = Request.QueryString[\"groupid\"];\r\n");
			stringBuilder.Append("\tstring TaskID = Request.QueryString[\"taskid\"];\r\n");
			stringBuilder.Append("\tstring InstanceID = Request.QueryString[\"instanceid\"];\r\n");
			stringBuilder.Append("\tstring DisplayModel = Request.QueryString[\"display\"] ?? \"0\";\r\n");
			stringBuilder.AppendFormat("\tstring DBConnID = \"{0}\";\r\n", jsonData["dbconn"].ToString());
			stringBuilder.AppendFormat("\tstring DBTable = \"{0}\";\r\n", jsonData["dbtable"].ToString());
			stringBuilder.AppendFormat("\tstring DBTablePK = \"{0}\";\r\n", jsonData["dbtablepk"].ToString());
			stringBuilder.AppendFormat("\tstring DBTableTitle = \"{0}\";\r\n", jsonData["dbtabletitle"].ToString());
			stringBuilder.Append("\tif(InstanceID.IsNullOrEmpty()){InstanceID = Request.QueryString[\"instanceid1\"];}\r\n");
			stringBuilder.Append("\tRoadFlow.Platform.Dictionary BDictionary = new RoadFlow.Platform.Dictionary();\r\n");
			stringBuilder.Append("\tRoadFlow.Platform.WorkFlow BWorkFlow = new RoadFlow.Platform.WorkFlow();\r\n");
			stringBuilder.Append("\tRoadFlow.Platform.WorkFlowTask BWorkFlowTask = new RoadFlow.Platform.WorkFlowTask();\r\n");
			stringBuilder.Append("\tstring fieldStatus = BWorkFlow.GetFieldStatus(FlowID, StepID);\r\n");
			stringBuilder.Append("\tLitJson.JsonData initData = BWorkFlow.GetFormData(DBConnID, DBTable, DBTablePK, InstanceID, fieldStatus, \"" + str + "\");\r\n");
			stringBuilder.Append("\tstring TaskTitle = BWorkFlow.GetFromFieldData(initData, DBTable, DBTableTitle);\r\n");
			stringBuilder.Append("}\r\n");
			stringBuilder.Append("<link href=\"~/Scripts/FlowRun/Forms/flowform.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n");
			stringBuilder.Append("<script src=\"~/Scripts/FlowRun/Forms/common.js\" type=\"text/javascript\" ></script>\r\n");
			if (jsonData.ContainsKey("hasEditor") && "1" == jsonData["hasEditor"].ToString())
			{
				stringBuilder.Append("<script src=\"~/Scripts/Ueditor/ueditor.config.js\" type=\"text/javascript\" ></script>\r\n");
				stringBuilder.Append("<script src=\"~/Scripts/Ueditor/ueditor.all.min.js\" type=\"text/javascript\" ></script>\r\n");
				stringBuilder.Append("<script src=\"~/Scripts/Ueditor/lang/zh-cn/zh-cn.js\" type=\"text/javascript\" ></script>\r\n");
				stringBuilder.Append("<input type=\"hidden\" id=\"Form_HasUEditor\" name=\"Form_HasUEditor\" value=\"1\" />\r\n");
			}
			string str3 = jsonData.ContainsKey("validatealerttype") ? jsonData["validatealerttype"].ToString() : "2";
			stringBuilder.Append("<input type=\"hidden\" id=\"Form_ValidateAlertType\" name=\"Form_ValidateAlertType\" value=\"" + str3 + "\" />\r\n");
			if (jsonData.ContainsKey("autotitle") && jsonData["autotitle"].ToString().ToLower() == "true")
			{
				stringBuilder.AppendFormat("<input type=\"hidden\" id=\"{0}\" name=\"{0}\" value=\"{1}\" />\r\n", jsonData["dbtable"].ToString() + "." + jsonData["dbtabletitle"].ToString(), "@(TaskTitle.IsNullOrEmpty() ? BWorkFlow.GetAutoTaskTitle(FlowID, StepID, Request.QueryString[\"groupid\"]) : TaskTitle)");
			}
			stringBuilder.AppendFormat("<input type=\"hidden\" id=\"Form_TitleField\" name=\"Form_TitleField\" value=\"{0}\" />\r\n", jsonData["dbtable"].ToString() + "." + jsonData["dbtabletitle"].ToString());
			stringBuilder.AppendFormat("<input type=\"hidden\" id=\"Form_DBConnID\" name=\"Form_DBConnID\" value=\"{0}\" />\r\n", jsonData["dbconn"].ToString());
			stringBuilder.AppendFormat("<input type=\"hidden\" id=\"Form_DBTable\" name=\"Form_DBTable\" value=\"{0}\" />\r\n", jsonData["dbtable"].ToString());
			stringBuilder.AppendFormat("<input type=\"hidden\" id=\"Form_DBTablePk\" name=\"Form_DBTablePk\" value=\"{0}\" />\r\n", jsonData["dbtablepk"].ToString());
			stringBuilder.AppendFormat("<input type=\"hidden\" id=\"Form_DBTableTitle\" name=\"Form_DBTableTitle\" value=\"{0}\" />\r\n", jsonData["dbtabletitle"].ToString());
			stringBuilder.AppendFormat("<input type=\"hidden\" id=\"Form_AutoSaveData\" name=\"Form_AutoSaveData\" value=\"{0}\" />\r\n", "1");
			stringBuilder.AppendFormat("<textarea id=\"Form_DBTableTitleExpression\" name=\"Form_DBTableTitleExpression\" style=\"display:none;width:0;height:0;\">{0}</textarea>\r\n", jsonData.ContainsKey("dbtabletitle1") ? jsonData["dbtabletitle1"].ToString() : "");
			stringBuilder.Append("<script type=\"text/javascript\">\r\n");
			stringBuilder.Append("\tvar initData = @Html.Raw(BWorkFlow.GetFormDataJsonString(initData));\r\n");
			stringBuilder.Append("\tvar fieldStatus = \"1\"==\"@Request.QueryString[\"isreadonly\"]\" ? {} : @Html.Raw(fieldStatus);\r\n");
			stringBuilder.Append("\tvar displayModel = '@DisplayModel';\r\n");
			stringBuilder.Append("\t$(window).load(function (){\r\n");
			stringBuilder.AppendFormat("\t\tformrun.initData(initData, \"{0}\", fieldStatus, displayModel);\r\n", jsonData["dbtable"].ToString());
			stringBuilder.Append("\t});\r\n");
			stringBuilder.Append("</script>\r\n");
			FileStream fileStream = System.IO.File.Open(base.Server.MapPath("~/Views/WorkFlowFormDesigner/Forms/" + str2), FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
			fileStream.SetLength(0L);
			StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.UTF8);
			streamWriter.Write(stringBuilder.ToString());
			streamWriter.Write(base.Server.HtmlDecode(text));
			streamWriter.Close();
			fileStream.Close();
			string str4 = JsonMapper.ToObject(workFlowForm2.Attribute)["apptype"].ToString();
			RoadFlow.Platform.AppLibrary appLibrary = new RoadFlow.Platform.AppLibrary();
			RoadFlow.Data.Model.AppLibrary appLibrary2 = appLibrary.GetByCode(text4);
			bool flag = false;
			if (appLibrary2 == null)
			{
				appLibrary2 = new RoadFlow.Data.Model.AppLibrary();
				appLibrary2.ID = Guid.NewGuid();
				appLibrary2.Code = text4;
				flag = true;
			}
			appLibrary2.Address = "/Views/WorkFlowFormDesigner/Forms/" + str2;
			appLibrary2.Note = "流程表单";
			appLibrary2.OpenMode = 0;
			appLibrary2.Params = "";
			appLibrary2.Title = text2.Trim();
			appLibrary2.Type = (str4.IsGuid() ? str4.ToGuid() : new RoadFlow.Platform.Dictionary().GetIDByCode("FormTypes"));
			if (flag)
			{
				appLibrary.Add(appLibrary2);
			}
			else
			{
				appLibrary.Update(appLibrary2);
			}
			RoadFlow.Platform.Log.Add("发布了流程表单", appLibrary2.Serialize() + "内容：" + text, RoadFlow.Platform.Log.Types.流程相关);
			workFlowForm2.Status = 1;
			workFlowForm.Update(workFlowForm2);
			return "发布成功!";
		}

		[MyAttribute(CheckApp = false, CheckLogin = false)]
		public string GetFormGridHtml()
		{
			string msg;
			if (!WebMvc.Common.Tools.CheckLogin(out msg) && !RoadFlow.Platform.WeiXin.Organize.CheckLogin())
			{
				return "";
			}
			string connID = base.Request.Form["dbconnid"];
			string dataFormat = base.Request.Form["dataformat"];
			string dataSource = base.Request.Form["datasource"];
			string str = base.Request.Form["datasource1"] ?? "";
			string @params = base.Request.Form["params"];
			return new RoadFlow.Platform.WorkFlowForm().GetFormGridHtml(connID, dataFormat, dataSource, str.FilterWildcard(), @params);
		}

		[MyAttribute(CheckApp = false)]
		public void Export()
		{
			string str = new RoadFlow.Platform.WorkFlowForm().Export(base.Request.QueryString["formid"].ToGuid(), 1);
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
				string text = RoadFlow.Utility.Config.FilePath + "WorkFlowFormImportFiles\\" + Guid.NewGuid().ToString("N");
				if (!Directory.Exists(text))
				{
					Directory.CreateDirectory(text);
				}
				string text2 = text + "\\" + httpPostedFileBase.FileName;
				httpPostedFileBase.SaveAs(text2);
				string text3 = new RoadFlow.Platform.WorkFlowForm().Import(text2, 1);
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
