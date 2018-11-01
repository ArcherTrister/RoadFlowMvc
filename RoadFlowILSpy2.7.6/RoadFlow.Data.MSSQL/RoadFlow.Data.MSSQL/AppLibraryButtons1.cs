using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RoadFlow.Data.MSSQL
{
	public class AppLibraryButtons1 : IAppLibraryButtons1
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.AppLibraryButtons1 model)
		{
			string sql = "INSERT INTO AppLibraryButtons1\r\n\t\t\t\t(ID,AppLibraryID,ButtonID,Name,Events,Ico,Sort,Type,ShowType,IsValidateShow) \r\n\t\t\t\tVALUES(@ID,@AppLibraryID,@ButtonID,@Name,@Events,@Ico,@Sort,@Type,@ShowType,@IsValidateShow)";
			SqlParameter[] parameter = new SqlParameter[10]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ID
				},
				new SqlParameter("@AppLibraryID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.AppLibraryID
				},
				(!model.ButtonID.HasValue) ? new SqlParameter("@ButtonID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@ButtonID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ButtonID
				},
				new SqlParameter("@Name", SqlDbType.NVarChar, 1000)
				{
					Value = model.Name
				},
				new SqlParameter("@Events", SqlDbType.VarChar, 5000)
				{
					Value = model.Events
				},
				new SqlParameter("@Ico", SqlDbType.VarChar, 2000)
				{
					Value = model.Ico
				},
				new SqlParameter("@Sort", SqlDbType.Int, -1)
				{
					Value = model.Sort
				},
				new SqlParameter("@Type", SqlDbType.Int, -1)
				{
					Value = model.Type
				},
				new SqlParameter("@ShowType", SqlDbType.Int, -1)
				{
					Value = model.ShowType
				},
				new SqlParameter("@IsValidateShow", SqlDbType.Int, -1)
				{
					Value = model.IsValidateShow
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.AppLibraryButtons1 model)
		{
			string sql = "UPDATE AppLibraryButtons1 SET \r\n\t\t\t\tAppLibraryID=@AppLibraryID,ButtonID=@ButtonID,Name=@Name,Events=@Events,Ico=@Ico,Sort=@Sort,Type=@Type,ShowType=@ShowType,IsValidateShow=@IsValidateShow\r\n\t\t\t\tWHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[10]
			{
				new SqlParameter("@AppLibraryID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.AppLibraryID
				},
				(!model.ButtonID.HasValue) ? new SqlParameter("@ButtonID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@ButtonID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ButtonID
				},
				new SqlParameter("@Name", SqlDbType.NVarChar, 1000)
				{
					Value = model.Name
				},
				new SqlParameter("@Events", SqlDbType.VarChar, 5000)
				{
					Value = model.Events
				},
				new SqlParameter("@Ico", SqlDbType.VarChar, 2000)
				{
					Value = model.Ico
				},
				new SqlParameter("@Sort", SqlDbType.Int, -1)
				{
					Value = model.Sort
				},
				new SqlParameter("@Type", SqlDbType.Int, -1)
				{
					Value = model.Type
				},
				new SqlParameter("@ShowType", SqlDbType.Int, -1)
				{
					Value = model.ShowType
				},
				new SqlParameter("@IsValidateShow", SqlDbType.Int, -1)
				{
					Value = model.IsValidateShow
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
			string sql = "DELETE FROM AppLibraryButtons1 WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.AppLibraryButtons1> DataReaderToList(SqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.AppLibraryButtons1> list = new List<RoadFlow.Data.Model.AppLibraryButtons1>();
			RoadFlow.Data.Model.AppLibraryButtons1 appLibraryButtons = null;
			while (dataReader.Read())
			{
				appLibraryButtons = new RoadFlow.Data.Model.AppLibraryButtons1();
				appLibraryButtons.ID = dataReader.GetGuid(0);
				appLibraryButtons.AppLibraryID = dataReader.GetGuid(1);
				if (!dataReader.IsDBNull(2))
				{
					appLibraryButtons.ButtonID = dataReader.GetGuid(2);
				}
				appLibraryButtons.Name = dataReader.GetString(3);
				appLibraryButtons.Events = dataReader.GetString(4);
				if (!dataReader.IsDBNull(5))
				{
					appLibraryButtons.Ico = dataReader.GetString(5);
				}
				appLibraryButtons.Sort = dataReader.GetInt32(6);
				appLibraryButtons.Type = dataReader.GetInt32(7);
				appLibraryButtons.ShowType = dataReader.GetInt32(8);
				appLibraryButtons.IsValidateShow = dataReader.GetInt32(9);
				list.Add(appLibraryButtons);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.AppLibraryButtons1> GetAll()
		{
			string sql = "SELECT * FROM AppLibraryButtons1";
			SqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.AppLibraryButtons1> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM AppLibraryButtons1";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.AppLibraryButtons1 Get(Guid id)
		{
			string sql = "SELECT * FROM AppLibraryButtons1 WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.AppLibraryButtons1> list = DataReaderToList(dataReader);
			dataReader.Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public int DeleteByAppID(Guid id)
		{
			string sql = "DELETE FROM AppLibraryButtons1 WHERE AppLibraryID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public List<RoadFlow.Data.Model.AppLibraryButtons1> GetAllByAppID(Guid id)
		{
			string sql = "SELECT * FROM AppLibraryButtons1 WHERE AppLibraryID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.AppLibraryButtons1> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}
	}
}
