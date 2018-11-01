using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RoadFlow.Data.MSSQL
{
	public class WorkFlowComment : IWorkFlowComment
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.WorkFlowComment model)
		{
			string sql = "INSERT INTO WorkFlowComment\r\n\t\t\t\t(ID,MemberID,Comment,Type,Sort) \r\n\t\t\t\tVALUES(@ID,@MemberID,@Comment,@Type,@Sort)";
			SqlParameter[] parameter = new SqlParameter[5]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ID
				},
				new SqlParameter("@MemberID", SqlDbType.VarChar, -1)
				{
					Value = model.MemberID
				},
				new SqlParameter("@Comment", SqlDbType.NVarChar, 1000)
				{
					Value = model.Comment
				},
				new SqlParameter("@Type", SqlDbType.Int, -1)
				{
					Value = model.Type
				},
				new SqlParameter("@Sort", SqlDbType.Int, -1)
				{
					Value = model.Sort
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.WorkFlowComment model)
		{
			string sql = "UPDATE WorkFlowComment SET \r\n\t\t\t\tMemberID=@MemberID,Comment=@Comment,Type=@Type,Sort=@Sort\r\n\t\t\t\tWHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[5]
			{
				new SqlParameter("@MemberID", SqlDbType.VarChar, -1)
				{
					Value = model.MemberID
				},
				new SqlParameter("@Comment", SqlDbType.NVarChar, 1000)
				{
					Value = model.Comment
				},
				new SqlParameter("@Type", SqlDbType.Int, -1)
				{
					Value = model.Type
				},
				new SqlParameter("@Sort", SqlDbType.Int, -1)
				{
					Value = model.Sort
				},
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ID
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public int Delete(Guid id)
		{
			string sql = "DELETE FROM WorkFlowComment WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.WorkFlowComment> DataReaderToList(SqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.WorkFlowComment> list = new List<RoadFlow.Data.Model.WorkFlowComment>();
			RoadFlow.Data.Model.WorkFlowComment workFlowComment = null;
			while (dataReader.Read())
			{
				workFlowComment = new RoadFlow.Data.Model.WorkFlowComment();
				workFlowComment.ID = dataReader.GetGuid(0);
				if (!dataReader.IsDBNull(1))
				{
					workFlowComment.MemberID = dataReader.GetString(1);
				}
				workFlowComment.Comment = dataReader.GetString(2);
				workFlowComment.Type = dataReader.GetInt32(3);
				workFlowComment.Sort = dataReader.GetInt32(4);
				list.Add(workFlowComment);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.WorkFlowComment> GetAll()
		{
			string sql = "SELECT * FROM WorkFlowComment";
			SqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.WorkFlowComment> result = DataReaderToList(dataReader);
			dataReader.Close();
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
			string sql = "SELECT * FROM WorkFlowComment WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.WorkFlowComment> list = DataReaderToList(dataReader);
			dataReader.Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public List<RoadFlow.Data.Model.WorkFlowComment> GetManagerAll()
		{
			string sql = "SELECT * FROM WorkFlowComment WHERE Type=0";
			SqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.WorkFlowComment> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public int GetManagerMaxSort()
		{
			string sql = "SELECT ISNULL(MAX(Sort)+1,1) FROM WorkFlowComment WHERE Type=0";
			SqlDataReader dataReader = dbHelper.GetDataReader(sql);
			if (dataReader.HasRows)
			{
				dataReader.Read();
				int @int = dataReader.GetInt32(0);
				dataReader.Close();
				return @int;
			}
			return 1;
		}

		public int GetUserMaxSort(Guid userID)
		{
			string sql = "SELECT ISNULL(MAX(Sort)+1,1) FROM WorkFlowComment WHERE MemberID=@MemberID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@MemberID", SqlDbType.UniqueIdentifier)
				{
					Value = userID
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			if (dataReader.HasRows)
			{
				dataReader.Read();
				int @int = dataReader.GetInt32(0);
				dataReader.Close();
				return @int;
			}
			return 1;
		}
	}
}
