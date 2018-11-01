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
	public class WorkFlowDelegation : IWorkFlowDelegation
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.WorkFlowDelegation model)
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Expected O, but got Unknown
			//IL_002e: Expected O, but got Unknown
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Expected O, but got Unknown
			//IL_0050: Expected O, but got Unknown
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0070: Expected O, but got Unknown
			//IL_0071: Expected O, but got Unknown
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Expected O, but got Unknown
			//IL_0092: Expected O, but got Unknown
			//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c3: Expected O, but got Unknown
			//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00de: Expected O, but got Unknown
			//IL_00df: Expected O, but got Unknown
			//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_0100: Expected O, but got Unknown
			//IL_0101: Expected O, but got Unknown
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0110: Unknown result type (might be due to invalid IL or missing references)
			//IL_0121: Expected O, but got Unknown
			//IL_0122: Expected O, but got Unknown
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			//IL_013d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0149: Expected O, but got Unknown
			//IL_0157: Unknown result type (might be due to invalid IL or missing references)
			//IL_015c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0167: Expected O, but got Unknown
			//IL_0168: Expected O, but got Unknown
			string sql = "INSERT INTO WorkFlowDelegation\r\n\t\t\t\t(ID,UserID,StartTime,EndTime,FlowID,ToUserID,WriteTime,Note) \r\n\t\t\t\tVALUES(:ID,:UserID,:StartTime,:EndTime,:FlowID,:ToUserID,:WriteTime,:Note)";
			OracleParameter[] obj = new OracleParameter[8];
			OracleParameter val = new OracleParameter(":ID", 126, 40);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":UserID", 126, 40);
			((DbParameter)val2).Value = model.UserID;
			obj[1] = val2;
			OracleParameter val3 = new OracleParameter(":StartTime", 106, 8);
			((DbParameter)val3).Value = model.StartTime;
			obj[2] = val3;
			OracleParameter val4 = new OracleParameter(":EndTime", 106, 8);
			((DbParameter)val4).Value = model.EndTime;
			obj[3] = val4;
			_003F val5;
			if (model.FlowID.HasValue)
			{
				val5 = new OracleParameter(":FlowID", 126, 40);
				((DbParameter)val5).Value = model.FlowID;
			}
			else
			{
				val5 = new OracleParameter(":FlowID", 126, 40);
				((DbParameter)val5).Value = DBNull.Value;
			}
			obj[4] = val5;
			OracleParameter val6 = new OracleParameter(":ToUserID", 126, 40);
			((DbParameter)val6).Value = model.ToUserID;
			obj[5] = val6;
			OracleParameter val7 = new OracleParameter(":WriteTime", 106, 8);
			((DbParameter)val7).Value = model.WriteTime;
			obj[6] = val7;
			_003F val8;
			if (model.Note != null)
			{
				val8 = new OracleParameter(":Note", 119, 8000);
				((DbParameter)val8).Value = model.Note;
			}
			else
			{
				val8 = new OracleParameter(":Note", 119, 8000);
				((DbParameter)val8).Value = DBNull.Value;
			}
			obj[7] = val8;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.WorkFlowDelegation model)
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Expected O, but got Unknown
			//IL_002e: Expected O, but got Unknown
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Expected O, but got Unknown
			//IL_004f: Expected O, but got Unknown
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Expected O, but got Unknown
			//IL_0070: Expected O, but got Unknown
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a1: Expected O, but got Unknown
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bc: Expected O, but got Unknown
			//IL_00bd: Expected O, but got Unknown
			//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00de: Expected O, but got Unknown
			//IL_00df: Expected O, but got Unknown
			//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ff: Expected O, but got Unknown
			//IL_0100: Expected O, but got Unknown
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_011b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0127: Expected O, but got Unknown
			//IL_0135: Unknown result type (might be due to invalid IL or missing references)
			//IL_013a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0145: Expected O, but got Unknown
			//IL_0146: Expected O, but got Unknown
			//IL_0151: Unknown result type (might be due to invalid IL or missing references)
			//IL_0156: Unknown result type (might be due to invalid IL or missing references)
			//IL_0167: Expected O, but got Unknown
			//IL_0168: Expected O, but got Unknown
			string sql = "UPDATE WorkFlowDelegation SET \r\n\t\t\t\tUserID=:UserID,StartTime=:StartTime,EndTime=:EndTime,FlowID=:FlowID,ToUserID=:ToUserID,WriteTime=:WriteTime,Note=:Note\r\n\t\t\t\tWHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[8];
			OracleParameter val = new OracleParameter(":UserID", 126, 40);
			((DbParameter)val).Value = model.UserID;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":StartTime", 106, 8);
			((DbParameter)val2).Value = model.StartTime;
			obj[1] = val2;
			OracleParameter val3 = new OracleParameter(":EndTime", 106, 8);
			((DbParameter)val3).Value = model.EndTime;
			obj[2] = val3;
			_003F val4;
			if (model.FlowID.HasValue)
			{
				val4 = new OracleParameter(":FlowID", 126, 40);
				((DbParameter)val4).Value = model.FlowID;
			}
			else
			{
				val4 = new OracleParameter(":FlowID", 126, 40);
				((DbParameter)val4).Value = DBNull.Value;
			}
			obj[3] = val4;
			OracleParameter val5 = new OracleParameter(":ToUserID", 126, 40);
			((DbParameter)val5).Value = model.ToUserID;
			obj[4] = val5;
			OracleParameter val6 = new OracleParameter(":WriteTime", 106, 8);
			((DbParameter)val6).Value = model.WriteTime;
			obj[5] = val6;
			_003F val7;
			if (model.Note != null)
			{
				val7 = new OracleParameter(":Note", 119, 8000);
				((DbParameter)val7).Value = model.Note;
			}
			else
			{
				val7 = new OracleParameter(":Note", 119, 8000);
				((DbParameter)val7).Value = DBNull.Value;
			}
			obj[6] = val7;
			OracleParameter val8 = new OracleParameter(":ID", 126, 40);
			((DbParameter)val8).Value = model.ID;
			obj[7] = val8;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Delete(Guid id)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "DELETE FROM WorkFlowDelegation WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.WorkFlowDelegation> DataReaderToList(OracleDataReader dataReader)
		{
			List<RoadFlow.Data.Model.WorkFlowDelegation> list = new List<RoadFlow.Data.Model.WorkFlowDelegation>();
			RoadFlow.Data.Model.WorkFlowDelegation workFlowDelegation = null;
			while (((DbDataReader)dataReader).Read())
			{
				workFlowDelegation = new RoadFlow.Data.Model.WorkFlowDelegation();
				workFlowDelegation.ID = ((DbDataReader)dataReader).GetString(0).ToGuid();
				workFlowDelegation.UserID = ((DbDataReader)dataReader).GetString(1).ToGuid();
				workFlowDelegation.StartTime = ((DbDataReader)dataReader).GetDateTime(2);
				workFlowDelegation.EndTime = ((DbDataReader)dataReader).GetDateTime(3);
				if (!((DbDataReader)dataReader).IsDBNull(4))
				{
					workFlowDelegation.FlowID = ((DbDataReader)dataReader).GetString(4).ToGuid();
				}
				workFlowDelegation.ToUserID = ((DbDataReader)dataReader).GetString(5).ToGuid();
				workFlowDelegation.WriteTime = ((DbDataReader)dataReader).GetDateTime(6);
				if (!((DbDataReader)dataReader).IsDBNull(7))
				{
					workFlowDelegation.Note = ((DbDataReader)dataReader).GetString(7);
				}
				list.Add(workFlowDelegation);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.WorkFlowDelegation> GetAll()
		{
			string sql = "SELECT * FROM WorkFlowDelegation";
			OracleDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.WorkFlowDelegation> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM WorkFlowDelegation";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.WorkFlowDelegation Get(Guid id)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "SELECT * FROM WorkFlowDelegation WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.WorkFlowDelegation> list = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public List<RoadFlow.Data.Model.WorkFlowDelegation> GetByUserID(Guid userID)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "SELECT * FROM WorkFlowDelegation WHERE UserID=:UserID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":UserID", 126);
			((DbParameter)val).Value = userID;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.WorkFlowDelegation> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public List<RoadFlow.Data.Model.WorkFlowDelegation> GetPagerData(out string pager, string query = "", string userID = "", string startTime = "", string endTime = "")
		{
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Expected O, but got Unknown
			//IL_0043: Expected O, but got Unknown
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Expected O, but got Unknown
			//IL_008f: Expected O, but got Unknown
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e8: Expected O, but got Unknown
			//IL_00ed: Expected O, but got Unknown
			StringBuilder stringBuilder = new StringBuilder();
			List<OracleParameter> list = new List<OracleParameter>();
			if (userID.IsGuid())
			{
				stringBuilder.Append("AND UserID=:UserID ");
				List<OracleParameter> list2 = list;
				OracleParameter val = new OracleParameter(":UserID", 126);
				((DbParameter)val).Value = userID.ToGuid();
				list2.Add(val);
			}
			if (startTime.IsDateTime())
			{
				stringBuilder.Append("AND StartTime>=:StartTime ");
				List<OracleParameter> list3 = list;
				OracleParameter val2 = new OracleParameter(":StartTime", 106);
				((DbParameter)val2).Value = startTime.ToDateTime().ToString("yyyy-MM-dd").ToDateTime();
				list3.Add(val2);
			}
			if (endTime.IsDateTime())
			{
				stringBuilder.Append("AND EndTime<=:EndTime ");
				List<OracleParameter> list4 = list;
				OracleParameter val3 = new OracleParameter(":EndTime", 106);
				((DbParameter)val3).Value = endTime.ToDateTime().AddDays(1.0).ToString("yyyy-MM-dd")
					.ToDateTime();
				list4.Add(val3);
			}
			int pageSize = Tools.GetPageSize();
			int pageNumber = Tools.GetPageNumber();
			long count;
			string paerSql = dbHelper.GetPaerSql("WorkFlowDelegation", "*", stringBuilder.ToString(), "WriteTime Desc", pageSize, pageNumber, out count, list.ToArray());
			pager = Tools.GetPagerHtml(count, pageSize, pageNumber, query);
			OracleDataReader dataReader = dbHelper.GetDataReader(paerSql, list.ToArray());
			List<RoadFlow.Data.Model.WorkFlowDelegation> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public List<RoadFlow.Data.Model.WorkFlowDelegation> GetPagerData(out long count, int pageSize, int pageNumber, string userID = "", string startTime = "", string endTime = "", string order = "")
		{
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Expected O, but got Unknown
			//IL_0045: Expected O, but got Unknown
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Expected O, but got Unknown
			//IL_0091: Expected O, but got Unknown
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ea: Expected O, but got Unknown
			//IL_00ef: Expected O, but got Unknown
			StringBuilder stringBuilder = new StringBuilder();
			List<OracleParameter> list = new List<OracleParameter>();
			if (userID.IsGuid())
			{
				stringBuilder.Append("AND UserID=:UserID ");
				List<OracleParameter> list2 = list;
				OracleParameter val = new OracleParameter(":UserID", 126);
				((DbParameter)val).Value = userID.ToGuid();
				list2.Add(val);
			}
			if (startTime.IsDateTime())
			{
				stringBuilder.Append("AND StartTime>=:StartTime ");
				List<OracleParameter> list3 = list;
				OracleParameter val2 = new OracleParameter(":StartTime", 106);
				((DbParameter)val2).Value = startTime.ToDateTime().ToString("yyyy-MM-dd").ToDateTime();
				list3.Add(val2);
			}
			if (endTime.IsDateTime())
			{
				stringBuilder.Append("AND EndTime<=:EndTime ");
				List<OracleParameter> list4 = list;
				OracleParameter val3 = new OracleParameter(":EndTime", 106);
				((DbParameter)val3).Value = endTime.ToDateTime().AddDays(1.0).ToString("yyyy-MM-dd")
					.ToDateTime();
				list4.Add(val3);
			}
			string paerSql = dbHelper.GetPaerSql("WorkFlowDelegation", "*", stringBuilder.ToString(), order.IsNullOrEmpty() ? "WriteTime Desc" : order, pageSize, pageNumber, out count, list.ToArray());
			OracleDataReader dataReader = dbHelper.GetDataReader(paerSql, list.ToArray());
			List<RoadFlow.Data.Model.WorkFlowDelegation> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public List<RoadFlow.Data.Model.WorkFlowDelegation> GetNoExpiredList()
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Expected O, but got Unknown
			//IL_002b: Expected O, but got Unknown
			string sql = "SELECT * FROM WorkFlowDelegation WHERE EndTime>=:EndTime";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":EndTime", 106);
			((DbParameter)val).Value = DateTimeNew.Now;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.WorkFlowDelegation> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}
	}
}
