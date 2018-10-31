// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MSSQL.WorkTime
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
  public class WorkTime : IWorkTime
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.WorkTime model)
    {
      string sql = "INSERT INTO WorkTime\r\n\t\t\t\t(ID,Year,Date1,Date2,AmTime1,AmTime2,PmTime1,PmTime2) \r\n\t\t\t\tVALUES(@ID,@Year,@Date1,@Date2,@AmTime1,@AmTime2,@PmTime1,@PmTime2)";
      SqlParameter[] sqlParameterArray = new SqlParameter[8];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter1.Value = (object) model.ID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@Year", SqlDbType.Int, -1);
      sqlParameter2.Value = (object) model.Year;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@Date1", SqlDbType.DateTime, 8);
      sqlParameter3.Value = (object) model.Date1;
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter4 = new SqlParameter("@Date2", SqlDbType.DateTime, 8);
      sqlParameter4.Value = (object) model.Date2;
      sqlParameterArray[index4] = sqlParameter4;
      int index5 = 4;
      SqlParameter sqlParameter5 = new SqlParameter("@AmTime1", SqlDbType.VarChar, 50);
      sqlParameter5.Value = (object) model.AmTime1;
      sqlParameterArray[index5] = sqlParameter5;
      int index6 = 5;
      SqlParameter sqlParameter6 = new SqlParameter("@AmTime2", SqlDbType.VarChar, 50);
      sqlParameter6.Value = (object) model.AmTime2;
      sqlParameterArray[index6] = sqlParameter6;
      int index7 = 6;
      SqlParameter sqlParameter7 = new SqlParameter("@PmTime1", SqlDbType.VarChar, 50);
      sqlParameter7.Value = (object) model.PmTime1;
      sqlParameterArray[index7] = sqlParameter7;
      int index8 = 7;
      SqlParameter sqlParameter8 = new SqlParameter("@PmTime2", SqlDbType.VarChar, 50);
      sqlParameter8.Value = (object) model.PmTime2;
      sqlParameterArray[index8] = sqlParameter8;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.WorkTime model)
    {
      string sql = "UPDATE WorkTime SET \r\n\t\t\t\tYear=@Year,Date1=@Date1,Date2=@Date2,AmTime1=@AmTime1,AmTime2=@AmTime2,PmTime1=@PmTime1,PmTime2=@PmTime2\r\n\t\t\t\tWHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[8];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@Year", SqlDbType.Int, -1);
      sqlParameter1.Value = (object) model.Year;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@Date1", SqlDbType.DateTime, 8);
      sqlParameter2.Value = (object) model.Date1;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@Date2", SqlDbType.DateTime, 8);
      sqlParameter3.Value = (object) model.Date2;
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter4 = new SqlParameter("@AmTime1", SqlDbType.VarChar, 50);
      sqlParameter4.Value = (object) model.AmTime1;
      sqlParameterArray[index4] = sqlParameter4;
      int index5 = 4;
      SqlParameter sqlParameter5 = new SqlParameter("@AmTime2", SqlDbType.VarChar, 50);
      sqlParameter5.Value = (object) model.AmTime2;
      sqlParameterArray[index5] = sqlParameter5;
      int index6 = 5;
      SqlParameter sqlParameter6 = new SqlParameter("@PmTime1", SqlDbType.VarChar, 50);
      sqlParameter6.Value = (object) model.PmTime1;
      sqlParameterArray[index6] = sqlParameter6;
      int index7 = 6;
      SqlParameter sqlParameter7 = new SqlParameter("@PmTime2", SqlDbType.VarChar, 50);
      sqlParameter7.Value = (object) model.PmTime2;
      sqlParameterArray[index7] = sqlParameter7;
      int index8 = 7;
      SqlParameter sqlParameter8 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter8.Value = (object) model.ID;
      sqlParameterArray[index8] = sqlParameter8;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM WorkTime WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.WorkTime> DataReaderToList(SqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.WorkTime> workTimeList = new List<RoadFlow.Data.Model.WorkTime>();
      while (dataReader.Read())
        workTimeList.Add(new RoadFlow.Data.Model.WorkTime()
        {
          ID = dataReader.GetGuid(0),
          Year = dataReader.GetInt32(1),
          Date1 = dataReader.GetDateTime(2),
          Date2 = dataReader.GetDateTime(3),
          AmTime1 = dataReader.GetString(4),
          AmTime2 = dataReader.GetString(5),
          PmTime1 = dataReader.GetString(6),
          PmTime2 = dataReader.GetString(7)
        });
      return workTimeList;
    }

    public List<RoadFlow.Data.Model.WorkTime> GetAll()
    {
      SqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM WorkTime");
      List<RoadFlow.Data.Model.WorkTime> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM WorkTime"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.WorkTime Get(Guid id)
    {
      string sql = "SELECT * FROM WorkTime WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkTime> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.WorkTime) null;
      return list[0];
    }

    public List<int> GetAllYear()
    {
      DataTable dataTable = this.dbHelper.GetDataTable("SELECT DISTINCT Year FROM WorkTime");
      List<int> intList = new List<int>();
      foreach (DataRow row in (InternalDataCollectionBase) dataTable.Rows)
        intList.Add(row[0].ToString().ToInt());
      return intList;
    }

    public List<RoadFlow.Data.Model.WorkTime> GetAll(int year)
    {
      SqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM WorkTime WHERE Year=" + (object) year);
      List<RoadFlow.Data.Model.WorkTime> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }
  }
}
