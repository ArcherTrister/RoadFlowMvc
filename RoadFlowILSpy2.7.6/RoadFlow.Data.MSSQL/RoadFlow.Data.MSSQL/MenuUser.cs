using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RoadFlow.Data.MSSQL
{
	public class MenuUser : IMenuUser
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.MenuUser model)
		{
			string sql = "INSERT INTO MenuUser\r\n\t\t\t\t(ID,MenuID,SubPageID,Organizes,Users,Buttons,Params) \r\n\t\t\t\tVALUES(@ID,@MenuID,@SubPageID,@Organizes,@Users,@Buttons,@Params)";
			SqlParameter[] parameter = new SqlParameter[7]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ID
				},
				new SqlParameter("@MenuID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.MenuID
				},
				new SqlParameter("@SubPageID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.SubPageID
				},
				new SqlParameter("@Organizes", SqlDbType.VarChar, 100)
				{
					Value = model.Organizes
				},
				new SqlParameter("@Users", SqlDbType.VarChar, -1)
				{
					Value = model.Users
				},
				(model.Buttons == null) ? new SqlParameter("@Buttons", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Buttons", SqlDbType.VarChar, -1)
				{
					Value = model.Buttons
				},
				(model.Params == null) ? new SqlParameter("@Params", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Params", SqlDbType.VarChar, -1)
				{
					Value = model.Params
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.MenuUser model)
		{
			string sql = "UPDATE MenuUser SET \r\n\t\t\t\tMenuID=@MenuID,SubPageID=@SubPageID,Organizes=@Organizes,Users=@Users,Buttons=@Buttons,Params=@Params\r\n\t\t\t\tWHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[7]
			{
				new SqlParameter("@MenuID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.MenuID
				},
				new SqlParameter("@SubPageID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.SubPageID
				},
				new SqlParameter("@Organizes", SqlDbType.VarChar, 100)
				{
					Value = model.Organizes
				},
				new SqlParameter("@Users", SqlDbType.VarChar, -1)
				{
					Value = model.Users
				},
				(model.Buttons == null) ? new SqlParameter("@Buttons", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Buttons", SqlDbType.VarChar, -1)
				{
					Value = model.Buttons
				},
				(model.Params == null) ? new SqlParameter("@Params", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Params", SqlDbType.VarChar, -1)
				{
					Value = model.Params
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
			string sql = "DELETE FROM MenuUser WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.MenuUser> DataReaderToList(SqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.MenuUser> list = new List<RoadFlow.Data.Model.MenuUser>();
			RoadFlow.Data.Model.MenuUser menuUser = null;
			while (dataReader.Read())
			{
				menuUser = new RoadFlow.Data.Model.MenuUser();
				menuUser.ID = dataReader.GetGuid(0);
				menuUser.MenuID = dataReader.GetGuid(1);
				menuUser.SubPageID = dataReader.GetGuid(2);
				menuUser.Organizes = dataReader.GetString(3);
				menuUser.Users = dataReader.GetString(4);
				if (!dataReader.IsDBNull(5))
				{
					menuUser.Buttons = dataReader.GetString(5);
				}
				if (!dataReader.IsDBNull(6))
				{
					menuUser.Params = dataReader.GetString(6);
				}
				list.Add(menuUser);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.MenuUser> GetAll()
		{
			string sql = "SELECT * FROM MenuUser";
			SqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.MenuUser> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM MenuUser";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.MenuUser Get(Guid id)
		{
			string sql = "SELECT * FROM MenuUser WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.MenuUser> list = DataReaderToList(dataReader);
			dataReader.Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public int DeleteByOrganizes(string organizes)
		{
			string sql = "DELETE FROM MenuUser WHERE Organizes=@Organizes";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@Organizes", SqlDbType.VarChar)
				{
					Value = organizes
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public int DeleteByMenuID(Guid menuID)
		{
			string sql = "DELETE FROM MenuUser WHERE MenuID=@MenuID";
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
