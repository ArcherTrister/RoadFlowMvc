using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace RoadFlow.Data.ORACLE
{
	public class ProgramBuilderValidates : IProgramBuilderValidates
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.ProgramBuilderValidates model)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Expected O, but got Unknown
			//IL_002c: Expected O, but got Unknown
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Expected O, but got Unknown
			//IL_004c: Expected O, but got Unknown
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Expected O, but got Unknown
			//IL_0067: Expected O, but got Unknown
			//IL_0070: Unknown result type (might be due to invalid IL or missing references)
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Expected O, but got Unknown
			//IL_0082: Expected O, but got Unknown
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a4: Expected O, but got Unknown
			//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bd: Expected O, but got Unknown
			//IL_00be: Expected O, but got Unknown
			//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dd: Expected O, but got Unknown
			//IL_00de: Expected O, but got Unknown
			string sql = "INSERT INTO ProgramBuilderValidates\r\n\t\t\t\t(ID,ProgramID,TableName,FieldName,FieldNote,Validate1) \r\n\t\t\t\tVALUES(:ID,:ProgramID,:TableName,:FieldName,:FieldNote,:Validate1)";
			OracleParameter[] obj = new OracleParameter[6];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":ProgramID", 126);
			((DbParameter)val2).Value = model.ProgramID;
			obj[1] = val2;
			OracleParameter val3 = new OracleParameter(":TableName", 126);
			((DbParameter)val3).Value = model.TableName;
			obj[2] = val3;
			OracleParameter val4 = new OracleParameter(":FieldName", 126);
			((DbParameter)val4).Value = model.FieldName;
			obj[3] = val4;
			_003F val5;
			if (model.FieldNote != null)
			{
				val5 = new OracleParameter(":FieldNote", 126);
				((DbParameter)val5).Value = model.FieldNote;
			}
			else
			{
				val5 = new OracleParameter(":FieldNote", 126);
				((DbParameter)val5).Value = DBNull.Value;
			}
			obj[4] = val5;
			OracleParameter val6 = new OracleParameter(":Validate1", 112);
			((DbParameter)val6).Value = model.Validate;
			obj[5] = val6;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.ProgramBuilderValidates model)
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
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Expected O, but got Unknown
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_009d: Expected O, but got Unknown
			//IL_009e: Expected O, but got Unknown
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bd: Expected O, but got Unknown
			//IL_00be: Expected O, but got Unknown
			//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dd: Expected O, but got Unknown
			//IL_00de: Expected O, but got Unknown
			string sql = "UPDATE ProgramBuilderValidates SET \r\n\t\t\t\tProgramID=:ProgramID,TableName=:TableName,FieldName=:FieldName,FieldNote=:FieldNote,Validate1=:Validate1\r\n\t\t\t\tWHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[6];
			OracleParameter val = new OracleParameter(":ProgramID", 126);
			((DbParameter)val).Value = model.ProgramID;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":TableName", 126);
			((DbParameter)val2).Value = model.TableName;
			obj[1] = val2;
			OracleParameter val3 = new OracleParameter(":FieldName", 126);
			((DbParameter)val3).Value = model.FieldName;
			obj[2] = val3;
			_003F val4;
			if (model.FieldNote != null)
			{
				val4 = new OracleParameter(":FieldNote", 126);
				((DbParameter)val4).Value = model.FieldNote;
			}
			else
			{
				val4 = new OracleParameter(":FieldNote", 126);
				((DbParameter)val4).Value = DBNull.Value;
			}
			obj[3] = val4;
			OracleParameter val5 = new OracleParameter(":Validate1", 112);
			((DbParameter)val5).Value = model.Validate;
			obj[4] = val5;
			OracleParameter val6 = new OracleParameter(":ID", 126);
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
			string sql = "DELETE FROM ProgramBuilderValidates WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.ProgramBuilderValidates> DataReaderToList(OracleDataReader dataReader)
		{
			List<RoadFlow.Data.Model.ProgramBuilderValidates> list = new List<RoadFlow.Data.Model.ProgramBuilderValidates>();
			RoadFlow.Data.Model.ProgramBuilderValidates programBuilderValidates = null;
			while (((DbDataReader)dataReader).Read())
			{
				programBuilderValidates = new RoadFlow.Data.Model.ProgramBuilderValidates();
				programBuilderValidates.ID = ((DbDataReader)dataReader).GetString(0).ToGuid();
				programBuilderValidates.ProgramID = ((DbDataReader)dataReader).GetString(1).ToGuid();
				programBuilderValidates.TableName = ((DbDataReader)dataReader).GetString(2);
				programBuilderValidates.FieldName = ((DbDataReader)dataReader).GetString(3);
				if (!((DbDataReader)dataReader).IsDBNull(4))
				{
					programBuilderValidates.FieldNote = ((DbDataReader)dataReader).GetString(4);
				}
				programBuilderValidates.Validate = ((DbDataReader)dataReader).GetInt32(5);
				list.Add(programBuilderValidates);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.ProgramBuilderValidates> GetAll()
		{
			string sql = "SELECT * FROM ProgramBuilderValidates";
			OracleDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.ProgramBuilderValidates> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM ProgramBuilderValidates";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.ProgramBuilderValidates Get(Guid id)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "SELECT * FROM ProgramBuilderValidates WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.ProgramBuilderValidates> list = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public List<RoadFlow.Data.Model.ProgramBuilderValidates> GetAll(Guid programID)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "SELECT * FROM ProgramBuilderValidates WHERE ProgramID=:ProgramID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ProgramID", 126);
			((DbParameter)val).Value = programID;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.ProgramBuilderValidates> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public int DeleteByProgramID(Guid id)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "DELETE FROM ProgramBuilderValidates WHERE ProgramID=:ProgramID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ProgramID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}
	}
}
