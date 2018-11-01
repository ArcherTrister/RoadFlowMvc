using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace RoadFlow.Data.MySql
{
	public class Menu : IMenu
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.Menu model)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Expected O, but got Unknown
			//IL_0056: Expected O, but got Unknown
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_0079: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Expected O, but got Unknown
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			//IL_009d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a8: Expected O, but got Unknown
			//IL_00a9: Expected O, but got Unknown
			//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c7: Expected O, but got Unknown
			//IL_00c8: Expected O, but got Unknown
			//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ee: Expected O, but got Unknown
			//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0100: Unknown result type (might be due to invalid IL or missing references)
			//IL_010b: Expected O, but got Unknown
			//IL_010c: Expected O, but got Unknown
			//IL_0121: Unknown result type (might be due to invalid IL or missing references)
			//IL_0126: Unknown result type (might be due to invalid IL or missing references)
			//IL_0132: Expected O, but got Unknown
			//IL_013f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0144: Unknown result type (might be due to invalid IL or missing references)
			//IL_014f: Expected O, but got Unknown
			//IL_0150: Expected O, but got Unknown
			//IL_015a: Unknown result type (might be due to invalid IL or missing references)
			//IL_015f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0170: Expected O, but got Unknown
			//IL_0171: Expected O, but got Unknown
			//IL_0187: Unknown result type (might be due to invalid IL or missing references)
			//IL_018c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0198: Expected O, but got Unknown
			//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b6: Expected O, but got Unknown
			//IL_01b7: Expected O, but got Unknown
			string sql = "INSERT INTO menu\r\n\t\t\t\t(ID,ParentID,AppLibraryID,Title,Params,Ico,Sort,IcoColor) \r\n\t\t\t\tVALUES(@ID,@ParentID,@AppLibraryID,@Title,@Params,@Ico,@Sort,@IcoColor)";
			MySqlParameter[] obj = new MySqlParameter[8];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@ParentID", 253, 36);
			((DbParameter)val2).Value = model.ParentID;
			obj[1] = val2;
			_003F val3;
			if (model.AppLibraryID.HasValue)
			{
				val3 = new MySqlParameter("@AppLibraryID", 253, 36);
				((DbParameter)val3).Value = model.AppLibraryID;
			}
			else
			{
				val3 = new MySqlParameter("@AppLibraryID", 253, 36);
				((DbParameter)val3).Value = DBNull.Value;
			}
			obj[2] = val3;
			MySqlParameter val4 = new MySqlParameter("@Title", 752, -1);
			((DbParameter)val4).Value = model.Title;
			obj[3] = val4;
			_003F val5;
			if (model.Params != null)
			{
				val5 = new MySqlParameter("@Params", 752, -1);
				((DbParameter)val5).Value = model.Params;
			}
			else
			{
				val5 = new MySqlParameter("@Params", 752, -1);
				((DbParameter)val5).Value = DBNull.Value;
			}
			obj[4] = val5;
			_003F val6;
			if (model.Ico != null)
			{
				val6 = new MySqlParameter("@Ico", 752, -1);
				((DbParameter)val6).Value = model.Ico;
			}
			else
			{
				val6 = new MySqlParameter("@Ico", 752, -1);
				((DbParameter)val6).Value = DBNull.Value;
			}
			obj[5] = val6;
			MySqlParameter val7 = new MySqlParameter("@Sort", 3, 11);
			((DbParameter)val7).Value = model.Sort;
			obj[6] = val7;
			_003F val8;
			if (model.IcoColor != null)
			{
				val8 = new MySqlParameter("@IcoColor", 253, 50);
				((DbParameter)val8).Value = model.IcoColor;
			}
			else
			{
				val8 = new MySqlParameter("@IcoColor", 253, 50);
				((DbParameter)val8).Value = DBNull.Value;
			}
			obj[7] = val8;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.Menu model)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Expected O, but got Unknown
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_0083: Expected O, but got Unknown
			//IL_0084: Expected O, but got Unknown
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Expected O, but got Unknown
			//IL_00a3: Expected O, but got Unknown
			//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c9: Expected O, but got Unknown
			//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00db: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Expected O, but got Unknown
			//IL_00e7: Expected O, but got Unknown
			//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0101: Unknown result type (might be due to invalid IL or missing references)
			//IL_010d: Expected O, but got Unknown
			//IL_011a: Unknown result type (might be due to invalid IL or missing references)
			//IL_011f: Unknown result type (might be due to invalid IL or missing references)
			//IL_012a: Expected O, but got Unknown
			//IL_012b: Expected O, but got Unknown
			//IL_0135: Unknown result type (might be due to invalid IL or missing references)
			//IL_013a: Unknown result type (might be due to invalid IL or missing references)
			//IL_014b: Expected O, but got Unknown
			//IL_014c: Expected O, but got Unknown
			//IL_0162: Unknown result type (might be due to invalid IL or missing references)
			//IL_0167: Unknown result type (might be due to invalid IL or missing references)
			//IL_0173: Expected O, but got Unknown
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0191: Expected O, but got Unknown
			//IL_0192: Expected O, but got Unknown
			//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b6: Expected O, but got Unknown
			//IL_01b7: Expected O, but got Unknown
			string sql = "UPDATE menu SET \r\n\t\t\t\tParentID=@ParentID,AppLibraryID=@AppLibraryID,Title=@Title,Params=@Params,Ico=@Ico,Sort=@Sort,IcoColor=@IcoColor \r\n\t\t\t\tWHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[8];
			MySqlParameter val = new MySqlParameter("@ParentID", 253, 36);
			((DbParameter)val).Value = model.ParentID;
			obj[0] = val;
			_003F val2;
			if (model.AppLibraryID.HasValue)
			{
				val2 = new MySqlParameter("@AppLibraryID", 253, 36);
				((DbParameter)val2).Value = model.AppLibraryID;
			}
			else
			{
				val2 = new MySqlParameter("@AppLibraryID", 253, 36);
				((DbParameter)val2).Value = DBNull.Value;
			}
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@Title", 752, -1);
			((DbParameter)val3).Value = model.Title;
			obj[2] = val3;
			_003F val4;
			if (model.Params != null)
			{
				val4 = new MySqlParameter("@Params", 752, -1);
				((DbParameter)val4).Value = model.Params;
			}
			else
			{
				val4 = new MySqlParameter("@Params", 752, -1);
				((DbParameter)val4).Value = DBNull.Value;
			}
			obj[3] = val4;
			_003F val5;
			if (model.Ico != null)
			{
				val5 = new MySqlParameter("@Ico", 752, -1);
				((DbParameter)val5).Value = model.Ico;
			}
			else
			{
				val5 = new MySqlParameter("@Ico", 752, -1);
				((DbParameter)val5).Value = DBNull.Value;
			}
			obj[4] = val5;
			MySqlParameter val6 = new MySqlParameter("@Sort", 3, 11);
			((DbParameter)val6).Value = model.Sort;
			obj[5] = val6;
			_003F val7;
			if (model.IcoColor != null)
			{
				val7 = new MySqlParameter("@IcoColor", 253, 50);
				((DbParameter)val7).Value = model.IcoColor;
			}
			else
			{
				val7 = new MySqlParameter("@IcoColor", 253, 50);
				((DbParameter)val7).Value = DBNull.Value;
			}
			obj[6] = val7;
			MySqlParameter val8 = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val8).Value = model.ID;
			obj[7] = val8;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Delete(Guid id)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Expected O, but got Unknown
			string sql = "DELETE FROM menu WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.Menu> DataReaderToList(MySqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.Menu> list = new List<RoadFlow.Data.Model.Menu>();
			RoadFlow.Data.Model.Menu menu = null;
			while (((DbDataReader)dataReader).Read())
			{
				menu = new RoadFlow.Data.Model.Menu();
				menu.ID = ((DbDataReader)dataReader).GetString(0).ToGuid();
				menu.ParentID = ((DbDataReader)dataReader).GetString(1).ToGuid();
				if (!((DbDataReader)dataReader).IsDBNull(2))
				{
					menu.AppLibraryID = ((DbDataReader)dataReader).GetString(2).ToGuid();
				}
				menu.Title = ((DbDataReader)dataReader).GetString(3);
				if (!((DbDataReader)dataReader).IsDBNull(4))
				{
					menu.Params = ((DbDataReader)dataReader).GetString(4);
				}
				if (!((DbDataReader)dataReader).IsDBNull(5))
				{
					menu.Ico = ((DbDataReader)dataReader).GetString(5);
				}
				menu.Sort = ((DbDataReader)dataReader).GetInt32(6);
				if (!((DbDataReader)dataReader).IsDBNull(7))
				{
					menu.IcoColor = ((DbDataReader)dataReader).GetString(7);
				}
				list.Add(menu);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.Menu> GetAll()
		{
			string sql = "SELECT * FROM menu";
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.Menu> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM menu";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.Menu Get(Guid id)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Expected O, but got Unknown
			string sql = "SELECT * FROM menu WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.Menu> list = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public DataTable GetAllDataTable()
		{
			string sql = "SELECT a.*,b.Address,b.OpenMode,b.Width,b.Height,b.Params AS Params1,b.Ico AS AppIco,b.Color AS IcoColor1 FROM Menu a LEFT JOIN AppLibrary b ON a.AppLibraryID=b.ID ORDER BY a.Sort";
			return dbHelper.GetDataTable(sql);
		}

		public List<RoadFlow.Data.Model.Menu> GetChild(Guid id)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Expected O, but got Unknown
			//IL_002a: Expected O, but got Unknown
			string sql = "SELECT * FROM Menu WHERE ParentID=@ParentID ORDER BY Sort";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ParentID", 253);
			((DbParameter)val).Value = id;
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.Menu> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public bool HasChild(Guid id)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Expected O, but got Unknown
			//IL_002a: Expected O, but got Unknown
			string sql = "SELECT ID FROM Menu WHERE ParentID=@ParentID LIMIT 0,1";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ParentID", 253);
			((DbParameter)val).Value = id;
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			bool hasRows = ((DbDataReader)dataReader).HasRows;
			((DbDataReader)dataReader).Close();
			return hasRows;
		}

		public int UpdateSort(Guid id, int sort)
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Expected O, but got Unknown
			//IL_0026: Expected O, but got Unknown
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Expected O, but got Unknown
			//IL_0044: Expected O, but got Unknown
			string sql = "UPDATE Menu SET Sort=@Sort WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[2];
			MySqlParameter val = new MySqlParameter("@Sort", 3);
			((DbParameter)val).Value = sort;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@ID", 253);
			((DbParameter)val2).Value = id;
			obj[1] = val2;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int GetMaxSort(Guid id)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Expected O, but got Unknown
			//IL_002a: Expected O, but got Unknown
			string sql = "SELECT IFNULL(MAX(Sort),0)+1 FROM Menu WHERE ParentID=@ParentID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ParentID", 253);
			((DbParameter)val).Value = id;
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			int test;
			if (!dbHelper.GetFieldValue(sql, parameter).IsInt(out test))
			{
				return 1;
			}
			return test;
		}

		public List<RoadFlow.Data.Model.Menu> GetAllByApplibaryID(Guid applibaryID)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			string sql = "SELECT * FROM Menu WHERE AppLibraryID=@AppLibraryID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@AppLibraryID", 253);
			((DbParameter)val).Value = applibaryID.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.Menu> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}
	}
}
