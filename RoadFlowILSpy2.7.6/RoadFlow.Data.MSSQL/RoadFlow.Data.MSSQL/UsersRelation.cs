using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RoadFlow.Data.MSSQL
{
	public class UsersRelation : IUsersRelation
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.UsersRelation model)
		{
			string sql = "INSERT INTO UsersRelation\r\n\t\t\t\t(UserID,OrganizeID,IsMain,Sort) \r\n\t\t\t\tVALUES(@UserID,@OrganizeID,@IsMain,@Sort)";
			SqlParameter[] parameter = new SqlParameter[4]
			{
				new SqlParameter("@UserID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.UserID
				},
				new SqlParameter("@OrganizeID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.OrganizeID
				},
				new SqlParameter("@IsMain", SqlDbType.Int, -1)
				{
					Value = model.IsMain
				},
				new SqlParameter("@Sort", SqlDbType.Int, -1)
				{
					Value = model.Sort
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.UsersRelation model)
		{
			string sql = "UPDATE UsersRelation SET \r\n\t\t\t\tIsMain=@IsMain,Sort=@Sort\r\n\t\t\t\tWHERE UserID=@UserID and OrganizeID=@OrganizeID";
			SqlParameter[] parameter = new SqlParameter[4]
			{
				new SqlParameter("@IsMain", SqlDbType.Int, -1)
				{
					Value = model.IsMain
				},
				new SqlParameter("@Sort", SqlDbType.Int, -1)
				{
					Value = model.Sort
				},
				new SqlParameter("@UserID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.UserID
				},
				new SqlParameter("@OrganizeID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.OrganizeID
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public int Delete(Guid userid, Guid organizeid)
		{
			string sql = "DELETE FROM UsersRelation WHERE UserID=@UserID AND OrganizeID=@OrganizeID";
			SqlParameter[] parameter = new SqlParameter[2]
			{
				new SqlParameter("@UserID", SqlDbType.UniqueIdentifier)
				{
					Value = userid
				},
				new SqlParameter("@OrganizeID", SqlDbType.UniqueIdentifier)
				{
					Value = organizeid
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.UsersRelation> DataReaderToList(SqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.UsersRelation> list = new List<RoadFlow.Data.Model.UsersRelation>();
			RoadFlow.Data.Model.UsersRelation usersRelation = null;
			while (dataReader.Read())
			{
				usersRelation = new RoadFlow.Data.Model.UsersRelation();
				usersRelation.UserID = dataReader.GetGuid(0);
				usersRelation.OrganizeID = dataReader.GetGuid(1);
				usersRelation.IsMain = dataReader.GetInt32(2);
				usersRelation.Sort = dataReader.GetInt32(3);
				list.Add(usersRelation);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.UsersRelation> GetAll()
		{
			string sql = "SELECT * FROM UsersRelation";
			SqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.UsersRelation> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM UsersRelation";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.UsersRelation Get(Guid userid, Guid organizeid)
		{
			string sql = "SELECT * FROM UsersRelation WHERE UserID=@UserID AND OrganizeID=@OrganizeID";
			SqlParameter[] parameter = new SqlParameter[2]
			{
				new SqlParameter("@UserID", SqlDbType.UniqueIdentifier)
				{
					Value = userid
				},
				new SqlParameter("@OrganizeID", SqlDbType.UniqueIdentifier)
				{
					Value = organizeid
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.UsersRelation> list = DataReaderToList(dataReader);
			dataReader.Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public List<RoadFlow.Data.Model.UsersRelation> GetAllByOrganizeID(Guid organizeID)
		{
			string sql = "SELECT * FROM UsersRelation WHERE OrganizeID=@OrganizeID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@OrganizeID", SqlDbType.UniqueIdentifier)
				{
					Value = organizeID
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.UsersRelation> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public List<RoadFlow.Data.Model.UsersRelation> GetAllByUserID(Guid userID)
		{
			string sql = "SELECT * FROM UsersRelation WHERE UserID=@UserID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@UserID", SqlDbType.UniqueIdentifier)
				{
					Value = userID
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.UsersRelation> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public RoadFlow.Data.Model.UsersRelation GetMainByUserID(Guid userID)
		{
			string sql = "SELECT * FROM UsersRelation WHERE UserID=@UserID AND IsMain=1";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@UserID", SqlDbType.UniqueIdentifier)
				{
					Value = userID
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.UsersRelation> list = DataReaderToList(dataReader);
			dataReader.Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public int DeleteByUserID(Guid userID)
		{
			string sql = "DELETE FROM UsersRelation WHERE UserID=@UserID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@UserID", SqlDbType.UniqueIdentifier)
				{
					Value = userID
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public int DeleteNotIsMainByUserID(Guid userID)
		{
			string sql = "DELETE FROM UsersRelation WHERE IsMain=0 AND UserID=@UserID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@UserID", SqlDbType.UniqueIdentifier)
				{
					Value = userID
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public int DeleteByOrganizeID(Guid organizeID)
		{
			string sql = "DELETE FROM UsersRelation WHERE OrganizeID=@OrganizeID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@OrganizeID", SqlDbType.UniqueIdentifier)
				{
					Value = organizeID
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public int GetMaxSort(Guid organizeID)
		{
			string sql = "SELECT ISNULL(MAX(Sort),0)+1 FROM UsersRelation WHERE OrganizeID=@OrganizeID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@OrganizeID", SqlDbType.UniqueIdentifier)
				{
					Value = organizeID
				}
			};
			return new DBHelper().GetFieldValue(sql, parameter).ToInt();
		}
	}
}
