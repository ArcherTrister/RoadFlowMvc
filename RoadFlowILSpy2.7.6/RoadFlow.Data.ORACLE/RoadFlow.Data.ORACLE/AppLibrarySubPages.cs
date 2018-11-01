using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace RoadFlow.Data.ORACLE
{
	public class AppLibrarySubPages : IAppLibrarySubPages
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.AppLibrarySubPages model)
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
			//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0100: Expected O, but got Unknown
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_010e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0119: Expected O, but got Unknown
			//IL_011a: Expected O, but got Unknown
			string sql = "INSERT INTO AppLibrarySubPages\r\n\t\t\t\t(ID,AppLibraryID,Name,Address,Ico,Sort,Note) \r\n\t\t\t\tVALUES(:ID,:AppLibraryID,:Name,:Address,:Ico,:Sort,:Note)";
			OracleParameter[] obj = new OracleParameter[7];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":AppLibraryID", 126);
			((DbParameter)val2).Value = model.AppLibraryID;
			obj[1] = val2;
			OracleParameter val3 = new OracleParameter(":Name", 126);
			((DbParameter)val3).Value = model.Name;
			obj[2] = val3;
			OracleParameter val4 = new OracleParameter(":Address", 126);
			((DbParameter)val4).Value = model.Address;
			obj[3] = val4;
			_003F val5;
			if (model.Ico != null)
			{
				val5 = new OracleParameter(":Ico", 126);
				((DbParameter)val5).Value = model.Ico;
			}
			else
			{
				val5 = new OracleParameter(":Ico", 126);
				((DbParameter)val5).Value = DBNull.Value;
			}
			obj[4] = val5;
			OracleParameter val6 = new OracleParameter(":Sort", 112);
			((DbParameter)val6).Value = model.Sort;
			obj[5] = val6;
			_003F val7;
			if (model.Note != null)
			{
				val7 = new OracleParameter(":Note", 126);
				((DbParameter)val7).Value = model.Note;
			}
			else
			{
				val7 = new OracleParameter(":Note", 126);
				((DbParameter)val7).Value = DBNull.Value;
			}
			obj[6] = val7;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.AppLibrarySubPages model)
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
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Expected O, but got Unknown
			//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f9: Expected O, but got Unknown
			//IL_00fa: Expected O, but got Unknown
			//IL_0103: Unknown result type (might be due to invalid IL or missing references)
			//IL_0108: Unknown result type (might be due to invalid IL or missing references)
			//IL_0119: Expected O, but got Unknown
			//IL_011a: Expected O, but got Unknown
			string sql = "UPDATE AppLibrarySubPages SET \r\n\t\t\t\tAppLibraryID=:AppLibraryID,Name=:Name,Address=:Address,Ico=:Ico,Sort=:Sort,Note=:Note\r\n\t\t\t\tWHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[7];
			OracleParameter val = new OracleParameter(":AppLibraryID", 126);
			((DbParameter)val).Value = model.AppLibraryID;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":Name", 126);
			((DbParameter)val2).Value = model.Name;
			obj[1] = val2;
			OracleParameter val3 = new OracleParameter(":Address", 126);
			((DbParameter)val3).Value = model.Address;
			obj[2] = val3;
			_003F val4;
			if (model.Ico != null)
			{
				val4 = new OracleParameter(":Ico", 126);
				((DbParameter)val4).Value = model.Ico;
			}
			else
			{
				val4 = new OracleParameter(":Ico", 126);
				((DbParameter)val4).Value = DBNull.Value;
			}
			obj[3] = val4;
			OracleParameter val5 = new OracleParameter(":Sort", 112);
			((DbParameter)val5).Value = model.Sort;
			obj[4] = val5;
			_003F val6;
			if (model.Note != null)
			{
				val6 = new OracleParameter(":Note", 126);
				((DbParameter)val6).Value = model.Note;
			}
			else
			{
				val6 = new OracleParameter(":Note", 126);
				((DbParameter)val6).Value = DBNull.Value;
			}
			obj[5] = val6;
			OracleParameter val7 = new OracleParameter(":ID", 126);
			((DbParameter)val7).Value = model.ID;
			obj[6] = val7;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Delete(Guid id)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "DELETE FROM AppLibrarySubPages WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.AppLibrarySubPages> DataReaderToList(OracleDataReader dataReader)
		{
			List<RoadFlow.Data.Model.AppLibrarySubPages> list = new List<RoadFlow.Data.Model.AppLibrarySubPages>();
			RoadFlow.Data.Model.AppLibrarySubPages appLibrarySubPages = null;
			while (((DbDataReader)dataReader).Read())
			{
				appLibrarySubPages = new RoadFlow.Data.Model.AppLibrarySubPages();
				appLibrarySubPages.ID = ((DbDataReader)dataReader).GetString(0).ToGuid();
				appLibrarySubPages.AppLibraryID = ((DbDataReader)dataReader).GetString(1).ToGuid();
				appLibrarySubPages.Name = ((DbDataReader)dataReader).GetString(2);
				appLibrarySubPages.Address = ((DbDataReader)dataReader).GetString(3);
				if (!((DbDataReader)dataReader).IsDBNull(4))
				{
					appLibrarySubPages.Ico = ((DbDataReader)dataReader).GetString(4);
				}
				appLibrarySubPages.Sort = ((DbDataReader)dataReader).GetInt32(5);
				if (!((DbDataReader)dataReader).IsDBNull(6))
				{
					appLibrarySubPages.Note = ((DbDataReader)dataReader).GetString(6);
				}
				list.Add(appLibrarySubPages);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.AppLibrarySubPages> GetAll()
		{
			string sql = "SELECT * FROM AppLibrarySubPages";
			OracleDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.AppLibrarySubPages> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM AppLibrarySubPages";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.AppLibrarySubPages Get(Guid id)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "SELECT * FROM AppLibrarySubPages WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.AppLibrarySubPages> list = DataReaderToList(dataReader);
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
			string sql = "DELETE FROM AppLibrarySubPages WHERE AppLibraryID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public List<RoadFlow.Data.Model.AppLibrarySubPages> GetAllByAppID(Guid id)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "SELECT * FROM AppLibrarySubPages WHERE AppLibraryID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.AppLibrarySubPages> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}
	}
}
