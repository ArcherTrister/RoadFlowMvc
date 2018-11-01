using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RoadFlow.Data.MSSQL
{
	public class SMSLog : ISMSLog
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.SMSLog model)
		{
			string sql = "INSERT INTO SMSLog\r\n\t\t\t\t(ID,MobileNumber,Contents,SendUserID,SendUserName,SendTime,Status,Note) \r\n\t\t\t\tVALUES(@ID,@MobileNumber,@Contents,@SendUserID,@SendUserName,@SendTime,@Status,@Note)";
			SqlParameter[] parameter = new SqlParameter[8]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ID
				},
				new SqlParameter("@MobileNumber", SqlDbType.VarChar, -1)
				{
					Value = model.MobileNumber
				},
				new SqlParameter("@Contents", SqlDbType.NVarChar, 400)
				{
					Value = model.Contents
				},
				(!model.SendUserID.HasValue) ? new SqlParameter("@SendUserID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@SendUserID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.SendUserID
				},
				(model.SendUserName == null) ? new SqlParameter("@SendUserName", SqlDbType.NVarChar, 1000)
				{
					Value = DBNull.Value
				} : new SqlParameter("@SendUserName", SqlDbType.NVarChar, 1000)
				{
					Value = model.SendUserName
				},
				new SqlParameter("@SendTime", SqlDbType.DateTime, 8)
				{
					Value = model.SendTime
				},
				new SqlParameter("@Status", SqlDbType.Int, -1)
				{
					Value = model.Status
				},
				(model.Note == null) ? new SqlParameter("@Note", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Note", SqlDbType.VarChar, -1)
				{
					Value = model.Note
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.SMSLog model)
		{
			string sql = "UPDATE SMSLog SET \r\n\t\t\t\tMobileNumber=@MobileNumber,Contents=@Contents,SendUserID=@SendUserID,SendUserName=@SendUserName,SendTime=@SendTime,Status=@Status,Note=@Note\r\n\t\t\t\tWHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[8]
			{
				new SqlParameter("@MobileNumber", SqlDbType.VarChar, -1)
				{
					Value = model.MobileNumber
				},
				new SqlParameter("@Contents", SqlDbType.NVarChar, 400)
				{
					Value = model.Contents
				},
				(!model.SendUserID.HasValue) ? new SqlParameter("@SendUserID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@SendUserID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.SendUserID
				},
				(model.SendUserName == null) ? new SqlParameter("@SendUserName", SqlDbType.NVarChar, 1000)
				{
					Value = DBNull.Value
				} : new SqlParameter("@SendUserName", SqlDbType.NVarChar, 1000)
				{
					Value = model.SendUserName
				},
				new SqlParameter("@SendTime", SqlDbType.DateTime, 8)
				{
					Value = model.SendTime
				},
				new SqlParameter("@Status", SqlDbType.Int, -1)
				{
					Value = model.Status
				},
				(model.Note == null) ? new SqlParameter("@Note", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Note", SqlDbType.VarChar, -1)
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
			string sql = "DELETE FROM SMSLog WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.SMSLog> DataReaderToList(SqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.SMSLog> list = new List<RoadFlow.Data.Model.SMSLog>();
			RoadFlow.Data.Model.SMSLog sMSLog = null;
			while (dataReader.Read())
			{
				sMSLog = new RoadFlow.Data.Model.SMSLog();
				sMSLog.ID = dataReader.GetGuid(0);
				sMSLog.MobileNumber = dataReader.GetString(1);
				sMSLog.Contents = dataReader.GetString(2);
				if (!dataReader.IsDBNull(3))
				{
					sMSLog.SendUserID = dataReader.GetGuid(3);
				}
				if (!dataReader.IsDBNull(4))
				{
					sMSLog.SendUserName = dataReader.GetString(4);
				}
				sMSLog.SendTime = dataReader.GetDateTime(5);
				sMSLog.Status = dataReader.GetInt32(6);
				if (!dataReader.IsDBNull(7))
				{
					sMSLog.Note = dataReader.GetString(7);
				}
				list.Add(sMSLog);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.SMSLog> GetAll()
		{
			string sql = "SELECT * FROM SMSLog";
			SqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.SMSLog> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM SMSLog";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.SMSLog Get(Guid id)
		{
			string sql = "SELECT * FROM SMSLog WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.SMSLog> list = DataReaderToList(dataReader);
			dataReader.Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}
	}
}
