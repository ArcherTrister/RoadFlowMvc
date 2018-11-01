using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace RoadFlow.Data.ORACLE
{
	public class UserShortcut : IUserShortcut
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.UserShortcut model)
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
			//IL_006b: Expected O, but got Unknown
			//IL_006c: Expected O, but got Unknown
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Expected O, but got Unknown
			//IL_008c: Expected O, but got Unknown
			string sql = "INSERT INTO UserShortcut\r\n\t\t\t\t(ID,MenuID,UserID,Sort) \r\n\t\t\t\tVALUES(:ID,:MenuID,:UserID,:Sort)";
			OracleParameter[] obj = new OracleParameter[4];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":MenuID", 126);
			((DbParameter)val2).Value = model.MenuID;
			obj[1] = val2;
			OracleParameter val3 = new OracleParameter(":UserID", 126);
			((DbParameter)val3).Value = model.UserID;
			obj[2] = val3;
			OracleParameter val4 = new OracleParameter(":Sort", 112);
			((DbParameter)val4).Value = model.Sort;
			obj[3] = val4;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.UserShortcut model)
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
			//IL_006b: Expected O, but got Unknown
			//IL_006c: Expected O, but got Unknown
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Expected O, but got Unknown
			//IL_008c: Expected O, but got Unknown
			string sql = "UPDATE UserShortcut SET \r\n\t\t\t\tMenuID=:MenuID,UserID=:UserID,Sort=:Sort\r\n\t\t\t\tWHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[4];
			OracleParameter val = new OracleParameter(":MenuID", 126);
			((DbParameter)val).Value = model.MenuID;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":UserID", 126);
			((DbParameter)val2).Value = model.UserID;
			obj[1] = val2;
			OracleParameter val3 = new OracleParameter(":Sort", 112);
			((DbParameter)val3).Value = model.Sort;
			obj[2] = val3;
			OracleParameter val4 = new OracleParameter(":ID", 126);
			((DbParameter)val4).Value = model.ID;
			obj[3] = val4;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Delete(Guid id)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "DELETE FROM UserShortcut WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.UserShortcut> DataReaderToList(OracleDataReader dataReader)
		{
			List<RoadFlow.Data.Model.UserShortcut> list = new List<RoadFlow.Data.Model.UserShortcut>();
			RoadFlow.Data.Model.UserShortcut userShortcut = null;
			while (((DbDataReader)dataReader).Read())
			{
				userShortcut = new RoadFlow.Data.Model.UserShortcut();
				userShortcut.ID = ((DbDataReader)dataReader).GetString(0).ToGuid();
				userShortcut.MenuID = ((DbDataReader)dataReader).GetString(1).ToGuid();
				userShortcut.UserID = ((DbDataReader)dataReader).GetString(2).ToGuid();
				userShortcut.Sort = ((DbDataReader)dataReader).GetInt32(3);
				list.Add(userShortcut);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.UserShortcut> GetAll()
		{
			string sql = "SELECT * FROM UserShortcut";
			OracleDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.UserShortcut> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM UserShortcut";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.UserShortcut Get(Guid id)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "SELECT * FROM UserShortcut WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.UserShortcut> list = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public int DeleteByUserID(Guid userID)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "DELETE FROM UserShortcut WHERE UserID=:UserID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":UserID", 126);
			((DbParameter)val).Value = userID;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public List<RoadFlow.Data.Model.UserShortcut> GetAllByUserID(Guid userID)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "SELECT * FROM UserShortcut WHERE UserID=:UserID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":UserID", 126);
			((DbParameter)val).Value = userID;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.UserShortcut> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public DataTable GetDataTableByUserID(Guid userID)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "SELECT * FROM UserShortcut WHERE UserID=:UserID ORDER BY Sort";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":UserID", 126);
			((DbParameter)val).Value = userID;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.GetDataTable(sql, parameter);
		}

		public int DeleteByMenuID(Guid menuID)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Expected O, but got Unknown
			//IL_002e: Expected O, but got Unknown
			string sql = "DELETE FROM UserShortcut WHERE MenuID=:MenuID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":MenuID", 126);
			((DbParameter)val).Value = menuID.ToString();
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}
	}
}
