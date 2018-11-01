using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RoadFlow.Data.MSSQL
{
	public class WeiXinMessage : IWeiXinMessage
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.WeiXinMessage model)
		{
			string sql = "INSERT INTO WeiXinMessage\r\n\t\t\t\t(ID,ToUserName,FromUserName,CreateTime,CreateTime1,MsgType,MsgId,AgentID,Contents,PicUrl,MediaId,Format,ThumbMediaId,Location_X,Location_Y,Scale,Label,Title,Description,AddTime) \r\n\t\t\t\tVALUES(@ID,@ToUserName,@FromUserName,@CreateTime,@CreateTime1,@MsgType,@MsgId,@AgentID,@Contents,@PicUrl,@MediaId,@Format,@ThumbMediaId,@Location_X,@Location_Y,@Scale,@Label,@Title,@Description,@AddTime)";
			SqlParameter[] parameter = new SqlParameter[20]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ID
				},
				new SqlParameter("@ToUserName", SqlDbType.VarChar, 200)
				{
					Value = model.ToUserName
				},
				new SqlParameter("@FromUserName", SqlDbType.VarChar, 200)
				{
					Value = model.FromUserName
				},
				new SqlParameter("@CreateTime", SqlDbType.Int, -1)
				{
					Value = model.CreateTime
				},
				new SqlParameter("@CreateTime1", SqlDbType.DateTime, 8)
				{
					Value = model.CreateTime1
				},
				new SqlParameter("@MsgType", SqlDbType.VarChar, 50)
				{
					Value = model.MsgType
				},
				new SqlParameter("@MsgId", SqlDbType.BigInt, -1)
				{
					Value = model.MsgId
				},
				new SqlParameter("@AgentID", SqlDbType.Int, -1)
				{
					Value = model.AgentID
				},
				(model.Contents == null) ? new SqlParameter("@Contents", SqlDbType.NVarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Contents", SqlDbType.NVarChar, -1)
				{
					Value = model.Contents
				},
				(model.PicUrl == null) ? new SqlParameter("@PicUrl", SqlDbType.VarChar, 500)
				{
					Value = DBNull.Value
				} : new SqlParameter("@PicUrl", SqlDbType.VarChar, 500)
				{
					Value = model.PicUrl
				},
				(model.MediaId == null) ? new SqlParameter("@MediaId", SqlDbType.VarChar, 500)
				{
					Value = DBNull.Value
				} : new SqlParameter("@MediaId", SqlDbType.VarChar, 500)
				{
					Value = model.MediaId
				},
				(model.Format == null) ? new SqlParameter("@Format", SqlDbType.VarChar, 50)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Format", SqlDbType.VarChar, 50)
				{
					Value = model.Format
				},
				(model.ThumbMediaId == null) ? new SqlParameter("@ThumbMediaId", SqlDbType.VarChar, 50)
				{
					Value = DBNull.Value
				} : new SqlParameter("@ThumbMediaId", SqlDbType.VarChar, 50)
				{
					Value = model.ThumbMediaId
				},
				(model.Location_X == null) ? new SqlParameter("@Location_X", SqlDbType.VarChar, 50)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Location_X", SqlDbType.VarChar, 50)
				{
					Value = model.Location_X
				},
				(model.Location_Y == null) ? new SqlParameter("@Location_Y", SqlDbType.VarChar, 50)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Location_Y", SqlDbType.VarChar, 50)
				{
					Value = model.Location_Y
				},
				(model.Scale == null) ? new SqlParameter("@Scale", SqlDbType.VarChar, 50)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Scale", SqlDbType.VarChar, 50)
				{
					Value = model.Scale
				},
				(model.Label == null) ? new SqlParameter("@Label", SqlDbType.NVarChar, 1000)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Label", SqlDbType.NVarChar, 1000)
				{
					Value = model.Label
				},
				(model.Title == null) ? new SqlParameter("@Title", SqlDbType.NVarChar, 1000)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Title", SqlDbType.NVarChar, 1000)
				{
					Value = model.Title
				},
				(model.Description == null) ? new SqlParameter("@Description", SqlDbType.NVarChar, 2000)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Description", SqlDbType.NVarChar, 2000)
				{
					Value = model.Description
				},
				new SqlParameter("@AddTime", SqlDbType.DateTime, 8)
				{
					Value = model.AddTime
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.WeiXinMessage model)
		{
			string sql = "UPDATE WeiXinMessage SET \r\n\t\t\t\tToUserName=@ToUserName,FromUserName=@FromUserName,CreateTime=@CreateTime,CreateTime1=@CreateTime1,MsgType=@MsgType,MsgId=@MsgId,AgentID=@AgentID,Contents=@Contents,PicUrl=@PicUrl,MediaId=@MediaId,Format=@Format,ThumbMediaId=@ThumbMediaId,Location_X=@Location_X,Location_Y=@Location_Y,Scale=@Scale,Label=@Label,Title=@Title,Description=@Description,AddTime=@AddTime\r\n\t\t\t\tWHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[20]
			{
				new SqlParameter("@ToUserName", SqlDbType.VarChar, 200)
				{
					Value = model.ToUserName
				},
				new SqlParameter("@FromUserName", SqlDbType.VarChar, 200)
				{
					Value = model.FromUserName
				},
				new SqlParameter("@CreateTime", SqlDbType.Int, -1)
				{
					Value = model.CreateTime
				},
				new SqlParameter("@CreateTime1", SqlDbType.DateTime, 8)
				{
					Value = model.CreateTime1
				},
				new SqlParameter("@MsgType", SqlDbType.VarChar, 50)
				{
					Value = model.MsgType
				},
				new SqlParameter("@MsgId", SqlDbType.BigInt, -1)
				{
					Value = model.MsgId
				},
				new SqlParameter("@AgentID", SqlDbType.Int, -1)
				{
					Value = model.AgentID
				},
				(model.Contents == null) ? new SqlParameter("@Contents", SqlDbType.NVarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Contents", SqlDbType.NVarChar, -1)
				{
					Value = model.Contents
				},
				(model.PicUrl == null) ? new SqlParameter("@PicUrl", SqlDbType.VarChar, 500)
				{
					Value = DBNull.Value
				} : new SqlParameter("@PicUrl", SqlDbType.VarChar, 500)
				{
					Value = model.PicUrl
				},
				(model.MediaId == null) ? new SqlParameter("@MediaId", SqlDbType.VarChar, 500)
				{
					Value = DBNull.Value
				} : new SqlParameter("@MediaId", SqlDbType.VarChar, 500)
				{
					Value = model.MediaId
				},
				(model.Format == null) ? new SqlParameter("@Format", SqlDbType.VarChar, 50)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Format", SqlDbType.VarChar, 50)
				{
					Value = model.Format
				},
				(model.ThumbMediaId == null) ? new SqlParameter("@ThumbMediaId", SqlDbType.VarChar, 50)
				{
					Value = DBNull.Value
				} : new SqlParameter("@ThumbMediaId", SqlDbType.VarChar, 50)
				{
					Value = model.ThumbMediaId
				},
				(model.Location_X == null) ? new SqlParameter("@Location_X", SqlDbType.VarChar, 50)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Location_X", SqlDbType.VarChar, 50)
				{
					Value = model.Location_X
				},
				(model.Location_Y == null) ? new SqlParameter("@Location_Y", SqlDbType.VarChar, 50)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Location_Y", SqlDbType.VarChar, 50)
				{
					Value = model.Location_Y
				},
				(model.Scale == null) ? new SqlParameter("@Scale", SqlDbType.VarChar, 50)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Scale", SqlDbType.VarChar, 50)
				{
					Value = model.Scale
				},
				(model.Label == null) ? new SqlParameter("@Label", SqlDbType.NVarChar, 1000)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Label", SqlDbType.NVarChar, 1000)
				{
					Value = model.Label
				},
				(model.Title == null) ? new SqlParameter("@Title", SqlDbType.NVarChar, 1000)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Title", SqlDbType.NVarChar, 1000)
				{
					Value = model.Title
				},
				(model.Description == null) ? new SqlParameter("@Description", SqlDbType.NVarChar, 2000)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Description", SqlDbType.NVarChar, 2000)
				{
					Value = model.Description
				},
				new SqlParameter("@AddTime", SqlDbType.DateTime, 8)
				{
					Value = model.AddTime
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
			string sql = "DELETE FROM WeiXinMessage WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.WeiXinMessage> DataReaderToList(SqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.WeiXinMessage> list = new List<RoadFlow.Data.Model.WeiXinMessage>();
			RoadFlow.Data.Model.WeiXinMessage weiXinMessage = null;
			while (dataReader.Read())
			{
				weiXinMessage = new RoadFlow.Data.Model.WeiXinMessage();
				weiXinMessage.ID = dataReader.GetGuid(0);
				weiXinMessage.ToUserName = dataReader.GetString(1);
				weiXinMessage.CreateTime = dataReader.GetInt32(3);
				weiXinMessage.CreateTime1 = dataReader.GetDateTime(4);
				weiXinMessage.MsgType = dataReader.GetString(5);
				weiXinMessage.MsgId = dataReader.GetInt64(6);
				weiXinMessage.AgentID = dataReader.GetInt32(7);
				if (!dataReader.IsDBNull(8))
				{
					weiXinMessage.Contents = dataReader.GetString(8);
				}
				if (!dataReader.IsDBNull(9))
				{
					weiXinMessage.PicUrl = dataReader.GetString(9);
				}
				if (!dataReader.IsDBNull(10))
				{
					weiXinMessage.MediaId = dataReader.GetString(10);
				}
				if (!dataReader.IsDBNull(11))
				{
					weiXinMessage.Format = dataReader.GetString(11);
				}
				if (!dataReader.IsDBNull(12))
				{
					weiXinMessage.ThumbMediaId = dataReader.GetString(12);
				}
				if (!dataReader.IsDBNull(13))
				{
					weiXinMessage.Location_X = dataReader.GetString(13);
				}
				if (!dataReader.IsDBNull(14))
				{
					weiXinMessage.Location_Y = dataReader.GetString(14);
				}
				if (!dataReader.IsDBNull(15))
				{
					weiXinMessage.Scale = dataReader.GetString(15);
				}
				if (!dataReader.IsDBNull(16))
				{
					weiXinMessage.Label = dataReader.GetString(16);
				}
				if (!dataReader.IsDBNull(17))
				{
					weiXinMessage.Title = dataReader.GetString(17);
				}
				if (!dataReader.IsDBNull(18))
				{
					weiXinMessage.Description = dataReader.GetString(18);
				}
				weiXinMessage.AddTime = dataReader.GetDateTime(19);
				list.Add(weiXinMessage);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.WeiXinMessage> GetAll()
		{
			string sql = "SELECT * FROM WeiXinMessage";
			SqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.WeiXinMessage> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM WeiXinMessage";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.WeiXinMessage Get(Guid id)
		{
			string sql = "SELECT * FROM WeiXinMessage WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.WeiXinMessage> list = DataReaderToList(dataReader);
			dataReader.Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}
	}
}
