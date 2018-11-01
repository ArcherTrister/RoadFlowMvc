using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace RoadFlow.Data.ORACLE
{
	public class HastenLog : IHastenLog
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.HastenLog model)
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
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0070: Unknown result type (might be due to invalid IL or missing references)
			//IL_007c: Expected O, but got Unknown
			//IL_007d: Expected O, but got Unknown
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Expected O, but got Unknown
			//IL_0098: Expected O, but got Unknown
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b7: Expected O, but got Unknown
			//IL_00b8: Expected O, but got Unknown
			//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Expected O, but got Unknown
			//IL_00d3: Expected O, but got Unknown
			//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f2: Expected O, but got Unknown
			//IL_00f3: Expected O, but got Unknown
			string sql = "INSERT INTO HastenLog\r\n\t\t\t\t(ID,OthersParams,Users,Types,Contents,SendUser,SendUserName,SendTime) \r\n\t\t\t\tVALUES(:ID,:OthersParams,:Users,:Types,:Contents,:SendUser,:SendUserName,:SendTime)";
			OracleParameter[] obj = new OracleParameter[8];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":OthersParams", 126);
			((DbParameter)val2).Value = model.OthersParams;
			obj[1] = val2;
			OracleParameter val3 = new OracleParameter(":Users", 126);
			((DbParameter)val3).Value = model.Users;
			obj[2] = val3;
			OracleParameter val4 = new OracleParameter(":Types", 126);
			((DbParameter)val4).Value = model.Types;
			obj[3] = val4;
			OracleParameter val5 = new OracleParameter(":Contents", 119);
			((DbParameter)val5).Value = model.Contents;
			obj[4] = val5;
			OracleParameter val6 = new OracleParameter(":SendUser", 126);
			((DbParameter)val6).Value = model.SendUser;
			obj[5] = val6;
			OracleParameter val7 = new OracleParameter(":SendUserName", 126);
			((DbParameter)val7).Value = model.SendUserName;
			obj[6] = val7;
			OracleParameter val8 = new OracleParameter(":SendTime", 106);
			((DbParameter)val8).Value = model.SendTime;
			obj[7] = val8;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.HastenLog model)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Expected O, but got Unknown
			//IL_0042: Expected O, but got Unknown
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Expected O, but got Unknown
			//IL_005d: Expected O, but got Unknown
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Expected O, but got Unknown
			//IL_0078: Expected O, but got Unknown
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Expected O, but got Unknown
			//IL_0098: Expected O, but got Unknown
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Expected O, but got Unknown
			//IL_00b3: Expected O, but got Unknown
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Expected O, but got Unknown
			//IL_00d3: Expected O, but got Unknown
			//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f2: Expected O, but got Unknown
			//IL_00f3: Expected O, but got Unknown
			string sql = "UPDATE HastenLog SET \r\n\t\t\t\tOthersParams=:OthersParams,Users=:Users,Types=:Types,Contents=:Contents,SendUser=:SendUser,SendUserName=:SendUserName,SendTime=:SendTime\r\n\t\t\t\tWHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[8];
			OracleParameter val = new OracleParameter(":OthersParams", 126);
			((DbParameter)val).Value = model.OthersParams;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":Users", 126);
			((DbParameter)val2).Value = model.Users;
			obj[1] = val2;
			OracleParameter val3 = new OracleParameter(":Types", 126);
			((DbParameter)val3).Value = model.Types;
			obj[2] = val3;
			OracleParameter val4 = new OracleParameter(":Contents", 119);
			((DbParameter)val4).Value = model.Contents;
			obj[3] = val4;
			OracleParameter val5 = new OracleParameter(":SendUser", 126);
			((DbParameter)val5).Value = model.SendUser;
			obj[4] = val5;
			OracleParameter val6 = new OracleParameter(":SendUserName", 126);
			((DbParameter)val6).Value = model.SendUserName;
			obj[5] = val6;
			OracleParameter val7 = new OracleParameter(":SendTime", 106);
			((DbParameter)val7).Value = model.SendTime;
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
			string sql = "DELETE FROM HastenLog WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.HastenLog> DataReaderToList(OracleDataReader dataReader)
		{
			List<RoadFlow.Data.Model.HastenLog> list = new List<RoadFlow.Data.Model.HastenLog>();
			RoadFlow.Data.Model.HastenLog hastenLog = null;
			while (((DbDataReader)dataReader).Read())
			{
				hastenLog = new RoadFlow.Data.Model.HastenLog();
				hastenLog.ID = ((DbDataReader)dataReader).GetGuid(0);
				hastenLog.OthersParams = ((DbDataReader)dataReader).GetString(1);
				hastenLog.Users = ((DbDataReader)dataReader).GetString(2);
				hastenLog.Types = ((DbDataReader)dataReader).GetString(3);
				hastenLog.Contents = ((DbDataReader)dataReader).GetString(4);
				hastenLog.SendUser = ((DbDataReader)dataReader).GetGuid(5);
				hastenLog.SendUserName = ((DbDataReader)dataReader).GetString(6);
				hastenLog.SendTime = ((DbDataReader)dataReader).GetDateTime(7);
				list.Add(hastenLog);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.HastenLog> GetAll()
		{
			string sql = "SELECT * FROM HastenLog";
			OracleDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.HastenLog> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
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
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "SELECT * FROM HastenLog WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.HastenLog> list = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}
	}
}
