using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace RoadFlow.Data.MySql
{
	public class AppLibraryButtons1 : IAppLibraryButtons1
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.AppLibraryButtons1 model)
		{
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0032: Expected O, but got Unknown
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Expected O, but got Unknown
			//IL_0057: Expected O, but got Unknown
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Expected O, but got Unknown
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a9: Expected O, but got Unknown
			//IL_00aa: Expected O, but got Unknown
			//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c8: Expected O, but got Unknown
			//IL_00c9: Expected O, but got Unknown
			//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00db: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Expected O, but got Unknown
			//IL_00e8: Expected O, but got Unknown
			//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0102: Unknown result type (might be due to invalid IL or missing references)
			//IL_010e: Expected O, but got Unknown
			//IL_011b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0120: Unknown result type (might be due to invalid IL or missing references)
			//IL_012b: Expected O, but got Unknown
			//IL_012c: Expected O, but got Unknown
			//IL_0136: Unknown result type (might be due to invalid IL or missing references)
			//IL_013b: Unknown result type (might be due to invalid IL or missing references)
			//IL_014c: Expected O, but got Unknown
			//IL_014d: Expected O, but got Unknown
			//IL_0157: Unknown result type (might be due to invalid IL or missing references)
			//IL_015c: Unknown result type (might be due to invalid IL or missing references)
			//IL_016d: Expected O, but got Unknown
			//IL_016e: Expected O, but got Unknown
			//IL_0178: Unknown result type (might be due to invalid IL or missing references)
			//IL_017d: Unknown result type (might be due to invalid IL or missing references)
			//IL_018e: Expected O, but got Unknown
			//IL_018f: Expected O, but got Unknown
			//IL_019a: Unknown result type (might be due to invalid IL or missing references)
			//IL_019f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b0: Expected O, but got Unknown
			//IL_01b1: Expected O, but got Unknown
			string sql = "INSERT INTO applibrarybuttons1\r\n\t\t\t\t(ID,AppLibraryID,ButtonID,Name,Events,Ico,Sort,Type,ShowType,IsValidateShow) \r\n\t\t\t\tVALUES(@ID,@AppLibraryID,@ButtonID,@Name,@Events,@Ico,@Sort,@Type,@ShowType,@IsValidateShow)";
			MySqlParameter[] obj = new MySqlParameter[10];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@AppLibraryID", 253, 36);
			((DbParameter)val2).Value = model.AppLibraryID;
			obj[1] = val2;
			_003F val3;
			if (model.ButtonID.HasValue)
			{
				val3 = new MySqlParameter("@ButtonID", 253, 36);
				((DbParameter)val3).Value = model.ButtonID;
			}
			else
			{
				val3 = new MySqlParameter("@ButtonID", 253, 36);
				((DbParameter)val3).Value = DBNull.Value;
			}
			obj[2] = val3;
			MySqlParameter val4 = new MySqlParameter("@Name", 752, -1);
			((DbParameter)val4).Value = model.Name;
			obj[3] = val4;
			MySqlParameter val5 = new MySqlParameter("@Events", 752, -1);
			((DbParameter)val5).Value = model.Events;
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
			MySqlParameter val8 = new MySqlParameter("@Type", 3, 11);
			((DbParameter)val8).Value = model.Type;
			obj[7] = val8;
			MySqlParameter val9 = new MySqlParameter("@ShowType", 3, 11);
			((DbParameter)val9).Value = model.ShowType;
			obj[8] = val9;
			MySqlParameter val10 = new MySqlParameter("@IsValidateShow", 3, 11);
			((DbParameter)val10).Value = model.IsValidateShow;
			obj[9] = val10;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.AppLibraryButtons1 model)
		{
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0032: Expected O, but got Unknown
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Expected O, but got Unknown
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_0079: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Expected O, but got Unknown
			//IL_0085: Expected O, but got Unknown
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a3: Expected O, but got Unknown
			//IL_00a4: Expected O, but got Unknown
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c2: Expected O, but got Unknown
			//IL_00c3: Expected O, but got Unknown
			//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e9: Expected O, but got Unknown
			//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0106: Expected O, but got Unknown
			//IL_0107: Expected O, but got Unknown
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_0127: Expected O, but got Unknown
			//IL_0128: Expected O, but got Unknown
			//IL_0132: Unknown result type (might be due to invalid IL or missing references)
			//IL_0137: Unknown result type (might be due to invalid IL or missing references)
			//IL_0148: Expected O, but got Unknown
			//IL_0149: Expected O, but got Unknown
			//IL_0153: Unknown result type (might be due to invalid IL or missing references)
			//IL_0158: Unknown result type (might be due to invalid IL or missing references)
			//IL_0169: Expected O, but got Unknown
			//IL_016a: Expected O, but got Unknown
			//IL_0174: Unknown result type (might be due to invalid IL or missing references)
			//IL_0179: Unknown result type (might be due to invalid IL or missing references)
			//IL_018a: Expected O, but got Unknown
			//IL_018b: Expected O, but got Unknown
			//IL_019a: Unknown result type (might be due to invalid IL or missing references)
			//IL_019f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b0: Expected O, but got Unknown
			//IL_01b1: Expected O, but got Unknown
			string sql = "UPDATE applibrarybuttons1 SET \r\n\t\t\t\tAppLibraryID=@AppLibraryID,ButtonID=@ButtonID,Name=@Name,Events=@Events,Ico=@Ico,Sort=@Sort,Type=@Type,ShowType=@ShowType,IsValidateShow=@IsValidateShow\r\n\t\t\t\tWHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[10];
			MySqlParameter val = new MySqlParameter("@AppLibraryID", 253, 36);
			((DbParameter)val).Value = model.AppLibraryID;
			obj[0] = val;
			_003F val2;
			if (model.ButtonID.HasValue)
			{
				val2 = new MySqlParameter("@ButtonID", 253, 36);
				((DbParameter)val2).Value = model.ButtonID;
			}
			else
			{
				val2 = new MySqlParameter("@ButtonID", 253, 36);
				((DbParameter)val2).Value = DBNull.Value;
			}
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@Name", 752, -1);
			((DbParameter)val3).Value = model.Name;
			obj[2] = val3;
			MySqlParameter val4 = new MySqlParameter("@Events", 752, -1);
			((DbParameter)val4).Value = model.Events;
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
			MySqlParameter val7 = new MySqlParameter("@Type", 3, 11);
			((DbParameter)val7).Value = model.Type;
			obj[6] = val7;
			MySqlParameter val8 = new MySqlParameter("@ShowType", 3, 11);
			((DbParameter)val8).Value = model.ShowType;
			obj[7] = val8;
			MySqlParameter val9 = new MySqlParameter("@IsValidateShow", 3, 11);
			((DbParameter)val9).Value = model.IsValidateShow;
			obj[8] = val9;
			MySqlParameter val10 = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val10).Value = model.ID;
			obj[9] = val10;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Delete(Guid id)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Expected O, but got Unknown
			string sql = "DELETE FROM applibrarybuttons1 WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.AppLibraryButtons1> DataReaderToList(MySqlDataReader dataReader)
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
			string sql = "SELECT * FROM applibrarybuttons1";
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.AppLibraryButtons1> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM applibrarybuttons1";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.AppLibraryButtons1 Get(Guid id)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Expected O, but got Unknown
			string sql = "SELECT * FROM applibrarybuttons1 WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
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
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Expected O, but got Unknown
			//IL_002a: Expected O, but got Unknown
			string sql = "DELETE FROM AppLibraryButtons1 WHERE AppLibraryID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253);
			((DbParameter)val).Value = id;
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public List<RoadFlow.Data.Model.AppLibraryButtons1> GetAllByAppID(Guid id)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Expected O, but got Unknown
			//IL_002a: Expected O, but got Unknown
			string sql = "SELECT * FROM AppLibraryButtons1 WHERE AppLibraryID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253);
			((DbParameter)val).Value = id;
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.AppLibraryButtons1> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}
	}
}
