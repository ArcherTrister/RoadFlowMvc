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
	public class WorkFlow : IWorkFlow
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.WorkFlow model)
		{
			string sql = "INSERT INTO WorkFlow\r\n\t\t\t\t(ID,Name,Type,Manager,InstanceManager,CreateDate,CreateUserID,DesignJSON,InstallDate,InstallUserID,RunJSON,Status) \r\n\t\t\t\tVALUES(@ID,@Name,@Type,@Manager,@InstanceManager,@CreateDate,@CreateUserID,@DesignJSON,@InstallDate,@InstallUserID,@RunJSON,@Status)";
			SqlParameter[] parameter = new SqlParameter[12]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ID
				},
				new SqlParameter("@Name", SqlDbType.NVarChar, 1000)
				{
					Value = model.Name
				},
				new SqlParameter("@Type", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.Type
				},
				new SqlParameter("@Manager", SqlDbType.VarChar, 5000)
				{
					Value = model.Manager
				},
				new SqlParameter("@InstanceManager", SqlDbType.VarChar, 5000)
				{
					Value = model.InstanceManager
				},
				new SqlParameter("@CreateDate", SqlDbType.DateTime, 8)
				{
					Value = model.CreateDate
				},
				new SqlParameter("@CreateUserID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.CreateUserID
				},
				(model.DesignJSON == null) ? new SqlParameter("@DesignJSON", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@DesignJSON", SqlDbType.VarChar, -1)
				{
					Value = model.DesignJSON
				},
				(!model.InstallDate.HasValue) ? new SqlParameter("@InstallDate", SqlDbType.DateTime, 8)
				{
					Value = DBNull.Value
				} : new SqlParameter("@InstallDate", SqlDbType.DateTime, 8)
				{
					Value = model.InstallDate
				},
				(!model.InstallUserID.HasValue) ? new SqlParameter("@InstallUserID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@InstallUserID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.InstallUserID
				},
				(model.RunJSON == null) ? new SqlParameter("@RunJSON", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@RunJSON", SqlDbType.VarChar, -1)
				{
					Value = model.RunJSON
				},
				new SqlParameter("@Status", SqlDbType.Int, -1)
				{
					Value = model.Status
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.WorkFlow model)
		{
			string sql = "UPDATE WorkFlow SET \r\n\t\t\t\tName=@Name,Type=@Type,Manager=@Manager,InstanceManager=@InstanceManager,CreateDate=@CreateDate,CreateUserID=@CreateUserID,DesignJSON=@DesignJSON,InstallDate=@InstallDate,InstallUserID=@InstallUserID,RunJSON=@RunJSON,Status=@Status\r\n\t\t\t\tWHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[12]
			{
				new SqlParameter("@Name", SqlDbType.NVarChar, 1000)
				{
					Value = model.Name
				},
				new SqlParameter("@Type", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.Type
				},
				new SqlParameter("@Manager", SqlDbType.VarChar, 5000)
				{
					Value = model.Manager
				},
				new SqlParameter("@InstanceManager", SqlDbType.VarChar, 5000)
				{
					Value = model.InstanceManager
				},
				new SqlParameter("@CreateDate", SqlDbType.DateTime, 8)
				{
					Value = model.CreateDate
				},
				new SqlParameter("@CreateUserID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.CreateUserID
				},
				(model.DesignJSON == null) ? new SqlParameter("@DesignJSON", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@DesignJSON", SqlDbType.VarChar, -1)
				{
					Value = model.DesignJSON
				},
				(!model.InstallDate.HasValue) ? new SqlParameter("@InstallDate", SqlDbType.DateTime, 8)
				{
					Value = DBNull.Value
				} : new SqlParameter("@InstallDate", SqlDbType.DateTime, 8)
				{
					Value = model.InstallDate
				},
				(!model.InstallUserID.HasValue) ? new SqlParameter("@InstallUserID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@InstallUserID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.InstallUserID
				},
				(model.RunJSON == null) ? new SqlParameter("@RunJSON", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@RunJSON", SqlDbType.VarChar, -1)
				{
					Value = model.RunJSON
				},
				new SqlParameter("@Status", SqlDbType.Int, -1)
				{
					Value = model.Status
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
			string sql = "DELETE FROM WorkFlow WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.WorkFlow> DataReaderToList(SqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.WorkFlow> list = new List<RoadFlow.Data.Model.WorkFlow>();
			RoadFlow.Data.Model.WorkFlow workFlow = null;
			while (dataReader.Read())
			{
				workFlow = new RoadFlow.Data.Model.WorkFlow();
				workFlow.ID = dataReader.GetGuid(0);
				workFlow.Name = dataReader.GetString(1);
				workFlow.Type = dataReader.GetGuid(2);
				workFlow.Manager = dataReader.GetString(3);
				workFlow.InstanceManager = dataReader.GetString(4);
				workFlow.CreateDate = dataReader.GetDateTime(5);
				workFlow.CreateUserID = dataReader.GetGuid(6);
				if (!dataReader.IsDBNull(7))
				{
					workFlow.DesignJSON = dataReader.GetString(7);
				}
				if (!dataReader.IsDBNull(8))
				{
					workFlow.InstallDate = dataReader.GetDateTime(8);
				}
				if (!dataReader.IsDBNull(9))
				{
					workFlow.InstallUserID = dataReader.GetGuid(9);
				}
				if (!dataReader.IsDBNull(10))
				{
					workFlow.RunJSON = dataReader.GetString(10);
				}
				workFlow.Status = dataReader.GetInt32(11);
				list.Add(workFlow);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.WorkFlow> GetAll()
		{
			string sql = "SELECT * FROM WorkFlow";
			SqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.WorkFlow> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM WorkFlow";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.WorkFlow Get(Guid id)
		{
			string sql = "SELECT * FROM WorkFlow WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.WorkFlow> list = DataReaderToList(dataReader);
			dataReader.Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public List<string> GetAllTypes()
		{
			string sql = "SELECT Type FROM WorkFlow GROUP BY Type";
			List<string> list = new List<string>();
			SqlDataReader dataReader = dbHelper.GetDataReader(sql);
			while (dataReader.Read())
			{
				list.Add(dataReader.GetString(0));
			}
			dataReader.Close();
			return list;
		}

		public Dictionary<Guid, string> GetAllIDAndName()
		{
			string sql = "SELECT ID,Name FROM WorkFlow WHERE Status<4 ORDER BY Name";
			Dictionary<Guid, string> dictionary = new Dictionary<Guid, string>();
			SqlDataReader dataReader = dbHelper.GetDataReader(sql);
			while (dataReader.Read())
			{
				dictionary.Add(dataReader.GetGuid(0), dataReader.GetString(1));
			}
			dataReader.Close();
			return dictionary;
		}

		public List<RoadFlow.Data.Model.WorkFlow> GetByTypes(string typeString)
		{
			string sql = "SELECT * FROM WorkFlow where Type IN(" + Tools.GetSqlInString(typeString) + ")";
			SqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.WorkFlow> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public List<RoadFlow.Data.Model.WorkFlow> GetPagerData(out string pager, string query = "", string userid = "", string typeid = "", string name = "", int pagesize = 15)
		{
			StringBuilder stringBuilder = new StringBuilder("AND Status<>4 ");
			List<SqlParameter> list = new List<SqlParameter>();
			if (!userid.IsNullOrEmpty())
			{
				stringBuilder.Append("AND CHARINDEX(@Manager,Manager)>0 ");
				list.Add(new SqlParameter("@Manager", SqlDbType.VarChar)
				{
					Value = userid
				});
			}
			if (!name.IsNullOrEmpty())
			{
				stringBuilder.Append("AND CHARINDEX(@Name,Name)>0 ");
				list.Add(new SqlParameter("@Name", SqlDbType.VarChar)
				{
					Value = name
				});
			}
			if (!typeid.IsNullOrEmpty())
			{
				stringBuilder.Append("AND Type IN (" + Tools.GetSqlInString(typeid) + ")");
			}
			int pageNumber = Tools.GetPageNumber();
			long count;
			string paerSql = dbHelper.GetPaerSql("WorkFlow", "ID,Name,Type,Manager,InstanceManager,CreateDate,CreateUserID,'' DesignJSON,InstallDate,InstallUserID,'' RunJSON,Status", stringBuilder.ToString(), "CreateDate DESC", pagesize, pageNumber, out count, list.ToArray());
			pager = Tools.GetPagerHtml(count, pagesize, pageNumber, query);
			SqlDataReader dataReader = dbHelper.GetDataReader(paerSql, list.ToArray());
			List<RoadFlow.Data.Model.WorkFlow> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public List<RoadFlow.Data.Model.WorkFlow> GetPagerData(out long count, int pageSize, int pageNumber, string userid = "", string typeid = "", string name = "", string order = "")
		{
			StringBuilder stringBuilder = new StringBuilder("AND Status<>4 ");
			List<SqlParameter> list = new List<SqlParameter>();
			if (!userid.IsNullOrEmpty())
			{
				stringBuilder.Append("AND CHARINDEX(@Manager,Manager)>0 ");
				list.Add(new SqlParameter("@Manager", SqlDbType.VarChar)
				{
					Value = userid
				});
			}
			if (!name.IsNullOrEmpty())
			{
				stringBuilder.Append("AND CHARINDEX(@Name,Name)>0 ");
				list.Add(new SqlParameter("@Name", SqlDbType.VarChar)
				{
					Value = name
				});
			}
			if (!typeid.IsNullOrEmpty())
			{
				stringBuilder.Append("AND Type IN (" + Tools.GetSqlInString(typeid) + ")");
			}
			string paerSql = dbHelper.GetPaerSql("WorkFlow", "ID,Name,Type,Manager,InstanceManager,CreateDate,CreateUserID,'' DesignJSON,InstallDate,InstallUserID,'' RunJSON,Status", stringBuilder.ToString(), order.IsNullOrEmpty() ? "CreateDate DESC" : order, pageSize, pageNumber, out count, list.ToArray());
			SqlDataReader dataReader = dbHelper.GetDataReader(paerSql, list.ToArray());
			List<RoadFlow.Data.Model.WorkFlow> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}
	}
}
