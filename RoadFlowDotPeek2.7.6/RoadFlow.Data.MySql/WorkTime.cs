// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MySql.WorkTime
// Assembly: RoadFlow.Data.MySql, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 29B652D7-5F6F-4A7D-AD1C-9F2C643FD784
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.MySql.dll

using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;
using System.Data;

namespace RoadFlow.Data.MySql
{
  public class WorkTime : IWorkTime
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.WorkTime model)
    {
      string sql = "INSERT INTO WorkTime\r\n\t\t\t\t(ID,Year,Date1,Date2,AmTime1,AmTime2,PmTime1,PmTime2) \r\n\t\t\t\tVALUES(@ID,@Year,@Date1,@Date2,@AmTime1,@AmTime2,@PmTime1,@PmTime2)";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[8];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@ID", MySqlDbType.VarChar, 50);
      mySqlParameter1.Value = (object) model.ID;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@Year", MySqlDbType.Int32);
      mySqlParameter2.Value = (object) model.Year;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@Date1", MySqlDbType.DateTime);
      mySqlParameter3.Value = (object) model.Date1;
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter4 = new MySqlParameter("@Date2", MySqlDbType.DateTime);
      mySqlParameter4.Value = (object) model.Date2;
      mySqlParameterArray[index4] = mySqlParameter4;
      int index5 = 4;
      MySqlParameter mySqlParameter5 = new MySqlParameter("@AmTime1", MySqlDbType.VarChar, 50);
      mySqlParameter5.Value = (object) model.AmTime1;
      mySqlParameterArray[index5] = mySqlParameter5;
      int index6 = 5;
      MySqlParameter mySqlParameter6 = new MySqlParameter("@AmTime2", MySqlDbType.VarChar, 50);
      mySqlParameter6.Value = (object) model.AmTime2;
      mySqlParameterArray[index6] = mySqlParameter6;
      int index7 = 6;
      MySqlParameter mySqlParameter7 = new MySqlParameter("@PmTime1", MySqlDbType.VarChar, 50);
      mySqlParameter7.Value = (object) model.PmTime1;
      mySqlParameterArray[index7] = mySqlParameter7;
      int index8 = 7;
      MySqlParameter mySqlParameter8 = new MySqlParameter("@PmTime2", MySqlDbType.VarChar, 50);
      mySqlParameter8.Value = (object) model.PmTime2;
      mySqlParameterArray[index8] = mySqlParameter8;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.WorkTime model)
    {
      string sql = "UPDATE WorkTime SET \r\n\t\t\t\tYear=@Year,Date1=@Date1,Date2=@Date2,AmTime1=@AmTime1,AmTime2=@AmTime2,PmTime1=@PmTime1,PmTime2=@PmTime2\r\n\t\t\t\tWHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[8];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@Year", MySqlDbType.Int32);
      mySqlParameter1.Value = (object) model.Year;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@Date1", MySqlDbType.DateTime);
      mySqlParameter2.Value = (object) model.Date1;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@Date2", MySqlDbType.DateTime);
      mySqlParameter3.Value = (object) model.Date2;
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter4 = new MySqlParameter("@AmTime1", MySqlDbType.VarChar, 50);
      mySqlParameter4.Value = (object) model.AmTime1;
      mySqlParameterArray[index4] = mySqlParameter4;
      int index5 = 4;
      MySqlParameter mySqlParameter5 = new MySqlParameter("@AmTime2", MySqlDbType.VarChar, 50);
      mySqlParameter5.Value = (object) model.AmTime2;
      mySqlParameterArray[index5] = mySqlParameter5;
      int index6 = 5;
      MySqlParameter mySqlParameter6 = new MySqlParameter("@PmTime1", MySqlDbType.VarChar, 50);
      mySqlParameter6.Value = (object) model.PmTime1;
      mySqlParameterArray[index6] = mySqlParameter6;
      int index7 = 6;
      MySqlParameter mySqlParameter7 = new MySqlParameter("@PmTime2", MySqlDbType.VarChar, 50);
      mySqlParameter7.Value = (object) model.PmTime2;
      mySqlParameterArray[index7] = mySqlParameter7;
      int index8 = 7;
      MySqlParameter mySqlParameter8 = new MySqlParameter("@ID", MySqlDbType.VarChar, 50);
      mySqlParameter8.Value = (object) model.ID;
      mySqlParameterArray[index8] = mySqlParameter8;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM WorkTime WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) id;
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.WorkTime> DataReaderToList(MySqlDataReader dataReader)
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
      MySqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM WorkTime");
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
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) id;
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
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
      MySqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM WorkTime WHERE Year=" + (object) year);
      List<RoadFlow.Data.Model.WorkTime> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }
  }
}
