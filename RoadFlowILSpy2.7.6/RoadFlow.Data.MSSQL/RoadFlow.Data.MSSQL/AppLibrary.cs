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
	public class AppLibrary : IAppLibrary
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.AppLibrary model)
		{
			string sql = "INSERT INTO AppLibrary\r\n\t\t\t\t(ID,Title,Address,Type,OpenMode,Width,Height,Params,Manager,Note,Code,Ico,Color) \r\n\t\t\t\tVALUES(@ID,@Title,@Address,@Type,@OpenMode,@Width,@Height,@Params,@Manager,@Note,@Code,@Ico,@Color)";
			SqlParameter[] parameter = new SqlParameter[13]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ID
				},
				new SqlParameter("@Title", SqlDbType.NVarChar, 510)
				{
					Value = model.Title
				},
				new SqlParameter("@Address", SqlDbType.VarChar, 200)
				{
					Value = model.Address
				},
				new SqlParameter("@Type", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.Type
				},
				new SqlParameter("@OpenMode", SqlDbType.Int, -1)
				{
					Value = model.OpenMode
				},
				(!model.Width.HasValue) ? new SqlParameter("@Width", SqlDbType.Int, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Width", SqlDbType.Int, -1)
				{
					Value = model.Width
				},
				(!model.Height.HasValue) ? new SqlParameter("@Height", SqlDbType.Int, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Height", SqlDbType.Int, -1)
				{
					Value = model.Height
				},
				(model.Params == null) ? new SqlParameter("@Params", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Params", SqlDbType.VarChar, -1)
				{
					Value = model.Params
				},
				(model.Manager == null) ? new SqlParameter("@Manager", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Manager", SqlDbType.VarChar, -1)
				{
					Value = model.Manager
				},
				(model.Note == null) ? new SqlParameter("@Note", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Note", SqlDbType.VarChar, -1)
				{
					Value = model.Note
				},
				(model.Code == null) ? new SqlParameter("@Code", SqlDbType.VarChar, 50)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Code", SqlDbType.VarChar, 50)
				{
					Value = model.Code
				},
				(model.Ico == null) ? new SqlParameter("@Ico", SqlDbType.VarChar, 2000)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Ico", SqlDbType.VarChar, 2000)
				{
					Value = model.Ico
				},
				(model.Color == null) ? new SqlParameter("@Color", SqlDbType.VarChar, 50)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Color", SqlDbType.VarChar, 50)
				{
					Value = model.Color
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.AppLibrary model)
		{
			string sql = "UPDATE AppLibrary SET \r\n\t\t\t\tTitle=@Title,Address=@Address,Type=@Type,OpenMode=@OpenMode,Width=@Width,Height=@Height,Params=@Params,Manager=@Manager,Note=@Note,Code=@Code,Ico=@Ico,Color=@Color\r\n\t\t\t\tWHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[13]
			{
				new SqlParameter("@Title", SqlDbType.NVarChar, 510)
				{
					Value = model.Title
				},
				new SqlParameter("@Address", SqlDbType.VarChar, 200)
				{
					Value = model.Address
				},
				new SqlParameter("@Type", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.Type
				},
				new SqlParameter("@OpenMode", SqlDbType.Int, -1)
				{
					Value = model.OpenMode
				},
				(!model.Width.HasValue) ? new SqlParameter("@Width", SqlDbType.Int, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Width", SqlDbType.Int, -1)
				{
					Value = model.Width
				},
				(!model.Height.HasValue) ? new SqlParameter("@Height", SqlDbType.Int, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Height", SqlDbType.Int, -1)
				{
					Value = model.Height
				},
				(model.Params == null) ? new SqlParameter("@Params", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Params", SqlDbType.VarChar, -1)
				{
					Value = model.Params
				},
				(model.Manager == null) ? new SqlParameter("@Manager", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Manager", SqlDbType.VarChar, -1)
				{
					Value = model.Manager
				},
				(model.Note == null) ? new SqlParameter("@Note", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Note", SqlDbType.VarChar, -1)
				{
					Value = model.Note
				},
				(model.Code == null) ? new SqlParameter("@Code", SqlDbType.VarChar, 50)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Code", SqlDbType.VarChar, 50)
				{
					Value = model.Code
				},
				(model.Ico == null) ? new SqlParameter("@Ico", SqlDbType.VarChar, 2000)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Ico", SqlDbType.VarChar, 2000)
				{
					Value = model.Ico
				},
				(model.Color == null) ? new SqlParameter("@Color", SqlDbType.VarChar, 50)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Color", SqlDbType.VarChar, 50)
				{
					Value = model.Color
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
			string sql = "DELETE FROM AppLibrary WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.AppLibrary> DataReaderToList(SqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.AppLibrary> list = new List<RoadFlow.Data.Model.AppLibrary>();
			RoadFlow.Data.Model.AppLibrary appLibrary = null;
			while (dataReader.Read())
			{
				appLibrary = new RoadFlow.Data.Model.AppLibrary();
				appLibrary.ID = dataReader.GetGuid(0);
				appLibrary.Title = dataReader.GetString(1);
				appLibrary.Address = dataReader.GetString(2);
				appLibrary.Type = dataReader.GetGuid(3);
				appLibrary.OpenMode = dataReader.GetInt32(4);
				if (!dataReader.IsDBNull(5))
				{
					appLibrary.Width = dataReader.GetInt32(5);
				}
				if (!dataReader.IsDBNull(6))
				{
					appLibrary.Height = dataReader.GetInt32(6);
				}
				if (!dataReader.IsDBNull(7))
				{
					appLibrary.Params = dataReader.GetString(7);
				}
				if (!dataReader.IsDBNull(8))
				{
					appLibrary.Manager = dataReader.GetString(8);
				}
				if (!dataReader.IsDBNull(9))
				{
					appLibrary.Note = dataReader.GetString(9);
				}
				if (!dataReader.IsDBNull(10))
				{
					appLibrary.Code = dataReader.GetString(10);
				}
				if (!dataReader.IsDBNull(11))
				{
					appLibrary.Ico = dataReader.GetString(11);
				}
				if (!dataReader.IsDBNull(12))
				{
					appLibrary.Color = dataReader.GetString(12);
				}
				list.Add(appLibrary);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.AppLibrary> GetAll()
		{
			string sql = "SELECT * FROM AppLibrary";
			SqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.AppLibrary> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM AppLibrary";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.AppLibrary Get(Guid id)
		{
			string sql = "SELECT * FROM AppLibrary WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.AppLibrary> list = DataReaderToList(dataReader);
			dataReader.Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public List<RoadFlow.Data.Model.AppLibrary> GetPagerData(out string pager, string query = "", string order = "Type,Title", int size = 15, int number = 1, string title = "", string type = "", string address = "")
		{
			StringBuilder stringBuilder = new StringBuilder();
			List<SqlParameter> list = new List<SqlParameter>();
			if (!title.IsNullOrEmpty())
			{
				stringBuilder.Append("AND CHARINDEX(@Title,Title)>0 ");
				list.Add(new SqlParameter("@Title", SqlDbType.NVarChar)
				{
					Value = title
				});
			}
			if (!type.IsNullOrEmpty())
			{
				stringBuilder.AppendFormat("AND Type IN({0}) ", Tools.GetSqlInString(type));
			}
			if (!address.IsNullOrEmpty())
			{
				stringBuilder.Append("AND CHARINDEX(@Address,Address)>0 ");
				list.Add(new SqlParameter("@Address", SqlDbType.VarChar)
				{
					Value = address
				});
			}
			long count;
			string paerSql = dbHelper.GetPaerSql("AppLibrary", "*", stringBuilder.ToString(), order, size, number, out count, list.ToArray());
			pager = Tools.GetPagerHtml(count, size, number, query);
			SqlDataReader dataReader = dbHelper.GetDataReader(paerSql, list.ToArray());
			List<RoadFlow.Data.Model.AppLibrary> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public List<RoadFlow.Data.Model.AppLibrary> GetPagerData(out long count, int size = 15, int number = 1, string title = "", string type = "", string address = "", string order = "")
		{
			StringBuilder stringBuilder = new StringBuilder();
			List<SqlParameter> list = new List<SqlParameter>();
			if (!title.IsNullOrEmpty())
			{
				stringBuilder.Append("AND CHARINDEX(@Title,Title)>0 ");
				list.Add(new SqlParameter("@Title", SqlDbType.NVarChar)
				{
					Value = title
				});
			}
			if (!type.IsNullOrEmpty())
			{
				stringBuilder.AppendFormat("AND Type IN({0}) ", Tools.GetSqlInString(type));
			}
			if (!address.IsNullOrEmpty())
			{
				stringBuilder.Append("AND CHARINDEX(@Address,Address)>0 ");
				list.Add(new SqlParameter("@Address", SqlDbType.VarChar)
				{
					Value = address
				});
			}
			string paerSql = dbHelper.GetPaerSql("AppLibrary", "*", stringBuilder.ToString(), order.IsNullOrEmpty() ? "Type,Title" : order, size, number, out count, list.ToArray());
			SqlDataReader dataReader = dbHelper.GetDataReader(paerSql, list.ToArray());
			List<RoadFlow.Data.Model.AppLibrary> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public List<RoadFlow.Data.Model.AppLibrary> GetAllByType(string types)
		{
			string sql = "SELECT * FROM AppLibrary WHERE Type IN(" + Tools.GetSqlInString(types) + ")";
			SqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.AppLibrary> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public int Delete(string[] idArray)
		{
			string sql = "DELETE FROM AppLibrary WHERE ID in(" + Tools.GetSqlInString(idArray) + ")";
			return dbHelper.Execute(sql);
		}

		public RoadFlow.Data.Model.AppLibrary GetByCode(string code)
		{
			string sql = "SELECT * FROM AppLibrary WHERE Code=@Code";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@Code", SqlDbType.VarChar, 50)
				{
					Value = code
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.AppLibrary> list = DataReaderToList(dataReader);
			dataReader.Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}
	}
}
