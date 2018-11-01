using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace RoadFlow.Data.ORACLE
{
	public class WorkFlowArchives : IWorkFlowArchives
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.WorkFlowArchives model)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Expected O, but got Unknown
			//IL_002f: Expected O, but got Unknown
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Expected O, but got Unknown
			//IL_0051: Expected O, but got Unknown
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0061: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Expected O, but got Unknown
			//IL_0073: Expected O, but got Unknown
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Expected O, but got Unknown
			//IL_0093: Expected O, but got Unknown
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Expected O, but got Unknown
			//IL_00b3: Expected O, but got Unknown
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d4: Expected O, but got Unknown
			//IL_00d5: Expected O, but got Unknown
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f6: Expected O, but got Unknown
			//IL_00f7: Expected O, but got Unknown
			//IL_0105: Unknown result type (might be due to invalid IL or missing references)
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Expected O, but got Unknown
			//IL_0117: Expected O, but got Unknown
			//IL_0125: Unknown result type (might be due to invalid IL or missing references)
			//IL_012a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0136: Expected O, but got Unknown
			//IL_0137: Expected O, but got Unknown
			//IL_0141: Unknown result type (might be due to invalid IL or missing references)
			//IL_0146: Unknown result type (might be due to invalid IL or missing references)
			//IL_0152: Expected O, but got Unknown
			//IL_0153: Expected O, but got Unknown
			//IL_015d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0162: Unknown result type (might be due to invalid IL or missing references)
			//IL_016e: Expected O, but got Unknown
			//IL_016f: Expected O, but got Unknown
			//IL_017a: Unknown result type (might be due to invalid IL or missing references)
			//IL_017f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0190: Expected O, but got Unknown
			//IL_0191: Expected O, but got Unknown
			string sql = "INSERT INTO WorkFlowArchives\r\n\t\t\t\t(ID,FlowID,StepID,FlowName,StepName,TaskID,GroupID,InstanceID,Title,Contents,Comments,WriteTime) \r\n\t\t\t\tVALUES(:ID,:FlowID,:StepID,:FlowName,:StepName,:TaskID,:GroupID,:InstanceID,:Title,:Contents,:Comments,:WriteTime)";
			OracleParameter[] obj = new OracleParameter[12];
			OracleParameter val = new OracleParameter(":ID", 126, 40);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":FlowID", 126, 40);
			((DbParameter)val2).Value = model.FlowID;
			obj[1] = val2;
			OracleParameter val3 = new OracleParameter(":StepID", 126, 40);
			((DbParameter)val3).Value = model.StepID;
			obj[2] = val3;
			OracleParameter val4 = new OracleParameter(":FlowName", 119, 1000);
			((DbParameter)val4).Value = model.FlowName;
			obj[3] = val4;
			OracleParameter val5 = new OracleParameter(":StepName", 119, 1000);
			((DbParameter)val5).Value = model.StepName;
			obj[4] = val5;
			OracleParameter val6 = new OracleParameter(":TaskID", 126, 40);
			((DbParameter)val6).Value = model.TaskID;
			obj[5] = val6;
			OracleParameter val7 = new OracleParameter(":GroupID", 126, 40);
			((DbParameter)val7).Value = model.GroupID;
			obj[6] = val7;
			OracleParameter val8 = new OracleParameter(":InstanceID", 126, 500);
			((DbParameter)val8).Value = model.InstanceID;
			obj[7] = val8;
			OracleParameter val9 = new OracleParameter(":Title", 119, 8000);
			((DbParameter)val9).Value = model.Title;
			obj[8] = val9;
			OracleParameter val10 = new OracleParameter(":Contents", 105);
			((DbParameter)val10).Value = model.Contents;
			obj[9] = val10;
			OracleParameter val11 = new OracleParameter(":Comments", 105);
			((DbParameter)val11).Value = model.Comments;
			obj[10] = val11;
			OracleParameter val12 = new OracleParameter(":WriteTime", 106, 8);
			((DbParameter)val12).Value = model.WriteTime;
			obj[11] = val12;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.WorkFlowArchives model)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Expected O, but got Unknown
			//IL_002f: Expected O, but got Unknown
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Expected O, but got Unknown
			//IL_0051: Expected O, but got Unknown
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			//IL_0070: Expected O, but got Unknown
			//IL_0071: Expected O, but got Unknown
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Expected O, but got Unknown
			//IL_0091: Expected O, but got Unknown
			//IL_009c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Expected O, but got Unknown
			//IL_00b3: Expected O, but got Unknown
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d4: Expected O, but got Unknown
			//IL_00d5: Expected O, but got Unknown
			//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f4: Expected O, but got Unknown
			//IL_00f5: Expected O, but got Unknown
			//IL_0103: Unknown result type (might be due to invalid IL or missing references)
			//IL_0108: Unknown result type (might be due to invalid IL or missing references)
			//IL_0114: Expected O, but got Unknown
			//IL_0115: Expected O, but got Unknown
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_012f: Expected O, but got Unknown
			//IL_0130: Expected O, but got Unknown
			//IL_013a: Unknown result type (might be due to invalid IL or missing references)
			//IL_013f: Unknown result type (might be due to invalid IL or missing references)
			//IL_014b: Expected O, but got Unknown
			//IL_014c: Expected O, but got Unknown
			//IL_0157: Unknown result type (might be due to invalid IL or missing references)
			//IL_015c: Unknown result type (might be due to invalid IL or missing references)
			//IL_016d: Expected O, but got Unknown
			//IL_016e: Expected O, but got Unknown
			//IL_017a: Unknown result type (might be due to invalid IL or missing references)
			//IL_017f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0190: Expected O, but got Unknown
			//IL_0191: Expected O, but got Unknown
			string sql = "UPDATE WorkFlowArchives SET \r\n\t\t\t\tFlowID=:FlowID,StepID=:StepID,FlowName=:FlowName,StepName=:StepName,TaskID=:TaskID,GroupID=:GroupID,InstanceID=:InstanceID,Title=:Title,Contents=:Contents,Comments=:Comments,WriteTime=:WriteTime\r\n\t\t\t\tWHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[12];
			OracleParameter val = new OracleParameter(":FlowID", 126, 40);
			((DbParameter)val).Value = model.FlowID;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":StepID", 126, 40);
			((DbParameter)val2).Value = model.StepID;
			obj[1] = val2;
			OracleParameter val3 = new OracleParameter(":FlowName", 119, 1000);
			((DbParameter)val3).Value = model.FlowName;
			obj[2] = val3;
			OracleParameter val4 = new OracleParameter(":StepName", 119, 1000);
			((DbParameter)val4).Value = model.StepName;
			obj[3] = val4;
			OracleParameter val5 = new OracleParameter(":TaskID", 126, 40);
			((DbParameter)val5).Value = model.TaskID;
			obj[4] = val5;
			OracleParameter val6 = new OracleParameter(":GroupID", 126, 40);
			((DbParameter)val6).Value = model.GroupID;
			obj[5] = val6;
			OracleParameter val7 = new OracleParameter(":InstanceID", 126, 500);
			((DbParameter)val7).Value = model.InstanceID;
			obj[6] = val7;
			OracleParameter val8 = new OracleParameter(":Title", 119, 8000);
			((DbParameter)val8).Value = model.Title;
			obj[7] = val8;
			OracleParameter val9 = new OracleParameter(":Contents", 105);
			((DbParameter)val9).Value = model.Contents;
			obj[8] = val9;
			OracleParameter val10 = new OracleParameter(":Comments", 105);
			((DbParameter)val10).Value = model.Comments;
			obj[9] = val10;
			OracleParameter val11 = new OracleParameter(":WriteTime", 106, 8);
			((DbParameter)val11).Value = model.WriteTime;
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
			string sql = "DELETE FROM WorkFlowArchives WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.WorkFlowArchives> DataReaderToList(OracleDataReader dataReader)
		{
			List<RoadFlow.Data.Model.WorkFlowArchives> list = new List<RoadFlow.Data.Model.WorkFlowArchives>();
			RoadFlow.Data.Model.WorkFlowArchives workFlowArchives = null;
			while (((DbDataReader)dataReader).Read())
			{
				workFlowArchives = new RoadFlow.Data.Model.WorkFlowArchives();
				workFlowArchives.ID = ((DbDataReader)dataReader).GetString(0).ToGuid();
				workFlowArchives.FlowID = ((DbDataReader)dataReader).GetString(1).ToGuid();
				workFlowArchives.StepID = ((DbDataReader)dataReader).GetString(2).ToGuid();
				workFlowArchives.FlowName = ((DbDataReader)dataReader).GetString(3);
				workFlowArchives.StepName = ((DbDataReader)dataReader).GetString(4);
				workFlowArchives.TaskID = ((DbDataReader)dataReader).GetString(5).ToGuid();
				workFlowArchives.GroupID = ((DbDataReader)dataReader).GetString(6).ToGuid();
				workFlowArchives.InstanceID = ((DbDataReader)dataReader).GetString(7);
				workFlowArchives.Title = ((DbDataReader)dataReader).GetString(8);
				workFlowArchives.Contents = ((DbDataReader)dataReader).GetString(9);
				workFlowArchives.Comments = ((DbDataReader)dataReader).GetString(10);
				workFlowArchives.WriteTime = ((DbDataReader)dataReader).GetDateTime(11);
				list.Add(workFlowArchives);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.WorkFlowArchives> GetAll()
		{
			string sql = "SELECT * FROM WorkFlowArchives";
			OracleDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.WorkFlowArchives> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM WorkFlowArchives";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.WorkFlowArchives Get(Guid id)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "SELECT * FROM WorkFlowArchives WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.WorkFlowArchives> list = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public DataTable GetPagerData(out string pager, string query = "", string title = "", string flowIDString = "")
		{
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Expected O, but got Unknown
			//IL_0039: Expected O, but got Unknown
			StringBuilder stringBuilder = new StringBuilder();
			List<OracleParameter> list = new List<OracleParameter>();
			if (!title.IsNullOrEmpty())
			{
				stringBuilder.Append("AND INSTR(Title,:Title,1,1)>0 ");
				List<OracleParameter> list2 = list;
				OracleParameter val = new OracleParameter(":Title", 119);
				((DbParameter)val).Value = title;
				list2.Add(val);
			}
			if (!flowIDString.IsNullOrEmpty())
			{
				stringBuilder.AppendFormat("AND FlowID IN({0}) ", Tools.GetSqlInString(flowIDString));
			}
			int pageSize = Tools.GetPageSize();
			int pageNumber = Tools.GetPageNumber();
			long count;
			string paerSql = dbHelper.GetPaerSql("WorkFlowArchives", "*", stringBuilder.ToString(), "WriteTime DESC", pageSize, pageNumber, out count, list.ToArray());
			pager = Tools.GetPagerHtml(count, pageSize, pageNumber, query);
			return dbHelper.GetDataTable(paerSql, list.ToArray());
		}

		public DataTable GetPagerData(out long count, int pageSize, int pageNumber, string title = "", string flowIDString = "", string date1 = "", string date2 = "", string order = "")
		{
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Expected O, but got Unknown
			//IL_003b: Expected O, but got Unknown
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_0062: Expected O, but got Unknown
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0089: Expected O, but got Unknown
			//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c2: Expected O, but got Unknown
			StringBuilder stringBuilder = new StringBuilder();
			List<OracleParameter> list = new List<OracleParameter>();
			if (!title.IsNullOrEmpty())
			{
				stringBuilder.Append("AND INSTR(Title,:Title,1,1)>0 ");
				List<OracleParameter> list2 = list;
				OracleParameter val = new OracleParameter(":Title", 119);
				((DbParameter)val).Value = title;
				list2.Add(val);
			}
			if (flowIDString.IsGuid())
			{
				stringBuilder.Append("AND FlowID=:FlowID ");
				list.Add(new OracleParameter(":FlowID", (object)flowIDString));
			}
			if (date1.IsDateTime())
			{
				stringBuilder.Append("AND WriteTime>=:WriteTime1 ");
				list.Add(new OracleParameter(":WriteTime1", (object)date1));
			}
			if (date2.IsDateTime())
			{
				stringBuilder.Append("AND WriteTime<=:WriteTime2 ");
				list.Add(new OracleParameter(":WriteTime2", (object)date2.ToDateTime().ToString("yyyy-MM-dd 23:59:59")));
			}
			string paerSql = dbHelper.GetPaerSql("WorkFlowArchives", "ID,FlowName,StepName,Title,WriteTime", stringBuilder.ToString(), order.IsNullOrEmpty() ? "WriteTime DESC" : order, pageSize, pageNumber, out count, list.ToArray());
			return dbHelper.GetDataTable(paerSql, list.ToArray());
		}
	}
}
