using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace RoadFlow.Data.MySql
{
	public class WorkFlowComment : IWorkFlowComment
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.WorkFlowComment model)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Expected O, but got Unknown
			//IL_0050: Expected O, but got Unknown
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Expected O, but got Unknown
			//IL_006f: Expected O, but got Unknown
			//IL_0079: Unknown result type (might be due to invalid IL or missing references)
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Expected O, but got Unknown
			//IL_0090: Expected O, but got Unknown
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_009f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b0: Expected O, but got Unknown
			//IL_00b1: Expected O, but got Unknown
			string sql = "INSERT INTO workflowcomment\r\n\t\t\t\t(ID,MemberID,Comment,Type,Sort) \r\n\t\t\t\tVALUES(@ID,@MemberID,@Comment,@Type,@Sort)";
			MySqlParameter[] obj = new MySqlParameter[5];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@MemberID", 751, -1);
			((DbParameter)val2).Value = model.MemberID;
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@Comment", 752, -1);
			((DbParameter)val3).Value = model.Comment;
			obj[2] = val3;
			MySqlParameter val4 = new MySqlParameter("@Type", 3, 11);
			((DbParameter)val4).Value = model.Type;
			obj[3] = val4;
			MySqlParameter val5 = new MySqlParameter("@Sort", 3, 11);
			((DbParameter)val5).Value = model.Sort;
			obj[4] = val5;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.WorkFlowComment model)
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Expected O, but got Unknown
			//IL_002b: Expected O, but got Unknown
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0049: Expected O, but got Unknown
			//IL_004a: Expected O, but got Unknown
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Expected O, but got Unknown
			//IL_006b: Expected O, but got Unknown
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Expected O, but got Unknown
			//IL_008c: Expected O, but got Unknown
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_009f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b0: Expected O, but got Unknown
			//IL_00b1: Expected O, but got Unknown
			string sql = "UPDATE workflowcomment SET \r\n\t\t\t\tMemberID=@MemberID,Comment=@Comment,Type=@Type,Sort=@Sort\r\n\t\t\t\tWHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[5];
			MySqlParameter val = new MySqlParameter("@MemberID", 751, -1);
			((DbParameter)val).Value = model.MemberID;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@Comment", 752, -1);
			((DbParameter)val2).Value = model.Comment;
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@Type", 3, 11);
			((DbParameter)val3).Value = model.Type;
			obj[2] = val3;
			MySqlParameter val4 = new MySqlParameter("@Sort", 3, 11);
			((DbParameter)val4).Value = model.Sort;
			obj[3] = val4;
			MySqlParameter val5 = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val5).Value = model.ID;
			obj[4] = val5;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Delete(Guid id)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Expected O, but got Unknown
			string sql = "DELETE FROM workflowcomment WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.WorkFlowComment> DataReaderToList(MySqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.WorkFlowComment> list = new List<RoadFlow.Data.Model.WorkFlowComment>();
			RoadFlow.Data.Model.WorkFlowComment workFlowComment = null;
			while (((DbDataReader)dataReader).Read())
			{
				workFlowComment = new RoadFlow.Data.Model.WorkFlowComment();
				workFlowComment.ID = ((DbDataReader)dataReader).GetString(0).ToGuid();
				workFlowComment.MemberID = ((DbDataReader)dataReader).GetString(1);
				workFlowComment.Comment = ((DbDataReader)dataReader).GetString(2);
				workFlowComment.Type = ((DbDataReader)dataReader).GetInt32(3);
				workFlowComment.Sort = ((DbDataReader)dataReader).GetInt32(4);
				list.Add(workFlowComment);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.WorkFlowComment> GetAll()
		{
			string sql = "SELECT * FROM workflowcomment";
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.WorkFlowComment> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM workflowcomment";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.WorkFlowComment Get(Guid id)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Expected O, but got Unknown
			string sql = "SELECT * FROM workflowcomment WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.WorkFlowComment> list = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public List<RoadFlow.Data.Model.WorkFlowComment> GetManagerAll()
		{
			string sql = "SELECT * FROM WorkFlowComment WHERE Type=0";
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.WorkFlowComment> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public int GetManagerMaxSort()
		{
			string sql = "SELECT IFNULL(MAX(Sort)+1,1) FROM WorkFlowComment WHERE Type=0";
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql);
			if (((DbDataReader)dataReader).HasRows)
			{
				((DbDataReader)dataReader).Read();
				int @int = ((DbDataReader)dataReader).GetInt32(0);
				((DbDataReader)dataReader).Close();
				return @int;
			}
			return 1;
		}

		public int GetUserMaxSort(Guid userID)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			string sql = "SELECT IFNULL(MAX(Sort)+1,1) FROM WorkFlowComment WHERE MemberID=@MemberID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@MemberID", 253);
			((DbParameter)val).Value = userID.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			if (((DbDataReader)dataReader).HasRows)
			{
				((DbDataReader)dataReader).Read();
				int @int = ((DbDataReader)dataReader).GetInt32(0);
				((DbDataReader)dataReader).Close();
				return @int;
			}
			return 1;
		}
	}
}
