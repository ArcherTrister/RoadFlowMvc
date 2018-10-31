// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MSSQL.SMSLog
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
  public class SMSLog : ISMSLog
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.SMSLog model)
    {
      string sql = "INSERT INTO SMSLog\r\n\t\t\t\t(ID,MobileNumber,Contents,SendUserID,SendUserName,SendTime,Status,Note) \r\n\t\t\t\tVALUES(@ID,@MobileNumber,@Contents,@SendUserID,@SendUserName,@SendTime,@Status,@Note)";
      SqlParameter[] sqlParameterArray = new SqlParameter[8];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter1.Value = (object) model.ID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@MobileNumber", SqlDbType.VarChar, -1);
      sqlParameter2.Value = (object) model.MobileNumber;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@Contents", SqlDbType.NVarChar, 400);
      sqlParameter3.Value = (object) model.Contents;
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter4;
      if (model.SendUserID.HasValue)
      {
        SqlParameter sqlParameter5 = new SqlParameter("@SendUserID", SqlDbType.UniqueIdentifier, -1);
        sqlParameter5.Value = (object) model.SendUserID;
        sqlParameter4 = sqlParameter5;
      }
      else
      {
        sqlParameter4 = new SqlParameter("@SendUserID", SqlDbType.UniqueIdentifier, -1);
        sqlParameter4.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index4] = sqlParameter4;
      int index5 = 4;
      SqlParameter sqlParameter6;
      if (model.SendUserName != null)
      {
        SqlParameter sqlParameter5 = new SqlParameter("@SendUserName", SqlDbType.NVarChar, 1000);
        sqlParameter5.Value = (object) model.SendUserName;
        sqlParameter6 = sqlParameter5;
      }
      else
      {
        sqlParameter6 = new SqlParameter("@SendUserName", SqlDbType.NVarChar, 1000);
        sqlParameter6.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index5] = sqlParameter6;
      int index6 = 5;
      SqlParameter sqlParameter7 = new SqlParameter("@SendTime", SqlDbType.DateTime, 8);
      sqlParameter7.Value = (object) model.SendTime;
      sqlParameterArray[index6] = sqlParameter7;
      int index7 = 6;
      SqlParameter sqlParameter8 = new SqlParameter("@Status", SqlDbType.Int, -1);
      sqlParameter8.Value = (object) model.Status;
      sqlParameterArray[index7] = sqlParameter8;
      int index8 = 7;
      SqlParameter sqlParameter9;
      if (model.Note != null)
      {
        SqlParameter sqlParameter5 = new SqlParameter("@Note", SqlDbType.VarChar, -1);
        sqlParameter5.Value = (object) model.Note;
        sqlParameter9 = sqlParameter5;
      }
      else
      {
        sqlParameter9 = new SqlParameter("@Note", SqlDbType.VarChar, -1);
        sqlParameter9.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index8] = sqlParameter9;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.SMSLog model)
    {
      string sql = "UPDATE SMSLog SET \r\n\t\t\t\tMobileNumber=@MobileNumber,Contents=@Contents,SendUserID=@SendUserID,SendUserName=@SendUserName,SendTime=@SendTime,Status=@Status,Note=@Note\r\n\t\t\t\tWHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[8];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@MobileNumber", SqlDbType.VarChar, -1);
      sqlParameter1.Value = (object) model.MobileNumber;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@Contents", SqlDbType.NVarChar, 400);
      sqlParameter2.Value = (object) model.Contents;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3;
      if (model.SendUserID.HasValue)
      {
        SqlParameter sqlParameter4 = new SqlParameter("@SendUserID", SqlDbType.UniqueIdentifier, -1);
        sqlParameter4.Value = (object) model.SendUserID;
        sqlParameter3 = sqlParameter4;
      }
      else
      {
        sqlParameter3 = new SqlParameter("@SendUserID", SqlDbType.UniqueIdentifier, -1);
        sqlParameter3.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter5;
      if (model.SendUserName != null)
      {
        SqlParameter sqlParameter4 = new SqlParameter("@SendUserName", SqlDbType.NVarChar, 1000);
        sqlParameter4.Value = (object) model.SendUserName;
        sqlParameter5 = sqlParameter4;
      }
      else
      {
        sqlParameter5 = new SqlParameter("@SendUserName", SqlDbType.NVarChar, 1000);
        sqlParameter5.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index4] = sqlParameter5;
      int index5 = 4;
      SqlParameter sqlParameter6 = new SqlParameter("@SendTime", SqlDbType.DateTime, 8);
      sqlParameter6.Value = (object) model.SendTime;
      sqlParameterArray[index5] = sqlParameter6;
      int index6 = 5;
      SqlParameter sqlParameter7 = new SqlParameter("@Status", SqlDbType.Int, -1);
      sqlParameter7.Value = (object) model.Status;
      sqlParameterArray[index6] = sqlParameter7;
      int index7 = 6;
      SqlParameter sqlParameter8;
      if (model.Note != null)
      {
        SqlParameter sqlParameter4 = new SqlParameter("@Note", SqlDbType.VarChar, -1);
        sqlParameter4.Value = (object) model.Note;
        sqlParameter8 = sqlParameter4;
      }
      else
      {
        sqlParameter8 = new SqlParameter("@Note", SqlDbType.VarChar, -1);
        sqlParameter8.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index7] = sqlParameter8;
      int index8 = 7;
      SqlParameter sqlParameter9 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter9.Value = (object) model.ID;
      sqlParameterArray[index8] = sqlParameter9;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM SMSLog WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.SMSLog> DataReaderToList(SqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.SMSLog> smsLogList = new List<RoadFlow.Data.Model.SMSLog>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.SMSLog smsLog = new RoadFlow.Data.Model.SMSLog();
        smsLog.ID = dataReader.GetGuid(0);
        smsLog.MobileNumber = dataReader.GetString(1);
        smsLog.Contents = dataReader.GetString(2);
        if (!dataReader.IsDBNull(3))
          smsLog.SendUserID = new Guid?(dataReader.GetGuid(3));
        if (!dataReader.IsDBNull(4))
          smsLog.SendUserName = dataReader.GetString(4);
        smsLog.SendTime = dataReader.GetDateTime(5);
        smsLog.Status = dataReader.GetInt32(6);
        if (!dataReader.IsDBNull(7))
          smsLog.Note = dataReader.GetString(7);
        smsLogList.Add(smsLog);
      }
      return smsLogList;
    }

    public List<RoadFlow.Data.Model.SMSLog> GetAll()
    {
      SqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM SMSLog");
      List<RoadFlow.Data.Model.SMSLog> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM SMSLog"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.SMSLog Get(Guid id)
    {
      string sql = "SELECT * FROM SMSLog WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.SMSLog> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.SMSLog) null;
      return list[0];
    }
  }
}
