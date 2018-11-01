using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RoadFlow.Data.MSSQL
{
	public class DocumentDirectory : IDocumentDirectory
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.DocumentDirectory model)
		{
			string sql = "INSERT INTO DocumentDirectory\r\n\t\t\t\t(ID,ParentID,Name,ReadUsers,ManageUsers,PublishUsers,Sort) \r\n\t\t\t\tVALUES(@ID,@ParentID,@Name,@ReadUsers,@ManageUsers,@PublishUsers,@Sort)";
			SqlParameter[] parameter = new SqlParameter[7]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ID
				},
				new SqlParameter("@ParentID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ParentID
				},
				new SqlParameter("@Name", SqlDbType.NVarChar, 1000)
				{
					Value = model.Name
				},
				(model.ReadUsers == null) ? new SqlParameter("@ReadUsers", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@ReadUsers", SqlDbType.VarChar, -1)
				{
					Value = model.ReadUsers
				},
				(model.ManageUsers == null) ? new SqlParameter("@ManageUsers", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@ManageUsers", SqlDbType.VarChar, -1)
				{
					Value = model.ManageUsers
				},
				(model.PublishUsers == null) ? new SqlParameter("@PublishUsers", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@PublishUsers", SqlDbType.VarChar, -1)
				{
					Value = model.PublishUsers
				},
				new SqlParameter("@Sort", SqlDbType.Int, -1)
				{
					Value = model.Sort
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.DocumentDirectory model)
		{
			string sql = "UPDATE DocumentDirectory SET \r\n\t\t\t\tParentID=@ParentID,Name=@Name,ReadUsers=@ReadUsers,ManageUsers=@ManageUsers,PublishUsers=@PublishUsers,Sort=@Sort\r\n\t\t\t\tWHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[7]
			{
				new SqlParameter("@ParentID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ParentID
				},
				new SqlParameter("@Name", SqlDbType.NVarChar, 1000)
				{
					Value = model.Name
				},
				(model.ReadUsers == null) ? new SqlParameter("@ReadUsers", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@ReadUsers", SqlDbType.VarChar, -1)
				{
					Value = model.ReadUsers
				},
				(model.ManageUsers == null) ? new SqlParameter("@ManageUsers", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@ManageUsers", SqlDbType.VarChar, -1)
				{
					Value = model.ManageUsers
				},
				(model.PublishUsers == null) ? new SqlParameter("@PublishUsers", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@PublishUsers", SqlDbType.VarChar, -1)
				{
					Value = model.PublishUsers
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
			string sql = "DELETE FROM DocumentDirectory WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.DocumentDirectory> DataReaderToList(SqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.DocumentDirectory> list = new List<RoadFlow.Data.Model.DocumentDirectory>();
			RoadFlow.Data.Model.DocumentDirectory documentDirectory = null;
			while (dataReader.Read())
			{
				documentDirectory = new RoadFlow.Data.Model.DocumentDirectory();
				documentDirectory.ID = dataReader.GetGuid(0);
				documentDirectory.ParentID = dataReader.GetGuid(1);
				documentDirectory.Name = dataReader.GetString(2);
				if (!dataReader.IsDBNull(3))
				{
					documentDirectory.ReadUsers = dataReader.GetString(3);
				}
				if (!dataReader.IsDBNull(4))
				{
					documentDirectory.ManageUsers = dataReader.GetString(4);
				}
				if (!dataReader.IsDBNull(5))
				{
					documentDirectory.PublishUsers = dataReader.GetString(5);
				}
				documentDirectory.Sort = dataReader.GetInt32(6);
				list.Add(documentDirectory);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.DocumentDirectory> GetAll()
		{
			string sql = "SELECT * FROM DocumentDirectory";
			SqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.DocumentDirectory> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM DocumentDirectory";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.DocumentDirectory Get(Guid id)
		{
			string sql = "SELECT * FROM DocumentDirectory WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.DocumentDirectory> list = DataReaderToList(dataReader);
			dataReader.Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public List<RoadFlow.Data.Model.DocumentDirectory> GetChilds(Guid id)
		{
			string sql = "SELECT * FROM DocumentDirectory WHERE ParentID=@ParentID ORDER BY Sort";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ParentID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.DocumentDirectory> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public int GetMaxSort(Guid dirID)
		{
			string sql = "SELECT (ISNULL(MAX(Sort),0)+5) Sort FROM DocumentDirectory WHERE ParentID=@ParentID ";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ParentID", dirID)
			};
			return dbHelper.GetFieldValue(sql, parameter).ToInt();
		}
	}
}
