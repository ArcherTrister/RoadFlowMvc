using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace RoadFlow.Data.ORACLE
{
	public class Organize : IOrganize
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.Organize model)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Expected O, but got Unknown
			//IL_002f: Expected O, but got Unknown
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Expected O, but got Unknown
			//IL_004f: Expected O, but got Unknown
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Expected O, but got Unknown
			//IL_006f: Expected O, but got Unknown
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Expected O, but got Unknown
			//IL_008f: Expected O, but got Unknown
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			//IL_009d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Expected O, but got Unknown
			//IL_00af: Expected O, but got Unknown
			//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d0: Expected O, but got Unknown
			//IL_00d1: Expected O, but got Unknown
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_00df: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f0: Expected O, but got Unknown
			//IL_00f1: Expected O, but got Unknown
			//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0110: Expected O, but got Unknown
			//IL_0111: Expected O, but got Unknown
			//IL_011a: Unknown result type (might be due to invalid IL or missing references)
			//IL_011f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0130: Expected O, but got Unknown
			//IL_0131: Expected O, but got Unknown
			//IL_0148: Unknown result type (might be due to invalid IL or missing references)
			//IL_014d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0159: Expected O, but got Unknown
			//IL_0167: Unknown result type (might be due to invalid IL or missing references)
			//IL_016c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0177: Expected O, but got Unknown
			//IL_0178: Expected O, but got Unknown
			//IL_018f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0194: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a0: Expected O, but got Unknown
			//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01be: Expected O, but got Unknown
			//IL_01bf: Expected O, but got Unknown
			//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e2: Expected O, but got Unknown
			//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fb: Expected O, but got Unknown
			//IL_01fc: Expected O, but got Unknown
			//IL_0206: Unknown result type (might be due to invalid IL or missing references)
			//IL_020b: Unknown result type (might be due to invalid IL or missing references)
			//IL_021c: Expected O, but got Unknown
			//IL_021d: Expected O, but got Unknown
			string sql = "INSERT INTO Organize\r\n\t\t\t\t(ID,Name,Number1,Type,Status,ParentID,Sort,Depth,ChildsLength,ChargeLeader,Leader,Note,IntID) \r\n\t\t\t\tVALUES(:ID,:Name,:Number1,:Type,:Status,:ParentID,:Sort,:Depth,:ChildsLength,:ChargeLeader,:Leader,:Note,:IntID)";
			OracleParameter[] obj = new OracleParameter[13];
			OracleParameter val = new OracleParameter(":ID", 126, 40);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":Name", 126, 2000);
			((DbParameter)val2).Value = model.Name;
			obj[1] = val2;
			OracleParameter val3 = new OracleParameter(":Number1", 126, 900);
			((DbParameter)val3).Value = model.Number;
			obj[2] = val3;
			OracleParameter val4 = new OracleParameter(":Type", 112);
			((DbParameter)val4).Value = model.Type;
			obj[3] = val4;
			OracleParameter val5 = new OracleParameter(":Status", 112);
			((DbParameter)val5).Value = model.Status;
			obj[4] = val5;
			OracleParameter val6 = new OracleParameter(":ParentID", 126, 40);
			((DbParameter)val6).Value = model.ParentID;
			obj[5] = val6;
			OracleParameter val7 = new OracleParameter(":Sort", 112);
			((DbParameter)val7).Value = model.Sort;
			obj[6] = val7;
			OracleParameter val8 = new OracleParameter(":Depth", 112);
			((DbParameter)val8).Value = model.Depth;
			obj[7] = val8;
			OracleParameter val9 = new OracleParameter(":ChildsLength", 112);
			((DbParameter)val9).Value = model.ChildsLength;
			obj[8] = val9;
			_003F val10;
			if (model.ChargeLeader != null)
			{
				val10 = new OracleParameter(":ChargeLeader", 126, 200);
				((DbParameter)val10).Value = model.ChargeLeader;
			}
			else
			{
				val10 = new OracleParameter(":ChargeLeader", 126, 200);
				((DbParameter)val10).Value = DBNull.Value;
			}
			obj[9] = val10;
			_003F val11;
			if (model.Leader != null)
			{
				val11 = new OracleParameter(":Leader", 126, 200);
				((DbParameter)val11).Value = model.Leader;
			}
			else
			{
				val11 = new OracleParameter(":Leader", 126, 200);
				((DbParameter)val11).Value = DBNull.Value;
			}
			obj[10] = val11;
			_003F val12;
			if (model.Note != null)
			{
				val12 = new OracleParameter(":Note", 119);
				((DbParameter)val12).Value = model.Note;
			}
			else
			{
				val12 = new OracleParameter(":Note", 119);
				((DbParameter)val12).Value = DBNull.Value;
			}
			obj[11] = val12;
			OracleParameter val13 = new OracleParameter(":IntID", 112);
			((DbParameter)val13).Value = model.IntID;
			obj[12] = val13;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.Organize model)
		{
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Expected O, but got Unknown
			//IL_002d: Expected O, but got Unknown
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Expected O, but got Unknown
			//IL_004d: Expected O, but got Unknown
			//IL_0056: Unknown result type (might be due to invalid IL or missing references)
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Expected O, but got Unknown
			//IL_006d: Expected O, but got Unknown
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Expected O, but got Unknown
			//IL_008d: Expected O, but got Unknown
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			//IL_009d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Expected O, but got Unknown
			//IL_00af: Expected O, but got Unknown
			//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ce: Expected O, but got Unknown
			//IL_00cf: Expected O, but got Unknown
			//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ee: Expected O, but got Unknown
			//IL_00ef: Expected O, but got Unknown
			//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_010e: Expected O, but got Unknown
			//IL_010f: Expected O, but got Unknown
			//IL_0125: Unknown result type (might be due to invalid IL or missing references)
			//IL_012a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0136: Expected O, but got Unknown
			//IL_0144: Unknown result type (might be due to invalid IL or missing references)
			//IL_0149: Unknown result type (might be due to invalid IL or missing references)
			//IL_0154: Expected O, but got Unknown
			//IL_0155: Expected O, but got Unknown
			//IL_016c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0171: Unknown result type (might be due to invalid IL or missing references)
			//IL_017d: Expected O, but got Unknown
			//IL_018b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0190: Unknown result type (might be due to invalid IL or missing references)
			//IL_019b: Expected O, but got Unknown
			//IL_019c: Expected O, but got Unknown
			//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bf: Expected O, but got Unknown
			//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d8: Expected O, but got Unknown
			//IL_01d9: Expected O, but got Unknown
			//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f9: Expected O, but got Unknown
			//IL_01fa: Expected O, but got Unknown
			//IL_0206: Unknown result type (might be due to invalid IL or missing references)
			//IL_020b: Unknown result type (might be due to invalid IL or missing references)
			//IL_021c: Expected O, but got Unknown
			//IL_021d: Expected O, but got Unknown
			string sql = "UPDATE Organize SET \r\n\t\t\t\tName=:Name,Number1=:Number1,Type=:Type,Status=:Status,ParentID=:ParentID,Sort=:Sort,Depth=:Depth,ChildsLength=:ChildsLength,ChargeLeader=:ChargeLeader,Leader=:Leader,Note=:Note,IntID=:IntID\r\n\t\t\t\tWHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[13];
			OracleParameter val = new OracleParameter(":Name", 126, 2000);
			((DbParameter)val).Value = model.Name;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":Number1", 126, 900);
			((DbParameter)val2).Value = model.Number;
			obj[1] = val2;
			OracleParameter val3 = new OracleParameter(":Type", 112);
			((DbParameter)val3).Value = model.Type;
			obj[2] = val3;
			OracleParameter val4 = new OracleParameter(":Status", 112);
			((DbParameter)val4).Value = model.Status;
			obj[3] = val4;
			OracleParameter val5 = new OracleParameter(":ParentID", 126, 40);
			((DbParameter)val5).Value = model.ParentID;
			obj[4] = val5;
			OracleParameter val6 = new OracleParameter(":Sort", 112);
			((DbParameter)val6).Value = model.Sort;
			obj[5] = val6;
			OracleParameter val7 = new OracleParameter(":Depth", 112);
			((DbParameter)val7).Value = model.Depth;
			obj[6] = val7;
			OracleParameter val8 = new OracleParameter(":ChildsLength", 112);
			((DbParameter)val8).Value = model.ChildsLength;
			obj[7] = val8;
			_003F val9;
			if (model.ChargeLeader != null)
			{
				val9 = new OracleParameter(":ChargeLeader", 126, 200);
				((DbParameter)val9).Value = model.ChargeLeader;
			}
			else
			{
				val9 = new OracleParameter(":ChargeLeader", 126, 200);
				((DbParameter)val9).Value = DBNull.Value;
			}
			obj[8] = val9;
			_003F val10;
			if (model.Leader != null)
			{
				val10 = new OracleParameter(":Leader", 126, 200);
				((DbParameter)val10).Value = model.Leader;
			}
			else
			{
				val10 = new OracleParameter(":Leader", 126, 200);
				((DbParameter)val10).Value = DBNull.Value;
			}
			obj[9] = val10;
			_003F val11;
			if (model.Note != null)
			{
				val11 = new OracleParameter(":Note", 119);
				((DbParameter)val11).Value = model.Note;
			}
			else
			{
				val11 = new OracleParameter(":Note", 119);
				((DbParameter)val11).Value = DBNull.Value;
			}
			obj[10] = val11;
			OracleParameter val12 = new OracleParameter(":IntID", 112);
			((DbParameter)val12).Value = model.IntID;
			obj[11] = val12;
			OracleParameter val13 = new OracleParameter(":ID", 126, 40);
			((DbParameter)val13).Value = model.ID;
			obj[12] = val13;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Delete(Guid id)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "DELETE FROM Organize WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.Organize> DataReaderToList(OracleDataReader dataReader)
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
			string sql = "SELECT * FROM Organize";
			OracleDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.Organize> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM Organize";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.Organize Get(Guid id)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "SELECT * FROM Organize WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
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
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Expected O, but got Unknown
			//IL_002b: Expected O, but got Unknown
			string sql = "SELECT * FROM Organize WHERE ParentID=:ParentID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ParentID", 126);
			((DbParameter)val).Value = Guid.Empty;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
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
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "SELECT * FROM Organize WHERE ParentID=:ParentID ORDER BY Sort";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ParentID", 126);
			((DbParameter)val).Value = ID;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.Organize> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public int GetMaxSort(Guid id)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "SELECT nvl(MAX(Sort),0)+1 FROM Organize WHERE ParentID=:ParentID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ParentID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.GetFieldValue(sql, parameter).ToInt();
		}

		public int UpdateChildsLength(Guid id, int length)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Expected O, but got Unknown
			//IL_0042: Expected O, but got Unknown
			string sql = "UPDATE Organize SET ChildsLength=:ChildsLength WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[2];
			OracleParameter val = new OracleParameter(":ChildsLength", 112);
			((DbParameter)val).Value = length;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":ID", 126);
			((DbParameter)val2).Value = id;
			obj[1] = val2;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int UpdateSort(Guid id, int sort)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Expected O, but got Unknown
			//IL_0042: Expected O, but got Unknown
			string sql = "UPDATE Organize SET Sort=:Sort WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[2];
			OracleParameter val = new OracleParameter(":Sort", 112);
			((DbParameter)val).Value = sort;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":ID", 126);
			((DbParameter)val2).Value = id;
			obj[1] = val2;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public List<RoadFlow.Data.Model.Organize> GetAllParent(string number)
		{
			string sql = "SELECT * FROM Organize WHERE ID IN(" + Tools.GetSqlInString(number) + ") ORDER BY Depth";
			OracleDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.Organize> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public List<RoadFlow.Data.Model.Organize> GetAllChild(string number)
		{
			string sql = "SELECT * FROM Organize WHERE NUMBER1 LIKE '" + number.ReplaceSql() + "%' ORDER BY Sort";
			OracleDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.Organize> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}
	}
}
