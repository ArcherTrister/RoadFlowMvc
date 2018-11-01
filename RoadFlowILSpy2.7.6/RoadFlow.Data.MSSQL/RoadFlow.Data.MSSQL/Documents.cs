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
	public class Documents : IDocuments
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.Documents model)
		{
			string sql = "INSERT INTO Documents\r\n\t\t\t\t(ID,DirectoryID,DirectoryName,Title,Source,Contents,Files,WriteTime,WriteUserID,WriteUserName,EditTime,EditUserID,EditUserName,ReadUsers,ReadCount) \r\n\t\t\t\tVALUES(@ID,@DirectoryID,@DirectoryName,@Title,@Source,@Contents,@Files,@WriteTime,@WriteUserID,@WriteUserName,@EditTime,@EditUserID,@EditUserName,@ReadUsers,@ReadCount)";
			SqlParameter[] parameter = new SqlParameter[15]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ID
				},
				new SqlParameter("@DirectoryID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.DirectoryID
				},
				new SqlParameter("@DirectoryName", SqlDbType.NVarChar, 400)
				{
					Value = model.DirectoryName
				},
				new SqlParameter("@Title", SqlDbType.NVarChar, 600)
				{
					Value = model.Title
				},
				new SqlParameter("@Source", SqlDbType.NVarChar, 100)
				{
					Value = model.Source
				},
				new SqlParameter("@Contents", SqlDbType.VarChar, -1)
				{
					Value = model.Contents
				},
				(model.Files == null) ? new SqlParameter("@Files", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Files", SqlDbType.VarChar, -1)
				{
					Value = model.Files
				},
				new SqlParameter("@WriteTime", SqlDbType.DateTime, 8)
				{
					Value = model.WriteTime
				},
				new SqlParameter("@WriteUserID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.WriteUserID
				},
				new SqlParameter("@WriteUserName", SqlDbType.NVarChar, 100)
				{
					Value = model.WriteUserName
				},
				(!model.EditTime.HasValue) ? new SqlParameter("@EditTime", SqlDbType.DateTime, 8)
				{
					Value = DBNull.Value
				} : new SqlParameter("@EditTime", SqlDbType.DateTime, 8)
				{
					Value = model.EditTime
				},
				(!model.EditUserID.HasValue) ? new SqlParameter("@EditUserID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@EditUserID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.EditUserID
				},
				(model.EditUserName == null) ? new SqlParameter("@EditUserName", SqlDbType.NVarChar, 100)
				{
					Value = DBNull.Value
				} : new SqlParameter("@EditUserName", SqlDbType.NVarChar, 100)
				{
					Value = model.EditUserName
				},
				(model.ReadUsers == null) ? new SqlParameter("@ReadUsers", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@ReadUsers", SqlDbType.VarChar, -1)
				{
					Value = model.ReadUsers
				},
				new SqlParameter("@ReadCount", SqlDbType.Int, -1)
				{
					Value = model.ReadCount
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.Documents model)
		{
			string sql = "UPDATE Documents SET \r\n\t\t\t\tDirectoryID=@DirectoryID,DirectoryName=@DirectoryName,Title=@Title,Source=@Source,Contents=@Contents,Files=@Files,WriteTime=@WriteTime,WriteUserID=@WriteUserID,WriteUserName=@WriteUserName,EditTime=@EditTime,EditUserID=@EditUserID,EditUserName=@EditUserName,ReadUsers=@ReadUsers,ReadCount=@ReadCount\r\n\t\t\t\tWHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[15]
			{
				new SqlParameter("@DirectoryID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.DirectoryID
				},
				new SqlParameter("@DirectoryName", SqlDbType.NVarChar, 400)
				{
					Value = model.DirectoryName
				},
				new SqlParameter("@Title", SqlDbType.NVarChar, 600)
				{
					Value = model.Title
				},
				new SqlParameter("@Source", SqlDbType.NVarChar, 100)
				{
					Value = model.Source
				},
				new SqlParameter("@Contents", SqlDbType.VarChar, -1)
				{
					Value = model.Contents
				},
				(model.Files == null) ? new SqlParameter("@Files", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Files", SqlDbType.VarChar, -1)
				{
					Value = model.Files
				},
				new SqlParameter("@WriteTime", SqlDbType.DateTime, 8)
				{
					Value = model.WriteTime
				},
				new SqlParameter("@WriteUserID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.WriteUserID
				},
				new SqlParameter("@WriteUserName", SqlDbType.NVarChar, 100)
				{
					Value = model.WriteUserName
				},
				(!model.EditTime.HasValue) ? new SqlParameter("@EditTime", SqlDbType.DateTime, 8)
				{
					Value = DBNull.Value
				} : new SqlParameter("@EditTime", SqlDbType.DateTime, 8)
				{
					Value = model.EditTime
				},
				(!model.EditUserID.HasValue) ? new SqlParameter("@EditUserID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@EditUserID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.EditUserID
				},
				(model.EditUserName == null) ? new SqlParameter("@EditUserName", SqlDbType.NVarChar, 100)
				{
					Value = DBNull.Value
				} : new SqlParameter("@EditUserName", SqlDbType.NVarChar, 100)
				{
					Value = model.EditUserName
				},
				(model.ReadUsers == null) ? new SqlParameter("@ReadUsers", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@ReadUsers", SqlDbType.VarChar, -1)
				{
					Value = model.ReadUsers
				},
				new SqlParameter("@ReadCount", SqlDbType.Int, -1)
				{
					Value = model.ReadCount
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
			string sql = "DELETE FROM Documents WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.Documents> DataReaderToList(SqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.Documents> list = new List<RoadFlow.Data.Model.Documents>();
			RoadFlow.Data.Model.Documents documents = null;
			while (dataReader.Read())
			{
				documents = new RoadFlow.Data.Model.Documents();
				documents.ID = dataReader.GetGuid(0);
				documents.DirectoryID = dataReader.GetGuid(1);
				documents.DirectoryName = dataReader.GetString(2);
				documents.Title = dataReader.GetString(3);
				documents.Source = dataReader.GetString(4);
				documents.Contents = dataReader.GetString(5);
				if (!dataReader.IsDBNull(6))
				{
					documents.Files = dataReader.GetString(6);
				}
				documents.WriteTime = dataReader.GetDateTime(7);
				documents.WriteUserID = dataReader.GetGuid(8);
				documents.WriteUserName = dataReader.GetString(9);
				if (!dataReader.IsDBNull(10))
				{
					documents.EditTime = dataReader.GetDateTime(10);
				}
				if (!dataReader.IsDBNull(11))
				{
					documents.EditUserID = dataReader.GetGuid(11);
				}
				if (!dataReader.IsDBNull(12))
				{
					documents.EditUserName = dataReader.GetString(12);
				}
				if (!dataReader.IsDBNull(13))
				{
					documents.ReadUsers = dataReader.GetString(13);
				}
				documents.ReadCount = dataReader.GetInt32(14);
				list.Add(documents);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.Documents> GetAll()
		{
			string sql = "SELECT * FROM Documents";
			SqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.Documents> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM Documents";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.Documents Get(Guid id)
		{
			string sql = "SELECT * FROM Documents WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.Documents> list = DataReaderToList(dataReader);
			dataReader.Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public void UpdateReadCount(Guid id)
		{
			string sql = "UPDATE Documents SET ReadCount=ReadCount+1 WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			dbHelper.Execute(sql, parameter);
		}

		public DataTable GetList(out string pager, string dirID, string userID, string query = "", string title = "", string date1 = "", string date2 = "", bool isNoRead = false)
		{
			List<SqlParameter> list = new List<SqlParameter>();
			StringBuilder stringBuilder = new StringBuilder("SELECT ID,DirectoryID,DirectoryName,Title,WriteTime,WriteUserName,IsRead,ReadCount,ROW_NUMBER() OVER(ORDER BY WriteTime DESC) AS PagerAutoRowNumber FROM Documents a LEFT JOIN DocumentsReadUsers b ON a.ID=b.DocumentID WHERE b.UserID=@UserID");
			list.Add(new SqlParameter("@UserID", SqlDbType.UniqueIdentifier)
			{
				Value = userID.ToGuid()
			});
			if (isNoRead)
			{
				stringBuilder.Append(" AND IsRead=0");
			}
			if (!dirID.IsNullOrEmpty())
			{
				stringBuilder.Append(" AND DirectoryID IN(" + Tools.GetSqlInString(dirID) + ")");
			}
			else
			{
				stringBuilder.Append(isNoRead ? "" : " AND 1=0");
			}
			if (!title.IsNullOrEmpty())
			{
				stringBuilder.Append(" AND CHARINDEX(@Title,Title)>0");
				list.Add(new SqlParameter("@Title", SqlDbType.NVarChar)
				{
					Value = title
				});
			}
			if (date1.IsDateTime())
			{
				stringBuilder.Append(" AND WriteTime>=@WriteTime");
				list.Add(new SqlParameter("@WriteTime", SqlDbType.DateTime)
				{
					Value = date1.ToDateTime().Date
				});
			}
			if (date2.IsDateTime())
			{
				stringBuilder.Append(" AND WriteTime<=@WriteTime1");
				list.Add(new SqlParameter("@WriteTime1", SqlDbType.DateTime)
				{
					Value = date2.ToDateTime().AddDays(1.0).Date
				});
			}
			int pageSize = Tools.GetPageSize();
			int pageNumber = Tools.GetPageNumber();
			long count;
			string paerSql = dbHelper.GetPaerSql(stringBuilder.ToString(), pageSize, pageNumber, out count, list.ToArray());
			pager = Tools.GetPagerHtml(count, pageSize, pageNumber, query);
			return dbHelper.GetDataTable(paerSql, list.ToArray());
		}

		public DataTable GetList(out long count, int size, int number, string dirID, string userID, string title = "", string date1 = "", string date2 = "", bool isNoRead = false, string order = "")
		{
			List<SqlParameter> list = new List<SqlParameter>();
			StringBuilder stringBuilder = new StringBuilder("SELECT ID,DirectoryID,DirectoryName,Title,WriteTime,WriteUserName,IsRead,ReadCount,ROW_NUMBER() OVER(ORDER BY " + (order.IsNullOrEmpty() ? "WriteTime DESC" : order) + ") AS PagerAutoRowNumber FROM Documents a LEFT JOIN DocumentsReadUsers b ON a.ID=b.DocumentID WHERE b.UserID=@UserID");
			list.Add(new SqlParameter("@UserID", SqlDbType.UniqueIdentifier)
			{
				Value = userID.ToGuid()
			});
			if (isNoRead)
			{
				stringBuilder.Append(" AND IsRead=0");
			}
			if (!dirID.IsNullOrEmpty())
			{
				stringBuilder.Append(" AND DirectoryID IN(" + Tools.GetSqlInString(dirID) + ")");
			}
			else
			{
				stringBuilder.Append(isNoRead ? "" : " AND 1=0");
			}
			if (!title.IsNullOrEmpty())
			{
				stringBuilder.Append(" AND CHARINDEX(@Title,Title)>0");
				list.Add(new SqlParameter("@Title", SqlDbType.NVarChar)
				{
					Value = title
				});
			}
			if (date1.IsDateTime())
			{
				stringBuilder.Append(" AND WriteTime>=@WriteTime");
				list.Add(new SqlParameter("@WriteTime", SqlDbType.DateTime)
				{
					Value = date1.ToDateTime().Date
				});
			}
			if (date2.IsDateTime())
			{
				stringBuilder.Append(" AND WriteTime<=@WriteTime1");
				list.Add(new SqlParameter("@WriteTime1", SqlDbType.DateTime)
				{
					Value = date2.ToDateTime().AddDays(1.0).Date
				});
			}
			string paerSql = dbHelper.GetPaerSql(stringBuilder.ToString(), size, number, out count, list.ToArray());
			return dbHelper.GetDataTable(paerSql, list.ToArray());
		}

		public int DeleteByDirectoryID(Guid directoryID)
		{
			string sql = "DELETE FROM Documents WHERE DirectoryID=@DirectoryID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@DirectoryID", SqlDbType.UniqueIdentifier)
				{
					Value = directoryID
				}
			};
			return dbHelper.Execute(sql, parameter);
		}
	}
}
