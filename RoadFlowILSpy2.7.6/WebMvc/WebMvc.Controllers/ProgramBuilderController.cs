using LitJson;
using RoadFlow.Data.Model;
using RoadFlow.Platform;
using RoadFlow.Platform.WeiXin;
using RoadFlow.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using WebMvc.Common;

namespace WebMvc.Controllers
{
	public class ProgramBuilderController : MyController
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult List()
		{
			return List(null);
		}

		[HttpPost]
		public ActionResult List(FormCollection form)
		{
			RoadFlow.Platform.ProgramBuilder programBuilder = new RoadFlow.Platform.ProgramBuilder();
			string text = base.Request.QueryString["Name1"];
			string text2 = base.Request.QueryString["typeid"];
			if (!base.Request.Form["delete"].IsNullOrEmpty())
			{
				string[] array = (base.Request.Form["checkbox_app"] ?? "").Split(',');
				foreach (string text3 in array)
				{
					if (text3.IsGuid())
					{
						programBuilder.DeleteAllSet(text3.ToGuid());
						RoadFlow.Platform.Log.Add("删除的应用程序设计", text3, RoadFlow.Platform.Log.Types.系统管理);
					}
				}
			}
			if (!base.Request.Form["publish"].IsNullOrEmpty())
			{
				string obj = base.Request.Form["checkbox_app"] ?? "";
				int num = 0;
				string[] array = obj.Split(',');
				foreach (string str in array)
				{
					if (str.IsGuid())
					{
						num += (programBuilder.Publish(str.ToGuid(), true) ? 1 : 0);
					}
				}
				base.ViewBag.script = "alert('成功发布" + num.ToString() + "个应用!');";
			}
			if (form != null)
			{
				text = base.Request.Form["Name1"];
			}
			string text4 = "&appid=" + base.Request.QueryString["appid"] + "&tabid=" + base.Request.QueryString["tabid"] + "&typeid=" + text2 + "&Name1=" + text;
			string pager;
			List<RoadFlow.Data.Model.ProgramBuilder> list = programBuilder.GetList(out pager, text4, text, text2);
			base.ViewBag.pager = pager;
			base.ViewBag.query1 = text4;
			return View(list);
		}

		public ActionResult Tree()
		{
			return View();
		}

		public ActionResult Add()
		{
			return View();
		}

		public ActionResult Set_Attr()
		{
			return Set_Attr(null);
		}

		[HttpPost]
		public ActionResult Set_Attr(FormCollection form)
		{
			RoadFlow.Data.Model.ProgramBuilder programBuilder = null;
			RoadFlow.Platform.ProgramBuilder programBuilder2 = new RoadFlow.Platform.ProgramBuilder();
			RoadFlow.Platform.Dictionary dictionary = new RoadFlow.Platform.Dictionary();
			string value = "1";
			string value2 = "1";
			string value3 = "";
			string value4 = "";
			string text = string.Empty;
			string value5 = base.Request.QueryString["typeid"];
			string str = base.Request.QueryString["pid"];
			string text2 = "";
			string text3 = "";
			if (str.IsGuid())
			{
				programBuilder = programBuilder2.Get(str.ToGuid());
				if (programBuilder != null)
				{
					value5 = programBuilder.Type.ToString();
					value = programBuilder.IsAdd.ToString();
					value2 = programBuilder.IsPager.ToString();
					value3 = programBuilder.DBConnID.ToString();
					text2 = programBuilder.TableName;
					text3 = programBuilder.InDataNumberFiledName;
					if (programBuilder.FormID.IsGuid())
					{
						text = programBuilder.FormID.ToString();
						RoadFlow.Data.Model.AppLibrary appLibrary = new RoadFlow.Platform.AppLibrary().Get(programBuilder.FormID.ToGuid());
						if (appLibrary != null)
						{
							value4 = appLibrary.Type.ToString();
						}
					}
				}
			}
			base.ViewBag.TypeOptions = new RoadFlow.Platform.AppLibrary().GetTypeOptions(value5);
			base.ViewBag.IsAddOptions = dictionary.GetOptionsByCode("yesno", RoadFlow.Platform.Dictionary.OptionValueField.Value, value);
			base.ViewBag.IsPagerOptions = dictionary.GetOptionsByCode("yesno", RoadFlow.Platform.Dictionary.OptionValueField.Value, value2);
			base.ViewBag.DbConnOptions = new RoadFlow.Platform.DBConnection().GetAllOptions(value3);
			base.ViewBag.TypeOptions1 = new RoadFlow.Platform.AppLibrary().GetTypeOptions(value4);
			base.ViewBag.TableName = text2;
			base.ViewBag.InDataNumberFiledName = text3;
			base.ViewBag.formid = text;
			string text4 = "&appid=" + base.Request.QueryString["appid"] + "&tabid=" + base.Request.QueryString["tabid"] + "&typeid=" + base.Request.QueryString["typeid"] + "&Name1=" + base.Request.QueryString["Name1"];
			if (form != null)
			{
				string text5 = base.Request.Form["Title1"];
				string sQL = base.Request.Form["sql"];
				string str2 = base.Request.Form["Type"];
				string str3 = base.Request.Form["IsAdd"];
				string str4 = base.Request.Form["DBConnID"];
				string formID = base.Request.Form["form_forms"];
				string str5 = base.Request.Form["form_editmodel"];
				string width = base.Request.Form["form_editmodel_width"];
				string height = base.Request.Form["form_editmodel_height"];
				string str6 = base.Request.Form["ButtonLocation"];
				string str7 = base.Request.Form["IsPager"];
				string clientScript = base.Request.Form["ClientScript"];
				string exportTemplate = base.Request.Form["ExportTemplate"];
				string str8 = base.Request.Form["ExportHeaderText"];
				string str9 = base.Request.Form["ExportFileName"];
				string tableStyle = base.Request.Form["TableStyle"];
				string tableHead = base.Request.Form["TableHead"];
				string tableName = base.Request.Form["DBTable"];
				string inDataNumberFiledName = base.Request.Form["DBFiled"];
				bool flag = false;
				if (programBuilder == null)
				{
					flag = true;
					programBuilder = new RoadFlow.Data.Model.ProgramBuilder();
					programBuilder.ID = Guid.NewGuid();
					programBuilder.CreateTime = DateTimeNew.Now;
					programBuilder.CreateUser = RoadFlow.Platform.Users.CurrentUserID;
					programBuilder.Status = 0;
				}
				programBuilder.IsAdd = str3.ToInt(0);
				programBuilder.Name = text5.Trim();
				programBuilder.SQL = sQL;
				programBuilder.DBConnID = str4.ToGuid();
				programBuilder.Type = str2.ToGuid();
				programBuilder.FormID = formID;
				programBuilder.EditModel = str5.ToInt(0);
				programBuilder.Width = width;
				programBuilder.Height = height;
				programBuilder.ButtonLocation = str6.ToInt(0);
				programBuilder.IsPager = str7.ToInt(1);
				programBuilder.ClientScript = clientScript;
				programBuilder.ExportTemplate = exportTemplate;
				programBuilder.ExportHeaderText = str8.Trim1();
				programBuilder.ExportFileName = str9.Trim1();
				programBuilder.TableStyle = tableStyle;
				programBuilder.TableHead = tableHead;
				programBuilder.TableName = tableName;
				programBuilder.InDataNumberFiledName = inDataNumberFiledName;
				if (flag)
				{
					programBuilder2.Add(programBuilder);
				}
				else
				{
					programBuilder2.Update(programBuilder);
				}
				RoadFlow.Platform.Log.Add("保存了应用程序设计属性", programBuilder.Serialize());
				base.ViewBag.script = "alert('保存成功');parent.location='Add?pid=" + programBuilder.ID + text4 + "';";
			}
			if (programBuilder == null)
			{
				programBuilder = new RoadFlow.Data.Model.ProgramBuilder();
			}
			return View(programBuilder);
		}

		public ActionResult Set_ListField()
		{
			return Set_ListField(null);
		}

		[HttpPost]
		public ActionResult Set_ListField(FormCollection form)
		{
			RoadFlow.Platform.ProgramBuilderFields programBuilderFields = new RoadFlow.Platform.ProgramBuilderFields();
			List<RoadFlow.Data.Model.ProgramBuilderFields> list = new List<RoadFlow.Data.Model.ProgramBuilderFields>();
			string text = base.Request.QueryString["pid"];
			if (!base.Request.Form["delete"].IsNullOrEmpty())
			{
				string[] array = (base.Request.Form["checkbox_app"] ?? "").Split(',');
				foreach (string str in array)
				{
					programBuilderFields.Delete(str.ToGuid());
				}
				RoadFlow.Platform.Log.Add("删除了应用程序设计字段", text);
			}
			list = programBuilderFields.GetAll(text.ToGuid());
			string text2 = (list.Count > 0) ? list.Max((RoadFlow.Data.Model.ProgramBuilderFields p) => p.Sort).ToString() : "0";
			string text3 = "&appid=" + base.Request.QueryString["appid"] + "&tabid=" + base.Request.QueryString["tabid"] + "&typeid=" + base.Request.QueryString["typeid"] + "&Name1=" + base.Request.QueryString["Name1"] + "&pid=" + base.Request.QueryString["pid"] + "&maxSort=" + text2;
			base.ViewBag.query = text3;
			return View(list);
		}

		public ActionResult Set_ListField_Add()
		{
			return Set_ListField_Add(null);
		}

		[HttpPost]
		public ActionResult Set_ListField_Add(FormCollection form)
		{
			RoadFlow.Data.Model.ProgramBuilderFields programBuilderFields = null;
			RoadFlow.Platform.ProgramBuilderFields programBuilderFields2 = new RoadFlow.Platform.ProgramBuilderFields();
			RoadFlow.Platform.Dictionary dictionary = new RoadFlow.Platform.Dictionary();
			RoadFlow.Platform.ProgramBuilder programBuilder = new RoadFlow.Platform.ProgramBuilder();
			string str = base.Request.QueryString["pid"];
			string str2 = base.Request.QueryString["fid"];
			string str3 = base.Request.QueryString["maxSort"];
			string value = "";
			string value2 = "";
			string value3 = "";
			base.ViewBag.sort = (str3.ToInt() + 5).ToString();
			if (str2.IsGuid())
			{
				programBuilderFields = programBuilderFields2.Get(str2.ToGuid());
				if (programBuilderFields != null)
				{
					value = programBuilderFields.Field;
					value2 = programBuilderFields.ShowType.ToString();
					value3 = programBuilderFields.Align;
					base.ViewBag.sort = programBuilderFields.Sort.ToString();
				}
			}
			base.ViewBag.ShowTypeOptions = dictionary.GetOptionsByCode("programbuilder_showtype", RoadFlow.Platform.Dictionary.OptionValueField.Value, value2);
			base.ViewBag.AlignOptions = dictionary.GetOptionsByCode("programbuilder_align", RoadFlow.Platform.Dictionary.OptionValueField.Value, value3);
			base.ViewBag.FieldOptions = programBuilder.GetFieldsOptions(str.ToGuid(), value);
			if (form != null)
			{
				string field = base.Request.Form["Field"];
				string text = base.Request.Form["ShowTitle"];
				string str4 = base.Request.Form["ShowType"];
				string showFormat = base.Request.Form["ShowFormat"];
				string align = base.Request.Form["Align"];
				string width = base.Request.Form["Width"];
				string customString = base.Request.Form["CustomString"];
				string str5 = base.Request.Form["Sort"];
				bool flag = false;
				if (programBuilderFields == null)
				{
					flag = true;
					programBuilderFields = new RoadFlow.Data.Model.ProgramBuilderFields();
					programBuilderFields.ID = Guid.NewGuid();
					programBuilderFields.ProgramID = str.ToGuid();
				}
				programBuilderFields.Align = align;
				programBuilderFields.CustomString = customString;
				programBuilderFields.Field = field;
				programBuilderFields.ShowFormat = showFormat;
				programBuilderFields.ShowTitle = (text.IsNullOrEmpty() ? "" : text);
				programBuilderFields.ShowType = str4.ToInt();
				programBuilderFields.Sort = str5.ToInt();
				programBuilderFields.Width = width;
				if (flag)
				{
					programBuilderFields2.Add(programBuilderFields);
				}
				else
				{
					programBuilderFields2.Update(programBuilderFields);
				}
				base.ViewBag.script = "alert('保存成功!');window.location='Set_ListField" + base.Request.Url.Query + "';";
			}
			if (programBuilderFields == null)
			{
				programBuilderFields = new RoadFlow.Data.Model.ProgramBuilderFields();
			}
			return View(programBuilderFields);
		}

		public ActionResult Set_Query()
		{
			return Set_Query(null);
		}

		[HttpPost]
		public ActionResult Set_Query(FormCollection form)
		{
			List<RoadFlow.Data.Model.ProgramBuilderQuerys> list = new List<RoadFlow.Data.Model.ProgramBuilderQuerys>();
			RoadFlow.Platform.ProgramBuilderQuerys programBuilderQuerys = new RoadFlow.Platform.ProgramBuilderQuerys();
			string empty = string.Empty;
			string empty2 = string.Empty;
			empty2 = base.Request.QueryString["pid"];
			if (!base.Request.Form["delete"].IsNullOrEmpty())
			{
				string[] array = (base.Request.Form["checkbox_app"] ?? "").Split(',');
				foreach (string str in array)
				{
					programBuilderQuerys.Delete(str.ToGuid());
				}
				RoadFlow.Platform.Log.Add("删除了应用程序设计查询", empty2);
			}
			list = programBuilderQuerys.GetAll(empty2.ToGuid());
			empty = ((list.Count > 0) ? list.Max((RoadFlow.Data.Model.ProgramBuilderQuerys p) => p.Sort).ToString() : "0");
			string text = "&appid=" + base.Request.QueryString["appid"] + "&tabid=" + base.Request.QueryString["tabid"] + "&typeid=" + base.Request.QueryString["typeid"] + "&Name1=" + base.Request.QueryString["Name1"] + "&pid=" + base.Request.QueryString["pid"] + "&maxSort=" + empty;
			base.ViewBag.query = text;
			return View(list);
		}

		public ActionResult Set_Query_Add()
		{
			return Set_Query_Add(null);
		}

		[HttpPost]
		public ActionResult Set_Query_Add(FormCollection form)
		{
			RoadFlow.Platform.ProgramBuilder programBuilder = new RoadFlow.Platform.ProgramBuilder();
			RoadFlow.Platform.Dictionary dictionary = new RoadFlow.Platform.Dictionary();
			string empty = string.Empty;
			string empty2 = string.Empty;
			RoadFlow.Data.Model.ProgramBuilderQuerys programBuilderQuerys = null;
			RoadFlow.Platform.ProgramBuilderQuerys programBuilderQuerys2 = new RoadFlow.Platform.ProgramBuilderQuerys();
			empty = base.Request.QueryString["pid"];
			empty2 = base.Request.QueryString["queryid"];
			string text = ((base.Request.QueryString["maxSort"] ?? "0").ToInt() + 5).ToString();
			string value = "";
			string value2 = "";
			string value3 = "";
			string value4 = "";
			string value5 = "";
			if (empty2.IsGuid())
			{
				programBuilderQuerys = programBuilderQuerys2.Get(empty2.ToGuid());
				if (programBuilderQuerys != null)
				{
					value = programBuilderQuerys.Field;
					value2 = programBuilderQuerys.Operators;
					value3 = programBuilderQuerys.InputType.ToString();
					value4 = programBuilderQuerys.DataSource.ToString();
					value5 = programBuilderQuerys.DataLinkID;
					text = programBuilderQuerys.Sort.ToString();
				}
			}
			base.ViewBag.sort = text.ToString();
			base.ViewBag.FieldOptions = programBuilder.GetFieldsOptions(empty.ToGuid(), value);
			base.ViewBag.OperatorsOptions = dictionary.GetOptionsByCode("programbuilder_operators", RoadFlow.Platform.Dictionary.OptionValueField.Value, value2);
			base.ViewBag.InputTypeOptions = dictionary.GetOptionsByCode("programbuilder_inputtype", RoadFlow.Platform.Dictionary.OptionValueField.Value, value3);
			base.ViewBag.ControlHidden = RoadFlow.Utility.Tools.GetRandomString(6);
			base.ViewBag.DataSource = dictionary.GetRadiosByCode("programbuilder_datasource", "DataSource", RoadFlow.Platform.Dictionary.OptionValueField.Value, value4, "onclick=\"dataSourceChange(this.value)\";");
			base.ViewBag.DataSource_String_SQL_LinkOptions = new RoadFlow.Platform.DBConnection().GetAllOptions(value5);
			if (form != null)
			{
				string field = base.Request.Form["Field"];
				string showTitle = base.Request.Form["ShowTitle"];
				string controlName = base.Request.Form["ControlName"];
				string operators = base.Request.Form["Operators"];
				string str = base.Request.Form["InputType"];
				string width = base.Request.Form["Width"];
				string str2 = base.Request.Form["Sort"];
				string str3 = base.Request.Form["DataSource"];
				string dataLinkID = base.Request.Form["DataSource_String_SQL_Link"];
				bool flag = false;
				if (programBuilderQuerys == null)
				{
					flag = true;
					programBuilderQuerys = new RoadFlow.Data.Model.ProgramBuilderQuerys();
					programBuilderQuerys.ID = Guid.NewGuid();
					programBuilderQuerys.ProgramID = empty.ToGuid();
				}
				programBuilderQuerys.ControlName = controlName;
				programBuilderQuerys.Field = field;
				programBuilderQuerys.InputType = str.ToInt();
				programBuilderQuerys.Operators = operators;
				programBuilderQuerys.ShowTitle = showTitle;
				programBuilderQuerys.Sort = str2.ToInt();
				programBuilderQuerys.Width = width;
				programBuilderQuerys.DataLinkID = dataLinkID;
				if (programBuilderQuerys.InputType == 6)
				{
					if (str3.IsInt())
					{
						programBuilderQuerys.DataSource = str3.ToInt();
						if (programBuilderQuerys.DataSource == 1 || programBuilderQuerys.DataSource == 3)
						{
							programBuilderQuerys.DataSourceString = base.Request.Form["DataSource_String"];
						}
						else if (programBuilderQuerys.DataSource == 2)
						{
							programBuilderQuerys.DataSourceString = base.Request.Form["DataSource_Dict"];
						}
					}
					else
					{
						programBuilderQuerys.DataSource = null;
					}
				}
				else if (programBuilderQuerys.InputType == 8)
				{
					programBuilderQuerys.DataSourceString = base.Request.Form["DataSource_Dict_Value"];
				}
				else if (programBuilderQuerys.InputType == 7)
				{
					string text2 = base.Request.Form["DataSource_Organize_Range"];
					string text3 = base.Request.Form["DataSource_Organize_Type_Unit"];
					string text4 = base.Request.Form["DataSource_Organize_Type_Dept"];
					string text5 = base.Request.Form["DataSource_Organize_Type_Station"];
					string text6 = base.Request.Form["DataSource_Organize_Type_WorkGroup"];
					string text7 = base.Request.Form["DataSource_Organize_Type_Role"];
					string text8 = base.Request.Form["DataSource_Organize_Type_User"];
					string text9 = base.Request.Form["DataSource_Organize_Type_More"];
					string str4 = base.Request.Form["DataSource_Organize_Type_QueryUsers"];
					programBuilderQuerys.DataSourceString = text2 + "|" + text3 + "|" + text4 + "|" + text5 + "|" + text6 + "|" + text7 + "|" + text8 + "|" + text9;
					programBuilderQuerys.IsQueryUsers = str4.ToInt(0);
				}
				if (flag)
				{
					programBuilderQuerys2.Add(programBuilderQuerys);
				}
				else
				{
					programBuilderQuerys2.Update(programBuilderQuerys);
				}
				base.ViewBag.script = "alert('保存成功!');window.location='Set_Query" + base.Request.Url.Query + "';";
			}
			if (programBuilderQuerys == null)
			{
				programBuilderQuerys = new RoadFlow.Data.Model.ProgramBuilderQuerys();
			}
			return View(programBuilderQuerys);
		}

		public ActionResult Set_Button()
		{
			return Set_Button(null);
		}

		[HttpPost]
		public ActionResult Set_Button(FormCollection form)
		{
			string empty = string.Empty;
			string empty2 = string.Empty;
			List<RoadFlow.Data.Model.ProgramBuilderButtons> list = new List<RoadFlow.Data.Model.ProgramBuilderButtons>();
			RoadFlow.Platform.ProgramBuilderButtons programBuilderButtons = new RoadFlow.Platform.ProgramBuilderButtons();
			string str = base.Request.QueryString["pid"];
			if (form != null && !base.Request.Form["delete"].IsNullOrEmpty())
			{
				string[] array = (base.Request.Form["checkbox_app"] ?? "").Split(',');
				foreach (string str2 in array)
				{
					if (str2.IsGuid())
					{
						programBuilderButtons.Delete(str2.ToGuid());
					}
				}
			}
			list = (from p in programBuilderButtons.GetAll(str.ToGuid())
			orderby p.ShowType, p.Sort
			select p).ToList();
			empty2 = ((list.Count > 0) ? (list.Max((RoadFlow.Data.Model.ProgramBuilderButtons p) => p.Sort) + 5).ToString() : "0");
			empty = "&appid=" + base.Request.QueryString["appid"] + "&tabid=" + base.Request.QueryString["tabid"] + "&typeid=" + base.Request.QueryString["typeid"] + "&Name1=" + base.Request.QueryString["Name1"] + "&pid=" + base.Request.QueryString["pid"] + "&maxSort=" + empty2;
			base.ViewBag.query = empty;
			return View(list);
		}

		public ActionResult Set_Button_Add()
		{
			return Set_Button_Add(null);
		}

		[HttpPost]
		public ActionResult Set_Button_Add(FormCollection form)
		{
			RoadFlow.Platform.ProgramBuilderButtons programBuilderButtons = new RoadFlow.Platform.ProgramBuilderButtons();
			RoadFlow.Data.Model.ProgramBuilderButtons programBuilderButtons2 = null;
			string empty = string.Empty;
			string empty2 = string.Empty;
			empty = base.Request.QueryString["bid"];
			empty2 = base.Request.QueryString["pid"];
			string str = base.Request.QueryString["maxSort"];
			if (empty.IsGuid())
			{
				programBuilderButtons2 = programBuilderButtons.Get(empty.ToGuid());
			}
			if (form != null)
			{
				string buttonName = base.Request.Form["buttonname"];
				string clientScript = base.Request.Form["ClientScript"];
				string str2 = base.Request.Form["Sort"];
				string str3 = base.Request.Form["buttonid"];
				string ico = base.Request.Form["Ico"];
				string str4 = base.Request.Form["showtype"];
				string str5 = base.Request.Form["IsValidateShow"];
				bool flag = false;
				if (programBuilderButtons2 == null)
				{
					flag = true;
					programBuilderButtons2 = new RoadFlow.Data.Model.ProgramBuilderButtons();
					programBuilderButtons2.ID = Guid.NewGuid();
					programBuilderButtons2.ProgramID = empty2.ToGuid();
				}
				programBuilderButtons2.ButtonName = buttonName;
				programBuilderButtons2.ClientScript = clientScript;
				programBuilderButtons2.Sort = str2.ToInt(0);
				programBuilderButtons2.IsValidateShow = str5.ToInt(1);
				if (str3.IsGuid())
				{
					programBuilderButtons2.ButtonID = str3.ToGuid();
				}
				programBuilderButtons2.Ico = ico;
				programBuilderButtons2.ShowType = str4.ToInt(1);
				if (flag)
				{
					programBuilderButtons.Add(programBuilderButtons2);
				}
				else
				{
					programBuilderButtons.Update(programBuilderButtons2);
				}
				base.ViewBag.script = "alert('保存成功!');window.location='Set_Button" + base.Request.Url.Query + "';";
			}
			if (programBuilderButtons2 == null)
			{
				programBuilderButtons2 = new RoadFlow.Data.Model.ProgramBuilderButtons();
				programBuilderButtons2.Sort = str.ToInt();
				programBuilderButtons2.ShowType = 1;
			}
			return View(programBuilderButtons2);
		}

		public ActionResult Set_Validate()
		{
			return Set_Validate(null);
		}

		[HttpPost]
		public ActionResult Set_Validate(FormCollection form)
		{
			string str = base.Request.QueryString["pid"];
			RoadFlow.Platform.ProgramBuilderValidates programBuilderValidates = new RoadFlow.Platform.ProgramBuilderValidates();
			List<RoadFlow.Data.Model.ProgramBuilderValidates> list = new List<RoadFlow.Data.Model.ProgramBuilderValidates>();
			List<RoadFlow.Data.Model.ProgramBuilderValidates> list2 = new List<RoadFlow.Data.Model.ProgramBuilderValidates>();
			List<Tuple<string, string, string>> list3 = new List<Tuple<string, string, string>>();
			if (str.IsGuid())
			{
				RoadFlow.Data.Model.ProgramBuilder programBuilder = new RoadFlow.Platform.ProgramBuilder().Get(str.ToGuid());
				if (programBuilder != null && !programBuilder.FormID.IsNullOrEmpty() && programBuilder.FormID.IsGuid())
				{
					RoadFlow.Data.Model.AppLibrary appLibrary = new RoadFlow.Platform.AppLibrary().Get(programBuilder.FormID.ToGuid());
					if (appLibrary != null && appLibrary.Code.IsGuid())
					{
						RoadFlow.Data.Model.WorkFlowForm workFlowForm = new RoadFlow.Platform.WorkFlowForm().Get(appLibrary.Code.ToGuid());
						if (workFlowForm != null)
						{
							JsonData jsonData = JsonMapper.ToObject(workFlowForm.Attribute);
							string str2 = jsonData.ContainsKey("dbconn") ? jsonData["dbconn"].ToString() : "";
							string text = jsonData.ContainsKey("dbtable") ? jsonData["dbtable"].ToString() : "";
							if (str2.IsGuid() && !text.IsNullOrEmpty())
							{
								foreach (KeyValuePair<string, string> field in new RoadFlow.Platform.DBConnection().GetFields(str2.ToGuid(), text))
								{
									list3.Add(new Tuple<string, string, string>(text, field.Key, field.Value));
								}
							}
							JsonData jsonData2 = JsonMapper.ToObject(workFlowForm.SubTableJson);
							if (jsonData2.IsArray)
							{
								foreach (JsonData item3 in (IEnumerable)jsonData2)
								{
									string item = item3.ContainsKey("secondtable") ? item3["secondtable"].ToString() : "";
									if (item3.ContainsKey("colnums"))
									{
										JsonData jsonData4 = item3["colnums"];
										if (jsonData4.IsArray)
										{
											foreach (JsonData item4 in (IEnumerable)jsonData4)
											{
												string text2 = item4.ContainsKey("fieldname") ? item4["fieldname"].ToString() : "";
												string item2 = item4.ContainsKey("showname") ? item4["showname"].ToString() : "";
												if (!text2.IsNullOrEmpty())
												{
													list3.Add(new Tuple<string, string, string>(item, text2, item2));
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			list2 = programBuilderValidates.GetAll(str.ToGuid());
			foreach (Tuple<string, string, string> item5 in list3)
			{
				RoadFlow.Data.Model.ProgramBuilderValidates programBuilderValidates2 = list2.Find(delegate(RoadFlow.Data.Model.ProgramBuilderValidates p)
				{
					if (p.TableName.Equals(item5.Item1, StringComparison.CurrentCultureIgnoreCase))
					{
						return p.FieldName.Equals(item5.Item2, StringComparison.CurrentCultureIgnoreCase);
					}
					return false;
				});
				list.Add(new RoadFlow.Data.Model.ProgramBuilderValidates
				{
					ID = Guid.NewGuid(),
					ProgramID = str.ToGuid(),
					TableName = item5.Item1,
					FieldName = item5.Item2,
					FieldNote = item5.Item3,
					Validate = ((programBuilderValidates2 != null) ? programBuilderValidates2.Validate : 0)
				});
			}
			if (form != null)
			{
				using (TransactionScope transactionScope = new TransactionScope())
				{
					programBuilderValidates.DeleteByProgramID(str.ToGuid());
					foreach (RoadFlow.Data.Model.ProgramBuilderValidates item6 in list)
					{
						item6.Validate = base.Request.Form["valdate_" + item6.TableName + "_" + item6.FieldName].ToInt(0);
						programBuilderValidates.Add(item6);
					}
					transactionScope.Complete();
				}
			}
			return View(list);
		}

		public ActionResult Set_Export()
		{
			return Set_Export(null);
		}

		[HttpPost]
		public ActionResult Set_Export(FormCollection form)
		{
			string empty = string.Empty;
			List<RoadFlow.Data.Model.ProgramBuilderExport> list = new List<RoadFlow.Data.Model.ProgramBuilderExport>();
			string str = base.Request.QueryString["pid"];
			string empty2 = string.Empty;
			RoadFlow.Platform.ProgramBuilderExport programBuilderExport = new RoadFlow.Platform.ProgramBuilderExport();
			if (form != null && !base.Request.Form["delete"].IsNullOrEmpty())
			{
				string[] array = (base.Request.Form["checkbox_app"] ?? "").Split(',');
				foreach (string str2 in array)
				{
					if (str2.IsGuid())
					{
						programBuilderExport.Delete(str2.ToGuid());
					}
				}
			}
			list = programBuilderExport.GetAll(str.ToGuid());
			empty2 = ((list.Count > 0) ? list.Max((RoadFlow.Data.Model.ProgramBuilderExport p) => p.Sort).ToString() : "0");
			empty = "&appid=" + base.Request.QueryString["appid"] + "&tabid=" + base.Request.QueryString["tabid"] + "&typeid=" + base.Request.QueryString["typeid"] + "&Name1=" + base.Request.QueryString["Name1"] + "&pid=" + base.Request.QueryString["pid"] + "&maxSort=" + empty2;
			base.ViewBag.query = empty;
			return View(list);
		}

		public ActionResult Set_Export_Add()
		{
			return Set_Export_Add(null);
		}

		[HttpPost]
		public ActionResult Set_Export_Add(FormCollection form)
		{
			RoadFlow.Data.Model.ProgramBuilderExport programBuilderExport = null;
			RoadFlow.Platform.ProgramBuilderExport programBuilderExport2 = new RoadFlow.Platform.ProgramBuilderExport();
			RoadFlow.Platform.Dictionary dictionary = new RoadFlow.Platform.Dictionary();
			RoadFlow.Platform.ProgramBuilder programBuilder = new RoadFlow.Platform.ProgramBuilder();
			string str = base.Request.QueryString["pid"];
			string str2 = base.Request.QueryString["eid"];
			string str3 = base.Request.QueryString["maxSort"];
			string value = "";
			string value2 = "";
			string value3 = "";
			string value4 = "";
			base.ViewBag.sort = (str3.ToInt() + 5).ToString();
			if (str2.IsGuid())
			{
				programBuilderExport = programBuilderExport2.Get(str2.ToGuid());
				if (programBuilderExport != null)
				{
					value = programBuilderExport.Field;
					value2 = programBuilderExport.ShowType.ToString();
					value3 = programBuilderExport.Align.ToString();
					base.ViewBag.sort = programBuilderExport.Sort.ToString();
					value4 = programBuilderExport.DataType.ToString();
				}
			}
			base.ViewBag.ShowTypeOptions = dictionary.GetOptionsByCode("programbuilder_showtype", RoadFlow.Platform.Dictionary.OptionValueField.Value, value2);
			base.ViewBag.AlignOptions = dictionary.GetOptionsByCode("programbuilder_align", RoadFlow.Platform.Dictionary.OptionValueField.Value, value3);
			base.ViewBag.FieldOptions = programBuilder.GetFieldsOptions(str.ToGuid(), value);
			base.ViewBag.DataTypeOptions = programBuilderExport2.GetDataTypeOptions(value4);
			if (form != null)
			{
				string field = base.Request.Form["Field"];
				string showTitle = base.Request.Form["ShowTitle"];
				string str4 = base.Request.Form["ShowType"];
				string showFormat = base.Request.Form["ShowFormat"];
				string b = base.Request.Form["Align"];
				string str5 = base.Request.Form["Width"];
				string customString = base.Request.Form["CustomString"];
				string str6 = base.Request.Form["Sort"];
				string str7 = base.Request.Form["DataType"];
				bool flag = false;
				if (programBuilderExport == null)
				{
					flag = true;
					programBuilderExport = new RoadFlow.Data.Model.ProgramBuilderExport();
					programBuilderExport.ID = Guid.NewGuid();
					programBuilderExport.ProgramID = str.ToGuid();
				}
				programBuilderExport.Align = ((!("left" == b)) ? (("center" == b) ? 1 : 2) : 0);
				programBuilderExport.CustomString = customString;
				programBuilderExport.Field = field;
				programBuilderExport.ShowFormat = showFormat;
				programBuilderExport.ShowTitle = showTitle;
				programBuilderExport.ShowType = str4.ToInt();
				programBuilderExport.Sort = str6.ToInt();
				if (str5.IsInt())
				{
					programBuilderExport.Width = str5.ToInt();
				}
				else
				{
					programBuilderExport.Width = null;
				}
				programBuilderExport.DataType = str7.ToInt(0);
				if (flag)
				{
					programBuilderExport2.Add(programBuilderExport);
				}
				else
				{
					programBuilderExport2.Update(programBuilderExport);
				}
				base.ViewBag.script = "alert('保存成功!');window.location='Set_Export" + base.Request.Url.Query + "';";
			}
			if (programBuilderExport == null)
			{
				programBuilderExport = new RoadFlow.Data.Model.ProgramBuilderExport();
			}
			return View(programBuilderExport);
		}

		public string Set_Export_CopyForList()
		{
			Guid guid = base.Request.QueryString["pid"].ToGuid();
			if (guid.IsEmptyGuid())
			{
				return "参数错误";
			}
			List<RoadFlow.Data.Model.ProgramBuilderFields> all = new RoadFlow.Platform.ProgramBuilderFields().GetAll(guid);
			RoadFlow.Platform.ProgramBuilderExport programBuilderExport = new RoadFlow.Platform.ProgramBuilderExport();
			foreach (RoadFlow.Data.Model.ProgramBuilderExport item in programBuilderExport.GetAll(guid))
			{
				programBuilderExport.Delete(item.ID);
			}
			foreach (RoadFlow.Data.Model.ProgramBuilderFields item2 in all)
			{
				if (!item2.Field.IsNullOrEmpty())
				{
					RoadFlow.Data.Model.ProgramBuilderExport programBuilderExport2 = new RoadFlow.Data.Model.ProgramBuilderExport();
					programBuilderExport2.Align = ((!("left" == item2.Align)) ? (("center" == item2.Align) ? 1 : 2) : 0);
					programBuilderExport2.CustomString = item2.CustomString;
					programBuilderExport2.DataType = 0;
					programBuilderExport2.Field = item2.Field;
					programBuilderExport2.ID = Guid.NewGuid();
					programBuilderExport2.ProgramID = guid;
					programBuilderExport2.ShowFormat = item2.ShowFormat;
					programBuilderExport2.ShowTitle = item2.ShowTitle;
					programBuilderExport2.ShowType = item2.ShowType;
					programBuilderExport2.Sort = item2.Sort;
					programBuilderExport.Add(programBuilderExport2);
				}
			}
			return "复制成功";
		}

		[MyAttribute(CheckApp = false, CheckUrl = false)]
		public string GetFieldsOptions()
		{
			string str = base.Request["applibaryid"];
			RoadFlow.Data.Model.AppLibrary appLibrary = new RoadFlow.Platform.AppLibrary().Get(str.ToGuid());
			if (appLibrary == null || !appLibrary.Code.IsGuid())
			{
				return "";
			}
			return new RoadFlow.Platform.ProgramBuilder().GetFieldsOptions(appLibrary.Code.ToGuid(), "");
		}

		public string Publish()
		{
			string str = base.Request.QueryString["pid"];
			if (!str.IsGuid())
			{
				return "成功失败!";
			}
			if (new RoadFlow.Platform.ProgramBuilder().Publish(str.ToGuid(), true))
			{
				return "成功发布!";
			}
			return "成功失败!";
		}

		[MyAttribute(CheckApp = false, CheckLogin = false, CheckUrl = false)]
		public ActionResult Run()
		{
			return Run(null);
		}

		[HttpPost]
		[MyAttribute(CheckApp = false, CheckLogin = false, CheckUrl = false)]
		public ActionResult Run(FormCollection form)
		{
			if (!WebMvc.Common.Tools.CheckLogin() && !RoadFlow.Platform.WeiXin.Organize.CheckLogin())
			{
				base.Response.End();
				return null;
			}
			ProgramBuilderCache programBuilderCache = null;
			RoadFlow.Platform.ProgramBuilder programBuilder = new RoadFlow.Platform.ProgramBuilder();
			new RoadFlow.Platform.ProgramBuilderQuerys();
			string empty = string.Empty;
			DataTable dataTable = null;
			RoadFlow.Platform.DBConnection dBConnection = new RoadFlow.Platform.DBConnection();
			new RoadFlow.Platform.Dictionary();
			new RoadFlow.Platform.Organize();
			string empty2 = string.Empty;
			string empty3 = string.Empty;
			empty = base.Request.QueryString["programid"];
			Guid test;
			if (empty.IsGuid(out test))
			{
				programBuilderCache = programBuilder.GetSet(test);
			}
			if (programBuilderCache == null)
			{
				base.Response.Write("未找到程序设置!");
				base.Response.End();
				return null;
			}
			if (form != null && !base.Request.Form["searchbutton"].IsNullOrEmpty())
			{
				foreach (RoadFlow.Data.Model.ProgramBuilderQuerys query in programBuilderCache.Querys)
				{
					if (query.InputType.In(3, 5))
					{
						query.Value = base.Request.Form[query.ControlName + "_start"].Trim1() + "," + base.Request.Form[query.ControlName + "_end"].Trim1();
					}
					else
					{
						query.Value = base.Request.Form[query.ControlName].Trim1();
					}
				}
			}
			else
			{
				foreach (RoadFlow.Data.Model.ProgramBuilderQuerys query2 in programBuilderCache.Querys)
				{
					if (query2.InputType.In(3, 5))
					{
						query2.Value = base.Request.QueryString[query2.ControlName + "_start"].Trim1() + "," + base.Request.QueryString[query2.ControlName + "_end"].Trim1();
					}
					else
					{
						query2.Value = base.Request.QueryString[query2.ControlName].Trim1();
					}
				}
			}
			empty2 = "&programid=" + empty + "&appid=" + base.Request.QueryString["appid"] + "&tabid=" + base.Request.QueryString["tabid"];
			foreach (RoadFlow.Data.Model.ProgramBuilderQuerys query3 in programBuilderCache.Querys)
			{
				if (query3.InputType.In(3, 5))
				{
					string[] array = query3.Value.Split(',');
					empty2 = empty2 + "&" + query3.ControlName + "_start=" + array[0] + "&" + query3.ControlName + "_end=" + array[1];
				}
				else
				{
					empty2 = empty2 + "&" + query3.ControlName + "=" + query3.Value;
				}
			}
			empty3 = (WebMvc.Common.Tools.BaseUrl + "/ProgramBuilder/Run?1=1" + empty2).UrlEncode();
			StringBuilder stringBuilder = new StringBuilder(programBuilderCache.Program.SQL);
			List<IDbDataParameter> list = new List<IDbDataParameter>();
			RoadFlow.Data.Model.DBConnection dBConnection2 = new RoadFlow.Platform.DBConnection().Get(programBuilderCache.Program.DBConnID);
			if (dBConnection2 == null)
			{
				base.Response.Write("未找到数据连接!");
				base.Response.End();
				return null;
			}
			string text = string.Empty;
			switch (dBConnection2.Type)
			{
			case "SqlServer":
			case "MySql":
				text = "@";
				break;
			case "Oracle":
				text = ":";
				break;
			}
			foreach (RoadFlow.Data.Model.ProgramBuilderQuerys query4 in programBuilderCache.Querys)
			{
				if (!query4.Value.IsNullOrEmpty())
				{
					string text2 = query4.Value.ReplaceSelectSql();
					string operators = query4.Operators;
					if (query4.InputType == 7 && query4.IsQueryUsers == 1)
					{
						text2 = new RoadFlow.Platform.Organize().GetAllUsersIdList(text2).ToArray().Join1();
					}
					if (!(operators == "%LIKE%"))
					{
						if (!(operators == "LIKE%"))
						{
							if (!(operators == "%LIKE"))
							{
								if (!(operators == "IN"))
								{
									if (operators == "NOT IN")
									{
										stringBuilder.AppendFormat(" AND {0} NOT IN({1})", query4.Field, RoadFlow.Utility.Tools.GetSqlInString(text2));
									}
									else if (query4.InputType.In(3, 5))
									{
										string[] array2 = text2.Split(',');
										if (array2[0].IsDateTime())
										{
											array2[0] = ((query4.InputType == 3) ? array2[0].ToDateString() : array2[0].ToDateTimeString());
											stringBuilder.AppendFormat(" AND {0}{1}{2}{3}_start", query4.Field, operators, text, query4.ControlName);
											list.Add(new SqlParameter(text + query4.ControlName + "_start", array2[0]));
										}
										if (array2[1].IsDateTime())
										{
											array2[1] = ((query4.InputType == 3) ? array2[1].ToDateTime().AddDays(1.0).ToDateString() : array2[1].ToDateTimeString());
											stringBuilder.AppendFormat(" AND {0}{1}{2}{3}_end", query4.Field, (operators == ">") ? "<" : "<=", text, query4.ControlName);
											list.Add(new SqlParameter(text + query4.ControlName + "_end", array2[1]));
										}
									}
									else
									{
										stringBuilder.AppendFormat(" AND {0}{1}{2}{3}", query4.Field, operators, text, query4.ControlName);
										list.Add(new SqlParameter(text + query4.ControlName, text2));
									}
								}
								else
								{
									stringBuilder.AppendFormat(" AND {0} IN({1})", query4.Field, RoadFlow.Utility.Tools.GetSqlInString(text2));
								}
							}
							else
							{
								stringBuilder.AppendFormat(" AND {0} LIKE '%{1}'", query4.Field, text2);
							}
						}
						else
						{
							stringBuilder.AppendFormat(" AND {0} LIKE '{1}%'", query4.Field, text2);
						}
					}
					else
					{
						stringBuilder.AppendFormat(" AND {0} LIKE '%{1}%'", query4.Field, text2);
					}
				}
			}
			string text3 = stringBuilder.ToString().FilterWildcard(RoadFlow.Platform.Users.CurrentUserID.ToString());
			string pager = default(string);
			dataTable = dBConnection.GetDataTable(dBConnection2, text3, out pager, empty2, list, (programBuilderCache.Program.IsPager.HasValue && programBuilderCache.Program.IsPager.Value == 0) ? (-1) : 0);
			base.ViewBag.pager = pager;
			base.ViewBag.PBModel = programBuilderCache;
			base.ViewBag.query = empty2;
			base.ViewBag.prevurl = empty3;
			programBuilder.AddToExportCache(programBuilderCache.Program.ID, dBConnection2.ID, text3, list);
			if (dataTable == null)
			{
				base.Response.Write("查询错误!");
				return View(dataTable);
			}
			return View(dataTable);
		}

		[MyAttribute(CheckApp = false)]
		public ActionResult RunDelete()
		{
			string str = base.Request.QueryString["secondtableeditform"];
			string text = base.Request.QueryString["instanceid"] ?? "";
			RoadFlow.Data.Model.AppLibrary appLibrary = new RoadFlow.Platform.AppLibrary().Get(str.ToGuid());
			if (appLibrary != null)
			{
				RoadFlow.Data.Model.WorkFlowForm workFlowForm = new RoadFlow.Platform.WorkFlowForm().Get(appLibrary.Code.ToGuid());
				if (workFlowForm != null)
				{
					RoadFlow.Platform.DBConnection dBConnection = new RoadFlow.Platform.DBConnection();
					JsonData jsonData = JsonMapper.ToObject(workFlowForm.Attribute);
					string text2 = jsonData.ContainsKey("dbconn") ? jsonData["dbconn"].ToString() : "";
					string text3 = jsonData.ContainsKey("dbtable") ? jsonData["dbtable"].ToString() : "";
					string text4 = jsonData.ContainsKey("dbtablepk") ? jsonData["dbtablepk"].ToString() : "";
					if (text2.IsGuid() && !text3.IsNullOrEmpty() && !text4.IsNullOrEmpty())
					{
						string[] array = (text ?? "").Split(',');
						foreach (string text5 in array)
						{
							DataTable dataTable = dBConnection.GetDataTable(text2, text3, text4, text5);
							if (dataTable.Rows.Count > 0)
							{
								dBConnection.DeleteData(text2.ToGuid(), text3, text4, text5);
								RoadFlow.Platform.Log.Add("删除了数据(生成程序)(" + text3 + ")", "连接ID:" + text2 + ",表名:" + text3 + ",主键:" + text5, RoadFlow.Platform.Log.Types.其它分类, dataTable.ToJsonString());
							}
						}
					}
				}
			}
			base.ViewBag.script = "alert('删除成功!');window.location='" + base.Request.QueryString["prevurl"] + "'";
			return View();
		}

		[MyAttribute(CheckApp = false)]
		public ActionResult OutToExcel()
		{
			return View();
		}

		[MyAttribute(CheckApp = false)]
		public ActionResult InFromExcel()
		{
			return InFromExcel(null);
		}

		[HttpPost]
		[MyAttribute(CheckApp = false)]
		[ValidateAntiForgeryToken]
		public ActionResult InFromExcel(FormCollection coll)
		{
			string text = base.Request.QueryString["programid"];
			RoadFlow.Data.Model.ProgramBuilder programBuilder = new RoadFlow.Platform.ProgramBuilder().Get(text.ToGuid());
			RoadFlow.Platform.DBConnection dBConnection = new RoadFlow.Platform.DBConnection();
			base.ViewBag.TableOptions = dBConnection.GetAllTableOptions(programBuilder.DBConnID, "");
			base.ViewBag.ConnID = programBuilder.DBConnID.ToString();
			base.ViewBag.TableName = programBuilder.TableName;
			base.ViewBag.NumberFiled = programBuilder.InDataNumberFiledName;
			if (coll != null)
			{
				HttpPostedFileBase httpPostedFileBase = base.Request.Files["excel"];
				if (httpPostedFileBase != null && !httpPostedFileBase.FileName.IsNullOrEmpty())
				{
					string numberFiled = base.Request.Form["NumberFiled"];
					string table = base.Request.Form["TableName"];
					string text2 = base.Server.MapPath(base.Url.Content("~/Content/UploadFiles/ProgramInExcel/" + text + "/" + Guid.NewGuid().ToString()));
					if (!Directory.Exists(text2))
					{
						Directory.CreateDirectory(text2);
					}
					string text3 = Path.Combine(text2, httpPostedFileBase.FileName);
					httpPostedFileBase.SaveAs(text3);
					string msg;
					int num = new RoadFlow.Platform.ProgramBuilder().InDataFormExcel(text.ToGuid(), table, text3, out msg, numberFiled);
					base.ViewBag.script = "alert('" + (msg.IsNullOrEmpty() ? ("本次共导入了" + num.ToString() + "条数据!") : msg) + "');new RoadUI.Window().close();";
				}
				else
				{
					base.ViewBag.script = "alert('要导入的Excel文件为空!');";
				}
			}
			return View();
		}
	}
}
