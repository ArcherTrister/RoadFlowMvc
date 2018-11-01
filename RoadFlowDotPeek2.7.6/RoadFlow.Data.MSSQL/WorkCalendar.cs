// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MSSQL.WorkCalendar
// Assembly: RoadFlow.Data.MSSQL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5107CDC7-8F84-4EE0-AC6D-E80FE4695340
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.MSSQL.dll

using RoadFlow.Data.Interface;
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
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@WorkDate", SqlDbType.Date, -1);
      sqlParameter.Value = (object) model.WorkDate;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.WorkCalendar model)
    {
      string sql = "UPDATE WorkCalendar SET \r\n\t\t\t\t\r\n\t\t\t\tWHERE WorkDate=@WorkDate";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@WorkDate", SqlDbType.Date, -1);
      sqlParameter.Value = (object) model.WorkDate;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(DateTime workdate)
    {
      string sql = "DELETE FROM WorkCalendar WHERE WorkDate=@WorkDate";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@WorkDate", SqlDbType.Date);
      sqlParameter.Value = (object) workdate;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.WorkCalendar> DataReaderToList(SqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.WorkCalendar> workCalendarList = new List<RoadFlow.Data.Model.WorkCalendar>();
      while (dataReader.Read())
        workCalendarList.Add(new RoadFlow.Data.Model.WorkCalendar()
        {
          WorkDate = dataReader.GetDateTime(0)
        });
      return workCalendarList;
    }

    public List<RoadFlow.Data.Model.WorkCalendar> GetAll()
    {
      SqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM WorkCalendar");
      List<RoadFlow.Data.Model.WorkCalendar> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM WorkCalendar"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.WorkCalendar Get(DateTime workdate)
    {
      string sql = "SELECT * FROM WorkCalendar WHERE WorkDate=@WorkDate";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@WorkDate", SqlDbType.Date);
      sqlParameter.Value = (object) workdate;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkCalendar> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.WorkCalendar) null;
      return list[0];
    }

    public int Delete(int year)
    {
      string sql = "DELETE FROM WorkCalendar WHERE YEAR(WorkDate)=@WorkDate";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@WorkDate", SqlDbType.Int);
      sqlParameter.Value = (object) year;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public List<RoadFlow.Data.Model.WorkCalendar> GetAll(int year)
    {
      string sql = "SELECT * FROM WorkCalendar WHERE YEAR(WorkDate)=@WorkDate";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@WorkDate", SqlDbType.Int);
      sqlParameter.Value = (object) year;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkCalendar> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }
  }
}
