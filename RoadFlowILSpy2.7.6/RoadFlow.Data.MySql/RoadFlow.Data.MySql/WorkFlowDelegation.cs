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
	public class WorkFlowDelegation : IWorkFlowDelegation
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.WorkFlowDelegation model)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Expected O, but got Unknown
			//IL_0056: Expected O, but got Unknown
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Expected O, but got Unknown
			//IL_0077: Expected O, but got Unknown
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Expected O, but got Unknown
			//IL_0098: Expected O, but got Unknown
			//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Expected O, but got Unknown
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_00df: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ea: Expected O, but got Unknown
			//IL_00eb: Expected O, but got Unknown
			//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_010f: Expected O, but got Unknown
			//IL_0110: Expected O, but got Unknown
			//IL_011a: Unknown result type (might be due to invalid IL or missing references)
			//IL_011f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0130: Expected O, but got Unknown
			//IL_0131: Expected O, but got Unknown
			//IL_0146: Unknown result type (might be due to invalid IL or missing references)
			//IL_014b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0157: Expected O, but got Unknown
			//IL_0164: Unknown result type (might be due to invalid IL or missing references)
			//IL_0169: Unknown result type (might be due to invalid IL or missing references)
			//IL_0174: Expected O, but got Unknown
			//IL_0175: Expected O, but got Unknown
			string sql = "INSERT INTO workflowdelegation\r\n\t\t\t\t(ID,UserID,StartTime,EndTime,FlowID,ToUserID,WriteTime,Note) \r\n\t\t\t\tVALUES(@ID,@UserID,@StartTime,@EndTime,@FlowID,@ToUserID,@WriteTime,@Note)";
			MySqlParameter[] obj = new MySqlParameter[8];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@UserID", 253, 36);
			((DbParameter)val2).Value = model.UserID;
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@StartTime", 12, -1);
			((DbParameter)val3).Value = model.StartTime;
			obj[2] = val3;
			MySqlParameter val4 = new MySqlParameter("@EndTime", 12, -1);
			((DbParameter)val4).Value = model.EndTime;
			obj[3] = val4;
			_003F val5;
			if (model.FlowID.HasValue)
			{
				val5 = new MySqlParameter("@FlowID", 253, 36);
				((DbParameter)val5).Value = model.FlowID;
			}
			else
			{
				val5 = new MySqlParameter("@FlowID", 253, 36);
				((DbParameter)val5).Value = DBNull.Value;
			}
			obj[4] = val5;
			MySqlParameter val6 = new MySqlParameter("@ToUserID", 253, 36);
			((DbParameter)val6).Value = model.ToUserID;
			obj[5] = val6;
			MySqlParameter val7 = new MySqlParameter("@WriteTime", 12, -1);
			((DbParameter)val7).Value = model.WriteTime;
			obj[6] = val7;
			_003F val8;
			if (model.Note != null)
			{
				val8 = new MySqlParameter("@Note", 752, -1);
				((DbParameter)val8).Value = model.Note;
			}
			else
			{
				val8 = new MySqlParameter("@Note", 752, -1);
				((DbParameter)val8).Value = DBNull.Value;
			}
			obj[7] = val8;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.WorkFlowDelegation model)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0051: Expected O, but got Unknown
			//IL_0052: Expected O, but got Unknown
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0061: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Expected O, but got Unknown
			//IL_0073: Expected O, but got Unknown
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a7: Expected O, but got Unknown
			//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c5: Expected O, but got Unknown
			//IL_00c6: Expected O, but got Unknown
			//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ea: Expected O, but got Unknown
			//IL_00eb: Expected O, but got Unknown
			//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_010b: Expected O, but got Unknown
			//IL_010c: Expected O, but got Unknown
			//IL_0121: Unknown result type (might be due to invalid IL or missing references)
			//IL_0126: Unknown result type (might be due to invalid IL or missing references)
			//IL_0132: Expected O, but got Unknown
			//IL_013f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0144: Unknown result type (might be due to invalid IL or missing references)
			//IL_014f: Expected O, but got Unknown
			//IL_0150: Expected O, but got Unknown
			//IL_015e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0174: Expected O, but got Unknown
			//IL_0175: Expected O, but got Unknown
			string sql = "UPDATE workflowdelegation SET \r\n\t\t\t\tUserID=@UserID,StartTime=@StartTime,EndTime=@EndTime,FlowID=@FlowID,ToUserID=@ToUserID,WriteTime=@WriteTime,Note=@Note\r\n\t\t\t\tWHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[8];
			MySqlParameter val = new MySqlParameter("@UserID", 253, 36);
			((DbParameter)val).Value = model.UserID;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@StartTime", 12, -1);
			((DbParameter)val2).Value = model.StartTime;
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@EndTime", 12, -1);
			((DbParameter)val3).Value = model.EndTime;
			obj[2] = val3;
			_003F val4;
			if (model.FlowID.HasValue)
			{
				val4 = new MySqlParameter("@FlowID", 253, 36);
				((DbParameter)val4).Value = model.FlowID;
			}
			else
			{
				val4 = new MySqlParameter("@FlowID", 253, 36);
				((DbParameter)val4).Value = DBNull.Value;
			}
			obj[3] = val4;
			MySqlParameter val5 = new MySqlParameter("@ToUserID", 253, 36);
			((DbParameter)val5).Value = model.ToUserID;
			obj[4] = val5;
			MySqlParameter val6 = new MySqlParameter("@WriteTime", 12, -1);
			((DbParameter)val6).Value = model.WriteTime;
			obj[5] = val6;
			_003F val7;
			if (model.Note != null)
			{
				val7 = new MySqlParameter("@Note", 752, -1);
				((DbParameter)val7).Value = model.Note;
			}
			else
			{
				val7 = new MySqlParameter("@Note", 752, -1);
				((DbParameter)val7).Value = DBNull.Value;
			}
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
			string sql = "DELETE FROM workflowdelegation WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.WorkFlowDelegation> DataReaderToList(MySqlDataReader dataReader)
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
			string sql = "SELECT * FROM workflowdelegation";
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.WorkFlowDelegation> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM workflowdelegation";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.WorkFlowDelegation Get(Guid id)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Expected O, but got Unknown
			string sql = "SELECT * FROM workflowdelegation WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
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
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Expected O, but got Unknown
			//IL_002a: Expected O, but got Unknown
			string sql = "SELECT * FROM WorkFlowDelegation WHERE UserID=@UserID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@UserID", 253);
			((DbParameter)val).Value = userID;
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.WorkFlowDelegation> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public List<RoadFlow.Data.Model.WorkFlowDelegation> GetPagerData(out string pager, string query = "", string userID = "", string startTime = "", string endTime = "")
		{
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Expected O, but got Unknown
			//IL_003c: Expected O, but got Unknown
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0083: Expected O, but got Unknown
			//IL_0088: Expected O, but got Unknown
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e1: Expected O, but got Unknown
			//IL_00e6: Expected O, but got Unknown
			StringBuilder stringBuilder = new StringBuilder();
			List<MySqlParameter> list = new List<MySqlParameter>();
			if (userID.IsGuid())
			{
				stringBuilder.Append("AND UserID=@UserID ");
				List<MySqlParameter> list2 = list;
				MySqlParameter val = new MySqlParameter("@UserID", 253);
				((DbParameter)val).Value = userID;
				list2.Add(val);
			}
			if (startTime.IsDateTime())
			{
				stringBuilder.Append("AND StartTime>=@StartTime ");
				List<MySqlParameter> list3 = list;
				MySqlParameter val2 = new MySqlParameter("@StartTime", 12);
				((DbParameter)val2).Value = startTime.ToDateTime().ToString("yyyy-MM-dd").ToDateTime();
				list3.Add(val2);
			}
			if (endTime.IsDateTime())
			{
				stringBuilder.Append("AND EndTime<=@EndTime ");
				List<MySqlParameter> list4 = list;
				MySqlParameter val3 = new MySqlParameter("@EndTime", 12);
				((DbParameter)val3).Value = endTime.ToDateTime().AddDays(1.0).ToString("yyyy-MM-dd")
					.ToDateTime();
				list4.Add(val3);
			}
			int pageSize = Tools.GetPageSize();
			int pageNumber = Tools.GetPageNumber();
			long count;
			string paerSql = dbHelper.GetPaerSql("WorkFlowDelegation", "*", stringBuilder.ToString(), "WriteTime Desc", pageSize, pageNumber, out count, list.ToArray());
			pager = Tools.GetPagerHtml(count, pageSize, pageNumber, query);
			MySqlDataReader dataReader = dbHelper.GetDataReader(paerSql, list.ToArray());
			List<RoadFlow.Data.Model.WorkFlowDelegation> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public List<RoadFlow.Data.Model.WorkFlowDelegation> GetPagerData(out long count, int pageSize, int pageNumber, string userID = "", string startTime = "", string endTime = "", string order = "")
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Expected O, but got Unknown
			//IL_003e: Expected O, but got Unknown
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0085: Expected O, but got Unknown
			//IL_008a: Expected O, but got Unknown
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e3: Expected O, but got Unknown
			//IL_00e8: Expected O, but got Unknown
			StringBuilder stringBuilder = new StringBuilder();
			List<MySqlParameter> list = new List<MySqlParameter>();
			if (userID.IsGuid())
			{
				stringBuilder.Append("AND UserID=@UserID ");
				List<MySqlParameter> list2 = list;
				MySqlParameter val = new MySqlParameter("@UserID", 253);
				((DbParameter)val).Value = userID;
				list2.Add(val);
			}
			if (startTime.IsDateTime())
			{
				stringBuilder.Append("AND StartTime>=@StartTime ");
				List<MySqlParameter> list3 = list;
				MySqlParameter val2 = new MySqlParameter("@StartTime", 12);
				((DbParameter)val2).Value = startTime.ToDateTime().ToString("yyyy-MM-dd").ToDateTime();
				list3.Add(val2);
			}
			if (endTime.IsDateTime())
			{
				stringBuilder.Append("AND EndTime<=@EndTime ");
				List<MySqlParameter> list4 = list;
				MySqlParameter val3 = new MySqlParameter("@EndTime", 12);
				((DbParameter)val3).Value = endTime.ToDateTime().AddDays(1.0).ToString("yyyy-MM-dd")
					.ToDateTime();
				list4.Add(val3);
			}
			string paerSql = dbHelper.GetPaerSql("WorkFlowDelegation", "*", stringBuilder.ToString(), order.IsNullOrEmpty() ? "WriteTime Desc" : order, pageSize, pageNumber, out count, list.ToArray());
			MySqlDataReader dataReader = dbHelper.GetDataReader(paerSql, list.ToArray());
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
			string sql = "SELECT * FROM WorkFlowDelegation WHERE EndTime>=@EndTime";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@EndTime", 12);
			((DbParameter)val).Value = DateTimeNew.Now;
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.WorkFlowDelegation> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}
	}
}
