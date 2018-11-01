using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace RoadFlow.Data.MySql
{
	public class AppLibrarySubPages : IAppLibrarySubPages
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.AppLibrarySubPages model)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Expected O, but got Unknown
			//IL_0056: Expected O, but got Unknown
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_0074: Expected O, but got Unknown
			//IL_0075: Expected O, but got Unknown
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Expected O, but got Unknown
			//IL_0094: Expected O, but got Unknown
			//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ba: Expected O, but got Unknown
			//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			//IL_00d8: Expected O, but got Unknown
			//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f8: Expected O, but got Unknown
			//IL_00f9: Expected O, but got Unknown
			//IL_010e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0113: Unknown result type (might be due to invalid IL or missing references)
			//IL_011f: Expected O, but got Unknown
			//IL_012c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0131: Unknown result type (might be due to invalid IL or missing references)
			//IL_013c: Expected O, but got Unknown
			//IL_013d: Expected O, but got Unknown
			string sql = "INSERT INTO applibrarysubpages\r\n\t\t\t\t(ID,AppLibraryID,Name,Address,Ico,Sort,Note) \r\n\t\t\t\tVALUES(@ID,@AppLibraryID,@Name,@Address,@Ico,@Sort,@Note)";
			MySqlParameter[] obj = new MySqlParameter[7];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@AppLibraryID", 253, 36);
			((DbParameter)val2).Value = model.AppLibraryID;
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@Name", 752, -1);
			((DbParameter)val3).Value = model.Name;
			obj[2] = val3;
			MySqlParameter val4 = new MySqlParameter("@Address", 752, -1);
			((DbParameter)val4).Value = model.Address;
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
			if (model.Note != null)
			{
				val7 = new MySqlParameter("@Note", 752, -1);
				((DbParameter)val7).Value = model.Note;
			}
			else
			{
				val7 = new MySqlParameter("@Note", 752, -1);
				((DbParameter)val7).Value = DBNull.Value;
			}
			obj[6] = val7;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.AppLibrarySubPages model)
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
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Expected O, but got Unknown
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Expected O, but got Unknown
			//IL_00b3: Expected O, but got Unknown
			//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d3: Expected O, but got Unknown
			//IL_00d4: Expected O, but got Unknown
			//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fa: Expected O, but got Unknown
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_010c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Expected O, but got Unknown
			//IL_0118: Expected O, but got Unknown
			//IL_0126: Unknown result type (might be due to invalid IL or missing references)
			//IL_012b: Unknown result type (might be due to invalid IL or missing references)
			//IL_013c: Expected O, but got Unknown
			//IL_013d: Expected O, but got Unknown
			string sql = "UPDATE applibrarysubpages SET \r\n\t\t\t\tAppLibraryID=@AppLibraryID,Name=@Name,Address=@Address,Ico=@Ico,Sort=@Sort,Note=@Note\r\n\t\t\t\tWHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[7];
			MySqlParameter val = new MySqlParameter("@AppLibraryID", 253, 36);
			((DbParameter)val).Value = model.AppLibraryID;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@Name", 752, -1);
			((DbParameter)val2).Value = model.Name;
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@Address", 752, -1);
			((DbParameter)val3).Value = model.Address;
			obj[2] = val3;
			_003F val4;
			if (model.Ico != null)
			{
				val4 = new MySqlParameter("@Ico", 752, -1);
				((DbParameter)val4).Value = model.Ico;
			}
			else
			{
				val4 = new MySqlParameter("@Ico", 752, -1);
				((DbParameter)val4).Value = DBNull.Value;
			}
			obj[3] = val4;
			MySqlParameter val5 = new MySqlParameter("@Sort", 3, 11);
			((DbParameter)val5).Value = model.Sort;
			obj[4] = val5;
			_003F val6;
			if (model.Note != null)
			{
				val6 = new MySqlParameter("@Note", 752, -1);
				((DbParameter)val6).Value = model.Note;
			}
			else
			{
				val6 = new MySqlParameter("@Note", 752, -1);
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
			string sql = "DELETE FROM applibrarysubpages WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.AppLibrarySubPages> DataReaderToList(MySqlDataReader dataReader)
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
			string sql = "SELECT * FROM applibrarysubpages";
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.AppLibrarySubPages> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM applibrarysubpages";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.AppLibrarySubPages Get(Guid id)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Expected O, but got Unknown
			string sql = "SELECT * FROM applibrarysubpages WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
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
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Expected O, but got Unknown
			//IL_002a: Expected O, but got Unknown
			string sql = "DELETE FROM AppLibrarySubPages WHERE AppLibraryID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253);
			((DbParameter)val).Value = id;
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public List<RoadFlow.Data.Model.AppLibrarySubPages> GetAllByAppID(Guid id)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Expected O, but got Unknown
			//IL_002a: Expected O, but got Unknown
			string sql = "SELECT * FROM AppLibrarySubPages WHERE AppLibraryID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253);
			((DbParameter)val).Value = id;
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.AppLibrarySubPages> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}
	}
}
