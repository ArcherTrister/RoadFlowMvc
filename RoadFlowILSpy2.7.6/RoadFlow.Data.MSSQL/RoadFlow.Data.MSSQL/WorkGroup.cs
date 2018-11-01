using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RoadFlow.Data.MSSQL
{
	public class WorkGroup : IWorkGroup
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.WorkGroup model)
		{
			string sql = "INSERT INTO WorkGroup\r\n\t\t\t\t(ID,Name,Members,Note,IntID) \r\n\t\t\t\tVALUES(@ID,@Name,@Members,@Note,@IntID)";
			SqlParameter[] parameter = new SqlParameter[5]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ID
				},
				new SqlParameter("@Name", SqlDbType.NVarChar, 1000)
				{
					Value = model.Name
				},
				new SqlParameter("@Members", SqlDbType.VarChar, -1)
				{
					Value = model.Members
				},
				(model.Note == null) ? new SqlParameter("@Note", SqlDbType.NVarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Note", SqlDbType.NVarChar, -1)
				{
					Value = model.Note
				},
				new SqlParameter("@IntID", SqlDbType.Int, -1)
				{
					Value = model.IntID
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.WorkGroup model)
		{
			string sql = "UPDATE WorkGroup SET \r\n\t\t\t\tName=@Name,Members=@Members,Note=@Note,IntID=@IntID \r\n\t\t\t\tWHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[5]
			{
				new SqlParameter("@Name", SqlDbType.NVarChar, 1000)
				{
					Value = model.Name
				},
				new SqlParameter("@Members", SqlDbType.VarChar, -1)
				{
					Value = model.Members
				},
				(model.Note == null) ? new SqlParameter("@Note", SqlDbType.NVarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Note", SqlDbType.NVarChar, -1)
				{
					Value = model.Note
				},
				new SqlParameter("@IntID", SqlDbType.Int, -1)
				{
					Value = model.IntID
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
			string sql = "DELETE FROM WorkGroup WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.WorkGroup> DataReaderToList(SqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.WorkGroup> list = new List<RoadFlow.Data.Model.WorkGroup>();
			RoadFlow.Data.Model.WorkGroup workGroup = null;
			while (dataReader.Read())
			{
				workGroup = new RoadFlow.Data.Model.WorkGroup();
				workGroup.ID = dataReader.GetGuid(0);
				workGroup.Name = dataReader.GetString(1);
				workGroup.Members = dataReader.GetString(2);
				if (!dataReader.IsDBNull(3))
				{
					workGroup.Note = dataReader.GetString(3);
				}
				workGroup.IntID = dataReader.GetInt32(4);
				list.Add(workGroup);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.WorkGroup> GetAll()
		{
			string sql = "SELECT * FROM WorkGroup";
			SqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.WorkGroup> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM WorkGroup";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.WorkGroup Get(Guid id)
		{
			string sql = "SELECT * FROM WorkGroup WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.WorkGroup> list = DataReaderToList(dataReader);
			dataReader.Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}
	}
}
