// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.ORACLE.SMSLog
// Assembly: RoadFlow.Data.ORACLE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C9018AA1-E48E-4231-92A9-CD6F0F275D11
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.ORACLE.dll

using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.ORACLE
{
  public class SMSLog : ISMSLog
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.SMSLog model)
    {
      string sql = "INSERT INTO SMSLog\r\n\t\t\t\t(ID,MobileNumber,Contents,SendUserID,SendUserName,SendTime,Status,Note) \r\n\t\t\t\tVALUES(:ID,:MobileNumber,:Contents,:SendUserID,:SendUserName,:SendTime,:Status,:Note)";
      OracleParameter[] oracleParameterArray = new OracleParameter[8];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter1.Value = (object) model.ID;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":MobileNumber", OracleDbType.Varchar2);
      oracleParameter2.Value = (object) model.MobileNumber;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3 = new OracleParameter(":Contents", OracleDbType.NVarchar2);
      oracleParameter3.Value = (object) model.Contents;
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter4;
      if (model.SendUserID.HasValue)
      {
        OracleParameter oracleParameter5 = new OracleParameter(":SendUserID", OracleDbType.Varchar2);
        oracleParameter5.Value = (object) model.SendUserID;
        oracleParameter4 = oracleParameter5;
      }
      else
      {
        oracleParameter4 = new OracleParameter(":SendUserID", OracleDbType.Varchar2);
        oracleParameter4.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index4] = oracleParameter4;
      int index5 = 4;
      OracleParameter oracleParameter6;
      if (model.SendUserName != null)
      {
        OracleParameter oracleParameter5 = new OracleParameter(":SendUserName", OracleDbType.NVarchar2);
        oracleParameter5.Value = (object) model.SendUserName;
        oracleParameter6 = oracleParameter5;
      }
      else
      {
        oracleParameter6 = new OracleParameter(":SendUserName", OracleDbType.NVarchar2, 1000);
        oracleParameter6.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index5] = oracleParameter6;
      int index6 = 5;
      OracleParameter oracleParameter7 = new OracleParameter(":SendTime", OracleDbType.Date);
      oracleParameter7.Value = (object) model.SendTime;
      oracleParameterArray[index6] = oracleParameter7;
      int index7 = 6;
      OracleParameter oracleParameter8 = new OracleParameter(":Status", OracleDbType.Int32);
      oracleParameter8.Value = (object) model.Status;
      oracleParameterArray[index7] = oracleParameter8;
      int index8 = 7;
      OracleParameter oracleParameter9 = new OracleParameter(":Note", OracleDbType.Varchar2);
      oracleParameter9.Value = (object) model.Note;
      oracleParameterArray[index8] = oracleParameter9;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Update(RoadFlow.Data.Model.SMSLog model)
    {
      string sql = "UPDATE SMSLog SET \r\n\t\t\t\tMobileNumber=:MobileNumber,Contents=:Contents,SendUserID=:SendUserID,SendUserName=:SendUserName,SendTime=:SendTime,Status=:Status,Note=:Note\r\n\t\t\t\tWHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[8];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":MobileNumber", OracleDbType.Varchar2);
      oracleParameter1.Value = (object) model.MobileNumber;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":Contents", OracleDbType.NVarchar2);
      oracleParameter2.Value = (object) model.Contents;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3;
      if (model.SendUserID.HasValue)
      {
        OracleParameter oracleParameter4 = new OracleParameter(":SendUserID", OracleDbType.Varchar2);
        oracleParameter4.Value = (object) model.SendUserID;
        oracleParameter3 = oracleParameter4;
      }
      else
      {
        oracleParameter3 = new OracleParameter(":SendUserID", OracleDbType.Varchar2);
        oracleParameter3.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter5;
      if (model.SendUserName != null)
      {
        OracleParameter oracleParameter4 = new OracleParameter(":SendUserName", OracleDbType.NVarchar2);
        oracleParameter4.Value = (object) model.SendUserName;
        oracleParameter5 = oracleParameter4;
      }
      else
      {
        oracleParameter5 = new OracleParameter(":SendUserName", OracleDbType.NVarchar2);
        oracleParameter5.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index4] = oracleParameter5;
      int index5 = 4;
      OracleParameter oracleParameter6 = new OracleParameter(":SendTime", OracleDbType.Date);
      oracleParameter6.Value = (object) model.SendTime;
      oracleParameterArray[index5] = oracleParameter6;
      int index6 = 5;
      OracleParameter oracleParameter7 = new OracleParameter(":Status", OracleDbType.Int32);
      oracleParameter7.Value = (object) model.Status;
      oracleParameterArray[index6] = oracleParameter7;
      int index7 = 6;
      OracleParameter oracleParameter8 = new OracleParameter(":Note", OracleDbType.Varchar2);
      oracleParameter8.Value = (object) model.Note;
      oracleParameterArray[index7] = oracleParameter8;
      int index8 = 7;
      OracleParameter oracleParameter9 = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter9.Value = (object) model.ID;
      oracleParameterArray[index8] = oracleParameter9;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM SMSLog WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    private List<RoadFlow.Data.Model.SMSLog> DataReaderToList(OracleDataReader dataReader)
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
        smsLog.Note = dataReader.GetString(7);
        smsLogList.Add(smsLog);
      }
      return smsLogList;
    }

    public List<RoadFlow.Data.Model.SMSLog> GetAll()
    {
      OracleDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM SMSLog");
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
      string sql = "SELECT * FROM SMSLog WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.SMSLog> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.SMSLog) null;
      return list[0];
    }
  }
}
