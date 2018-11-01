using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace RoadFlow.Data.ORACLE
{
	public class AppLibraryButtons1 : IAppLibraryButtons1
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.AppLibraryButtons1 model)
		{
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Expected O, but got Unknown
			//IL_002d: Expected O, but got Unknown
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Expected O, but got Unknown
			//IL_004d: Expected O, but got Unknown
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_007c: Expected O, but got Unknown
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Expected O, but got Unknown
			//IL_0096: Expected O, but got Unknown
			//IL_009f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b0: Expected O, but got Unknown
			//IL_00b1: Expected O, but got Unknown
			//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cb: Expected O, but got Unknown
			//IL_00cc: Expected O, but got Unknown
			//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Expected O, but got Unknown
			//IL_00e7: Expected O, but got Unknown
			//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0106: Expected O, but got Unknown
			//IL_0107: Expected O, but got Unknown
			//IL_0110: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0126: Expected O, but got Unknown
			//IL_0127: Expected O, but got Unknown
			//IL_0130: Unknown result type (might be due to invalid IL or missing references)
			//IL_0135: Unknown result type (might be due to invalid IL or missing references)
			//IL_0146: Expected O, but got Unknown
			//IL_0147: Expected O, but got Unknown
			//IL_0151: Unknown result type (might be due to invalid IL or missing references)
			//IL_0156: Unknown result type (might be due to invalid IL or missing references)
			//IL_0167: Expected O, but got Unknown
			//IL_0168: Expected O, but got Unknown
			string sql = "INSERT INTO AppLibraryButtons1\r\n\t\t\t\t(ID,AppLibraryID,ButtonID,Name,Events,Ico,Sort,Type,ShowType,IsValidateShow) \r\n\t\t\t\tVALUES(:ID,:AppLibraryID,:ButtonID,:Name,:Events,:Ico,:Sort,:Type,:ShowType,:IsValidateShow)";
			OracleParameter[] obj = new OracleParameter[10];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":AppLibraryID", 126);
			((DbParameter)val2).Value = model.AppLibraryID;
			obj[1] = val2;
			_003F val3;
			if (model.ButtonID.HasValue)
			{
				val3 = new OracleParameter(":ButtonID", 126);
				((DbParameter)val3).Value = model.ButtonID;
			}
			else
			{
				val3 = new OracleParameter(":ButtonID", 126);
				((DbParameter)val3).Value = DBNull.Value;
			}
			obj[2] = val3;
			OracleParameter val4 = new OracleParameter(":Name", 126);
			((DbParameter)val4).Value = model.Name;
			obj[3] = val4;
			OracleParameter val5 = new OracleParameter(":Events", 126);
			((DbParameter)val5).Value = model.Events;
			obj[4] = val5;
			OracleParameter val6 = new OracleParameter(":Ico", 126);
			((DbParameter)val6).Value = model.Ico;
			obj[5] = val6;
			OracleParameter val7 = new OracleParameter(":Sort", 112);
			((DbParameter)val7).Value = model.Sort;
			obj[6] = val7;
			OracleParameter val8 = new OracleParameter(":Type", 112);
			((DbParameter)val8).Value = model.Type;
			obj[7] = val8;
			OracleParameter val9 = new OracleParameter(":ShowType", 112);
			((DbParameter)val9).Value = model.ShowType;
			obj[8] = val9;
			OracleParameter val10 = new OracleParameter(":IsValidateShow", 112);
			((DbParameter)val10).Value = model.IsValidateShow;
			obj[9] = val10;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.AppLibraryButtons1 model)
		{
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Expected O, but got Unknown
			//IL_002d: Expected O, but got Unknown
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Expected O, but got Unknown
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0075: Expected O, but got Unknown
			//IL_0076: Expected O, but got Unknown
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Expected O, but got Unknown
			//IL_0091: Expected O, but got Unknown
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_009f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ab: Expected O, but got Unknown
			//IL_00ac: Expected O, but got Unknown
			//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
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
			//IL_0126: Expected O, but got Unknown
			//IL_0127: Expected O, but got Unknown
			//IL_0130: Unknown result type (might be due to invalid IL or missing references)
			//IL_0135: Unknown result type (might be due to invalid IL or missing references)
			//IL_0146: Expected O, but got Unknown
			//IL_0147: Expected O, but got Unknown
			//IL_0151: Unknown result type (might be due to invalid IL or missing references)
			//IL_0156: Unknown result type (might be due to invalid IL or missing references)
			//IL_0167: Expected O, but got Unknown
			//IL_0168: Expected O, but got Unknown
			string sql = "UPDATE AppLibraryButtons1 SET \r\n\t\t\t\tAppLibraryID=:AppLibraryID,ButtonID=:ButtonID,Name=:Name,Events=:Events,Ico=:Ico,Sort=:Sort,Type=:Type,ShowType=:ShowType,IsValidateShow=:IsValidateShow\r\n\t\t\t\tWHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[10];
			OracleParameter val = new OracleParameter(":AppLibraryID", 126);
			((DbParameter)val).Value = model.AppLibraryID;
			obj[0] = val;
			_003F val2;
			if (model.ButtonID.HasValue)
			{
				val2 = new OracleParameter(":ButtonID", 126);
				((DbParameter)val2).Value = model.ButtonID;
			}
			else
			{
				val2 = new OracleParameter(":ButtonID", 126);
				((DbParameter)val2).Value = DBNull.Value;
			}
			obj[1] = val2;
			OracleParameter val3 = new OracleParameter(":Name", 126);
			((DbParameter)val3).Value = model.Name;
			obj[2] = val3;
			OracleParameter val4 = new OracleParameter(":Events", 126);
			((DbParameter)val4).Value = model.Events;
			obj[3] = val4;
			OracleParameter val5 = new OracleParameter(":Ico", 126);
			((DbParameter)val5).Value = model.Ico;
			obj[4] = val5;
			OracleParameter val6 = new OracleParameter(":Sort", 112);
			((DbParameter)val6).Value = model.Sort;
			obj[5] = val6;
			OracleParameter val7 = new OracleParameter(":Type", 112);
			((DbParameter)val7).Value = model.Type;
			obj[6] = val7;
			OracleParameter val8 = new OracleParameter(":ShowType", 112);
			((DbParameter)val8).Value = model.ShowType;
			obj[7] = val8;
			OracleParameter val9 = new OracleParameter(":IsValidateShow", 112);
			((DbParameter)val9).Value = model.IsValidateShow;
			obj[8] = val9;
			OracleParameter val10 = new OracleParameter(":ID", 126);
			((DbParameter)val10).Value = model.ID;
			obj[9] = val10;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Delete(Guid id)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "DELETE FROM AppLibraryButtons1 WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.AppLibraryButtons1> DataReaderToList(OracleDataReader dataReader)
		{
			List<RoadFlow.Data.Model.AppLibraryButtons1> list = new List<RoadFlow.Data.Model.AppLibraryButtons1>();
			RoadFlow.Data.Model.AppLibraryButtons1 appLibraryButtons = null;
			while (((DbDataReader)dataReader).Read())
			{
				appLibraryButtons = new RoadFlow.Data.Model.AppLibraryButtons1();
				appLibraryButtons.ID = ((DbDataReader)dataReader).GetString(0).ToGuid();
				appLibraryButtons.AppLibraryID = ((DbDataReader)dataReader).GetString(1).ToGuid();
				if (!((DbDataReader)dataReader).IsDBNull(2))
				{
					appLibraryButtons.ButtonID = ((DbDataReader)dataReader).GetString(2).ToGuid();
				}
				appLibraryButtons.Name = ((DbDataReader)dataReader).GetString(3);
				appLibraryButtons.Events = ((DbDataReader)dataReader).GetString(4);
				if (!((DbDataReader)dataReader).IsDBNull(5))
				{
					appLibraryButtons.Ico = ((DbDataReader)dataReader).GetString(5);
				}
				appLibraryButtons.Sort = ((DbDataReader)dataReader).GetInt32(6);
				appLibraryButtons.Type = ((DbDataReader)dataReader).GetInt32(7);
				appLibraryButtons.ShowType = ((DbDataReader)dataReader).GetInt32(8);
				appLibraryButtons.IsValidateShow = ((DbDataReader)dataReader).GetInt32(9);
				list.Add(appLibraryButtons);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.AppLibraryButtons1> GetAll()
		{
			string sql = "SELECT * FROM AppLibraryButtons1";
			OracleDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.AppLibraryButtons1> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM AppLibraryButtons1";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.AppLibraryButtons1 Get(Guid id)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "SELECT * FROM AppLibraryButtons1 WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.AppLibraryButtons1> list = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public int DeleteByAppID(Guid id)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "DELETE FROM AppLibraryButtons1 WHERE AppLibraryID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public List<RoadFlow.Data.Model.AppLibraryButtons1> GetAllByAppID(Guid id)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "SELECT * FROM AppLibraryButtons1 WHERE AppLibraryID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.AppLibraryButtons1> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}
	}
}
