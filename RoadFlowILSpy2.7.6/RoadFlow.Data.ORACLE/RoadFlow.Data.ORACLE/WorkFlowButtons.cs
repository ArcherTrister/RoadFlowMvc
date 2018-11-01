using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace RoadFlow.Data.ORACLE
{
	public class WorkFlowButtons : IWorkFlowButtons
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.WorkFlowButtons model)
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Expected O, but got Unknown
			//IL_002e: Expected O, but got Unknown
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Expected O, but got Unknown
			//IL_004e: Expected O, but got Unknown
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_0075: Expected O, but got Unknown
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Expected O, but got Unknown
			//IL_0094: Expected O, but got Unknown
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b6: Expected O, but got Unknown
			//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Expected O, but got Unknown
			//IL_00d0: Expected O, but got Unknown
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f2: Expected O, but got Unknown
			//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0100: Unknown result type (might be due to invalid IL or missing references)
			//IL_010b: Expected O, but got Unknown
			//IL_010c: Expected O, but got Unknown
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_011a: Unknown result type (might be due to invalid IL or missing references)
			//IL_012b: Expected O, but got Unknown
			//IL_012c: Expected O, but got Unknown
			string sql = "INSERT INTO WorkFlowButtons\r\n\t\t\t\t(ID,Title,Ico,Script,Note,Sort) \r\n\t\t\t\tVALUES(:ID,:Title,:Ico,:Script,:Note,:Sort)";
			OracleParameter[] obj = new OracleParameter[6];
			OracleParameter val = new OracleParameter(":ID", 126, 40);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":Title", 119, 1000);
			((DbParameter)val2).Value = model.Title;
			obj[1] = val2;
			_003F val3;
			if (model.Ico != null)
			{
				val3 = new OracleParameter(":Ico", 126, 500);
				((DbParameter)val3).Value = model.Ico;
			}
			else
			{
				val3 = new OracleParameter(":Ico", 126, 500);
				((DbParameter)val3).Value = DBNull.Value;
			}
			obj[2] = val3;
			_003F val4;
			if (model.Script != null)
			{
				val4 = new OracleParameter(":Script", 105);
				((DbParameter)val4).Value = model.Script;
			}
			else
			{
				val4 = new OracleParameter(":Script", 105);
				((DbParameter)val4).Value = DBNull.Value;
			}
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
			OracleParameter val6 = new OracleParameter(":Sort", 112);
			((DbParameter)val6).Value = model.Sort;
			obj[5] = val6;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.WorkFlowButtons model)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Expected O, but got Unknown
			//IL_002c: Expected O, but got Unknown
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Expected O, but got Unknown
			//IL_0061: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Expected O, but got Unknown
			//IL_0072: Expected O, but got Unknown
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Expected O, but got Unknown
			//IL_009d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ad: Expected O, but got Unknown
			//IL_00ae: Expected O, but got Unknown
			//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d0: Expected O, but got Unknown
			//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00de: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e9: Expected O, but got Unknown
			//IL_00ea: Expected O, but got Unknown
			//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0109: Expected O, but got Unknown
			//IL_010a: Expected O, but got Unknown
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_011a: Unknown result type (might be due to invalid IL or missing references)
			//IL_012b: Expected O, but got Unknown
			//IL_012c: Expected O, but got Unknown
			string sql = "UPDATE WorkFlowButtons SET \r\n\t\t\t\tTitle=:Title,Ico=:Ico,Script=:Script,Note=:Note,Sort=:Sort\r\n\t\t\t\tWHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[6];
			OracleParameter val = new OracleParameter(":Title", 119, 1000);
			((DbParameter)val).Value = model.Title;
			obj[0] = val;
			_003F val2;
			if (model.Ico != null)
			{
				val2 = new OracleParameter(":Ico", 126, 500);
				((DbParameter)val2).Value = model.Ico;
			}
			else
			{
				val2 = new OracleParameter(":Ico", 126, 500);
				((DbParameter)val2).Value = DBNull.Value;
			}
			obj[1] = val2;
			_003F val3;
			if (model.Script != null)
			{
				val3 = new OracleParameter(":Script", 105);
				((DbParameter)val3).Value = model.Script;
			}
			else
			{
				val3 = new OracleParameter(":Script", 105);
				((DbParameter)val3).Value = DBNull.Value;
			}
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
			OracleParameter val5 = new OracleParameter(":Sort", 112);
			((DbParameter)val5).Value = model.Sort;
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
			string sql = "DELETE FROM WorkFlowButtons WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.WorkFlowButtons> DataReaderToList(OracleDataReader dataReader)
		{
			List<RoadFlow.Data.Model.WorkFlowButtons> list = new List<RoadFlow.Data.Model.WorkFlowButtons>();
			RoadFlow.Data.Model.WorkFlowButtons workFlowButtons = null;
			while (((DbDataReader)dataReader).Read())
			{
				workFlowButtons = new RoadFlow.Data.Model.WorkFlowButtons();
				workFlowButtons.ID = ((DbDataReader)dataReader).GetString(0).ToGuid();
				workFlowButtons.Title = ((DbDataReader)dataReader).GetString(1);
				if (!((DbDataReader)dataReader).IsDBNull(2))
				{
					workFlowButtons.Ico = ((DbDataReader)dataReader).GetString(2);
				}
				if (!((DbDataReader)dataReader).IsDBNull(3))
				{
					workFlowButtons.Script = ((DbDataReader)dataReader).GetString(3);
				}
				if (!((DbDataReader)dataReader).IsDBNull(4))
				{
					workFlowButtons.Note = ((DbDataReader)dataReader).GetString(4);
				}
				workFlowButtons.Sort = ((DbDataReader)dataReader).GetInt32(5);
				list.Add(workFlowButtons);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.WorkFlowButtons> GetAll()
		{
			string sql = "SELECT * FROM WorkFlowButtons";
			OracleDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.WorkFlowButtons> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM WorkFlowButtons";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.WorkFlowButtons Get(Guid id)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "SELECT * FROM WorkFlowButtons WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.WorkFlowButtons> list = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public int GetMaxSort()
		{
			string sql = "SELECT nvl(MAX(Sort),0)+1 FROM WorkFlowButtons";
			string fieldValue = dbHelper.GetFieldValue(sql);
			if (!fieldValue.IsInt())
			{
				return 1;
			}
			return fieldValue.ToInt();
		}
	}
}
