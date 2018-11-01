using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace RoadFlow.Data.ORACLE
{
	public class WorkGroup : IWorkGroup
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.WorkGroup model)
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Expected O, but got Unknown
			//IL_002e: Expected O, but got Unknown
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Expected O, but got Unknown
			//IL_004e: Expected O, but got Unknown
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Expected O, but got Unknown
			//IL_0069: Expected O, but got Unknown
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Expected O, but got Unknown
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a4: Expected O, but got Unknown
			//IL_00a5: Expected O, but got Unknown
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c4: Expected O, but got Unknown
			//IL_00c5: Expected O, but got Unknown
			string sql = "INSERT INTO WorkGroup\r\n\t\t\t\t(ID,Name,Members,Note,IntID) \r\n\t\t\t\tVALUES(:ID,:Name,:Members,:Note,:IntID)";
			OracleParameter[] obj = new OracleParameter[5];
			OracleParameter val = new OracleParameter(":ID", 126, 40);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":Name", 119, 1000);
			((DbParameter)val2).Value = model.Name;
			obj[1] = val2;
			OracleParameter val3 = new OracleParameter(":Members", 105);
			((DbParameter)val3).Value = model.Members;
			obj[2] = val3;
			_003F val4;
			if (model.Note != null)
			{
				val4 = new OracleParameter(":Note", 119);
				((DbParameter)val4).Value = model.Note;
			}
			else
			{
				val4 = new OracleParameter(":Note", 119);
				((DbParameter)val4).Value = DBNull.Value;
			}
			obj[3] = val4;
			OracleParameter val5 = new OracleParameter(":IntID", 112);
			((DbParameter)val5).Value = model.IntID;
			obj[4] = val5;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.WorkGroup model)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Expected O, but got Unknown
			//IL_002c: Expected O, but got Unknown
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0046: Expected O, but got Unknown
			//IL_0047: Expected O, but got Unknown
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Expected O, but got Unknown
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Expected O, but got Unknown
			//IL_0083: Expected O, but got Unknown
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Expected O, but got Unknown
			//IL_00a3: Expected O, but got Unknown
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c4: Expected O, but got Unknown
			//IL_00c5: Expected O, but got Unknown
			string sql = "UPDATE WorkGroup SET \r\n\t\t\t\tName=:Name,Members=:Members,Note=:Note,IntID=:IntID \r\n\t\t\t\tWHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[5];
			OracleParameter val = new OracleParameter(":Name", 119, 1000);
			((DbParameter)val).Value = model.Name;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":Members", 105);
			((DbParameter)val2).Value = model.Members;
			obj[1] = val2;
			_003F val3;
			if (model.Note != null)
			{
				val3 = new OracleParameter(":Note", 119);
				((DbParameter)val3).Value = model.Note;
			}
			else
			{
				val3 = new OracleParameter(":Note", 119);
				((DbParameter)val3).Value = DBNull.Value;
			}
			obj[2] = val3;
			OracleParameter val4 = new OracleParameter(":IntID", 112);
			((DbParameter)val4).Value = model.IntID;
			obj[3] = val4;
			OracleParameter val5 = new OracleParameter(":ID", 126, 40);
			((DbParameter)val5).Value = model.ID;
			obj[4] = val5;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Delete(Guid id)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "DELETE FROM WorkGroup WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.WorkGroup> DataReaderToList(OracleDataReader dataReader)
		{
			List<RoadFlow.Data.Model.WorkGroup> list = new List<RoadFlow.Data.Model.WorkGroup>();
			RoadFlow.Data.Model.WorkGroup workGroup = null;
			while (((DbDataReader)dataReader).Read())
			{
				workGroup = new RoadFlow.Data.Model.WorkGroup();
				workGroup.ID = ((DbDataReader)dataReader).GetString(0).ToGuid();
				workGroup.Name = ((DbDataReader)dataReader).GetString(1);
				workGroup.Members = ((DbDataReader)dataReader).GetString(2);
				if (!((DbDataReader)dataReader).IsDBNull(3))
				{
					workGroup.Note = ((DbDataReader)dataReader).GetString(3);
				}
				workGroup.IntID = ((DbDataReader)dataReader).GetInt32(4);
				list.Add(workGroup);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.WorkGroup> GetAll()
		{
			string sql = "SELECT * FROM WorkGroup";
			OracleDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.WorkGroup> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM WorkGroup";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.WorkGroup Get(Guid id)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "SELECT * FROM WorkGroup WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.WorkGroup> list = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}
	}
}
