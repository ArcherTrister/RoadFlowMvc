using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace RoadFlow.Data.ORACLE
{
	public class WorkCalendar : IWorkCalendar
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.WorkCalendar model)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Expected O, but got Unknown
			//IL_002c: Expected O, but got Unknown
			string sql = "INSERT INTO WorkCalendar\r\n\t\t\t\t(WorkDate) \r\n\t\t\t\tVALUES(:WorkDate)";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter("@WorkDate", 106);
			((DbParameter)val).Value = model.WorkDate;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.WorkCalendar model)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Expected O, but got Unknown
			//IL_002c: Expected O, but got Unknown
			string sql = "UPDATE WorkCalendar SET \r\n\t\t\t\tWHERE WorkDate=:WorkDate";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter("@WorkDate", 106);
			((DbParameter)val).Value = model.WorkDate;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Delete(DateTime workdate)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "DELETE FROM WorkCalendar WHERE WorkDate=@WorkDate";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter("@WorkDate", 106);
			((DbParameter)val).Value = workdate;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.WorkCalendar> DataReaderToList(OracleDataReader dataReader)
		{
			List<RoadFlow.Data.Model.WorkCalendar> list = new List<RoadFlow.Data.Model.WorkCalendar>();
			RoadFlow.Data.Model.WorkCalendar workCalendar = null;
			while (((DbDataReader)dataReader).Read())
			{
				workCalendar = new RoadFlow.Data.Model.WorkCalendar();
				workCalendar.WorkDate = ((DbDataReader)dataReader).GetDateTime(0);
				list.Add(workCalendar);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.WorkCalendar> GetAll()
		{
			string sql = "SELECT * FROM WorkCalendar";
			OracleDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.WorkCalendar> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
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
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "SELECT * FROM WorkCalendar WHERE WorkDate=:WorkDate";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":WorkDate", 106);
			((DbParameter)val).Value = workdate;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.WorkCalendar> list = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public int Delete(int year)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "DELETE FROM WorkCalendar WHERE to_char(WorkDate,'yyyy')=:WorkDate";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter("@WorkDate", 126);
			((DbParameter)val).Value = year;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public List<RoadFlow.Data.Model.WorkCalendar> GetAll(int year)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "SELECT * FROM WorkCalendar WHERE to_char(WorkDate,'yyyy')=:WorkDate";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":WorkDate", 126);
			((DbParameter)val).Value = year;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.WorkCalendar> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}
	}
}
