using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace RoadFlow.Data.MySql
{
	public class WorkFlow : IWorkFlow
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.WorkFlow model)
		{
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0032: Expected O, but got Unknown
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Expected O, but got Unknown
			//IL_0051: Expected O, but got Unknown
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			//IL_0075: Expected O, but got Unknown
			//IL_0076: Expected O, but got Unknown
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Expected O, but got Unknown
			//IL_0095: Expected O, but got Unknown
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b3: Expected O, but got Unknown
			//IL_00b4: Expected O, but got Unknown
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d4: Expected O, but got Unknown
			//IL_00d5: Expected O, but got Unknown
			//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f9: Expected O, but got Unknown
			//IL_00fa: Expected O, but got Unknown
			//IL_010f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0114: Unknown result type (might be due to invalid IL or missing references)
			//IL_0120: Expected O, but got Unknown
			//IL_012d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0132: Unknown result type (might be due to invalid IL or missing references)
			//IL_013d: Expected O, but got Unknown
			//IL_013e: Expected O, but got Unknown
			//IL_0158: Unknown result type (might be due to invalid IL or missing references)
			//IL_015d: Unknown result type (might be due to invalid IL or missing references)
			//IL_016e: Expected O, but got Unknown
			//IL_0178: Unknown result type (might be due to invalid IL or missing references)
			//IL_017d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0188: Expected O, but got Unknown
			//IL_0189: Expected O, but got Unknown
			//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_01be: Expected O, but got Unknown
			//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01dc: Expected O, but got Unknown
			//IL_01dd: Expected O, but got Unknown
			//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0204: Expected O, but got Unknown
			//IL_0211: Unknown result type (might be due to invalid IL or missing references)
			//IL_0216: Unknown result type (might be due to invalid IL or missing references)
			//IL_0221: Expected O, but got Unknown
			//IL_0222: Expected O, but got Unknown
			//IL_022d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0232: Unknown result type (might be due to invalid IL or missing references)
			//IL_0243: Expected O, but got Unknown
			//IL_0244: Expected O, but got Unknown
			string sql = "INSERT INTO workflow\r\n\t\t\t\t(ID,Name,Type,Manager,InstanceManager,CreateDate,CreateUserID,DesignJSON,InstallDate,InstallUserID,RunJSON,Status) \r\n\t\t\t\tVALUES(@ID,@Name,@Type,@Manager,@InstanceManager,@CreateDate,@CreateUserID,@DesignJSON,@InstallDate,@InstallUserID,@RunJSON,@Status)";
			MySqlParameter[] obj = new MySqlParameter[12];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@Name", 752, -1);
			((DbParameter)val2).Value = model.Name;
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@Type", 253, 36);
			((DbParameter)val3).Value = model.Type;
			obj[2] = val3;
			MySqlParameter val4 = new MySqlParameter("@Manager", 752, -1);
			((DbParameter)val4).Value = model.Manager;
			obj[3] = val4;
			MySqlParameter val5 = new MySqlParameter("@InstanceManager", 752, -1);
			((DbParameter)val5).Value = model.InstanceManager;
			obj[4] = val5;
			MySqlParameter val6 = new MySqlParameter("@CreateDate", 12, -1);
			((DbParameter)val6).Value = model.CreateDate;
			obj[5] = val6;
			MySqlParameter val7 = new MySqlParameter("@CreateUserID", 253, 36);
			((DbParameter)val7).Value = model.CreateUserID;
			obj[6] = val7;
			_003F val8;
			if (model.DesignJSON != null)
			{
				val8 = new MySqlParameter("@DesignJSON", 751, -1);
				((DbParameter)val8).Value = model.DesignJSON;
			}
			else
			{
				val8 = new MySqlParameter("@DesignJSON", 751, -1);
				((DbParameter)val8).Value = DBNull.Value;
			}
			obj[7] = val8;
			_003F val9;
			if (model.InstallDate.HasValue)
			{
				val9 = new MySqlParameter("@InstallDate", 12, -1);
				((DbParameter)val9).Value = model.InstallDate;
			}
			else
			{
				val9 = new MySqlParameter("@InstallDate", 12, -1);
				((DbParameter)val9).Value = DBNull.Value;
			}
			obj[8] = val9;
			_003F val10;
			if (model.InstallUserID.HasValue)
			{
				val10 = new MySqlParameter("@InstallUserID", 253, 36);
				((DbParameter)val10).Value = model.InstallUserID;
			}
			else
			{
				val10 = new MySqlParameter("@InstallUserID", 253, 36);
				((DbParameter)val10).Value = DBNull.Value;
			}
			obj[9] = val10;
			_003F val11;
			if (model.RunJSON != null)
			{
				val11 = new MySqlParameter("@RunJSON", 751, -1);
				((DbParameter)val11).Value = model.RunJSON;
			}
			else
			{
				val11 = new MySqlParameter("@RunJSON", 751, -1);
				((DbParameter)val11).Value = DBNull.Value;
			}
			obj[10] = val11;
			MySqlParameter val12 = new MySqlParameter("@Status", 3, 11);
			((DbParameter)val12).Value = model.Status;
			obj[11] = val12;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.WorkFlow model)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Expected O, but got Unknown
			//IL_002c: Expected O, but got Unknown
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Expected O, but got Unknown
			//IL_0051: Expected O, but got Unknown
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Expected O, but got Unknown
			//IL_0070: Expected O, but got Unknown
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Expected O, but got Unknown
			//IL_008f: Expected O, but got Unknown
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Expected O, but got Unknown
			//IL_00b0: Expected O, but got Unknown
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d4: Expected O, but got Unknown
			//IL_00d5: Expected O, but got Unknown
			//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fb: Expected O, but got Unknown
			//IL_0108: Unknown result type (might be due to invalid IL or missing references)
			//IL_010d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0118: Expected O, but got Unknown
			//IL_0119: Expected O, but got Unknown
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			//IL_0149: Expected O, but got Unknown
			//IL_0153: Unknown result type (might be due to invalid IL or missing references)
			//IL_0158: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Expected O, but got Unknown
			//IL_0164: Expected O, but got Unknown
			//IL_0182: Unknown result type (might be due to invalid IL or missing references)
			//IL_0187: Unknown result type (might be due to invalid IL or missing references)
			//IL_0198: Expected O, but got Unknown
			//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b6: Expected O, but got Unknown
			//IL_01b7: Expected O, but got Unknown
			//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01de: Expected O, but got Unknown
			//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fb: Expected O, but got Unknown
			//IL_01fc: Expected O, but got Unknown
			//IL_0207: Unknown result type (might be due to invalid IL or missing references)
			//IL_020c: Unknown result type (might be due to invalid IL or missing references)
			//IL_021d: Expected O, but got Unknown
			//IL_021e: Expected O, but got Unknown
			//IL_022d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0232: Unknown result type (might be due to invalid IL or missing references)
			//IL_0243: Expected O, but got Unknown
			//IL_0244: Expected O, but got Unknown
			string sql = "UPDATE workflow SET \r\n\t\t\t\tName=@Name,Type=@Type,Manager=@Manager,InstanceManager=@InstanceManager,CreateDate=@CreateDate,CreateUserID=@CreateUserID,DesignJSON=@DesignJSON,InstallDate=@InstallDate,InstallUserID=@InstallUserID,RunJSON=@RunJSON,Status=@Status\r\n\t\t\t\tWHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[12];
			MySqlParameter val = new MySqlParameter("@Name", 752, -1);
			((DbParameter)val).Value = model.Name;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@Type", 253, 36);
			((DbParameter)val2).Value = model.Type;
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@Manager", 752, -1);
			((DbParameter)val3).Value = model.Manager;
			obj[2] = val3;
			MySqlParameter val4 = new MySqlParameter("@InstanceManager", 752, -1);
			((DbParameter)val4).Value = model.InstanceManager;
			obj[3] = val4;
			MySqlParameter val5 = new MySqlParameter("@CreateDate", 12, -1);
			((DbParameter)val5).Value = model.CreateDate;
			obj[4] = val5;
			MySqlParameter val6 = new MySqlParameter("@CreateUserID", 253, 36);
			((DbParameter)val6).Value = model.CreateUserID;
			obj[5] = val6;
			_003F val7;
			if (model.DesignJSON != null)
			{
				val7 = new MySqlParameter("@DesignJSON", 751, -1);
				((DbParameter)val7).Value = model.DesignJSON;
			}
			else
			{
				val7 = new MySqlParameter("@DesignJSON", 751, -1);
				((DbParameter)val7).Value = DBNull.Value;
			}
			obj[6] = val7;
			_003F val8;
			if (model.InstallDate.HasValue)
			{
				val8 = new MySqlParameter("@InstallDate", 12, -1);
				((DbParameter)val8).Value = model.InstallDate;
			}
			else
			{
				val8 = new MySqlParameter("@InstallDate", 12, -1);
				((DbParameter)val8).Value = DBNull.Value;
			}
			obj[7] = val8;
			_003F val9;
			if (model.InstallUserID.HasValue)
			{
				val9 = new MySqlParameter("@InstallUserID", 253, 36);
				((DbParameter)val9).Value = model.InstallUserID;
			}
			else
			{
				val9 = new MySqlParameter("@InstallUserID", 253, 36);
				((DbParameter)val9).Value = DBNull.Value;
			}
			obj[8] = val9;
			_003F val10;
			if (model.RunJSON != null)
			{
				val10 = new MySqlParameter("@RunJSON", 751, -1);
				((DbParameter)val10).Value = model.RunJSON;
			}
			else
			{
				val10 = new MySqlParameter("@RunJSON", 751, -1);
				((DbParameter)val10).Value = DBNull.Value;
			}
			obj[9] = val10;
			MySqlParameter val11 = new MySqlParameter("@Status", 3, 11);
			((DbParameter)val11).Value = model.Status;
			obj[10] = val11;
			MySqlParameter val12 = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val12).Value = model.ID;
			obj[11] = val12;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Delete(Guid id)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Expected O, but got Unknown
			string sql = "DELETE FROM workflow WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.WorkFlow> DataReaderToList(MySqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.WorkFlow> list = new List<RoadFlow.Data.Model.WorkFlow>();
			RoadFlow.Data.Model.WorkFlow workFlow = null;
			while (((DbDataReader)dataReader).Read())
			{
				workFlow = new RoadFlow.Data.Model.WorkFlow();
				workFlow.ID = ((DbDataReader)dataReader).GetString(0).ToGuid();
				workFlow.Name = ((DbDataReader)dataReader).GetString(1);
				workFlow.Type = ((DbDataReader)dataReader).GetString(2).ToGuid();
				workFlow.Manager = ((DbDataReader)dataReader).GetString(3);
				workFlow.InstanceManager = ((DbDataReader)dataReader).GetString(4);
				workFlow.CreateDate = ((DbDataReader)dataReader).GetDateTime(5);
				workFlow.CreateUserID = ((DbDataReader)dataReader).GetString(6).ToGuid();
				if (!((DbDataReader)dataReader).IsDBNull(7))
				{
					workFlow.DesignJSON = ((DbDataReader)dataReader).GetString(7);
				}
				if (!((DbDataReader)dataReader).IsDBNull(8))
				{
					workFlow.InstallDate = ((DbDataReader)dataReader).GetDateTime(8);
				}
				if (!((DbDataReader)dataReader).IsDBNull(9))
				{
					workFlow.InstallUserID = ((DbDataReader)dataReader).GetString(9).ToGuid();
				}
				if (!((DbDataReader)dataReader).IsDBNull(10))
				{
					workFlow.RunJSON = ((DbDataReader)dataReader).GetString(10);
				}
				workFlow.Status = ((DbDataReader)dataReader).GetInt32(11);
				list.Add(workFlow);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.WorkFlow> GetAll()
		{
			string sql = "SELECT * FROM workflow";
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.WorkFlow> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM workflow";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.WorkFlow Get(Guid id)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Expected O, but got Unknown
			string sql = "SELECT * FROM workflow WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.WorkFlow> list = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public List<string> GetAllTypes()
		{
			string sql = "SELECT Type FROM WorkFlow GROUP BY Type";
			List<string> list = new List<string>();
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql);
			while (((DbDataReader)dataReader).Read())
			{
				list.Add(((DbDataReader)dataReader).GetString(0));
			}
			((DbDataReader)dataReader).Close();
			return list;
		}

		public Dictionary<Guid, string> GetAllIDAndName()
		{
			string sql = "SELECT ID,Name FROM WorkFlow WHERE Status<4 ORDER BY Name";
			Dictionary<Guid, string> dictionary = new Dictionary<Guid, string>();
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql);
			while (((DbDataReader)dataReader).Read())
			{
				dictionary.Add(((DbDataReader)dataReader).GetGuid(0), ((DbDataReader)dataReader).GetString(1));
			}
			((DbDataReader)dataReader).Close();
			return dictionary;
		}

		public List<RoadFlow.Data.Model.WorkFlow> GetByTypes(string typeString)
		{
			string sql = "SELECT * FROM WorkFlow where Type IN(" + Tools.GetSqlInString(typeString) + ")";
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.WorkFlow> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public List<RoadFlow.Data.Model.WorkFlow> GetPagerData(out string pager, string query = "", string userid = "", string typeid = "", string name = "", int pagesize = 15)
		{
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Expected O, but got Unknown
			//IL_0041: Expected O, but got Unknown
			//IL_0061: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Expected O, but got Unknown
			//IL_0073: Expected O, but got Unknown
			StringBuilder stringBuilder = new StringBuilder("AND Status<>4 ");
			List<MySqlParameter> list = new List<MySqlParameter>();
			if (!userid.IsNullOrEmpty())
			{
				stringBuilder.Append("AND INSTR(Manager,@Manager)>0 ");
				List<MySqlParameter> list2 = list;
				MySqlParameter val = new MySqlParameter("@Manager", 253);
				((DbParameter)val).Value = userid;
				list2.Add(val);
			}
			if (!name.IsNullOrEmpty())
			{
				stringBuilder.Append("AND INSTR(Name,@Name)>0 ");
				List<MySqlParameter> list3 = list;
				MySqlParameter val2 = new MySqlParameter("@Name", 253);
				((DbParameter)val2).Value = name;
				list3.Add(val2);
			}
			if (!typeid.IsNullOrEmpty())
			{
				stringBuilder.Append("AND Type IN (" + Tools.GetSqlInString(typeid) + ")");
			}
			int pageNumber = Tools.GetPageNumber();
			long count;
			string paerSql = dbHelper.GetPaerSql("WorkFlow", "ID,Name,Type,Manager,InstanceManager,CreateDate,CreateUserID,'' DesignJSON,InstallDate,InstallUserID,'' RunJSON,Status", stringBuilder.ToString(), "CreateDate DESC", pagesize, pageNumber, out count, list.ToArray());
			pager = Tools.GetPagerHtml(count, pagesize, pageNumber, query);
			MySqlDataReader dataReader = dbHelper.GetDataReader(paerSql, list.ToArray());
			List<RoadFlow.Data.Model.WorkFlow> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public List<RoadFlow.Data.Model.WorkFlow> GetPagerData(out long count, int pageSize, int pageNumber, string userid = "", string typeid = "", string name = "", string order = "")
		{
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Expected O, but got Unknown
			//IL_0043: Expected O, but got Unknown
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_0070: Expected O, but got Unknown
			//IL_0075: Expected O, but got Unknown
			StringBuilder stringBuilder = new StringBuilder("AND Status<>4 ");
			List<MySqlParameter> list = new List<MySqlParameter>();
			if (!userid.IsNullOrEmpty())
			{
				stringBuilder.Append("AND INSTR(Manager,@Manager)>0 ");
				List<MySqlParameter> list2 = list;
				MySqlParameter val = new MySqlParameter("@Manager", 253);
				((DbParameter)val).Value = userid;
				list2.Add(val);
			}
			if (!name.IsNullOrEmpty())
			{
				stringBuilder.Append("AND INSTR(Name,@Name)>0 ");
				List<MySqlParameter> list3 = list;
				MySqlParameter val2 = new MySqlParameter("@Name", 253);
				((DbParameter)val2).Value = name;
				list3.Add(val2);
			}
			if (!typeid.IsNullOrEmpty())
			{
				stringBuilder.Append("AND Type IN (" + Tools.GetSqlInString(typeid) + ")");
			}
			string paerSql = dbHelper.GetPaerSql("WorkFlow", "ID,Name,Type,Manager,InstanceManager,CreateDate,CreateUserID,'' DesignJSON,InstallDate,InstallUserID,'' RunJSON,Status", stringBuilder.ToString(), order.IsNullOrEmpty() ? "CreateDate DESC" : order, pageSize, pageNumber, out count, list.ToArray());
			MySqlDataReader dataReader = dbHelper.GetDataReader(paerSql, list.ToArray());
			List<RoadFlow.Data.Model.WorkFlow> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}
	}
}
