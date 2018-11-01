using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace RoadFlow.Data.ORACLE
{
	public class ProgramBuilderQuerys : IProgramBuilderQuerys
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.ProgramBuilderQuerys model)
		{
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Expected O, but got Unknown
			//IL_002d: Expected O, but got Unknown
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Expected O, but got Unknown
			//IL_004d: Expected O, but got Unknown
			//IL_0056: Unknown result type (might be due to invalid IL or missing references)
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Expected O, but got Unknown
			//IL_0068: Expected O, but got Unknown
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Expected O, but got Unknown
			//IL_0083: Expected O, but got Unknown
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_009d: Expected O, but got Unknown
			//IL_009e: Expected O, but got Unknown
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b8: Expected O, but got Unknown
			//IL_00b9: Expected O, but got Unknown
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Expected O, but got Unknown
			//IL_00d9: Expected O, but got Unknown
			//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fb: Expected O, but got Unknown
			//IL_0104: Unknown result type (might be due to invalid IL or missing references)
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0114: Expected O, but got Unknown
			//IL_0115: Expected O, but got Unknown
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_0134: Expected O, but got Unknown
			//IL_0135: Expected O, but got Unknown
			//IL_014f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0154: Unknown result type (might be due to invalid IL or missing references)
			//IL_0165: Expected O, but got Unknown
			//IL_016e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0173: Unknown result type (might be due to invalid IL or missing references)
			//IL_017e: Expected O, but got Unknown
			//IL_017f: Expected O, but got Unknown
			//IL_0191: Unknown result type (might be due to invalid IL or missing references)
			//IL_0196: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a2: Expected O, but got Unknown
			//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bb: Expected O, but got Unknown
			//IL_01bc: Expected O, but got Unknown
			//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01df: Expected O, but got Unknown
			//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f8: Expected O, but got Unknown
			//IL_01f9: Expected O, but got Unknown
			//IL_0213: Unknown result type (might be due to invalid IL or missing references)
			//IL_0218: Unknown result type (might be due to invalid IL or missing references)
			//IL_0229: Expected O, but got Unknown
			//IL_0232: Unknown result type (might be due to invalid IL or missing references)
			//IL_0237: Unknown result type (might be due to invalid IL or missing references)
			//IL_0242: Expected O, but got Unknown
			//IL_0243: Expected O, but got Unknown
			//IL_0255: Unknown result type (might be due to invalid IL or missing references)
			//IL_025a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0266: Expected O, but got Unknown
			//IL_026f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0274: Unknown result type (might be due to invalid IL or missing references)
			//IL_027f: Expected O, but got Unknown
			//IL_0280: Expected O, but got Unknown
			string sql = "INSERT INTO ProgramBuilderQuerys\r\n\t\t\t\t(ID,ProgramID,Field,ShowTitle,Operators,ControlName,InputType,Width,Sort,DataSource,DataSourceString,DataLinkID,IsQueryUsers,Value) \r\n\t\t\t\tVALUES(:ID,:ProgramID,:Field,:ShowTitle,:Operators,:ControlName,:InputType,:Width,:Sort,:DataSource,:DataSourceString,:DataLinkID,:IsQueryUsers,:Value)";
			OracleParameter[] obj = new OracleParameter[14];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":ProgramID", 126);
			((DbParameter)val2).Value = model.ProgramID;
			obj[1] = val2;
			OracleParameter val3 = new OracleParameter(":Field", 126);
			((DbParameter)val3).Value = model.Field;
			obj[2] = val3;
			OracleParameter val4 = new OracleParameter(":ShowTitle", 126);
			((DbParameter)val4).Value = model.ShowTitle;
			obj[3] = val4;
			OracleParameter val5 = new OracleParameter(":Operators", 126);
			((DbParameter)val5).Value = model.Operators;
			obj[4] = val5;
			OracleParameter val6 = new OracleParameter(":ControlName", 126);
			((DbParameter)val6).Value = model.ControlName;
			obj[5] = val6;
			OracleParameter val7 = new OracleParameter(":InputType", 112);
			((DbParameter)val7).Value = model.InputType;
			obj[6] = val7;
			_003F val8;
			if (model.Width != null)
			{
				val8 = new OracleParameter(":Width", 126);
				((DbParameter)val8).Value = model.Width;
			}
			else
			{
				val8 = new OracleParameter(":Width", 126);
				((DbParameter)val8).Value = DBNull.Value;
			}
			obj[7] = val8;
			OracleParameter val9 = new OracleParameter(":Sort", 112);
			((DbParameter)val9).Value = model.Sort;
			obj[8] = val9;
			_003F val10;
			if (model.DataSource.HasValue)
			{
				val10 = new OracleParameter(":DataSource", 112);
				((DbParameter)val10).Value = model.DataSource;
			}
			else
			{
				val10 = new OracleParameter(":DataSource", 112);
				((DbParameter)val10).Value = DBNull.Value;
			}
			obj[9] = val10;
			_003F val11;
			if (model.DataSourceString != null)
			{
				val11 = new OracleParameter(":DataSourceString", 126);
				((DbParameter)val11).Value = model.DataSourceString;
			}
			else
			{
				val11 = new OracleParameter(":DataSourceString", 126);
				((DbParameter)val11).Value = DBNull.Value;
			}
			obj[10] = val11;
			_003F val12;
			if (model.DataLinkID != null)
			{
				val12 = new OracleParameter(":DataLinkID", 126);
				((DbParameter)val12).Value = model.DataLinkID;
			}
			else
			{
				val12 = new OracleParameter(":DataLinkID", 126);
				((DbParameter)val12).Value = DBNull.Value;
			}
			obj[11] = val12;
			_003F val13;
			if (model.IsQueryUsers.HasValue)
			{
				val13 = new OracleParameter(":IsQueryUsers", 112);
				((DbParameter)val13).Value = model.IsQueryUsers;
			}
			else
			{
				val13 = new OracleParameter(":IsQueryUsers", 112);
				((DbParameter)val13).Value = DBNull.Value;
			}
			obj[12] = val13;
			_003F val14;
			if (model.Value != null)
			{
				val14 = new OracleParameter(":Value", 126);
				((DbParameter)val14).Value = model.Value;
			}
			else
			{
				val14 = new OracleParameter(":Value", 126);
				((DbParameter)val14).Value = DBNull.Value;
			}
			obj[13] = val14;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.ProgramBuilderQuerys model)
		{
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Expected O, but got Unknown
			//IL_002d: Expected O, but got Unknown
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Expected O, but got Unknown
			//IL_0048: Expected O, but got Unknown
			//IL_0051: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Unknown result type (might be due to invalid IL or missing references)
			//IL_0062: Expected O, but got Unknown
			//IL_0063: Expected O, but got Unknown
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Expected O, but got Unknown
			//IL_007e: Expected O, but got Unknown
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0098: Expected O, but got Unknown
			//IL_0099: Expected O, but got Unknown
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b8: Expected O, but got Unknown
			//IL_00b9: Expected O, but got Unknown
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00db: Expected O, but got Unknown
			//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f4: Expected O, but got Unknown
			//IL_00f5: Expected O, but got Unknown
			//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0104: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Expected O, but got Unknown
			//IL_0116: Expected O, but got Unknown
			//IL_012f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0134: Unknown result type (might be due to invalid IL or missing references)
			//IL_0145: Expected O, but got Unknown
			//IL_014e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0153: Unknown result type (might be due to invalid IL or missing references)
			//IL_015e: Expected O, but got Unknown
			//IL_015f: Expected O, but got Unknown
			//IL_0171: Unknown result type (might be due to invalid IL or missing references)
			//IL_0176: Unknown result type (might be due to invalid IL or missing references)
			//IL_0182: Expected O, but got Unknown
			//IL_018b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0190: Unknown result type (might be due to invalid IL or missing references)
			//IL_019b: Expected O, but got Unknown
			//IL_019c: Expected O, but got Unknown
			//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bf: Expected O, but got Unknown
			//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d8: Expected O, but got Unknown
			//IL_01d9: Expected O, but got Unknown
			//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0209: Expected O, but got Unknown
			//IL_0212: Unknown result type (might be due to invalid IL or missing references)
			//IL_0217: Unknown result type (might be due to invalid IL or missing references)
			//IL_0222: Expected O, but got Unknown
			//IL_0223: Expected O, but got Unknown
			//IL_0235: Unknown result type (might be due to invalid IL or missing references)
			//IL_023a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0246: Expected O, but got Unknown
			//IL_024f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0254: Unknown result type (might be due to invalid IL or missing references)
			//IL_025f: Expected O, but got Unknown
			//IL_0260: Expected O, but got Unknown
			//IL_026a: Unknown result type (might be due to invalid IL or missing references)
			//IL_026f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0280: Expected O, but got Unknown
			//IL_0281: Expected O, but got Unknown
			string sql = "UPDATE ProgramBuilderQuerys SET \r\n\t\t\t\tProgramID=:ProgramID,Field=:Field,ShowTitle=:ShowTitle,Operators=:Operators,ControlName=:ControlName,InputType=:InputType,Width=:Width,Sort=:Sort,DataSource=:DataSource,DataSourceString=:DataSourceString,DataLinkID=:DataLinkID,IsQueryUsers=:IsQueryUsers,Value=:Value\r\n\t\t\t\tWHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[14];
			OracleParameter val = new OracleParameter(":ProgramID", 126);
			((DbParameter)val).Value = model.ProgramID;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":Field", 126);
			((DbParameter)val2).Value = model.Field;
			obj[1] = val2;
			OracleParameter val3 = new OracleParameter(":ShowTitle", 126);
			((DbParameter)val3).Value = model.ShowTitle;
			obj[2] = val3;
			OracleParameter val4 = new OracleParameter(":Operators", 126);
			((DbParameter)val4).Value = model.Operators;
			obj[3] = val4;
			OracleParameter val5 = new OracleParameter(":ControlName", 126);
			((DbParameter)val5).Value = model.ControlName;
			obj[4] = val5;
			OracleParameter val6 = new OracleParameter(":InputType", 112);
			((DbParameter)val6).Value = model.InputType;
			obj[5] = val6;
			_003F val7;
			if (model.Width != null)
			{
				val7 = new OracleParameter(":Width", 126);
				((DbParameter)val7).Value = model.Width;
			}
			else
			{
				val7 = new OracleParameter(":Width", 126);
				((DbParameter)val7).Value = DBNull.Value;
			}
			obj[6] = val7;
			OracleParameter val8 = new OracleParameter(":Sort", 112, -1);
			((DbParameter)val8).Value = model.Sort;
			obj[7] = val8;
			_003F val9;
			if (model.DataSource.HasValue)
			{
				val9 = new OracleParameter(":DataSource", 112);
				((DbParameter)val9).Value = model.DataSource;
			}
			else
			{
				val9 = new OracleParameter(":DataSource", 112);
				((DbParameter)val9).Value = DBNull.Value;
			}
			obj[8] = val9;
			_003F val10;
			if (model.DataSourceString != null)
			{
				val10 = new OracleParameter(":DataSourceString", 126);
				((DbParameter)val10).Value = model.DataSourceString;
			}
			else
			{
				val10 = new OracleParameter(":DataSourceString", 126);
				((DbParameter)val10).Value = DBNull.Value;
			}
			obj[9] = val10;
			_003F val11;
			if (model.DataLinkID != null)
			{
				val11 = new OracleParameter(":DataLinkID", 126);
				((DbParameter)val11).Value = model.DataLinkID;
			}
			else
			{
				val11 = new OracleParameter(":DataLinkID", 126);
				((DbParameter)val11).Value = DBNull.Value;
			}
			obj[10] = val11;
			_003F val12;
			if (model.IsQueryUsers.HasValue)
			{
				val12 = new OracleParameter(":IsQueryUsers", 112);
				((DbParameter)val12).Value = model.IsQueryUsers;
			}
			else
			{
				val12 = new OracleParameter(":IsQueryUsers", 112);
				((DbParameter)val12).Value = DBNull.Value;
			}
			obj[11] = val12;
			_003F val13;
			if (model.Value != null)
			{
				val13 = new OracleParameter(":Value", 126);
				((DbParameter)val13).Value = model.Value;
			}
			else
			{
				val13 = new OracleParameter(":Value", 126);
				((DbParameter)val13).Value = DBNull.Value;
			}
			obj[12] = val13;
			OracleParameter val14 = new OracleParameter(":ID", 126);
			((DbParameter)val14).Value = model.ID;
			obj[13] = val14;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Delete(Guid id)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "DELETE FROM ProgramBuilderQuerys WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.ProgramBuilderQuerys> DataReaderToList(OracleDataReader dataReader)
		{
			List<RoadFlow.Data.Model.ProgramBuilderQuerys> list = new List<RoadFlow.Data.Model.ProgramBuilderQuerys>();
			RoadFlow.Data.Model.ProgramBuilderQuerys programBuilderQuerys = null;
			while (((DbDataReader)dataReader).Read())
			{
				programBuilderQuerys = new RoadFlow.Data.Model.ProgramBuilderQuerys();
				programBuilderQuerys.ID = ((DbDataReader)dataReader).GetString(0).ToGuid();
				programBuilderQuerys.ProgramID = ((DbDataReader)dataReader).GetString(1).ToGuid();
				programBuilderQuerys.Field = ((DbDataReader)dataReader).GetString(2);
				programBuilderQuerys.ShowTitle = ((DbDataReader)dataReader).GetString(3);
				programBuilderQuerys.Operators = ((DbDataReader)dataReader).GetString(4);
				programBuilderQuerys.ControlName = ((DbDataReader)dataReader).GetString(5);
				programBuilderQuerys.InputType = ((DbDataReader)dataReader).GetInt32(6);
				if (!((DbDataReader)dataReader).IsDBNull(7))
				{
					programBuilderQuerys.Width = ((DbDataReader)dataReader).GetString(7);
				}
				programBuilderQuerys.Sort = ((DbDataReader)dataReader).GetInt32(8);
				if (!((DbDataReader)dataReader).IsDBNull(9))
				{
					programBuilderQuerys.DataSource = ((DbDataReader)dataReader).GetInt32(9);
				}
				if (!((DbDataReader)dataReader).IsDBNull(10))
				{
					programBuilderQuerys.DataSourceString = ((DbDataReader)dataReader).GetString(10);
				}
				if (!((DbDataReader)dataReader).IsDBNull(11))
				{
					programBuilderQuerys.DataLinkID = ((DbDataReader)dataReader).GetString(11);
				}
				if (!((DbDataReader)dataReader).IsDBNull(12))
				{
					programBuilderQuerys.IsQueryUsers = ((DbDataReader)dataReader).GetInt32(12);
				}
				if (!((DbDataReader)dataReader).IsDBNull(13))
				{
					programBuilderQuerys.Value = ((DbDataReader)dataReader).GetString(13);
				}
				list.Add(programBuilderQuerys);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.ProgramBuilderQuerys> GetAll()
		{
			string sql = "SELECT * FROM ProgramBuilderQuerys";
			OracleDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.ProgramBuilderQuerys> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM ProgramBuilderQuerys";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.ProgramBuilderQuerys Get(Guid id)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "SELECT * FROM ProgramBuilderQuerys WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.ProgramBuilderQuerys> list = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public List<RoadFlow.Data.Model.ProgramBuilderQuerys> GetAll(Guid programID)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "SELECT * FROM ProgramBuilderQuerys WHERE ProgramID=:ProgramID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ProgramID", 126);
			((DbParameter)val).Value = programID;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.ProgramBuilderQuerys> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public int DeleteByProgramID(Guid id)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "DELETE FROM ProgramBuilderQuerys WHERE ProgramID=:ProgramID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ProgramID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}
	}
}
