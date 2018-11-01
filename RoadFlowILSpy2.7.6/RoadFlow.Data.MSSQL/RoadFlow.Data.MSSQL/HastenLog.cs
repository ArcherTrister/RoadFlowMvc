using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RoadFlow.Data.MSSQL
{
	public class HastenLog : IHastenLog
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.HastenLog model)
		{
			string sql = "INSERT INTO HastenLog\r\n\t\t\t\t(ID,OthersParams,Users,Types,Contents,SendUser,SendUserName,SendTime) \r\n\t\t\t\tVALUES(@ID,@OthersParams,@Users,@Types,@Contents,@SendUser,@SendUserName,@SendTime)";
			SqlParameter[] parameter = new SqlParameter[8]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ID
				},
				new SqlParameter("@OthersParams", SqlDbType.VarChar, 5000)
				{
					Value = model.OthersParams
				},
				new SqlParameter("@Users", SqlDbType.VarChar, 5000)
				{
					Value = model.Users
				},
				new SqlParameter("@Types", SqlDbType.VarChar, 500)
				{
					Value = model.Types
				},
				new SqlParameter("@Contents", SqlDbType.NVarChar, 1000)
				{
					Value = model.Contents
				},
				new SqlParameter("@SendUser", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.SendUser
				},
				new SqlParameter("@SendUserName", SqlDbType.NVarChar, 100)
				{
					Value = model.SendUserName
				},
				new SqlParameter("@SendTime", SqlDbType.DateTime, 8)
				{
					Value = model.SendTime
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.HastenLog model)
		{
			string sql = "UPDATE HastenLog SET \r\n\t\t\t\tOthersParams=@OthersParams,Users=@Users,Types=@Types,Contents=@Contents,SendUser=@SendUser,SendUserName=@SendUserName,SendTime=@SendTime\r\n\t\t\t\tWHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[8]
			{
				new SqlParameter("@OthersParams", SqlDbType.VarChar, 5000)
				{
					Value = model.OthersParams
				},
				new SqlParameter("@Users", SqlDbType.VarChar, 5000)
				{
					Value = model.Users
				},
				new SqlParameter("@Types", SqlDbType.VarChar, 500)
				{
					Value = model.Types
				},
				new SqlParameter("@Contents", SqlDbType.NVarChar, 1000)
				{
					Value = model.Contents
				},
				new SqlParameter("@SendUser", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.SendUser
				},
				new SqlParameter("@SendUserName", SqlDbType.NVarChar, 100)
				{
					Value = model.SendUserName
				},
				new SqlParameter("@SendTime", SqlDbType.DateTime, 8)
				{
					Value = model.SendTime
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
			string sql = "DELETE FROM HastenLog WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.HastenLog> DataReaderToList(SqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.HastenLog> list = new List<RoadFlow.Data.Model.HastenLog>();
			RoadFlow.Data.Model.HastenLog hastenLog = null;
			while (dataReader.Read())
			{
				hastenLog = new RoadFlow.Data.Model.HastenLog();
				hastenLog.ID = dataReader.GetGuid(0);
				hastenLog.OthersParams = dataReader.GetString(1);
				hastenLog.Users = dataReader.GetString(2);
				hastenLog.Types = dataReader.GetString(3);
				hastenLog.Contents = dataReader.GetString(4);
				hastenLog.SendUser = dataReader.GetGuid(5);
				hastenLog.SendUserName = dataReader.GetString(6);
				hastenLog.SendTime = dataReader.GetDateTime(7);
				list.Add(hastenLog);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.HastenLog> GetAll()
		{
			string sql = "SELECT * FROM HastenLog";
			SqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.HastenLog> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM HastenLog";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.HastenLog Get(Guid id)
		{
			string sql = "SELECT * FROM HastenLog WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.HastenLog> list = DataReaderToList(dataReader);
			dataReader.Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}
	}
}
