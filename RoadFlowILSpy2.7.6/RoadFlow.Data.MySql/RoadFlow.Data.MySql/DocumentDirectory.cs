using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace RoadFlow.Data.MySql
{
	public class DocumentDirectory : IDocumentDirectory
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.DocumentDirectory model)
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
			//IL_014b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0150: Unknown result type (might be due to invalid IL or missing references)
			//IL_0161: Expected O, but got Unknown
			//IL_0162: Expected O, but got Unknown
			string sql = "INSERT INTO documentdirectory\r\n\t\t\t\t(ID,ParentID,Name,ReadUsers,ManageUsers,PublishUsers,Sort) \r\n\t\t\t\tVALUES(@ID,@ParentID,@Name,@ReadUsers,@ManageUsers,@PublishUsers,@Sort)";
			MySqlParameter[] obj = new MySqlParameter[7];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@ParentID", 253, 36);
			((DbParameter)val2).Value = model.ParentID;
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@Name", 752, -1);
			((DbParameter)val3).Value = model.Name;
			obj[2] = val3;
			_003F val4;
			if (model.ReadUsers != null)
			{
				val4 = new MySqlParameter("@ReadUsers", 751, -1);
				((DbParameter)val4).Value = model.ReadUsers;
			}
			else
			{
				val4 = new MySqlParameter("@ReadUsers", 751, -1);
				((DbParameter)val4).Value = DBNull.Value;
			}
			obj[3] = val4;
			_003F val5;
			if (model.ManageUsers != null)
			{
				val5 = new MySqlParameter("@ManageUsers", 751, -1);
				((DbParameter)val5).Value = model.ManageUsers;
			}
			else
			{
				val5 = new MySqlParameter("@ManageUsers", 751, -1);
				((DbParameter)val5).Value = DBNull.Value;
			}
			obj[4] = val5;
			_003F val6;
			if (model.PublishUsers != null)
			{
				val6 = new MySqlParameter("@PublishUsers", 751, -1);
				((DbParameter)val6).Value = model.PublishUsers;
			}
			else
			{
				val6 = new MySqlParameter("@PublishUsers", 751, -1);
				((DbParameter)val6).Value = DBNull.Value;
			}
			obj[5] = val6;
			MySqlParameter val7 = new MySqlParameter("@Sort", 3, 11);
			((DbParameter)val7).Value = model.Sort;
			obj[6] = val7;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.DocumentDirectory model)
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
			//IL_0126: Unknown result type (might be due to invalid IL or missing references)
			//IL_012b: Unknown result type (might be due to invalid IL or missing references)
			//IL_013c: Expected O, but got Unknown
			//IL_013d: Expected O, but got Unknown
			//IL_014b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0150: Unknown result type (might be due to invalid IL or missing references)
			//IL_0161: Expected O, but got Unknown
			//IL_0162: Expected O, but got Unknown
			string sql = "UPDATE documentdirectory SET \r\n\t\t\t\tParentID=@ParentID,Name=@Name,ReadUsers=@ReadUsers,ManageUsers=@ManageUsers,PublishUsers=@PublishUsers,Sort=@Sort\r\n\t\t\t\tWHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[7];
			MySqlParameter val = new MySqlParameter("@ParentID", 253, 36);
			((DbParameter)val).Value = model.ParentID;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@Name", 752, -1);
			((DbParameter)val2).Value = model.Name;
			obj[1] = val2;
			_003F val3;
			if (model.ReadUsers != null)
			{
				val3 = new MySqlParameter("@ReadUsers", 751, -1);
				((DbParameter)val3).Value = model.ReadUsers;
			}
			else
			{
				val3 = new MySqlParameter("@ReadUsers", 751, -1);
				((DbParameter)val3).Value = DBNull.Value;
			}
			obj[2] = val3;
			_003F val4;
			if (model.ManageUsers != null)
			{
				val4 = new MySqlParameter("@ManageUsers", 751, -1);
				((DbParameter)val4).Value = model.ManageUsers;
			}
			else
			{
				val4 = new MySqlParameter("@ManageUsers", 751, -1);
				((DbParameter)val4).Value = DBNull.Value;
			}
			obj[3] = val4;
			_003F val5;
			if (model.PublishUsers != null)
			{
				val5 = new MySqlParameter("@PublishUsers", 751, -1);
				((DbParameter)val5).Value = model.PublishUsers;
			}
			else
			{
				val5 = new MySqlParameter("@PublishUsers", 751, -1);
				((DbParameter)val5).Value = DBNull.Value;
			}
			obj[4] = val5;
			MySqlParameter val6 = new MySqlParameter("@Sort", 3, 11);
			((DbParameter)val6).Value = model.Sort;
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
			string sql = "DELETE FROM documentdirectory WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.DocumentDirectory> DataReaderToList(MySqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.DocumentDirectory> list = new List<RoadFlow.Data.Model.DocumentDirectory>();
			RoadFlow.Data.Model.DocumentDirectory documentDirectory = null;
			while (((DbDataReader)dataReader).Read())
			{
				documentDirectory = new RoadFlow.Data.Model.DocumentDirectory();
				documentDirectory.ID = ((DbDataReader)dataReader).GetString(0).ToGuid();
				documentDirectory.ParentID = ((DbDataReader)dataReader).GetString(1).ToGuid();
				documentDirectory.Name = ((DbDataReader)dataReader).GetString(2);
				if (!((DbDataReader)dataReader).IsDBNull(3))
				{
					documentDirectory.ReadUsers = ((DbDataReader)dataReader).GetString(3);
				}
				if (!((DbDataReader)dataReader).IsDBNull(4))
				{
					documentDirectory.ManageUsers = ((DbDataReader)dataReader).GetString(4);
				}
				if (!((DbDataReader)dataReader).IsDBNull(5))
				{
					documentDirectory.PublishUsers = ((DbDataReader)dataReader).GetString(5);
				}
				documentDirectory.Sort = ((DbDataReader)dataReader).GetInt32(6);
				list.Add(documentDirectory);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.DocumentDirectory> GetAll()
		{
			string sql = "SELECT * FROM documentdirectory";
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.DocumentDirectory> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM documentdirectory";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.DocumentDirectory Get(Guid id)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Expected O, but got Unknown
			string sql = "SELECT * FROM documentdirectory WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.DocumentDirectory> list = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public List<RoadFlow.Data.Model.DocumentDirectory> GetChilds(Guid id)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Expected O, but got Unknown
			//IL_002a: Expected O, but got Unknown
			string sql = "SELECT * FROM DocumentDirectory WHERE ParentID=@ParentID ORDER BY Sort";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ParentID", 253);
			((DbParameter)val).Value = id;
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.DocumentDirectory> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public int GetMaxSort(Guid dirID)
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Expected O, but got Unknown
			string sql = "SELECT (IFNULL(MAX(Sort),0)+5) Sort FROM DocumentDirectory WHERE ParentID=@ParentID ";
			MySqlParameter[] parameter = (MySqlParameter[])new MySqlParameter[1]
			{
				new MySqlParameter("@ParentID", (object)dirID)
			};
			return dbHelper.GetFieldValue(sql, parameter).ToInt();
		}
	}
}
