using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace RoadFlow.Data.MySql
{
	public class Organize : IOrganize
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.Organize model)
		{
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0032: Expected O, but got Unknown
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Expected O, but got Unknown
			//IL_0051: Expected O, but got Unknown
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Expected O, but got Unknown
			//IL_0070: Expected O, but got Unknown
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Expected O, but got Unknown
			//IL_0091: Expected O, but got Unknown
			//IL_009b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Expected O, but got Unknown
			//IL_00b2: Expected O, but got Unknown
			//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d6: Expected O, but got Unknown
			//IL_00d7: Expected O, but got Unknown
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f7: Expected O, but got Unknown
			//IL_00f8: Expected O, but got Unknown
			//IL_0102: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0118: Expected O, but got Unknown
			//IL_0119: Expected O, but got Unknown
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_0128: Unknown result type (might be due to invalid IL or missing references)
			//IL_0139: Expected O, but got Unknown
			//IL_013a: Expected O, but got Unknown
			//IL_0154: Unknown result type (might be due to invalid IL or missing references)
			//IL_0159: Unknown result type (might be due to invalid IL or missing references)
			//IL_0165: Expected O, but got Unknown
			//IL_0176: Unknown result type (might be due to invalid IL or missing references)
			//IL_017b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Expected O, but got Unknown
			//IL_0187: Expected O, but got Unknown
			//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b2: Expected O, but got Unknown
			//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d3: Expected O, but got Unknown
			//IL_01d4: Expected O, but got Unknown
			//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fb: Expected O, but got Unknown
			//IL_0208: Unknown result type (might be due to invalid IL or missing references)
			//IL_020d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0218: Expected O, but got Unknown
			//IL_0219: Expected O, but got Unknown
			//IL_0224: Unknown result type (might be due to invalid IL or missing references)
			//IL_0229: Unknown result type (might be due to invalid IL or missing references)
			//IL_023a: Expected O, but got Unknown
			//IL_023b: Expected O, but got Unknown
			string sql = "INSERT INTO organize\r\n\t\t\t\t(ID,Name,Number,Type,Status,ParentID,Sort,Depth,ChildsLength,ChargeLeader,Leader,Note,IntID) \r\n\t\t\t\tVALUES(@ID,@Name,@Number,@Type,@Status,@ParentID,@Sort,@Depth,@ChildsLength,@ChargeLeader,@Leader,@Note,@IntID)";
			MySqlParameter[] obj = new MySqlParameter[13];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@Name", 752, -1);
			((DbParameter)val2).Value = model.Name;
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@Number", 752, -1);
			((DbParameter)val3).Value = model.Number;
			obj[2] = val3;
			MySqlParameter val4 = new MySqlParameter("@Type", 3, 11);
			((DbParameter)val4).Value = model.Type;
			obj[3] = val4;
			MySqlParameter val5 = new MySqlParameter("@Status", 3, 11);
			((DbParameter)val5).Value = model.Status;
			obj[4] = val5;
			MySqlParameter val6 = new MySqlParameter("@ParentID", 253, 36);
			((DbParameter)val6).Value = model.ParentID;
			obj[5] = val6;
			MySqlParameter val7 = new MySqlParameter("@Sort", 3, 11);
			((DbParameter)val7).Value = model.Sort;
			obj[6] = val7;
			MySqlParameter val8 = new MySqlParameter("@Depth", 3, 11);
			((DbParameter)val8).Value = model.Depth;
			obj[7] = val8;
			MySqlParameter val9 = new MySqlParameter("@ChildsLength", 3, 11);
			((DbParameter)val9).Value = model.ChildsLength;
			obj[8] = val9;
			_003F val10;
			if (model.ChargeLeader != null)
			{
				val10 = new MySqlParameter("@ChargeLeader", 253, 200);
				((DbParameter)val10).Value = model.ChargeLeader;
			}
			else
			{
				val10 = new MySqlParameter("@ChargeLeader", 253, 200);
				((DbParameter)val10).Value = DBNull.Value;
			}
			obj[9] = val10;
			_003F val11;
			if (model.Leader != null)
			{
				val11 = new MySqlParameter("@Leader", 253, 200);
				((DbParameter)val11).Value = model.Leader;
			}
			else
			{
				val11 = new MySqlParameter("@Leader", 253, 200);
				((DbParameter)val11).Value = DBNull.Value;
			}
			obj[10] = val11;
			_003F val12;
			if (model.Note != null)
			{
				val12 = new MySqlParameter("@Note", 751, -1);
				((DbParameter)val12).Value = model.Note;
			}
			else
			{
				val12 = new MySqlParameter("@Note", 751, -1);
				((DbParameter)val12).Value = DBNull.Value;
			}
			obj[11] = val12;
			MySqlParameter val13 = new MySqlParameter("@IntID", 3, 11);
			((DbParameter)val13).Value = model.IntID;
			obj[12] = val13;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.Organize model)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Expected O, but got Unknown
			//IL_002c: Expected O, but got Unknown
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_004a: Expected O, but got Unknown
			//IL_004b: Expected O, but got Unknown
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Expected O, but got Unknown
			//IL_006c: Expected O, but got Unknown
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Expected O, but got Unknown
			//IL_008d: Expected O, but got Unknown
			//IL_009b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Expected O, but got Unknown
			//IL_00b2: Expected O, but got Unknown
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Expected O, but got Unknown
			//IL_00d3: Expected O, but got Unknown
			//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f3: Expected O, but got Unknown
			//IL_00f4: Expected O, but got Unknown
			//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0103: Unknown result type (might be due to invalid IL or missing references)
			//IL_0114: Expected O, but got Unknown
			//IL_0115: Expected O, but got Unknown
			//IL_012e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_013f: Expected O, but got Unknown
			//IL_0150: Unknown result type (might be due to invalid IL or missing references)
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0160: Expected O, but got Unknown
			//IL_0161: Expected O, but got Unknown
			//IL_017b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0180: Unknown result type (might be due to invalid IL or missing references)
			//IL_018c: Expected O, but got Unknown
			//IL_019d: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ad: Expected O, but got Unknown
			//IL_01ae: Expected O, but got Unknown
			//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d5: Expected O, but got Unknown
			//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f2: Expected O, but got Unknown
			//IL_01f3: Expected O, but got Unknown
			//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0203: Unknown result type (might be due to invalid IL or missing references)
			//IL_0214: Expected O, but got Unknown
			//IL_0215: Expected O, but got Unknown
			//IL_0224: Unknown result type (might be due to invalid IL or missing references)
			//IL_0229: Unknown result type (might be due to invalid IL or missing references)
			//IL_023a: Expected O, but got Unknown
			//IL_023b: Expected O, but got Unknown
			string sql = "UPDATE organize SET \r\n\t\t\t\tName=@Name,Number=@Number,Type=@Type,Status=@Status,ParentID=@ParentID,Sort=@Sort,Depth=@Depth,ChildsLength=@ChildsLength,ChargeLeader=@ChargeLeader,Leader=@Leader,Note=@Note,IntID=@IntID \r\n\t\t\t\tWHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[13];
			MySqlParameter val = new MySqlParameter("@Name", 752, -1);
			((DbParameter)val).Value = model.Name;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@Number", 752, -1);
			((DbParameter)val2).Value = model.Number;
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@Type", 3, 11);
			((DbParameter)val3).Value = model.Type;
			obj[2] = val3;
			MySqlParameter val4 = new MySqlParameter("@Status", 3, 11);
			((DbParameter)val4).Value = model.Status;
			obj[3] = val4;
			MySqlParameter val5 = new MySqlParameter("@ParentID", 253, 36);
			((DbParameter)val5).Value = model.ParentID;
			obj[4] = val5;
			MySqlParameter val6 = new MySqlParameter("@Sort", 3, 11);
			((DbParameter)val6).Value = model.Sort;
			obj[5] = val6;
			MySqlParameter val7 = new MySqlParameter("@Depth", 3, 11);
			((DbParameter)val7).Value = model.Depth;
			obj[6] = val7;
			MySqlParameter val8 = new MySqlParameter("@ChildsLength", 3, 11);
			((DbParameter)val8).Value = model.ChildsLength;
			obj[7] = val8;
			_003F val9;
			if (model.ChargeLeader != null)
			{
				val9 = new MySqlParameter("@ChargeLeader", 253, 200);
				((DbParameter)val9).Value = model.ChargeLeader;
			}
			else
			{
				val9 = new MySqlParameter("@ChargeLeader", 253, 200);
				((DbParameter)val9).Value = DBNull.Value;
			}
			obj[8] = val9;
			_003F val10;
			if (model.Leader != null)
			{
				val10 = new MySqlParameter("@Leader", 253, 200);
				((DbParameter)val10).Value = model.Leader;
			}
			else
			{
				val10 = new MySqlParameter("@Leader", 253, 200);
				((DbParameter)val10).Value = DBNull.Value;
			}
			obj[9] = val10;
			_003F val11;
			if (model.Note != null)
			{
				val11 = new MySqlParameter("@Note", 751, -1);
				((DbParameter)val11).Value = model.Note;
			}
			else
			{
				val11 = new MySqlParameter("@Note", 751, -1);
				((DbParameter)val11).Value = DBNull.Value;
			}
			obj[10] = val11;
			MySqlParameter val12 = new MySqlParameter("@IntID", 3, 11);
			((DbParameter)val12).Value = model.IntID;
			obj[11] = val12;
			MySqlParameter val13 = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val13).Value = model.ID;
			obj[12] = val13;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Delete(Guid id)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Expected O, but got Unknown
			string sql = "DELETE FROM organize WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.Organize> DataReaderToList(MySqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.Organize> list = new List<RoadFlow.Data.Model.Organize>();
			RoadFlow.Data.Model.Organize organize = null;
			while (((DbDataReader)dataReader).Read())
			{
				organize = new RoadFlow.Data.Model.Organize();
				organize.ID = ((DbDataReader)dataReader).GetString(0).ToGuid();
				organize.Name = ((DbDataReader)dataReader).GetString(1);
				organize.Number = ((DbDataReader)dataReader).GetString(2);
				organize.Type = ((DbDataReader)dataReader).GetInt32(3);
				organize.Status = ((DbDataReader)dataReader).GetInt32(4);
				organize.ParentID = ((DbDataReader)dataReader).GetString(5).ToGuid();
				organize.Sort = ((DbDataReader)dataReader).GetInt32(6);
				organize.Depth = ((DbDataReader)dataReader).GetInt32(7);
				organize.ChildsLength = ((DbDataReader)dataReader).GetInt32(8);
				if (!((DbDataReader)dataReader).IsDBNull(9))
				{
					organize.ChargeLeader = ((DbDataReader)dataReader).GetString(9);
				}
				if (!((DbDataReader)dataReader).IsDBNull(10))
				{
					organize.Leader = ((DbDataReader)dataReader).GetString(10);
				}
				if (!((DbDataReader)dataReader).IsDBNull(11))
				{
					organize.Note = ((DbDataReader)dataReader).GetString(11);
				}
				organize.IntID = ((DbDataReader)dataReader).GetInt32(12);
				list.Add(organize);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.Organize> GetAll()
		{
			string sql = "SELECT * FROM organize";
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.Organize> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM organize";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.Organize Get(Guid id)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Expected O, but got Unknown
			string sql = "SELECT * FROM organize WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.Organize> list = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public RoadFlow.Data.Model.Organize GetRoot()
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Expected O, but got Unknown
			//IL_0038: Expected O, but got Unknown
			string sql = "SELECT * FROM Organize WHERE ParentID=@ParentID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ParentID", 253);
			((DbParameter)val).Value = Guid.Empty.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.Organize> list = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public List<RoadFlow.Data.Model.Organize> GetChilds(Guid ID)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Expected O, but got Unknown
			//IL_002a: Expected O, but got Unknown
			string sql = "SELECT * FROM Organize WHERE ParentID=@ParentID ORDER BY Sort";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ParentID", 253);
			((DbParameter)val).Value = ID;
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.Organize> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public int GetMaxSort(Guid id)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Expected O, but got Unknown
			//IL_002a: Expected O, but got Unknown
			string sql = "SELECT IFNULL(MAX(Sort),0)+1 FROM Organize WHERE ParentID=@ParentID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ParentID", 253);
			((DbParameter)val).Value = id;
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.GetFieldValue(sql, parameter).ToInt();
		}

		public int UpdateChildsLength(Guid id, int length)
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Expected O, but got Unknown
			//IL_0026: Expected O, but got Unknown
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Expected O, but got Unknown
			//IL_0044: Expected O, but got Unknown
			string sql = "UPDATE Organize SET ChildsLength=@ChildsLength WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[2];
			MySqlParameter val = new MySqlParameter("@ChildsLength", 3);
			((DbParameter)val).Value = length;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@ID", 253);
			((DbParameter)val2).Value = id;
			obj[1] = val2;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
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
			string sql = "UPDATE Organize SET Sort=@Sort WHERE ID=@ID";
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

		public List<RoadFlow.Data.Model.Organize> GetAllParent(string number)
		{
			string sql = "SELECT * FROM Organize WHERE ID IN(" + Tools.GetSqlInString(number) + ") ORDER BY Depth";
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.Organize> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public List<RoadFlow.Data.Model.Organize> GetAllChild(string number)
		{
			string sql = "SELECT * FROM Organize WHERE Number LIKE '" + number.ReplaceSql() + "%' ORDER BY Sort";
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.Organize> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}
	}
}
