using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace RoadFlow.Data.MySql
{
	public class SMSLog : ISMSLog
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.SMSLog model)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Expected O, but got Unknown
			//IL_0050: Expected O, but got Unknown
			//IL_0061: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Expected O, but got Unknown
			//IL_0073: Expected O, but got Unknown
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a7: Expected O, but got Unknown
			//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c5: Expected O, but got Unknown
			//IL_00c6: Expected O, but got Unknown
			//IL_00db: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Expected O, but got Unknown
			//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0109: Expected O, but got Unknown
			//IL_010a: Expected O, but got Unknown
			//IL_0114: Unknown result type (might be due to invalid IL or missing references)
			//IL_0119: Unknown result type (might be due to invalid IL or missing references)
			//IL_012a: Expected O, but got Unknown
			//IL_012b: Expected O, but got Unknown
			//IL_0135: Unknown result type (might be due to invalid IL or missing references)
			//IL_013a: Unknown result type (might be due to invalid IL or missing references)
			//IL_014b: Expected O, but got Unknown
			//IL_014c: Expected O, but got Unknown
			//IL_0161: Unknown result type (might be due to invalid IL or missing references)
			//IL_0166: Unknown result type (might be due to invalid IL or missing references)
			//IL_0172: Expected O, but got Unknown
			//IL_017f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0184: Unknown result type (might be due to invalid IL or missing references)
			//IL_018f: Expected O, but got Unknown
			//IL_0190: Expected O, but got Unknown
			string sql = "INSERT INTO smslog\r\n\t\t\t\t(ID,MobileNumber,Contents,SendUserID,SendUserName,SendTime,Status,Note) \r\n\t\t\t\tVALUES(@ID,@MobileNumber,@Contents,@SendUserID,@SendUserName,@SendTime,@Status,@Note)";
			MySqlParameter[] obj = new MySqlParameter[8];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@MobileNumber", 751, -1);
			((DbParameter)val2).Value = model.MobileNumber;
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@Contents", 253, 200);
			((DbParameter)val3).Value = model.Contents;
			obj[2] = val3;
			_003F val4;
			if (model.SendUserID.HasValue)
			{
				val4 = new MySqlParameter("@SendUserID", 253, 36);
				((DbParameter)val4).Value = model.SendUserID;
			}
			else
			{
				val4 = new MySqlParameter("@SendUserID", 253, 36);
				((DbParameter)val4).Value = DBNull.Value;
			}
			obj[3] = val4;
			_003F val5;
			if (model.SendUserName != null)
			{
				val5 = new MySqlParameter("@SendUserName", 752, -1);
				((DbParameter)val5).Value = model.SendUserName;
			}
			else
			{
				val5 = new MySqlParameter("@SendUserName", 752, -1);
				((DbParameter)val5).Value = DBNull.Value;
			}
			obj[4] = val5;
			MySqlParameter val6 = new MySqlParameter("@SendTime", 12, -1);
			((DbParameter)val6).Value = model.SendTime;
			obj[5] = val6;
			MySqlParameter val7 = new MySqlParameter("@Status", 3, 11);
			((DbParameter)val7).Value = model.Status;
			obj[6] = val7;
			_003F val8;
			if (model.Note != null)
			{
				val8 = new MySqlParameter("@Note", 751, -1);
				((DbParameter)val8).Value = model.Note;
			}
			else
			{
				val8 = new MySqlParameter("@Note", 751, -1);
				((DbParameter)val8).Value = DBNull.Value;
			}
			obj[7] = val8;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.SMSLog model)
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Expected O, but got Unknown
			//IL_002b: Expected O, but got Unknown
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Expected O, but got Unknown
			//IL_004e: Expected O, but got Unknown
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Expected O, but got Unknown
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Expected O, but got Unknown
			//IL_00a1: Expected O, but got Unknown
			//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c7: Expected O, but got Unknown
			//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e4: Expected O, but got Unknown
			//IL_00e5: Expected O, but got Unknown
			//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0105: Expected O, but got Unknown
			//IL_0106: Expected O, but got Unknown
			//IL_0110: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0126: Expected O, but got Unknown
			//IL_0127: Expected O, but got Unknown
			//IL_013c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0141: Unknown result type (might be due to invalid IL or missing references)
			//IL_014d: Expected O, but got Unknown
			//IL_015a: Unknown result type (might be due to invalid IL or missing references)
			//IL_015f: Unknown result type (might be due to invalid IL or missing references)
			//IL_016a: Expected O, but got Unknown
			//IL_016b: Expected O, but got Unknown
			//IL_0179: Unknown result type (might be due to invalid IL or missing references)
			//IL_017e: Unknown result type (might be due to invalid IL or missing references)
			//IL_018f: Expected O, but got Unknown
			//IL_0190: Expected O, but got Unknown
			string sql = "UPDATE smslog SET \r\n\t\t\t\tMobileNumber=@MobileNumber,Contents=@Contents,SendUserID=@SendUserID,SendUserName=@SendUserName,SendTime=@SendTime,Status=@Status,Note=@Note\r\n\t\t\t\tWHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[8];
			MySqlParameter val = new MySqlParameter("@MobileNumber", 751, -1);
			((DbParameter)val).Value = model.MobileNumber;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@Contents", 253, 200);
			((DbParameter)val2).Value = model.Contents;
			obj[1] = val2;
			_003F val3;
			if (model.SendUserID.HasValue)
			{
				val3 = new MySqlParameter("@SendUserID", 253, 36);
				((DbParameter)val3).Value = model.SendUserID;
			}
			else
			{
				val3 = new MySqlParameter("@SendUserID", 253, 36);
				((DbParameter)val3).Value = DBNull.Value;
			}
			obj[2] = val3;
			_003F val4;
			if (model.SendUserName != null)
			{
				val4 = new MySqlParameter("@SendUserName", 752, -1);
				((DbParameter)val4).Value = model.SendUserName;
			}
			else
			{
				val4 = new MySqlParameter("@SendUserName", 752, -1);
				((DbParameter)val4).Value = DBNull.Value;
			}
			obj[3] = val4;
			MySqlParameter val5 = new MySqlParameter("@SendTime", 12, -1);
			((DbParameter)val5).Value = model.SendTime;
			obj[4] = val5;
			MySqlParameter val6 = new MySqlParameter("@Status", 3, 11);
			((DbParameter)val6).Value = model.Status;
			obj[5] = val6;
			_003F val7;
			if (model.Note != null)
			{
				val7 = new MySqlParameter("@Note", 751, -1);
				((DbParameter)val7).Value = model.Note;
			}
			else
			{
				val7 = new MySqlParameter("@Note", 751, -1);
				((DbParameter)val7).Value = DBNull.Value;
			}
			obj[6] = val7;
			MySqlParameter val8 = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val8).Value = model.ID;
			obj[7] = val8;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Delete(Guid id)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Expected O, but got Unknown
			string sql = "DELETE FROM smslog WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.SMSLog> DataReaderToList(MySqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.SMSLog> list = new List<RoadFlow.Data.Model.SMSLog>();
			RoadFlow.Data.Model.SMSLog sMSLog = null;
			while (((DbDataReader)dataReader).Read())
			{
				sMSLog = new RoadFlow.Data.Model.SMSLog();
				sMSLog.ID = ((DbDataReader)dataReader).GetString(0).ToGuid();
				sMSLog.MobileNumber = ((DbDataReader)dataReader).GetString(1);
				sMSLog.Contents = ((DbDataReader)dataReader).GetString(2);
				if (!((DbDataReader)dataReader).IsDBNull(3))
				{
					sMSLog.SendUserID = ((DbDataReader)dataReader).GetString(3).ToGuid();
				}
				if (!((DbDataReader)dataReader).IsDBNull(4))
				{
					sMSLog.SendUserName = ((DbDataReader)dataReader).GetString(4);
				}
				sMSLog.SendTime = ((DbDataReader)dataReader).GetDateTime(5);
				sMSLog.Status = ((DbDataReader)dataReader).GetInt32(6);
				if (!((DbDataReader)dataReader).IsDBNull(7))
				{
					sMSLog.Note = ((DbDataReader)dataReader).GetString(7);
				}
				list.Add(sMSLog);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.SMSLog> GetAll()
		{
			string sql = "SELECT * FROM smslog";
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.SMSLog> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM smslog";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.SMSLog Get(Guid id)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Expected O, but got Unknown
			string sql = "SELECT * FROM smslog WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.SMSLog> list = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}
	}
}
