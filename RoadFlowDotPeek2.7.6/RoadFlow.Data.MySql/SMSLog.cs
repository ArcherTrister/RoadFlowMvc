// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MySql.SMSLog
// Assembly: RoadFlow.Data.MySql, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 29B652D7-5F6F-4A7D-AD1C-9F2C643FD784
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.MySql.dll

using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.MySql
{
  public class SMSLog : ISMSLog
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.SMSLog model)
    {
      string sql = "INSERT INTO smslog\r\n\t\t\t\t(ID,MobileNumber,Contents,SendUserID,SendUserName,SendTime,Status,Note) \r\n\t\t\t\tVALUES(@ID,@MobileNumber,@Contents,@SendUserID,@SendUserName,@SendTime,@Status,@Note)";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[8];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter1.Value = (object) model.ID;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@MobileNumber", MySqlDbType.LongText, -1);
      mySqlParameter2.Value = (object) model.MobileNumber;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@Contents", MySqlDbType.VarChar, 200);
      mySqlParameter3.Value = (object) model.Contents;
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter4;
      if (model.SendUserID.HasValue)
      {
        MySqlParameter mySqlParameter5 = new MySqlParameter("@SendUserID", MySqlDbType.VarChar, 36);
        mySqlParameter5.Value = (object) model.SendUserID;
        mySqlParameter4 = mySqlParameter5;
      }
      else
      {
        mySqlParameter4 = new MySqlParameter("@SendUserID", MySqlDbType.VarChar, 36);
        mySqlParameter4.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index4] = mySqlParameter4;
      int index5 = 4;
      MySqlParameter mySqlParameter6;
      if (model.SendUserName != null)
      {
        MySqlParameter mySqlParameter5 = new MySqlParameter("@SendUserName", MySqlDbType.Text, -1);
        mySqlParameter5.Value = (object) model.SendUserName;
        mySqlParameter6 = mySqlParameter5;
      }
      else
      {
        mySqlParameter6 = new MySqlParameter("@SendUserName", MySqlDbType.Text, -1);
        mySqlParameter6.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index5] = mySqlParameter6;
      int index6 = 5;
      MySqlParameter mySqlParameter7 = new MySqlParameter("@SendTime", MySqlDbType.DateTime, -1);
      mySqlParameter7.Value = (object) model.SendTime;
      mySqlParameterArray[index6] = mySqlParameter7;
      int index7 = 6;
      MySqlParameter mySqlParameter8 = new MySqlParameter("@Status", MySqlDbType.Int32, 11);
      mySqlParameter8.Value = (object) model.Status;
      mySqlParameterArray[index7] = mySqlParameter8;
      int index8 = 7;
      MySqlParameter mySqlParameter9;
      if (model.Note != null)
      {
        MySqlParameter mySqlParameter5 = new MySqlParameter("@Note", MySqlDbType.LongText, -1);
        mySqlParameter5.Value = (object) model.Note;
        mySqlParameter9 = mySqlParameter5;
      }
      else
      {
        mySqlParameter9 = new MySqlParameter("@Note", MySqlDbType.LongText, -1);
        mySqlParameter9.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index8] = mySqlParameter9;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.SMSLog model)
    {
      string sql = "UPDATE smslog SET \r\n\t\t\t\tMobileNumber=@MobileNumber,Contents=@Contents,SendUserID=@SendUserID,SendUserName=@SendUserName,SendTime=@SendTime,Status=@Status,Note=@Note\r\n\t\t\t\tWHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[8];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@MobileNumber", MySqlDbType.LongText, -1);
      mySqlParameter1.Value = (object) model.MobileNumber;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@Contents", MySqlDbType.VarChar, 200);
      mySqlParameter2.Value = (object) model.Contents;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3;
      if (model.SendUserID.HasValue)
      {
        MySqlParameter mySqlParameter4 = new MySqlParameter("@SendUserID", MySqlDbType.VarChar, 36);
        mySqlParameter4.Value = (object) model.SendUserID;
        mySqlParameter3 = mySqlParameter4;
      }
      else
      {
        mySqlParameter3 = new MySqlParameter("@SendUserID", MySqlDbType.VarChar, 36);
        mySqlParameter3.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter5;
      if (model.SendUserName != null)
      {
        MySqlParameter mySqlParameter4 = new MySqlParameter("@SendUserName", MySqlDbType.Text, -1);
        mySqlParameter4.Value = (object) model.SendUserName;
        mySqlParameter5 = mySqlParameter4;
      }
      else
      {
        mySqlParameter5 = new MySqlParameter("@SendUserName", MySqlDbType.Text, -1);
        mySqlParameter5.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index4] = mySqlParameter5;
      int index5 = 4;
      MySqlParameter mySqlParameter6 = new MySqlParameter("@SendTime", MySqlDbType.DateTime, -1);
      mySqlParameter6.Value = (object) model.SendTime;
      mySqlParameterArray[index5] = mySqlParameter6;
      int index6 = 5;
      MySqlParameter mySqlParameter7 = new MySqlParameter("@Status", MySqlDbType.Int32, 11);
      mySqlParameter7.Value = (object) model.Status;
      mySqlParameterArray[index6] = mySqlParameter7;
      int index7 = 6;
      MySqlParameter mySqlParameter8;
      if (model.Note != null)
      {
        MySqlParameter mySqlParameter4 = new MySqlParameter("@Note", MySqlDbType.LongText, -1);
        mySqlParameter4.Value = (object) model.Note;
        mySqlParameter8 = mySqlParameter4;
      }
      else
      {
        mySqlParameter8 = new MySqlParameter("@Note", MySqlDbType.LongText, -1);
        mySqlParameter8.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index7] = mySqlParameter8;
      int index8 = 7;
      MySqlParameter mySqlParameter9 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter9.Value = (object) model.ID;
      mySqlParameterArray[index8] = mySqlParameter9;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM smslog WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.SMSLog> DataReaderToList(MySqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.SMSLog> smsLogList = new List<RoadFlow.Data.Model.SMSLog>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.SMSLog smsLog = new RoadFlow.Data.Model.SMSLog();
        smsLog.ID = dataReader.GetString(0).ToGuid();
        smsLog.MobileNumber = dataReader.GetString(1);
        smsLog.Contents = dataReader.GetString(2);
        if (!dataReader.IsDBNull(3))
          smsLog.SendUserID = new Guid?(dataReader.GetString(3).ToGuid());
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
      MySqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM smslog");
      List<RoadFlow.Data.Model.SMSLog> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM smslog"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.SMSLog Get(Guid id)
    {
      string sql = "SELECT * FROM smslog WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.SMSLog> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.SMSLog) null;
      return list[0];
    }
  }
}
