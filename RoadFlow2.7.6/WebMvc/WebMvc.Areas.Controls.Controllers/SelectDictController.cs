using RoadFlow.Data.Model;
using RoadFlow.Platform;
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web.Mvc;
using WebMvc.Common;

namespace WebMvc.Areas.Controls.Controllers
{
	public class SelectDictController : Controller
	{
		public ActionResult Index()
		{
			RoadFlow.Platform.Dictionary dictionary = new RoadFlow.Platform.Dictionary();
			string obj = base.Request.QueryString["values"] ?? "";
			string text7 = base.Request.QueryString["rootid"];
			string text = base.Request.QueryString["datasource"];
			string str = base.Request.QueryString["sql"];
			DataTable dataTable = new DataTable();
			if ("1" == text)
			{
				string str2 = base.Request.QueryString["dbconn"];
				RoadFlow.Platform.DBConnection dBConnection = new RoadFlow.Platform.DBConnection();
				RoadFlow.Data.Model.DBConnection dbconn = dBConnection.Get(str2.ToGuid());
				dataTable = dBConnection.GetDataTable(dbconn, str.UrlDecode().FilterWildcard().ReplaceSelectSql());
			}
			StringBuilder stringBuilder = new StringBuilder();
			string[] array = obj.Split(',');
			foreach (string text2 in array)
			{
				if (!text2.IsNullOrEmpty())
				{
					if (!(text == "0"))
					{
						if (text == "1")
						{
							string value = string.Empty;
							foreach (DataRow row in dataTable.Rows)
							{
								if (text2 == row[0].ToString())
								{
									value = ((dataTable.Columns.Count > 1) ? row[1].ToString() : text2);
									break;
								}
							}
							stringBuilder.AppendFormat("<div onclick=\"currentDel=this;showinfo('{0}');\" class=\"selectorDiv\" ondblclick=\"currentDel=this;del();\" value=\"{0}\">", text2);
							stringBuilder.Append(value);
							stringBuilder.Append("</div>");
							continue;
						}
						if (text == "2")
						{
							string text3 = base.Request.QueryString["url2"];
							if (!text3.IsNullOrEmpty())
							{
								text3 = ((text3.IndexOf('?') >= 0) ? (text3 + "&values=" + text2) : (text3 + "?values=" + text2));
								StringBuilder stringBuilder2 = new StringBuilder();
								try
								{
									TextWriter writer = new StringWriter(stringBuilder2);
									base.Server.Execute(text3, writer);
								}
								catch
								{
								}
								stringBuilder.AppendFormat("<div onclick=\"currentDel=this;showinfo('{0}');\" class=\"selectorDiv\" ondblclick=\"currentDel=this;del();\" value=\"{0}\">", text2);
								stringBuilder.Append(stringBuilder2.ToString());
								stringBuilder.Append("</div>");
							}
							continue;
						}
						if (text == "3")
						{
							string str3 = base.Request.QueryString["dbconn"];
							string text4 = base.Request.QueryString["dbtable"];
							string text5 = base.Request.QueryString["valuefield"];
							string text6 = base.Request.QueryString["titlefield"];
							string text8 = base.Request.QueryString["parentfield"];
							string str4 = base.Request.QueryString["where1"];
							RoadFlow.Platform.DBConnection dBConnection2 = new RoadFlow.Platform.DBConnection();
							RoadFlow.Data.Model.DBConnection dbconn2 = dBConnection2.Get(str3.ToGuid());
							string str5 = "select " + text6 + " from " + text4 + " where " + text5 + "='" + text2 + "'";
							DataTable dataTable2 = dBConnection2.GetDataTable(dbconn2, str5.ReplaceSelectSql());
							string value2 = string.Empty;
							if (dataTable2.Rows.Count > 0)
							{
								value2 = dataTable2.Rows[0][0].ToString();
							}
							stringBuilder.AppendFormat("<div onclick=\"currentDel=this;showinfo('{0}');\" class=\"selectorDiv\" ondblclick=\"currentDel=this;del();\" value=\"{0}\">", text2);
							stringBuilder.Append(value2);
							stringBuilder.Append("</div>");
							base.ViewBag.where = str4.UrlEncode();
							continue;
						}
					}
					Guid test;
					if (text2.IsGuid(out test))
					{
						stringBuilder.AppendFormat("<div onclick=\"currentDel=this;showinfo('{0}');\" class=\"selectorDiv\" ondblclick=\"currentDel=this;del();\" value=\"{0}\">", text2);
						stringBuilder.Append(dictionary.GetTitle(test));
						stringBuilder.Append("</div>");
					}
				}
			}
			base.ViewBag.defaultValuesString = stringBuilder.ToString().Trim1();
			return View();
		}

		public ActionResult Index_App()
		{
			RoadFlow.Platform.Dictionary dictionary = new RoadFlow.Platform.Dictionary();
			string obj = base.Request.QueryString["values"] ?? "";
			string text7 = base.Request.QueryString["rootid"];
			string text = base.Request.QueryString["datasource"];
			string str = base.Request.QueryString["sql"];
			DataTable dataTable = new DataTable();
			if ("1" == text)
			{
				string str2 = base.Request.QueryString["dbconn"];
				RoadFlow.Platform.DBConnection dBConnection = new RoadFlow.Platform.DBConnection();
				RoadFlow.Data.Model.DBConnection dbconn = dBConnection.Get(str2.ToGuid());
				dataTable = dBConnection.GetDataTable(dbconn, str.UrlDecode().FilterWildcard().ReplaceSelectSql());
			}
			StringBuilder stringBuilder = new StringBuilder();
			string[] array = obj.Split(',');
			foreach (string text2 in array)
			{
				if (!text2.IsNullOrEmpty())
				{
					if (!(text == "0"))
					{
						if (text == "1")
						{
							string value = string.Empty;
							foreach (DataRow row in dataTable.Rows)
							{
								if (text2 == row[0].ToString())
								{
									value = ((dataTable.Columns.Count > 1) ? row[1].ToString() : text2);
									break;
								}
							}
							stringBuilder.AppendFormat("<div onclick=\"currentDel=this;showinfo('{0}');\" class=\"selectorDiv\" ondblclick=\"currentDel=this;del();\" value=\"{0}\">", text2);
							stringBuilder.Append(value);
							stringBuilder.Append("</div>");
							continue;
						}
						if (text == "2")
						{
							string text3 = base.Request.QueryString["url2"];
							if (!text3.IsNullOrEmpty())
							{
								text3 = ((text3.IndexOf('?') >= 0) ? (text3 + "&values=" + text2) : (text3 + "?values=" + text2));
								StringBuilder stringBuilder2 = new StringBuilder();
								try
								{
									TextWriter writer = new StringWriter(stringBuilder2);
									base.Server.Execute(text3, writer);
								}
								catch
								{
								}
								stringBuilder.AppendFormat("<div onclick=\"currentDel=this;showinfo('{0}');\" class=\"selectorDiv\" ondblclick=\"currentDel=this;del();\" value=\"{0}\">", text2);
								stringBuilder.Append(stringBuilder2.ToString());
								stringBuilder.Append("</div>");
							}
							continue;
						}
						if (text == "3")
						{
							string str3 = base.Request.QueryString["dbconn"];
							string text4 = base.Request.QueryString["dbtable"];
							string text5 = base.Request.QueryString["valuefield"];
							string text6 = base.Request.QueryString["titlefield"];
							string text8 = base.Request.QueryString["parentfield"];
							string str4 = base.Request.QueryString["where1"];
							RoadFlow.Platform.DBConnection dBConnection2 = new RoadFlow.Platform.DBConnection();
							RoadFlow.Data.Model.DBConnection dbconn2 = dBConnection2.Get(str3.ToGuid());
							string str5 = "select " + text6 + " from " + text4 + " where " + text5 + "='" + text2 + "'";
							DataTable dataTable2 = dBConnection2.GetDataTable(dbconn2, str5.ReplaceSelectSql());
							string value2 = string.Empty;
							if (dataTable2.Rows.Count > 0)
							{
								value2 = dataTable2.Rows[0][0].ToString();
							}
							stringBuilder.AppendFormat("<div onclick=\"currentDel=this;showinfo('{0}');\" class=\"selectorDiv\" ondblclick=\"currentDel=this;del();\" value=\"{0}\">", text2);
							stringBuilder.Append(value2);
							stringBuilder.Append("</div>");
							base.ViewBag.where = str4.UrlEncode();
							continue;
						}
					}
					Guid test;
					if (text2.IsGuid(out test))
					{
						stringBuilder.AppendFormat("<div onclick=\"currentDel=this;showinfo('{0}');\" class=\"selectorDiv\" ondblclick=\"currentDel=this;del();\" value=\"{0}\">", text2);
						stringBuilder.Append(dictionary.GetTitle(test));
						stringBuilder.Append("</div>");
					}
				}
			}
			base.ViewBag.defaultValuesString = stringBuilder.ToString().Trim1();
			return View();
		}

		public string GetNames()
		{
			string obj = base.Request.QueryString["values"] ?? "";
			RoadFlow.Platform.Dictionary dictionary = new RoadFlow.Platform.Dictionary();
			StringBuilder stringBuilder = new StringBuilder();
			string[] array = obj.Split(',');
			foreach (string str in array)
			{
				RoadFlow.Data.Model.Dictionary dictionary2 = dictionary.Get(str.ToGuid(), true);
				if (dictionary2 != null)
				{
					stringBuilder.Append(dictionary2.Title);
					stringBuilder.Append(',');
				}
			}
			return stringBuilder.ToString().TrimEnd(',');
		}

		public string GetNote()
		{
			string str = base.Request.QueryString["id"];
			string result = "";
			Guid test;
			if (str.IsGuid(out test))
			{
				RoadFlow.Data.Model.Dictionary dictionary = new RoadFlow.Platform.Dictionary().Get(test, true);
				if (dictionary != null)
				{
					result = dictionary.Note;
				}
			}
			return result;
		}

		public string GetNames_SQL()
		{
			string str = base.Request.QueryString["dbconn"];
			string str2 = base.Request.QueryString["sql"];
			RoadFlow.Platform.DBConnection dBConnection = new RoadFlow.Platform.DBConnection();
			RoadFlow.Data.Model.DBConnection dbconn = dBConnection.Get(str.ToGuid());
			DataTable dataTable = dBConnection.GetDataTable(dbconn, str2.UrlDecode().FilterWildcard().ReplaceSelectSql());
			string obj = base.Request.QueryString["values"] ?? "";
			StringBuilder stringBuilder = new StringBuilder();
			string[] array = obj.Split(',');
			foreach (string a in array)
			{
				string empty = string.Empty;
				string value = string.Empty;
				foreach (DataRow row in dataTable.Rows)
				{
					empty = row[0].ToString();
					if (a == empty)
					{
						value = ((dataTable.Columns.Count > 1) ? row[1].ToString() : empty);
						break;
					}
				}
				stringBuilder.Append(value);
				stringBuilder.Append(',');
			}
			return stringBuilder.ToString().TrimEnd(',');
		}

		public string GetJson_SQL()
		{
			if (!Tools.CheckLogin(false))
			{
				return "{}";
			}
			string str = base.Request.QueryString["dbconn"];
			string str2 = base.Request.QueryString["sql"];
			RoadFlow.Platform.DBConnection dBConnection = new RoadFlow.Platform.DBConnection();
			RoadFlow.Data.Model.DBConnection dbconn = dBConnection.Get(str.ToGuid());
			DataTable dataTable = dBConnection.GetDataTable(dbconn, str2.UrlDecode().FilterWildcard().ReplaceSelectSql());
			StringBuilder stringBuilder = new StringBuilder(1000);
			foreach (DataRow row in dataTable.Rows)
			{
				string text = row[0].ToString();
				string arg = (dataTable.Columns.Count > 1) ? row[1].ToString() : text;
				stringBuilder.Append("{");
				stringBuilder.AppendFormat("\"id\":\"{0}\",", text);
				stringBuilder.AppendFormat("\"parentID\":\"{0}\",", Guid.Empty.ToString());
				stringBuilder.AppendFormat("\"title\":\"{0}\",", arg);
				stringBuilder.AppendFormat("\"type\":\"{0}\",", "2");
				stringBuilder.AppendFormat("\"ico\":\"{0}\",", "");
				stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", "0");
				stringBuilder.Append("\"childs\":[]},");
			}
			return "[" + stringBuilder.ToString().TrimEnd(',') + "]";
		}

		public string GetJson_Table()
		{
			string str = base.Request.QueryString["dbconn"];
			string text = base.Request.QueryString["dbtable"];
			string text2 = base.Request.QueryString["valuefield"];
			string text3 = base.Request.QueryString["titlefield"];
			string text4 = base.Request.QueryString["parentfield"];
			string str2 = (base.Request.QueryString["where"] ?? "").UrlDecode();
			RoadFlow.Platform.DBConnection dBConnection = new RoadFlow.Platform.DBConnection();
			RoadFlow.Data.Model.DBConnection dbconn = dBConnection.Get(str.ToGuid());
			string str3 = "select " + text2 + "," + text3 + " from " + text + (str2.IsNullOrEmpty() ? "" : (" where " + str2.FilterWildcard()));
			DataTable dataTable = dBConnection.GetDataTable(dbconn, str3.ReplaceSelectSql());
			StringBuilder stringBuilder = new StringBuilder(1000);
			foreach (DataRow row in dataTable.Rows)
			{
				string text5 = row[0].ToString();
				string arg = (dataTable.Columns.Count > 1) ? row[1].ToString() : text5;
				string str4 = "select * from " + text + " where " + text4 + "='" + text5 + "'";
				bool flag = dBConnection.GetDataTable(dbconn, str4.ReplaceSelectSql()).Rows.Count > 0;
				stringBuilder.Append("{");
				stringBuilder.AppendFormat("\"id\":\"{0}\",", text5);
				stringBuilder.AppendFormat("\"parentID\":\"{0}\",", Guid.Empty.ToString());
				stringBuilder.AppendFormat("\"title\":\"{0}\",", arg);
				stringBuilder.AppendFormat("\"type\":\"{0}\",", flag ? "1" : "2");
				stringBuilder.AppendFormat("\"ico\":\"{0}\",", "");
				stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", flag ? "1" : "0");
				stringBuilder.Append("\"childs\":[]},");
			}
			return "[" + stringBuilder.ToString().TrimEnd(',') + "]";
		}

		public string GetJson_TableRefresh()
		{
			string str = base.Request.QueryString["dbconn"];
			string text = base.Request.QueryString["dbtable"];
			string text2 = base.Request.QueryString["valuefield"];
			string text3 = base.Request.QueryString["titlefield"];
			string text4 = base.Request.QueryString["parentfield"];
			string text7 = base.Request.QueryString["where"];
			string text5 = base.Request.QueryString["refreshid"];
			RoadFlow.Platform.DBConnection dBConnection = new RoadFlow.Platform.DBConnection();
			RoadFlow.Data.Model.DBConnection dbconn = dBConnection.Get(str.ToGuid());
			string str2 = "select " + text2 + "," + text3 + " from " + text + " where " + text4 + "='" + text5 + "'";
			DataTable dataTable = dBConnection.GetDataTable(dbconn, str2.ReplaceSelectSql());
			StringBuilder stringBuilder = new StringBuilder(1000);
			foreach (DataRow row in dataTable.Rows)
			{
				string text6 = row[0].ToString();
				string arg = (dataTable.Columns.Count > 1) ? row[1].ToString() : text6;
				string str3 = "select * from " + text + " where " + text4 + "='" + text6 + "'";
				bool flag = dBConnection.GetDataTable(dbconn, str3.ReplaceSelectSql()).Rows.Count > 0;
				stringBuilder.Append("{");
				stringBuilder.AppendFormat("\"id\":\"{0}\",", text6);
				stringBuilder.AppendFormat("\"parentID\":\"{0}\",", Guid.Empty.ToString());
				stringBuilder.AppendFormat("\"title\":\"{0}\",", arg);
				stringBuilder.AppendFormat("\"type\":\"{0}\",", flag ? "1" : "2");
				stringBuilder.AppendFormat("\"ico\":\"{0}\",", "");
				stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", flag ? "1" : "0");
				stringBuilder.Append("\"childs\":[]},");
			}
			return "[" + stringBuilder.ToString().TrimEnd(',') + "]";
		}

		public string GetNames_Table()
		{
			string str = base.Request.QueryString["dbconn"];
			string text = base.Request.QueryString["dbtable"];
			string text2 = base.Request.QueryString["valuefield"];
			string text3 = base.Request.QueryString["titlefield"];
			string text5 = base.Request.QueryString["parentfield"];
			string text6 = base.Request.QueryString["where"];
			string obj = base.Request.QueryString["values"] ?? "";
			RoadFlow.Platform.DBConnection dBConnection = new RoadFlow.Platform.DBConnection();
			RoadFlow.Data.Model.DBConnection dbconn = dBConnection.Get(str.ToGuid());
			StringBuilder stringBuilder = new StringBuilder();
			string[] array = obj.Split(',');
			foreach (string text4 in array)
			{
				if (!text4.IsNullOrEmpty())
				{
					string str2 = "select " + text3 + " from " + text + " where " + text2 + "='" + text4 + "'";
					DataTable dataTable = dBConnection.GetDataTable(dbconn, str2.ReplaceSelectSql());
					if (dataTable.Rows.Count > 0)
					{
						stringBuilder.Append(dataTable.Rows[0][0].ToString());
						stringBuilder.Append(",");
					}
				}
			}
			return stringBuilder.ToString().TrimEnd(',');
		}
	}
}
