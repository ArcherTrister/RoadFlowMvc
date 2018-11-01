using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace RoadFlow.Data.MySql
{
	public class WorkFlowData : IWorkFlowData
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.WorkFlowData model)
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Expected O, but got Unknown
			//IL_0030: Expected O, but got Unknown
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Expected O, but got Unknown
			//IL_0054: Expected O, but got Unknown
			//IL_0061: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Expected O, but got Unknown
			//IL_0078: Expected O, but got Unknown
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_009a: Expected O, but got Unknown
			//IL_009b: Expected O, but got Unknown
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bd: Expected O, but got Unknown
			//IL_00be: Expected O, but got Unknown
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Expected O, but got Unknown
			//IL_00e1: Expected O, but got Unknown
			string sql = "INSERT INTO WorkFlowData\r\n\t\t\t\t(ID,InstanceID,LinkID,TableName,FieldName,Value) \r\n\t\t\t\tVALUES(@ID,@InstanceID,@LinkID,@TableName,@FieldName,@Value)";
			MySqlParameter[] obj = new MySqlParameter[6];
			MySqlParameter val = new MySqlParameter("@ID", 253, -1);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@InstanceID", 253, -1);
			((DbParameter)val2).Value = model.InstanceID;
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@LinkID", 253, -1);
			((DbParameter)val3).Value = model.LinkID;
			obj[2] = val3;
			MySqlParameter val4 = new MySqlParameter("@TableName", 253, 500);
			((DbParameter)val4).Value = model.TableName;
			obj[3] = val4;
			MySqlParameter val5 = new MySqlParameter("@FieldName", 253, 500);
			((DbParameter)val5).Value = model.FieldName;
			obj[4] = val5;
			MySqlParameter val6 = new MySqlParameter("@Value", 253, 8000);
			((DbParameter)val6).Value = model.Value;
			obj[5] = val6;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.WorkFlowData model)
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Expected O, but got Unknown
			//IL_0030: Expected O, but got Unknown
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Expected O, but got Unknown
			//IL_0054: Expected O, but got Unknown
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Expected O, but got Unknown
			//IL_0077: Expected O, but got Unknown
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0099: Expected O, but got Unknown
			//IL_009a: Expected O, but got Unknown
			//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bc: Expected O, but got Unknown
			//IL_00bd: Expected O, but got Unknown
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Expected O, but got Unknown
			//IL_00e1: Expected O, but got Unknown
			string sql = "UPDATE WorkFlowData SET \r\n\t\t\t\tInstanceID=@InstanceID,LinkID=@LinkID,TableName=@TableName,FieldName=@FieldName,Value=@Value\r\n\t\t\t\tWHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[6];
			MySqlParameter val = new MySqlParameter("@InstanceID", 253, -1);
			((DbParameter)val).Value = model.InstanceID;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@LinkID", 253, -1);
			((DbParameter)val2).Value = model.LinkID;
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@TableName", 253, 500);
			((DbParameter)val3).Value = model.TableName;
			obj[2] = val3;
			MySqlParameter val4 = new MySqlParameter("@FieldName", 253, 500);
			((DbParameter)val4).Value = model.FieldName;
			obj[3] = val4;
			MySqlParameter val5 = new MySqlParameter("@Value", 253, 8000);
			((DbParameter)val5).Value = model.Value;
			obj[4] = val5;
			MySqlParameter val6 = new MySqlParameter("@ID", 253, -1);
			((DbParameter)val6).Value = model.ID;
			obj[5] = val6;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Delete(Guid id)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			string sql = "DELETE FROM WorkFlowData WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.WorkFlowData> DataReaderToList(MySqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.WorkFlowData> list = new List<RoadFlow.Data.Model.WorkFlowData>();
			RoadFlow.Data.Model.WorkFlowData workFlowData = null;
			while (((DbDataReader)dataReader).Read())
			{
				workFlowData = new RoadFlow.Data.Model.WorkFlowData();
				workFlowData.ID = ((DbDataReader)dataReader).GetGuid(0);
				workFlowData.InstanceID = ((DbDataReader)dataReader).GetGuid(1);
				workFlowData.LinkID = ((DbDataReader)dataReader).GetGuid(2);
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
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql);
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
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			string sql = "SELECT * FROM WorkFlowData WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
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
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			string sql = "SELECT * FROM WorkFlowData WHERE InstanceID=@InstanceID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@InstanceID", 253);
			((DbParameter)val).Value = instanceID.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.WorkFlowData> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}
	}
}
