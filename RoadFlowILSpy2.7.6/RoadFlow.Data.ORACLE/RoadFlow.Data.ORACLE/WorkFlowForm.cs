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
	public class WorkFlowForm : IWorkFlowForm
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.WorkFlowForm model)
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
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Expected O, but got Unknown
			//IL_0093: Expected O, but got Unknown
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Expected O, but got Unknown
			//IL_00b0: Expected O, but got Unknown
			//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d0: Expected O, but got Unknown
			//IL_00d1: Expected O, but got Unknown
			//IL_00db: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f1: Expected O, but got Unknown
			//IL_00f2: Expected O, but got Unknown
			//IL_0103: Unknown result type (might be due to invalid IL or missing references)
			//IL_0108: Unknown result type (might be due to invalid IL or missing references)
			//IL_0114: Expected O, but got Unknown
			//IL_011d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0122: Unknown result type (might be due to invalid IL or missing references)
			//IL_012d: Expected O, but got Unknown
			//IL_012e: Expected O, but got Unknown
			//IL_013f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0144: Unknown result type (might be due to invalid IL or missing references)
			//IL_0150: Expected O, but got Unknown
			//IL_0159: Unknown result type (might be due to invalid IL or missing references)
			//IL_015e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0169: Expected O, but got Unknown
			//IL_016a: Expected O, but got Unknown
			//IL_017c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_018d: Expected O, but got Unknown
			//IL_0196: Unknown result type (might be due to invalid IL or missing references)
			//IL_019b: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a6: Expected O, but got Unknown
			//IL_01a7: Expected O, but got Unknown
			//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01be: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ca: Expected O, but got Unknown
			//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e3: Expected O, but got Unknown
			//IL_01e4: Expected O, but got Unknown
			//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0204: Expected O, but got Unknown
			//IL_0205: Expected O, but got Unknown
			string sql = "INSERT INTO WorkFlowForm\r\n\t\t\t\t(ID,Name,Type,CreateUserID,CreateUserName,CreateTime,LastModifyTime,Html,SubTableJson,EventsJson,Attribute,Status) \r\n\t\t\t\tVALUES(:ID,:Name,:Type,:CreateUserID,:CreateUserName,:CreateTime,:LastModifyTime,:Html,:SubTableJson,:EventsJson,:Attribute,:Status)";
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
			OracleParameter val4 = new OracleParameter(":CreateUserID", 126, 40);
			((DbParameter)val4).Value = model.CreateUserID;
			obj[3] = val4;
			OracleParameter val5 = new OracleParameter(":CreateUserName", 119, 100);
			((DbParameter)val5).Value = model.CreateUserName;
			obj[4] = val5;
			OracleParameter val6 = new OracleParameter(":CreateTime", 106, 8);
			((DbParameter)val6).Value = model.CreateTime;
			obj[5] = val6;
			OracleParameter val7 = new OracleParameter(":LastModifyTime", 106, 8);
			((DbParameter)val7).Value = model.LastModifyTime;
			obj[6] = val7;
			_003F val8;
			if (model.Html != null)
			{
				val8 = new OracleParameter(":Html", 105);
				((DbParameter)val8).Value = model.Html;
			}
			else
			{
				val8 = new OracleParameter(":Html", 105);
				((DbParameter)val8).Value = DBNull.Value;
			}
			obj[7] = val8;
			_003F val9;
			if (model.SubTableJson != null)
			{
				val9 = new OracleParameter(":SubTableJson", 105);
				((DbParameter)val9).Value = model.SubTableJson;
			}
			else
			{
				val9 = new OracleParameter(":SubTableJson", 105);
				((DbParameter)val9).Value = DBNull.Value;
			}
			obj[8] = val9;
			_003F val10;
			if (model.EventsJson != null)
			{
				val10 = new OracleParameter(":EventsJson", 105);
				((DbParameter)val10).Value = model.EventsJson;
			}
			else
			{
				val10 = new OracleParameter(":EventsJson", 105);
				((DbParameter)val10).Value = DBNull.Value;
			}
			obj[9] = val10;
			_003F val11;
			if (model.Attribute != null)
			{
				val11 = new OracleParameter(":Attribute", 105);
				((DbParameter)val11).Value = model.Attribute;
			}
			else
			{
				val11 = new OracleParameter(":Attribute", 105);
				((DbParameter)val11).Value = DBNull.Value;
			}
			obj[10] = val11;
			OracleParameter val12 = new OracleParameter(":Status", 112);
			((DbParameter)val12).Value = model.Status;
			obj[11] = val12;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.WorkFlowForm model)
		{
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Expected O, but got Unknown
			//IL_002d: Expected O, but got Unknown
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Expected O, but got Unknown
			//IL_004f: Expected O, but got Unknown
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0070: Expected O, but got Unknown
			//IL_0071: Expected O, but got Unknown
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_008d: Expected O, but got Unknown
			//IL_008e: Expected O, but got Unknown
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			//IL_009d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Expected O, but got Unknown
			//IL_00af: Expected O, but got Unknown
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Expected O, but got Unknown
			//IL_00d0: Expected O, but got Unknown
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f2: Expected O, but got Unknown
			//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0100: Unknown result type (might be due to invalid IL or missing references)
			//IL_010b: Expected O, but got Unknown
			//IL_010c: Expected O, but got Unknown
			//IL_011d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0122: Unknown result type (might be due to invalid IL or missing references)
			//IL_012e: Expected O, but got Unknown
			//IL_0137: Unknown result type (might be due to invalid IL or missing references)
			//IL_013c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0147: Expected O, but got Unknown
			//IL_0148: Expected O, but got Unknown
			//IL_0159: Unknown result type (might be due to invalid IL or missing references)
			//IL_015e: Unknown result type (might be due to invalid IL or missing references)
			//IL_016a: Expected O, but got Unknown
			//IL_0173: Unknown result type (might be due to invalid IL or missing references)
			//IL_0178: Unknown result type (might be due to invalid IL or missing references)
			//IL_0183: Expected O, but got Unknown
			//IL_0184: Expected O, but got Unknown
			//IL_0196: Unknown result type (might be due to invalid IL or missing references)
			//IL_019b: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a7: Expected O, but got Unknown
			//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c0: Expected O, but got Unknown
			//IL_01c1: Expected O, but got Unknown
			//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e1: Expected O, but got Unknown
			//IL_01e2: Expected O, but got Unknown
			//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0204: Expected O, but got Unknown
			//IL_0205: Expected O, but got Unknown
			string sql = "UPDATE WorkFlowForm SET \r\n\t\t\t\tName=:Name,Type=:Type,CreateUserID=:CreateUserID,CreateUserName=:CreateUserName,CreateTime=:CreateTime,LastModifyTime=:LastModifyTime,Html=:Html,SubTableJson=:SubTableJson,EventsJson=:EventsJson,Attribute=:Attribute,Status=:Status\r\n\t\t\t\tWHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[12];
			OracleParameter val = new OracleParameter(":Name", 119, 1000);
			((DbParameter)val).Value = model.Name;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":Type", 126, 40);
			((DbParameter)val2).Value = model.Type;
			obj[1] = val2;
			OracleParameter val3 = new OracleParameter(":CreateUserID", 126, 40);
			((DbParameter)val3).Value = model.CreateUserID;
			obj[2] = val3;
			OracleParameter val4 = new OracleParameter(":CreateUserName", 119, 100);
			((DbParameter)val4).Value = model.CreateUserName;
			obj[3] = val4;
			OracleParameter val5 = new OracleParameter(":CreateTime", 106, 8);
			((DbParameter)val5).Value = model.CreateTime;
			obj[4] = val5;
			OracleParameter val6 = new OracleParameter(":LastModifyTime", 106, 8);
			((DbParameter)val6).Value = model.LastModifyTime;
			obj[5] = val6;
			_003F val7;
			if (model.Html != null)
			{
				val7 = new OracleParameter(":Html", 105);
				((DbParameter)val7).Value = model.Html;
			}
			else
			{
				val7 = new OracleParameter(":Html", 105);
				((DbParameter)val7).Value = DBNull.Value;
			}
			obj[6] = val7;
			_003F val8;
			if (model.SubTableJson != null)
			{
				val8 = new OracleParameter(":SubTableJson", 105);
				((DbParameter)val8).Value = model.SubTableJson;
			}
			else
			{
				val8 = new OracleParameter(":SubTableJson", 105);
				((DbParameter)val8).Value = DBNull.Value;
			}
			obj[7] = val8;
			_003F val9;
			if (model.EventsJson != null)
			{
				val9 = new OracleParameter(":EventsJson", 105);
				((DbParameter)val9).Value = model.EventsJson;
			}
			else
			{
				val9 = new OracleParameter(":EventsJson", 105);
				((DbParameter)val9).Value = DBNull.Value;
			}
			obj[8] = val9;
			_003F val10;
			if (model.Attribute != null)
			{
				val10 = new OracleParameter(":Attribute", 105);
				((DbParameter)val10).Value = model.Attribute;
			}
			else
			{
				val10 = new OracleParameter(":Attribute", 105);
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
			string sql = "DELETE FROM WorkFlowForm WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.WorkFlowForm> DataReaderToList(OracleDataReader dataReader)
		{
			List<RoadFlow.Data.Model.WorkFlowForm> list = new List<RoadFlow.Data.Model.WorkFlowForm>();
			RoadFlow.Data.Model.WorkFlowForm workFlowForm = null;
			while (((DbDataReader)dataReader).Read())
			{
				workFlowForm = new RoadFlow.Data.Model.WorkFlowForm();
				workFlowForm.ID = ((DbDataReader)dataReader).GetString(0).ToGuid();
				workFlowForm.Name = ((DbDataReader)dataReader).GetString(1);
				workFlowForm.Type = ((DbDataReader)dataReader).GetString(2).ToGuid();
				workFlowForm.CreateUserID = ((DbDataReader)dataReader).GetString(3).ToGuid();
				workFlowForm.CreateUserName = ((DbDataReader)dataReader).GetString(4);
				workFlowForm.CreateTime = ((DbDataReader)dataReader).GetDateTime(5);
				workFlowForm.LastModifyTime = ((DbDataReader)dataReader).GetDateTime(6);
				if (!((DbDataReader)dataReader).IsDBNull(7))
				{
					workFlowForm.Html = ((DbDataReader)dataReader).GetString(7);
				}
				if (!((DbDataReader)dataReader).IsDBNull(8))
				{
					workFlowForm.SubTableJson = ((DbDataReader)dataReader).GetString(8);
				}
				if (!((DbDataReader)dataReader).IsDBNull(9))
				{
					workFlowForm.EventsJson = ((DbDataReader)dataReader).GetString(9);
				}
				if (!((DbDataReader)dataReader).IsDBNull(10))
				{
					workFlowForm.Attribute = ((DbDataReader)dataReader).GetString(10);
				}
				workFlowForm.Status = ((DbDataReader)dataReader).GetInt32(11);
				list.Add(workFlowForm);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.WorkFlowForm> GetAll()
		{
			string sql = "SELECT * FROM WorkFlowForm";
			OracleDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.WorkFlowForm> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM WorkFlowForm";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.WorkFlowForm Get(Guid id)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "SELECT * FROM WorkFlowForm WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.WorkFlowForm> list = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public List<RoadFlow.Data.Model.WorkFlowForm> GetAllByType(string types)
		{
			string sql = "SELECT * FROM WorkFlowForm where Type IN(" + Tools.GetSqlInString(types) + ")";
			OracleDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.WorkFlowForm> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public List<RoadFlow.Data.Model.WorkFlowForm> GetPagerData(out string pager, string query = "", string userid = "", string typeid = "", string name = "", int pagesize = 15)
		{
			//IL_002d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Expected O, but got Unknown
			//IL_003e: Expected O, but got Unknown
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Expected O, but got Unknown
			//IL_006d: Expected O, but got Unknown
			StringBuilder stringBuilder = new StringBuilder("AND Status IN(0,1) ");
			List<OracleParameter> list = new List<OracleParameter>();
			if (!userid.IsNullOrEmpty())
			{
				stringBuilder.Append("AND CreateUserID=:CreateUserID ");
				List<OracleParameter> list2 = list;
				OracleParameter val = new OracleParameter(":CreateUserID", 126);
				((DbParameter)val).Value = userid;
				list2.Add(val);
			}
			if (!name.IsNullOrEmpty())
			{
				stringBuilder.Append("AND CHARINDEX(:Name,Name)>0 ");
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
			string paerSql = dbHelper.GetPaerSql("WorkFlowForm", "ID,Name,Type,CreateUserID,CreateUserName,CreateTime,LastModifyTime,'' Html,'' SubTableJson,'' EventsJson,'' Attribute,Status", stringBuilder.ToString(), "CreateTime DESC", pagesize, pageNumber, out count, list.ToArray());
			pager = Tools.GetPagerHtml(count, pagesize, pageNumber, query);
			OracleDataReader dataReader = dbHelper.GetDataReader(paerSql, list.ToArray());
			List<RoadFlow.Data.Model.WorkFlowForm> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public List<RoadFlow.Data.Model.WorkFlowForm> GetPagerData(out long count, int pageSize, int pageNumber, string userid = "", string typeid = "", string name = "", string order = "")
		{
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_003b: Expected O, but got Unknown
			//IL_0040: Expected O, but got Unknown
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Expected O, but got Unknown
			//IL_006f: Expected O, but got Unknown
			StringBuilder stringBuilder = new StringBuilder("AND Status IN(0,1) ");
			List<OracleParameter> list = new List<OracleParameter>();
			if (!userid.IsNullOrEmpty())
			{
				stringBuilder.Append("AND CreateUserID=:CreateUserID ");
				List<OracleParameter> list2 = list;
				OracleParameter val = new OracleParameter(":CreateUserID", 126);
				((DbParameter)val).Value = userid;
				list2.Add(val);
			}
			if (!name.IsNullOrEmpty())
			{
				stringBuilder.Append("AND CHARINDEX(:Name,Name)>0 ");
				List<OracleParameter> list3 = list;
				OracleParameter val2 = new OracleParameter(":Name", 126);
				((DbParameter)val2).Value = name;
				list3.Add(val2);
			}
			if (!typeid.IsNullOrEmpty())
			{
				stringBuilder.Append("AND Type IN (" + Tools.GetSqlInString(typeid) + ")");
			}
			string paerSql = dbHelper.GetPaerSql("WorkFlowForm", "ID,Name,Type,CreateUserID,CreateUserName,CreateTime,LastModifyTime,'' Html,'' SubTableJson,'' EventsJson,'' Attribute,Status", stringBuilder.ToString(), order.IsNullOrEmpty() ? "CreateTime DESC" : order, pageSize, pageNumber, out count, list.ToArray());
			OracleDataReader dataReader = dbHelper.GetDataReader(paerSql, list.ToArray());
			List<RoadFlow.Data.Model.WorkFlowForm> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}
	}
}
