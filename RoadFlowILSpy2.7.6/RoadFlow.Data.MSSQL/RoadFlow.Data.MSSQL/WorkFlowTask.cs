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
	public class WorkFlowTask : IWorkFlowTask
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.WorkFlowTask model)
		{
			string sql = "INSERT INTO WorkFlowTask\r\n\t\t\t\t(ID,PrevID,PrevStepID,FlowID,StepID,StepName,InstanceID,GroupID,Type,Title,SenderID,SenderName,SenderTime,ReceiveID,ReceiveName,ReceiveTime,OpenTime,CompletedTime,CompletedTime1,Comment,IsSign,Status,Note,Sort,SubFlowGroupID,OtherType,Files,IsExpiredAutoSubmit,StepSort) \r\n\t\t\t\tVALUES(@ID,@PrevID,@PrevStepID,@FlowID,@StepID,@StepName,@InstanceID,@GroupID,@Type,@Title,@SenderID,@SenderName,@SenderTime,@ReceiveID,@ReceiveName,@ReceiveTime,@OpenTime,@CompletedTime,@CompletedTime1,@Comment,@IsSign,@Status,@Note,@Sort,@SubFlowGroupID,@OtherType,@Files,@IsExpiredAutoSubmit,@StepSort)";
			SqlParameter[] parameter = new SqlParameter[29]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ID
				},
				new SqlParameter("@PrevID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.PrevID
				},
				new SqlParameter("@PrevStepID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.PrevStepID
				},
				new SqlParameter("@FlowID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.FlowID
				},
				new SqlParameter("@StepID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.StepID
				},
				new SqlParameter("@StepName", SqlDbType.NVarChar, 1000)
				{
					Value = model.StepName
				},
				new SqlParameter("@InstanceID", SqlDbType.VarChar, 50)
				{
					Value = model.InstanceID
				},
				new SqlParameter("@GroupID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.GroupID
				},
				new SqlParameter("@Type", SqlDbType.Int, -1)
				{
					Value = model.Type
				},
				new SqlParameter("@Title", SqlDbType.NVarChar, 1000)
				{
					Value = model.Title
				},
				new SqlParameter("@SenderID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.SenderID
				},
				new SqlParameter("@SenderName", SqlDbType.NVarChar, 100)
				{
					Value = model.SenderName
				},
				new SqlParameter("@SenderTime", SqlDbType.DateTime, 8)
				{
					Value = model.SenderTime
				},
				new SqlParameter("@ReceiveID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ReceiveID
				},
				new SqlParameter("@ReceiveName", SqlDbType.NVarChar, 100)
				{
					Value = model.ReceiveName
				},
				new SqlParameter("@ReceiveTime", SqlDbType.DateTime, 8)
				{
					Value = model.ReceiveTime
				},
				(!model.OpenTime.HasValue) ? new SqlParameter("@OpenTime", SqlDbType.DateTime, 8)
				{
					Value = DBNull.Value
				} : new SqlParameter("@OpenTime", SqlDbType.DateTime, 8)
				{
					Value = model.OpenTime
				},
				(!model.CompletedTime.HasValue) ? new SqlParameter("@CompletedTime", SqlDbType.DateTime, 8)
				{
					Value = DBNull.Value
				} : new SqlParameter("@CompletedTime", SqlDbType.DateTime, 8)
				{
					Value = model.CompletedTime
				},
				(!model.CompletedTime1.HasValue) ? new SqlParameter("@CompletedTime1", SqlDbType.DateTime, 8)
				{
					Value = DBNull.Value
				} : new SqlParameter("@CompletedTime1", SqlDbType.DateTime, 8)
				{
					Value = model.CompletedTime1
				},
				(model.Comment == null) ? new SqlParameter("@Comment", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Comment", SqlDbType.VarChar, -1)
				{
					Value = model.Comment
				},
				(!model.IsSign.HasValue) ? new SqlParameter("@IsSign", SqlDbType.Int, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@IsSign", SqlDbType.Int, -1)
				{
					Value = model.IsSign
				},
				new SqlParameter("@Status", SqlDbType.Int, -1)
				{
					Value = model.Status
				},
				(model.Note == null) ? new SqlParameter("@Note", SqlDbType.NVarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Note", SqlDbType.NVarChar, -1)
				{
					Value = model.Note
				},
				new SqlParameter("@Sort", SqlDbType.Int, -1)
				{
					Value = model.Sort
				},
				(model.SubFlowGroupID == null) ? new SqlParameter("@SubFlowGroupID", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@SubFlowGroupID", SqlDbType.VarChar, -1)
				{
					Value = model.SubFlowGroupID
				},
				(!model.OtherType.HasValue) ? new SqlParameter("@OtherType", SqlDbType.Int, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@OtherType", SqlDbType.Int, -1)
				{
					Value = model.OtherType
				},
				(model.Files == null) ? new SqlParameter("@Files", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Files", SqlDbType.VarChar, -1)
				{
					Value = model.Files
				},
				new SqlParameter("@IsExpiredAutoSubmit", SqlDbType.Int, -1)
				{
					Value = model.IsExpiredAutoSubmit
				},
				new SqlParameter("@StepSort", SqlDbType.Int, -1)
				{
					Value = model.StepSort
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.WorkFlowTask model)
		{
			string sql = "UPDATE WorkFlowTask SET \r\n\t\t\t\tPrevID=@PrevID,PrevStepID=@PrevStepID,FlowID=@FlowID,StepID=@StepID,StepName=@StepName,InstanceID=@InstanceID,GroupID=@GroupID,Type=@Type,Title=@Title,SenderID=@SenderID,SenderName=@SenderName,SenderTime=@SenderTime,ReceiveID=@ReceiveID,ReceiveName=@ReceiveName,ReceiveTime=@ReceiveTime,OpenTime=@OpenTime,CompletedTime=@CompletedTime,CompletedTime1=@CompletedTime1,Comment=@Comment,IsSign=@IsSign,Status=@Status,Note=@Note,Sort=@Sort,SubFlowGroupID=@SubFlowGroupID,OtherType=@OtherType,Files=@Files,IsExpiredAutoSubmit=@IsExpiredAutoSubmit,StepSort=@StepSort  \r\n\t\t\t\tWHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[29]
			{
				new SqlParameter("@PrevID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.PrevID
				},
				new SqlParameter("@PrevStepID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.PrevStepID
				},
				new SqlParameter("@FlowID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.FlowID
				},
				new SqlParameter("@StepID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.StepID
				},
				new SqlParameter("@StepName", SqlDbType.NVarChar, 1000)
				{
					Value = model.StepName
				},
				new SqlParameter("@InstanceID", SqlDbType.VarChar, 50)
				{
					Value = model.InstanceID
				},
				new SqlParameter("@GroupID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.GroupID
				},
				new SqlParameter("@Type", SqlDbType.Int, -1)
				{
					Value = model.Type
				},
				new SqlParameter("@Title", SqlDbType.NVarChar, 1000)
				{
					Value = model.Title
				},
				new SqlParameter("@SenderID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.SenderID
				},
				new SqlParameter("@SenderName", SqlDbType.NVarChar, 100)
				{
					Value = model.SenderName
				},
				new SqlParameter("@SenderTime", SqlDbType.DateTime, 8)
				{
					Value = model.SenderTime
				},
				new SqlParameter("@ReceiveID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ReceiveID
				},
				new SqlParameter("@ReceiveName", SqlDbType.NVarChar, 100)
				{
					Value = model.ReceiveName
				},
				new SqlParameter("@ReceiveTime", SqlDbType.DateTime, 8)
				{
					Value = model.ReceiveTime
				},
				(!model.OpenTime.HasValue) ? new SqlParameter("@OpenTime", SqlDbType.DateTime, 8)
				{
					Value = DBNull.Value
				} : new SqlParameter("@OpenTime", SqlDbType.DateTime, 8)
				{
					Value = model.OpenTime
				},
				(!model.CompletedTime.HasValue) ? new SqlParameter("@CompletedTime", SqlDbType.DateTime, 8)
				{
					Value = DBNull.Value
				} : new SqlParameter("@CompletedTime", SqlDbType.DateTime, 8)
				{
					Value = model.CompletedTime
				},
				(!model.CompletedTime1.HasValue) ? new SqlParameter("@CompletedTime1", SqlDbType.DateTime, 8)
				{
					Value = DBNull.Value
				} : new SqlParameter("@CompletedTime1", SqlDbType.DateTime, 8)
				{
					Value = model.CompletedTime1
				},
				(model.Comment == null) ? new SqlParameter("@Comment", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Comment", SqlDbType.VarChar, -1)
				{
					Value = model.Comment
				},
				(!model.IsSign.HasValue) ? new SqlParameter("@IsSign", SqlDbType.Int, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@IsSign", SqlDbType.Int, -1)
				{
					Value = model.IsSign
				},
				new SqlParameter("@Status", SqlDbType.Int, -1)
				{
					Value = model.Status
				},
				(model.Note == null) ? new SqlParameter("@Note", SqlDbType.NVarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Note", SqlDbType.NVarChar, -1)
				{
					Value = model.Note
				},
				new SqlParameter("@Sort", SqlDbType.Int, -1)
				{
					Value = model.Sort
				},
				(model.SubFlowGroupID == null) ? new SqlParameter("@SubFlowGroupID", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@SubFlowGroupID", SqlDbType.VarChar, -1)
				{
					Value = model.SubFlowGroupID
				},
				(!model.OtherType.HasValue) ? new SqlParameter("@OtherType", SqlDbType.Int, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@OtherType", SqlDbType.Int, -1)
				{
					Value = model.OtherType
				},
				(model.Files == null) ? new SqlParameter("@Files", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Files", SqlDbType.VarChar, -1)
				{
					Value = model.Files
				},
				new SqlParameter("@IsExpiredAutoSubmit", SqlDbType.Int, -1)
				{
					Value = model.IsExpiredAutoSubmit
				},
				new SqlParameter("@StepSort", SqlDbType.Int, -1)
				{
					Value = model.StepSort
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
			string sql = "DELETE FROM WorkFlowTask WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.WorkFlowTask> DataReaderToList(SqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.WorkFlowTask> list = new List<RoadFlow.Data.Model.WorkFlowTask>();
			RoadFlow.Data.Model.WorkFlowTask workFlowTask = null;
			while (dataReader.Read())
			{
				workFlowTask = new RoadFlow.Data.Model.WorkFlowTask();
				workFlowTask.ID = dataReader.GetGuid(0);
				workFlowTask.PrevID = dataReader.GetGuid(1);
				workFlowTask.PrevStepID = dataReader.GetGuid(2);
				workFlowTask.FlowID = dataReader.GetGuid(3);
				workFlowTask.StepID = dataReader.GetGuid(4);
				workFlowTask.StepName = dataReader.GetString(5);
				workFlowTask.InstanceID = dataReader.GetString(6);
				workFlowTask.GroupID = dataReader.GetGuid(7);
				workFlowTask.Type = dataReader.GetInt32(8);
				workFlowTask.Title = dataReader.GetString(9);
				workFlowTask.SenderID = dataReader.GetGuid(10);
				workFlowTask.SenderName = dataReader.GetString(11);
				workFlowTask.SenderTime = dataReader.GetDateTime(12);
				workFlowTask.ReceiveID = dataReader.GetGuid(13);
				workFlowTask.ReceiveName = dataReader.GetString(14);
				workFlowTask.ReceiveTime = dataReader.GetDateTime(15);
				if (!dataReader.IsDBNull(16))
				{
					workFlowTask.OpenTime = dataReader.GetDateTime(16);
				}
				if (!dataReader.IsDBNull(17))
				{
					workFlowTask.CompletedTime = dataReader.GetDateTime(17);
				}
				if (!dataReader.IsDBNull(18))
				{
					workFlowTask.CompletedTime1 = dataReader.GetDateTime(18);
				}
				if (!dataReader.IsDBNull(19))
				{
					workFlowTask.Comment = dataReader.GetString(19);
				}
				if (!dataReader.IsDBNull(20))
				{
					workFlowTask.IsSign = dataReader.GetInt32(20);
				}
				workFlowTask.Status = dataReader.GetInt32(21);
				if (!dataReader.IsDBNull(22))
				{
					workFlowTask.Note = dataReader.GetString(22);
				}
				workFlowTask.Sort = dataReader.GetInt32(23);
				if (!dataReader.IsDBNull(24))
				{
					workFlowTask.SubFlowGroupID = dataReader.GetString(24);
				}
				if (!dataReader.IsDBNull(25))
				{
					workFlowTask.OtherType = dataReader.GetInt32(25);
				}
				if (!dataReader.IsDBNull(26))
				{
					workFlowTask.Files = dataReader.GetString(26);
				}
				workFlowTask.IsExpiredAutoSubmit = dataReader.GetInt32(27);
				workFlowTask.StepSort = dataReader.GetInt32(28);
				list.Add(workFlowTask);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.WorkFlowTask> GetAll()
		{
			string sql = "SELECT * FROM WorkFlowTask";
			SqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.WorkFlowTask> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM WorkFlowTask";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.WorkFlowTask Get(Guid id)
		{
			string sql = "SELECT * FROM WorkFlowTask WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.WorkFlowTask> list = DataReaderToList(dataReader);
			dataReader.Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public int Delete(Guid flowID, Guid groupID)
		{
			string text = "DELETE FROM WorkFlowTask WHERE GroupID=@GroupID";
			List<SqlParameter> list = new List<SqlParameter>
			{
				new SqlParameter("@GroupID", SqlDbType.UniqueIdentifier)
				{
					Value = groupID
				}
			};
			if (!flowID.IsEmptyGuid())
			{
				text += " AND FlowID=@FlowID";
				list.Add(new SqlParameter("@FlowID", SqlDbType.UniqueIdentifier)
				{
					Value = flowID
				});
			}
			return dbHelper.Execute(text, list.ToArray());
		}

		public void UpdateOpenTime(Guid id, DateTime openTime, bool isStatus = false)
		{
			string sql = "UPDATE WorkFlowTask SET OpenTime=@OpenTime " + (isStatus ? ", Status=1" : "") + " WHERE ID=@ID AND OpenTime IS NULL";
			SqlParameter[] parameter = new SqlParameter[2]
			{
				(openTime == DateTime.MinValue) ? new SqlParameter("@OpenTime", SqlDbType.DateTime)
				{
					Value = DBNull.Value
				} : new SqlParameter("@OpenTime", SqlDbType.DateTime)
				{
					Value = openTime
				},
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			dbHelper.Execute(sql, parameter);
		}

		public List<RoadFlow.Data.Model.WorkFlowTask> GetTasks(Guid userID, out string pager, string query = "", string title = "", string flowid = "", string sender = "", string date1 = "", string date2 = "", int type = 0)
		{
			List<SqlParameter> list = new List<SqlParameter>();
			StringBuilder stringBuilder = new StringBuilder("SELECT *,ROW_NUMBER() OVER(ORDER BY " + ((type == 0) ? "SenderTime DESC" : "CompletedTime1 DESC") + ") AS PagerAutoRowNumber FROM WorkFlowTask WHERE ReceiveID=@ReceiveID");
			stringBuilder.Append((type == 0) ? " AND Status IN(0,1)" : " AND Status IN(2,3,4,5)");
			list.Add(new SqlParameter("@ReceiveID", SqlDbType.UniqueIdentifier)
			{
				Value = userID
			});
			if (!title.IsNullOrEmpty())
			{
				stringBuilder.Append(" AND CHARINDEX(@Title,Title)>0");
				list.Add(new SqlParameter("@Title", SqlDbType.NVarChar, 2000)
				{
					Value = title
				});
			}
			if (flowid.IsGuid())
			{
				stringBuilder.Append(" AND FlowID=@FlowID");
				list.Add(new SqlParameter("@FlowID", SqlDbType.UniqueIdentifier)
				{
					Value = flowid.ToGuid()
				});
			}
			else if (!flowid.IsNullOrEmpty() && flowid.IndexOf(',') >= 0)
			{
				stringBuilder.Append(" AND FlowID IN(" + Tools.GetSqlInString(flowid) + ")");
			}
			if (sender.IsGuid())
			{
				stringBuilder.Append(" AND SenderID=@SenderID");
				list.Add(new SqlParameter("@SenderID", SqlDbType.UniqueIdentifier)
				{
					Value = sender.ToGuid()
				});
			}
			if (date1.IsDateTime())
			{
				stringBuilder.Append(" AND ReceiveTime>=@ReceiveTime");
				list.Add(new SqlParameter("@ReceiveTime", SqlDbType.DateTime)
				{
					Value = date1.ToDateTime().Date
				});
			}
			if (date2.IsDateTime())
			{
				stringBuilder.Append(" AND SenderTime<=@ReceiveTime1");
				list.Add(new SqlParameter("@ReceiveTime1", SqlDbType.DateTime)
				{
					Value = date2.ToDateTime().AddDays(1.0).Date
				});
			}
			int pageSize = Tools.GetPageSize();
			int pageNumber = Tools.GetPageNumber();
			long count;
			string paerSql = dbHelper.GetPaerSql(stringBuilder.ToString(), pageSize, pageNumber, out count, list.ToArray());
			pager = Tools.GetPagerHtml(count, pageSize, pageNumber, query);
			SqlDataReader dataReader = dbHelper.GetDataReader(paerSql, list.ToArray());
			List<RoadFlow.Data.Model.WorkFlowTask> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public List<RoadFlow.Data.Model.WorkFlowTask> GetTasks(Guid userID, out long count, int size, int number, string title = "", string flowid = "", string sender = "", string date1 = "", string date2 = "", int type = 0, string order = "")
		{
			List<SqlParameter> list = new List<SqlParameter>();
			StringBuilder stringBuilder = new StringBuilder("SELECT *,ROW_NUMBER() OVER(ORDER BY " + ((!order.IsNullOrEmpty()) ? order : ((type == 0) ? "SenderTime DESC" : "CompletedTime1 DESC")) + ") AS PagerAutoRowNumber FROM WorkFlowTask WHERE ReceiveID=@ReceiveID");
			stringBuilder.Append((type == 0) ? " AND Status IN(0,1)" : " AND Status IN(2,3,4,5)");
			list.Add(new SqlParameter("@ReceiveID", SqlDbType.UniqueIdentifier)
			{
				Value = userID
			});
			if (!title.IsNullOrEmpty())
			{
				stringBuilder.Append(" AND CHARINDEX(@Title,Title)>0");
				list.Add(new SqlParameter("@Title", SqlDbType.NVarChar, 2000)
				{
					Value = title
				});
			}
			if (flowid.IsGuid())
			{
				stringBuilder.Append(" AND FlowID=@FlowID");
				list.Add(new SqlParameter("@FlowID", SqlDbType.UniqueIdentifier)
				{
					Value = flowid.ToGuid()
				});
			}
			else if (!flowid.IsNullOrEmpty() && flowid.IndexOf(',') >= 0)
			{
				stringBuilder.Append(" AND FlowID IN(" + Tools.GetSqlInString(flowid) + ")");
			}
			if (sender.IsGuid())
			{
				stringBuilder.Append(" AND SenderID=@SenderID");
				list.Add(new SqlParameter("@SenderID", SqlDbType.UniqueIdentifier)
				{
					Value = sender.ToGuid()
				});
			}
			if (date1.IsDateTime())
			{
				stringBuilder.Append(" AND ReceiveTime>=@ReceiveTime");
				list.Add(new SqlParameter("@ReceiveTime", SqlDbType.DateTime)
				{
					Value = date1.ToDateTime().Date
				});
			}
			if (date2.IsDateTime())
			{
				stringBuilder.Append(" AND SenderTime<=@ReceiveTime1");
				list.Add(new SqlParameter("@ReceiveTime1", SqlDbType.DateTime)
				{
					Value = date2.ToDateTime().AddDays(1.0).Date
				});
			}
			string paerSql = dbHelper.GetPaerSql(stringBuilder.ToString(), size, number, out count, list.ToArray());
			SqlDataReader dataReader = dbHelper.GetDataReader(paerSql, list.ToArray());
			List<RoadFlow.Data.Model.WorkFlowTask> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public List<RoadFlow.Data.Model.WorkFlowTask> GetInstances(Guid[] flowID, Guid[] senderID, Guid[] receiveID, out string pager, string query = "", string title = "", string flowid = "", string date1 = "", string date2 = "", int status = 0)
		{
			List<SqlParameter> list = new List<SqlParameter>();
			StringBuilder stringBuilder = new StringBuilder("SELECT a.*,ROW_NUMBER() OVER(ORDER BY a.SenderTime DESC) AS PagerAutoRowNumber FROM WorkFlowTask a\r\n                WHERE a.ID=(SELECT TOP 1 ID FROM WorkFlowTask WHERE FlowID=a.FlowID AND GroupID=a.GroupID ORDER BY Sort DESC)");
			switch (status)
			{
			case 1:
				stringBuilder.Append(" AND a.Status IN(0,1,5)");
				break;
			case 2:
				stringBuilder.Append(" AND a.Status IN(2,3,4)");
				break;
			}
			if (flowID != null && flowID.Length != 0)
			{
				stringBuilder.Append(string.Format(" AND a.FlowID IN({0})", Tools.GetSqlInString(flowID)));
			}
			if (senderID != null && senderID.Length != 0)
			{
				if (senderID.Length == 1)
				{
					stringBuilder.Append(" AND a.SenderID=@SenderID");
					list.Add(new SqlParameter("@SenderID", SqlDbType.UniqueIdentifier)
					{
						Value = senderID[0]
					});
				}
				else
				{
					stringBuilder.Append(string.Format(" AND a.SenderID IN({0})", Tools.GetSqlInString(senderID)));
				}
			}
			if (receiveID != null && receiveID.Length != 0)
			{
				if (senderID.Length == 1)
				{
					stringBuilder.Append(" AND a.ReceiveID=@ReceiveID");
					list.Add(new SqlParameter("@ReceiveID", SqlDbType.UniqueIdentifier)
					{
						Value = receiveID[0]
					});
				}
				else
				{
					stringBuilder.Append(string.Format(" AND a.ReceiveID IN({0})", Tools.GetSqlInString(receiveID)));
				}
			}
			if (!title.IsNullOrEmpty())
			{
				stringBuilder.Append(" AND CHARINDEX(@Title,a.Title)>0");
				list.Add(new SqlParameter("@Title", SqlDbType.NVarChar, 2000)
				{
					Value = title
				});
			}
			if (flowid.IsGuid())
			{
				stringBuilder.Append(" AND a.FlowID=@FlowID");
				list.Add(new SqlParameter("@FlowID", SqlDbType.UniqueIdentifier)
				{
					Value = flowid.ToGuid()
				});
			}
			else if (!flowid.IsNullOrEmpty() && flowid.IndexOf(',') >= 0)
			{
				stringBuilder.Append(" AND a.FlowID IN(" + Tools.GetSqlInString(flowid) + ")");
			}
			if (date1.IsDateTime())
			{
				stringBuilder.Append(" AND a.SenderTime>=@SenderTime");
				list.Add(new SqlParameter("@SenderTime", SqlDbType.DateTime)
				{
					Value = date1.ToDateTime().Date
				});
			}
			if (date2.IsDateTime())
			{
				stringBuilder.Append(" AND a.SenderTime<=@SenderTime1");
				list.Add(new SqlParameter("@SenderTime1", SqlDbType.DateTime)
				{
					Value = date2.ToDateTime().AddDays(1.0).Date
				});
			}
			int pageSize = Tools.GetPageSize();
			int pageNumber = Tools.GetPageNumber();
			long count;
			string paerSql = dbHelper.GetPaerSql(stringBuilder.ToString(), pageSize, pageNumber, out count, list.ToArray());
			pager = Tools.GetPagerHtml(count, pageSize, pageNumber, query);
			SqlDataReader dataReader = dbHelper.GetDataReader(paerSql, list.ToArray());
			List<RoadFlow.Data.Model.WorkFlowTask> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public DataTable GetInstances1(Guid[] flowID, Guid[] senderID, Guid[] receiveID, out string pager, string query = "", string title = "", string flowid = "", string date1 = "", string date2 = "", int status = 0)
		{
			List<SqlParameter> list = new List<SqlParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			switch (status)
			{
			case 1:
				stringBuilder.Append(" AND Status IN(0,1,5)");
				break;
			case 2:
				stringBuilder.Append(" AND Status IN(2,3,4)");
				break;
			}
			if (flowID != null && flowID.Length != 0)
			{
				stringBuilder.Append(string.Format(" AND FlowID IN({0})", Tools.GetSqlInString(flowID)));
			}
			if (senderID != null && senderID.Length != 0)
			{
				if (senderID.Length == 1)
				{
					stringBuilder.Append(" AND SenderID=@SenderID");
					list.Add(new SqlParameter("@SenderID", SqlDbType.UniqueIdentifier)
					{
						Value = senderID[0]
					});
				}
				else
				{
					stringBuilder.Append(string.Format(" AND SenderID IN({0})", Tools.GetSqlInString(senderID)));
				}
			}
			if (receiveID != null && receiveID.Length != 0)
			{
				if (receiveID.Length == 1)
				{
					stringBuilder.Append(" AND ReceiveID=@ReceiveID");
					list.Add(new SqlParameter("@ReceiveID", SqlDbType.UniqueIdentifier)
					{
						Value = receiveID[0]
					});
				}
				else
				{
					stringBuilder.Append(string.Format(" AND ReceiveID IN({0})", Tools.GetSqlInString(receiveID)));
				}
			}
			if (!title.IsNullOrEmpty())
			{
				stringBuilder.Append(" AND CHARINDEX(@Title,Title)>0");
				list.Add(new SqlParameter("@Title", SqlDbType.NVarChar, 2000)
				{
					Value = title
				});
			}
			if (flowid.IsGuid())
			{
				stringBuilder.Append(" AND FlowID=@FlowID");
				list.Add(new SqlParameter("@FlowID", SqlDbType.UniqueIdentifier)
				{
					Value = flowid.ToGuid()
				});
			}
			else if (!flowid.IsNullOrEmpty() && flowid.IndexOf(',') >= 0)
			{
				stringBuilder.Append(" AND FlowID IN(" + Tools.GetSqlInString(flowid) + ")");
			}
			if (date1.IsDateTime())
			{
				stringBuilder.Append(" AND SenderTime>=@SenderTime");
				list.Add(new SqlParameter("@SenderTime", SqlDbType.DateTime)
				{
					Value = date1.ToDateTime().Date
				});
			}
			if (date2.IsDateTime())
			{
				stringBuilder.Append(" AND SenderTime<=@SenderTime1");
				list.Add(new SqlParameter("@SenderTime1", SqlDbType.DateTime)
				{
					Value = date2.ToDateTime().AddDays(1.0).Date
				});
			}
			string sql = string.Format("select *,ROW_NUMBER() OVER(ORDER BY SenderTime DESC) AS PagerAutoRowNumber from(\r\nselect flowid,groupid,MAX(SenderTime) SenderTime from WorkFlowTask WHERE 1=1 {0} group by FlowID, GroupID\r\n) temp", stringBuilder.ToString());
			int pageSize = Tools.GetPageSize();
			int pageNumber = Tools.GetPageNumber();
			long count;
			string paerSql = dbHelper.GetPaerSql(sql, pageSize, pageNumber, out count, list.ToArray());
			pager = Tools.GetPagerHtml(count, pageSize, pageNumber, query);
			return dbHelper.GetDataTable(paerSql, list.ToArray());
		}

		public DataTable GetInstances1(Guid[] flowID, Guid[] senderID, Guid[] receiveID, out long count, int size, int number, string title = "", string flowid = "", string date1 = "", string date2 = "", int status = 0, string order = "")
		{
			List<SqlParameter> list = new List<SqlParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			switch (status)
			{
			case 1:
				stringBuilder.Append(" AND Status IN(0,1,5)");
				break;
			case 2:
				stringBuilder.Append(" AND Status IN(2,3,4)");
				break;
			}
			if (flowID != null && flowID.Length != 0)
			{
				stringBuilder.Append(string.Format(" AND FlowID IN({0})", Tools.GetSqlInString(flowID)));
			}
			if (senderID != null && senderID.Length != 0)
			{
				if (senderID.Length == 1)
				{
					stringBuilder.Append(" AND SenderID=@SenderID");
					list.Add(new SqlParameter("@SenderID", SqlDbType.UniqueIdentifier)
					{
						Value = senderID[0]
					});
				}
				else
				{
					stringBuilder.Append(string.Format(" AND SenderID IN({0})", Tools.GetSqlInString(senderID)));
				}
			}
			if (receiveID != null && receiveID.Length != 0)
			{
				if (receiveID.Length == 1)
				{
					stringBuilder.Append(" AND SenderID=@ReceiveID");
					list.Add(new SqlParameter("@ReceiveID", SqlDbType.UniqueIdentifier)
					{
						Value = receiveID[0]
					});
				}
				else
				{
					stringBuilder.Append(string.Format(" AND SenderID IN({0})", Tools.GetSqlInString(receiveID)));
				}
			}
			if (!title.IsNullOrEmpty())
			{
				stringBuilder.Append(" AND CHARINDEX(@Title,Title)>0");
				list.Add(new SqlParameter("@Title", SqlDbType.NVarChar, 2000)
				{
					Value = title
				});
			}
			if (flowid.IsGuid())
			{
				stringBuilder.Append(" AND FlowID=@FlowID");
				list.Add(new SqlParameter("@FlowID", SqlDbType.UniqueIdentifier)
				{
					Value = flowid.ToGuid()
				});
			}
			else if (!flowid.IsNullOrEmpty() && flowid.IndexOf(',') >= 0)
			{
				stringBuilder.Append(" AND FlowID IN(" + Tools.GetSqlInString(flowid) + ")");
			}
			if (date1.IsDateTime())
			{
				stringBuilder.Append(" AND SenderTime>=@SenderTime");
				list.Add(new SqlParameter("@SenderTime", SqlDbType.DateTime)
				{
					Value = date1.ToDateTime().Date
				});
			}
			if (date2.IsDateTime())
			{
				stringBuilder.Append(" AND SenderTime<=@SenderTime1");
				list.Add(new SqlParameter("@SenderTime1", SqlDbType.DateTime)
				{
					Value = date2.ToDateTime().AddDays(1.0).Date
				});
			}
			string sql = string.Format("select *,ROW_NUMBER() OVER(ORDER BY " + (order.IsNullOrEmpty() ? "SenderTime DESC" : order) + ") AS PagerAutoRowNumber from(select flowid,groupid,MAX(SenderTime) SenderTime from WorkFlowTask WHERE 1=1 {0} group by FlowID, GroupID) temp", stringBuilder.ToString());
			string paerSql = dbHelper.GetPaerSql(sql, size, number, out count, list.ToArray());
			return dbHelper.GetDataTable(paerSql, list.ToArray());
		}

		public Guid GetFirstSnderID(Guid flowID, Guid groupID)
		{
			string sql = "SELECT SenderID FROM WorkFlowTask WHERE FlowID=@FlowID AND GroupID=@GroupID AND PrevID=@PrevID";
			SqlParameter[] parameter = new SqlParameter[3]
			{
				new SqlParameter("@FlowID", SqlDbType.UniqueIdentifier)
				{
					Value = flowID
				},
				new SqlParameter("@GroupID", SqlDbType.UniqueIdentifier)
				{
					Value = groupID
				},
				new SqlParameter("@PrevID", SqlDbType.UniqueIdentifier)
				{
					Value = Guid.Empty
				}
			};
			return dbHelper.GetFieldValue(sql, parameter).ToGuid();
		}

		public List<Guid> GetStepSnderID(Guid flowID, Guid stepID, Guid groupID)
		{
			string sql = "SELECT ReceiveID, Sort FROM WorkFlowTask WHERE FlowID=@FlowID AND StepID=@StepID AND GroupID=@GroupID AND Sort=(SELECT ISNULL(MAX(Sort),0) FROM WorkFlowTask WHERE FlowID=@FlowID AND StepID=@StepID AND GroupID=@GroupID)";
			SqlParameter[] parameter = new SqlParameter[3]
			{
				new SqlParameter("@FlowID", SqlDbType.UniqueIdentifier)
				{
					Value = flowID
				},
				new SqlParameter("@StepID", SqlDbType.UniqueIdentifier)
				{
					Value = stepID
				},
				new SqlParameter("@GroupID", SqlDbType.UniqueIdentifier)
				{
					Value = groupID
				}
			};
			DataTable dataTable = dbHelper.GetDataTable(sql, parameter);
			List<Guid> list = new List<Guid>();
			foreach (DataRow row in dataTable.Rows)
			{
				Guid result;
				if (Guid.TryParse(row[0].ToString(), out result))
				{
					list.Add(result);
				}
			}
			return list;
		}

		public List<Guid> GetPrevSnderID(Guid flowID, Guid stepID, Guid groupID)
		{
			string sql = "SELECT ReceiveID FROM WorkFlowTask WHERE ID=(SELECT PrevID FROM WorkFlowTask WHERE FlowID=@FlowID AND StepID=@StepID AND GroupID=@GroupID)";
			SqlParameter[] parameter = new SqlParameter[3]
			{
				new SqlParameter("@FlowID", SqlDbType.UniqueIdentifier)
				{
					Value = flowID
				},
				new SqlParameter("@StepID", SqlDbType.UniqueIdentifier)
				{
					Value = stepID
				},
				new SqlParameter("@GroupID", SqlDbType.UniqueIdentifier)
				{
					Value = groupID
				}
			};
			DataTable dataTable = dbHelper.GetDataTable(sql, parameter);
			List<Guid> list = new List<Guid>();
			foreach (DataRow row in dataTable.Rows)
			{
				Guid result;
				if (Guid.TryParse(row[0].ToString(), out result))
				{
					list.Add(result);
				}
			}
			return list;
		}

		public int Completed(Guid taskID, string comment = "", bool isSign = false, int status = 2, string note = "", string files = "")
		{
			string sql = "UPDATE WorkFlowTask SET Comment=@Comment,CompletedTime1=@CompletedTime1,IsSign=@IsSign,Status=@Status,Note=@Note,Files=@Files WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[7]
			{
				comment.IsNullOrEmpty() ? new SqlParameter("@Comment", SqlDbType.VarChar)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Comment", SqlDbType.VarChar)
				{
					Value = comment
				},
				new SqlParameter("@CompletedTime1", SqlDbType.DateTime)
				{
					Value = DateTimeNew.Now
				},
				new SqlParameter("@IsSign", SqlDbType.Int)
				{
					Value = (isSign ? 1 : 0)
				},
				new SqlParameter("@Status", SqlDbType.Int)
				{
					Value = status
				},
				note.IsNullOrEmpty() ? new SqlParameter("@Note", SqlDbType.NVarChar)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Note", SqlDbType.NVarChar)
				{
					Value = note
				},
				files.IsNullOrEmpty() ? new SqlParameter("@Files", SqlDbType.VarChar)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Files", SqlDbType.VarChar)
				{
					Value = files
				},
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = taskID
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public int UpdateNextTaskStatus(Guid taskID, int status)
		{
			string sql = "UPDATE WorkFlowTask SET Status=@Status WHERE PrevID=@PrevID";
			SqlParameter[] parameter = new SqlParameter[2]
			{
				new SqlParameter("@Status", SqlDbType.Int)
				{
					Value = status
				},
				new SqlParameter("@PrevID", SqlDbType.UniqueIdentifier)
				{
					Value = taskID
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public List<RoadFlow.Data.Model.WorkFlowTask> GetTaskList(Guid flowID, Guid stepID, Guid groupID)
		{
			string sql = "SELECT * FROM WorkFlowTask WHERE StepID=@StepID AND GroupID=@GroupID";
			SqlParameter[] parameter = new SqlParameter[2]
			{
				new SqlParameter("@StepID", SqlDbType.UniqueIdentifier)
				{
					Value = stepID
				},
				new SqlParameter("@GroupID", SqlDbType.UniqueIdentifier)
				{
					Value = groupID
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.WorkFlowTask> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public List<RoadFlow.Data.Model.WorkFlowTask> GetUserTaskList(Guid flowID, Guid stepID, Guid groupID, Guid userID)
		{
			string sql = "SELECT * FROM WorkFlowTask WHERE StepID=@StepID AND GroupID=@GroupID AND ReceiveID=@ReceiveID";
			SqlParameter[] parameter = new SqlParameter[3]
			{
				new SqlParameter("@StepID", SqlDbType.UniqueIdentifier)
				{
					Value = stepID
				},
				new SqlParameter("@GroupID", SqlDbType.UniqueIdentifier)
				{
					Value = groupID
				},
				new SqlParameter("@ReceiveID", SqlDbType.UniqueIdentifier)
				{
					Value = userID
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.WorkFlowTask> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public List<RoadFlow.Data.Model.WorkFlowTask> GetTaskList(Guid flowID, Guid groupID)
		{
			string empty = string.Empty;
			SqlParameter[] parameter;
			if (flowID.IsEmptyGuid())
			{
				empty = "SELECT * FROM WorkFlowTask WHERE GroupID=@GroupID";
				parameter = new SqlParameter[1]
				{
					new SqlParameter("@GroupID", SqlDbType.UniqueIdentifier)
					{
						Value = groupID
					}
				};
			}
			else
			{
				empty = "SELECT * FROM WorkFlowTask WHERE FlowID=@FlowID AND GroupID=@GroupID";
				parameter = new SqlParameter[2]
				{
					new SqlParameter("@FlowID", SqlDbType.UniqueIdentifier)
					{
						Value = flowID
					},
					new SqlParameter("@GroupID", SqlDbType.UniqueIdentifier)
					{
						Value = groupID
					}
				};
			}
			SqlDataReader dataReader = dbHelper.GetDataReader(empty, parameter);
			List<RoadFlow.Data.Model.WorkFlowTask> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public List<RoadFlow.Data.Model.WorkFlowTask> GetTaskList(Guid taskID, bool isStepID = true)
		{
			RoadFlow.Data.Model.WorkFlowTask workFlowTask = Get(taskID);
			if (workFlowTask != null)
			{
				string sql = string.Format("SELECT * FROM WorkFlowTask WHERE FlowID=@FlowID AND GroupID=@GroupID AND PrevID=@PrevID AND {0}", isStepID ? "StepID=@StepID" : "PrevStepID=@StepID");
				SqlParameter[] parameter = new SqlParameter[4]
				{
					new SqlParameter("@FlowID", SqlDbType.UniqueIdentifier)
					{
						Value = workFlowTask.FlowID
					},
					new SqlParameter("@GroupID", SqlDbType.UniqueIdentifier)
					{
						Value = workFlowTask.GroupID
					},
					new SqlParameter("@PrevID", SqlDbType.UniqueIdentifier)
					{
						Value = workFlowTask.PrevID
					},
					new SqlParameter("@StepID", SqlDbType.UniqueIdentifier)
					{
						Value = (isStepID ? workFlowTask.StepID : workFlowTask.PrevStepID)
					}
				};
				SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
				List<RoadFlow.Data.Model.WorkFlowTask> result = DataReaderToList(dataReader);
				dataReader.Close();
				return result;
			}
			return new List<RoadFlow.Data.Model.WorkFlowTask>();
		}

		public List<RoadFlow.Data.Model.WorkFlowTask> GetPrevTaskList(Guid taskID)
		{
			string sql = "SELECT * FROM WorkFlowTask WHERE ID=(SELECT PrevID FROM WorkFlowTask WHERE ID=@ID)";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = taskID
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.WorkFlowTask> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public List<RoadFlow.Data.Model.WorkFlowTask> GetNextTaskList(Guid taskID)
		{
			string sql = "SELECT * FROM WorkFlowTask WHERE PrevID=@PrevID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@PrevID", SqlDbType.UniqueIdentifier)
				{
					Value = taskID
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.WorkFlowTask> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public bool HasTasks(Guid flowID)
		{
			string sql = "SELECT TOP 1 ID FROM WorkFlowTask WHERE FlowID=@FlowID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@FlowID", SqlDbType.UniqueIdentifier)
				{
					Value = flowID
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			bool hasRows = dataReader.HasRows;
			dataReader.Close();
			return hasRows;
		}

		public bool HasNoCompletedTasks(Guid flowID, Guid stepID, Guid groupID, Guid userID)
		{
			string sql = "SELECT TOP 1 ID FROM WorkFlowTask WHERE FlowID=@FlowID AND StepID=@StepID AND GroupID=@GroupID AND ReceiveID=@ReceiveID AND Status IN(-1,0,1)";
			SqlParameter[] parameter = new SqlParameter[4]
			{
				new SqlParameter("@FlowID", SqlDbType.UniqueIdentifier)
				{
					Value = flowID
				},
				new SqlParameter("@StepID", SqlDbType.UniqueIdentifier)
				{
					Value = stepID
				},
				new SqlParameter("@GroupID", SqlDbType.UniqueIdentifier)
				{
					Value = groupID
				},
				new SqlParameter("@ReceiveID", SqlDbType.UniqueIdentifier)
				{
					Value = userID
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			bool hasRows = dataReader.HasRows;
			dataReader.Close();
			return hasRows;
		}

		public int UpdateTempTasks(Guid flowID, Guid stepID, Guid groupID, DateTime? completedTime, DateTime receiveTime)
		{
			string sql = "UPDATE WorkFlowTask SET CompletedTime=@CompletedTime,ReceiveTime=@ReceiveTime,SenderTime=@SenderTime,Status=0 WHERE FlowID=@FlowID AND StepID=@StepID AND GroupID=@GroupID AND Status=-1";
			SqlParameter[] parameter = new SqlParameter[6]
			{
				(!completedTime.HasValue) ? new SqlParameter("@CompletedTime", SqlDbType.DateTime)
				{
					Value = DBNull.Value
				} : new SqlParameter("@CompletedTime", SqlDbType.DateTime)
				{
					Value = completedTime.Value
				},
				new SqlParameter("@ReceiveTime", SqlDbType.DateTime)
				{
					Value = receiveTime
				},
				new SqlParameter("@SenderTime", SqlDbType.DateTime)
				{
					Value = receiveTime
				},
				new SqlParameter("@FlowID", SqlDbType.UniqueIdentifier)
				{
					Value = flowID
				},
				new SqlParameter("@StepID", SqlDbType.UniqueIdentifier)
				{
					Value = stepID
				},
				new SqlParameter("@GroupID", SqlDbType.UniqueIdentifier)
				{
					Value = groupID
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public int DeleteTempTasks(Guid flowID, Guid stepID, Guid groupID, Guid prevStepID)
		{
			string text = "DELETE WorkFlowTask WHERE FlowID=@FlowID AND StepID=@StepID AND GroupID=@GroupID AND Status=-1";
			List<SqlParameter> list = new List<SqlParameter>
			{
				new SqlParameter("@FlowID", SqlDbType.UniqueIdentifier)
				{
					Value = flowID
				},
				new SqlParameter("@StepID", SqlDbType.UniqueIdentifier)
				{
					Value = stepID
				},
				new SqlParameter("@GroupID", SqlDbType.UniqueIdentifier)
				{
					Value = groupID
				}
			};
			if (!prevStepID.IsEmptyGuid())
			{
				text += " AND PrevStepID=@PrevStepID";
				list.Add(new SqlParameter("@PrevStepID", SqlDbType.UniqueIdentifier)
				{
					Value = prevStepID
				});
			}
			return dbHelper.Execute(text, list.ToArray());
		}

		public int GetTaskStatus(Guid taskID)
		{
			string sql = "SELECT Status FROM WorkFlowTask WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = taskID
				}
			};
			int test;
			if (!dbHelper.GetFieldValue(sql, parameter).IsInt(out test))
			{
				return -1;
			}
			return test;
		}

		public List<RoadFlow.Data.Model.WorkFlowTask> GetBySubFlowGroupID(Guid subflowGroupID)
		{
			string sql = "SELECT * FROM WorkFlowTask WHERE CHARINDEX(@SubFlowGroupID,SubFlowGroupID)>0";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@SubFlowGroupID", SqlDbType.VarChar)
				{
					Value = subflowGroupID.ToString()
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.WorkFlowTask> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public RoadFlow.Data.Model.WorkFlowTask GetLastTask(Guid flowID, Guid groupID)
		{
			string sql = "SELECT TOP 1 * FROM WorkFlowTask WHERE FlowID=@FlowID AND GroupID=@GroupID ORDER BY Sort DESC";
			SqlParameter[] parameter = new SqlParameter[2]
			{
				new SqlParameter("@FlowID", SqlDbType.UniqueIdentifier)
				{
					Value = flowID
				},
				new SqlParameter("@GroupID", SqlDbType.UniqueIdentifier)
				{
					Value = groupID
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.WorkFlowTask> list = DataReaderToList(dataReader);
			dataReader.Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public List<RoadFlow.Data.Model.WorkFlowTask> GetExpiredAutoSubmitTasks()
		{
			string sql = "SELECT * FROM WorkFlowTask WHERE CompletedTime<'" + DateTimeNew.Now.ToDateTimeStringS() + "' AND IsExpiredAutoSubmit=1 AND Status IN(0,1)";
			SqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.WorkFlowTask> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}
	}
}
