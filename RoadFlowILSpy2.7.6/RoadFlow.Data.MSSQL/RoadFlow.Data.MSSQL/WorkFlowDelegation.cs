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
	public class WorkFlowDelegation : IWorkFlowDelegation
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.WorkFlowDelegation model)
		{
			string sql = "INSERT INTO WorkFlowDelegation\r\n\t\t\t\t(ID,UserID,StartTime,EndTime,FlowID,ToUserID,WriteTime,Note) \r\n\t\t\t\tVALUES(@ID,@UserID,@StartTime,@EndTime,@FlowID,@ToUserID,@WriteTime,@Note)";
			SqlParameter[] parameter = new SqlParameter[8]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ID
				},
				new SqlParameter("@UserID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.UserID
				},
				new SqlParameter("@StartTime", SqlDbType.DateTime, 8)
				{
					Value = model.StartTime
				},
				new SqlParameter("@EndTime", SqlDbType.DateTime, 8)
				{
					Value = model.EndTime
				},
				(!model.FlowID.HasValue) ? new SqlParameter("@FlowID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@FlowID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.FlowID
				},
				new SqlParameter("@ToUserID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ToUserID
				},
				new SqlParameter("@WriteTime", SqlDbType.DateTime, 8)
				{
					Value = model.WriteTime
				},
				(model.Note == null) ? new SqlParameter("@Note", SqlDbType.NVarChar, 8000)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Note", SqlDbType.NVarChar, 8000)
				{
					Value = model.Note
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.WorkFlowDelegation model)
		{
			string sql = "UPDATE WorkFlowDelegation SET \r\n\t\t\t\tUserID=@UserID,StartTime=@StartTime,EndTime=@EndTime,FlowID=@FlowID,ToUserID=@ToUserID,WriteTime=@WriteTime,Note=@Note\r\n\t\t\t\tWHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[8]
			{
				new SqlParameter("@UserID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.UserID
				},
				new SqlParameter("@StartTime", SqlDbType.DateTime, 8)
				{
					Value = model.StartTime
				},
				new SqlParameter("@EndTime", SqlDbType.DateTime, 8)
				{
					Value = model.EndTime
				},
				(!model.FlowID.HasValue) ? new SqlParameter("@FlowID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@FlowID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.FlowID
				},
				new SqlParameter("@ToUserID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ToUserID
				},
				new SqlParameter("@WriteTime", SqlDbType.DateTime, 8)
				{
					Value = model.WriteTime
				},
				(model.Note == null) ? new SqlParameter("@Note", SqlDbType.NVarChar, 8000)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Note", SqlDbType.NVarChar, 8000)
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
			string sql = "DELETE FROM WorkFlowDelegation WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.WorkFlowDelegation> DataReaderToList(SqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.WorkFlowDelegation> list = new List<RoadFlow.Data.Model.WorkFlowDelegation>();
			RoadFlow.Data.Model.WorkFlowDelegation workFlowDelegation = null;
			while (dataReader.Read())
			{
				workFlowDelegation = new RoadFlow.Data.Model.WorkFlowDelegation();
				workFlowDelegation.ID = dataReader.GetGuid(0);
				workFlowDelegation.UserID = dataReader.GetGuid(1);
				workFlowDelegation.StartTime = dataReader.GetDateTime(2);
				workFlowDelegation.EndTime = dataReader.GetDateTime(3);
				if (!dataReader.IsDBNull(4))
				{
					workFlowDelegation.FlowID = dataReader.GetGuid(4);
				}
				workFlowDelegation.ToUserID = dataReader.GetGuid(5);
				workFlowDelegation.WriteTime = dataReader.GetDateTime(6);
				if (!dataReader.IsDBNull(7))
				{
					workFlowDelegation.Note = dataReader.GetString(7);
				}
				list.Add(workFlowDelegation);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.WorkFlowDelegation> GetAll()
		{
			string sql = "SELECT * FROM WorkFlowDelegation";
			SqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.WorkFlowDelegation> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM WorkFlowDelegation";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.WorkFlowDelegation Get(Guid id)
		{
			string sql = "SELECT * FROM WorkFlowDelegation WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.WorkFlowDelegation> list = DataReaderToList(dataReader);
			dataReader.Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public List<RoadFlow.Data.Model.WorkFlowDelegation> GetByUserID(Guid userID)
		{
			string sql = "SELECT * FROM WorkFlowDelegation WHERE UserID=@UserID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@UserID", SqlDbType.UniqueIdentifier)
				{
					Value = userID
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.WorkFlowDelegation> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public List<RoadFlow.Data.Model.WorkFlowDelegation> GetPagerData(out string pager, string query = "", string userID = "", string startTime = "", string endTime = "")
		{
			StringBuilder stringBuilder = new StringBuilder();
			List<SqlParameter> list = new List<SqlParameter>();
			if (userID.IsGuid())
			{
				stringBuilder.Append("AND UserID=@UserID ");
				list.Add(new SqlParameter("@UserID", SqlDbType.UniqueIdentifier)
				{
					Value = userID.ToGuid()
				});
			}
			if (startTime.IsDateTime())
			{
				stringBuilder.Append("AND StartTime>=@StartTime ");
				list.Add(new SqlParameter("@StartTime", SqlDbType.DateTime)
				{
					Value = startTime.ToDateTime().ToString("yyyy-MM-dd").ToDateTime()
				});
			}
			if (endTime.IsDateTime())
			{
				stringBuilder.Append("AND EndTime<=@EndTime ");
				list.Add(new SqlParameter("@EndTime", SqlDbType.DateTime)
				{
					Value = endTime.ToDateTime().AddDays(1.0).ToString("yyyy-MM-dd")
						.ToDateTime()
				});
			}
			int pageSize = Tools.GetPageSize();
			int pageNumber = Tools.GetPageNumber();
			long count;
			string paerSql = dbHelper.GetPaerSql("WorkFlowDelegation", "*", stringBuilder.ToString(), "WriteTime Desc", pageSize, pageNumber, out count, list.ToArray());
			pager = Tools.GetPagerHtml(count, pageSize, pageNumber, query);
			SqlDataReader dataReader = dbHelper.GetDataReader(paerSql, list.ToArray());
			List<RoadFlow.Data.Model.WorkFlowDelegation> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public List<RoadFlow.Data.Model.WorkFlowDelegation> GetPagerData(out long count, int pageSize, int pageNumber, string userID = "", string startTime = "", string endTime = "", string order = "")
		{
			StringBuilder stringBuilder = new StringBuilder();
			List<SqlParameter> list = new List<SqlParameter>();
			if (userID.IsGuid())
			{
				stringBuilder.Append("AND UserID=@UserID ");
				list.Add(new SqlParameter("@UserID", SqlDbType.UniqueIdentifier)
				{
					Value = userID.ToGuid()
				});
			}
			if (startTime.IsDateTime())
			{
				stringBuilder.Append("AND StartTime>=@StartTime ");
				list.Add(new SqlParameter("@StartTime", SqlDbType.DateTime)
				{
					Value = startTime.ToDateTime().ToString("yyyy-MM-dd").ToDateTime()
				});
			}
			if (endTime.IsDateTime())
			{
				stringBuilder.Append("AND EndTime<=@EndTime ");
				list.Add(new SqlParameter("@EndTime", SqlDbType.DateTime)
				{
					Value = endTime.ToDateTime().AddDays(1.0).ToString("yyyy-MM-dd")
						.ToDateTime()
				});
			}
			string paerSql = dbHelper.GetPaerSql("WorkFlowDelegation", "*", stringBuilder.ToString(), order.IsNullOrEmpty() ? "WriteTime Desc" : order, pageSize, pageNumber, out count, list.ToArray());
			SqlDataReader dataReader = dbHelper.GetDataReader(paerSql, list.ToArray());
			List<RoadFlow.Data.Model.WorkFlowDelegation> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public List<RoadFlow.Data.Model.WorkFlowDelegation> GetNoExpiredList()
		{
			string sql = "SELECT * FROM WorkFlowDelegation WHERE EndTime>=@EndTime";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@EndTime", SqlDbType.DateTime)
				{
					Value = DateTimeNew.Now
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.WorkFlowDelegation> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}
	}
}
