// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MSSQL.ShortMessage
// Assembly: RoadFlow.Data.MSSQL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5107CDC7-8F84-4EE0-AC6D-E80FE4695340
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.MSSQL.dll

using RoadFlow.Data.Interface;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RoadFlow.Data.MSSQL
{
  public class ShortMessage : IShortMessage
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.ShortMessage model)
    {
      string sql = "INSERT INTO ShortMessage\r\n\t\t\t\t(ID,Title,Contents,SendUserID,SendUserName,ReceiveUserID,ReceiveUserName,SendTime,LinkUrl,LinkID,Type,Files) \r\n\t\t\t\tVALUES(@ID,@Title,@Contents,@SendUserID,@SendUserName,@ReceiveUserID,@ReceiveUserName,@SendTime,@LinkUrl,@LinkID,@Type,@Files)";
      SqlParameter[] sqlParameterArray = new SqlParameter[12];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter1.Value = (object) model.ID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@Title", SqlDbType.NVarChar, 1000);
      sqlParameter2.Value = (object) model.Title;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3;
      if (model.Contents != null)
      {
        SqlParameter sqlParameter4 = new SqlParameter("@Contents", SqlDbType.NVarChar, -1);
        sqlParameter4.Value = (object) model.Contents;
        sqlParameter3 = sqlParameter4;
      }
      else
      {
        sqlParameter3 = new SqlParameter("@Contents", SqlDbType.NVarChar, -1);
        sqlParameter3.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter5 = new SqlParameter("@SendUserID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter5.Value = (object) model.SendUserID;
      sqlParameterArray[index4] = sqlParameter5;
      int index5 = 4;
      SqlParameter sqlParameter6 = new SqlParameter("@SendUserName", SqlDbType.NVarChar, 1000);
      sqlParameter6.Value = (object) model.SendUserName;
      sqlParameterArray[index5] = sqlParameter6;
      int index6 = 5;
      SqlParameter sqlParameter7 = new SqlParameter("@ReceiveUserID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter7.Value = (object) model.ReceiveUserID;
      sqlParameterArray[index6] = sqlParameter7;
      int index7 = 6;
      SqlParameter sqlParameter8 = new SqlParameter("@ReceiveUserName", SqlDbType.NVarChar, 1000);
      sqlParameter8.Value = (object) model.ReceiveUserName;
      sqlParameterArray[index7] = sqlParameter8;
      int index8 = 7;
      SqlParameter sqlParameter9 = new SqlParameter("@SendTime", SqlDbType.DateTime, 8);
      sqlParameter9.Value = (object) model.SendTime;
      sqlParameterArray[index8] = sqlParameter9;
      int index9 = 8;
      SqlParameter sqlParameter10;
      if (model.LinkUrl != null)
      {
        SqlParameter sqlParameter4 = new SqlParameter("@LinkUrl", SqlDbType.VarChar, -1);
        sqlParameter4.Value = (object) model.LinkUrl;
        sqlParameter10 = sqlParameter4;
      }
      else
      {
        sqlParameter10 = new SqlParameter("@LinkUrl", SqlDbType.VarChar, -1);
        sqlParameter10.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index9] = sqlParameter10;
      int index10 = 9;
      SqlParameter sqlParameter11;
      if (model.LinkID != null)
      {
        SqlParameter sqlParameter4 = new SqlParameter("@LinkID", SqlDbType.VarChar, 50);
        sqlParameter4.Value = (object) model.LinkID;
        sqlParameter11 = sqlParameter4;
      }
      else
      {
        sqlParameter11 = new SqlParameter("@LinkID", SqlDbType.VarChar, 50);
        sqlParameter11.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index10] = sqlParameter11;
      int index11 = 10;
      SqlParameter sqlParameter12 = new SqlParameter("@Type", SqlDbType.Int, -1);
      sqlParameter12.Value = (object) model.Type;
      sqlParameterArray[index11] = sqlParameter12;
      int index12 = 11;
      SqlParameter sqlParameter13;
      if (model.Files != null)
      {
        SqlParameter sqlParameter4 = new SqlParameter("@Files", SqlDbType.VarChar, -1);
        sqlParameter4.Value = (object) model.Files;
        sqlParameter13 = sqlParameter4;
      }
      else
      {
        sqlParameter13 = new SqlParameter("@Files", SqlDbType.VarChar, -1);
        sqlParameter13.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index12] = sqlParameter13;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.ShortMessage model)
    {
      string sql = "UPDATE ShortMessage SET \r\n\t\t\t\tTitle=@Title,Contents=@Contents,SendUserID=@SendUserID,SendUserName=@SendUserName,ReceiveUserID=@ReceiveUserID,ReceiveUserName=@ReceiveUserName,SendTime=@SendTime,LinkUrl=@LinkUrl,LinkID=@LinkID,Type=@Type,Files=@Files\r\n\t\t\t\tWHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[12];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@Title", SqlDbType.NVarChar, 1000);
      sqlParameter1.Value = (object) model.Title;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2;
      if (model.Contents != null)
      {
        SqlParameter sqlParameter3 = new SqlParameter("@Contents", SqlDbType.NVarChar, -1);
        sqlParameter3.Value = (object) model.Contents;
        sqlParameter2 = sqlParameter3;
      }
      else
      {
        sqlParameter2 = new SqlParameter("@Contents", SqlDbType.NVarChar, -1);
        sqlParameter2.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter4 = new SqlParameter("@SendUserID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter4.Value = (object) model.SendUserID;
      sqlParameterArray[index3] = sqlParameter4;
      int index4 = 3;
      SqlParameter sqlParameter5 = new SqlParameter("@SendUserName", SqlDbType.NVarChar, 1000);
      sqlParameter5.Value = (object) model.SendUserName;
      sqlParameterArray[index4] = sqlParameter5;
      int index5 = 4;
      SqlParameter sqlParameter6 = new SqlParameter("@ReceiveUserID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter6.Value = (object) model.ReceiveUserID;
      sqlParameterArray[index5] = sqlParameter6;
      int index6 = 5;
      SqlParameter sqlParameter7 = new SqlParameter("@ReceiveUserName", SqlDbType.NVarChar, 1000);
      sqlParameter7.Value = (object) model.ReceiveUserName;
      sqlParameterArray[index6] = sqlParameter7;
      int index7 = 6;
      SqlParameter sqlParameter8 = new SqlParameter("@SendTime", SqlDbType.DateTime, 8);
      sqlParameter8.Value = (object) model.SendTime;
      sqlParameterArray[index7] = sqlParameter8;
      int index8 = 7;
      SqlParameter sqlParameter9;
      if (model.LinkUrl != null)
      {
        SqlParameter sqlParameter3 = new SqlParameter("@LinkUrl", SqlDbType.VarChar, -1);
        sqlParameter3.Value = (object) model.LinkUrl;
        sqlParameter9 = sqlParameter3;
      }
      else
      {
        sqlParameter9 = new SqlParameter("@LinkUrl", SqlDbType.VarChar, -1);
        sqlParameter9.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index8] = sqlParameter9;
      int index9 = 8;
      SqlParameter sqlParameter10;
      if (model.LinkID != null)
      {
        SqlParameter sqlParameter3 = new SqlParameter("@LinkID", SqlDbType.VarChar, 50);
        sqlParameter3.Value = (object) model.LinkID;
        sqlParameter10 = sqlParameter3;
      }
      else
      {
        sqlParameter10 = new SqlParameter("@LinkID", SqlDbType.VarChar, 50);
        sqlParameter10.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index9] = sqlParameter10;
      int index10 = 9;
      SqlParameter sqlParameter11 = new SqlParameter("@Type", SqlDbType.Int, -1);
      sqlParameter11.Value = (object) model.Type;
      sqlParameterArray[index10] = sqlParameter11;
      int index11 = 10;
      SqlParameter sqlParameter12;
      if (model.Files != null)
      {
        SqlParameter sqlParameter3 = new SqlParameter("@Files", SqlDbType.VarChar, -1);
        sqlParameter3.Value = (object) model.Files;
        sqlParameter12 = sqlParameter3;
      }
      else
      {
        sqlParameter12 = new SqlParameter("@Files", SqlDbType.VarChar, -1);
        sqlParameter12.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index11] = sqlParameter12;
      int index12 = 11;
      SqlParameter sqlParameter13 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter13.Value = (object) model.ID;
      sqlParameterArray[index12] = sqlParameter13;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM ShortMessage WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.ShortMessage> DataReaderToList(SqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.ShortMessage> shortMessageList = new List<RoadFlow.Data.Model.ShortMessage>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.ShortMessage shortMessage = new RoadFlow.Data.Model.ShortMessage();
        shortMessage.ID = dataReader.GetGuid(0);
        shortMessage.Title = dataReader.GetString(1);
        if (!dataReader.IsDBNull(2))
          shortMessage.Contents = dataReader.GetString(2);
        shortMessage.SendUserID = dataReader.GetGuid(3);
        shortMessage.SendUserName = dataReader.GetString(4);
        shortMessage.ReceiveUserID = dataReader.GetGuid(5);
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
      SqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT *,0 AS Status FROM ShortMessage");
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
      string sql = "SELECT *,0 AS Status FROM ShortMessage WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.ShortMessage> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.ShortMessage) null;
      return list[0];
    }

    public RoadFlow.Data.Model.ShortMessage GetRead(Guid id)
    {
      string sql = "SELECT *,0 AS Status FROM ShortMessage1 WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.ShortMessage> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.ShortMessage) null;
      return list[0];
    }

    public List<RoadFlow.Data.Model.ShortMessage> GetAllNoRead()
    {
      SqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT *,0 AS Status FROM ShortMessage");
      List<RoadFlow.Data.Model.ShortMessage> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.ShortMessage> GetAllNoReadByUserID(Guid userID)
    {
      string sql = "SELECT *,0 AS Status FROM ShortMessage WHERE ReceiveUserID=@ReceiveUserID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ReceiveUserID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) userID;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.ShortMessage> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public int UpdateStatus(Guid id)
    {
      string sql = "INSERT INTO ShortMessage1 SELECT * FROM ShortMessage WHERE ID=@ID;DELETE FROM ShortMessage WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public List<RoadFlow.Data.Model.ShortMessage> GetList(out string pager, int[] status, string query = "", string title = "", string contents = "", string senderID = "", string date1 = "", string date2 = "", string receiveID = "")
    {
      List<SqlParameter> sqlParameterList = new List<SqlParameter>();
      string str = string.Empty;
      if (status.Length == 1 && status[0] == 0)
        str = "SELECT *,0 AS Status,ROW_NUMBER() OVER(ORDER BY SendTime DESC) AS PagerAutoRowNumber FROM ShortMessage WHERE 1=1";
      else if (status.Length == 1 && status[0] == 1)
        str = "SELECT *,1 AS Status,ROW_NUMBER() OVER(ORDER BY SendTime DESC) AS PagerAutoRowNumber FROM ShortMessage1 WHERE 1=1";
      else if (status.Length == 2)
        str = "SELECT *,ROW_NUMBER() OVER(ORDER BY SendTime DESC) AS PagerAutoRowNumber FROM(SELECT *,0 AS Status FROM ShortMessage WHERE 1=1 UNION ALL SELECT *,1 AS Status FROM ShortMessage1 WHERE 1=1) temp WHERE 1=1";
      StringBuilder stringBuilder = new StringBuilder(str);
      if (receiveID.IsGuid())
      {
        stringBuilder.Append(" AND ReceiveUserID=@ReceiveUserID");
        sqlParameterList.Add(new SqlParameter("@ReceiveUserID", (object) receiveID));
      }
      if (!title.IsNullOrEmpty())
      {
        stringBuilder.Append(" AND CHARINDEX(@Title,Title)>0");
        sqlParameterList.Add(new SqlParameter("@Title", (object) title));
      }
      if (!contents.IsNullOrEmpty())
      {
        stringBuilder.Append(" AND CHARINDEX(@Contents,Contents)>0");
        sqlParameterList.Add(new SqlParameter("@Contents", (object) contents));
      }
      if (!senderID.IsNullOrEmpty())
        stringBuilder.AppendFormat(" AND SendUserID IN({0})", (object) senderID);
      if (date1.IsDateTime())
      {
        stringBuilder.Append(" AND SendTime>=@SendTime");
        sqlParameterList.Add(new SqlParameter("@SendTime", (object) date1.ToDateTime()));
      }
      if (date2.IsDateTime())
      {
        stringBuilder.Append(" AND SendTime<=@SendTime1");
        sqlParameterList.Add(new SqlParameter("@SendTime1", (object) date2.ToDateTime().AddDays(1.0).ToDateString()));
      }
      int pageSize = Tools.GetPageSize();
      int pageNumber = Tools.GetPageNumber();
      long count;
      string paerSql = this.dbHelper.GetPaerSql(stringBuilder.ToString(), pageSize, pageNumber, out count, sqlParameterList.ToArray());
      pager = Tools.GetPagerHtml(count, pageSize, pageNumber, query);
      SqlDataReader dataReader = this.dbHelper.GetDataReader(paerSql, sqlParameterList.ToArray());
      List<RoadFlow.Data.Model.ShortMessage> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.ShortMessage> GetList(out long count, int[] status, int size, int number, string title = "", string contents = "", string senderID = "", string date1 = "", string date2 = "", string receiveID = "", string order = "")
    {
      List<SqlParameter> sqlParameterList = new List<SqlParameter>();
      string str = string.Empty;
      if (status.Length == 1 && status[0] == 0)
        str = "SELECT *,0 AS Status,ROW_NUMBER() OVER(ORDER BY " + (order.IsNullOrEmpty() ? "SendTime DESC" : order) + ") AS PagerAutoRowNumber FROM ShortMessage WHERE 1=1";
      else if (status.Length == 1 && status[0] == 1)
        str = "SELECT *,1 AS Status,ROW_NUMBER() OVER(ORDER BY " + (order.IsNullOrEmpty() ? "SendTime DESC" : order) + ") AS PagerAutoRowNumber FROM ShortMessage1 WHERE 1=1";
      else if (status.Length == 2)
        str = "SELECT *,ROW_NUMBER() OVER(ORDER BY " + (order.IsNullOrEmpty() ? "SendTime DESC" : order) + ") AS PagerAutoRowNumber FROM(SELECT *,0 AS Status FROM ShortMessage WHERE 1=1 UNION ALL SELECT *,1 AS Status FROM ShortMessage1 WHERE 1=1) temp WHERE 1=1";
      StringBuilder stringBuilder = new StringBuilder(str);
      if (receiveID.IsGuid())
      {
        stringBuilder.Append(" AND ReceiveUserID=@ReceiveUserID");
        sqlParameterList.Add(new SqlParameter("@ReceiveUserID", (object) receiveID));
      }
      if (!title.IsNullOrEmpty())
      {
        stringBuilder.Append(" AND CHARINDEX(@Title,Title)>0");
        sqlParameterList.Add(new SqlParameter("@Title", (object) title));
      }
      if (!contents.IsNullOrEmpty())
      {
        stringBuilder.Append(" AND CHARINDEX(@Contents,Contents)>0");
        sqlParameterList.Add(new SqlParameter("@Contents", (object) contents));
      }
      if (!senderID.IsNullOrEmpty())
        stringBuilder.AppendFormat(" AND SendUserID IN({0})", (object) senderID);
      if (date1.IsDateTime())
      {
        stringBuilder.Append(" AND SendTime>=@SendTime");
        sqlParameterList.Add(new SqlParameter("@SendTime", (object) date1.ToDateTime()));
      }
      if (date2.IsDateTime())
      {
        stringBuilder.Append(" AND SendTime<=@SendTime1");
        sqlParameterList.Add(new SqlParameter("@SendTime1", (object) date2.ToDateTime().AddDays(1.0).ToDateString()));
      }
      SqlDataReader dataReader = this.dbHelper.GetDataReader(this.dbHelper.GetPaerSql(stringBuilder.ToString(), size, number, out count, sqlParameterList.ToArray()), sqlParameterList.ToArray());
      List<RoadFlow.Data.Model.ShortMessage> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public int Delete(string linkID, int Type)
    {
      string sql = "DELETE FROM ShortMessage WHERE LinkID=@LinkID AND Type=@Type";
      SqlParameter[] sqlParameterArray = new SqlParameter[2];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@LinkID", SqlDbType.VarChar);
      sqlParameter1.Value = (object) linkID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@Type", SqlDbType.Int);
      sqlParameter2.Value = (object) Type;
      sqlParameterArray[index2] = sqlParameter2;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }
  }
}
