// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MySql.ShortMessage
// Assembly: RoadFlow.Data.MySql, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 29B652D7-5F6F-4A7D-AD1C-9F2C643FD784
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.MySql.dll

using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoadFlow.Data.MySql
{
  public class ShortMessage : IShortMessage
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.ShortMessage model)
    {
      string sql = "INSERT INTO shortmessage\r\n\t\t\t\t(ID,Title,Contents,SendUserID,SendUserName,ReceiveUserID,ReceiveUserName,SendTime,LinkUrl,LinkID,Type,Files) \r\n\t\t\t\tVALUES(@ID,@Title,@Contents,@SendUserID,@SendUserName,@ReceiveUserID,@ReceiveUserName,@SendTime,@LinkUrl,@LinkID,@Type,@Files)";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[12];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter1.Value = (object) model.ID;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@Title", MySqlDbType.Text, -1);
      mySqlParameter2.Value = (object) model.Title;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3;
      if (model.Contents != null)
      {
        MySqlParameter mySqlParameter4 = new MySqlParameter("@Contents", MySqlDbType.VarChar, 4000);
        mySqlParameter4.Value = (object) model.Contents;
        mySqlParameter3 = mySqlParameter4;
      }
      else
      {
        mySqlParameter3 = new MySqlParameter("@Contents", MySqlDbType.VarChar, 4000);
        mySqlParameter3.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter5 = new MySqlParameter("@SendUserID", MySqlDbType.VarChar, 36);
      mySqlParameter5.Value = (object) model.SendUserID;
      mySqlParameterArray[index4] = mySqlParameter5;
      int index5 = 4;
      MySqlParameter mySqlParameter6 = new MySqlParameter("@SendUserName", MySqlDbType.Text, -1);
      mySqlParameter6.Value = (object) model.SendUserName;
      mySqlParameterArray[index5] = mySqlParameter6;
      int index6 = 5;
      MySqlParameter mySqlParameter7 = new MySqlParameter("@ReceiveUserID", MySqlDbType.VarChar, 36);
      mySqlParameter7.Value = (object) model.ReceiveUserID;
      mySqlParameterArray[index6] = mySqlParameter7;
      int index7 = 6;
      MySqlParameter mySqlParameter8 = new MySqlParameter("@ReceiveUserName", MySqlDbType.Text, -1);
      mySqlParameter8.Value = (object) model.ReceiveUserName;
      mySqlParameterArray[index7] = mySqlParameter8;
      int index8 = 7;
      MySqlParameter mySqlParameter9 = new MySqlParameter("@SendTime", MySqlDbType.DateTime, -1);
      mySqlParameter9.Value = (object) model.SendTime;
      mySqlParameterArray[index8] = mySqlParameter9;
      int index9 = 8;
      MySqlParameter mySqlParameter10;
      if (model.LinkUrl != null)
      {
        MySqlParameter mySqlParameter4 = new MySqlParameter("@LinkUrl", MySqlDbType.VarChar, 2000);
        mySqlParameter4.Value = (object) model.LinkUrl;
        mySqlParameter10 = mySqlParameter4;
      }
      else
      {
        mySqlParameter10 = new MySqlParameter("@LinkUrl", MySqlDbType.VarChar, 2000);
        mySqlParameter10.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index9] = mySqlParameter10;
      int index10 = 9;
      MySqlParameter mySqlParameter11;
      if (model.LinkID != null)
      {
        MySqlParameter mySqlParameter4 = new MySqlParameter("@LinkID", MySqlDbType.VarChar, 50);
        mySqlParameter4.Value = (object) model.LinkID;
        mySqlParameter11 = mySqlParameter4;
      }
      else
      {
        mySqlParameter11 = new MySqlParameter("@LinkID", MySqlDbType.VarChar, 50);
        mySqlParameter11.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index10] = mySqlParameter11;
      int index11 = 10;
      MySqlParameter mySqlParameter12 = new MySqlParameter("@Type", MySqlDbType.Int32, 11);
      mySqlParameter12.Value = (object) model.Type;
      mySqlParameterArray[index11] = mySqlParameter12;
      int index12 = 11;
      MySqlParameter mySqlParameter13 = new MySqlParameter("@Files", MySqlDbType.Text, -1);
      mySqlParameter13.Value = (object) model.Files;
      mySqlParameterArray[index12] = mySqlParameter13;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.ShortMessage model)
    {
      string sql = "UPDATE shortmessage SET \r\n\t\t\t\tTitle=@Title,Contents=@Contents,SendUserID=@SendUserID,SendUserName=@SendUserName,ReceiveUserID=@ReceiveUserID,ReceiveUserName=@ReceiveUserName,SendTime=@SendTime,LinkUrl=@LinkUrl,LinkID=@LinkID,Type=@Type,Files=@Files\r\n\t\t\t\tWHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[12];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@Title", MySqlDbType.Text, -1);
      mySqlParameter1.Value = (object) model.Title;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2;
      if (model.Contents != null)
      {
        MySqlParameter mySqlParameter3 = new MySqlParameter("@Contents", MySqlDbType.VarChar, 4000);
        mySqlParameter3.Value = (object) model.Contents;
        mySqlParameter2 = mySqlParameter3;
      }
      else
      {
        mySqlParameter2 = new MySqlParameter("@Contents", MySqlDbType.VarChar, 4000);
        mySqlParameter2.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter4 = new MySqlParameter("@SendUserID", MySqlDbType.VarChar, 36);
      mySqlParameter4.Value = (object) model.SendUserID;
      mySqlParameterArray[index3] = mySqlParameter4;
      int index4 = 3;
      MySqlParameter mySqlParameter5 = new MySqlParameter("@SendUserName", MySqlDbType.Text, -1);
      mySqlParameter5.Value = (object) model.SendUserName;
      mySqlParameterArray[index4] = mySqlParameter5;
      int index5 = 4;
      MySqlParameter mySqlParameter6 = new MySqlParameter("@ReceiveUserID", MySqlDbType.VarChar, 36);
      mySqlParameter6.Value = (object) model.ReceiveUserID;
      mySqlParameterArray[index5] = mySqlParameter6;
      int index6 = 5;
      MySqlParameter mySqlParameter7 = new MySqlParameter("@ReceiveUserName", MySqlDbType.Text, -1);
      mySqlParameter7.Value = (object) model.ReceiveUserName;
      mySqlParameterArray[index6] = mySqlParameter7;
      int index7 = 6;
      MySqlParameter mySqlParameter8 = new MySqlParameter("@SendTime", MySqlDbType.DateTime, -1);
      mySqlParameter8.Value = (object) model.SendTime;
      mySqlParameterArray[index7] = mySqlParameter8;
      int index8 = 7;
      MySqlParameter mySqlParameter9;
      if (model.LinkUrl != null)
      {
        MySqlParameter mySqlParameter3 = new MySqlParameter("@LinkUrl", MySqlDbType.VarChar, 2000);
        mySqlParameter3.Value = (object) model.LinkUrl;
        mySqlParameter9 = mySqlParameter3;
      }
      else
      {
        mySqlParameter9 = new MySqlParameter("@LinkUrl", MySqlDbType.VarChar, 2000);
        mySqlParameter9.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index8] = mySqlParameter9;
      int index9 = 8;
      MySqlParameter mySqlParameter10;
      if (model.LinkID != null)
      {
        MySqlParameter mySqlParameter3 = new MySqlParameter("@LinkID", MySqlDbType.VarChar, 50);
        mySqlParameter3.Value = (object) model.LinkID;
        mySqlParameter10 = mySqlParameter3;
      }
      else
      {
        mySqlParameter10 = new MySqlParameter("@LinkID", MySqlDbType.VarChar, 50);
        mySqlParameter10.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index9] = mySqlParameter10;
      int index10 = 9;
      MySqlParameter mySqlParameter11 = new MySqlParameter("@Type", MySqlDbType.Int32, 11);
      mySqlParameter11.Value = (object) model.Type;
      mySqlParameterArray[index10] = mySqlParameter11;
      int index11 = 10;
      MySqlParameter mySqlParameter12 = new MySqlParameter("@Files", MySqlDbType.Text, -1);
      mySqlParameter12.Value = (object) model.Files;
      mySqlParameterArray[index11] = mySqlParameter12;
      int index12 = 11;
      MySqlParameter mySqlParameter13 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter13.Value = (object) model.ID;
      mySqlParameterArray[index12] = mySqlParameter13;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM shortmessage WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.ShortMessage> DataReaderToList(MySqlDataReader dataReader)
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
      MySqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT *,0 AS Status FROM shortmessage");
      List<RoadFlow.Data.Model.ShortMessage> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM shortmessage"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.ShortMessage Get(Guid id)
    {
      string sql = "SELECT *,0 AS Status FROM shortmessage WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.ShortMessage> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.ShortMessage) null;
      return list[0];
    }

    public RoadFlow.Data.Model.ShortMessage GetRead(Guid id)
    {
      string sql = "SELECT *,0 AS Status FROM ShortMessage1 WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.ShortMessage> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.ShortMessage) null;
      return list[0];
    }

    public List<RoadFlow.Data.Model.ShortMessage> GetAllNoRead()
    {
      MySqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT *,0 AS Status FROM ShortMessage");
      List<RoadFlow.Data.Model.ShortMessage> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.ShortMessage> GetAllNoReadByUserID(Guid userID)
    {
      string sql = "SELECT *,0 AS Status FROM ShortMessage WHERE ReceiveUserID=@ReceiveUserID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ReceiveUserID", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) userID.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.ShortMessage> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public int UpdateStatus(Guid id)
    {
      string sql = "INSERT INTO ShortMessage1 SELECT * FROM ShortMessage WHERE ID=@ID;DELETE FROM ShortMessage WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public List<RoadFlow.Data.Model.ShortMessage> GetList(out string pager, int[] status, string query = "", string title = "", string contents = "", string senderID = "", string date1 = "", string date2 = "", string receiveID = "")
    {
      List<MySqlParameter> mySqlParameterList = new List<MySqlParameter>();
      string str = string.Empty;
      if (status.Length == 1 && status[0] == 0)
        str = "SELECT *,0 AS Status FROM ShortMessage WHERE 1=1";
      else if (status.Length == 1 && status[0] == 1)
        str = "SELECT *,1 AS Status FROM ShortMessage1 WHERE 1=1";
      else if (status.Length == 2)
        str = "SELECT * FROM(SELECT *,0 AS Status FROM ShortMessage WHERE 1=1 UNION ALL SELECT *,1 AS Status FROM ShortMessage1 WHERE 1=1) temp WHERE 1=1";
      StringBuilder stringBuilder = new StringBuilder(str);
      if (receiveID.IsGuid())
      {
        stringBuilder.Append(" AND ReceiveUserID=@ReceiveUserID");
        mySqlParameterList.Add(new MySqlParameter("@ReceiveUserID", (object) receiveID));
      }
      if (!title.IsNullOrEmpty())
      {
        stringBuilder.Append(" AND INSTR(Title,@Title)>0");
        mySqlParameterList.Add(new MySqlParameter("@Title", (object) title));
      }
      if (!contents.IsNullOrEmpty())
      {
        stringBuilder.Append(" AND INSTR(Contents,@Contents)>0");
        mySqlParameterList.Add(new MySqlParameter("@Contents", (object) contents));
      }
      if (!senderID.IsNullOrEmpty())
        stringBuilder.AppendFormat(" AND SendUserID IN({0})", (object) senderID);
      if (date1.IsDateTime())
      {
        stringBuilder.Append(" AND SendTime>=@SendTime");
        mySqlParameterList.Add(new MySqlParameter("@SendTime", (object) date1.ToDateTime()));
      }
      if (date2.IsDateTime())
      {
        stringBuilder.Append(" AND SendTime<=@SendTime1");
        mySqlParameterList.Add(new MySqlParameter("@SendTime1", (object) date2.ToDateTime().AddDays(1.0).ToDateString()));
      }
      stringBuilder.Append(" ORDER BY SendTime DESC");
      int pageSize = Tools.GetPageSize();
      int pageNumber = Tools.GetPageNumber();
      long count;
      string paerSql = this.dbHelper.GetPaerSql(stringBuilder.ToString(), pageSize, pageNumber, out count, mySqlParameterList.ToArray());
      pager = Tools.GetPagerHtml(count, pageSize, pageNumber, query);
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(paerSql, mySqlParameterList.ToArray());
      List<RoadFlow.Data.Model.ShortMessage> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.ShortMessage> GetList(out long count, int[] status, int size, int number, string title = "", string contents = "", string senderID = "", string date1 = "", string date2 = "", string receiveID = "", string order = "")
    {
      List<MySqlParameter> mySqlParameterList = new List<MySqlParameter>();
      string str = string.Empty;
      if (status.Length == 1 && status[0] == 0)
        str = "SELECT *,0 AS Status FROM ShortMessage WHERE 1=1";
      else if (status.Length == 1 && status[0] == 1)
        str = "SELECT *,1 AS Status FROM ShortMessage1 WHERE 1=1";
      else if (status.Length == 2)
        str = "SELECT * FROM(SELECT *,0 AS Status FROM ShortMessage WHERE 1=1 UNION ALL SELECT *,1 AS Status FROM ShortMessage1 WHERE 1=1) temp WHERE 1=1";
      StringBuilder stringBuilder = new StringBuilder(str);
      if (receiveID.IsGuid())
      {
        stringBuilder.Append(" AND ReceiveUserID=@ReceiveUserID");
        mySqlParameterList.Add(new MySqlParameter("@ReceiveUserID", (object) receiveID));
      }
      if (!title.IsNullOrEmpty())
      {
        stringBuilder.Append(" AND INSTR(Title,@Title)>0");
        mySqlParameterList.Add(new MySqlParameter("@Title", (object) title));
      }
      if (!contents.IsNullOrEmpty())
      {
        stringBuilder.Append(" AND INSTR(Contents,@Contents)>0");
        mySqlParameterList.Add(new MySqlParameter("@Contents", (object) contents));
      }
      if (!senderID.IsNullOrEmpty())
        stringBuilder.AppendFormat(" AND SendUserID IN({0})", (object) senderID);
      if (date1.IsDateTime())
      {
        stringBuilder.Append(" AND SendTime>=@SendTime");
        mySqlParameterList.Add(new MySqlParameter("@SendTime", (object) date1.ToDateTime()));
      }
      if (date2.IsDateTime())
      {
        stringBuilder.Append(" AND SendTime<=@SendTime1");
        mySqlParameterList.Add(new MySqlParameter("@SendTime1", (object) date2.ToDateTime().AddDays(1.0).ToDateString()));
      }
      stringBuilder.Append(" ORDER BY " + (order.IsNullOrEmpty() ? "SendTime DESC" : order));
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(this.dbHelper.GetPaerSql(stringBuilder.ToString(), size, number, out count, mySqlParameterList.ToArray()), mySqlParameterList.ToArray());
      List<RoadFlow.Data.Model.ShortMessage> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public int Delete(string linkID, int Type)
    {
      string sql = "DELETE FROM ShortMessage WHERE LinkID=@LinkID AND Type=@Type";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[2];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@LinkID", MySqlDbType.VarChar);
      mySqlParameter1.Value = (object) linkID;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@Type", MySqlDbType.Int32);
      mySqlParameter2.Value = (object) Type;
      mySqlParameterArray[index2] = mySqlParameter2;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }
  }
}
