using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RoadFlow.Data.MSSQL
{
	public class UserShortcut : IUserShortcut
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.UserShortcut model)
		{
			string sql = "INSERT INTO UserShortcut\r\n\t\t\t\t(ID,MenuID,UserID,Sort) \r\n\t\t\t\tVALUES(@ID,@MenuID,@UserID,@Sort)";
			SqlParameter[] parameter = new SqlParameter[4]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ID
				},
				new SqlParameter("@MenuID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.MenuID
				},
				new SqlParameter("@UserID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.UserID
				},
				new SqlParameter("@Sort", SqlDbType.Int, -1)
				{
					Value = model.Sort
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.UserShortcut model)
		{
			string sql = "UPDATE UserShortcut SET \r\n\t\t\t\tMenuID=@MenuID,UserID=@UserID,Sort=@Sort\r\n\t\t\t\tWHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[4]
			{
				new SqlParameter("@MenuID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.MenuID
				},
				new SqlParameter("@UserID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.UserID
				},
				new SqlParameter("@Sort", SqlDbType.Int, -1)
				{
					Value = model.Sort
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
			string sql = "DELETE FROM UserShortcut WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.UserShortcut> DataReaderToList(SqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.UserShortcut> list = new List<RoadFlow.Data.Model.UserShortcut>();
			RoadFlow.Data.Model.UserShortcut userShortcut = null;
			while (dataReader.Read())
			{
				userShortcut = new RoadFlow.Data.Model.UserShortcut();
				userShortcut.ID = dataReader.GetGuid(0);
				userShortcut.MenuID = dataReader.GetGuid(1);
				userShortcut.UserID = dataReader.GetGuid(2);
				userShortcut.Sort = dataReader.GetInt32(3);
				list.Add(userShortcut);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.UserShortcut> GetAll()
		{
			string sql = "SELECT * FROM UserShortcut";
			SqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.UserShortcut> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM UserShortcut";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.UserShortcut Get(Guid id)
		{
			string sql = "SELECT * FROM UserShortcut WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.UserShortcut> list = DataReaderToList(dataReader);
			dataReader.Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public int DeleteByUserID(Guid userID)
		{
			string sql = "DELETE FROM UserShortcut WHERE UserID=@UserID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@UserID", SqlDbType.UniqueIdentifier)
				{
					Value = userID
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public List<RoadFlow.Data.Model.UserShortcut> GetAllByUserID(Guid userID)
		{
			string sql = "SELECT * FROM UserShortcut WHERE UserID=@UserID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@UserID", SqlDbType.UniqueIdentifier)
				{
					Value = userID
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.UserShortcut> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public DataTable GetDataTableByUserID(Guid userID)
		{
			string sql = "SELECT * FROM UserShortcut WHERE UserID=@UserID ORDER BY Sort";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@UserID", SqlDbType.UniqueIdentifier)
				{
					Value = userID
				}
			};
			return dbHelper.GetDataTable(sql, parameter);
		}

		public int DeleteByMenuID(Guid menuID)
		{
			string sql = "DELETE FROM UserShortcut WHERE MenuID=@MenuID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@MenuID", SqlDbType.UniqueIdentifier)
				{
					Value = menuID
				}
			};
			return dbHelper.Execute(sql, parameter);
		}
	}
}
