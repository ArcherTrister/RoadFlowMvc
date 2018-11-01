using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace RoadFlow.Data.ORACLE
{
	public class MenuUser : IMenuUser
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.MenuUser model)
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
			//IL_0086: Expected O, but got Unknown
			//IL_0087: Expected O, but got Unknown
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a1: Expected O, but got Unknown
			//IL_00a2: Expected O, but got Unknown
			//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c4: Expected O, but got Unknown
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dd: Expected O, but got Unknown
			//IL_00de: Expected O, but got Unknown
			string sql = "INSERT INTO MenuUser\r\n\t\t\t\t(ID,MenuID,SubPageID,Organizes,Users,Buttons) \r\n\t\t\t\tVALUES(:ID,:MenuID,:SubPageID,:Organizes,:Users,:Buttons)";
			OracleParameter[] obj = new OracleParameter[6];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":MenuID", 126);
			((DbParameter)val2).Value = model.MenuID;
			obj[1] = val2;
			OracleParameter val3 = new OracleParameter(":SubPageID", 126);
			((DbParameter)val3).Value = model.SubPageID;
			obj[2] = val3;
			OracleParameter val4 = new OracleParameter(":Organizes", 126);
			((DbParameter)val4).Value = model.Organizes;
			obj[3] = val4;
			OracleParameter val5 = new OracleParameter(":Users", 126);
			((DbParameter)val5).Value = model.Users;
			obj[4] = val5;
			_003F val6;
			if (model.Buttons != null)
			{
				val6 = new OracleParameter(":Buttons", 126);
				((DbParameter)val6).Value = model.Buttons;
			}
			else
			{
				val6 = new OracleParameter(":Buttons", 126);
				((DbParameter)val6).Value = DBNull.Value;
			}
			obj[5] = val6;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.MenuUser model)
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
			string sql = "UPDATE MenuUser SET \r\n\t\t\t\tMenuID=:MenuID,SubPageID=:SubPageID,Organizes=:Organizes,Users=:Users,Buttons=:Buttons\r\n\t\t\t\tWHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[6];
			OracleParameter val = new OracleParameter(":MenuID", 126);
			((DbParameter)val).Value = model.MenuID;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":SubPageID", 126);
			((DbParameter)val2).Value = model.SubPageID;
			obj[1] = val2;
			OracleParameter val3 = new OracleParameter(":Organizes", 126);
			((DbParameter)val3).Value = model.Organizes;
			obj[2] = val3;
			OracleParameter val4 = new OracleParameter(":Users", 126);
			((DbParameter)val4).Value = model.Users;
			obj[3] = val4;
			_003F val5;
			if (model.Buttons != null)
			{
				val5 = new OracleParameter(":Buttons", 126);
				((DbParameter)val5).Value = model.Buttons;
			}
			else
			{
				val5 = new OracleParameter(":Buttons", 126);
				((DbParameter)val5).Value = DBNull.Value;
			}
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
			string sql = "DELETE FROM MenuUser WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.MenuUser> DataReaderToList(OracleDataReader dataReader)
		{
			List<RoadFlow.Data.Model.MenuUser> list = new List<RoadFlow.Data.Model.MenuUser>();
			RoadFlow.Data.Model.MenuUser menuUser = null;
			while (((DbDataReader)dataReader).Read())
			{
				menuUser = new RoadFlow.Data.Model.MenuUser();
				menuUser.ID = ((DbDataReader)dataReader).GetString(0).ToGuid();
				menuUser.MenuID = ((DbDataReader)dataReader).GetString(1).ToGuid();
				menuUser.SubPageID = ((DbDataReader)dataReader).GetString(2).ToGuid();
				menuUser.Organizes = ((DbDataReader)dataReader).GetString(3);
				menuUser.Users = ((DbDataReader)dataReader).GetString(4);
				if (!((DbDataReader)dataReader).IsDBNull(5))
				{
					menuUser.Buttons = ((DbDataReader)dataReader).GetString(5);
				}
				list.Add(menuUser);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.MenuUser> GetAll()
		{
			string sql = "SELECT * FROM MenuUser";
			OracleDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.MenuUser> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM MenuUser";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.MenuUser Get(Guid id)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "SELECT * FROM MenuUser WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.MenuUser> list = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public int DeleteByOrganizes(string organizes)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0021: Expected O, but got Unknown
			//IL_0022: Expected O, but got Unknown
			string sql = "DELETE FROM MenuUser WHERE Organizes=:Organizes";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":Organizes", 126);
			((DbParameter)val).Value = organizes;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int DeleteByMenuID(Guid menuID)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Expected O, but got Unknown
			//IL_002e: Expected O, but got Unknown
			string sql = "DELETE FROM MenuUser WHERE MenuID=:MenuID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":MenuID", 126);
			((DbParameter)val).Value = menuID.ToString();
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}
	}
}
