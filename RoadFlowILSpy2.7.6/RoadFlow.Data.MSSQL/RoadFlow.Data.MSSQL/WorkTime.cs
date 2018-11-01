using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RoadFlow.Data.MSSQL
{
	public class WorkTime : IWorkTime
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.WorkTime model)
		{
			string sql = "INSERT INTO WorkTime\r\n\t\t\t\t(ID,Year,Date1,Date2,AmTime1,AmTime2,PmTime1,PmTime2) \r\n\t\t\t\tVALUES(@ID,@Year,@Date1,@Date2,@AmTime1,@AmTime2,@PmTime1,@PmTime2)";
			SqlParameter[] parameter = new SqlParameter[8]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ID
				},
				new SqlParameter("@Year", SqlDbType.Int, -1)
				{
					Value = model.Year
				},
				new SqlParameter("@Date1", SqlDbType.DateTime, 8)
				{
					Value = model.Date1
				},
				new SqlParameter("@Date2", SqlDbType.DateTime, 8)
				{
					Value = model.Date2
				},
				new SqlParameter("@AmTime1", SqlDbType.VarChar, 50)
				{
					Value = model.AmTime1
				},
				new SqlParameter("@AmTime2", SqlDbType.VarChar, 50)
				{
					Value = model.AmTime2
				},
				new SqlParameter("@PmTime1", SqlDbType.VarChar, 50)
				{
					Value = model.PmTime1
				},
				new SqlParameter("@PmTime2", SqlDbType.VarChar, 50)
				{
					Value = model.PmTime2
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.WorkTime model)
		{
			string sql = "UPDATE WorkTime SET \r\n\t\t\t\tYear=@Year,Date1=@Date1,Date2=@Date2,AmTime1=@AmTime1,AmTime2=@AmTime2,PmTime1=@PmTime1,PmTime2=@PmTime2\r\n\t\t\t\tWHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[8]
			{
				new SqlParameter("@Year", SqlDbType.Int, -1)
				{
					Value = model.Year
				},
				new SqlParameter("@Date1", SqlDbType.DateTime, 8)
				{
					Value = model.Date1
				},
				new SqlParameter("@Date2", SqlDbType.DateTime, 8)
				{
					Value = model.Date2
				},
				new SqlParameter("@AmTime1", SqlDbType.VarChar, 50)
				{
					Value = model.AmTime1
				},
				new SqlParameter("@AmTime2", SqlDbType.VarChar, 50)
				{
					Value = model.AmTime2
				},
				new SqlParameter("@PmTime1", SqlDbType.VarChar, 50)
				{
					Value = model.PmTime1
				},
				new SqlParameter("@PmTime2", SqlDbType.VarChar, 50)
				{
					Value = model.PmTime2
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
			string sql = "DELETE FROM WorkTime WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.WorkTime> DataReaderToList(SqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.WorkTime> list = new List<RoadFlow.Data.Model.WorkTime>();
			RoadFlow.Data.Model.WorkTime workTime = null;
			while (dataReader.Read())
			{
				workTime = new RoadFlow.Data.Model.WorkTime();
				workTime.ID = dataReader.GetGuid(0);
				workTime.Year = dataReader.GetInt32(1);
				workTime.Date1 = dataReader.GetDateTime(2);
				workTime.Date2 = dataReader.GetDateTime(3);
				workTime.AmTime1 = dataReader.GetString(4);
				workTime.AmTime2 = dataReader.GetString(5);
				workTime.PmTime1 = dataReader.GetString(6);
				workTime.PmTime2 = dataReader.GetString(7);
				list.Add(workTime);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.WorkTime> GetAll()
		{
			string sql = "SELECT * FROM WorkTime";
			SqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.WorkTime> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM WorkTime";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.WorkTime Get(Guid id)
		{
			string sql = "SELECT * FROM WorkTime WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.WorkTime> list = DataReaderToList(dataReader);
			dataReader.Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public List<int> GetAllYear()
		{
			string sql = "SELECT DISTINCT Year FROM WorkTime";
			DataTable dataTable = dbHelper.GetDataTable(sql);
			List<int> list = new List<int>();
			foreach (DataRow row in dataTable.Rows)
			{
				list.Add(row[0].ToString().ToInt());
			}
			return list;
		}

		public List<RoadFlow.Data.Model.WorkTime> GetAll(int year)
		{
			string sql = "SELECT * FROM WorkTime WHERE Year=" + year;
			SqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.WorkTime> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}
	}
}
