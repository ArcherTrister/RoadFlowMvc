// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MySql.WorkCalendar
// Assembly: RoadFlow.Data.MySql, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 29B652D7-5F6F-4A7D-AD1C-9F2C643FD784
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.MySql.dll

using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.MySql
{
  public class WorkCalendar : IWorkCalendar
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.WorkCalendar model)
    {
      string sql = "INSERT INTO workcalendar\r\n\t\t\t\t(WorkDate) \r\n\t\t\t\tVALUES(@WorkDate)";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@WorkDate", MySqlDbType.Date, -1);
      mySqlParameter.Value = (object) model.WorkDate;
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.WorkCalendar model)
    {
      string sql = "UPDATE workcalendar SET \r\n\t\t\t\t\r\n\t\t\t\tWHERE WorkDate=@WorkDate";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@WorkDate", MySqlDbType.Date, -1);
      mySqlParameter.Value = (object) model.WorkDate;
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(DateTime workdate)
    {
      string sql = "DELETE FROM workcalendar WHERE WorkDate=@WorkDate";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@WorkDate", MySqlDbType.Date);
      mySqlParameter.Value = (object) workdate;
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.WorkCalendar> DataReaderToList(MySqlDataReader dataReader)
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
      MySqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM workcalendar");
      List<RoadFlow.Data.Model.WorkCalendar> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM workcalendar"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.WorkCalendar Get(DateTime workdate)
    {
      string sql = "SELECT * FROM workcalendar WHERE WorkDate=@WorkDate";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@WorkDate", MySqlDbType.Date);
      mySqlParameter.Value = (object) workdate;
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkCalendar> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.WorkCalendar) null;
      return list[0];
    }

    public int Delete(int year)
    {
      string sql = "DELETE FROM WorkCalendar WHERE YEAR(WorkDate)=@WorkDate";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@WorkDate", MySqlDbType.Int32);
      mySqlParameter.Value = (object) year;
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public List<RoadFlow.Data.Model.WorkCalendar> GetAll(int year)
    {
      string sql = "SELECT * FROM WorkCalendar WHERE YEAR(WorkDate)=@WorkDate";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@WorkDate", MySqlDbType.Int32);
      mySqlParameter.Value = (object) year;
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkCalendar> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }
  }
}
