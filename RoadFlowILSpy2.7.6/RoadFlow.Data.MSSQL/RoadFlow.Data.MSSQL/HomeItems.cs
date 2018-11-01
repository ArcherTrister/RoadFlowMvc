using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RoadFlow.Data.MSSQL
{
	public class HomeItems : IHomeItems
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.HomeItems model)
		{
			string sql = "INSERT INTO HomeItems\r\n\t\t\t\t(ID,Type,Name,Title,DataSourceType,DataSource,Ico,BgColor,Color,DBConnID,LinkURL,UseOrganizes,UseUsers,Sort,Note) \r\n\t\t\t\tVALUES(@ID,@Type,@Name,@Title,@DataSourceType,@DataSource,@Ico,@BgColor,@Color,@DBConnID,@LinkURL,@UseOrganizes,@UseUsers,@Sort,@Note)";
			SqlParameter[] parameter = new SqlParameter[15]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ID
				},
				new SqlParameter("@Type", SqlDbType.Int, -1)
				{
					Value = model.Type
				},
				new SqlParameter("@Name", SqlDbType.NVarChar, 1000)
				{
					Value = model.Name
				},
				new SqlParameter("@Title", SqlDbType.NVarChar, 1000)
				{
					Value = model.Title
				},
				new SqlParameter("@DataSourceType", SqlDbType.Int, -1)
				{
					Value = model.DataSourceType
				},
				(model.DataSource == null) ? new SqlParameter("@DataSource", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@DataSource", SqlDbType.VarChar, -1)
				{
					Value = model.DataSource
				},
				(model.Ico == null) ? new SqlParameter("@Ico", SqlDbType.VarChar, 2000)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Ico", SqlDbType.VarChar, 2000)
				{
					Value = model.Ico
				},
				(model.BgColor == null) ? new SqlParameter("@BgColor", SqlDbType.VarChar, 50)
				{
					Value = DBNull.Value
				} : new SqlParameter("@BgColor", SqlDbType.VarChar, 50)
				{
					Value = model.BgColor
				},
				(model.Color == null) ? new SqlParameter("@Color", SqlDbType.VarChar, 50)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Color", SqlDbType.VarChar, 50)
				{
					Value = model.Color
				},
				(!model.DBConnID.HasValue) ? new SqlParameter("@DBConnID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@DBConnID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.DBConnID
				},
				(model.LinkURL == null) ? new SqlParameter("@LinkURL", SqlDbType.VarChar, 2000)
				{
					Value = DBNull.Value
				} : new SqlParameter("@LinkURL", SqlDbType.VarChar, 2000)
				{
					Value = model.LinkURL
				},
				(model.UseOrganizes == null) ? new SqlParameter("@UseOrganizes", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@UseOrganizes", SqlDbType.VarChar, -1)
				{
					Value = model.UseOrganizes
				},
				(model.UseUsers == null) ? new SqlParameter("@UseUsers", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@UseUsers", SqlDbType.VarChar, -1)
				{
					Value = model.UseUsers
				},
				(!model.Sort.HasValue) ? new SqlParameter("@Sort", SqlDbType.Int, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Sort", SqlDbType.Int, -1)
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

		public int Update(RoadFlow.Data.Model.HomeItems model)
		{
			string sql = "UPDATE HomeItems SET \r\n\t\t\t\tType=@Type,Name=@Name,Title=@Title,DataSourceType=@DataSourceType,DataSource=@DataSource,Ico=@Ico,BgColor=@BgColor,Color=@Color,DBConnID=@DBConnID,LinkURL=@LinkURL,UseOrganizes=@UseOrganizes,UseUsers=@UseUsers,Sort=@Sort,Note=@Note\r\n\t\t\t\tWHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[15]
			{
				new SqlParameter("@Type", SqlDbType.Int, -1)
				{
					Value = model.Type
				},
				new SqlParameter("@Name", SqlDbType.NVarChar, 1000)
				{
					Value = model.Name
				},
				new SqlParameter("@Title", SqlDbType.NVarChar, 1000)
				{
					Value = model.Title
				},
				new SqlParameter("@DataSourceType", SqlDbType.Int, -1)
				{
					Value = model.DataSourceType
				},
				(model.DataSource == null) ? new SqlParameter("@DataSource", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@DataSource", SqlDbType.VarChar, -1)
				{
					Value = model.DataSource
				},
				(model.Ico == null) ? new SqlParameter("@Ico", SqlDbType.VarChar, 2000)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Ico", SqlDbType.VarChar, 2000)
				{
					Value = model.Ico
				},
				(model.BgColor == null) ? new SqlParameter("@BgColor", SqlDbType.VarChar, 50)
				{
					Value = DBNull.Value
				} : new SqlParameter("@BgColor", SqlDbType.VarChar, 50)
				{
					Value = model.BgColor
				},
				(model.Color == null) ? new SqlParameter("@Color", SqlDbType.VarChar, 50)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Color", SqlDbType.VarChar, 50)
				{
					Value = model.Color
				},
				(!model.DBConnID.HasValue) ? new SqlParameter("@DBConnID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@DBConnID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.DBConnID
				},
				(model.LinkURL == null) ? new SqlParameter("@LinkURL", SqlDbType.VarChar, 2000)
				{
					Value = DBNull.Value
				} : new SqlParameter("@LinkURL", SqlDbType.VarChar, 2000)
				{
					Value = model.LinkURL
				},
				(model.UseOrganizes == null) ? new SqlParameter("@UseOrganizes", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@UseOrganizes", SqlDbType.VarChar, -1)
				{
					Value = model.UseOrganizes
				},
				(model.UseUsers == null) ? new SqlParameter("@UseUsers", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@UseUsers", SqlDbType.VarChar, -1)
				{
					Value = model.UseUsers
				},
				(!model.Sort.HasValue) ? new SqlParameter("@Sort", SqlDbType.Int, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Sort", SqlDbType.Int, -1)
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
			string sql = "DELETE FROM HomeItems WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.HomeItems> DataReaderToList(SqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.HomeItems> list = new List<RoadFlow.Data.Model.HomeItems>();
			RoadFlow.Data.Model.HomeItems homeItems = null;
			while (dataReader.Read())
			{
				homeItems = new RoadFlow.Data.Model.HomeItems();
				homeItems.ID = dataReader.GetGuid(0);
				homeItems.Type = dataReader.GetInt32(1);
				homeItems.Name = dataReader.GetString(2);
				homeItems.Title = dataReader.GetString(3);
				homeItems.DataSourceType = dataReader.GetInt32(4);
				if (!dataReader.IsDBNull(5))
				{
					homeItems.DataSource = dataReader.GetString(5);
				}
				if (!dataReader.IsDBNull(6))
				{
					homeItems.Ico = dataReader.GetString(6);
				}
				if (!dataReader.IsDBNull(7))
				{
					homeItems.BgColor = dataReader.GetString(7);
				}
				if (!dataReader.IsDBNull(8))
				{
					homeItems.Color = dataReader.GetString(8);
				}
				if (!dataReader.IsDBNull(9))
				{
					homeItems.DBConnID = dataReader.GetGuid(9);
				}
				if (!dataReader.IsDBNull(10))
				{
					homeItems.LinkURL = dataReader.GetString(10);
				}
				if (!dataReader.IsDBNull(11))
				{
					homeItems.UseOrganizes = dataReader.GetString(11);
				}
				if (!dataReader.IsDBNull(12))
				{
					homeItems.UseUsers = dataReader.GetString(12);
				}
				if (!dataReader.IsDBNull(13))
				{
					homeItems.Sort = dataReader.GetInt32(13);
				}
				if (!dataReader.IsDBNull(14))
				{
					homeItems.Note = dataReader.GetString(14);
				}
				list.Add(homeItems);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.HomeItems> GetAll()
		{
			string sql = "SELECT * FROM HomeItems";
			SqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.HomeItems> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM HomeItems";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.HomeItems Get(Guid id)
		{
			string sql = "SELECT * FROM HomeItems WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.HomeItems> list = DataReaderToList(dataReader);
			dataReader.Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public List<RoadFlow.Data.Model.HomeItems> GetList(out string pager, string query = "", string name = "", string title = "", string type = "")
		{
			List<SqlParameter> list = new List<SqlParameter>();
			StringBuilder stringBuilder = new StringBuilder("SELECT *,ROW_NUMBER() OVER(ORDER BY Type,Sort) AS PagerAutoRowNumber FROM HomeItems WHERE 1=1 ");
			if (!name.IsNullOrEmpty())
			{
				stringBuilder.Append(" AND CHARINDEX(@Name,Name)>0");
				list.Add(new SqlParameter("@Name", name));
			}
			if (!title.IsNullOrEmpty())
			{
				stringBuilder.Append(" AND CHARINDEX(@Title,Title)>0");
				list.Add(new SqlParameter("@Title", title));
			}
			if (!type.IsNullOrEmpty())
			{
				stringBuilder.Append(" AND Type=@Type");
				list.Add(new SqlParameter("@Type", type));
			}
			int pageSize = Tools.GetPageSize();
			int pageNumber = Tools.GetPageNumber();
			long count;
			string paerSql = dbHelper.GetPaerSql(stringBuilder.ToString(), pageSize, pageNumber, out count, list.ToArray());
			pager = Tools.GetPagerHtml(count, pageSize, pageNumber, query);
			SqlDataReader dataReader = dbHelper.GetDataReader(paerSql, list.ToArray());
			List<RoadFlow.Data.Model.HomeItems> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public List<RoadFlow.Data.Model.HomeItems> GetList(out long count, int size, int number, string name = "", string title = "", string type = "", string order = "")
		{
			List<SqlParameter> list = new List<SqlParameter>();
			StringBuilder stringBuilder = new StringBuilder("SELECT *,ROW_NUMBER() OVER(ORDER BY " + (order.IsNullOrEmpty() ? "Type,Sort" : order) + ") AS PagerAutoRowNumber FROM HomeItems WHERE 1=1 ");
			if (!name.IsNullOrEmpty())
			{
				stringBuilder.Append(" AND CHARINDEX(@Name,Name)>0");
				list.Add(new SqlParameter("@Name", name));
			}
			if (!title.IsNullOrEmpty())
			{
				stringBuilder.Append(" AND CHARINDEX(@Title,Title)>0");
				list.Add(new SqlParameter("@Title", title));
			}
			if (!type.IsNullOrEmpty())
			{
				stringBuilder.Append(" AND Type=@Type");
				list.Add(new SqlParameter("@Type", type));
			}
			string paerSql = dbHelper.GetPaerSql(stringBuilder.ToString(), size, number, out count, list.ToArray());
			SqlDataReader dataReader = dbHelper.GetDataReader(paerSql, list.ToArray());
			List<RoadFlow.Data.Model.HomeItems> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public int GetMaxSort(int type)
		{
			string sql = "SELECT MAX(Sort) FROM HomeItems WHERE Type=" + type;
			return dbHelper.GetFieldValue(sql).ToInt(0) + 5;
		}
	}
}
