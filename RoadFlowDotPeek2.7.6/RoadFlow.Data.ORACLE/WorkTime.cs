// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.ORACLE.WorkTime
// Assembly: RoadFlow.Data.ORACLE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C9018AA1-E48E-4231-92A9-CD6F0F275D11
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.ORACLE.dll

using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;
using System.Data;

namespace RoadFlow.Data.ORACLE
{
  public class WorkTime : IWorkTime
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.WorkTime model)
    {
      string sql = "INSERT INTO WorkTime\r\n\t\t\t\t(ID,Year,Date1,Date2,AmTime1,AmTime2,PmTime1,PmTime2) \r\n\t\t\t\tVALUES(:ID,:Year,:Date1,:Date2,:AmTime1,:AmTime2,:PmTime1,:PmTime2)";
      OracleParameter[] oracleParameterArray = new OracleParameter[8];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":ID", OracleDbType.Varchar2, 50);
      oracleParameter1.Value = (object) model.ID;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":Year", OracleDbType.Int32);
      oracleParameter2.Value = (object) model.Year;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3 = new OracleParameter(":Date1", OracleDbType.Date);
      oracleParameter3.Value = (object) model.Date1;
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter4 = new OracleParameter(":Date2", OracleDbType.Date);
      oracleParameter4.Value = (object) model.Date2;
      oracleParameterArray[index4] = oracleParameter4;
      int index5 = 4;
      OracleParameter oracleParameter5 = new OracleParameter(":AmTime1", OracleDbType.Varchar2, 50);
      oracleParameter5.Value = (object) model.AmTime1;
      oracleParameterArray[index5] = oracleParameter5;
      int index6 = 5;
      OracleParameter oracleParameter6 = new OracleParameter(":AmTime2", OracleDbType.Varchar2, 50);
      oracleParameter6.Value = (object) model.AmTime2;
      oracleParameterArray[index6] = oracleParameter6;
      int index7 = 6;
      OracleParameter oracleParameter7 = new OracleParameter(":PmTime1", OracleDbType.Varchar2, 50);
      oracleParameter7.Value = (object) model.PmTime1;
      oracleParameterArray[index7] = oracleParameter7;
      int index8 = 7;
      OracleParameter oracleParameter8 = new OracleParameter(":PmTime2", OracleDbType.Varchar2, 50);
      oracleParameter8.Value = (object) model.PmTime2;
      oracleParameterArray[index8] = oracleParameter8;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Update(RoadFlow.Data.Model.WorkTime model)
    {
      string sql = "UPDATE WorkTime SET \r\n\t\t\t\tYear=:Year,Date1=:Date1,Date2=:Date2,AmTime1=:AmTime1,AmTime2=:AmTime2,PmTime1=:PmTime1,PmTime2=:PmTime2\r\n\t\t\t\tWHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[8];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":Year", OracleDbType.Varchar2, 50);
      oracleParameter1.Value = (object) model.Year;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":Date1", OracleDbType.Date);
      oracleParameter2.Value = (object) model.Date1;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3 = new OracleParameter(":Date2", OracleDbType.Date);
      oracleParameter3.Value = (object) model.Date2;
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter4 = new OracleParameter(":AmTime1", OracleDbType.Varchar2, 50);
      oracleParameter4.Value = (object) model.AmTime1;
      oracleParameterArray[index4] = oracleParameter4;
      int index5 = 4;
      OracleParameter oracleParameter5 = new OracleParameter(":AmTime2", OracleDbType.Varchar2, 50);
      oracleParameter5.Value = (object) model.AmTime2;
      oracleParameterArray[index5] = oracleParameter5;
      int index6 = 5;
      OracleParameter oracleParameter6 = new OracleParameter(":PmTime1", OracleDbType.Varchar2, 50);
      oracleParameter6.Value = (object) model.PmTime1;
      oracleParameterArray[index6] = oracleParameter6;
      int index7 = 6;
      OracleParameter oracleParameter7 = new OracleParameter(":PmTime2", OracleDbType.Varchar2, 50);
      oracleParameter7.Value = (object) model.PmTime2;
      oracleParameterArray[index7] = oracleParameter7;
      int index8 = 7;
      OracleParameter oracleParameter8 = new OracleParameter(":ID", OracleDbType.Varchar2, 50);
      oracleParameter8.Value = (object) model.ID;
      oracleParameterArray[index8] = oracleParameter8;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM WorkTime WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    private List<RoadFlow.Data.Model.WorkTime> DataReaderToList(OracleDataReader dataReader)
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
      OracleDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM WorkTime");
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
      string sql = "SELECT * FROM WorkTime WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
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
      OracleDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM WorkTime WHERE Year=" + (object) year);
      List<RoadFlow.Data.Model.WorkTime> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }
  }
}
