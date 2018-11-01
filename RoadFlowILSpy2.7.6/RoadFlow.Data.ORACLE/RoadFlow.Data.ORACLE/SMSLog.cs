using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace RoadFlow.Data.ORACLE
{
	public class SMSLog : ISMSLog
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.SMSLog model)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Expected O, but got Unknown
			//IL_002c: Expected O, but got Unknown
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0046: Expected O, but got Unknown
			//IL_0047: Expected O, but got Unknown
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_0061: Expected O, but got Unknown
			//IL_0062: Expected O, but got Unknown
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Expected O, but got Unknown
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_009f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00aa: Expected O, but got Unknown
			//IL_00ab: Expected O, but got Unknown
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cd: Expected O, but got Unknown
			//IL_00db: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00eb: Expected O, but got Unknown
			//IL_00ec: Expected O, but got Unknown
			//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_010b: Expected O, but got Unknown
			//IL_010c: Expected O, but got Unknown
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_011a: Unknown result type (might be due to invalid IL or missing references)
			//IL_012b: Expected O, but got Unknown
			//IL_012c: Expected O, but got Unknown
			//IL_0135: Unknown result type (might be due to invalid IL or missing references)
			//IL_013a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0146: Expected O, but got Unknown
			//IL_0147: Expected O, but got Unknown
			string sql = "INSERT INTO SMSLog\r\n\t\t\t\t(ID,MobileNumber,Contents,SendUserID,SendUserName,SendTime,Status,Note) \r\n\t\t\t\tVALUES(:ID,:MobileNumber,:Contents,:SendUserID,:SendUserName,:SendTime,:Status,:Note)";
			OracleParameter[] obj = new OracleParameter[8];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":MobileNumber", 126);
			((DbParameter)val2).Value = model.MobileNumber;
			obj[1] = val2;
			OracleParameter val3 = new OracleParameter(":Contents", 119);
			((DbParameter)val3).Value = model.Contents;
			obj[2] = val3;
			_003F val4;
			if (model.SendUserID.HasValue)
			{
				val4 = new OracleParameter(":SendUserID", 126);
				((DbParameter)val4).Value = model.SendUserID;
			}
			else
			{
				val4 = new OracleParameter(":SendUserID", 126);
				((DbParameter)val4).Value = DBNull.Value;
			}
			obj[3] = val4;
			_003F val5;
			if (model.SendUserName != null)
			{
				val5 = new OracleParameter(":SendUserName", 119);
				((DbParameter)val5).Value = model.SendUserName;
			}
			else
			{
				val5 = new OracleParameter(":SendUserName", 119, 1000);
				((DbParameter)val5).Value = DBNull.Value;
			}
			obj[4] = val5;
			OracleParameter val6 = new OracleParameter(":SendTime", 106);
			((DbParameter)val6).Value = model.SendTime;
			obj[5] = val6;
			OracleParameter val7 = new OracleParameter(":Status", 112);
			((DbParameter)val7).Value = model.Status;
			obj[6] = val7;
			OracleParameter val8 = new OracleParameter(":Note", 126);
			((DbParameter)val8).Value = model.Note;
			obj[7] = val8;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.SMSLog model)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Expected O, but got Unknown
			//IL_0042: Expected O, but got Unknown
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Expected O, but got Unknown
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Expected O, but got Unknown
			//IL_008b: Expected O, but got Unknown
			//IL_009c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ad: Expected O, but got Unknown
			//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c6: Expected O, but got Unknown
			//IL_00c7: Expected O, but got Unknown
			//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Expected O, but got Unknown
			//IL_00e7: Expected O, but got Unknown
			//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0106: Expected O, but got Unknown
			//IL_0107: Expected O, but got Unknown
			//IL_0110: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0121: Expected O, but got Unknown
			//IL_0122: Expected O, but got Unknown
			//IL_012b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0130: Unknown result type (might be due to invalid IL or missing references)
			//IL_0141: Expected O, but got Unknown
			//IL_0142: Expected O, but got Unknown
			string sql = "UPDATE SMSLog SET \r\n\t\t\t\tMobileNumber=:MobileNumber,Contents=:Contents,SendUserID=:SendUserID,SendUserName=:SendUserName,SendTime=:SendTime,Status=:Status,Note=:Note\r\n\t\t\t\tWHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[8];
			OracleParameter val = new OracleParameter(":MobileNumber", 126);
			((DbParameter)val).Value = model.MobileNumber;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":Contents", 119);
			((DbParameter)val2).Value = model.Contents;
			obj[1] = val2;
			_003F val3;
			if (model.SendUserID.HasValue)
			{
				val3 = new OracleParameter(":SendUserID", 126);
				((DbParameter)val3).Value = model.SendUserID;
			}
			else
			{
				val3 = new OracleParameter(":SendUserID", 126);
				((DbParameter)val3).Value = DBNull.Value;
			}
			obj[2] = val3;
			_003F val4;
			if (model.SendUserName != null)
			{
				val4 = new OracleParameter(":SendUserName", 119);
				((DbParameter)val4).Value = model.SendUserName;
			}
			else
			{
				val4 = new OracleParameter(":SendUserName", 119);
				((DbParameter)val4).Value = DBNull.Value;
			}
			obj[3] = val4;
			OracleParameter val5 = new OracleParameter(":SendTime", 106);
			((DbParameter)val5).Value = model.SendTime;
			obj[4] = val5;
			OracleParameter val6 = new OracleParameter(":Status", 112);
			((DbParameter)val6).Value = model.Status;
			obj[5] = val6;
			OracleParameter val7 = new OracleParameter(":Note", 126);
			((DbParameter)val7).Value = model.Note;
			obj[6] = val7;
			OracleParameter val8 = new OracleParameter(":ID", 126);
			((DbParameter)val8).Value = model.ID;
			obj[7] = val8;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Delete(Guid id)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "DELETE FROM SMSLog WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.SMSLog> DataReaderToList(OracleDataReader dataReader)
		{
			List<RoadFlow.Data.Model.SMSLog> list = new List<RoadFlow.Data.Model.SMSLog>();
			RoadFlow.Data.Model.SMSLog sMSLog = null;
			while (((DbDataReader)dataReader).Read())
			{
				sMSLog = new RoadFlow.Data.Model.SMSLog();
				sMSLog.ID = ((DbDataReader)dataReader).GetGuid(0);
				sMSLog.MobileNumber = ((DbDataReader)dataReader).GetString(1);
				sMSLog.Contents = ((DbDataReader)dataReader).GetString(2);
				if (!((DbDataReader)dataReader).IsDBNull(3))
				{
					sMSLog.SendUserID = ((DbDataReader)dataReader).GetGuid(3);
				}
				if (!((DbDataReader)dataReader).IsDBNull(4))
				{
					sMSLog.SendUserName = ((DbDataReader)dataReader).GetString(4);
				}
				sMSLog.SendTime = ((DbDataReader)dataReader).GetDateTime(5);
				sMSLog.Status = ((DbDataReader)dataReader).GetInt32(6);
				sMSLog.Note = ((DbDataReader)dataReader).GetString(7);
				list.Add(sMSLog);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.SMSLog> GetAll()
		{
			string sql = "SELECT * FROM SMSLog";
			OracleDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.SMSLog> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
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
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "SELECT * FROM SMSLog WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
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
