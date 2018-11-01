using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace RoadFlow.Data.ORACLE
{
	public class WorkFlowData : IWorkFlowData
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.WorkFlowData model)
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Expected O, but got Unknown
			//IL_002e: Expected O, but got Unknown
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Expected O, but got Unknown
			//IL_0050: Expected O, but got Unknown
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Expected O, but got Unknown
			//IL_0072: Expected O, but got Unknown
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Expected O, but got Unknown
			//IL_0092: Expected O, but got Unknown
			//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Expected O, but got Unknown
			//IL_00b2: Expected O, but got Unknown
			//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Expected O, but got Unknown
			//IL_00d2: Expected O, but got Unknown
			string sql = "INSERT INTO WorkFlowData\r\n\t\t\t\t(ID,InstanceID,LinkID,TableName,FieldName,Value) \r\n\t\t\t\tVALUES(:ID,:InstanceID,:LinkID,:TableName,:FieldName,:Value)";
			OracleParameter[] obj = new OracleParameter[6];
			OracleParameter val = new OracleParameter(":ID", 126, 40);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":InstanceID", 126, 40);
			((DbParameter)val2).Value = model.InstanceID;
			obj[1] = val2;
			OracleParameter val3 = new OracleParameter(":LinkID", 126, 40);
			((DbParameter)val3).Value = model.LinkID;
			obj[2] = val3;
			OracleParameter val4 = new OracleParameter(":TableName", 126, 500);
			((DbParameter)val4).Value = model.TableName;
			obj[3] = val4;
			OracleParameter val5 = new OracleParameter(":FieldName", 126, 500);
			((DbParameter)val5).Value = model.FieldName;
			obj[4] = val5;
			OracleParameter val6 = new OracleParameter(":Value", 126, 4000);
			((DbParameter)val6).Value = model.Value;
			obj[5] = val6;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.WorkFlowData model)
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Expected O, but got Unknown
			//IL_002e: Expected O, but got Unknown
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Expected O, but got Unknown
			//IL_0050: Expected O, but got Unknown
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Expected O, but got Unknown
			//IL_0070: Expected O, but got Unknown
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Expected O, but got Unknown
			//IL_0090: Expected O, but got Unknown
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Expected O, but got Unknown
			//IL_00b0: Expected O, but got Unknown
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Expected O, but got Unknown
			//IL_00d2: Expected O, but got Unknown
			string sql = "UPDATE WorkFlowData SET \r\n\t\t\t\tInstanceID=:InstanceID,LinkID=:LinkID,TableName=:TableName,FieldName=:FieldName,Value=:Value\r\n\t\t\t\tWHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[6];
			OracleParameter val = new OracleParameter(":InstanceID", 126, 40);
			((DbParameter)val).Value = model.InstanceID;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":LinkID", 126, 40);
			((DbParameter)val2).Value = model.LinkID;
			obj[1] = val2;
			OracleParameter val3 = new OracleParameter(":TableName", 126, 500);
			((DbParameter)val3).Value = model.TableName;
			obj[2] = val3;
			OracleParameter val4 = new OracleParameter(":FieldName", 126, 500);
			((DbParameter)val4).Value = model.FieldName;
			obj[3] = val4;
			OracleParameter val5 = new OracleParameter(":Value", 126, 4000);
			((DbParameter)val5).Value = model.Value;
			obj[4] = val5;
			OracleParameter val6 = new OracleParameter(":ID", 126, 40);
			((DbParameter)val6).Value = model.ID;
			obj[5] = val6;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Delete(Guid id)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "DELETE FROM WorkFlowData WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.WorkFlowData> DataReaderToList(OracleDataReader dataReader)
		{
			List<RoadFlow.Data.Model.WorkFlowData> list = new List<RoadFlow.Data.Model.WorkFlowData>();
			RoadFlow.Data.Model.WorkFlowData workFlowData = null;
			while (((DbDataReader)dataReader).Read())
			{
				workFlowData = new RoadFlow.Data.Model.WorkFlowData();
				workFlowData.ID = ((DbDataReader)dataReader).GetString(0).ToGuid();
				workFlowData.InstanceID = ((DbDataReader)dataReader).GetString(1).ToGuid();
				workFlowData.LinkID = ((DbDataReader)dataReader).GetString(2).ToGuid();
				workFlowData.TableName = ((DbDataReader)dataReader).GetString(3);
				workFlowData.FieldName = ((DbDataReader)dataReader).GetString(4);
				workFlowData.Value = ((DbDataReader)dataReader).GetString(5);
				list.Add(workFlowData);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.WorkFlowData> GetAll()
		{
			string sql = "SELECT * FROM WorkFlowData";
			OracleDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.WorkFlowData> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM WorkFlowData";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.WorkFlowData Get(Guid id)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "SELECT * FROM WorkFlowData WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.WorkFlowData> list = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public List<RoadFlow.Data.Model.WorkFlowData> GetAll(Guid instanceID)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "SELECT * FROM WorkFlowData WHERE InstanceID=:InstanceID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":InstanceID", 126);
			((DbParameter)val).Value = instanceID;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.WorkFlowData> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}
	}
}
