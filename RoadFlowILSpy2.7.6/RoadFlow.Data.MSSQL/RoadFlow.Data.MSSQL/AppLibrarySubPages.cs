using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RoadFlow.Data.MSSQL
{
	public class AppLibrarySubPages : IAppLibrarySubPages
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.AppLibrarySubPages model)
		{
			string sql = "INSERT INTO AppLibrarySubPages\r\n\t\t\t\t(ID,AppLibraryID,Name,Address,Ico,Sort,Note) \r\n\t\t\t\tVALUES(@ID,@AppLibraryID,@Name,@Address,@Ico,@Sort,@Note)";
			SqlParameter[] parameter = new SqlParameter[7]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ID
				},
				new SqlParameter("@AppLibraryID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.AppLibraryID
				},
				new SqlParameter("@Name", SqlDbType.NVarChar, 1000)
				{
					Value = model.Name
				},
				new SqlParameter("@Address", SqlDbType.VarChar, 5000)
				{
					Value = model.Address
				},
				(model.Ico == null) ? new SqlParameter("@Ico", SqlDbType.VarChar, 5000)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Ico", SqlDbType.VarChar, 5000)
				{
					Value = model.Ico
				},
				new SqlParameter("@Sort", SqlDbType.Int, -1)
				{
					Value = model.Sort
				},
				(model.Note == null) ? new SqlParameter("@Note", SqlDbType.NVarChar, 4000)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Note", SqlDbType.NVarChar, 4000)
				{
					Value = model.Note
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.AppLibrarySubPages model)
		{
			string sql = "UPDATE AppLibrarySubPages SET \r\n\t\t\t\tAppLibraryID=@AppLibraryID,Name=@Name,Address=@Address,Ico=@Ico,Sort=@Sort,Note=@Note\r\n\t\t\t\tWHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[7]
			{
				new SqlParameter("@AppLibraryID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.AppLibraryID
				},
				new SqlParameter("@Name", SqlDbType.NVarChar, 1000)
				{
					Value = model.Name
				},
				new SqlParameter("@Address", SqlDbType.VarChar, 5000)
				{
					Value = model.Address
				},
				(model.Ico == null) ? new SqlParameter("@Ico", SqlDbType.VarChar, 5000)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Ico", SqlDbType.VarChar, 5000)
				{
					Value = model.Ico
				},
				new SqlParameter("@Sort", SqlDbType.Int, -1)
				{
					Value = model.Sort
				},
				(model.Note == null) ? new SqlParameter("@Note", SqlDbType.NVarChar, 4000)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Note", SqlDbType.NVarChar, 4000)
				{
					Value = model.Note
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
			string sql = "DELETE FROM AppLibrarySubPages WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.AppLibrarySubPages> DataReaderToList(SqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.AppLibrarySubPages> list = new List<RoadFlow.Data.Model.AppLibrarySubPages>();
			RoadFlow.Data.Model.AppLibrarySubPages appLibrarySubPages = null;
			while (dataReader.Read())
			{
				appLibrarySubPages = new RoadFlow.Data.Model.AppLibrarySubPages();
				appLibrarySubPages.ID = dataReader.GetGuid(0);
				appLibrarySubPages.AppLibraryID = dataReader.GetGuid(1);
				appLibrarySubPages.Name = dataReader.GetString(2);
				appLibrarySubPages.Address = dataReader.GetString(3);
				if (!dataReader.IsDBNull(4))
				{
					appLibrarySubPages.Ico = dataReader.GetString(4);
				}
				appLibrarySubPages.Sort = dataReader.GetInt32(5);
				if (!dataReader.IsDBNull(6))
				{
					appLibrarySubPages.Note = dataReader.GetString(6);
				}
				list.Add(appLibrarySubPages);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.AppLibrarySubPages> GetAll()
		{
			string sql = "SELECT * FROM AppLibrarySubPages";
			SqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.AppLibrarySubPages> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM AppLibrarySubPages";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.AppLibrarySubPages Get(Guid id)
		{
			string sql = "SELECT * FROM AppLibrarySubPages WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.AppLibrarySubPages> list = DataReaderToList(dataReader);
			dataReader.Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public int DeleteByAppID(Guid id)
		{
			string sql = "DELETE FROM AppLibrarySubPages WHERE AppLibraryID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public List<RoadFlow.Data.Model.AppLibrarySubPages> GetAllByAppID(Guid id)
		{
			string sql = "SELECT * FROM AppLibrarySubPages WHERE AppLibraryID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.AppLibrarySubPages> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}
	}
}
