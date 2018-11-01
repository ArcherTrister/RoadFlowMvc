using LitJson;
using RoadFlow.Data.Factory;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using RoadFlow.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace RoadFlow.Platform
{
	public class WorkFlowForm
	{
		private IWorkFlowForm dataWorkFlowForm;

		public WorkFlowForm()
		{
			dataWorkFlowForm = Factory.GetWorkFlowForm();
		}

		public int Add(RoadFlow.Data.Model.WorkFlowForm model)
		{
			return dataWorkFlowForm.Add(model);
		}

		public int Update(RoadFlow.Data.Model.WorkFlowForm model)
		{
			return dataWorkFlowForm.Update(model);
		}

		public List<RoadFlow.Data.Model.WorkFlowForm> GetAll()
		{
			return dataWorkFlowForm.GetAll();
		}

		public RoadFlow.Data.Model.WorkFlowForm Get(Guid id)
		{
			return dataWorkFlowForm.Get(id);
		}

		public int Delete(Guid id)
		{
			return dataWorkFlowForm.Delete(id);
		}

		public long GetCount()
		{
			return dataWorkFlowForm.GetCount();
		}

		public string GetValidatePropTypeRadios(string name, string value, string att = "")
		{
			return Tools.GetRadioString(new ListItem[3]
			{
				new ListItem("弹出(alert)", "0")
				{
					Selected = ("0" == value)
				},
				new ListItem("图标和提示信息", "1")
				{
					Selected = ("1" == value)
				},
				new ListItem("图标", "2")
				{
					Selected = ("2" == value)
				}
			}, name, att);
		}

		public string GetInputTypeRadios(string name, string value, string att = "")
		{
			return Tools.GetRadioString(new ListItem[2]
			{
				new ListItem("明文", "text")
				{
					Selected = ("0" == value)
				},
				new ListItem("密码", "password")
				{
					Selected = ("1" == value)
				}
			}, name, att);
		}

		public string GetEventOptions(string name, string value, string att = "")
		{
			return Tools.GetOptionsString(new ListItem[12]
			{
				new ListItem("onclick", "onclick")
				{
					Selected = ("onclick" == value)
				},
				new ListItem("onchange", "onchange")
				{
					Selected = ("onchange" == value)
				},
				new ListItem("ondblclick", "ondblclick")
				{
					Selected = ("ondblclick" == value)
				},
				new ListItem("onfocus", "onfocus")
				{
					Selected = ("onfocus" == value)
				},
				new ListItem("onblur", "onblur")
				{
					Selected = ("onblur" == value)
				},
				new ListItem("onkeydown", "onkeydown")
				{
					Selected = ("onkeydown" == value)
				},
				new ListItem("onkeypress", "onkeypress")
				{
					Selected = ("onkeypress" == value)
				},
				new ListItem("onkeyup", "onkeyup")
				{
					Selected = ("onkeyup" == value)
				},
				new ListItem("onmousedown", "onmousedown")
				{
					Selected = ("onmousedown" == value)
				},
				new ListItem("onmouseup", "onmouseup")
				{
					Selected = ("onmouseup" == value)
				},
				new ListItem("onmouseover", "onmouseover")
				{
					Selected = ("onmouseover" == value)
				},
				new ListItem("onmouseout", "onmouseout")
				{
					Selected = ("onmouseout" == value)
				}
			});
		}

		public string GetValueTypeOptions(string value)
		{
			return Tools.GetOptionsString(new ListItem[8]
			{
				new ListItem("字符串", "0")
				{
					Selected = ("0" == value)
				},
				new ListItem("整数", "1")
				{
					Selected = ("1" == value)
				},
				new ListItem("实数", "2")
				{
					Selected = ("2" == value)
				},
				new ListItem("正整数", "3")
				{
					Selected = ("3" == value)
				},
				new ListItem("正实数", "4")
				{
					Selected = ("4" == value)
				},
				new ListItem("负整数", "5")
				{
					Selected = ("5" == value)
				},
				new ListItem("负实数", "6")
				{
					Selected = ("6" == value)
				},
				new ListItem("手机号码", "7")
				{
					Selected = ("7" == value)
				}
			});
		}

		public string GetDefaultValueSelect(string value)
		{
			StringBuilder stringBuilder = new StringBuilder(1000);
			stringBuilder.Append("<option value=\"\"></option>");
			stringBuilder.Append("<optgroup label=\"组织机构相关选项\"></optgroup>");
			stringBuilder.AppendFormat("<option value=\"u_@RoadFlow.Platform.Users.CurrentUserID.ToString()\" {0}>当前步骤用户ID</option>", ("10" == value) ? "selected=\"selected\"" : "");
			stringBuilder.AppendFormat("<option value=\"@(RoadFlow.Platform.Users.CurrentUserName)\" {0}>当前步骤用户姓名</option>", ("11" == value) ? "selected=\"selected\"" : "");
			stringBuilder.AppendFormat("<option value=\"@(RoadFlow.Platform.Users.CurrentDeptID)\" {0}>当前步骤用户部门ID</option>", ("12" == value) ? "selected=\"selected\"" : "");
			stringBuilder.AppendFormat("<option value=\"@(RoadFlow.Platform.Users.CurrentDeptName)\" {0}>当前步骤用户部门名称</option>", ("13" == value) ? "selected=\"selected\"" : "");
			stringBuilder.AppendFormat("<option value=\"u_@(new RoadFlow.Platform.WorkFlowTask().GetFirstSnderID(FlowID.ToGuid(), GroupID.ToGuid(), true))\" {0}>流程发起者ID</option>", ("14" == value) ? "selected=\"selected\"" : "");
			stringBuilder.AppendFormat("<option value=\"@(new RoadFlow.Platform.Users().GetName(new RoadFlow.Platform.WorkFlowTask().GetFirstSnderID(FlowID.ToGuid(), GroupID.ToGuid(), true)))\" {0}>流程发起者姓名</option>", ("15" == value) ? "selected=\"selected\"" : "");
			stringBuilder.AppendFormat("<option value=\"@(new RoadFlow.Platform.WorkFlowTask().GetFirstSnderDeptID(FlowID.ToGuid(), GroupID.ToGuid()))\" {0}>流程发起者部门ID</option>", ("16" == value) ? "selected=\"selected\"" : "");
			stringBuilder.AppendFormat("<option value=\"@(new RoadFlow.Platform.Organize().GetName(new RoadFlow.Platform.WorkFlowTask().GetFirstSnderDeptID(FlowID.ToGuid(), GroupID.ToGuid())))\" {0}>流程发起者部门名称</option>", ("17" == value) ? "selected=\"selected\"" : "");
			stringBuilder.Append("<optgroup label=\"日期时间相关选项\"></optgroup>");
			stringBuilder.AppendFormat("<option value=\"@(RoadFlow.Utility.DateTimeNew.ShortDate)\" {0}>短日期格式(2014-4-15)</option>", ("20" == value) ? "selected=\"selected\"" : "");
			stringBuilder.AppendFormat("<option value=\"@(RoadFlow.Utility.DateTimeNew.LongDate)\" {0}>长日期格式(2014年4月15日)</option>", ("21" == value) ? "selected=\"selected\"" : "");
			stringBuilder.AppendFormat("<option value=\"@(RoadFlow.Utility.DateTimeNew.ShortTime)\" {0}>短时间格式(23:59)</option>", ("22" == value) ? "selected=\"selected\"" : "");
			stringBuilder.AppendFormat("<option value=\"@(RoadFlow.Utility.DateTimeNew.LongTime)\" {0}>长时间格式(23时59分)</option>", ("23" == value) ? "selected=\"selected\"" : "");
			stringBuilder.AppendFormat("<option value=\"@(RoadFlow.Utility.DateTimeNew.ShortDateTime)\" {0}>短日期时间格式(2014-4-15 22:31)</option>", ("24" == value) ? "selected=\"selected\"" : "");
			stringBuilder.AppendFormat("<option value=\"@(RoadFlow.Utility.DateTimeNew.LongDateTime)\" {0}>长日期时间格式(2014年4月15日 22时31分)</option>", ("25" == value) ? "selected=\"selected\"" : "");
			stringBuilder.Append("<optgroup label=\"流程实例相关选项\"></optgroup>");
			stringBuilder.AppendFormat("<option value=\"@Html.Raw(BWorkFlow.GetFlowName(FlowID.ToGuid()))\" {0}>当前流程名称</option>", ("30" == value) ? "selected=\"selected\"" : "");
			stringBuilder.AppendFormat("<option value=\"@Html.Raw(BWorkFlow.GetStepName(StepID.ToGuid(), FlowID.ToGuid(), true))\" {0}>当前步骤名称</option>", ("31" == value) ? "selected=\"selected\"" : "");
			return stringBuilder.ToString();
		}

		public string GetDefaultValueSelectByAspx(string value)
		{
			StringBuilder stringBuilder = new StringBuilder(1000);
			stringBuilder.Append("<option value=\"\"></option>");
			stringBuilder.Append("<optgroup label=\"组织机构相关选项\"></optgroup>");
			stringBuilder.AppendFormat("<option value=\"u_<%=RoadFlow.Platform.Users.CurrentUserID.ToString()%>\" {0}>当前步骤用户ID</option>", ("10" == value) ? "selected=\"selected\"" : "");
			stringBuilder.AppendFormat("<option value=\"<%=RoadFlow.Platform.Users.CurrentUserName%>\" {0}>当前步骤用户姓名</option>", ("11" == value) ? "selected=\"selected\"" : "");
			stringBuilder.AppendFormat("<option value=\"<%=RoadFlow.Platform.Users.CurrentDeptID%>\" {0}>当前步骤用户部门ID</option>", ("12" == value) ? "selected=\"selected\"" : "");
			stringBuilder.AppendFormat("<option value=\"<%=RoadFlow.Platform.Users.CurrentDeptName%>\" {0}>当前步骤用户部门名称</option>", ("13" == value) ? "selected=\"selected\"" : "");
			stringBuilder.AppendFormat("<option value=\"u_<%=new RoadFlow.Platform.WorkFlowTask().GetFirstSnderID(FlowID.ToGuid(), GroupID.ToGuid(), true)%>\" {0}>流程发起者ID</option>", ("14" == value) ? "selected=\"selected\"" : "");
			stringBuilder.AppendFormat("<option value=\"<%=new RoadFlow.Platform.Users().GetName(new RoadFlow.Platform.WorkFlowTask().GetFirstSnderID(FlowID.ToGuid(), GroupID.ToGuid(), true))%>\" {0}>流程发起者姓名</option>", ("15" == value) ? "selected=\"selected\"" : "");
			stringBuilder.AppendFormat("<option value=\"<%=new RoadFlow.Platform.WorkFlowTask().GetFirstSnderDeptID(FlowID.ToGuid(), GroupID.ToGuid())%>\" {0}>流程发起者部门ID</option>", ("16" == value) ? "selected=\"selected\"" : "");
			stringBuilder.AppendFormat("<option value=\"<%=new RoadFlow.Platform.Organize().GetName(new RoadFlow.Platform.WorkFlowTask().GetFirstSnderDeptID(FlowID.ToGuid(), GroupID.ToGuid()))%>\" {0}>流程发起者部门名称</option>", ("17" == value) ? "selected=\"selected\"" : "");
			stringBuilder.Append("<optgroup label=\"日期时间相关选项\"></optgroup>");
			stringBuilder.AppendFormat("<option value=\"<%=RoadFlow.Utility.DateTimeNew.ShortDate%>\" {0}>短日期格式(2014-4-15)</option>", ("20" == value) ? "selected=\"selected\"" : "");
			stringBuilder.AppendFormat("<option value=\"<%=RoadFlow.Utility.DateTimeNew.LongDate%>\" {0}>长日期格式(2014年4月15日)</option>", ("21" == value) ? "selected=\"selected\"" : "");
			stringBuilder.AppendFormat("<option value=\"<%=RoadFlow.Utility.DateTimeNew.ShortTime%>\" {0}>短时间格式(23:59)</option>", ("22" == value) ? "selected=\"selected\"" : "");
			stringBuilder.AppendFormat("<option value=\"<%=RoadFlow.Utility.DateTimeNew.LongTime%>\" {0}>长时间格式(23时59分)</option>", ("23" == value) ? "selected=\"selected\"" : "");
			stringBuilder.AppendFormat("<option value=\"<%=RoadFlow.Utility.DateTimeNew.ShortDateTime%>\" {0}>短日期时间格式(2014-4-15 22:31)</option>", ("24" == value) ? "selected=\"selected\"" : "");
			stringBuilder.AppendFormat("<option value=\"<%=RoadFlow.Utility.DateTimeNew.LongDateTime%>\" {0}>长日期时间格式(2014年4月15日 22时31分)</option>", ("25" == value) ? "selected=\"selected\"" : "");
			stringBuilder.Append("<optgroup label=\"流程实例相关选项\"></optgroup>");
			stringBuilder.AppendFormat("<option value=\"<%=BWorkFlow.GetFlowName(FlowID.ToGuid())%>\" {0}>当前流程名称</option>", ("30" == value) ? "selected=\"selected\"" : "");
			stringBuilder.AppendFormat("<option value=\"<%=BWorkFlow.GetStepName(StepID.ToGuid(), FlowID.ToGuid(), true)%>\" {0}>当前步骤名称</option>", ("31" == value) ? "selected=\"selected\"" : "");
			return stringBuilder.ToString();
		}

		public string GetTextareaModelRadios(string name, string value, string att = "")
		{
			return Tools.GetRadioString(new ListItem[2]
			{
				new ListItem("普通", "default")
				{
					Selected = ("default" == value)
				},
				new ListItem("HTML", "html")
				{
					Selected = ("html" == value)
				}
			}, name, att);
		}

		public string GetDataSourceRadios(string name, string value, string att = "")
		{
			return Tools.GetRadioString(new ListItem[3]
			{
				new ListItem("数据字典", "0")
				{
					Selected = ("0" == value)
				},
				new ListItem("自定义", "1")
				{
					Selected = ("1" == value)
				},
				new ListItem("SQL语句", "2")
				{
					Selected = ("2" == value)
				}
			}, name, att);
		}

		public string GetOrgRangeRadios(string name, string value, string att = "")
		{
			return Tools.GetRadioString(new ListItem[2]
			{
				new ListItem("发起者部门", "0")
				{
					Selected = ("0" == value)
				},
				new ListItem("处理者部门", "1")
				{
					Selected = ("1" == value)
				}
			}, name, att);
		}

		public string GetOrgSelectTypeCheckboxs(string name, string value, string att = "")
		{
			return Tools.GetCheckBoxString(new ListItem[5]
			{
				new ListItem("部门", "0")
				{
					Selected = ("0" == value)
				},
				new ListItem("岗位", "1")
				{
					Selected = ("1" == value)
				},
				new ListItem("人员", "2")
				{
					Selected = ("2" == value)
				},
				new ListItem("工作组", "3")
				{
					Selected = ("3" == value)
				},
				new ListItem("单位", "4")
				{
					Selected = ("4" == value)
				}
			}, name, value.Split(','), att);
		}

		public string GetEditmodeOptions(string value)
		{
			return Tools.GetOptionsString(new ListItem[10]
			{
				new ListItem("无", "")
				{
					Selected = ("" == value)
				},
				new ListItem("文本框", "text")
				{
					Selected = ("text" == value)
				},
				new ListItem("文本域", "textarea")
				{
					Selected = ("textarea" == value)
				},
				new ListItem("下拉列表", "select")
				{
					Selected = ("select" == value)
				},
				new ListItem("复选框", "checkbox")
				{
					Selected = ("checkbox" == value)
				},
				new ListItem("单选框", "radio")
				{
					Selected = ("radio" == value)
				},
				new ListItem("日期时间", "datetime")
				{
					Selected = ("datetime" == value)
				},
				new ListItem("组织机构选择", "org")
				{
					Selected = ("org" == value)
				},
				new ListItem("数据字典选择", "dict")
				{
					Selected = ("dict" == value)
				},
				new ListItem("附件", "files")
				{
					Selected = ("files" == value)
				}
			});
		}

		public string GetDisplayModeOptions(string value)
		{
			return Tools.GetOptionsString(new ListItem[18]
			{
				new ListItem("常规", "normal")
				{
					Selected = ("normal" == value)
				},
				new ListItem("数据字典ID显示为标题", "dict_id_title")
				{
					Selected = ("dict_id_title" == value)
				},
				new ListItem("数据字典ID显示为代码", "dict_id_code")
				{
					Selected = ("dict_id_code" == value)
				},
				new ListItem("数据字典ID显示为值", "dict_id_value")
				{
					Selected = ("dict_id_value" == value)
				},
				new ListItem("数据字典ID显示为备注", "dict_id_note")
				{
					Selected = ("dict_id_note" == value)
				},
				new ListItem("数据字典ID显示为其它", "dict_id_other")
				{
					Selected = ("dict_id_other" == value)
				},
				new ListItem("数据字典唯一代码显示为标题", "dict_code_title")
				{
					Selected = ("dict_code_title" == value)
				},
				new ListItem("数据字典唯一代码显示为ID", "dict_code_id")
				{
					Selected = ("dict_code_id" == value)
				},
				new ListItem("数据字典唯一代码显示为值", "dict_code_value")
				{
					Selected = ("dict_code_value" == value)
				},
				new ListItem("数据字典唯一代码显示为备注", "dict_code_note")
				{
					Selected = ("dict_code_note" == value)
				},
				new ListItem("数据字典唯一代码显示为其它", "dict_code_other")
				{
					Selected = ("dict_code_other" == value)
				},
				new ListItem("组织机构ID显示为名称", "organize_id_name")
				{
					Selected = ("organize_id_name" == value)
				},
				new ListItem("附件显示为连接", "files_link")
				{
					Selected = ("files_link" == value)
				},
				new ListItem("附件显示为图片", "files_img")
				{
					Selected = ("files_img" == value)
				},
				new ListItem("日期时间显示为指定格式", "datetime_format")
				{
					Selected = ("datetime_format" == value)
				},
				new ListItem("数字显示为指定格式", "number_format")
				{
					Selected = ("number_format" == value)
				},
				new ListItem("字符串时间显示为指定格式", "string_format")
				{
					Selected = ("string_format" == value)
				},
				new ListItem("关联显示为其它表字段值", "table_fieldvalue")
				{
					Selected = ("table_fieldvalue" == value)
				}
			});
		}

		public string GetDisplayString(string value, string displayModel, string format = "", string dbconnID = "", string sql = "")
		{
			string empty = string.Empty;
			switch ((displayModel ?? "").ToLower())
			{
			default:
				return value;
			case "dict_id_title":
			{
				RoadFlow.Data.Model.Dictionary dictionary2 = new Dictionary().Get(value.ToGuid());
				return (dictionary2 == null) ? "" : dictionary2.Title;
			}
			case "dict_id_code":
			{
				RoadFlow.Data.Model.Dictionary dictionary5 = new Dictionary().Get(value.ToGuid());
				return (dictionary5 == null) ? "" : dictionary5.Code;
			}
			case "dict_id_value":
			{
				RoadFlow.Data.Model.Dictionary dictionary4 = new Dictionary().Get(value.ToGuid());
				return (dictionary4 == null) ? "" : dictionary4.Value;
			}
			case "dict_id_note":
			{
				RoadFlow.Data.Model.Dictionary dictionary = new Dictionary().Get(value.ToGuid());
				return (dictionary == null) ? "" : dictionary.Note;
			}
			case "dict_id_other":
			{
				RoadFlow.Data.Model.Dictionary dictionary3 = new Dictionary().Get(value.ToGuid());
				return (dictionary3 == null) ? "" : dictionary3.Other;
			}
			case "dict_code_title":
			{
				RoadFlow.Data.Model.Dictionary byCode3 = new Dictionary().GetByCode(value);
				return (byCode3 == null) ? "" : byCode3.Title;
			}
			case "dict_code_id":
			{
				RoadFlow.Data.Model.Dictionary byCode2 = new Dictionary().GetByCode(value);
				return (byCode2 == null) ? "" : byCode2.ID.ToString();
			}
			case "dict_code_value":
			{
				RoadFlow.Data.Model.Dictionary byCode4 = new Dictionary().GetByCode(value);
				return (byCode4 == null) ? "" : byCode4.Value;
			}
			case "dict_code_note":
			{
				RoadFlow.Data.Model.Dictionary byCode = new Dictionary().GetByCode(value);
				return (byCode == null) ? "" : byCode.Note;
			}
			case "dict_code_other":
			{
				RoadFlow.Data.Model.Dictionary byCode5 = new Dictionary().GetByCode(value);
				return (byCode5 == null) ? "" : byCode5.Other;
			}
			case "organize_id_name":
				return new Organize().GetNames(value);
			case "files_link":
			{
				string[] array3 = value.Split('|');
				StringBuilder stringBuilder2 = new StringBuilder();
				string[] array2 = array3;
				foreach (string text in array2)
				{
					stringBuilder2.AppendFormat("<a target=\"_blank\" class=\"blue\" href=\"{0}\">{1}</a><br/>", text, Path.GetFileName(text));
				}
				return stringBuilder2.ToString();
			}
			case "files_img":
			{
				string[] array = value.Split('|');
				StringBuilder stringBuilder = new StringBuilder();
				string[] array2 = array;
				foreach (string arg in array2)
				{
					stringBuilder.AppendFormat("<img src=\"{0}\" />", arg);
				}
				return stringBuilder.ToString();
			}
			case "datetime_format":
				return value.ToDateTime().ToString(format ?? Config.DateFormat);
			case "number_format":
				return value.ToDecimal().ToString(format);
			case "table_fieldvalue":
			{
				DBConnection dBConnection = new DBConnection();
				DataTable dataTable = dBConnection.GetDataTable(dBConnection.Get(dbconnID.ToGuid()), sql + "'" + value + "'");
				return (dataTable.Rows.Count > 0 && dataTable.Columns.Count > 0) ? dataTable.Rows[0][0].ToString() : "";
			}
			}
		}

		public string GetStatusTitle(int status)
		{
			string result = string.Empty;
			switch (status)
			{
			case 0:
				result = "已保存";
				break;
			case 1:
				result = "已发布";
				break;
			case 2:
				result = "已作废";
				break;
			}
			return result;
		}

		public string GetHeadHtml(string serverScript)
		{
			return "";
		}

		public string GetOptionsFromUrl(string url, string value)
		{
			string text = url + ((url.IndexOf('?') >= 0) ? "&" : "?") + "values=" + value;
			if (!text.Contains("http", StringComparison.CurrentCultureIgnoreCase) && !text.Contains("https", StringComparison.CurrentCultureIgnoreCase))
			{
				Uri url2 = HttpContext.Current.Request.Url;
				text = url2.ToString().Substring(0, url2.ToString().IndexOf("//") + 2) + url2.Authority + text;
			}
			try
			{
				return HttpHelper.SendGet(text);
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

		public string GetOptionsFromString(string str, string value, bool isEmpty = true)
		{
			if (str.IsNullOrEmpty())
			{
				return "";
			}
			string[] array = str.Split(';');
			StringBuilder stringBuilder = new StringBuilder();
			if (isEmpty)
			{
				stringBuilder.Append("<option value=\"\"></option>");
			}
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				string[] array3 = array2[i].Split(',');
				string text = string.Empty;
				string empty = string.Empty;
				if (array3.Length != 0)
				{
					text = array3[0];
				}
				stringBuilder.AppendFormat(arg2: (array3.Length <= 1) ? text : array3[1], format: "<option value=\"{0}\"{1}>{2}</option>", arg0: text, arg1: text.Equals(value, StringComparison.CurrentCultureIgnoreCase) ? " selected=\"selected\"" : "");
			}
			return stringBuilder.ToString();
		}

		public string GetOptionsFromSql(string connID, string sql, string value)
		{
			Guid test;
			if (!connID.IsGuid(out test))
			{
				return "";
			}
			DBConnection dBConnection = new DBConnection();
			RoadFlow.Data.Model.DBConnection dBConnection2 = dBConnection.Get(test);
			if (dBConnection2 == null)
			{
				return "";
			}
			DataTable dataTable = dBConnection.GetDataTable(dBConnection2, sql.Replace("\u00a0", " ").FilterWildcard().ReplaceSelectSql());
			if (dataTable.Rows.Count == 0)
			{
				return "";
			}
			List<ListItem> list = new List<ListItem>();
			foreach (DataRow row in dataTable.Rows)
			{
				if (dataTable.Columns.Count != 0)
				{
					string text = row[0].ToString();
					string text2 = text;
					if (dataTable.Columns.Count > 1)
					{
						text2 = row[1].ToString();
					}
					list.Add(new ListItem(text2, text)
					{
						Selected = (value == text)
					});
				}
			}
			return Tools.GetOptionsString(list.ToArray());
		}

		public string GetRadioFromSql(string connID, string sql, string name, string value, string attr = "")
		{
			Guid test;
			if (!connID.IsGuid(out test))
			{
				return "";
			}
			DBConnection dBConnection = new DBConnection();
			RoadFlow.Data.Model.DBConnection dBConnection2 = dBConnection.Get(test);
			if (dBConnection2 == null)
			{
				return "";
			}
			DataTable dataTable = dBConnection.GetDataTable(dBConnection2, sql.Replace("\u00a0", " ").FilterWildcard().ReplaceSelectSql());
			if (dataTable.Rows.Count == 0)
			{
				return "";
			}
			List<ListItem> list = new List<ListItem>();
			foreach (DataRow row in dataTable.Rows)
			{
				if (dataTable.Columns.Count != 0)
				{
					string text = row[0].ToString();
					string text2 = text;
					if (dataTable.Columns.Count > 1)
					{
						text2 = row[1].ToString();
					}
					list.Add(new ListItem(text2, text)
					{
						Selected = (value == text)
					});
				}
			}
			return Tools.GetRadioString(list.ToArray(), name, attr);
		}

		public string GetCheckboxFromSql(string connID, string sql, string name, string value, string attr = "")
		{
			Guid test;
			if (!connID.IsGuid(out test))
			{
				return "";
			}
			DBConnection dBConnection = new DBConnection();
			RoadFlow.Data.Model.DBConnection dBConnection2 = dBConnection.Get(test);
			if (dBConnection2 == null)
			{
				return "";
			}
			DataTable dataTable = dBConnection.GetDataTable(dBConnection2, sql.Replace("\u00a0", " ").FilterWildcard().ReplaceSelectSql());
			if (dataTable.Rows.Count == 0)
			{
				return "";
			}
			List<ListItem> list = new List<ListItem>();
			foreach (DataRow row in dataTable.Rows)
			{
				if (dataTable.Columns.Count != 0)
				{
					string text = row[0].ToString();
					string text2 = text;
					if (dataTable.Columns.Count > 1)
					{
						text2 = row[1].ToString();
					}
					list.Add(new ListItem(text2, text));
				}
			}
			return Tools.GetCheckBoxString(list.ToArray(), name, (value ?? "").Split(','), attr);
		}

		public string GetFormGridHtml(string connID, string dataFormat, string dataSource, string dataSource1, string params1 = "")
		{
			if (!dataFormat.IsInt() || !dataSource.IsInt() || dataSource1.IsNullOrEmpty())
			{
				return "";
			}
			if (dataSource == "0")
			{
				DBConnection dBConnection = new DBConnection();
				RoadFlow.Data.Model.DBConnection dBConnection2 = dBConnection.Get(connID.ToGuid());
				if (dBConnection2 != null)
				{
					DataTable dataTable = dBConnection.GetDataTable(dBConnection2, (dataSource1.Replace("\u00a0", " ") + " " + params1).ReplaceSelectSql());
					switch (dataFormat)
					{
					case "0":
						return dataTableToHtml(dataTable);
					case "1":
						if (dataTable.Rows.Count <= 0)
						{
							return "";
						}
						return dataTable.Rows[0][0].ToString();
					case "2":
						if (dataTable.Rows.Count <= 0)
						{
							return "";
						}
						return jsonToHtml(dataTable.Rows[0][0].ToString());
					default:
						return "";
					}
				}
				return "";
			}
			if (dataSource == "1")
			{
				string empty = string.Empty;
				try
				{
					empty = HttpHelper.SendGet(dataSource1 + params1);
					switch (dataFormat)
					{
					case "0":
					case "1":
						return empty;
					case "2":
						return jsonToHtml(empty);
					default:
						return "";
					}
				}
				catch
				{
					return "";
				}
			}
			if (dataSource == "2")
			{
				WorkFlowCustomEventParams workFlowCustomEventParams = default(WorkFlowCustomEventParams);
				workFlowCustomEventParams.FlowID = (HttpContext.Current.Request.QueryString["FlowID"] ?? "").ToGuid();
				workFlowCustomEventParams.GroupID = (HttpContext.Current.Request.QueryString["GroupID"] ?? "").ToGuid();
				workFlowCustomEventParams.StepID = (HttpContext.Current.Request.QueryString["StepID"] ?? "").ToGuid();
				workFlowCustomEventParams.TaskID = (HttpContext.Current.Request.QueryString["TaskID"] ?? "").ToGuid();
				workFlowCustomEventParams.InstanceID = (HttpContext.Current.Request.QueryString["InstanceID"] ?? "");
				workFlowCustomEventParams.Other = params1;
				object obj2 = null;
				try
				{
					obj2 = new WorkFlowTask().ExecuteFlowCustomEvent(dataSource1, workFlowCustomEventParams);
					switch (dataFormat)
					{
					case "0":
						return dataTableToHtml((DataTable)obj2);
					case "1":
						return obj2.ToString();
					case "2":
						return jsonToHtml(obj2.ToString());
					default:
						return "";
					}
				}
				catch
				{
					return "";
				}
			}
			return "";
		}

		private string dataTableToHtml(DataTable dt)
		{
			StringBuilder stringBuilder = new StringBuilder(2000);
			stringBuilder.Append("<table border=\"1\" style=\"border-collapse:collapse;width:100%;\">");
			stringBuilder.Append("<thead><tr style=\"height:25px;\">");
			foreach (DataColumn column in dt.Columns)
			{
				stringBuilder.AppendFormat("<th>{0}</th>", column.ColumnName);
			}
			stringBuilder.Append("</tr></thead>");
			stringBuilder.Append("<tbody>");
			foreach (DataRow row in dt.Rows)
			{
				stringBuilder.Append("<tr style=\"height:22px;\">");
				for (int i = 0; i < dt.Columns.Count; i++)
				{
					stringBuilder.AppendFormat("<td>{0}</td>", row[i].ToString().HtmlEncode());
				}
				stringBuilder.Append("</tr>");
			}
			stringBuilder.Append("</tbody>");
			stringBuilder.Append("</table>");
			return stringBuilder.ToString();
		}

		private string jsonToHtml(string jsonStr)
		{
			JsonData jsonData = JsonMapper.ToObject(jsonStr);
			if (!jsonData.IsArray)
			{
				return "";
			}
			StringBuilder stringBuilder = new StringBuilder(2000);
			stringBuilder.Append("<table border=\"1\" style=\"border-collapse:collapse;width:100%;\">");
			stringBuilder.Append("<tbody><tr style=\"height:25px;\">");
			foreach (JsonData item in (IEnumerable)jsonData)
			{
				stringBuilder.Append("<tr style=\"height:22px;\">");
				foreach (JsonData item2 in (IEnumerable)item)
				{
					stringBuilder.AppendFormat("<td>{0}</td>", item2.ToString());
				}
				stringBuilder.Append("</tr>");
			}
			stringBuilder.Append("</tbody>");
			stringBuilder.Append("</table>");
			return stringBuilder.ToString();
		}

		public string GetAllChildsIDString(Guid id, bool isSelf = true)
		{
			return new Dictionary().GetAllChildsIDString(id);
		}

		public List<RoadFlow.Data.Model.WorkFlowForm> GetAllByType(Guid id)
		{
			return dataWorkFlowForm.GetAllByType(GetAllChildsIDString(id));
		}

		public string GetTypeOptions(string value = "")
		{
			return new Dictionary().GetOptionsByCode("FormTypes", Dictionary.OptionValueField.ID, value);
		}

		public string GetComboxTableHtmlFromSql(string connID, string sql, string value)
		{
			Guid test;
			if (!connID.IsGuid(out test))
			{
				return "";
			}
			DBConnection dBConnection = new DBConnection();
			RoadFlow.Data.Model.DBConnection dBConnection2 = dBConnection.Get(test);
			if (dBConnection2 == null)
			{
				return "";
			}
			DataTable dataTable = dBConnection.GetDataTable(dBConnection2, sql.Replace("\u00a0", " ").FilterWildcard().ReplaceSelectSql());
			if (dataTable.Rows.Count == 0)
			{
				return "";
			}
			StringBuilder stringBuilder = new StringBuilder(2000);
			stringBuilder.Append("<table><thead><tr>");
			for (int i = 0; i < dataTable.Columns.Count; i++)
			{
				if (dataTable.Columns.Count <= 1 || i != 0)
				{
					stringBuilder.Append("<th>");
					stringBuilder.Append(dataTable.Columns[i].ColumnName);
					stringBuilder.Append("</th>");
				}
			}
			stringBuilder.Append("</thead>");
			stringBuilder.Append("<tbody>");
			for (int j = 0; j < dataTable.Rows.Count; j++)
			{
				stringBuilder.Append("<tr>");
				for (int k = 0; k < dataTable.Columns.Count; k++)
				{
					if (dataTable.Columns.Count <= 1 || k != 0)
					{
						stringBuilder.AppendFormat("<td value=\"{0}\"{1}>", dataTable.Rows[j][0], dataTable.Rows[j][0].ToString().Equals(value, StringComparison.CurrentCultureIgnoreCase) ? " selected=\"selected\"" : "");
						stringBuilder.Append(dataTable.Rows[j][k]);
						stringBuilder.Append("</td>");
					}
				}
				stringBuilder.Append("</tr>");
			}
			stringBuilder.Append("</tr></tbody></table>");
			return stringBuilder.ToString();
		}

		public string GetArchivesString(string formHtml, string commentHtml)
		{
			return "<link href=\"" + Config.BaseUrl + "/Platform/WorkFlowRun/Scripts/Forms/flowform_print.css\" rel=\"stylesheet\" />        <style type=\"text/css\" media=\"print\">            .Noprint { display: none; }        </style>        <link href=\"" + Config.BaseUrl + "/Platform/WorkFlowRun/Scripts/Forms/flowform.css\" rel=\"stylesheet\" type=\"text/css\" />        <script src=\"" + Config.BaseUrl + "/Platform/WorkFlowRun/Scripts/Forms/common.js\" type=\"text/javascript\" ></script><div style=\"width:98%; margin:-10px auto 0 auto;\">" + formHtml + "<script type=\"text/javascript\">fieldStatus ={};displayModel='1';</script>" + "</div>";
		}

		public List<RoadFlow.Data.Model.WorkFlowForm> GetPagerData(out string pager, string query = "", string userid = "", string typeid = "", string name = "", int pagesize = 15)
		{
			return dataWorkFlowForm.GetPagerData(out pager, query, userid, typeid, name, pagesize);
		}

		public List<RoadFlow.Data.Model.WorkFlowForm> GetPagerData(out long count, int pageSize, int pageNumber, string userid = "", string typeid = "", string name = "", string order = "")
		{
			return dataWorkFlowForm.GetPagerData(out count, pageSize, pageNumber, userid, typeid, name, order);
		}

		public string GetWorkFlowFormXml(Guid formID, string applibaryID = "")
		{
			RoadFlow.Data.Model.WorkFlowForm workFlowForm = Get(formID);
			if (workFlowForm == null)
			{
				return "";
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
			stringBuilder.Append("<WorkFlowForm>");
			stringBuilder.Append("<ID>" + workFlowForm.ID.ToString() + "</ID>");
			stringBuilder.Append("<Name><![CDATA[" + workFlowForm.Name + "]]></Name>");
			stringBuilder.Append("<Type>" + workFlowForm.Type.ToString() + "</Type>");
			stringBuilder.Append("<CreateUserID>" + workFlowForm.CreateUserID.ToString() + "</CreateUserID>");
			stringBuilder.Append("<CreateUserName>" + workFlowForm.CreateUserName + "</CreateUserName>");
			stringBuilder.Append("<CreateTime>" + workFlowForm.CreateTime.ToDateTimeStringS() + "</CreateTime>");
			stringBuilder.Append("<LastModifyTime>" + workFlowForm.LastModifyTime.ToDateTimeStringS() + "</LastModifyTime>");
			stringBuilder.Append("<Html><![CDATA[" + workFlowForm.Html + "]]></Html>");
			stringBuilder.Append("<SubTableJson><![CDATA[" + workFlowForm.SubTableJson + "]]></SubTableJson>");
			stringBuilder.Append("<EventsJson><![CDATA[" + workFlowForm.EventsJson + "]]></EventsJson>");
			stringBuilder.Append("<Attribute><![CDATA[" + workFlowForm.Attribute + "]]></Attribute>");
			stringBuilder.Append("<Status>" + workFlowForm.Status.ToString() + "</Status>");
			stringBuilder.Append("<ApplibaryID>" + applibaryID + "</ApplibaryID>");
			stringBuilder.Append("</WorkFlowForm>");
			return stringBuilder.ToString();
		}

		public bool AddFromXmlFile(string xmlFile, int type = 0)
		{
			XElement root = XDocument.Load(xmlFile).Root;
			Guid guid = (root.Element("ID") != null) ? root.Element("ID").Value.ToGuid() : Guid.Empty;
			string name = (root.Element("Name") != null) ? root.Element("Name").Value : "";
			Guid guid2 = (root.Element("Type") != null) ? root.Element("Type").Value.ToGuid() : Guid.Empty;
			string str = (root.Element("CreateUserID") != null) ? root.Element("CreateUserID").Value : "";
			string text = (root.Element("CreateUserName") != null) ? root.Element("CreateUserName").Value : "";
			string str2 = (root.Element("CreateTime") != null) ? root.Element("CreateTime").Value : "";
			string str3 = (root.Element("LastModifyTime") != null) ? root.Element("LastModifyTime").Value : "";
			string html = (root.Element("Html") != null) ? root.Element("Html").Value : "";
			string subTableJson = (root.Element("SubTableJson") != null) ? root.Element("SubTableJson").Value : "";
			string eventsJson = (root.Element("EventsJson") != null) ? root.Element("EventsJson").Value : "";
			string attribute = (root.Element("Attribute") != null) ? root.Element("Attribute").Value : "";
			string str4 = (root.Element("Status") != null) ? root.Element("Status").Value : "";
			string str5 = (root.Element("ApplibaryID") != null) ? root.Element("ApplibaryID").Value : "";
			bool flag = false;
			RoadFlow.Data.Model.WorkFlowForm workFlowForm = Get(guid);
			if (workFlowForm == null)
			{
				workFlowForm = new RoadFlow.Data.Model.WorkFlowForm();
				flag = true;
			}
			workFlowForm.Attribute = attribute;
			workFlowForm.CreateTime = (str2.IsDateTime() ? str2.ToDateTime() : DateTimeNew.Now);
			workFlowForm.CreateUserID = (str.IsGuid() ? str.ToGuid() : Users.CurrentUserID);
			workFlowForm.CreateUserName = (text.IsNullOrEmpty() ? Users.CurrentUserName : text);
			workFlowForm.EventsJson = eventsJson;
			workFlowForm.Html = html;
			workFlowForm.ID = guid;
			workFlowForm.LastModifyTime = (str3.IsDateTime() ? str3.ToDateTime() : DateTimeNew.Now);
			workFlowForm.Name = name;
			workFlowForm.Status = str4.ToInt(0);
			workFlowForm.SubTableJson = subTableJson;
			workFlowForm.Type = guid2;
			if (flag)
			{
				Add(workFlowForm);
			}
			else
			{
				Update(workFlowForm);
			}
			AppLibrary appLibrary = new AppLibrary();
			RoadFlow.Data.Model.AppLibrary appLibrary2 = appLibrary.GetByCode(guid.ToString());
			flag = false;
			if (appLibrary2 == null)
			{
				appLibrary2 = new RoadFlow.Data.Model.AppLibrary();
				flag = true;
			}
			appLibrary2.ID = (str5.IsGuid() ? str5.ToGuid() : Guid.NewGuid());
			appLibrary2.Address = ((type == 0) ? ("/Platform/WorkFlowFormDesigner/Forms/" + workFlowForm.ID.ToString() + ".aspx") : ("/Views/WorkFlowFormDesigner/Forms/" + workFlowForm.ID.ToString() + ".cshtml"));
			appLibrary2.Note = "流程表单";
			appLibrary2.OpenMode = 0;
			appLibrary2.Params = "";
			appLibrary2.Title = workFlowForm.Name;
			appLibrary2.Code = workFlowForm.ID.ToString();
			appLibrary2.Type = (guid2.IsEmptyGuid() ? new Dictionary().GetIDByCode("FormTypes") : guid2);
			if (flag)
			{
				appLibrary.Add(appLibrary2);
			}
			else
			{
				appLibrary.Update(appLibrary2);
			}
			appLibrary.ClearCache();
			return true;
		}

		public string Export(Guid formID, int type = 0)
		{
			RoadFlow.Data.Model.WorkFlowForm workFlowForm = Get(formID);
			if (workFlowForm == null)
			{
				return "";
			}
			List<FileInfo> list = new List<FileInfo>();
			string text = Config.FilePath + "WorkFlowFormExportFiles\\" + Guid.NewGuid().ToString("N") + "\\";
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			string text2 = text + "FlowFormDesigner_" + formID.ToString() + ".xml";
			if (File.Exists(text2))
			{
				File.Delete(text2);
			}
			RoadFlow.Data.Model.AppLibrary byCode = new AppLibrary().GetByCode(formID.ToString());
			string workFlowFormXml = GetWorkFlowFormXml(formID, (byCode == null) ? "" : byCode.ID.ToString());
			FileStream fileStream = new FileStream(text2, FileMode.Append);
			StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.UTF8);
			streamWriter.Write(workFlowFormXml);
			streamWriter.Flush();
			streamWriter.Close();
			fileStream.Close();
			list.Add(new FileInfo(text2));
			if (workFlowForm.Status == 1)
			{
				string text3 = (type == 0) ? (HttpContext.Current.Server.MapPath("/Platform/WorkFlowFormDesigner/Forms/") + "\\" + workFlowForm.ID.ToString() + ".aspx") : (HttpContext.Current.Server.MapPath("/Views/WorkFlowFormDesigner/Forms/") + "\\" + workFlowForm.ID.ToString() + ".cshtml");
				if (File.Exists(text3))
				{
					list.Add(new FileInfo(text3));
				}
			}
			string text4 = text + "\\" + workFlowForm.Name + "_" + formID.ToString() + ".zip";
			if (FileCompression.CompressFile(list, text4, 0, false))
			{
				return text4;
			}
			return "";
		}

		public string Import(string zipFile, int type = 0)
		{
			string text = Path.GetDirectoryName(zipFile) + "\\";
			string text2 = FileCompression.Decompress(zipFile, text);
			if ("1" != text2)
			{
				Log.Add("解压文件出错-" + zipFile, text2);
				return "解压文件出错!";
			}
			IEnumerable<string> enumerable = from p in Directory.GetFiles(text)
			where Path.GetFileName(p).StartsWith("FlowFormDesigner_")
			select p;
			WorkFlowForm workFlowForm = new WorkFlowForm();
			foreach (string item in enumerable)
			{
				string[] array = Path.GetFileNameWithoutExtension(item).Split('_');
				string text3 = string.Empty;
				if (array.Length > 1)
				{
					text3 = array[1];
				}
				if (!text3.IsNullOrEmpty() && workFlowForm.AddFromXmlFile(item, type))
				{
					string empty = string.Empty;
					string empty2 = string.Empty;
					if (type == 0)
					{
						empty = Path.GetDirectoryName(item) + "\\" + text3 + ".aspx";
						empty2 = HttpContext.Current.Server.MapPath("/Platform/WorkFlowFormDesigner/Forms/") + "\\" + text3 + ".aspx";
					}
					else
					{
						empty = Path.GetDirectoryName(item) + "\\" + text3 + ".cshtml";
						empty2 = HttpContext.Current.Server.MapPath("/Views/WorkFlowFormDesigner/Forms/") + "\\" + text3 + ".cshtml";
					}
					if (File.Exists(empty))
					{
						File.Copy(empty, empty2, true);
					}
				}
			}
			return "1";
		}

		public string ReplaceTitleExpression(string expression, string tableName, string instanceId, out bool isEmptyField)
		{
			List<string> list = new List<string>();
			string[] array = expression.Split('{');
			foreach (string text in array)
			{
				if (text.IndexOf('}') >= 0)
				{
					list.Add(text.Substring(0, text.IndexOf('}')));
				}
			}
			string text2 = expression;
			bool flag = false;
			foreach (string item in list)
			{
				string text3 = HttpContext.Current.Request.Form[tableName + "." + item];
				if (text3.IsNullOrEmpty())
				{
					string pk = HttpContext.Current.Request.Form["Form_DBTablePk"];
					string connid = HttpContext.Current.Request.Form["Form_DBConnID"];
					JsonData formData = new WorkFlow().GetFormData(connid, tableName, pk, instanceId);
					text3 = (formData.ContainsKey((tableName + "_" + item).ToLower()) ? formData[(tableName + "_" + item).ToLower()].ToString() : "");
				}
				if (text3.IsNullOrEmpty() && !flag)
				{
					flag = true;
				}
				text2 = text2.Replace("{" + item + "}", text3);
			}
			isEmptyField = flag;
			return text2;
		}
	}
}
