using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RoadFlow.Data.MSSQL
{
	public class WorkFlowData : IWorkFlowData
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.WorkFlowData model)
		{
			string sql = "INSERT INTO WorkFlowData\r\n\t\t\t\t(ID,InstanceID,LinkID,TableName,FieldName,Value) \r\n\t\t\t\tVALUES(@ID,@InstanceID,@LinkID,@TableName,@FieldName,@Value)";
			SqlParameter[] parameter = new SqlParameter[6]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ID
				},
				new SqlParameter("@InstanceID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.InstanceID
				},
				new SqlParameter("@LinkID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.LinkID
				},
				new SqlParameter("@TableName", SqlDbType.VarChar, 500)
				{
					Value = model.TableName
				},
				new SqlParameter("@FieldName", SqlDbType.VarChar, 500)
				{
					Value = model.FieldName
				},
				new SqlParameter("@Value", SqlDbType.VarChar, 8000)
				{
					Value = model.Value
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.WorkFlowData model)
		{
			string sql = "UPDATE WorkFlowData SET \r\n\t\t\t\tInstanceID=@InstanceID,LinkID=@LinkID,TableName=@TableName,FieldName=@FieldName,Value=@Value\r\n\t\t\t\tWHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[6]
			{
				new SqlParameter("@InstanceID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.InstanceID
				},
				new SqlParameter("@LinkID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.LinkID
				},
				new SqlParameter("@TableName", SqlDbType.VarChar, 500)
				{
					Value = model.TableName
				},
				new SqlParameter("@FieldName", SqlDbType.VarChar, 500)
				{
					Value = model.FieldName
				},
				new SqlParameter("@Value", SqlDbType.VarChar, 8000)
				{
					Value = model.Value
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
			string sql = "DELETE FROM WorkFlowData WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.WorkFlowData> DataReaderToList(SqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.WorkFlowData> list = new List<RoadFlow.Data.Model.WorkFlowData>();
			RoadFlow.Data.Model.WorkFlowData workFlowData = null;
			while (dataReader.Read())
			{
				workFlowData = new RoadFlow.Data.Model.WorkFlowData();
				workFlowData.ID = dataReader.GetGuid(0);
				workFlowData.InstanceID = dataReader.GetGuid(1);
				workFlowData.LinkID = dataReader.GetGuid(2);
				workFlowData.TableName = dataReader.GetString(3);
				workFlowData.FieldName = dataReader.GetString(4);
				workFlowData.Value = dataReader.GetString(5);
				list.Add(workFlowData);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.WorkFlowData> GetAll()
		{
			string sql = "SELECT * FROM WorkFlowData";
			SqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.WorkFlowData> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM WorkFlowData";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.WorkFlowData Get(Guid id)
		{
			string sql = "SELECT * FROM WorkFlowData WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.WorkFlowData> list = DataReaderToList(dataReader);
			dataReader.Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public List<RoadFlow.Data.Model.WorkFlowData> GetAll(Guid instanceID)
		{
			string sql = "SELECT * FROM WorkFlowData WHERE InstanceID=@InstanceID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@InstanceID", SqlDbType.UniqueIdentifier)
				{
					Value = instanceID
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.WorkFlowData> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}
	}
}
