using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace RoadFlow.Data.ORACLE
{
	public class WorkFlowComment : IWorkFlowComment
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.WorkFlowComment model)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Expected O, but got Unknown
			//IL_002c: Expected O, but got Unknown
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Expected O, but got Unknown
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Expected O, but got Unknown
			//IL_0068: Expected O, but got Unknown
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Expected O, but got Unknown
			//IL_0083: Expected O, but got Unknown
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Expected O, but got Unknown
			//IL_00a3: Expected O, but got Unknown
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c2: Expected O, but got Unknown
			//IL_00c3: Expected O, but got Unknown
			string sql = "INSERT INTO WorkFlowComment\r\n\t\t\t\t(ID,MemberID,Comment1,Type,Sort) \r\n\t\t\t\tVALUES(:ID,:MemberID,:Comment1,:Type,:Sort)";
			OracleParameter[] obj = new OracleParameter[5];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			_003F val2;
			if (model.MemberID != null)
			{
				val2 = new OracleParameter(":MemberID", 105);
				((DbParameter)val2).Value = model.MemberID;
			}
			else
			{
				val2 = new OracleParameter(":MemberID", 105);
				((DbParameter)val2).Value = DBNull.Value;
			}
			obj[1] = val2;
			OracleParameter val3 = new OracleParameter(":Comment1", 119);
			((DbParameter)val3).Value = model.Comment;
			obj[2] = val3;
			OracleParameter val4 = new OracleParameter(":Type", 112);
			((DbParameter)val4).Value = model.Type;
			obj[3] = val4;
			OracleParameter val5 = new OracleParameter(":Sort", 112);
			((DbParameter)val5).Value = model.Sort;
			obj[4] = val5;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.WorkFlowComment model)
		{
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Expected O, but got Unknown
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Expected O, but got Unknown
			//IL_0048: Expected O, but got Unknown
			//IL_0051: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Unknown result type (might be due to invalid IL or missing references)
			//IL_0062: Expected O, but got Unknown
			//IL_0063: Expected O, but got Unknown
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Expected O, but got Unknown
			//IL_0083: Expected O, but got Unknown
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Expected O, but got Unknown
			//IL_00a3: Expected O, but got Unknown
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c2: Expected O, but got Unknown
			//IL_00c3: Expected O, but got Unknown
			string sql = "UPDATE WorkFlowComment SET \r\n\t\t\t\tMemberID=:MemberID,Comment1=:Comment1,Type=:Type,Sort=:Sort\r\n\t\t\t\tWHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[5];
			_003F val;
			if (model.MemberID != null)
			{
				val = new OracleParameter(":MemberID", 105);
				((DbParameter)val).Value = model.MemberID;
			}
			else
			{
				val = new OracleParameter(":MemberID", 105);
				((DbParameter)val).Value = DBNull.Value;
			}
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":Comment1", 119);
			((DbParameter)val2).Value = model.Comment;
			obj[1] = val2;
			OracleParameter val3 = new OracleParameter(":Type", 112);
			((DbParameter)val3).Value = model.Type;
			obj[2] = val3;
			OracleParameter val4 = new OracleParameter(":Sort", 112);
			((DbParameter)val4).Value = model.Sort;
			obj[3] = val4;
			OracleParameter val5 = new OracleParameter(":ID", 126);
			((DbParameter)val5).Value = model.ID;
			obj[4] = val5;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Delete(Guid id)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "DELETE FROM WorkFlowComment WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.WorkFlowComment> DataReaderToList(OracleDataReader dataReader)
		{
			List<RoadFlow.Data.Model.WorkFlowComment> list = new List<RoadFlow.Data.Model.WorkFlowComment>();
			RoadFlow.Data.Model.WorkFlowComment workFlowComment = null;
			while (((DbDataReader)dataReader).Read())
			{
				workFlowComment = new RoadFlow.Data.Model.WorkFlowComment();
				workFlowComment.ID = ((DbDataReader)dataReader).GetString(0).ToGuid();
				if (!((DbDataReader)dataReader).IsDBNull(1))
				{
					workFlowComment.MemberID = ((DbDataReader)dataReader).GetString(1);
				}
				workFlowComment.Comment = ((DbDataReader)dataReader).GetString(2);
				workFlowComment.Type = ((DbDataReader)dataReader).GetInt32(3);
				workFlowComment.Sort = ((DbDataReader)dataReader).GetInt32(4);
				list.Add(workFlowComment);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.WorkFlowComment> GetAll()
		{
			string sql = "SELECT * FROM WorkFlowComment";
			OracleDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.WorkFlowComment> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM WorkFlowComment";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.WorkFlowComment Get(Guid id)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "SELECT * FROM WorkFlowComment WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
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
			OracleDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.WorkFlowComment> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public int GetManagerMaxSort()
		{
			string sql = "SELECT nvl(MAX(Sort)+1,1) FROM WorkFlowComment WHERE Type=0";
			OracleDataReader dataReader = dbHelper.GetDataReader(sql);
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
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "SELECT nvl(MAX(Sort)+1,1) FROM WorkFlowComment WHERE MemberID=:MemberID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":MemberID", 126);
			((DbParameter)val).Value = userID;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
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
