using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace RoadFlow.Data.MySql
{
	public class WorkFlowArchives : IWorkFlowArchives
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.WorkFlowArchives model)
		{
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0032: Expected O, but got Unknown
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Expected O, but got Unknown
			//IL_0057: Expected O, but got Unknown
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Expected O, but got Unknown
			//IL_007c: Expected O, but got Unknown
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_009a: Expected O, but got Unknown
			//IL_009b: Expected O, but got Unknown
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Expected O, but got Unknown
			//IL_00ba: Expected O, but got Unknown
			//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00de: Expected O, but got Unknown
			//IL_00df: Expected O, but got Unknown
			//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0103: Expected O, but got Unknown
			//IL_0104: Expected O, but got Unknown
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_0122: Expected O, but got Unknown
			//IL_0123: Expected O, but got Unknown
			//IL_0130: Unknown result type (might be due to invalid IL or missing references)
			//IL_0135: Unknown result type (might be due to invalid IL or missing references)
			//IL_0141: Expected O, but got Unknown
			//IL_0142: Expected O, but got Unknown
			//IL_0150: Unknown result type (might be due to invalid IL or missing references)
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0161: Expected O, but got Unknown
			//IL_0162: Expected O, but got Unknown
			//IL_0170: Unknown result type (might be due to invalid IL or missing references)
			//IL_0175: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Expected O, but got Unknown
			//IL_0182: Expected O, but got Unknown
			//IL_018d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0192: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a3: Expected O, but got Unknown
			//IL_01a4: Expected O, but got Unknown
			string sql = "INSERT INTO workflowarchives\r\n\t\t\t\t(ID,FlowID,StepID,FlowName,StepName,TaskID,GroupID,InstanceID,Title,Contents,Comments,WriteTime) \r\n\t\t\t\tVALUES(@ID,@FlowID,@StepID,@FlowName,@StepName,@TaskID,@GroupID,@InstanceID,@Title,@Contents,@Comments,@WriteTime)";
			MySqlParameter[] obj = new MySqlParameter[12];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@FlowID", 253, 36);
			((DbParameter)val2).Value = model.FlowID;
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@StepID", 253, 36);
			((DbParameter)val3).Value = model.StepID;
			obj[2] = val3;
			MySqlParameter val4 = new MySqlParameter("@FlowName", 752, -1);
			((DbParameter)val4).Value = model.FlowName;
			obj[3] = val4;
			MySqlParameter val5 = new MySqlParameter("@StepName", 752, -1);
			((DbParameter)val5).Value = model.StepName;
			obj[4] = val5;
			MySqlParameter val6 = new MySqlParameter("@TaskID", 253, 36);
			((DbParameter)val6).Value = model.TaskID;
			obj[5] = val6;
			MySqlParameter val7 = new MySqlParameter("@GroupID", 253, 36);
			((DbParameter)val7).Value = model.GroupID;
			obj[6] = val7;
			MySqlParameter val8 = new MySqlParameter("@InstanceID", 752, -1);
			((DbParameter)val8).Value = model.InstanceID;
			obj[7] = val8;
			MySqlParameter val9 = new MySqlParameter("@Title", 752, -1);
			((DbParameter)val9).Value = model.Title;
			obj[8] = val9;
			MySqlParameter val10 = new MySqlParameter("@Contents", 751, -1);
			((DbParameter)val10).Value = model.Contents;
			obj[9] = val10;
			MySqlParameter val11 = new MySqlParameter("@Comments", 751, -1);
			((DbParameter)val11).Value = model.Comments;
			obj[10] = val11;
			MySqlParameter val12 = new MySqlParameter("@WriteTime", 12, -1);
			((DbParameter)val12).Value = model.WriteTime;
			obj[11] = val12;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.WorkFlowArchives model)
		{
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0032: Expected O, but got Unknown
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Expected O, but got Unknown
			//IL_0057: Expected O, but got Unknown
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_0075: Expected O, but got Unknown
			//IL_0076: Expected O, but got Unknown
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Expected O, but got Unknown
			//IL_0095: Expected O, but got Unknown
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Expected O, but got Unknown
			//IL_00ba: Expected O, but got Unknown
			//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00de: Expected O, but got Unknown
			//IL_00df: Expected O, but got Unknown
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fd: Expected O, but got Unknown
			//IL_00fe: Expected O, but got Unknown
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0110: Unknown result type (might be due to invalid IL or missing references)
			//IL_011c: Expected O, but got Unknown
			//IL_011d: Expected O, but got Unknown
			//IL_012a: Unknown result type (might be due to invalid IL or missing references)
			//IL_012f: Unknown result type (might be due to invalid IL or missing references)
			//IL_013b: Expected O, but got Unknown
			//IL_013c: Expected O, but got Unknown
			//IL_014a: Unknown result type (might be due to invalid IL or missing references)
			//IL_014f: Unknown result type (might be due to invalid IL or missing references)
			//IL_015b: Expected O, but got Unknown
			//IL_015c: Expected O, but got Unknown
			//IL_0167: Unknown result type (might be due to invalid IL or missing references)
			//IL_016c: Unknown result type (might be due to invalid IL or missing references)
			//IL_017d: Expected O, but got Unknown
			//IL_017e: Expected O, but got Unknown
			//IL_018d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0192: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a3: Expected O, but got Unknown
			//IL_01a4: Expected O, but got Unknown
			string sql = "UPDATE workflowarchives SET \r\n\t\t\t\tFlowID=@FlowID,StepID=@StepID,FlowName=@FlowName,StepName=@StepName,TaskID=@TaskID,GroupID=@GroupID,InstanceID=@InstanceID,Title=@Title,Contents=@Contents,Comments=@Comments,WriteTime=@WriteTime\r\n\t\t\t\tWHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[12];
			MySqlParameter val = new MySqlParameter("@FlowID", 253, 36);
			((DbParameter)val).Value = model.FlowID;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@StepID", 253, 36);
			((DbParameter)val2).Value = model.StepID;
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@FlowName", 752, -1);
			((DbParameter)val3).Value = model.FlowName;
			obj[2] = val3;
			MySqlParameter val4 = new MySqlParameter("@StepName", 752, -1);
			((DbParameter)val4).Value = model.StepName;
			obj[3] = val4;
			MySqlParameter val5 = new MySqlParameter("@TaskID", 253, 36);
			((DbParameter)val5).Value = model.TaskID;
			obj[4] = val5;
			MySqlParameter val6 = new MySqlParameter("@GroupID", 253, 36);
			((DbParameter)val6).Value = model.GroupID;
			obj[5] = val6;
			MySqlParameter val7 = new MySqlParameter("@InstanceID", 752, -1);
			((DbParameter)val7).Value = model.InstanceID;
			obj[6] = val7;
			MySqlParameter val8 = new MySqlParameter("@Title", 752, -1);
			((DbParameter)val8).Value = model.Title;
			obj[7] = val8;
			MySqlParameter val9 = new MySqlParameter("@Contents", 751, -1);
			((DbParameter)val9).Value = model.Contents;
			obj[8] = val9;
			MySqlParameter val10 = new MySqlParameter("@Comments", 751, -1);
			((DbParameter)val10).Value = model.Comments;
			obj[9] = val10;
			MySqlParameter val11 = new MySqlParameter("@WriteTime", 12, -1);
			((DbParameter)val11).Value = model.WriteTime;
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
			string sql = "DELETE FROM workflowarchives WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.WorkFlowArchives> DataReaderToList(MySqlDataReader dataReader)
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
			string sql = "SELECT * FROM workflowarchives";
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.WorkFlowArchives> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM workflowarchives";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.WorkFlowArchives Get(Guid id)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Expected O, but got Unknown
			string sql = "SELECT * FROM workflowarchives WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
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
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Expected O, but got Unknown
			//IL_003c: Expected O, but got Unknown
			StringBuilder stringBuilder = new StringBuilder();
			List<MySqlParameter> list = new List<MySqlParameter>();
			if (!title.IsNullOrEmpty())
			{
				stringBuilder.Append("AND INSTR(Title,@Title)>0 ");
				List<MySqlParameter> list2 = list;
				MySqlParameter val = new MySqlParameter("@Title", 253);
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
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Expected O, but got Unknown
			//IL_003e: Expected O, but got Unknown
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Expected O, but got Unknown
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Expected O, but got Unknown
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c5: Expected O, but got Unknown
			StringBuilder stringBuilder = new StringBuilder();
			List<MySqlParameter> list = new List<MySqlParameter>();
			if (!title.IsNullOrEmpty())
			{
				stringBuilder.Append("AND INSTR(Title,@Title)>0 ");
				List<MySqlParameter> list2 = list;
				MySqlParameter val = new MySqlParameter("@Title", 253);
				((DbParameter)val).Value = title;
				list2.Add(val);
			}
			if (flowIDString.IsGuid())
			{
				stringBuilder.Append("AND FlowID=@FlowID ");
				list.Add(new MySqlParameter("@FlowID", (object)flowIDString));
			}
			if (date1.IsDateTime())
			{
				stringBuilder.Append("AND WriteTime>=@WriteTime1 ");
				list.Add(new MySqlParameter("@WriteTime1", (object)date1));
			}
			if (date2.IsDateTime())
			{
				stringBuilder.Append("AND WriteTime<=@WriteTime2 ");
				list.Add(new MySqlParameter("@WriteTime2", (object)date2.ToDateTime().ToString("yyyy-MM-dd 23:59:59")));
			}
			string paerSql = dbHelper.GetPaerSql("WorkFlowArchives", "ID,FlowName,StepName,Title,WriteTime", stringBuilder.ToString(), order.IsNullOrEmpty() ? "WriteTime DESC" : order, pageSize, pageNumber, out count, list.ToArray());
			return dbHelper.GetDataTable(paerSql, list.ToArray());
		}
	}
}
