using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RoadFlow.Data.MSSQL
{
	public class WorkCalendar : IWorkCalendar
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.WorkCalendar model)
		{
			string sql = "INSERT INTO WorkCalendar\r\n\t\t\t\t(WorkDate) \r\n\t\t\t\tVALUES(@WorkDate)";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@WorkDate", SqlDbType.Date, -1)
				{
					Value = model.WorkDate
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.WorkCalendar model)
		{
			string sql = "UPDATE WorkCalendar SET \r\n\t\t\t\t\r\n\t\t\t\tWHERE WorkDate=@WorkDate";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@WorkDate", SqlDbType.Date, -1)
				{
					Value = model.WorkDate
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public int Delete(DateTime workdate)
		{
			string sql = "DELETE FROM WorkCalendar WHERE WorkDate=@WorkDate";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@WorkDate", SqlDbType.Date)
				{
					Value = workdate
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.WorkCalendar> DataReaderToList(SqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.WorkCalendar> list = new List<RoadFlow.Data.Model.WorkCalendar>();
			RoadFlow.Data.Model.WorkCalendar workCalendar = null;
			while (dataReader.Read())
			{
				workCalendar = new RoadFlow.Data.Model.WorkCalendar();
				workCalendar.WorkDate = dataReader.GetDateTime(0);
				list.Add(workCalendar);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.WorkCalendar> GetAll()
		{
			string sql = "SELECT * FROM WorkCalendar";
			SqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.WorkCalendar> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM WorkCalendar";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.WorkCalendar Get(DateTime workdate)
		{
			string sql = "SELECT * FROM WorkCalendar WHERE WorkDate=@WorkDate";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@WorkDate", SqlDbType.Date)
				{
					Value = workdate
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.WorkCalendar> list = DataReaderToList(dataReader);
			dataReader.Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public int Delete(int year)
		{
			string sql = "DELETE FROM WorkCalendar WHERE YEAR(WorkDate)=@WorkDate";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@WorkDate", SqlDbType.Int)
				{
					Value = year
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public List<RoadFlow.Data.Model.WorkCalendar> GetAll(int year)
		{
			string sql = "SELECT * FROM WorkCalendar WHERE YEAR(WorkDate)=@WorkDate";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@WorkDate", SqlDbType.Int)
				{
					Value = year
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.WorkCalendar> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}
	}
}
