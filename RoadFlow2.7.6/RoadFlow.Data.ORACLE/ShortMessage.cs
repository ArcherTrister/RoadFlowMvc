// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.ORACLE.ShortMessage
// Assembly: RoadFlow.Data.ORACLE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C9018AA1-E48E-4231-92A9-CD6F0F275D11
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.ORACLE.dll

using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoadFlow.Data.ORACLE
{
  public class ShortMessage : IShortMessage
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.ShortMessage model)
    {
      string sql = "INSERT INTO ShortMessage\r\n\t\t\t\t(ID,Title,Contents,SendUserID,SendUserName,ReceiveUserID,ReceiveUserName,SendTime,LinkUrl,LinkID,Type,Files) \r\n\t\t\t\tVALUES(:ID,:Title,:Contents,:SendUserID,:SendUserName,:ReceiveUserID,:ReceiveUserName,:SendTime,:LinkUrl,:LinkID,:Type,:Files)";
      OracleParameter[] oracleParameterArray = new OracleParameter[12];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter1.Value = (object) model.ID;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":Title", OracleDbType.NVarchar2);
      oracleParameter2.Value = (object) model.Title;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3;
      if (model.Contents != null)
      {
        OracleParameter oracleParameter4 = new OracleParameter(":Contents", OracleDbType.NVarchar2);
        oracleParameter4.Value = (object) model.Contents;
        oracleParameter3 = oracleParameter4;
      }
      else
      {
        oracleParameter3 = new OracleParameter(":Contents", OracleDbType.NVarchar2);
        oracleParameter3.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter5 = new OracleParameter(":SendUserID", OracleDbType.Varchar2);
      oracleParameter5.Value = (object) model.SendUserID;
      oracleParameterArray[index4] = oracleParameter5;
      int index5 = 4;
      OracleParameter oracleParameter6 = new OracleParameter(":SendUserName", OracleDbType.NVarchar2);
      oracleParameter6.Value = (object) model.SendUserName;
      oracleParameterArray[index5] = oracleParameter6;
      int index6 = 5;
      OracleParameter oracleParameter7 = new OracleParameter(":ReceiveUserID", OracleDbType.Varchar2);
      oracleParameter7.Value = (object) model.ReceiveUserID;
      oracleParameterArray[index6] = oracleParameter7;
      int index7 = 6;
      OracleParameter oracleParameter8 = new OracleParameter(":ReceiveUserName", OracleDbType.NVarchar2);
      oracleParameter8.Value = (object) model.ReceiveUserName;
      oracleParameterArray[index7] = oracleParameter8;
      int index8 = 7;
      OracleParameter oracleParameter9 = new OracleParameter(":SendTime", OracleDbType.Date);
      oracleParameter9.Value = (object) model.SendTime;
      oracleParameterArray[index8] = oracleParameter9;
      int index9 = 8;
      OracleParameter oracleParameter10;
      if (model.LinkUrl != null)
      {
        OracleParameter oracleParameter4 = new OracleParameter(":LinkUrl", OracleDbType.Varchar2);
        oracleParameter4.Value = (object) model.LinkUrl;
        oracleParameter10 = oracleParameter4;
      }
      else
      {
        oracleParameter10 = new OracleParameter(":LinkUrl", OracleDbType.Varchar2);
        oracleParameter10.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index9] = oracleParameter10;
      int index10 = 9;
      OracleParameter oracleParameter11;
      if (model.LinkID != null)
      {
        OracleParameter oracleParameter4 = new OracleParameter(":LinkID", OracleDbType.Varchar2);
        oracleParameter4.Value = (object) model.LinkID;
        oracleParameter11 = oracleParameter4;
      }
      else
      {
        oracleParameter11 = new OracleParameter(":LinkID", OracleDbType.Varchar2);
        oracleParameter11.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index10] = oracleParameter11;
      int index11 = 10;
      OracleParameter oracleParameter12 = new OracleParameter(":Type", OracleDbType.Int32);
      oracleParameter12.Value = (object) model.Type;
      oracleParameterArray[index11] = oracleParameter12;
      int index12 = 11;
      OracleParameter oracleParameter13 = new OracleParameter(":Files", OracleDbType.Varchar2);
      oracleParameter13.Value = (object) model.Files;
      oracleParameterArray[index12] = oracleParameter13;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Update(RoadFlow.Data.Model.ShortMessage model)
    {
      string sql = "UPDATE ShortMessage SET \r\n\t\t\t\tTitle=:Title,Contents=:Contents,SendUserID=:SendUserID,SendUserName=:SendUserName,ReceiveUserID=:ReceiveUserID,ReceiveUserName=:ReceiveUserName,SendTime=:SendTime,LinkUrl=:LinkUrl,LinkID=:LinkID,Type=:Type,Files=:Files\r\n\t\t\t\tWHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[12];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":Title", OracleDbType.NVarchar2);
      oracleParameter1.Value = (object) model.Title;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2;
      if (model.Contents != null)
      {
        OracleParameter oracleParameter3 = new OracleParameter(":Contents", OracleDbType.Varchar2);
        oracleParameter3.Value = (object) model.Contents;
        oracleParameter2 = oracleParameter3;
      }
      else
      {
        oracleParameter2 = new OracleParameter(":Contents", OracleDbType.NVarchar2);
        oracleParameter2.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter4 = new OracleParameter(":SendUserID", OracleDbType.Varchar2);
      oracleParameter4.Value = (object) model.SendUserID;
      oracleParameterArray[index3] = oracleParameter4;
      int index4 = 3;
      OracleParameter oracleParameter5 = new OracleParameter(":SendUserName", OracleDbType.NVarchar2);
      oracleParameter5.Value = (object) model.SendUserName;
      oracleParameterArray[index4] = oracleParameter5;
      int index5 = 4;
      OracleParameter oracleParameter6 = new OracleParameter(":ReceiveUserID", OracleDbType.Varchar2);
      oracleParameter6.Value = (object) model.ReceiveUserID;
      oracleParameterArray[index5] = oracleParameter6;
      int index6 = 5;
      OracleParameter oracleParameter7 = new OracleParameter(":ReceiveUserName", OracleDbType.NVarchar2);
      oracleParameter7.Value = (object) model.ReceiveUserName;
      oracleParameterArray[index6] = oracleParameter7;
      int index7 = 6;
      OracleParameter oracleParameter8 = new OracleParameter(":SendTime", OracleDbType.Date);
      oracleParameter8.Value = (object) model.SendTime;
      oracleParameterArray[index7] = oracleParameter8;
      int index8 = 7;
      OracleParameter oracleParameter9;
      if (model.LinkUrl != null)
      {
        OracleParameter oracleParameter3 = new OracleParameter(":LinkUrl", OracleDbType.Varchar2);
        oracleParameter3.Value = (object) model.LinkUrl;
        oracleParameter9 = oracleParameter3;
      }
      else
      {
        oracleParameter9 = new OracleParameter(":LinkUrl", OracleDbType.Varchar2);
        oracleParameter9.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index8] = oracleParameter9;
      int index9 = 8;
      OracleParameter oracleParameter10;
      if (model.LinkID != null)
      {
        OracleParameter oracleParameter3 = new OracleParameter(":LinkID", OracleDbType.Varchar2);
        oracleParameter3.Value = (object) model.LinkID;
        oracleParameter10 = oracleParameter3;
      }
      else
      {
        oracleParameter10 = new OracleParameter(":LinkID", OracleDbType.Varchar2);
        oracleParameter10.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index9] = oracleParameter10;
      int index10 = 9;
      OracleParameter oracleParameter11 = new OracleParameter(":Type", OracleDbType.Int32);
      oracleParameter11.Value = (object) model.Type;
      oracleParameterArray[index10] = oracleParameter11;
      int index11 = 10;
      OracleParameter oracleParameter12 = new OracleParameter(":Files", OracleDbType.Varchar2);
      oracleParameter12.Value = (object) model.Files;
      oracleParameterArray[index11] = oracleParameter12;
      int index12 = 11;
      OracleParameter oracleParameter13 = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter13.Value = (object) model.ID;
      oracleParameterArray[index12] = oracleParameter13;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM ShortMessage WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id.ToString();
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    private List<RoadFlow.Data.Model.ShortMessage> DataReaderToList(OracleDataReader dataReader)
    {
      List<RoadFlow.Data.Model.ShortMessage> shortMessageList = new List<RoadFlow.Data.Model.ShortMessage>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.ShortMessage shortMessage = new RoadFlow.Data.Model.ShortMessage();
        shortMessage.ID = dataReader.GetString(0).ToGuid();
        shortMessage.Title = dataReader.GetString(1);
        if (!dataReader.IsDBNull(2))
          shortMessage.Contents = dataReader.GetString(2);
        shortMessage.SendUserID = dataReader.GetString(3).ToGuid();
        shortMessage.SendUserName = dataReader.GetString(4);
        shortMessage.ReceiveUserID = dataReader.GetString(5).ToGuid();
        shortMessage.ReceiveUserName = dataReader.GetString(6);
        shortMessage.SendTime = dataReader.GetDateTime(7);
        if (!dataReader.IsDBNull(8))
          shortMessage.LinkUrl = dataReader.GetString(8);
        if (!dataReader.IsDBNull(9))
          shortMessage.LinkID = dataReader.GetString(9);
        shortMessage.Type = dataReader.GetInt32(10);
        if (!dataReader.IsDBNull(11))
          shortMessage.Files = dataReader.GetString(11);
        shortMessage.Status = dataReader.FieldCount <= 11 ? 0 : dataReader.GetInt32(12);
        shortMessageList.Add(shortMessage);
      }
      return shortMessageList;
    }

    public List<RoadFlow.Data.Model.ShortMessage> GetAll()
    {
      OracleDataReader dataReader = this.dbHelper.GetDataReader("SELECT ID,Title,Contents,SendUserID,SendUserName,ReceiveUserID,ReceiveUserName,SendTime,LinkUrl,LinkID,Type,Files,0 AS Status FROM ShortMessage");
      List<RoadFlow.Data.Model.ShortMessage> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM ShortMessage"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.ShortMessage Get(Guid id)
    {
      string sql = "SELECT ID,Title,Contents,SendUserID,SendUserName,ReceiveUserID,ReceiveUserName,SendTime,LinkUrl,LinkID,Type,Files,0 AS Status FROM ShortMessage WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id.ToString();
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.ShortMessage> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.ShortMessage) null;
      return list[0];
    }

    public RoadFlow.Data.Model.ShortMessage GetRead(Guid id)
    {
      string sql = "SELECT ID,Title,Contents,SendUserID,SendUserName,ReceiveUserID,ReceiveUserName,SendTime,LinkUrl,LinkID,Type,Files,0 AS Status FROM ShortMessage1 WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id.ToString();
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.ShortMessage> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.ShortMessage) null;
      return list[0];
    }

    public List<RoadFlow.Data.Model.ShortMessage> GetAllNoRead()
    {
      OracleDataReader dataReader = this.dbHelper.GetDataReader("SELECT ID,Title,Contents,SendUserID,SendUserName,ReceiveUserID,ReceiveUserName,SendTime,LinkUrl,LinkID,Type,Files,0 AS Status FROM ShortMessage");
      List<RoadFlow.Data.Model.ShortMessage> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.ShortMessage> GetAllNoReadByUserID(Guid userID)
    {
      string sql = "SELECT ID,Title,Contents,SendUserID,SendUserName,ReceiveUserID,ReceiveUserName,SendTime,LinkUrl,LinkID,Type,Files,0 AS Status FROM ShortMessage WHERE ReceiveUserID=:ReceiveUserID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ReceiveUserID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) userID.ToString();
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.ShortMessage> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public int UpdateStatus(Guid id)
    {
      string sql = "BEGIN INSERT INTO ShortMessage1 SELECT * FROM ShortMessage WHERE ID=:ID; DELETE FROM ShortMessage WHERE ID=:ID; END;";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public List<RoadFlow.Data.Model.ShortMessage> GetList(out string pager, int[] status, string query = "", string title = "", string contents = "", string senderID = "", string date1 = "", string date2 = "", string receiveID = "")
    {
      List<OracleParameter> oracleParameterList = new List<OracleParameter>();
      string str = string.Empty;
      if (status.Length == 1 && status[0] == 0)
        str = "SELECT ID,Title,Contents,SendUserID,SendUserName,ReceiveUserID,ReceiveUserName,SendTime,LinkUrl,LinkID,Type,Files,0 AS Status FROM ShortMessage WHERE 1=1";
      else if (status.Length == 1 && status[0] == 1)
        str = "SELECT ID,Title,Contents,SendUserID,SendUserName,ReceiveUserID,ReceiveUserName,SendTime,LinkUrl,LinkID,Type,Files,1 AS Status FROM ShortMessage1 WHERE 1=1";
      else if (status.Length == 2)
        str = "SELECT * FROM(SELECT ID,Title,Contents,SendUserID,SendUserName,ReceiveUserID,ReceiveUserName,SendTime,LinkUrl,LinkID,Type,Files,0 AS Status FROM ShortMessage WHERE 1=1 UNION ALL SELECT ID,Title,Contents,SendUserID,SendUserName,ReceiveUserID,ReceiveUserName,SendTime,LinkUrl,LinkID,Type,Files,1 AS Status FROM ShortMessage1 WHERE 1=1) temp WHERE 1=1";
      StringBuilder stringBuilder = new StringBuilder(str);
      if (receiveID.IsGuid())
      {
        stringBuilder.Append(" AND ReceiveUserID=:ReceiveUserID");
        oracleParameterList.Add(new OracleParameter(":ReceiveUserID", (object) receiveID));
      }
      if (!title.IsNullOrEmpty())
      {
        stringBuilder.Append(" AND INSTR(Title,:Title,1,1)>0");
        oracleParameterList.Add(new OracleParameter(":Title", (object) title));
      }
      if (!contents.IsNullOrEmpty())
      {
        stringBuilder.Append(" AND INSTR(Contents,:Contents,1,1)>0");
        oracleParameterList.Add(new OracleParameter(":Contents", (object) contents));
      }
      if (!senderID.IsNullOrEmpty())
        stringBuilder.AppendFormat(" AND SendUserID IN({0})", (object) senderID);
      if (date1.IsDateTime())
      {
        stringBuilder.Append(" AND SendTime>=:SendTime");
        oracleParameterList.Add(new OracleParameter(":SendTime", (object) date1.ToDateTime()));
      }
      if (date2.IsDateTime())
      {
        stringBuilder.Append(" AND SendTime<=:SendTime1");
        oracleParameterList.Add(new OracleParameter(":SendTime1", (object) date2.ToDateTime().AddDays(1.0).ToDateString()));
      }
      int pageSize = Tools.GetPageSize();
      int pageNumber = Tools.GetPageNumber();
      long count;
      string paerSql = this.dbHelper.GetPaerSql(stringBuilder.ToString(), pageSize, pageNumber, out count, oracleParameterList.ToArray());
      pager = Tools.GetPagerHtml(count, pageSize, pageNumber, query);
      OracleDataReader dataReader = this.dbHelper.GetDataReader(paerSql, oracleParameterList.ToArray());
      List<RoadFlow.Data.Model.ShortMessage> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.ShortMessage> GetList(out long count, int[] status, int size, int number, string title = "", string contents = "", string senderID = "", string date1 = "", string date2 = "", string receiveID = "", string order = "")
    {
      List<OracleParameter> oracleParameterList = new List<OracleParameter>();
      string str = string.Empty;
      if (status.Length == 1 && status[0] == 0)
        str = "SELECT ID,Title,Contents,SendUserID,SendUserName,ReceiveUserID,ReceiveUserName,SendTime,LinkUrl,LinkID,Type,Files,0 AS Status FROM ShortMessage WHERE 1=1";
      else if (status.Length == 1 && status[0] == 1)
        str = "SELECT ID,Title,Contents,SendUserID,SendUserName,ReceiveUserID,ReceiveUserName,SendTime,LinkUrl,LinkID,Type,Files,1 AS Status FROM ShortMessage1 WHERE 1=1";
      else if (status.Length == 2)
        str = "SELECT * FROM(SELECT ID,Title,Contents,SendUserID,SendUserName,ReceiveUserID,ReceiveUserName,SendTime,LinkUrl,LinkID,Type,Files,0 AS Status FROM ShortMessage WHERE 1=1 UNION ALL SELECT ID,Title,Contents,SendUserID,SendUserName,ReceiveUserID,ReceiveUserName,SendTime,LinkUrl,LinkID,Type,Files,1 AS Status FROM ShortMessage1 WHERE 1=1) temp WHERE 1=1";
      StringBuilder stringBuilder = new StringBuilder(str);
      if (receiveID.IsGuid())
      {
        stringBuilder.Append(" AND ReceiveUserID=:ReceiveUserID");
        oracleParameterList.Add(new OracleParameter(":ReceiveUserID", (object) receiveID));
      }
      if (!title.IsNullOrEmpty())
      {
        stringBuilder.Append(" AND INSTR(Title,:Title,1,1)>0");
        oracleParameterList.Add(new OracleParameter(":Title", (object) title));
      }
      if (!contents.IsNullOrEmpty())
      {
        stringBuilder.Append(" AND INSTR(Contents,:Contents,1,1)>0");
        oracleParameterList.Add(new OracleParameter(":Contents", (object) contents));
      }
      if (!senderID.IsNullOrEmpty())
        stringBuilder.AppendFormat(" AND SendUserID IN({0})", (object) senderID);
      if (date1.IsDateTime())
      {
        stringBuilder.Append(" AND SendTime>=:SendTime");
        oracleParameterList.Add(new OracleParameter(":SendTime", (object) date1.ToDateTime()));
      }
      if (date2.IsDateTime())
      {
        stringBuilder.Append(" AND SendTime<=:SendTime1");
        oracleParameterList.Add(new OracleParameter(":SendTime1", (object) date2.ToDateTime().AddDays(1.0).ToDateString()));
      }
      stringBuilder.Append(" ORDER BY " + (order.IsNullOrEmpty() ? "SendTime DESC" : order));
      OracleDataReader dataReader = this.dbHelper.GetDataReader(this.dbHelper.GetPaerSql(stringBuilder.ToString(), size, number, out count, oracleParameterList.ToArray()), oracleParameterList.ToArray());
      List<RoadFlow.Data.Model.ShortMessage> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public int Delete(string linkID, int Type)
    {
      string sql = "DELETE FROM ShortMessage WHERE LinkID=:LinkID AND Type=:Type";
      OracleParameter[] oracleParameterArray = new OracleParameter[2];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":LinkID", OracleDbType.Varchar2);
      oracleParameter1.Value = (object) linkID;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":Type", OracleDbType.Int32);
      oracleParameter2.Value = (object) Type;
      oracleParameterArray[index2] = oracleParameter2;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }
  }
}
