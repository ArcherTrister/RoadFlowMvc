// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.ORACLE.WorkCalendar
// Assembly: RoadFlow.Data.ORACLE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C9018AA1-E48E-4231-92A9-CD6F0F275D11
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.ORACLE.dll

using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.ORACLE
{
  public class WorkCalendar : IWorkCalendar
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.WorkCalendar model)
    {
      string sql = "INSERT INTO WorkCalendar\r\n\t\t\t\t(WorkDate) \r\n\t\t\t\tVALUES(:WorkDate)";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter("@WorkDate", OracleDbType.Date);
      oracleParameter.Value = (object) model.WorkDate;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Update(RoadFlow.Data.Model.WorkCalendar model)
    {
      string sql = "UPDATE WorkCalendar SET \r\n\t\t\t\tWHERE WorkDate=:WorkDate";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter("@WorkDate", OracleDbType.Date);
      oracleParameter.Value = (object) model.WorkDate;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Delete(DateTime workdate)
    {
      string sql = "DELETE FROM WorkCalendar WHERE WorkDate=@WorkDate";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter("@WorkDate", OracleDbType.Date);
      oracleParameter.Value = (object) workdate;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    private List<RoadFlow.Data.Model.WorkCalendar> DataReaderToList(OracleDataReader dataReader)
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
      OracleDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM WorkCalendar");
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
      string sql = "SELECT * FROM WorkCalendar WHERE WorkDate=:WorkDate";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":WorkDate", OracleDbType.Date);
      oracleParameter.Value = (object) workdate;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkCalendar> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.WorkCalendar) null;
      return list[0];
    }

    public int Delete(int year)
    {
      string sql = "DELETE FROM WorkCalendar WHERE to_char(WorkDate,'yyyy')=:WorkDate";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter("@WorkDate", OracleDbType.Varchar2);
      oracleParameter.Value = (object) year;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public List<RoadFlow.Data.Model.WorkCalendar> GetAll(int year)
    {
      string sql = "SELECT * FROM WorkCalendar WHERE to_char(WorkDate,'yyyy')=:WorkDate";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":WorkDate", OracleDbType.Varchar2);
      oracleParameter.Value = (object) year;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkCalendar> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }
  }
}
