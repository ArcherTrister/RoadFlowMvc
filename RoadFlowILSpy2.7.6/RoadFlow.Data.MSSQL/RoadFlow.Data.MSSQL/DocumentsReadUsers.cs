using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RoadFlow.Data.MSSQL
{
	public class DocumentsReadUsers : IDocumentsReadUsers
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.DocumentsReadUsers model)
		{
			string sql = "INSERT INTO DocumentsReadUsers\r\n\t\t\t\t(DocumentID,UserID,IsRead) \r\n\t\t\t\tVALUES(@DocumentID,@UserID,@IsRead)";
			SqlParameter[] parameter = new SqlParameter[3]
			{
				new SqlParameter("@DocumentID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.DocumentID
				},
				new SqlParameter("@UserID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.UserID
				},
				new SqlParameter("@IsRead", SqlDbType.Int, -1)
				{
					Value = model.IsRead
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.DocumentsReadUsers model)
		{
			string sql = "UPDATE DocumentsReadUsers SET \r\n\t\t\t\tIsRead=@IsRead\r\n\t\t\t\tWHERE DocumentID=@DocumentID and UserID=@UserID";
			SqlParameter[] parameter = new SqlParameter[3]
			{
				new SqlParameter("@IsRead", SqlDbType.Int, -1)
				{
					Value = model.IsRead
				},
				new SqlParameter("@DocumentID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.DocumentID
				},
				new SqlParameter("@UserID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.UserID
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public int Delete(Guid documentid, Guid userid)
		{
			string sql = "DELETE FROM DocumentsReadUsers WHERE DocumentID=@DocumentID AND UserID=@UserID";
			SqlParameter[] parameter = new SqlParameter[2]
			{
				new SqlParameter("@DocumentID", SqlDbType.UniqueIdentifier)
				{
					Value = documentid
				},
				new SqlParameter("@UserID", SqlDbType.UniqueIdentifier)
				{
					Value = userid
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.DocumentsReadUsers> DataReaderToList(SqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.DocumentsReadUsers> list = new List<RoadFlow.Data.Model.DocumentsReadUsers>();
			RoadFlow.Data.Model.DocumentsReadUsers documentsReadUsers = null;
			while (dataReader.Read())
			{
				documentsReadUsers = new RoadFlow.Data.Model.DocumentsReadUsers();
				documentsReadUsers.DocumentID = dataReader.GetGuid(0);
				documentsReadUsers.UserID = dataReader.GetGuid(1);
				documentsReadUsers.IsRead = dataReader.GetInt32(2);
				list.Add(documentsReadUsers);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.DocumentsReadUsers> GetAll()
		{
			string sql = "SELECT * FROM DocumentsReadUsers";
			SqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.DocumentsReadUsers> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM DocumentsReadUsers";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.DocumentsReadUsers Get(Guid documentid, Guid userid)
		{
			string sql = "SELECT * FROM DocumentsReadUsers WHERE DocumentID=@DocumentID AND UserID=@UserID";
			SqlParameter[] parameter = new SqlParameter[2]
			{
				new SqlParameter("@DocumentID", SqlDbType.UniqueIdentifier)
				{
					Value = documentid
				},
				new SqlParameter("@UserID", SqlDbType.UniqueIdentifier)
				{
					Value = userid
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.DocumentsReadUsers> list = DataReaderToList(dataReader);
			dataReader.Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public int Delete(Guid documentid)
		{
			string sql = "DELETE FROM DocumentsReadUsers WHERE DocumentID=@DocumentID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@DocumentID", SqlDbType.UniqueIdentifier)
				{
					Value = documentid
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public void UpdateRead(Guid docID, Guid userID)
		{
			string sql = "UPDATE DocumentsReadUsers SET IsRead=1 WHERE DocumentID=@DocumentID AND UserID=@UserID";
			SqlParameter[] parameter = new SqlParameter[2]
			{
				new SqlParameter("@DocumentID", SqlDbType.UniqueIdentifier)
				{
					Value = docID
				},
				new SqlParameter("@UserID", SqlDbType.UniqueIdentifier)
				{
					Value = userID
				}
			};
			dbHelper.Execute(sql, parameter);
		}
	}
}
