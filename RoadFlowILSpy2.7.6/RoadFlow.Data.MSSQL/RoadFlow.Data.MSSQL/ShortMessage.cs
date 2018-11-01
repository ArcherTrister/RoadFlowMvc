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
	public class ShortMessage : IShortMessage
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.ShortMessage model)
		{
			string sql = "INSERT INTO ShortMessage\r\n\t\t\t\t(ID,Title,Contents,SendUserID,SendUserName,ReceiveUserID,ReceiveUserName,SendTime,LinkUrl,LinkID,Type,Files) \r\n\t\t\t\tVALUES(@ID,@Title,@Contents,@SendUserID,@SendUserName,@ReceiveUserID,@ReceiveUserName,@SendTime,@LinkUrl,@LinkID,@Type,@Files)";
			SqlParameter[] parameter = new SqlParameter[12]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ID
				},
				new SqlParameter("@Title", SqlDbType.NVarChar, 1000)
				{
					Value = model.Title
				},
				(model.Contents == null) ? new SqlParameter("@Contents", SqlDbType.NVarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Contents", SqlDbType.NVarChar, -1)
				{
					Value = model.Contents
				},
				new SqlParameter("@SendUserID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.SendUserID
				},
				new SqlParameter("@SendUserName", SqlDbType.NVarChar, 1000)
				{
					Value = model.SendUserName
				},
				new SqlParameter("@ReceiveUserID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ReceiveUserID
				},
				new SqlParameter("@ReceiveUserName", SqlDbType.NVarChar, 1000)
				{
					Value = model.ReceiveUserName
				},
				new SqlParameter("@SendTime", SqlDbType.DateTime, 8)
				{
					Value = model.SendTime
				},
				(model.LinkUrl == null) ? new SqlParameter("@LinkUrl", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@LinkUrl", SqlDbType.VarChar, -1)
				{
					Value = model.LinkUrl
				},
				(model.LinkID == null) ? new SqlParameter("@LinkID", SqlDbType.VarChar, 50)
				{
					Value = DBNull.Value
				} : new SqlParameter("@LinkID", SqlDbType.VarChar, 50)
				{
					Value = model.LinkID
				},
				new SqlParameter("@Type", SqlDbType.Int, -1)
				{
					Value = model.Type
				},
				(model.Files == null) ? new SqlParameter("@Files", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Files", SqlDbType.VarChar, -1)
				{
					Value = model.Files
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.ShortMessage model)
		{
			string sql = "UPDATE ShortMessage SET \r\n\t\t\t\tTitle=@Title,Contents=@Contents,SendUserID=@SendUserID,SendUserName=@SendUserName,ReceiveUserID=@ReceiveUserID,ReceiveUserName=@ReceiveUserName,SendTime=@SendTime,LinkUrl=@LinkUrl,LinkID=@LinkID,Type=@Type,Files=@Files\r\n\t\t\t\tWHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[12]
			{
				new SqlParameter("@Title", SqlDbType.NVarChar, 1000)
				{
					Value = model.Title
				},
				(model.Contents == null) ? new SqlParameter("@Contents", SqlDbType.NVarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Contents", SqlDbType.NVarChar, -1)
				{
					Value = model.Contents
				},
				new SqlParameter("@SendUserID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.SendUserID
				},
				new SqlParameter("@SendUserName", SqlDbType.NVarChar, 1000)
				{
					Value = model.SendUserName
				},
				new SqlParameter("@ReceiveUserID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ReceiveUserID
				},
				new SqlParameter("@ReceiveUserName", SqlDbType.NVarChar, 1000)
				{
					Value = model.ReceiveUserName
				},
				new SqlParameter("@SendTime", SqlDbType.DateTime, 8)
				{
					Value = model.SendTime
				},
				(model.LinkUrl == null) ? new SqlParameter("@LinkUrl", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@LinkUrl", SqlDbType.VarChar, -1)
				{
					Value = model.LinkUrl
				},
				(model.LinkID == null) ? new SqlParameter("@LinkID", SqlDbType.VarChar, 50)
				{
					Value = DBNull.Value
				} : new SqlParameter("@LinkID", SqlDbType.VarChar, 50)
				{
					Value = model.LinkID
				},
				new SqlParameter("@Type", SqlDbType.Int, -1)
				{
					Value = model.Type
				},
				(model.Files == null) ? new SqlParameter("@Files", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Files", SqlDbType.VarChar, -1)
				{
					Value = model.Files
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
			string sql = "DELETE FROM ShortMessage WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.ShortMessage> DataReaderToList(SqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.ShortMessage> list = new List<RoadFlow.Data.Model.ShortMessage>();
			RoadFlow.Data.Model.ShortMessage shortMessage = null;
			while (dataReader.Read())
			{
				shortMessage = new RoadFlow.Data.Model.ShortMessage();
				shortMessage.ID = dataReader.GetGuid(0);
				shortMessage.Title = dataReader.GetString(1);
				if (!dataReader.IsDBNull(2))
				{
					shortMessage.Contents = dataReader.GetString(2);
				}
				shortMessage.SendUserID = dataReader.GetGuid(3);
				shortMessage.SendUserName = dataReader.GetString(4);
				shortMessage.ReceiveUserID = dataReader.GetGuid(5);
				shortMessage.ReceiveUserName = dataReader.GetString(6);
				shortMessage.SendTime = dataReader.GetDateTime(7);
				if (!dataReader.IsDBNull(8))
				{
					shortMessage.LinkUrl = dataReader.GetString(8);
				}
				if (!dataReader.IsDBNull(9))
				{
					shortMessage.LinkID = dataReader.GetString(9);
				}
				shortMessage.Type = dataReader.GetInt32(10);
				if (!dataReader.IsDBNull(11))
				{
					shortMessage.Files = dataReader.GetString(11);
				}
				if (dataReader.FieldCount > 11)
				{
					shortMessage.Status = dataReader.GetInt32(12);
				}
				else
				{
					shortMessage.Status = 0;
				}
				list.Add(shortMessage);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.ShortMessage> GetAll()
		{
			string sql = "SELECT *,0 AS Status FROM ShortMessage";
			SqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.ShortMessage> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM ShortMessage";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.ShortMessage Get(Guid id)
		{
			string sql = "SELECT *,0 AS Status FROM ShortMessage WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.ShortMessage> list = DataReaderToList(dataReader);
			dataReader.Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public RoadFlow.Data.Model.ShortMessage GetRead(Guid id)
		{
			string sql = "SELECT *,0 AS Status FROM ShortMessage1 WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.ShortMessage> list = DataReaderToList(dataReader);
			dataReader.Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public List<RoadFlow.Data.Model.ShortMessage> GetAllNoRead()
		{
			string sql = "SELECT *,0 AS Status FROM ShortMessage";
			SqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.ShortMessage> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public List<RoadFlow.Data.Model.ShortMessage> GetAllNoReadByUserID(Guid userID)
		{
			string sql = "SELECT *,0 AS Status FROM ShortMessage WHERE ReceiveUserID=@ReceiveUserID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ReceiveUserID", SqlDbType.UniqueIdentifier)
				{
					Value = userID
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.ShortMessage> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public int UpdateStatus(Guid id)
		{
			string sql = "INSERT INTO ShortMessage1 SELECT * FROM ShortMessage WHERE ID=@ID;DELETE FROM ShortMessage WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public List<RoadFlow.Data.Model.ShortMessage> GetList(out string pager, int[] status, string query = "", string title = "", string contents = "", string senderID = "", string date1 = "", string date2 = "", string receiveID = "")
		{
			List<SqlParameter> list = new List<SqlParameter>();
			string value = string.Empty;
			if (status.Length == 1 && status[0] == 0)
			{
				value = "SELECT *,0 AS Status,ROW_NUMBER() OVER(ORDER BY SendTime DESC) AS PagerAutoRowNumber FROM ShortMessage WHERE 1=1";
			}
			else if (status.Length == 1 && status[0] == 1)
			{
				value = "SELECT *,1 AS Status,ROW_NUMBER() OVER(ORDER BY SendTime DESC) AS PagerAutoRowNumber FROM ShortMessage1 WHERE 1=1";
			}
			else if (status.Length == 2)
			{
				value = "SELECT *,ROW_NUMBER() OVER(ORDER BY SendTime DESC) AS PagerAutoRowNumber FROM(SELECT *,0 AS Status FROM ShortMessage WHERE 1=1 UNION ALL SELECT *,1 AS Status FROM ShortMessage1 WHERE 1=1) temp WHERE 1=1";
			}
			StringBuilder stringBuilder = new StringBuilder(value);
			if (receiveID.IsGuid())
			{
				stringBuilder.Append(" AND ReceiveUserID=@ReceiveUserID");
				list.Add(new SqlParameter("@ReceiveUserID", receiveID));
			}
			if (!title.IsNullOrEmpty())
			{
				stringBuilder.Append(" AND CHARINDEX(@Title,Title)>0");
				list.Add(new SqlParameter("@Title", title));
			}
			if (!contents.IsNullOrEmpty())
			{
				stringBuilder.Append(" AND CHARINDEX(@Contents,Contents)>0");
				list.Add(new SqlParameter("@Contents", contents));
			}
			if (!senderID.IsNullOrEmpty())
			{
				stringBuilder.AppendFormat(" AND SendUserID IN({0})", senderID);
			}
			if (date1.IsDateTime())
			{
				stringBuilder.Append(" AND SendTime>=@SendTime");
				list.Add(new SqlParameter("@SendTime", date1.ToDateTime()));
			}
			if (date2.IsDateTime())
			{
				stringBuilder.Append(" AND SendTime<=@SendTime1");
				list.Add(new SqlParameter("@SendTime1", date2.ToDateTime().AddDays(1.0).ToDateString()));
			}
			int pageSize = Tools.GetPageSize();
			int pageNumber = Tools.GetPageNumber();
			long count;
			string paerSql = dbHelper.GetPaerSql(stringBuilder.ToString(), pageSize, pageNumber, out count, list.ToArray());
			pager = Tools.GetPagerHtml(count, pageSize, pageNumber, query);
			SqlDataReader dataReader = dbHelper.GetDataReader(paerSql, list.ToArray());
			List<RoadFlow.Data.Model.ShortMessage> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public List<RoadFlow.Data.Model.ShortMessage> GetList(out long count, int[] status, int size, int number, string title = "", string contents = "", string senderID = "", string date1 = "", string date2 = "", string receiveID = "", string order = "")
		{
			List<SqlParameter> list = new List<SqlParameter>();
			string value = string.Empty;
			if (status.Length == 1 && status[0] == 0)
			{
				value = "SELECT *,0 AS Status,ROW_NUMBER() OVER(ORDER BY " + (order.IsNullOrEmpty() ? "SendTime DESC" : order) + ") AS PagerAutoRowNumber FROM ShortMessage WHERE 1=1";
			}
			else if (status.Length == 1 && status[0] == 1)
			{
				value = "SELECT *,1 AS Status,ROW_NUMBER() OVER(ORDER BY " + (order.IsNullOrEmpty() ? "SendTime DESC" : order) + ") AS PagerAutoRowNumber FROM ShortMessage1 WHERE 1=1";
			}
			else if (status.Length == 2)
			{
				value = "SELECT *,ROW_NUMBER() OVER(ORDER BY " + (order.IsNullOrEmpty() ? "SendTime DESC" : order) + ") AS PagerAutoRowNumber FROM(SELECT *,0 AS Status FROM ShortMessage WHERE 1=1 UNION ALL SELECT *,1 AS Status FROM ShortMessage1 WHERE 1=1) temp WHERE 1=1";
			}
			StringBuilder stringBuilder = new StringBuilder(value);
			if (receiveID.IsGuid())
			{
				stringBuilder.Append(" AND ReceiveUserID=@ReceiveUserID");
				list.Add(new SqlParameter("@ReceiveUserID", receiveID));
			}
			if (!title.IsNullOrEmpty())
			{
				stringBuilder.Append(" AND CHARINDEX(@Title,Title)>0");
				list.Add(new SqlParameter("@Title", title));
			}
			if (!contents.IsNullOrEmpty())
			{
				stringBuilder.Append(" AND CHARINDEX(@Contents,Contents)>0");
				list.Add(new SqlParameter("@Contents", contents));
			}
			if (!senderID.IsNullOrEmpty())
			{
				stringBuilder.AppendFormat(" AND SendUserID IN({0})", senderID);
			}
			if (date1.IsDateTime())
			{
				stringBuilder.Append(" AND SendTime>=@SendTime");
				list.Add(new SqlParameter("@SendTime", date1.ToDateTime()));
			}
			if (date2.IsDateTime())
			{
				stringBuilder.Append(" AND SendTime<=@SendTime1");
				list.Add(new SqlParameter("@SendTime1", date2.ToDateTime().AddDays(1.0).ToDateString()));
			}
			string paerSql = dbHelper.GetPaerSql(stringBuilder.ToString(), size, number, out count, list.ToArray());
			SqlDataReader dataReader = dbHelper.GetDataReader(paerSql, list.ToArray());
			List<RoadFlow.Data.Model.ShortMessage> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public int Delete(string linkID, int Type)
		{
			string sql = "DELETE FROM ShortMessage WHERE LinkID=@LinkID AND Type=@Type";
			SqlParameter[] parameter = new SqlParameter[2]
			{
				new SqlParameter("@LinkID", SqlDbType.VarChar)
				{
					Value = linkID
				},
				new SqlParameter("@Type", SqlDbType.Int)
				{
					Value = Type
				}
			};
			return dbHelper.Execute(sql, parameter);
		}
	}
}
