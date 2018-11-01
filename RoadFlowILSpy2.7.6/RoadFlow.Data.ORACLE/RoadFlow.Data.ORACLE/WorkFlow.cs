using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace RoadFlow.Data.ORACLE
{
	public class WorkFlow : IWorkFlow
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.WorkFlow model)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Expected O, but got Unknown
			//IL_002f: Expected O, but got Unknown
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Expected O, but got Unknown
			//IL_004f: Expected O, but got Unknown
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0070: Expected O, but got Unknown
			//IL_0071: Expected O, but got Unknown
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Expected O, but got Unknown
			//IL_0091: Expected O, but got Unknown
			//IL_009f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b0: Expected O, but got Unknown
			//IL_00b1: Expected O, but got Unknown
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Expected O, but got Unknown
			//IL_00d2: Expected O, but got Unknown
			//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f3: Expected O, but got Unknown
			//IL_00f4: Expected O, but got Unknown
			//IL_0105: Unknown result type (might be due to invalid IL or missing references)
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Expected O, but got Unknown
			//IL_011f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0124: Unknown result type (might be due to invalid IL or missing references)
			//IL_012f: Expected O, but got Unknown
			//IL_0130: Expected O, but got Unknown
			//IL_014a: Unknown result type (might be due to invalid IL or missing references)
			//IL_014f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0160: Expected O, but got Unknown
			//IL_016a: Unknown result type (might be due to invalid IL or missing references)
			//IL_016f: Unknown result type (might be due to invalid IL or missing references)
			//IL_017a: Expected O, but got Unknown
			//IL_017b: Expected O, but got Unknown
			//IL_0197: Unknown result type (might be due to invalid IL or missing references)
			//IL_019c: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ad: Expected O, but got Unknown
			//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c8: Expected O, but got Unknown
			//IL_01c9: Expected O, but got Unknown
			//IL_01db: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ec: Expected O, but got Unknown
			//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_0205: Expected O, but got Unknown
			//IL_0206: Expected O, but got Unknown
			//IL_0210: Unknown result type (might be due to invalid IL or missing references)
			//IL_0215: Unknown result type (might be due to invalid IL or missing references)
			//IL_0226: Expected O, but got Unknown
			//IL_0227: Expected O, but got Unknown
			string sql = "INSERT INTO WorkFlow\r\n\t\t\t\t(ID,Name,Type,Manager,InstanceManager,CreateDate,CreateUserID,DesignJSON,InstallDate,InstallUserID,RunJSON,Status) \r\n\t\t\t\tVALUES(:ID,:Name,:Type,:Manager,:InstanceManager,:CreateDate,:CreateUserID,:DesignJSON,:InstallDate,:InstallUserID,:RunJSON,:Status)";
			OracleParameter[] obj = new OracleParameter[12];
			OracleParameter val = new OracleParameter(":ID", 126, 40);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":Name", 119, 1000);
			((DbParameter)val2).Value = model.Name;
			obj[1] = val2;
			OracleParameter val3 = new OracleParameter(":Type", 126, 40);
			((DbParameter)val3).Value = model.Type;
			obj[2] = val3;
			OracleParameter val4 = new OracleParameter(":Manager", 126, 5000);
			((DbParameter)val4).Value = model.Manager;
			obj[3] = val4;
			OracleParameter val5 = new OracleParameter(":InstanceManager", 126, 5000);
			((DbParameter)val5).Value = model.InstanceManager;
			obj[4] = val5;
			OracleParameter val6 = new OracleParameter(":CreateDate", 106, 8);
			((DbParameter)val6).Value = model.CreateDate;
			obj[5] = val6;
			OracleParameter val7 = new OracleParameter(":CreateUserID", 126, 40);
			((DbParameter)val7).Value = model.CreateUserID;
			obj[6] = val7;
			_003F val8;
			if (model.DesignJSON != null)
			{
				val8 = new OracleParameter(":DesignJSON", 105);
				((DbParameter)val8).Value = model.DesignJSON;
			}
			else
			{
				val8 = new OracleParameter(":DesignJSON", 105);
				((DbParameter)val8).Value = DBNull.Value;
			}
			obj[7] = val8;
			_003F val9;
			if (model.InstallDate.HasValue)
			{
				val9 = new OracleParameter(":InstallDate", 106, 8);
				((DbParameter)val9).Value = model.InstallDate;
			}
			else
			{
				val9 = new OracleParameter(":InstallDate", 106, 8);
				((DbParameter)val9).Value = DBNull.Value;
			}
			obj[8] = val9;
			_003F val10;
			if (model.InstallUserID.HasValue)
			{
				val10 = new OracleParameter(":InstallUserID", 126, 40);
				((DbParameter)val10).Value = model.InstallUserID;
			}
			else
			{
				val10 = new OracleParameter(":InstallUserID", 126, 40);
				((DbParameter)val10).Value = DBNull.Value;
			}
			obj[9] = val10;
			_003F val11;
			if (model.RunJSON != null)
			{
				val11 = new OracleParameter(":RunJSON", 105);
				((DbParameter)val11).Value = model.RunJSON;
			}
			else
			{
				val11 = new OracleParameter(":RunJSON", 105);
				((DbParameter)val11).Value = DBNull.Value;
			}
			obj[10] = val11;
			OracleParameter val12 = new OracleParameter(":Status", 112);
			((DbParameter)val12).Value = model.Status;
			obj[11] = val12;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.WorkFlow model)
		{
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Expected O, but got Unknown
			//IL_002d: Expected O, but got Unknown
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Expected O, but got Unknown
			//IL_004f: Expected O, but got Unknown
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Expected O, but got Unknown
			//IL_006f: Expected O, but got Unknown
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Expected O, but got Unknown
			//IL_008f: Expected O, but got Unknown
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Expected O, but got Unknown
			//IL_00b0: Expected O, but got Unknown
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Expected O, but got Unknown
			//IL_00d2: Expected O, but got Unknown
			//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f4: Expected O, but got Unknown
			//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0102: Unknown result type (might be due to invalid IL or missing references)
			//IL_010d: Expected O, but got Unknown
			//IL_010e: Expected O, but got Unknown
			//IL_0128: Unknown result type (might be due to invalid IL or missing references)
			//IL_012d: Unknown result type (might be due to invalid IL or missing references)
			//IL_013e: Expected O, but got Unknown
			//IL_0148: Unknown result type (might be due to invalid IL or missing references)
			//IL_014d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0158: Expected O, but got Unknown
			//IL_0159: Expected O, but got Unknown
			//IL_0174: Unknown result type (might be due to invalid IL or missing references)
			//IL_0179: Unknown result type (might be due to invalid IL or missing references)
			//IL_018a: Expected O, but got Unknown
			//IL_0195: Unknown result type (might be due to invalid IL or missing references)
			//IL_019a: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a5: Expected O, but got Unknown
			//IL_01a6: Expected O, but got Unknown
			//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c9: Expected O, but got Unknown
			//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e2: Expected O, but got Unknown
			//IL_01e3: Expected O, but got Unknown
			//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0203: Expected O, but got Unknown
			//IL_0204: Expected O, but got Unknown
			//IL_0210: Unknown result type (might be due to invalid IL or missing references)
			//IL_0215: Unknown result type (might be due to invalid IL or missing references)
			//IL_0226: Expected O, but got Unknown
			//IL_0227: Expected O, but got Unknown
			string sql = "UPDATE WorkFlow SET \r\n\t\t\t\tName=:Name,Type=:Type,Manager=:Manager,InstanceManager=:InstanceManager,CreateDate=:CreateDate,CreateUserID=:CreateUserID,DesignJSON=:DesignJSON,InstallDate=:InstallDate,InstallUserID=:InstallUserID,RunJSON=:RunJSON,Status=:Status\r\n\t\t\t\tWHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[12];
			OracleParameter val = new OracleParameter(":Name", 119, 1000);
			((DbParameter)val).Value = model.Name;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":Type", 126, 40);
			((DbParameter)val2).Value = model.Type;
			obj[1] = val2;
			OracleParameter val3 = new OracleParameter(":Manager", 126, 5000);
			((DbParameter)val3).Value = model.Manager;
			obj[2] = val3;
			OracleParameter val4 = new OracleParameter(":InstanceManager", 126, 5000);
			((DbParameter)val4).Value = model.InstanceManager;
			obj[3] = val4;
			OracleParameter val5 = new OracleParameter(":CreateDate", 106, 8);
			((DbParameter)val5).Value = model.CreateDate;
			obj[4] = val5;
			OracleParameter val6 = new OracleParameter(":CreateUserID", 126, 40);
			((DbParameter)val6).Value = model.CreateUserID;
			obj[5] = val6;
			_003F val7;
			if (model.DesignJSON != null)
			{
				val7 = new OracleParameter(":DesignJSON", 105);
				((DbParameter)val7).Value = model.DesignJSON;
			}
			else
			{
				val7 = new OracleParameter(":DesignJSON", 105);
				((DbParameter)val7).Value = DBNull.Value;
			}
			obj[6] = val7;
			_003F val8;
			if (model.InstallDate.HasValue)
			{
				val8 = new OracleParameter(":InstallDate", 106, 8);
				((DbParameter)val8).Value = model.InstallDate;
			}
			else
			{
				val8 = new OracleParameter(":InstallDate", 106, 8);
				((DbParameter)val8).Value = DBNull.Value;
			}
			obj[7] = val8;
			_003F val9;
			if (model.InstallUserID.HasValue)
			{
				val9 = new OracleParameter(":InstallUserID", 126, 40);
				((DbParameter)val9).Value = model.InstallUserID;
			}
			else
			{
				val9 = new OracleParameter(":InstallUserID", 126, 40);
				((DbParameter)val9).Value = DBNull.Value;
			}
			obj[8] = val9;
			_003F val10;
			if (model.RunJSON != null)
			{
				val10 = new OracleParameter(":RunJSON", 105);
				((DbParameter)val10).Value = model.RunJSON;
			}
			else
			{
				val10 = new OracleParameter(":RunJSON", 105);
				((DbParameter)val10).Value = DBNull.Value;
			}
			obj[9] = val10;
			OracleParameter val11 = new OracleParameter(":Status", 112);
			((DbParameter)val11).Value = model.Status;
			obj[10] = val11;
			OracleParameter val12 = new OracleParameter(":ID", 126, 40);
			((DbParameter)val12).Value = model.ID;
			obj[11] = val12;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Delete(Guid id)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "DELETE FROM WorkFlow WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.WorkFlow> DataReaderToList(OracleDataReader dataReader)
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
			string sql = "SELECT * FROM WorkFlow";
			OracleDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.WorkFlow> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM WorkFlow";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.WorkFlow Get(Guid id)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "SELECT * FROM WorkFlow WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
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
			OracleDataReader dataReader = dbHelper.GetDataReader(sql);
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
			OracleDataReader dataReader = dbHelper.GetDataReader(sql);
			while (((DbDataReader)dataReader).Read())
			{
				dictionary.Add(((DbDataReader)dataReader).GetString(0).ToGuid(), ((DbDataReader)dataReader).GetString(1));
			}
			((DbDataReader)dataReader).Close();
			return dictionary;
		}

		public List<RoadFlow.Data.Model.WorkFlow> GetByTypes(string typeString)
		{
			string sql = "SELECT * FROM WorkFlow where Type IN(" + Tools.GetSqlInString(typeString) + ")";
			OracleDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.WorkFlow> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public List<RoadFlow.Data.Model.WorkFlow> GetPagerData(out string pager, string query = "", string userid = "", string typeid = "", string name = "", int pagesize = 15)
		{
			//IL_002d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Expected O, but got Unknown
			//IL_003e: Expected O, but got Unknown
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Expected O, but got Unknown
			//IL_006d: Expected O, but got Unknown
			StringBuilder stringBuilder = new StringBuilder("AND Status!=4 ");
			List<OracleParameter> list = new List<OracleParameter>();
			if (!userid.IsNullOrEmpty())
			{
				stringBuilder.Append("AND INSTR(Manager,:Manager,1,1)>0 ");
				List<OracleParameter> list2 = list;
				OracleParameter val = new OracleParameter(":Manager", 126);
				((DbParameter)val).Value = userid;
				list2.Add(val);
			}
			if (!name.IsNullOrEmpty())
			{
				stringBuilder.Append("AND INSTR(Name,:Name,1,1)>0 ");
				List<OracleParameter> list3 = list;
				OracleParameter val2 = new OracleParameter(":Name", 126);
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
			OracleDataReader dataReader = dbHelper.GetDataReader(paerSql, list.ToArray());
			List<RoadFlow.Data.Model.WorkFlow> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public List<RoadFlow.Data.Model.WorkFlow> GetPagerData(out long count, int pageSize, int pageNumber, string userid = "", string typeid = "", string name = "", string order = "")
		{
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_003b: Expected O, but got Unknown
			//IL_0040: Expected O, but got Unknown
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Expected O, but got Unknown
			//IL_006f: Expected O, but got Unknown
			StringBuilder stringBuilder = new StringBuilder("AND Status!=4 ");
			List<OracleParameter> list = new List<OracleParameter>();
			if (!userid.IsNullOrEmpty())
			{
				stringBuilder.Append("AND INSTR(Manager,:Manager,1,1)>0 ");
				List<OracleParameter> list2 = list;
				OracleParameter val = new OracleParameter(":Manager", 126);
				((DbParameter)val).Value = userid;
				list2.Add(val);
			}
			if (!name.IsNullOrEmpty())
			{
				stringBuilder.Append("AND INSTR(Name,:Name,1,1)>0 ");
				List<OracleParameter> list3 = list;
				OracleParameter val2 = new OracleParameter(":Name", 126);
				((DbParameter)val2).Value = name;
				list3.Add(val2);
			}
			if (!typeid.IsNullOrEmpty())
			{
				stringBuilder.Append("AND Type IN (" + Tools.GetSqlInString(typeid) + ")");
			}
			string paerSql = dbHelper.GetPaerSql("WorkFlow", "ID,Name,Type,Manager,InstanceManager,CreateDate,CreateUserID,'' DesignJSON,InstallDate,InstallUserID,'' RunJSON,Status", stringBuilder.ToString(), order.IsNullOrEmpty() ? "CreateDate DESC" : order, pageSize, pageNumber, out count, list.ToArray());
			OracleDataReader dataReader = dbHelper.GetDataReader(paerSql, list.ToArray());
			List<RoadFlow.Data.Model.WorkFlow> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}
	}
}
