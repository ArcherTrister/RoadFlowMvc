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
	public class WorkFlowArchives : IWorkFlowArchives
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.WorkFlowArchives model)
		{
			string sql = "INSERT INTO WorkFlowArchives\r\n\t\t\t\t(ID,FlowID,StepID,FlowName,StepName,TaskID,GroupID,InstanceID,Title,Contents,Comments,WriteTime) \r\n\t\t\t\tVALUES(@ID,@FlowID,@StepID,@FlowName,@StepName,@TaskID,@GroupID,@InstanceID,@Title,@Contents,@Comments,@WriteTime)";
			SqlParameter[] parameter = new SqlParameter[12]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ID
				},
				new SqlParameter("@FlowID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.FlowID
				},
				new SqlParameter("@StepID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.StepID
				},
				new SqlParameter("@FlowName", SqlDbType.NVarChar, 1000)
				{
					Value = model.FlowName
				},
				new SqlParameter("@StepName", SqlDbType.NVarChar, 1000)
				{
					Value = model.StepName
				},
				new SqlParameter("@TaskID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.TaskID
				},
				new SqlParameter("@GroupID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.GroupID
				},
				new SqlParameter("@InstanceID", SqlDbType.VarChar, 500)
				{
					Value = model.InstanceID
				},
				new SqlParameter("@Title", SqlDbType.NVarChar, 8000)
				{
					Value = model.Title
				},
				new SqlParameter("@Contents", SqlDbType.Text, -1)
				{
					Value = model.Contents
				},
				new SqlParameter("@Comments", SqlDbType.Text, -1)
				{
					Value = model.Comments
				},
				new SqlParameter("@WriteTime", SqlDbType.DateTime, 8)
				{
					Value = model.WriteTime
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.WorkFlowArchives model)
		{
			string sql = "UPDATE WorkFlowArchives SET \r\n\t\t\t\tFlowID=@FlowID,StepID=@StepID,FlowName=@FlowName,StepName=@StepName,TaskID=@TaskID,GroupID=@GroupID,InstanceID=@InstanceID,Title=@Title,Contents=@Contents,Comments=@Comments,WriteTime=@WriteTime\r\n\t\t\t\tWHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[12]
			{
				new SqlParameter("@FlowID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.FlowID
				},
				new SqlParameter("@StepID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.StepID
				},
				new SqlParameter("@FlowName", SqlDbType.NVarChar, 1000)
				{
					Value = model.FlowName
				},
				new SqlParameter("@StepName", SqlDbType.NVarChar, 1000)
				{
					Value = model.StepName
				},
				new SqlParameter("@TaskID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.TaskID
				},
				new SqlParameter("@GroupID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.GroupID
				},
				new SqlParameter("@InstanceID", SqlDbType.VarChar, 500)
				{
					Value = model.InstanceID
				},
				new SqlParameter("@Title", SqlDbType.NVarChar, 8000)
				{
					Value = model.Title
				},
				new SqlParameter("@Contents", SqlDbType.Text, -1)
				{
					Value = model.Contents
				},
				new SqlParameter("@Comments", SqlDbType.Text, -1)
				{
					Value = model.Comments
				},
				new SqlParameter("@WriteTime", SqlDbType.DateTime, 8)
				{
					Value = model.WriteTime
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
			string sql = "DELETE FROM WorkFlowArchives WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.WorkFlowArchives> DataReaderToList(SqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.WorkFlowArchives> list = new List<RoadFlow.Data.Model.WorkFlowArchives>();
			RoadFlow.Data.Model.WorkFlowArchives workFlowArchives = null;
			while (dataReader.Read())
			{
				workFlowArchives = new RoadFlow.Data.Model.WorkFlowArchives();
				workFlowArchives.ID = dataReader.GetGuid(0);
				workFlowArchives.FlowID = dataReader.GetGuid(1);
				workFlowArchives.StepID = dataReader.GetGuid(2);
				workFlowArchives.FlowName = dataReader.GetString(3);
				workFlowArchives.StepName = dataReader.GetString(4);
				workFlowArchives.TaskID = dataReader.GetGuid(5);
				workFlowArchives.GroupID = dataReader.GetGuid(6);
				workFlowArchives.InstanceID = dataReader.GetString(7);
				workFlowArchives.Title = dataReader.GetString(8);
				workFlowArchives.Contents = dataReader.GetString(9);
				workFlowArchives.Comments = dataReader.GetString(10);
				workFlowArchives.WriteTime = dataReader.GetDateTime(11);
				list.Add(workFlowArchives);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.WorkFlowArchives> GetAll()
		{
			string sql = "SELECT * FROM WorkFlowArchives";
			SqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.WorkFlowArchives> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM WorkFlowArchives";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.WorkFlowArchives Get(Guid id)
		{
			string sql = "SELECT * FROM WorkFlowArchives WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.WorkFlowArchives> list = DataReaderToList(dataReader);
			dataReader.Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public DataTable GetPagerData(out string pager, string query = "", string title = "", string flowIDString = "")
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
			if (!flowIDString.IsNullOrEmpty())
			{
				stringBuilder.AppendFormat("AND FlowID IN({0}) ", Tools.GetSqlInString(flowIDString));
			}
			int pageSize = Tools.GetPageSize();
			int pageNumber = Tools.GetPageNumber();
			long count;
			string paerSql = dbHelper.GetPaerSql("WorkFlowArchives", "*", stringBuilder.ToString(), "WriteTime DESC", pageSize, pageNumber, out count, list.ToArray());
			pager = Tools.GetPagerHtml(count, pageSize, pageNumber, query);
			return dbHelper.GetDataTable(paerSql, list.ToArray());
		}

		public DataTable GetPagerData(out long count, int pageSize, int pageNumber, string title = "", string flowIDString = "", string date1 = "", string date2 = "", string order = "")
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
			if (flowIDString.IsGuid())
			{
				stringBuilder.Append("AND FlowID=@FlowID ");
				list.Add(new SqlParameter("@FlowID", flowIDString));
			}
			if (date1.IsDateTime())
			{
				stringBuilder.Append("AND WriteTime>=@WriteTime1 ");
				list.Add(new SqlParameter("@WriteTime1", date1));
			}
			if (date2.IsDateTime())
			{
				stringBuilder.Append("AND WriteTime<=@WriteTime2 ");
				list.Add(new SqlParameter("@WriteTime2", date2.ToDateTime().ToString("yyyy-MM-dd 23:59:59")));
			}
			string paerSql = dbHelper.GetPaerSql("WorkFlowArchives", "ID,FlowName,StepName,Title,WriteTime", stringBuilder.ToString(), order.IsNullOrEmpty() ? "WriteTime DESC" : order, pageSize, pageNumber, out count, list.ToArray());
			return dbHelper.GetDataTable(paerSql, list.ToArray());
		}
	}
}
