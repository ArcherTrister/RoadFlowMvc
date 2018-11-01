using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RoadFlow.Data.MSSQL
{
	public class AppLibraryButtons : IAppLibraryButtons
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.AppLibraryButtons model)
		{
			string sql = "INSERT INTO AppLibraryButtons\r\n\t\t\t\t(ID,Name,Events,Ico,Sort,Note) \r\n\t\t\t\tVALUES(@ID,@Name,@Events,@Ico,@Sort,@Note)";
			SqlParameter[] parameter = new SqlParameter[6]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ID
				},
				new SqlParameter("@Name", SqlDbType.NVarChar, 100)
				{
					Value = model.Name
				},
				new SqlParameter("@Events", SqlDbType.VarChar, 5000)
				{
					Value = model.Events
				},
				(model.Ico == null) ? new SqlParameter("@Ico", SqlDbType.VarChar, 5000)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Ico", SqlDbType.VarChar, 5000)
				{
					Value = model.Ico
				},
				new SqlParameter("@Sort", SqlDbType.Int, -1)
				{
					Value = model.Sort
				},
				(model.Note == null) ? new SqlParameter("@Note", SqlDbType.NVarChar, 1000)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Note", SqlDbType.NVarChar, 1000)
				{
					Value = model.Note
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.AppLibraryButtons model)
		{
			string sql = "UPDATE AppLibraryButtons SET \r\n\t\t\t\tName=@Name,Events=@Events,Ico=@Ico,Sort=@Sort,Note=@Note\r\n\t\t\t\tWHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[6]
			{
				new SqlParameter("@Name", SqlDbType.NVarChar, 100)
				{
					Value = model.Name
				},
				new SqlParameter("@Events", SqlDbType.VarChar, 5000)
				{
					Value = model.Events
				},
				(model.Ico == null) ? new SqlParameter("@Ico", SqlDbType.VarChar, 5000)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Ico", SqlDbType.VarChar, 5000)
				{
					Value = model.Ico
				},
				new SqlParameter("@Sort", SqlDbType.Int, -1)
				{
					Value = model.Sort
				},
				(model.Note == null) ? new SqlParameter("@Note", SqlDbType.NVarChar, 1000)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Note", SqlDbType.NVarChar, 1000)
				{
					Value = model.Note
				},
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ID
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public int Delete(Guid id)
		{
			string sql = "DELETE FROM AppLibraryButtons WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.AppLibraryButtons> DataReaderToList(SqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.AppLibraryButtons> list = new List<RoadFlow.Data.Model.AppLibraryButtons>();
			RoadFlow.Data.Model.AppLibraryButtons appLibraryButtons = null;
			while (dataReader.Read())
			{
				appLibraryButtons = new RoadFlow.Data.Model.AppLibraryButtons();
				appLibraryButtons.ID = dataReader.GetGuid(0);
				appLibraryButtons.Name = dataReader.GetString(1);
				appLibraryButtons.Events = dataReader.GetString(2);
				if (!dataReader.IsDBNull(3))
				{
					appLibraryButtons.Ico = dataReader.GetString(3);
				}
				appLibraryButtons.Sort = dataReader.GetInt32(4);
				if (!dataReader.IsDBNull(5))
				{
					appLibraryButtons.Note = dataReader.GetString(5);
				}
				list.Add(appLibraryButtons);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.AppLibraryButtons> GetAll()
		{
			string sql = "SELECT * FROM AppLibraryButtons";
			SqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.AppLibraryButtons> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM AppLibraryButtons";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.AppLibraryButtons Get(Guid id)
		{
			string sql = "SELECT * FROM AppLibraryButtons WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.AppLibraryButtons> list = DataReaderToList(dataReader);
			dataReader.Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public List<RoadFlow.Data.Model.AppLibraryButtons> GetPagerData(out string pager, string query = "", int size = 15, int number = 1, string title = "")
		{
			StringBuilder stringBuilder = new StringBuilder();
			List<SqlParameter> list = new List<SqlParameter>();
			if (!title.IsNullOrEmpty())
			{
				stringBuilder.Append("AND CHARINDEX(@Name,Name)>0 ");
				list.Add(new SqlParameter("@Name", SqlDbType.NVarChar)
				{
					Value = title
				});
			}
			long count;
			string paerSql = dbHelper.GetPaerSql("AppLibraryButtons", "*", stringBuilder.ToString(), "Sort DESC", size, number, out count, list.ToArray());
			pager = Tools.GetPagerHtml(count, size, number, query);
			SqlDataReader dataReader = dbHelper.GetDataReader(paerSql, list.ToArray());
			List<RoadFlow.Data.Model.AppLibraryButtons> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public List<RoadFlow.Data.Model.AppLibraryButtons> GetPagerData(out long count, int size, int number, string title = "", string order = "")
		{
			StringBuilder stringBuilder = new StringBuilder();
			List<SqlParameter> list = new List<SqlParameter>();
			if (!title.IsNullOrEmpty())
			{
				stringBuilder.Append("AND CHARINDEX(@Name,Name)>0 ");
				list.Add(new SqlParameter("@Name", SqlDbType.NVarChar)
				{
					Value = title
				});
			}
			string paerSql = dbHelper.GetPaerSql("AppLibraryButtons", "*", stringBuilder.ToString(), order.IsNullOrEmpty() ? "Sort DESC" : order, size, number, out count, list.ToArray());
			SqlDataReader dataReader = dbHelper.GetDataReader(paerSql, list.ToArray());
			List<RoadFlow.Data.Model.AppLibraryButtons> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public int GetMaxSort()
		{
			string sql = "SELECT ISNULL(MAX(Sort),0)+5 FROM AppLibraryButtons";
			return dbHelper.GetFieldValue(sql).ToInt();
		}
	}
}
