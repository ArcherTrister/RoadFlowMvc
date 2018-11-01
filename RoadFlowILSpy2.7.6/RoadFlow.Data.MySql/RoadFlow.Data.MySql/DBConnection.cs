using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace RoadFlow.Data.MySql
{
	public class DBConnection : IDBConnection
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.DBConnection model)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Expected O, but got Unknown
			//IL_0050: Expected O, but got Unknown
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Expected O, but got Unknown
			//IL_006f: Expected O, but got Unknown
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_008d: Expected O, but got Unknown
			//IL_008e: Expected O, but got Unknown
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b4: Expected O, but got Unknown
			//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Expected O, but got Unknown
			//IL_00d2: Expected O, but got Unknown
			string sql = "INSERT INTO dbconnection\r\n\t\t\t\t(ID,Name,Type,ConnectionString,Note) \r\n\t\t\t\tVALUES(@ID,@Name,@Type,@ConnectionString,@Note)";
			MySqlParameter[] obj = new MySqlParameter[5];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@Name", 752, -1);
			((DbParameter)val2).Value = model.Name;
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@Type", 752, -1);
			((DbParameter)val3).Value = model.Type;
			obj[2] = val3;
			MySqlParameter val4 = new MySqlParameter("@ConnectionString", 751, -1);
			((DbParameter)val4).Value = model.ConnectionString;
			obj[3] = val4;
			_003F val5;
			if (model.Note != null)
			{
				val5 = new MySqlParameter("@Note", 751, -1);
				((DbParameter)val5).Value = model.Note;
			}
			else
			{
				val5 = new MySqlParameter("@Note", 751, -1);
				((DbParameter)val5).Value = DBNull.Value;
			}
			obj[4] = val5;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.DBConnection model)
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Expected O, but got Unknown
			//IL_002b: Expected O, but got Unknown
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0049: Expected O, but got Unknown
			//IL_004a: Expected O, but got Unknown
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Expected O, but got Unknown
			//IL_0069: Expected O, but got Unknown
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Expected O, but got Unknown
			//IL_009c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ac: Expected O, but got Unknown
			//IL_00ad: Expected O, but got Unknown
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Expected O, but got Unknown
			//IL_00d2: Expected O, but got Unknown
			string sql = "UPDATE dbconnection SET \r\n\t\t\t\tName=@Name,Type=@Type,ConnectionString=@ConnectionString,Note=@Note\r\n\t\t\t\tWHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[5];
			MySqlParameter val = new MySqlParameter("@Name", 752, -1);
			((DbParameter)val).Value = model.Name;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@Type", 752, -1);
			((DbParameter)val2).Value = model.Type;
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@ConnectionString", 751, -1);
			((DbParameter)val3).Value = model.ConnectionString;
			obj[2] = val3;
			_003F val4;
			if (model.Note != null)
			{
				val4 = new MySqlParameter("@Note", 751, -1);
				((DbParameter)val4).Value = model.Note;
			}
			else
			{
				val4 = new MySqlParameter("@Note", 751, -1);
				((DbParameter)val4).Value = DBNull.Value;
			}
			obj[3] = val4;
			MySqlParameter val5 = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val5).Value = model.ID;
			obj[4] = val5;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Delete(Guid id)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Expected O, but got Unknown
			string sql = "DELETE FROM dbconnection WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.DBConnection> DataReaderToList(MySqlDataReader dataReader)
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
			string sql = "SELECT * FROM dbconnection";
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.DBConnection> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM dbconnection";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.DBConnection Get(Guid id)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Expected O, but got Unknown
			string sql = "SELECT * FROM dbconnection WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
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
