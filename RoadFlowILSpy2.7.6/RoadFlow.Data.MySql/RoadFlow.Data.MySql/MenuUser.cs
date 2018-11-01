using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace RoadFlow.Data.MySql
{
	public class MenuUser : IMenuUser
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.MenuUser model)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Expected O, but got Unknown
			//IL_0056: Expected O, but got Unknown
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Expected O, but got Unknown
			//IL_007b: Expected O, but got Unknown
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_009a: Expected O, but got Unknown
			//IL_009b: Expected O, but got Unknown
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Expected O, but got Unknown
			//IL_00ba: Expected O, but got Unknown
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Expected O, but got Unknown
			//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fd: Expected O, but got Unknown
			//IL_00fe: Expected O, but got Unknown
			//IL_0113: Unknown result type (might be due to invalid IL or missing references)
			//IL_0118: Unknown result type (might be due to invalid IL or missing references)
			//IL_0124: Expected O, but got Unknown
			//IL_0131: Unknown result type (might be due to invalid IL or missing references)
			//IL_0136: Unknown result type (might be due to invalid IL or missing references)
			//IL_0141: Expected O, but got Unknown
			//IL_0142: Expected O, but got Unknown
			string sql = "INSERT INTO menuuser\r\n\t\t\t\t(ID,MenuID,SubPageID,Organizes,Users,Buttons,Params) \r\n\t\t\t\tVALUES(@ID,@MenuID,@SubPageID,@Organizes,@Users,@Buttons,@Params)";
			MySqlParameter[] obj = new MySqlParameter[7];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@MenuID", 253, 36);
			((DbParameter)val2).Value = model.MenuID;
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@SubPageID", 253, 36);
			((DbParameter)val3).Value = model.SubPageID;
			obj[2] = val3;
			MySqlParameter val4 = new MySqlParameter("@Organizes", 253, 100);
			((DbParameter)val4).Value = model.Organizes;
			obj[3] = val4;
			MySqlParameter val5 = new MySqlParameter("@Users", 751, -1);
			((DbParameter)val5).Value = model.Users;
			obj[4] = val5;
			_003F val6;
			if (model.Buttons != null)
			{
				val6 = new MySqlParameter("@Buttons", 751, -1);
				((DbParameter)val6).Value = model.Buttons;
			}
			else
			{
				val6 = new MySqlParameter("@Buttons", 751, -1);
				((DbParameter)val6).Value = DBNull.Value;
			}
			obj[5] = val6;
			_003F val7;
			if (model.Params != null)
			{
				val7 = new MySqlParameter("@Params", 751, -1);
				((DbParameter)val7).Value = model.Params;
			}
			else
			{
				val7 = new MySqlParameter("@Params", 751, -1);
				((DbParameter)val7).Value = DBNull.Value;
			}
			obj[6] = val7;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.MenuUser model)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Expected O, but got Unknown
			//IL_0056: Expected O, but got Unknown
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_0075: Expected O, but got Unknown
			//IL_0076: Expected O, but got Unknown
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Expected O, but got Unknown
			//IL_0095: Expected O, but got Unknown
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bb: Expected O, but got Unknown
			//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Expected O, but got Unknown
			//IL_00d9: Expected O, but got Unknown
			//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ff: Expected O, but got Unknown
			//IL_010c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			//IL_011c: Expected O, but got Unknown
			//IL_011d: Expected O, but got Unknown
			//IL_012b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0130: Unknown result type (might be due to invalid IL or missing references)
			//IL_0141: Expected O, but got Unknown
			//IL_0142: Expected O, but got Unknown
			string sql = "UPDATE menuuser SET \r\n\t\t\t\tMenuID=@MenuID,SubPageID=@SubPageID,Organizes=@Organizes,Users=@Users,Buttons=@Buttons,Params=@Params\r\n\t\t\t\tWHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[7];
			MySqlParameter val = new MySqlParameter("@MenuID", 253, 36);
			((DbParameter)val).Value = model.MenuID;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@SubPageID", 253, 36);
			((DbParameter)val2).Value = model.SubPageID;
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@Organizes", 253, 100);
			((DbParameter)val3).Value = model.Organizes;
			obj[2] = val3;
			MySqlParameter val4 = new MySqlParameter("@Users", 751, -1);
			((DbParameter)val4).Value = model.Users;
			obj[3] = val4;
			_003F val5;
			if (model.Buttons != null)
			{
				val5 = new MySqlParameter("@Buttons", 751, -1);
				((DbParameter)val5).Value = model.Buttons;
			}
			else
			{
				val5 = new MySqlParameter("@Buttons", 751, -1);
				((DbParameter)val5).Value = DBNull.Value;
			}
			obj[4] = val5;
			_003F val6;
			if (model.Params != null)
			{
				val6 = new MySqlParameter("@Params", 751, -1);
				((DbParameter)val6).Value = model.Params;
			}
			else
			{
				val6 = new MySqlParameter("@Params", 751, -1);
				((DbParameter)val6).Value = DBNull.Value;
			}
			obj[5] = val6;
			MySqlParameter val7 = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val7).Value = model.ID;
			obj[6] = val7;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Delete(Guid id)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Expected O, but got Unknown
			string sql = "DELETE FROM menuuser WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.MenuUser> DataReaderToList(MySqlDataReader dataReader)
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
				if (!((DbDataReader)dataReader).IsDBNull(6))
				{
					menuUser.Params = ((DbDataReader)dataReader).GetString(6);
				}
				list.Add(menuUser);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.MenuUser> GetAll()
		{
			string sql = "SELECT * FROM menuuser";
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.MenuUser> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM menuuser";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.MenuUser Get(Guid id)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Expected O, but got Unknown
			string sql = "SELECT * FROM menuuser WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
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
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Expected O, but got Unknown
			//IL_0025: Expected O, but got Unknown
			string sql = "DELETE FROM MenuUser WHERE Organizes=@Organizes";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@Organizes", 253);
			((DbParameter)val).Value = organizes;
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int DeleteByMenuID(Guid menuID)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			string sql = "DELETE FROM MenuUser WHERE MenuID=@MenuID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@MenuID", 253);
			((DbParameter)val).Value = menuID.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}
	}
}
