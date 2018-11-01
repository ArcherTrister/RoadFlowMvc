using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RoadFlow.Data.MSSQL
{
	public class Dictionary : IDictionary
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.Dictionary model)
		{
			string sql = "INSERT INTO Dictionary\r\n\t\t\t\t(ID,ParentID,Title,Code,Value,Note,Other,Sort) \r\n\t\t\t\tVALUES(@ID,@ParentID,@Title,@Code,@Value,@Note,@Other,@Sort)";
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
				new SqlParameter("@Title", SqlDbType.NVarChar, -1)
				{
					Value = model.Title
				},
				(model.Code == null) ? new SqlParameter("@Code", SqlDbType.VarChar, 500)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Code", SqlDbType.VarChar, 500)
				{
					Value = model.Code
				},
				(model.Value == null) ? new SqlParameter("@Value", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Value", SqlDbType.VarChar, -1)
				{
					Value = model.Value
				},
				(model.Note == null) ? new SqlParameter("@Note", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Note", SqlDbType.VarChar, -1)
				{
					Value = model.Note
				},
				(model.Other == null) ? new SqlParameter("@Other", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Other", SqlDbType.VarChar, -1)
				{
					Value = model.Other
				},
				new SqlParameter("@Sort", SqlDbType.Int, -1)
				{
					Value = model.Sort
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.Dictionary model)
		{
			string sql = "UPDATE Dictionary SET \r\n\t\t\t\tParentID=@ParentID,Title=@Title,Code=@Code,Value=@Value,Note=@Note,Other=@Other,Sort=@Sort\r\n\t\t\t\tWHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[8]
			{
				new SqlParameter("@ParentID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ParentID
				},
				new SqlParameter("@Title", SqlDbType.NVarChar, -1)
				{
					Value = model.Title
				},
				(model.Code == null) ? new SqlParameter("@Code", SqlDbType.VarChar, 500)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Code", SqlDbType.VarChar, 500)
				{
					Value = model.Code
				},
				(model.Value == null) ? new SqlParameter("@Value", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Value", SqlDbType.VarChar, -1)
				{
					Value = model.Value
				},
				(model.Note == null) ? new SqlParameter("@Note", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Note", SqlDbType.VarChar, -1)
				{
					Value = model.Note
				},
				(model.Other == null) ? new SqlParameter("@Other", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Other", SqlDbType.VarChar, -1)
				{
					Value = model.Other
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
			string sql = "DELETE FROM Dictionary WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.Dictionary> DataReaderToList(SqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.Dictionary> list = new List<RoadFlow.Data.Model.Dictionary>();
			RoadFlow.Data.Model.Dictionary dictionary = null;
			while (dataReader.Read())
			{
				dictionary = new RoadFlow.Data.Model.Dictionary();
				dictionary.ID = dataReader.GetGuid(0);
				dictionary.ParentID = dataReader.GetGuid(1);
				dictionary.Title = dataReader.GetString(2);
				if (!dataReader.IsDBNull(3))
				{
					dictionary.Code = dataReader.GetString(3);
				}
				if (!dataReader.IsDBNull(4))
				{
					dictionary.Value = dataReader.GetString(4);
				}
				if (!dataReader.IsDBNull(5))
				{
					dictionary.Note = dataReader.GetString(5);
				}
				if (!dataReader.IsDBNull(6))
				{
					dictionary.Other = dataReader.GetString(6);
				}
				dictionary.Sort = dataReader.GetInt32(7);
				list.Add(dictionary);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.Dictionary> GetAll()
		{
			string sql = "SELECT * FROM Dictionary";
			SqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.Dictionary> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM Dictionary";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.Dictionary Get(Guid id)
		{
			string sql = "SELECT * FROM Dictionary WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.Dictionary> list = DataReaderToList(dataReader);
			dataReader.Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public RoadFlow.Data.Model.Dictionary GetRoot()
		{
			string sql = "SELECT * FROM Dictionary WHERE ParentID=@ParentID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ParentID", SqlDbType.UniqueIdentifier)
				{
					Value = Guid.Empty
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.Dictionary> list = DataReaderToList(dataReader);
			dataReader.Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public List<RoadFlow.Data.Model.Dictionary> GetChilds(Guid id)
		{
			string sql = "SELECT * FROM Dictionary WHERE ParentID=@ParentID ORDER BY Sort";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ParentID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.Dictionary> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public List<RoadFlow.Data.Model.Dictionary> GetChilds(string code)
		{
			string sql = "SELECT * FROM Dictionary WHERE ParentID=(SELECT ID FROM Dictionary WHERE Code=@Code) ORDER BY Sort";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@Code", SqlDbType.VarChar)
				{
					Value = code
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.Dictionary> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public RoadFlow.Data.Model.Dictionary GetParent(Guid id)
		{
			string sql = "SELECT * FROM Dictionary WHERE ID=(SELECT ParentID FROM Dictionary WHERE ID=@ID)";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.Dictionary> list = DataReaderToList(dataReader);
			dataReader.Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public bool HasChilds(Guid id)
		{
			string sql = "SELECT ID FROM Dictionary WHERE ParentID=@ParentID";
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

		public int GetMaxSort(Guid id)
		{
			string sql = "SELECT MAX(Sort)+1 FROM Dictionary WHERE ParentID=@ParentID";
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

		public int UpdateSort(Guid id, int sort)
		{
			string sql = "UPDATE Dictionary SET Sort=@Sort WHERE ID=@ID";
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

		public RoadFlow.Data.Model.Dictionary GetByCode(string code)
		{
			string sql = "SELECT * FROM Dictionary WHERE Code=@Code";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@Code", SqlDbType.VarChar)
				{
					Value = code
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.Dictionary> list = DataReaderToList(dataReader);
			dataReader.Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}
	}
}
