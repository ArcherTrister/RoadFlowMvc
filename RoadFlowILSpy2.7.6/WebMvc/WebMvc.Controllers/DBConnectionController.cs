using LitJson;
using RoadFlow.Data.Model;
using RoadFlow.Platform;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
	public class DBConnectionController : MyController
	{
		public ActionResult Index()
		{
			string text = string.Format("&appid={0}&tabid={1}", base.Request.QueryString["appid"], base.Request.QueryString["tabid"]);
			List<RoadFlow.Data.Model.DBConnection> all = new RoadFlow.Platform.DBConnection().GetAll();
			JsonData jsonData = new JsonData();
			foreach (RoadFlow.Data.Model.DBConnection item in all)
			{
				JsonData jsonData2 = new JsonData();
				jsonData2["id"] = item.ID.ToString();
				jsonData2["Name"] = item.Name;
				jsonData2["Type"] = item.Type;
				jsonData2["ConnectionString"] = item.ConnectionString;
				jsonData2["Note"] = item.Note;
				jsonData2["Opation"] = "<a class=\"editlink\" href=\"javascript:edit('" + item.ID + "');\">编辑</a><a onclick=\"test('" + item.ID + "');\" style=\"background:url(" + base.Url.Content("~/Images/ico/hammer_screwdriver.png") + ") no-repeat left center; padding-left:18px; margin-left:5px;\" href=\"javascript:void(0);\">测试</a><a onclick=\"table('" + item.ID + "','" + item.Name + "');\" style=\"background:url(" + base.Url.Content("~/Images/ico/topic_search.gif") + ") no-repeat left center; padding-left:18px; margin-left:5px;\" href=\"javascript:void(0);\">管理表</a>";
				jsonData.Add(jsonData2);
			}
			base.ViewBag.Query1 = text;
			base.ViewBag.list = jsonData.ToJson();
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public string Delete()
		{
			RoadFlow.Platform.DBConnection dBConnection = new RoadFlow.Platform.DBConnection();
			string text = base.Request.Form["ids"];
			StringBuilder stringBuilder = new StringBuilder();
			string[] array = text.Split(',');
			for (int i = 0; i < array.Length; i++)
			{
				Guid test;
				if (array[i].IsGuid(out test))
				{
					stringBuilder.Append(dBConnection.Get(test).Serialize());
					dBConnection.Delete(test);
				}
			}
			dBConnection.ClearCache();
			RoadFlow.Platform.Log.Add("删除了数据连接", stringBuilder.ToString(), RoadFlow.Platform.Log.Types.流程相关);
			return "删除成功!";
		}

		public ActionResult Edit()
		{
			return Edit(null);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(FormCollection collection)
		{
			string str = base.Request.QueryString["id"];
			RoadFlow.Platform.DBConnection dBConnection = new RoadFlow.Platform.DBConnection();
			RoadFlow.Data.Model.DBConnection dBConnection2 = null;
			if (str.IsGuid())
			{
				dBConnection2 = dBConnection.Get(str.ToGuid());
			}
			bool flag = !str.IsGuid();
			string oldXML = string.Empty;
			if (dBConnection2 == null)
			{
				dBConnection2 = new RoadFlow.Data.Model.DBConnection();
				dBConnection2.ID = Guid.NewGuid();
			}
			else
			{
				oldXML = dBConnection2.Serialize();
			}
			if (collection != null)
			{
				string text = base.Request.Form["Name"];
				string type = base.Request.Form["LinkType"];
				string connectionString = base.Request.Form["ConnStr"];
				string note = base.Request.Form["Note"];
				dBConnection2.Name = text.Trim();
				dBConnection2.Type = type;
				dBConnection2.ConnectionString = connectionString;
				dBConnection2.Note = note;
				if (flag)
				{
					dBConnection.Add(dBConnection2);
					RoadFlow.Platform.Log.Add("添加了数据库连接", dBConnection2.Serialize(), RoadFlow.Platform.Log.Types.数据连接);
					base.ViewBag.Script = "alert('添加成功!');new RoadUI.Window().reloadOpener();new RoadUI.Window().close();";
				}
				else
				{
					dBConnection.Update(dBConnection2);
					RoadFlow.Platform.Log.Add("修改了数据库连接", "", RoadFlow.Platform.Log.Types.数据连接, oldXML, dBConnection2.Serialize());
					base.ViewBag.Script = "alert('修改成功!');new RoadUI.Window().reloadOpener();new RoadUI.Window().close();";
				}
				dBConnection.ClearCache();
			}
			base.ViewBag.TypeOptions = dBConnection.GetAllTypeOptions(dBConnection2.Type);
			return View(dBConnection2);
		}

		public string Test()
		{
			Guid test;
			if (!base.Request.QueryString["id"].IsGuid(out test))
			{
				return "参数错误";
			}
			return new RoadFlow.Platform.DBConnection().Test(test);
		}

		public ActionResult Table(FormCollection collection)
		{
			string text = base.Request.QueryString["connid"];
			List<Tuple<string, int>> list = new List<Tuple<string, int>>();
			RoadFlow.Platform.DBConnection dBConnection = new RoadFlow.Platform.DBConnection();
			string empty = string.Empty;
			string empty2 = string.Empty;
			List<string> systemDataTables = RoadFlow.Utility.Config.SystemDataTables;
			if (!text.IsGuid())
			{
				base.Response.Write("数据连接ID错误");
				base.Response.End();
				return null;
			}
			RoadFlow.Data.Model.DBConnection dBConnection2 = dBConnection.Get(text.ToGuid());
			if (dBConnection2 == null)
			{
				base.Response.Write("未找到数据连接");
				base.Response.End();
				return null;
			}
			empty2 = dBConnection2.Type;
			foreach (string table2 in dBConnection.GetTables(dBConnection2.ID, 1))
			{
				list.Add(new Tuple<string, int>(table2, 0));
			}
			foreach (string table3 in dBConnection.GetTables(dBConnection2.ID, 2))
			{
				list.Add(new Tuple<string, int>(table3, 1));
			}
			JsonData jsonData = new JsonData();
			foreach (Tuple<string, int> item in list)
			{
				bool flag = systemDataTables.Find((string p) => p.Equals(item.Item1, StringComparison.CurrentCultureIgnoreCase)) != null;
				StringBuilder stringBuilder = new StringBuilder("<a class=\"viewlink\" href=\"javascript:void(0);\" onclick=\"queryTable('" + text + "','" + item.Item1 + "');\">查询</a>");
				JsonData jsonData2 = new JsonData();
				jsonData2["Name"] = item.Item1;
				jsonData2["Type"] = ((item.Item2 == 0) ? (flag ? "系统表" : "表") : "视图");
				jsonData2["Opation"] = stringBuilder.ToString();
				jsonData.Add(jsonData2);
			}
			empty = "&connid=" + text + "&appid=" + base.Request.QueryString["appid"] + "&tabid=" + base.Request.QueryString["tabid"];
			base.ViewBag.Query = empty;
			base.ViewBag.dbconnID = text;
			base.ViewBag.DBType = empty2;
			base.ViewBag.list = jsonData.ToJson();
			return View();
		}

		public ActionResult TableQuery()
		{
			return TableQuery(null);
		}

		[HttpPost]
		public ActionResult TableQuery(FormCollection collection)
		{
			RoadFlow.Platform.DBConnection dBConnection = new RoadFlow.Platform.DBConnection();
			string empty = string.Empty;
			string empty2 = string.Empty;
			RoadFlow.Data.Model.DBConnection dBConnection2 = null;
			string empty3 = string.Empty;
			empty = base.Request.QueryString["tablename"];
			empty2 = base.Request.QueryString["dbconnid"];
			dBConnection2 = dBConnection.Get(empty2.ToGuid());
			if (dBConnection2 == null)
			{
				base.ViewBag.LiteralResult = "未找到数据连接";
				base.ViewBag.LiteralResultCount.Text = "";
				return View();
			}
			if (collection != null)
			{
				empty3 = base.Request.Form["sqltext"];
			}
			else
			{
				if (empty.IsNullOrEmpty())
				{
					base.ViewBag.LiteralResult = "";
					base.ViewBag.LiteralResultCount = "";
					return View();
				}
				empty3 = dBConnection.GetDefaultQuerySql(dBConnection2, empty);
			}
			if (empty3.IsNullOrEmpty())
			{
				base.ViewBag.LiteralResult = "SQL为空！";
				base.ViewBag.LiteralResultCount = "";
				return View();
			}
			if (!dBConnection.CheckSql(empty3))
			{
				base.ViewBag.LiteralResult = "SQL含有破坏系统表的语句，禁止执行！";
				base.ViewBag.LiteralResultCount = "";
				RoadFlow.Platform.Log.Add("尝试执行有破坏系统表的SQL语句", empty3, RoadFlow.Platform.Log.Types.数据连接);
				return View();
			}
			DataTable dataTable = dBConnection.GetDataTable(dBConnection2, empty3);
			RoadFlow.Platform.Log.Add("执行了SQL", empty3, RoadFlow.Platform.Log.Types.数据连接, dataTable.ToJsonString());
			base.ViewBag.LiteralResult = Tools.DataTableToHtml(dataTable);
			base.ViewBag.LiteralResultCount = "(共" + dataTable.Rows.Count + "行)";
			base.ViewBag.sqltext = empty3;
			return View();
		}

		public ActionResult TableDelete()
		{
			return View();
		}

		public ActionResult TableEdit_SqlServer()
		{
			return TableEdit_SqlServer(null);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult TableEdit_SqlServer(FormCollection collection)
		{
			string empty = string.Empty;
			string empty2 = string.Empty;
			RoadFlow.Platform.DBConnection dBConnection = new RoadFlow.Platform.DBConnection();
			DataTable dataTable = new DataTable();
			IDbConnection dbConnection = null;
			List<string> list = new List<string>();
			RoadFlow.Data.Model.DBConnection dBConnection2 = null;
			bool flag = false;
			List<string> systemDataTables = RoadFlow.Utility.Config.SystemDataTables;
			empty = base.Request.QueryString["dbconnid"];
			empty2 = base.Request.QueryString["tablename"];
			if (empty2.IsNullOrEmpty())
			{
				empty2 = "NEWTABLE_" + Tools.GetRandomString();
				flag = true;
			}
			if (empty.IsGuid() && !empty2.IsNullOrEmpty())
			{
				dBConnection2 = dBConnection.Get(empty.ToGuid());
				if (dBConnection2 != null)
				{
					dbConnection = dBConnection.GetConnection(dBConnection2);
					if (dbConnection != null)
					{
						if (dbConnection.State != ConnectionState.Open)
						{
							dbConnection.Open();
						}
						dataTable = dBConnection.GetTableSchema(dbConnection, empty2, dBConnection2.Type);
						list = dBConnection.GetPrimaryKey(dBConnection2, empty2);
					}
				}
			}
			if (flag)
			{
				empty2 = "";
			}
			if (dataTable.Rows.Count == 0)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow["f_name"] = "ID";
				dataRow["t_name"] = "int";
				dataRow["is_null"] = 0;
				dataRow["isidentity"] = 1;
				dataTable.Rows.Add(dataRow);
				list.Add("ID");
			}
			base.ViewBag.PrimaryKeyList = list;
			base.ViewBag.IsAddTable = flag;
			base.ViewBag.tableName = empty2;
			if (collection != null)
			{
				if (dBConnection2 == null)
				{
					base.ViewBag.ClientScript = "alert('未找到数据连接!');";
					return View(dataTable);
				}
				string[] array = (base.Request.Form["f_name"] ?? "").Split(',');
				string text = base.Request.Form["tablename"];
				string oldtablename = base.Request.Form["oldtablename"];
				string text2 = base.Request.Form["delfield"] ?? "";
				StringBuilder stringBuilder = new StringBuilder();
				StringBuilder stringBuilder2 = new StringBuilder();
				if (systemDataTables.Find((string p) => p.Equals(oldtablename, StringComparison.CurrentCultureIgnoreCase)) != null)
				{
					base.ViewBag.ClientScript = "alert('您不能修改系统表!');";
					return View(dataTable);
				}
				string[] array2;
				if (flag)
				{
					stringBuilder.Append("CREATE TABLE [" + text + "] (");
					oldtablename = text;
				}
				else
				{
					foreach (string constraint in dBConnection.GetConstraints(dBConnection2, oldtablename))
					{
						stringBuilder.Append("ALTER TABLE [" + oldtablename + "] DROP CONSTRAINT [" + constraint + "];");
					}
					StringBuilder stringBuilder3 = new StringBuilder();
					array2 = text2.Split(',');
					foreach (string text3 in array2)
					{
						if (!text3.IsNullOrEmpty() && dataTable.Select("f_name='" + text3 + "'").Length != 0)
						{
							stringBuilder3.Append("[" + text3 + "],");
						}
					}
					if (stringBuilder3.Length > 0)
					{
						stringBuilder.Append("ALTER TABLE [" + oldtablename + "] DROP COLUMN " + stringBuilder3.ToString().TrimEnd(',') + ";");
					}
				}
				List<string> list2 = new List<string>();
				array2 = array;
				foreach (string text4 in array2)
				{
					string text5 = base.Request.Form[text4 + "_name1"];
					string text6 = base.Request.Form[text4 + "_type"];
					string text7 = base.Request.Form[text4 + "_length"];
					string b = base.Request.Form[text4 + "_isnull"];
					string b2 = base.Request.Form[text4 + "_isidentity"];
					string b3 = base.Request.Form[text4 + "_primarykey"];
					string text8 = base.Request.Form[text4 + "_defaultvalue"];
					string b4 = base.Request.Form[text4 + "_isadd"];
					if (!text5.IsNullOrEmpty() && !text6.IsNullOrEmpty())
					{
						string text9 = string.Empty;
						switch (text6)
						{
						case "varchar":
						case "nvarchar":
							text9 = text6 + "(" + ((!text7.IsInt()) ? "50" : ((text7.ToInt() == -1) ? "MAX" : text7)) + ")";
							break;
						case "char":
							text9 = text6 + "(" + (text7.IsInt() ? text7 : "50") + ")";
							break;
						case "datetime":
						case "text":
						case "uniqueidentifier":
						case "int":
						case "money":
						case "float":
							text9 = text6;
							break;
						case "decimal":
							text9 = text6 + "(" + (text7.IsNullOrEmpty() ? "18,2" : text7) + ")";
							break;
						}
						string text10 = ("1" == b) ? " NULL" : " NOT NULL";
						string text11 = ("1" == b2) ? " IDENTITY(1,1)" : "";
						bool flag2 = "1" == b4;
						if ("1" == b3)
						{
							list2.Add(text5);
						}
						if (flag)
						{
							stringBuilder.Append("[" + text5 + "] ");
							stringBuilder.Append(text9);
							stringBuilder.Append(" " + text10);
							stringBuilder.Append(" " + text11);
							if (!text8.IsNullOrEmpty())
							{
								stringBuilder.Append(" DEFAULT " + text8);
							}
							if (!text4.Equals(array.Last(), StringComparison.CurrentCultureIgnoreCase))
							{
								stringBuilder.Append(",");
							}
						}
						else
						{
							if (!flag2 && text11.IsNullOrEmpty() && dataTable.Select("f_name='" + text4 + "' and isidentity=1").Length != 0)
							{
								stringBuilder.Append("ALTER TABLE [" + oldtablename + "] DROP COLUMN [" + text4 + "];");
								stringBuilder.Append("ALTER TABLE [" + oldtablename + "] ADD [" + text5 + "] " + text9 + text11 + text10 + ";");
							}
							else if (!text11.IsNullOrEmpty() && !flag2)
							{
								stringBuilder.Append("ALTER TABLE [" + oldtablename + "] DROP COLUMN [" + text4 + "];ALTER TABLE [" + oldtablename + "] ADD [" + text5 + "] int NOT NULL IDENTITY(1,1);");
							}
							else
							{
								if (flag2)
								{
									stringBuilder.Append("ALTER TABLE [" + oldtablename + "] ADD [" + text5 + "] " + text9 + text11 + text10 + ";");
								}
								else
								{
									stringBuilder.Append("ALTER TABLE [" + oldtablename + "] ALTER COLUMN [" + text4 + "] " + text9 + text11 + text10 + ";");
								}
								if (!flag2 && !text4.Equals(text5, StringComparison.CurrentCultureIgnoreCase))
								{
									stringBuilder.Append("EXEC sp_rename N'[" + oldtablename + "].[" + text4 + "]', N'" + text5 + "', 'COLUMN';");
								}
							}
							if (!text8.IsNullOrEmpty())
							{
								stringBuilder.Append("ALTER TABLE [" + oldtablename + "] ADD CONSTRAINT [DF_" + text + "_" + text4 + "] DEFAULT (" + text8 + ") FOR [" + text4 + "];");
							}
						}
					}
				}
				if (flag)
				{
					if (list2.Count > 0)
					{
						stringBuilder.Append(", PRIMARY KEY (");
						foreach (string item in list2)
						{
							stringBuilder.Append("[" + item + "]");
							if (!item.Equals(list2.Last()))
							{
								stringBuilder.Append(",");
							}
						}
						stringBuilder.Append(")");
					}
					stringBuilder.Append(")");
				}
				else
				{
					if (list2.Count > 0)
					{
						stringBuilder2.Append("ALTER TABLE [" + text + "] ADD CONSTRAINT [PK_" + text + "] PRIMARY KEY (");
						foreach (string item2 in list2)
						{
							stringBuilder2.Append("[" + item2 + "]");
							if (!item2.Equals(list2.Last()))
							{
								stringBuilder2.Append(",");
							}
						}
						stringBuilder2.Append(");");
					}
					if (!text.Equals(oldtablename, StringComparison.CurrentCultureIgnoreCase))
					{
						stringBuilder.Append("EXEC sp_rename '" + oldtablename + "', '" + text + "';");
					}
				}
				string text12 = stringBuilder.ToString();
				string msg;
				bool flag3 = dBConnection.TestSql(dBConnection2, text12, out msg, false);
				if (flag3 && stringBuilder2.Length > 0)
				{
					flag3 = dBConnection.TestSql(dBConnection2, stringBuilder2.ToString(), out msg, false);
				}
				string text13 = "TableEdit_SqlServer?dbconnid=" + empty + "&tablename=" + text + "&connid=" + empty + "&appid=" + base.Request.QueryString["appid"] + "&tabid=" + base.Request.QueryString["tabid"] + "&s_Name=" + base.Request.QueryString["s_Name"];
				if (flag3)
				{
					RoadFlow.Platform.Log.Add("修改表结构成功-" + dBConnection2.Name + "-" + oldtablename, text12, RoadFlow.Platform.Log.Types.数据连接);
					base.ViewBag.ClientScript = "alert('保存成功!');window.location='" + text13 + "';";
					return View(dataTable);
				}
				RoadFlow.Platform.Log.Add("修改表结构失败-" + dBConnection2.Name + "-" + oldtablename, text12, RoadFlow.Platform.Log.Types.数据连接);
				base.ViewBag.ClientScript = "alert('保存失败-" + msg.Replace("'", "") + "!');window.location='" + text13 + "';";
				return View(dataTable);
			}
			return View(dataTable);
		}

		public ActionResult TableEdit_Oracle()
		{
			return TableEdit_Oracle(null);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult TableEdit_Oracle(FormCollection collection)
		{
			string empty = string.Empty;
			string empty2 = string.Empty;
			RoadFlow.Platform.DBConnection dBConnection = new RoadFlow.Platform.DBConnection();
			DataTable dataTable = new DataTable();
			IDbConnection dbConnection = null;
			List<string> list = new List<string>();
			RoadFlow.Data.Model.DBConnection dBConnection2 = null;
			bool flag = false;
			List<string> systemDataTables = RoadFlow.Utility.Config.SystemDataTables;
			empty = base.Request.QueryString["dbconnid"];
			empty2 = base.Request.QueryString["tablename"];
			if (empty2.IsNullOrEmpty())
			{
				empty2 = "NEWTABLE_" + Tools.GetRandomString();
				flag = true;
			}
			if (empty.IsGuid() && !empty2.IsNullOrEmpty())
			{
				dBConnection2 = dBConnection.Get(empty.ToGuid());
				if (dBConnection2 != null)
				{
					dbConnection = dBConnection.GetConnection(dBConnection2);
					if (dbConnection != null)
					{
						if (dbConnection.State != ConnectionState.Open)
						{
							dbConnection.Open();
						}
						dataTable = dBConnection.GetTableSchema(dbConnection, empty2, dBConnection2.Type);
						list = dBConnection.GetPrimaryKey(dBConnection2, empty2);
					}
				}
			}
			if (flag)
			{
				empty2 = "";
			}
			if (dataTable.Rows.Count == 0)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow["f_name"] = "ID";
				dataRow["t_name"] = "int";
				dataRow["is_null"] = 0;
				dataRow["isidentity"] = 1;
				dataTable.Rows.Add(dataRow);
				list.Add("ID");
			}
			base.ViewBag.PrimaryKeyList = list;
			base.ViewBag.IsAddTable = flag;
			base.ViewBag.tableName = empty2;
			if (collection != null)
			{
				if (dBConnection2 == null)
				{
					base.ViewBag.ClientScript = "alert('未找到数据连接!');";
					return View(dataTable);
				}
				string[] array = (base.Request.Form["f_name"] ?? "").Split(',');
				string text = base.Request.Form["tablename"];
				string oldtablename = base.Request.Form["oldtablename"];
				string text2 = base.Request.Form["delfield"] ?? "";
				new StringBuilder();
				List<string> list2 = new List<string>();
				string text3 = "temp_" + Guid.NewGuid().ToString("N");
				if (systemDataTables.Find((string p) => p.Equals(oldtablename, StringComparison.CurrentCultureIgnoreCase)) != null)
				{
					base.ViewBag.ClientScript = "alert('您不能修改系统表!');";
					return View(dataTable);
				}
				if (flag)
				{
					list2.Add("CREATE TABLE \"" + text + "\" (\"" + text3 + "\" varchar2(50) NULL)");
					oldtablename = text;
				}
				if (list.Count > 0)
				{
					list2.Add("ALTER TABLE \"" + oldtablename + "\" DROP PRIMARY KEY");
				}
				StringBuilder stringBuilder = new StringBuilder();
				string[] array2 = text2.Split(',');
				foreach (string text4 in array2)
				{
					if (!text4.IsNullOrEmpty())
					{
						stringBuilder.Append("\"" + text4 + "\",");
					}
				}
				if (stringBuilder.Length > 0)
				{
					list2.Add("ALTER TABLE \"" + oldtablename + "\" DROP (" + stringBuilder.ToString().TrimEnd(',') + ")");
				}
				StringBuilder stringBuilder2 = new StringBuilder();
				array2 = array;
				foreach (string text5 in array2)
				{
					string text6 = base.Request.Form[text5 + "_name1"];
					string text7 = base.Request.Form[text5 + "_type"];
					string text8 = base.Request.Form[text5 + "_length"];
					string b = base.Request.Form[text5 + "_isnull"];
					string text9 = base.Request.Form[text5 + "_isidentity"];
					string b2 = base.Request.Form[text5 + "_primarykey"];
					string text10 = base.Request.Form[text5 + "_defaultvalue"];
					string b3 = base.Request.Form[text5 + "_isadd"];
					if (!text6.IsNullOrEmpty() && !text7.IsNullOrEmpty())
					{
						string text11 = string.Empty;
						switch (text7.ToLower())
						{
						case "varchar2":
						case "nvarchar2":
							text11 = text7 + "(" + ((!text8.IsInt()) ? "50" : ((text8.ToInt() == -1) ? "50" : text8)) + ")";
							break;
						case "char":
							text11 = text7 + "(" + (text8.IsInt() ? text8 : "50") + ")";
							break;
						case "date":
						case "clog":
						case "nclog":
						case "int":
						case "float":
							text11 = text7;
							break;
						case "number":
							text11 = text7 + "(" + (text8.IsNullOrEmpty() ? "18,2" : text8) + ")";
							break;
						}
						int num = (dataTable.Select("F_Name='" + text5 + "'").Length != 0) ? dataTable.Select("F_Name='" + text5 + "'")[0]["IS_NULL"].ToString().ToInt() : (-1);
						string text12 = "";
						if ("1" == b)
						{
							if (num == 0)
							{
								text12 = " NULL";
							}
						}
						else if (num == 1)
						{
							text12 = " NOT NULL";
						}
						string text13 = ("1" == text9) ? " " : "";
						string text14 = (!text10.IsNullOrEmpty()) ? (" DEFAULT " + text10) : "";
						bool flag2 = "1" == b3;
						if (flag2)
						{
							list2.Add("ALTER TABLE \"" + oldtablename + "\" ADD (\"" + text6 + "\" " + text11 + text13 + text14 + text12 + ")");
						}
						else if (!text9.IsNullOrEmpty())
						{
							list2.Add("ALTER TABLE \"" + oldtablename + "\" MODIFY (\"" + text6 + "\" " + text11 + text13 + text14 + text12 + ")");
						}
						else
						{
							list2.Add("ALTER TABLE \"" + oldtablename + "\" MODIFY (\"" + text5 + "\" " + text11 + text13 + text14 + text12 + ")");
						}
						if ("1" == b2)
						{
							stringBuilder2.Append("\"" + text6 + "\",");
						}
						if (!flag2 && !text5.Equals(text6, StringComparison.CurrentCultureIgnoreCase))
						{
							list2.Add("ALTER TABLE \"" + oldtablename + "\" RENAME COLUMN \"" + text5 + "\" TO \"" + text6 + "\"");
						}
					}
				}
				if (stringBuilder2.Length > 0)
				{
					list2.Add("ALTER TABLE \"" + oldtablename + "\" ADD CONSTRAINT \"" + text + "_PK\" PRIMARY KEY (" + stringBuilder2.ToString().TrimEnd(',') + ")");
				}
				if (!text.Equals(oldtablename, StringComparison.CurrentCultureIgnoreCase))
				{
					list2.Add("ALTER TABLE \"" + oldtablename + "\" RENAME TO \"" + text + "\"");
				}
				if (flag)
				{
					list2.Add("ALTER TABLE \"" + oldtablename + "\" DROP (\"" + text3 + "\")");
				}
				string contents = list2.ToString(";");
				bool flag3 = true;
				foreach (string item in list2)
				{
					if (!dBConnection.TestSql(dBConnection2, item, false) && flag3)
					{
						flag3 = false;
					}
				}
				string str = "TableEdit_Oracle?dbconnid=" + empty + "&tablename=" + text + "&connid=" + empty + "&appid=" + base.Request.QueryString["appid"] + "&tabid=" + base.Request.QueryString["tabid"] + "&s_Name=" + base.Request.QueryString["s_Name"];
				if (flag3)
				{
					RoadFlow.Platform.Log.Add("修改表结构成功-" + dBConnection2.Name + "-" + oldtablename, contents, RoadFlow.Platform.Log.Types.数据连接);
					base.ViewBag.ClientScript = "alert('保存成功!');window.location='" + str + "';";
					return View(dataTable);
				}
				RoadFlow.Platform.Log.Add("修改表结构失败-" + dBConnection2.Name + "-" + oldtablename, contents, RoadFlow.Platform.Log.Types.数据连接);
				base.ViewBag.ClientScript = "alert('保存失败!');window.location='" + str + "';";
				return View(dataTable);
			}
			return View(dataTable);
		}

		public ActionResult TableEdit_MySql()
		{
			return TableEdit_MySql(null);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult TableEdit_MySql(FormCollection collection)
		{
			string empty = string.Empty;
			string empty2 = string.Empty;
			RoadFlow.Platform.DBConnection dBConnection = new RoadFlow.Platform.DBConnection();
			DataTable dataTable = new DataTable();
			IDbConnection dbConnection = null;
			List<string> list = new List<string>();
			RoadFlow.Data.Model.DBConnection dBConnection2 = null;
			bool flag = false;
			List<string> systemDataTables = RoadFlow.Utility.Config.SystemDataTables;
			empty = base.Request.QueryString["dbconnid"];
			empty2 = base.Request.QueryString["tablename"];
			if (empty2.IsNullOrEmpty())
			{
				empty2 = "NEWTABLE_" + Tools.GetRandomString();
				flag = true;
			}
			if (empty.IsGuid() && !empty2.IsNullOrEmpty())
			{
				dBConnection2 = dBConnection.Get(empty.ToGuid());
				if (dBConnection2 != null)
				{
					dbConnection = dBConnection.GetConnection(dBConnection2);
					if (dbConnection != null)
					{
						if (dbConnection.State != ConnectionState.Open)
						{
							dbConnection.Open();
						}
						if (!flag)
						{
							dataTable = dBConnection.GetTableSchema(dbConnection, empty2, dBConnection2.Type);
							list = dBConnection.GetPrimaryKey(dBConnection2, empty2);
						}
						else
						{
							dataTable = dBConnection.GetTableSchema(dbConnection, "Log", dBConnection2.Type);
							dataTable.Rows.Clear();
						}
					}
				}
			}
			if (flag)
			{
				empty2 = "";
			}
			if (dataTable.Rows.Count == 0)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow["f_name"] = "ID";
				dataRow["t_name"] = "int";
				dataRow["is_null"] = 0;
				dataRow["isidentity"] = 1;
				dataTable.Rows.Add(dataRow);
				list.Add("ID");
			}
			base.ViewBag.PrimaryKeyList = list;
			base.ViewBag.IsAddTable = flag;
			base.ViewBag.tableName = empty2;
			if (collection != null)
			{
				if (dBConnection2 == null)
				{
					base.ViewBag.ClientScript = "alert('未找到数据连接!');";
					return View(dataTable);
				}
				string[] array = (base.Request.Form["f_name"] ?? "").Split(',');
				string text = base.Request.Form["tablename"];
				string oldtablename = base.Request.Form["oldtablename"];
				string text2 = base.Request.Form["delfield"] ?? "";
				StringBuilder stringBuilder = new StringBuilder();
				string text3 = "temp_" + Guid.NewGuid().ToString("N");
				if (systemDataTables.Find((string p) => p.Equals(oldtablename, StringComparison.CurrentCultureIgnoreCase)) != null)
				{
					base.ViewBag.ClientScript = "alert('您不能修改系统表!');";
					return View(dataTable);
				}
				if (flag)
				{
					stringBuilder.Append("CREATE TABLE `" + text + "` (`" + text3 + "` varchar(255) PRIMARY KEY NOT NULL);");
					oldtablename = text;
				}
				stringBuilder.Append("ALTER TABLE `" + oldtablename + "` ");
				if (list.Count > 0)
				{
					stringBuilder.Append("DROP PRIMARY KEY,");
				}
				string[] array2 = text2.Split(',');
				foreach (string text4 in array2)
				{
					if (!text4.IsNullOrEmpty())
					{
						stringBuilder.Append("DROP COLUMN `" + text4 + "`,");
					}
				}
				array2 = array;
				foreach (string text5 in array2)
				{
					string text6 = base.Request.Form[text5 + "_name1"];
					string text7 = base.Request.Form[text5 + "_type"];
					string text8 = base.Request.Form[text5 + "_length"];
					string b = base.Request.Form[text5 + "_isnull"];
					string text9 = base.Request.Form[text5 + "_isidentity"];
					string b2 = base.Request.Form[text5 + "_primarykey"];
					string text10 = base.Request.Form[text5 + "_defaultvalue"];
					string b3 = base.Request.Form[text5 + "_isadd"];
					if (!text6.IsNullOrEmpty() && !text7.IsNullOrEmpty())
					{
						string text11 = string.Empty;
						switch (text7)
						{
						case "varchar":
							text11 = text7 + "(" + ((!text8.IsInt()) ? "255" : ((text8.ToInt() <= -1) ? "255" : text8)) + ")";
							break;
						case "char":
							text11 = text7 + "(" + (text8.IsInt() ? text8 : "255") + ")";
							break;
						case "datetime":
						case "text":
						case "longtext":
						case "int":
						case "float":
							text11 = text7;
							break;
						case "decimal":
							text11 = text7 + "(" + (text8.IsNullOrEmpty() ? "18,2" : text8) + ")";
							break;
						}
						string text12 = ("1" == b) ? " NULL" : " NOT NULL";
						string text13 = ("1" == text9) ? " AUTO_INCREMENT" : "";
						string text14 = text10.IsNullOrEmpty() ? "" : (" DEFAULT " + text10);
						bool flag2 = "1" == b3;
						if (flag2)
						{
							stringBuilder.Append("ADD COLUMN `" + text6 + "` " + text11 + text13 + text12 + ",");
						}
						else if (!text9.IsNullOrEmpty())
						{
							stringBuilder.Append("MODIFY COLUMN `" + text6 + "` " + text11 + text13 + text12 + text14 + ",");
						}
						else if (!flag2 && !text5.Equals(text6, StringComparison.CurrentCultureIgnoreCase))
						{
							stringBuilder.Append("CHANGE COLUMN `" + text5 + "` `" + text6 + "` " + text11 + text13 + text12 + text14 + ",");
						}
						else
						{
							stringBuilder.Append("MODIFY COLUMN `" + text5 + "` " + text11 + text13 + text12 + text14 + ",");
						}
						if ("1" == b2)
						{
							stringBuilder.Append("ADD PRIMARY KEY (`" + text5 + "`),");
						}
					}
				}
				if (!text.Equals(oldtablename, StringComparison.CurrentCultureIgnoreCase))
				{
					stringBuilder.Append("RENAME TABLE `" + oldtablename + "` TO `" + text + "`,");
				}
				if (flag)
				{
					stringBuilder.Append("DROP COLUMN `" + text3 + "`,");
				}
				string text15 = stringBuilder.ToString().TrimEnd(',') + ";";
				bool flag3 = dBConnection.TestSql(dBConnection2, text15, false);
				string str = "TableEdit_MySql?dbconnid=" + empty + "&tablename=" + text + "&connid=" + empty + "&appid=" + base.Request.QueryString["appid"] + "&tabid=" + base.Request.QueryString["tabid"] + "&s_Name=" + base.Request.QueryString["s_Name"];
				if (flag3)
				{
					RoadFlow.Platform.Log.Add("修改表结构成功-" + dBConnection2.Name + "-" + oldtablename, text15, RoadFlow.Platform.Log.Types.数据连接);
					base.ViewBag.ClientScript = "alert('保存成功!');window.location='" + str + "';";
					return View(dataTable);
				}
				RoadFlow.Platform.Log.Add("修改表结构失败-" + dBConnection2.Name + "-" + oldtablename, text15, RoadFlow.Platform.Log.Types.数据连接);
				base.ViewBag.ClientScript = "alert('保存失败!');window.location='" + str + "';";
				return View(dataTable);
			}
			return View(dataTable);
		}
	}
}
