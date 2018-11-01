using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RoadFlow.Data.MSSQL
{
	public class Menu : IMenu
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.Menu model)
		{
			string sql = "INSERT INTO Menu\r\n\t\t\t\t(ID,ParentID,AppLibraryID,Title,Params,Ico,Sort,IcoColor) \r\n\t\t\t\tVALUES(@ID,@ParentID,@AppLibraryID,@Title,@Params,@Ico,@Sort,@IcoColor)";
			SqlParameter[] parameter = new SqlParameter[8]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ID
				},
				new SqlParameter("@ParentID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ParentID
				},
				(!model.AppLibraryID.HasValue) ? new SqlParameter("@AppLibraryID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@AppLibraryID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.AppLibraryID
				},
				new SqlParameter("@Title", SqlDbType.NVarChar, 1000)
				{
					Value = model.Title
				},
				(model.Params == null) ? new SqlParameter("@Params", SqlDbType.VarChar, 5000)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Params", SqlDbType.VarChar, 5000)
				{
					Value = model.Params
				},
				(model.Ico == null) ? new SqlParameter("@Ico", SqlDbType.VarChar, 500)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Ico", SqlDbType.VarChar, 500)
				{
					Value = model.Ico
				},
				new SqlParameter("@Sort", SqlDbType.Int, -1)
				{
					Value = model.Sort
				},
				(model.IcoColor == null) ? new SqlParameter("@IcoColor", SqlDbType.VarChar, 50)
				{
					Value = DBNull.Value
				} : new SqlParameter("@IcoColor", SqlDbType.VarChar, 50)
				{
					Value = model.IcoColor
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.Menu model)
		{
			string sql = "UPDATE Menu SET \r\n\t\t\t\tParentID=@ParentID,AppLibraryID=@AppLibraryID,Title=@Title,Params=@Params,Ico=@Ico,Sort=@Sort,IcoColor=@IcoColor \r\n\t\t\t\tWHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[8]
			{
				new SqlParameter("@ParentID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ParentID
				},
				(!model.AppLibraryID.HasValue) ? new SqlParameter("@AppLibraryID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@AppLibraryID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.AppLibraryID
				},
				new SqlParameter("@Title", SqlDbType.NVarChar, 1000)
				{
					Value = model.Title
				},
				(model.Params == null) ? new SqlParameter("@Params", SqlDbType.VarChar, 5000)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Params", SqlDbType.VarChar, 5000)
				{
					Value = model.Params
				},
				(model.Ico == null) ? new SqlParameter("@Ico", SqlDbType.VarChar, 500)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Ico", SqlDbType.VarChar, 500)
				{
					Value = model.Ico
				},
				new SqlParameter("@Sort", SqlDbType.Int, -1)
				{
					Value = model.Sort
				},
				(model.IcoColor == null) ? new SqlParameter("@IcoColor", SqlDbType.VarChar, 50)
				{
					Value = DBNull.Value
				} : new SqlParameter("@IcoColor", SqlDbType.VarChar, 50)
				{
					Value = model.IcoColor
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
			string sql = "DELETE FROM Menu WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.Menu> DataReaderToList(SqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.Menu> list = new List<RoadFlow.Data.Model.Menu>();
			RoadFlow.Data.Model.Menu menu = null;
			while (dataReader.Read())
			{
				menu = new RoadFlow.Data.Model.Menu();
				menu.ID = dataReader.GetGuid(0);
				menu.ParentID = dataReader.GetGuid(1);
				if (!dataReader.IsDBNull(2))
				{
					menu.AppLibraryID = dataReader.GetGuid(2);
				}
				menu.Title = dataReader.GetString(3);
				if (!dataReader.IsDBNull(4))
				{
					menu.Params = dataReader.GetString(4);
				}
				if (!dataReader.IsDBNull(5))
				{
					menu.Ico = dataReader.GetString(5);
				}
				menu.Sort = dataReader.GetInt32(6);
				if (!dataReader.IsDBNull(7))
				{
					menu.IcoColor = dataReader.GetString(7);
				}
				list.Add(menu);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.Menu> GetAll()
		{
			string sql = "SELECT * FROM Menu";
			SqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.Menu> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM Menu";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.Menu Get(Guid id)
		{
			string sql = "SELECT * FROM Menu WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.Menu> list = DataReaderToList(dataReader);
			dataReader.Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public DataTable GetAllDataTable()
		{
			string sql = "SELECT a.*,b.Address,b.OpenMode,b.Width,b.Height,b.Params AS Params1,b.Ico AS AppIco,b.Color AS IcoColor1 FROM Menu a LEFT JOIN AppLibrary b ON a.AppLibraryID=b.ID ORDER BY a.Sort";
			return dbHelper.GetDataTable(sql);
		}

		public List<RoadFlow.Data.Model.Menu> GetChild(Guid id)
		{
			string sql = "SELECT * FROM Menu WHERE ParentID=@ParentID ORDER BY Sort";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ParentID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.Menu> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public bool HasChild(Guid id)
		{
			string sql = "SELECT TOP 1 ID FROM Menu WHERE ParentID=@ParentID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ParentID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			bool hasRows = dataReader.HasRows;
			dataReader.Close();
			return hasRows;
		}

		public int UpdateSort(Guid id, int sort)
		{
			string sql = "UPDATE Menu SET Sort=@Sort WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[2]
			{
				new SqlParameter("@Sort", SqlDbType.Int)
				{
					Value = sort
				},
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public int GetMaxSort(Guid id)
		{
			string sql = "SELECT ISNULL(MAX(Sort),0)+1 FROM Menu WHERE ParentID=@ParentID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ParentID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			int test;
			if (!dbHelper.GetFieldValue(sql, parameter).IsInt(out test))
			{
				return 1;
			}
			return test;
		}

		public List<RoadFlow.Data.Model.Menu> GetAllByApplibaryID(Guid applibaryID)
		{
			string sql = "SELECT * FROM Menu WHERE AppLibraryID=@AppLibraryID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@AppLibraryID", SqlDbType.UniqueIdentifier)
				{
					Value = applibaryID
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.Menu> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}
	}
}
