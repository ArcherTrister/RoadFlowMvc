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
	public class WorkFlowForm : IWorkFlowForm
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.WorkFlowForm model)
		{
			string sql = "INSERT INTO WorkFlowForm\r\n\t\t\t\t(ID,Name,Type,CreateUserID,CreateUserName,CreateTime,LastModifyTime,Html,SubTableJson,EventsJson,Attribute,Status) \r\n\t\t\t\tVALUES(@ID,@Name,@Type,@CreateUserID,@CreateUserName,@CreateTime,@LastModifyTime,@Html,@SubTableJson,@EventsJson,@Attribute,@Status)";
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
				new SqlParameter("@CreateUserID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.CreateUserID
				},
				new SqlParameter("@CreateUserName", SqlDbType.NVarChar, 100)
				{
					Value = model.CreateUserName
				},
				new SqlParameter("@CreateTime", SqlDbType.DateTime, 8)
				{
					Value = model.CreateTime
				},
				new SqlParameter("@LastModifyTime", SqlDbType.DateTime, 8)
				{
					Value = model.LastModifyTime
				},
				(model.Html == null) ? new SqlParameter("@Html", SqlDbType.Text, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Html", SqlDbType.Text, -1)
				{
					Value = model.Html
				},
				(model.SubTableJson == null) ? new SqlParameter("@SubTableJson", SqlDbType.Text, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@SubTableJson", SqlDbType.Text, -1)
				{
					Value = model.SubTableJson
				},
				(model.EventsJson == null) ? new SqlParameter("@EventsJson", SqlDbType.Text, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@EventsJson", SqlDbType.Text, -1)
				{
					Value = model.EventsJson
				},
				(model.Attribute == null) ? new SqlParameter("@Attribute", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Attribute", SqlDbType.VarChar, -1)
				{
					Value = model.Attribute
				},
				new SqlParameter("@Status", SqlDbType.Int, -1)
				{
					Value = model.Status
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.WorkFlowForm model)
		{
			string sql = "UPDATE WorkFlowForm SET \r\n\t\t\t\tName=@Name,Type=@Type,CreateUserID=@CreateUserID,CreateUserName=@CreateUserName,CreateTime=@CreateTime,LastModifyTime=@LastModifyTime,Html=@Html,SubTableJson=@SubTableJson,EventsJson=@EventsJson,Attribute=@Attribute,Status=@Status\r\n\t\t\t\tWHERE ID=@ID";
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
				new SqlParameter("@CreateUserID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.CreateUserID
				},
				new SqlParameter("@CreateUserName", SqlDbType.NVarChar, 100)
				{
					Value = model.CreateUserName
				},
				new SqlParameter("@CreateTime", SqlDbType.DateTime, 8)
				{
					Value = model.CreateTime
				},
				new SqlParameter("@LastModifyTime", SqlDbType.DateTime, 8)
				{
					Value = model.LastModifyTime
				},
				(model.Html == null) ? new SqlParameter("@Html", SqlDbType.Text, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Html", SqlDbType.Text, -1)
				{
					Value = model.Html
				},
				(model.SubTableJson == null) ? new SqlParameter("@SubTableJson", SqlDbType.Text, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@SubTableJson", SqlDbType.Text, -1)
				{
					Value = model.SubTableJson
				},
				(model.EventsJson == null) ? new SqlParameter("@EventsJson", SqlDbType.Text, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@EventsJson", SqlDbType.Text, -1)
				{
					Value = model.EventsJson
				},
				(model.Attribute == null) ? new SqlParameter("@Attribute", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Attribute", SqlDbType.VarChar, -1)
				{
					Value = model.Attribute
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
			string sql = "DELETE FROM WorkFlowForm WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.WorkFlowForm> DataReaderToList(SqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.WorkFlowForm> list = new List<RoadFlow.Data.Model.WorkFlowForm>();
			RoadFlow.Data.Model.WorkFlowForm workFlowForm = null;
			while (dataReader.Read())
			{
				workFlowForm = new RoadFlow.Data.Model.WorkFlowForm();
				workFlowForm.ID = dataReader.GetGuid(0);
				workFlowForm.Name = dataReader.GetString(1);
				workFlowForm.Type = dataReader.GetGuid(2);
				workFlowForm.CreateUserID = dataReader.GetGuid(3);
				workFlowForm.CreateUserName = dataReader.GetString(4);
				workFlowForm.CreateTime = dataReader.GetDateTime(5);
				workFlowForm.LastModifyTime = dataReader.GetDateTime(6);
				if (!dataReader.IsDBNull(7))
				{
					workFlowForm.Html = dataReader.GetString(7);
				}
				if (!dataReader.IsDBNull(8))
				{
					workFlowForm.SubTableJson = dataReader.GetString(8);
				}
				if (!dataReader.IsDBNull(9))
				{
					workFlowForm.EventsJson = dataReader.GetString(9);
				}
				if (!dataReader.IsDBNull(10))
				{
					workFlowForm.Attribute = dataReader.GetString(10);
				}
				workFlowForm.Status = dataReader.GetInt32(11);
				list.Add(workFlowForm);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.WorkFlowForm> GetAll()
		{
			string sql = "SELECT * FROM WorkFlowForm";
			SqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.WorkFlowForm> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM WorkFlowForm";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.WorkFlowForm Get(Guid id)
		{
			string sql = "SELECT * FROM WorkFlowForm WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.WorkFlowForm> list = DataReaderToList(dataReader);
			dataReader.Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public List<RoadFlow.Data.Model.WorkFlowForm> GetAllByType(string types)
		{
			string sql = "SELECT ID, Name, Type, CreateUserID, CreateUserName, CreateTime, LastModifyTime, '' as Html, '' as SubTableJson, '' as EventsJson, '' as Attribute, Status FROM WorkFlowForm where Type IN(" + Tools.GetSqlInString(types) + ")";
			SqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.WorkFlowForm> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public List<RoadFlow.Data.Model.WorkFlowForm> GetPagerData(out string pager, string query = "", string userid = "", string typeid = "", string name = "", int pagesize = 15)
		{
			StringBuilder stringBuilder = new StringBuilder("AND Status IN(0,1) ");
			List<SqlParameter> list = new List<SqlParameter>();
			if (!userid.IsNullOrEmpty())
			{
				stringBuilder.Append("AND CreateUserID=@CreateUserID ");
				list.Add(new SqlParameter("@CreateUserID", SqlDbType.UniqueIdentifier)
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
			string paerSql = dbHelper.GetPaerSql("WorkFlowForm", "ID,Name,Type,CreateUserID,CreateUserName,CreateTime,LastModifyTime,'' Html,'' SubTableJson,'' EventsJson,'' Attribute,Status", stringBuilder.ToString(), "CreateTime DESC", pagesize, pageNumber, out count, list.ToArray());
			pager = Tools.GetPagerHtml(count, pagesize, pageNumber, query);
			SqlDataReader dataReader = dbHelper.GetDataReader(paerSql, list.ToArray());
			List<RoadFlow.Data.Model.WorkFlowForm> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public List<RoadFlow.Data.Model.WorkFlowForm> GetPagerData(out long count, int pageSize, int pageNumber, string userid = "", string typeid = "", string name = "", string order = "")
		{
			StringBuilder stringBuilder = new StringBuilder("AND Status IN(0,1) ");
			List<SqlParameter> list = new List<SqlParameter>();
			if (!userid.IsNullOrEmpty())
			{
				stringBuilder.Append("AND CreateUserID=@CreateUserID ");
				list.Add(new SqlParameter("@CreateUserID", SqlDbType.UniqueIdentifier)
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
			string paerSql = dbHelper.GetPaerSql("WorkFlowForm", "ID,Name,Type,CreateUserID,CreateUserName,CreateTime,LastModifyTime,'' Html,'' SubTableJson,'' EventsJson,'' Attribute,Status", stringBuilder.ToString(), order.IsNullOrEmpty() ? "CreateTime DESC" : order, pageSize, pageNumber, out count, list.ToArray());
			SqlDataReader dataReader = dbHelper.GetDataReader(paerSql, list.ToArray());
			List<RoadFlow.Data.Model.WorkFlowForm> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}
	}
}
