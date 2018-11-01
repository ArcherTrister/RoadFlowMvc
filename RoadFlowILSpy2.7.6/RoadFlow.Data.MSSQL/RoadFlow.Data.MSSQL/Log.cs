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
	public class Log : ILog
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.Log model)
		{
			string sql = "INSERT INTO Log\r\n\t\t\t\t(ID,Title,Type,WriteTime,UserID,UserName,IPAddress,URL,Contents,Others,OldXml,NewXml) \r\n\t\t\t\tVALUES(@ID,@Title,@Type,@WriteTime,@UserID,@UserName,@IPAddress,@URL,@Contents,@Others,@OldXml,@NewXml)";
			SqlParameter[] parameter = new SqlParameter[12]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ID
				},
				new SqlParameter("@Title", SqlDbType.NVarChar, -1)
				{
					Value = model.Title
				},
				new SqlParameter("@Type", SqlDbType.NVarChar, 100)
				{
					Value = model.Type
				},
				new SqlParameter("@WriteTime", SqlDbType.DateTime, 8)
				{
					Value = model.WriteTime
				},
				(!model.UserID.HasValue) ? new SqlParameter("@UserID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@UserID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.UserID
				},
				(model.UserName == null) ? new SqlParameter("@UserName", SqlDbType.NVarChar, 100)
				{
					Value = DBNull.Value
				} : new SqlParameter("@UserName", SqlDbType.NVarChar, 100)
				{
					Value = model.UserName
				},
				(model.IPAddress == null) ? new SqlParameter("@IPAddress", SqlDbType.VarChar, 50)
				{
					Value = DBNull.Value
				} : new SqlParameter("@IPAddress", SqlDbType.VarChar, 50)
				{
					Value = model.IPAddress
				},
				(model.URL == null) ? new SqlParameter("@URL", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@URL", SqlDbType.VarChar, -1)
				{
					Value = model.URL
				},
				(model.Contents == null) ? new SqlParameter("@Contents", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Contents", SqlDbType.VarChar, -1)
				{
					Value = model.Contents
				},
				(model.Others == null) ? new SqlParameter("@Others", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Others", SqlDbType.VarChar, -1)
				{
					Value = model.Others
				},
				(model.OldXml == null) ? new SqlParameter("@OldXml", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@OldXml", SqlDbType.VarChar, -1)
				{
					Value = model.OldXml
				},
				(model.NewXml == null) ? new SqlParameter("@NewXml", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@NewXml", SqlDbType.VarChar, -1)
				{
					Value = model.NewXml
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.Log model)
		{
			string sql = "UPDATE Log SET \r\n\t\t\t\tTitle=@Title,Type=@Type,WriteTime=@WriteTime,UserID=@UserID,UserName=@UserName,IPAddress=@IPAddress,URL=@URL,Contents=@Contents,Others=@Others,OldXml=@OldXml,NewXml=@NewXml\r\n\t\t\t\tWHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[12]
			{
				new SqlParameter("@Title", SqlDbType.NVarChar, -1)
				{
					Value = model.Title
				},
				new SqlParameter("@Type", SqlDbType.NVarChar, 100)
				{
					Value = model.Type
				},
				new SqlParameter("@WriteTime", SqlDbType.DateTime, 8)
				{
					Value = model.WriteTime
				},
				(!model.UserID.HasValue) ? new SqlParameter("@UserID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@UserID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.UserID
				},
				(model.UserName == null) ? new SqlParameter("@UserName", SqlDbType.NVarChar, 100)
				{
					Value = DBNull.Value
				} : new SqlParameter("@UserName", SqlDbType.NVarChar, 100)
				{
					Value = model.UserName
				},
				(model.IPAddress == null) ? new SqlParameter("@IPAddress", SqlDbType.VarChar, 50)
				{
					Value = DBNull.Value
				} : new SqlParameter("@IPAddress", SqlDbType.VarChar, 50)
				{
					Value = model.IPAddress
				},
				(model.URL == null) ? new SqlParameter("@URL", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@URL", SqlDbType.VarChar, -1)
				{
					Value = model.URL
				},
				(model.Contents == null) ? new SqlParameter("@Contents", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Contents", SqlDbType.VarChar, -1)
				{
					Value = model.Contents
				},
				(model.Others == null) ? new SqlParameter("@Others", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Others", SqlDbType.VarChar, -1)
				{
					Value = model.Others
				},
				(model.OldXml == null) ? new SqlParameter("@OldXml", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@OldXml", SqlDbType.VarChar, -1)
				{
					Value = model.OldXml
				},
				(model.NewXml == null) ? new SqlParameter("@NewXml", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@NewXml", SqlDbType.VarChar, -1)
				{
					Value = model.NewXml
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
			string sql = "DELETE FROM Log WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.Log> DataReaderToList(SqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.Log> list = new List<RoadFlow.Data.Model.Log>();
			RoadFlow.Data.Model.Log log = null;
			while (dataReader.Read())
			{
				log = new RoadFlow.Data.Model.Log();
				log.ID = dataReader.GetGuid(0);
				log.Title = dataReader.GetString(1);
				log.Type = dataReader.GetString(2);
				log.WriteTime = dataReader.GetDateTime(3);
				if (!dataReader.IsDBNull(4))
				{
					log.UserID = dataReader.GetGuid(4);
				}
				if (!dataReader.IsDBNull(5))
				{
					log.UserName = dataReader.GetString(5);
				}
				if (!dataReader.IsDBNull(6))
				{
					log.IPAddress = dataReader.GetString(6);
				}
				if (!dataReader.IsDBNull(7))
				{
					log.URL = dataReader.GetString(7);
				}
				if (!dataReader.IsDBNull(8))
				{
					log.Contents = dataReader.GetString(8);
				}
				if (!dataReader.IsDBNull(9))
				{
					log.Others = dataReader.GetString(9);
				}
				if (!dataReader.IsDBNull(10))
				{
					log.OldXml = dataReader.GetString(10);
				}
				if (!dataReader.IsDBNull(11))
				{
					log.NewXml = dataReader.GetString(11);
				}
				list.Add(log);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.Log> GetAll()
		{
			string sql = "SELECT * FROM Log";
			SqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.Log> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM Log";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.Log Get(Guid id)
		{
			string sql = "SELECT * FROM Log WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.Log> list = DataReaderToList(dataReader);
			dataReader.Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public DataTable GetPagerData(out string pager, string query = "", int size = 15, int number = 1, string title = "", string type = "", string date1 = "", string date2 = "", string userID = "")
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
				stringBuilder.Append("AND Type=@Type ");
				list.Add(new SqlParameter("@Type", SqlDbType.NVarChar)
				{
					Value = type
				});
			}
			if (date1.IsDateTime())
			{
				stringBuilder.Append("AND WriteTime>=@Date1 ");
				list.Add(new SqlParameter("@Date1", SqlDbType.DateTime)
				{
					Value = date1.ToDateTime().ToString("yyyy-MM-dd 00:00:00")
				});
			}
			if (date2.IsDateTime())
			{
				stringBuilder.Append("AND WriteTime<=@Date2 ");
				list.Add(new SqlParameter("@Date2", SqlDbType.DateTime)
				{
					Value = date2.ToDateTime().AddDays(1.0).ToString("yyyy-MM-dd 00:00:00")
				});
			}
			if (userID.IsGuid())
			{
				stringBuilder.Append("AND UserID=@UserID ");
				list.Add(new SqlParameter("@UserID", SqlDbType.UniqueIdentifier)
				{
					Value = userID.ToGuid()
				});
			}
			long count;
			string paerSql = dbHelper.GetPaerSql("Log", "ID,Title,Type,WriteTime,UserName,IPAddress", stringBuilder.ToString(), "WriteTime DESC", size, number, out count, list.ToArray());
			pager = Tools.GetPagerHtml(count, size, number, query);
			return dbHelper.GetDataTable(paerSql, list.ToArray());
		}

		public DataTable GetPagerData(out long count, int size = 15, int number = 1, string title = "", string type = "", string date1 = "", string date2 = "", string userID = "", string order = "")
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
				stringBuilder.Append("AND Type=@Type ");
				list.Add(new SqlParameter("@Type", SqlDbType.NVarChar)
				{
					Value = type
				});
			}
			if (date1.IsDateTime())
			{
				stringBuilder.Append("AND WriteTime>=@Date1 ");
				list.Add(new SqlParameter("@Date1", SqlDbType.DateTime)
				{
					Value = date1.ToDateTime().ToString("yyyy-MM-dd 00:00:00")
				});
			}
			if (date2.IsDateTime())
			{
				stringBuilder.Append("AND WriteTime<=@Date2 ");
				list.Add(new SqlParameter("@Date2", SqlDbType.DateTime)
				{
					Value = date2.ToDateTime().AddDays(1.0).ToString("yyyy-MM-dd 00:00:00")
				});
			}
			if (userID.IsGuid())
			{
				stringBuilder.Append("AND UserID=@UserID ");
				list.Add(new SqlParameter("@UserID", SqlDbType.UniqueIdentifier)
				{
					Value = userID.ToGuid()
				});
			}
			string paerSql = dbHelper.GetPaerSql("Log", "ID,Title,Type,WriteTime,UserName,IPAddress", stringBuilder.ToString(), order.IsNullOrEmpty() ? "WriteTime DESC" : order, size, number, out count, list.ToArray());
			return dbHelper.GetDataTable(paerSql.ToString(), list.ToArray());
		}
	}
}
