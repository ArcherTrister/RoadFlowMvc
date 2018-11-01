using RoadFlow.Cache.IO;
using RoadFlow.Data.Factory;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Web;

namespace RoadFlow.Platform
{
	public class ProgramBuilder
	{
		public static string exportCackeKey = "ExportToExcel_";

		private IProgramBuilder dataProgramBuilder;

		public ProgramBuilder()
		{
			dataProgramBuilder = Factory.GetProgramBuilder();
		}

		public int Add(RoadFlow.Data.Model.ProgramBuilder model)
		{
			return dataProgramBuilder.Add(model);
		}

		public int Update(RoadFlow.Data.Model.ProgramBuilder model)
		{
			return dataProgramBuilder.Update(model);
		}

		public List<RoadFlow.Data.Model.ProgramBuilder> GetAll()
		{
			return dataProgramBuilder.GetAll();
		}

		public RoadFlow.Data.Model.ProgramBuilder Get(Guid id)
		{
			return dataProgramBuilder.Get(id);
		}

		public int Delete(Guid id)
		{
			return dataProgramBuilder.Delete(id);
		}

		public long GetCount()
		{
			return dataProgramBuilder.GetCount();
		}

		public List<RoadFlow.Data.Model.ProgramBuilder> GetList(out string pager, string query = "", string name = "", string typeid = "")
		{
			if (typeid.IsGuid())
			{
				typeid = new Dictionary().GetAllChildsIDString(typeid.ToGuid());
			}
			return dataProgramBuilder.GetList(out pager, query, name, typeid);
		}

		public List<string> GetFields(Guid id)
		{
			RoadFlow.Data.Model.ProgramBuilder programBuilder = Get(id);
			if (programBuilder == null)
			{
				return new List<string>();
			}
			return new DBConnection().GetFieldsBySQL(programBuilder.DBConnID, programBuilder.SQL);
		}

		public string GetFieldsOptions(Guid id, string value)
		{
			List<string> fields = GetFields(id);
			StringBuilder stringBuilder = new StringBuilder();
			foreach (string item in fields)
			{
				stringBuilder.AppendFormat("<option value=\"{0}\" {1}>{2}</option>", item, (item == value) ? "selected=\"selected\"" : "", item);
			}
			return stringBuilder.ToString();
		}

		public void DeleteAllSet(Guid id)
		{
			RoadFlow.Data.Model.ProgramBuilder programBuilder = Get(id);
			if (programBuilder != null)
			{
				programBuilder.Status = 2;
				Update(programBuilder);
				Log.Add("删除了应用程序设计", id.ToString());
			}
		}

		public void AddToCache(ProgramBuilderCache pb)
		{
			Opation.Set(15.ToString() + pb.Program.ID.ToString("N"), pb);
		}

		public ProgramBuilderCache GetSet(Guid id)
		{
			object obj = Opation.Get(15.ToString() + id.ToString("N"));
			if (obj != null)
			{
				return (ProgramBuilderCache)obj;
			}
			ProgramBuilderCache programBuilderCache = new ProgramBuilderCache();
			RoadFlow.Data.Model.ProgramBuilder programBuilder = Get(id);
			if (programBuilder == null)
			{
				return null;
			}
			programBuilderCache.Program = programBuilder;
			programBuilderCache.Fields = (from p in new ProgramBuilderFields().GetAll(id)
			orderby p.Sort
			select p).ToList();
			programBuilderCache.Querys = (from p in new ProgramBuilderQuerys().GetAll(id)
			orderby p.Sort
			select p).ToList();
			programBuilderCache.Buttons = (from p in new ProgramBuilderButtons().GetAll(id)
			orderby p.Sort
			select p).ToList();
			programBuilderCache.Validates = new ProgramBuilderValidates().GetAll(id);
			programBuilderCache.Export = (from p in new ProgramBuilderExport().GetAll(id)
			orderby p.Sort
			select p).ToList();
			AddToCache(programBuilderCache);
			return programBuilderCache;
		}

		public bool Publish(Guid id, bool isMvc = false)
		{
			RoadFlow.Data.Model.ProgramBuilder programBuilder = Get(id);
			if (programBuilder == null || programBuilder.Name.IsNullOrEmpty() || programBuilder.SQL.IsNullOrEmpty())
			{
				return false;
			}
			AppLibrary appLibrary = new AppLibrary();
			RoadFlow.Data.Model.AppLibrary appLibrary2 = appLibrary.GetByCode(id.ToString());
			bool flag = false;
			using (TransactionScope transactionScope = new TransactionScope())
			{
				if (appLibrary2 == null)
				{
					flag = true;
					appLibrary2 = new RoadFlow.Data.Model.AppLibrary();
					appLibrary2.ID = Guid.NewGuid();
				}
				appLibrary2.Address = ((!isMvc) ? ("/Platform/ProgramBuilder/Run.aspx?programid=" + id.ToString()) : ("/ProgramBuilder/Run?programid=" + id.ToString()));
				appLibrary2.Code = id.ToString();
				appLibrary2.OpenMode = 0;
				appLibrary2.Title = programBuilder.Name;
				appLibrary2.Type = programBuilder.Type;
				if (flag)
				{
					appLibrary.Add(appLibrary2);
				}
				else
				{
					appLibrary.Update(appLibrary2);
				}
				programBuilder.Status = 1;
				Update(programBuilder);
				List<RoadFlow.Data.Model.ProgramBuilderButtons> all = new ProgramBuilderButtons().GetAll(programBuilder.ID);
				AppLibraryButtons1 appLibraryButtons = new AppLibraryButtons1();
				List<RoadFlow.Data.Model.AppLibraryButtons1> allByAppID = appLibraryButtons.GetAllByAppID(appLibrary2.ID);
				List<RoadFlow.Data.Model.AppLibraryButtons1> list = new List<RoadFlow.Data.Model.AppLibraryButtons1>();
				foreach (RoadFlow.Data.Model.ProgramBuilderButtons item in all)
				{
					RoadFlow.Data.Model.AppLibraryButtons1 appLibraryButtons2 = allByAppID.Find((RoadFlow.Data.Model.AppLibraryButtons1 p) => p.ID == item.ID);
					bool flag2 = false;
					if (appLibraryButtons2 == null)
					{
						appLibraryButtons2 = new RoadFlow.Data.Model.AppLibraryButtons1();
						flag2 = true;
					}
					appLibraryButtons2.AppLibraryID = appLibrary2.ID;
					appLibraryButtons2.ButtonID = item.ButtonID;
					appLibraryButtons2.Events = item.ClientScript;
					appLibraryButtons2.Ico = (item.Ico ?? "");
					appLibraryButtons2.ID = item.ID;
					appLibraryButtons2.Name = item.ButtonName;
					appLibraryButtons2.ShowType = item.ShowType;
					appLibraryButtons2.Sort = item.Sort;
					appLibraryButtons2.Type = 0;
					appLibraryButtons2.IsValidateShow = item.IsValidateShow;
					if (flag2)
					{
						appLibraryButtons.Add(appLibraryButtons2);
					}
					else
					{
						appLibraryButtons.Update(appLibraryButtons2);
					}
					list.Add(appLibraryButtons2);
				}
				foreach (RoadFlow.Data.Model.AppLibraryButtons1 item2 in allByAppID)
				{
					if (list.Find((RoadFlow.Data.Model.AppLibraryButtons1 p) => p.ID == item2.ID) == null)
					{
						appLibraryButtons.Delete(item2.ID);
					}
				}
				transactionScope.Complete();
			}
			new AppLibrary().ClearCache();
			new Menu().ClearAllDataTableCache();
			new AppLibraryButtons1().ClearCache();
			new AppLibrarySubPages().ClearCache();
			ProgramBuilderCache programBuilderCache = new ProgramBuilderCache();
			programBuilderCache.Program = programBuilder;
			programBuilderCache.Fields = (from p in new ProgramBuilderFields().GetAll(programBuilder.ID)
			orderby p.Sort
			select p).ToList();
			programBuilderCache.Querys = (from p in new ProgramBuilderQuerys().GetAll(programBuilder.ID)
			orderby p.Sort
			select p).ToList();
			programBuilderCache.Buttons = (from p in new ProgramBuilderButtons().GetAll(id)
			orderby p.Sort
			select p).ToList();
			programBuilderCache.Validates = new ProgramBuilderValidates().GetAll(id);
			programBuilderCache.Export = (from p in new ProgramBuilderExport().GetAll(id)
			orderby p.Sort
			select p).ToList();
			AddToCache(programBuilderCache);
			return true;
		}

		public string GetJsonString(Guid id)
		{
			ProgramBuilderCache set = GetSet(id);
			if (set == null || set.Validates == null)
			{
				return "{}";
			}
			StringBuilder stringBuilder = new StringBuilder();
			foreach (RoadFlow.Data.Model.ProgramBuilderValidates validate in set.Validates)
			{
				string text = validate.TableName + "_" + validate.FieldName;
				stringBuilder.AppendFormat("\"{0}\":\"{1}\"", text.ToLower(), "0_" + validate.Validate);
				stringBuilder.Append(",");
			}
			return "{" + stringBuilder.ToString().TrimEnd(',') + "}";
		}

		public void AddToExportCache(Guid programID, Guid dbConnID, string querySql, List<IDbDataParameter> parList)
		{
			string str = exportCackeKey + programID.ToString("N") + HttpContext.Current.Session.SessionID;
			Opation.Set(str + "_DbConnID", dbConnID);
			Opation.Set(str + "_QuerySql", querySql);
			Opation.Set(str + "_QueryParameter", parList);
		}

		public Guid GetExportCache(Guid programID, out string querySql, out List<IDbDataParameter> parList)
		{
			querySql = "";
			parList = new List<IDbDataParameter>();
			string str = exportCackeKey + programID.ToString("N") + HttpContext.Current.Session.SessionID;
			object obj = Opation.Get(str + "_QuerySql");
			if (obj != null)
			{
				querySql = obj.ToString();
			}
			object obj2 = Opation.Get(str + "_QueryParameter");
			if (obj2 != null)
			{
				parList = (List<IDbDataParameter>)obj2;
			}
			object obj3 = Opation.Get(str + "_DbConnID");
			if (obj3 != null)
			{
				return obj3.ToString().ToGuid();
			}
			return Guid.Empty;
		}

		public DataTable GetExportDataTable(Guid programID, out string template, out string headerText, out string fileName)
		{
			template = "";
			headerText = "";
			fileName = "";
			ProgramBuilderCache set = GetSet(programID);
			if (set == null)
			{
				return new DataTable();
			}
			template = Files.FilePath + set.Program.ExportTemplate.DesDecrypt();
			headerText = set.Program.ExportHeaderText;
			fileName = set.Program.ExportFileName;
			string querySql;
			List<IDbDataParameter> parList;
			Guid exportCache = GetExportCache(programID, out querySql, out parList);
			DBConnection dBConnection = new DBConnection();
			Guid connID = exportCache;
			string sql = querySql;
			IDataParameter[] param = parList.ToArray();
			DataTable dataTable = dBConnection.GetDataTable(connID, sql, param);
			List<RoadFlow.Data.Model.ProgramBuilderExport> export = set.Export;
			DataTable dataTable2 = new DataTable();
			foreach (RoadFlow.Data.Model.ProgramBuilderExport item in export)
			{
				DataColumn dataColumn = new DataColumn(item.ShowTitle, GetExportColumnsType(item.DataType.HasValue ? item.DataType.Value : 0));
				dataColumn.Caption = item.Width.ToString();
				dataTable2.Columns.Add(dataColumn);
			}
			int num = 1;
			Dictionary dictionary = new Dictionary();
			Organize organize = new Organize();
			foreach (DataRow row in dataTable.Rows)
			{
				DataRow dataRow2 = dataTable2.NewRow();
				foreach (RoadFlow.Data.Model.ProgramBuilderExport item2 in export)
				{
					object empty = string.Empty;
					object obj = item2.Field.IsNullOrEmpty() ? "" : row[item2.Field];
					switch (item2.ShowType)
					{
					case 0:
						empty = obj;
						break;
					case 1:
						empty = num.ToString();
						break;
					case 2:
						empty = obj.ToString().ToDateTime().ToString(item2.ShowFormat);
						break;
					case 3:
						empty = obj.ToString().ToDecimal().ToString(item2.ShowFormat);
						break;
					case 4:
						empty = dictionary.GetTitle(obj.ToString().ToGuid());
						break;
					case 5:
						empty = organize.GetNames(obj.ToString());
						break;
					case 6:
						empty = item2.CustomString;
						break;
					default:
						empty = obj;
						break;
					}
					dataRow2[item2.ShowTitle] = empty;
				}
				num++;
				dataTable2.Rows.Add(dataRow2);
			}
			return dataTable2;
		}

		private Type GetExportColumnsType(int type)
		{
			Type type2 = "".GetType();
			switch (type)
			{
			case 0:
			case 1:
				type2 = "".GetType();
				break;
			case 2:
				type2 = decimal.MaxValue.GetType();
				break;
			case 3:
				type2 = DateTime.Now.GetType();
				break;
			}
			return type2;
		}

		public int InDataFormExcel(Guid programID, string table, string file, out string msg, string numberFiled = "")
		{
			int result = 0;
			msg = "";
			if (table.IsNullOrEmpty())
			{
				msg = "没有选择表";
				return result;
			}
			DBConnection dBConnection = new DBConnection();
			RoadFlow.Data.Model.ProgramBuilder programBuilder = Get(programID);
			if (programBuilder == null)
			{
				msg = "未找到应用程序设计";
				return result;
			}
			RoadFlow.Data.Model.DBConnection dBConnection2 = dBConnection.Get(programBuilder.DBConnID);
			if (dBConnection2 == null)
			{
				msg = "未找到相应的数据库连接";
				return result;
			}
			List<RoadFlow.Data.Model.ProgramBuilderFields> all = new ProgramBuilderFields().GetAll(programID);
			if (all.Count != 0)
			{
				try
				{
					DataTable dataTable = NPOIHelper.ReadToDataTable(file);
					if (dataTable.Rows.Count == 0)
					{
						msg = "未发现要导入的数据";
						return result;
					}
					List<string> fieldsBySQL = dBConnection.GetFieldsBySQL(programBuilder.DBConnID, "select * from " + table + " where 1=0");
					DataTable dataTable2 = new DataTable(table);
					string text = DateTimeNew.Now.ToString("yyyyMMddHHmmssfffff");
					foreach (RoadFlow.Data.Model.ProgramBuilderFields item in all)
					{
						if (!item.Field.IsNullOrEmpty() && fieldsBySQL.Find((string p) => p.Equals(item.Field, StringComparison.CurrentCultureIgnoreCase)) != null)
						{
							dataTable2.Columns.Add(item.Field);
						}
					}
					if (!numberFiled.IsNullOrEmpty())
					{
						dataTable2.Columns.Add(numberFiled);
					}
					foreach (DataRow row in dataTable.Rows)
					{
						DataRow dataRow2 = dataTable2.NewRow();
						foreach (DataColumn column in dataTable2.Columns)
						{
							RoadFlow.Data.Model.ProgramBuilderFields programBuilderFields = all.Find((RoadFlow.Data.Model.ProgramBuilderFields p) => p.Field.Equals(column.ColumnName));
							if (programBuilderFields != null)
							{
								dataRow2[column.ColumnName] = row[programBuilderFields.ShowTitle];
							}
						}
						if (!numberFiled.IsNullOrEmpty())
						{
							dataRow2[numberFiled] = text;
						}
						dataTable2.Rows.Add(dataRow2);
					}
					result = dBConnection.DataTableToDB(dBConnection2, dataTable2);
					Log.Add("通过应用程序导入了数据-表(" + table + ")标识(" + text + ")", file);
					return result;
				}
				catch (Exception ex)
				{
					msg = ex.Message;
					return result;
				}
			}
			msg = "应用程序未设置列表字段";
			return result;
		}
	}
}
