using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace RoadFlow.Data.MySql
{
	public class Dictionary : IDictionary
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.Dictionary model)
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
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			//IL_009b: Expected O, but got Unknown
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b8: Expected O, but got Unknown
			//IL_00b9: Expected O, but got Unknown
			//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00df: Expected O, but got Unknown
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fc: Expected O, but got Unknown
			//IL_00fd: Expected O, but got Unknown
			//IL_0112: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Expected O, but got Unknown
			//IL_0130: Unknown result type (might be due to invalid IL or missing references)
			//IL_0135: Unknown result type (might be due to invalid IL or missing references)
			//IL_0140: Expected O, but got Unknown
			//IL_0141: Expected O, but got Unknown
			//IL_0156: Unknown result type (might be due to invalid IL or missing references)
			//IL_015b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0167: Expected O, but got Unknown
			//IL_0174: Unknown result type (might be due to invalid IL or missing references)
			//IL_0179: Unknown result type (might be due to invalid IL or missing references)
			//IL_0184: Expected O, but got Unknown
			//IL_0185: Expected O, but got Unknown
			//IL_018f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0194: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a5: Expected O, but got Unknown
			//IL_01a6: Expected O, but got Unknown
			string sql = "INSERT INTO dictionary\r\n\t\t\t\t(ID,ParentID,Title,Code,Value,Note,Other,Sort) \r\n\t\t\t\tVALUES(@ID,@ParentID,@Title,@Code,@Value,@Note,@Other,@Sort)";
			MySqlParameter[] obj = new MySqlParameter[8];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@ParentID", 253, 36);
			((DbParameter)val2).Value = model.ParentID;
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@Title", 751, -1);
			((DbParameter)val3).Value = model.Title;
			obj[2] = val3;
			_003F val4;
			if (model.Code != null)
			{
				val4 = new MySqlParameter("@Code", 752, -1);
				((DbParameter)val4).Value = model.Code;
			}
			else
			{
				val4 = new MySqlParameter("@Code", 752, -1);
				((DbParameter)val4).Value = DBNull.Value;
			}
			obj[3] = val4;
			_003F val5;
			if (model.Value != null)
			{
				val5 = new MySqlParameter("@Value", 751, -1);
				((DbParameter)val5).Value = model.Value;
			}
			else
			{
				val5 = new MySqlParameter("@Value", 751, -1);
				((DbParameter)val5).Value = DBNull.Value;
			}
			obj[4] = val5;
			_003F val6;
			if (model.Note != null)
			{
				val6 = new MySqlParameter("@Note", 751, -1);
				((DbParameter)val6).Value = model.Note;
			}
			else
			{
				val6 = new MySqlParameter("@Note", 751, -1);
				((DbParameter)val6).Value = DBNull.Value;
			}
			obj[5] = val6;
			_003F val7;
			if (model.Other != null)
			{
				val7 = new MySqlParameter("@Other", 751, -1);
				((DbParameter)val7).Value = model.Other;
			}
			else
			{
				val7 = new MySqlParameter("@Other", 751, -1);
				((DbParameter)val7).Value = DBNull.Value;
			}
			obj[6] = val7;
			MySqlParameter val8 = new MySqlParameter("@Sort", 3, 11);
			((DbParameter)val8).Value = model.Sort;
			obj[7] = val8;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.Dictionary model)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Expected O, but got Unknown
			//IL_0050: Expected O, but got Unknown
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Expected O, but got Unknown
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Expected O, but got Unknown
			//IL_0094: Expected O, but got Unknown
			//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ba: Expected O, but got Unknown
			//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			//IL_00d8: Expected O, but got Unknown
			//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fe: Expected O, but got Unknown
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0110: Unknown result type (might be due to invalid IL or missing references)
			//IL_011b: Expected O, but got Unknown
			//IL_011c: Expected O, but got Unknown
			//IL_0131: Unknown result type (might be due to invalid IL or missing references)
			//IL_0136: Unknown result type (might be due to invalid IL or missing references)
			//IL_0142: Expected O, but got Unknown
			//IL_014f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0154: Unknown result type (might be due to invalid IL or missing references)
			//IL_015f: Expected O, but got Unknown
			//IL_0160: Expected O, but got Unknown
			//IL_016a: Unknown result type (might be due to invalid IL or missing references)
			//IL_016f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0180: Expected O, but got Unknown
			//IL_0181: Expected O, but got Unknown
			//IL_018f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0194: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a5: Expected O, but got Unknown
			//IL_01a6: Expected O, but got Unknown
			string sql = "UPDATE dictionary SET \r\n\t\t\t\tParentID=@ParentID,Title=@Title,Code=@Code,Value=@Value,Note=@Note,Other=@Other,Sort=@Sort\r\n\t\t\t\tWHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[8];
			MySqlParameter val = new MySqlParameter("@ParentID", 253, 36);
			((DbParameter)val).Value = model.ParentID;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@Title", 751, -1);
			((DbParameter)val2).Value = model.Title;
			obj[1] = val2;
			_003F val3;
			if (model.Code != null)
			{
				val3 = new MySqlParameter("@Code", 752, -1);
				((DbParameter)val3).Value = model.Code;
			}
			else
			{
				val3 = new MySqlParameter("@Code", 752, -1);
				((DbParameter)val3).Value = DBNull.Value;
			}
			obj[2] = val3;
			_003F val4;
			if (model.Value != null)
			{
				val4 = new MySqlParameter("@Value", 751, -1);
				((DbParameter)val4).Value = model.Value;
			}
			else
			{
				val4 = new MySqlParameter("@Value", 751, -1);
				((DbParameter)val4).Value = DBNull.Value;
			}
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
			_003F val6;
			if (model.Other != null)
			{
				val6 = new MySqlParameter("@Other", 751, -1);
				((DbParameter)val6).Value = model.Other;
			}
			else
			{
				val6 = new MySqlParameter("@Other", 751, -1);
				((DbParameter)val6).Value = DBNull.Value;
			}
			obj[5] = val6;
			MySqlParameter val7 = new MySqlParameter("@Sort", 3, 11);
			((DbParameter)val7).Value = model.Sort;
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
			string sql = "DELETE FROM dictionary WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.Dictionary> DataReaderToList(MySqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.Dictionary> list = new List<RoadFlow.Data.Model.Dictionary>();
			RoadFlow.Data.Model.Dictionary dictionary = null;
			while (((DbDataReader)dataReader).Read())
			{
				dictionary = new RoadFlow.Data.Model.Dictionary();
				dictionary.ID = ((DbDataReader)dataReader).GetString(0).ToGuid();
				dictionary.ParentID = ((DbDataReader)dataReader).GetString(1).ToGuid();
				dictionary.Title = ((DbDataReader)dataReader).GetString(2);
				if (!((DbDataReader)dataReader).IsDBNull(3))
				{
					dictionary.Code = ((DbDataReader)dataReader).GetString(3);
				}
				if (!((DbDataReader)dataReader).IsDBNull(4))
				{
					dictionary.Value = ((DbDataReader)dataReader).GetString(4);
				}
				if (!((DbDataReader)dataReader).IsDBNull(5))
				{
					dictionary.Note = ((DbDataReader)dataReader).GetString(5);
				}
				if (!((DbDataReader)dataReader).IsDBNull(6))
				{
					dictionary.Other = ((DbDataReader)dataReader).GetString(6);
				}
				dictionary.Sort = ((DbDataReader)dataReader).GetInt32(7);
				list.Add(dictionary);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.Dictionary> GetAll()
		{
			string sql = "SELECT * FROM dictionary";
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.Dictionary> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM dictionary";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.Dictionary Get(Guid id)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Expected O, but got Unknown
			string sql = "SELECT * FROM dictionary WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.Dictionary> list = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public RoadFlow.Data.Model.Dictionary GetRoot()
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Expected O, but got Unknown
			//IL_002e: Expected O, but got Unknown
			string sql = "SELECT * FROM Dictionary WHERE ParentID=@ParentID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ParentID", 253);
			((DbParameter)val).Value = Guid.Empty;
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.Dictionary> list = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public List<RoadFlow.Data.Model.Dictionary> GetChilds(Guid id)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Expected O, but got Unknown
			//IL_002a: Expected O, but got Unknown
			string sql = "SELECT * FROM Dictionary WHERE ParentID=@ParentID ORDER BY Sort";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ParentID", 253);
			((DbParameter)val).Value = id;
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.Dictionary> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public List<RoadFlow.Data.Model.Dictionary> GetChilds(string code)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Expected O, but got Unknown
			//IL_0025: Expected O, but got Unknown
			string sql = "SELECT * FROM Dictionary WHERE ParentID=(SELECT ID FROM Dictionary WHERE Code=@Code) ORDER BY Sort";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@Code", 253);
			((DbParameter)val).Value = code;
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.Dictionary> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public RoadFlow.Data.Model.Dictionary GetParent(Guid id)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Expected O, but got Unknown
			//IL_002a: Expected O, but got Unknown
			string sql = "SELECT * FROM Dictionary WHERE ID=(SELECT ParentID FROM Dictionary WHERE ID=@ID)";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253);
			((DbParameter)val).Value = id;
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.Dictionary> list = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public bool HasChilds(Guid id)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Expected O, but got Unknown
			//IL_002a: Expected O, but got Unknown
			string sql = "SELECT ID FROM Dictionary WHERE ParentID=@ParentID";
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

		public int GetMaxSort(Guid id)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Expected O, but got Unknown
			//IL_002a: Expected O, but got Unknown
			string sql = "SELECT MAX(Sort)+1 FROM Dictionary WHERE ParentID=@ParentID";
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
			string sql = "UPDATE Dictionary SET Sort=@Sort WHERE ID=@ID";
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

		public RoadFlow.Data.Model.Dictionary GetByCode(string code)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Expected O, but got Unknown
			//IL_0025: Expected O, but got Unknown
			string sql = "SELECT * FROM Dictionary WHERE Code=@Code";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@Code", 253);
			((DbParameter)val).Value = code;
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.Dictionary> list = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}
	}
}
