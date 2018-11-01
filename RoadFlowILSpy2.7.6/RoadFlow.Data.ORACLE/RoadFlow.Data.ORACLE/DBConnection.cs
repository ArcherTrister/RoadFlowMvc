using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace RoadFlow.Data.ORACLE
{
	public class DBConnection : IDBConnection
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.DBConnection model)
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Expected O, but got Unknown
			//IL_002e: Expected O, but got Unknown
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Expected O, but got Unknown
			//IL_004e: Expected O, but got Unknown
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0061: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Expected O, but got Unknown
			//IL_006e: Expected O, but got Unknown
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Expected O, but got Unknown
			//IL_0089: Expected O, but got Unknown
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_009f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ab: Expected O, but got Unknown
			//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c4: Expected O, but got Unknown
			//IL_00c5: Expected O, but got Unknown
			string sql = "INSERT INTO DBConnection\r\n\t\t\t\t(ID,Name,Type,ConnectionString,Note) \r\n\t\t\t\tVALUES(:ID,:Name,:Type,:ConnectionString,:Note)";
			OracleParameter[] obj = new OracleParameter[5];
			OracleParameter val = new OracleParameter(":ID", 126, 40);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":Name", 126, 500);
			((DbParameter)val2).Value = model.Name;
			obj[1] = val2;
			OracleParameter val3 = new OracleParameter(":Type", 126, 500);
			((DbParameter)val3).Value = model.Type;
			obj[2] = val3;
			OracleParameter val4 = new OracleParameter(":ConnectionString", 105);
			((DbParameter)val4).Value = model.ConnectionString;
			obj[3] = val4;
			_003F val5;
			if (model.Note != null)
			{
				val5 = new OracleParameter(":Note", 105);
				((DbParameter)val5).Value = model.Note;
			}
			else
			{
				val5 = new OracleParameter(":Note", 105);
				((DbParameter)val5).Value = DBNull.Value;
			}
			obj[4] = val5;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.DBConnection model)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Expected O, but got Unknown
			//IL_002c: Expected O, but got Unknown
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Expected O, but got Unknown
			//IL_004c: Expected O, but got Unknown
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Expected O, but got Unknown
			//IL_0067: Expected O, but got Unknown
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0089: Expected O, but got Unknown
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Expected O, but got Unknown
			//IL_00a3: Expected O, but got Unknown
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c4: Expected O, but got Unknown
			//IL_00c5: Expected O, but got Unknown
			string sql = "UPDATE DBConnection SET \r\n\t\t\t\tName=:Name,Type=:Type,ConnectionString=:ConnectionString,Note=:Note\r\n\t\t\t\tWHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[5];
			OracleParameter val = new OracleParameter(":Name", 126, 500);
			((DbParameter)val).Value = model.Name;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":Type", 126, 500);
			((DbParameter)val2).Value = model.Type;
			obj[1] = val2;
			OracleParameter val3 = new OracleParameter(":ConnectionString", 105);
			((DbParameter)val3).Value = model.ConnectionString;
			obj[2] = val3;
			_003F val4;
			if (model.Note != null)
			{
				val4 = new OracleParameter(":Note", 105);
				((DbParameter)val4).Value = model.Note;
			}
			else
			{
				val4 = new OracleParameter(":Note", 105);
				((DbParameter)val4).Value = DBNull.Value;
			}
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
			string sql = "DELETE FROM DBConnection WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.DBConnection> DataReaderToList(OracleDataReader dataReader)
		{
			List<RoadFlow.Data.Model.DBConnection> list = new List<RoadFlow.Data.Model.DBConnection>();
			RoadFlow.Data.Model.DBConnection dBConnection = null;
			while (((DbDataReader)dataReader).Read())
			{
				dBConnection = new RoadFlow.Data.Model.DBConnection();
				dBConnection.ID = ((DbDataReader)dataReader).GetString(0).ToGuid();
				dBConnection.Name = ((DbDataReader)dataReader).GetString(1);
				dBConnection.Type = ((DbDataReader)dataReader).GetString(2);
				dBConnection.ConnectionString = ((DbDataReader)dataReader).GetString(3);
				if (!((DbDataReader)dataReader).IsDBNull(4))
				{
					dBConnection.Note = ((DbDataReader)dataReader).GetString(4);
				}
				list.Add(dBConnection);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.DBConnection> GetAll()
		{
			string sql = "SELECT * FROM DBConnection";
			OracleDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.DBConnection> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM DBConnection";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.DBConnection Get(Guid id)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "SELECT * FROM DBConnection WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.DBConnection> list = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}
	}
}
