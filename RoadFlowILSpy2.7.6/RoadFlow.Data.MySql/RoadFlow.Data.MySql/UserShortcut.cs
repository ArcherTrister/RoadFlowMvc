using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace RoadFlow.Data.MySql
{
	public class UserShortcut : IUserShortcut
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.UserShortcut model)
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
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_009b: Expected O, but got Unknown
			//IL_009c: Expected O, but got Unknown
			string sql = "INSERT INTO usershortcut\r\n\t\t\t\t(ID,MenuID,UserID,Sort) \r\n\t\t\t\tVALUES(@ID,@MenuID,@UserID,@Sort)";
			MySqlParameter[] obj = new MySqlParameter[4];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@MenuID", 253, 36);
			((DbParameter)val2).Value = model.MenuID;
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@UserID", 253, 36);
			((DbParameter)val3).Value = model.UserID;
			obj[2] = val3;
			MySqlParameter val4 = new MySqlParameter("@Sort", 3, 11);
			((DbParameter)val4).Value = model.Sort;
			obj[3] = val4;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.UserShortcut model)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Expected O, but got Unknown
			//IL_0056: Expected O, but got Unknown
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Expected O, but got Unknown
			//IL_0077: Expected O, but got Unknown
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_009b: Expected O, but got Unknown
			//IL_009c: Expected O, but got Unknown
			string sql = "UPDATE usershortcut SET \r\n\t\t\t\tMenuID=@MenuID,UserID=@UserID,Sort=@Sort\r\n\t\t\t\tWHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[4];
			MySqlParameter val = new MySqlParameter("@MenuID", 253, 36);
			((DbParameter)val).Value = model.MenuID;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@UserID", 253, 36);
			((DbParameter)val2).Value = model.UserID;
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@Sort", 3, 11);
			((DbParameter)val3).Value = model.Sort;
			obj[2] = val3;
			MySqlParameter val4 = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val4).Value = model.ID;
			obj[3] = val4;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Delete(Guid id)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Expected O, but got Unknown
			string sql = "DELETE FROM usershortcut WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.UserShortcut> DataReaderToList(MySqlDataReader dataReader)
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
			string sql = "SELECT * FROM usershortcut";
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.UserShortcut> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM usershortcut";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.UserShortcut Get(Guid id)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Expected O, but got Unknown
			string sql = "SELECT * FROM usershortcut WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
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
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			string sql = "DELETE FROM UserShortcut WHERE UserID=@UserID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@UserID", 253);
			((DbParameter)val).Value = userID.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public List<RoadFlow.Data.Model.UserShortcut> GetAllByUserID(Guid userID)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			string sql = "SELECT * FROM UserShortcut WHERE UserID=@UserID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@UserID", 253);
			((DbParameter)val).Value = userID.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.UserShortcut> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public DataTable GetDataTableByUserID(Guid userID)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			string sql = "SELECT * FROM UserShortcut WHERE UserID=@UserID ORDER BY Sort";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@UserID", 253);
			((DbParameter)val).Value = userID.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.GetDataTable(sql, parameter);
		}

		public int DeleteByMenuID(Guid menuID)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			string sql = "DELETE FROM UserShortcut WHERE MenuID=@MenuID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@MenuID", 253);
			((DbParameter)val).Value = menuID.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}
	}
}
