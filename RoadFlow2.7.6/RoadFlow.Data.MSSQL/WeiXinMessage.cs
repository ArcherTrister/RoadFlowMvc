// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MSSQL.WeiXinMessage
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
  public class WeiXinMessage : IWeiXinMessage
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.WeiXinMessage model)
    {
      string sql = "INSERT INTO WeiXinMessage\r\n\t\t\t\t(ID,ToUserName,FromUserName,CreateTime,CreateTime1,MsgType,MsgId,AgentID,Contents,PicUrl,MediaId,Format,ThumbMediaId,Location_X,Location_Y,Scale,Label,Title,Description,AddTime) \r\n\t\t\t\tVALUES(@ID,@ToUserName,@FromUserName,@CreateTime,@CreateTime1,@MsgType,@MsgId,@AgentID,@Contents,@PicUrl,@MediaId,@Format,@ThumbMediaId,@Location_X,@Location_Y,@Scale,@Label,@Title,@Description,@AddTime)";
      SqlParameter[] sqlParameterArray = new SqlParameter[20];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter1.Value = (object) model.ID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@ToUserName", SqlDbType.VarChar, 200);
      sqlParameter2.Value = (object) model.ToUserName;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@FromUserName", SqlDbType.VarChar, 200);
      sqlParameter3.Value = (object) model.FromUserName;
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter4 = new SqlParameter("@CreateTime", SqlDbType.Int, -1);
      sqlParameter4.Value = (object) model.CreateTime;
      sqlParameterArray[index4] = sqlParameter4;
      int index5 = 4;
      SqlParameter sqlParameter5 = new SqlParameter("@CreateTime1", SqlDbType.DateTime, 8);
      sqlParameter5.Value = (object) model.CreateTime1;
      sqlParameterArray[index5] = sqlParameter5;
      int index6 = 5;
      SqlParameter sqlParameter6 = new SqlParameter("@MsgType", SqlDbType.VarChar, 50);
      sqlParameter6.Value = (object) model.MsgType;
      sqlParameterArray[index6] = sqlParameter6;
      int index7 = 6;
      SqlParameter sqlParameter7 = new SqlParameter("@MsgId", SqlDbType.BigInt, -1);
      sqlParameter7.Value = (object) model.MsgId;
      sqlParameterArray[index7] = sqlParameter7;
      int index8 = 7;
      SqlParameter sqlParameter8 = new SqlParameter("@AgentID", SqlDbType.Int, -1);
      sqlParameter8.Value = (object) model.AgentID;
      sqlParameterArray[index8] = sqlParameter8;
      int index9 = 8;
      SqlParameter sqlParameter9;
      if (model.Contents != null)
      {
        SqlParameter sqlParameter10 = new SqlParameter("@Contents", SqlDbType.NVarChar, -1);
        sqlParameter10.Value = (object) model.Contents;
        sqlParameter9 = sqlParameter10;
      }
      else
      {
        sqlParameter9 = new SqlParameter("@Contents", SqlDbType.NVarChar, -1);
        sqlParameter9.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index9] = sqlParameter9;
      int index10 = 9;
      SqlParameter sqlParameter11;
      if (model.PicUrl != null)
      {
        SqlParameter sqlParameter10 = new SqlParameter("@PicUrl", SqlDbType.VarChar, 500);
        sqlParameter10.Value = (object) model.PicUrl;
        sqlParameter11 = sqlParameter10;
      }
      else
      {
        sqlParameter11 = new SqlParameter("@PicUrl", SqlDbType.VarChar, 500);
        sqlParameter11.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index10] = sqlParameter11;
      int index11 = 10;
      SqlParameter sqlParameter12;
      if (model.MediaId != null)
      {
        SqlParameter sqlParameter10 = new SqlParameter("@MediaId", SqlDbType.VarChar, 500);
        sqlParameter10.Value = (object) model.MediaId;
        sqlParameter12 = sqlParameter10;
      }
      else
      {
        sqlParameter12 = new SqlParameter("@MediaId", SqlDbType.VarChar, 500);
        sqlParameter12.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index11] = sqlParameter12;
      int index12 = 11;
      SqlParameter sqlParameter13;
      if (model.Format != null)
      {
        SqlParameter sqlParameter10 = new SqlParameter("@Format", SqlDbType.VarChar, 50);
        sqlParameter10.Value = (object) model.Format;
        sqlParameter13 = sqlParameter10;
      }
      else
      {
        sqlParameter13 = new SqlParameter("@Format", SqlDbType.VarChar, 50);
        sqlParameter13.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index12] = sqlParameter13;
      int index13 = 12;
      SqlParameter sqlParameter14;
      if (model.ThumbMediaId != null)
      {
        SqlParameter sqlParameter10 = new SqlParameter("@ThumbMediaId", SqlDbType.VarChar, 50);
        sqlParameter10.Value = (object) model.ThumbMediaId;
        sqlParameter14 = sqlParameter10;
      }
      else
      {
        sqlParameter14 = new SqlParameter("@ThumbMediaId", SqlDbType.VarChar, 50);
        sqlParameter14.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index13] = sqlParameter14;
      int index14 = 13;
      SqlParameter sqlParameter15;
      if (model.Location_X != null)
      {
        SqlParameter sqlParameter10 = new SqlParameter("@Location_X", SqlDbType.VarChar, 50);
        sqlParameter10.Value = (object) model.Location_X;
        sqlParameter15 = sqlParameter10;
      }
      else
      {
        sqlParameter15 = new SqlParameter("@Location_X", SqlDbType.VarChar, 50);
        sqlParameter15.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index14] = sqlParameter15;
      int index15 = 14;
      SqlParameter sqlParameter16;
      if (model.Location_Y != null)
      {
        SqlParameter sqlParameter10 = new SqlParameter("@Location_Y", SqlDbType.VarChar, 50);
        sqlParameter10.Value = (object) model.Location_Y;
        sqlParameter16 = sqlParameter10;
      }
      else
      {
        sqlParameter16 = new SqlParameter("@Location_Y", SqlDbType.VarChar, 50);
        sqlParameter16.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index15] = sqlParameter16;
      int index16 = 15;
      SqlParameter sqlParameter17;
      if (model.Scale != null)
      {
        SqlParameter sqlParameter10 = new SqlParameter("@Scale", SqlDbType.VarChar, 50);
        sqlParameter10.Value = (object) model.Scale;
        sqlParameter17 = sqlParameter10;
      }
      else
      {
        sqlParameter17 = new SqlParameter("@Scale", SqlDbType.VarChar, 50);
        sqlParameter17.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index16] = sqlParameter17;
      int index17 = 16;
      SqlParameter sqlParameter18;
      if (model.Label != null)
      {
        SqlParameter sqlParameter10 = new SqlParameter("@Label", SqlDbType.NVarChar, 1000);
        sqlParameter10.Value = (object) model.Label;
        sqlParameter18 = sqlParameter10;
      }
      else
      {
        sqlParameter18 = new SqlParameter("@Label", SqlDbType.NVarChar, 1000);
        sqlParameter18.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index17] = sqlParameter18;
      int index18 = 17;
      SqlParameter sqlParameter19;
      if (model.Title != null)
      {
        SqlParameter sqlParameter10 = new SqlParameter("@Title", SqlDbType.NVarChar, 1000);
        sqlParameter10.Value = (object) model.Title;
        sqlParameter19 = sqlParameter10;
      }
      else
      {
        sqlParameter19 = new SqlParameter("@Title", SqlDbType.NVarChar, 1000);
        sqlParameter19.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index18] = sqlParameter19;
      int index19 = 18;
      SqlParameter sqlParameter20;
      if (model.Description != null)
      {
        SqlParameter sqlParameter10 = new SqlParameter("@Description", SqlDbType.NVarChar, 2000);
        sqlParameter10.Value = (object) model.Description;
        sqlParameter20 = sqlParameter10;
      }
      else
      {
        sqlParameter20 = new SqlParameter("@Description", SqlDbType.NVarChar, 2000);
        sqlParameter20.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index19] = sqlParameter20;
      int index20 = 19;
      SqlParameter sqlParameter21 = new SqlParameter("@AddTime", SqlDbType.DateTime, 8);
      sqlParameter21.Value = (object) model.AddTime;
      sqlParameterArray[index20] = sqlParameter21;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.WeiXinMessage model)
    {
      string sql = "UPDATE WeiXinMessage SET \r\n\t\t\t\tToUserName=@ToUserName,FromUserName=@FromUserName,CreateTime=@CreateTime,CreateTime1=@CreateTime1,MsgType=@MsgType,MsgId=@MsgId,AgentID=@AgentID,Contents=@Contents,PicUrl=@PicUrl,MediaId=@MediaId,Format=@Format,ThumbMediaId=@ThumbMediaId,Location_X=@Location_X,Location_Y=@Location_Y,Scale=@Scale,Label=@Label,Title=@Title,Description=@Description,AddTime=@AddTime\r\n\t\t\t\tWHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[20];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@ToUserName", SqlDbType.VarChar, 200);
      sqlParameter1.Value = (object) model.ToUserName;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@FromUserName", SqlDbType.VarChar, 200);
      sqlParameter2.Value = (object) model.FromUserName;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@CreateTime", SqlDbType.Int, -1);
      sqlParameter3.Value = (object) model.CreateTime;
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter4 = new SqlParameter("@CreateTime1", SqlDbType.DateTime, 8);
      sqlParameter4.Value = (object) model.CreateTime1;
      sqlParameterArray[index4] = sqlParameter4;
      int index5 = 4;
      SqlParameter sqlParameter5 = new SqlParameter("@MsgType", SqlDbType.VarChar, 50);
      sqlParameter5.Value = (object) model.MsgType;
      sqlParameterArray[index5] = sqlParameter5;
      int index6 = 5;
      SqlParameter sqlParameter6 = new SqlParameter("@MsgId", SqlDbType.BigInt, -1);
      sqlParameter6.Value = (object) model.MsgId;
      sqlParameterArray[index6] = sqlParameter6;
      int index7 = 6;
      SqlParameter sqlParameter7 = new SqlParameter("@AgentID", SqlDbType.Int, -1);
      sqlParameter7.Value = (object) model.AgentID;
      sqlParameterArray[index7] = sqlParameter7;
      int index8 = 7;
      SqlParameter sqlParameter8;
      if (model.Contents != null)
      {
        SqlParameter sqlParameter9 = new SqlParameter("@Contents", SqlDbType.NVarChar, -1);
        sqlParameter9.Value = (object) model.Contents;
        sqlParameter8 = sqlParameter9;
      }
      else
      {
        sqlParameter8 = new SqlParameter("@Contents", SqlDbType.NVarChar, -1);
        sqlParameter8.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index8] = sqlParameter8;
      int index9 = 8;
      SqlParameter sqlParameter10;
      if (model.PicUrl != null)
      {
        SqlParameter sqlParameter9 = new SqlParameter("@PicUrl", SqlDbType.VarChar, 500);
        sqlParameter9.Value = (object) model.PicUrl;
        sqlParameter10 = sqlParameter9;
      }
      else
      {
        sqlParameter10 = new SqlParameter("@PicUrl", SqlDbType.VarChar, 500);
        sqlParameter10.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index9] = sqlParameter10;
      int index10 = 9;
      SqlParameter sqlParameter11;
      if (model.MediaId != null)
      {
        SqlParameter sqlParameter9 = new SqlParameter("@MediaId", SqlDbType.VarChar, 500);
        sqlParameter9.Value = (object) model.MediaId;
        sqlParameter11 = sqlParameter9;
      }
      else
      {
        sqlParameter11 = new SqlParameter("@MediaId", SqlDbType.VarChar, 500);
        sqlParameter11.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index10] = sqlParameter11;
      int index11 = 10;
      SqlParameter sqlParameter12;
      if (model.Format != null)
      {
        SqlParameter sqlParameter9 = new SqlParameter("@Format", SqlDbType.VarChar, 50);
        sqlParameter9.Value = (object) model.Format;
        sqlParameter12 = sqlParameter9;
      }
      else
      {
        sqlParameter12 = new SqlParameter("@Format", SqlDbType.VarChar, 50);
        sqlParameter12.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index11] = sqlParameter12;
      int index12 = 11;
      SqlParameter sqlParameter13;
      if (model.ThumbMediaId != null)
      {
        SqlParameter sqlParameter9 = new SqlParameter("@ThumbMediaId", SqlDbType.VarChar, 50);
        sqlParameter9.Value = (object) model.ThumbMediaId;
        sqlParameter13 = sqlParameter9;
      }
      else
      {
        sqlParameter13 = new SqlParameter("@ThumbMediaId", SqlDbType.VarChar, 50);
        sqlParameter13.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index12] = sqlParameter13;
      int index13 = 12;
      SqlParameter sqlParameter14;
      if (model.Location_X != null)
      {
        SqlParameter sqlParameter9 = new SqlParameter("@Location_X", SqlDbType.VarChar, 50);
        sqlParameter9.Value = (object) model.Location_X;
        sqlParameter14 = sqlParameter9;
      }
      else
      {
        sqlParameter14 = new SqlParameter("@Location_X", SqlDbType.VarChar, 50);
        sqlParameter14.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index13] = sqlParameter14;
      int index14 = 13;
      SqlParameter sqlParameter15;
      if (model.Location_Y != null)
      {
        SqlParameter sqlParameter9 = new SqlParameter("@Location_Y", SqlDbType.VarChar, 50);
        sqlParameter9.Value = (object) model.Location_Y;
        sqlParameter15 = sqlParameter9;
      }
      else
      {
        sqlParameter15 = new SqlParameter("@Location_Y", SqlDbType.VarChar, 50);
        sqlParameter15.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index14] = sqlParameter15;
      int index15 = 14;
      SqlParameter sqlParameter16;
      if (model.Scale != null)
      {
        SqlParameter sqlParameter9 = new SqlParameter("@Scale", SqlDbType.VarChar, 50);
        sqlParameter9.Value = (object) model.Scale;
        sqlParameter16 = sqlParameter9;
      }
      else
      {
        sqlParameter16 = new SqlParameter("@Scale", SqlDbType.VarChar, 50);
        sqlParameter16.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index15] = sqlParameter16;
      int index16 = 15;
      SqlParameter sqlParameter17;
      if (model.Label != null)
      {
        SqlParameter sqlParameter9 = new SqlParameter("@Label", SqlDbType.NVarChar, 1000);
        sqlParameter9.Value = (object) model.Label;
        sqlParameter17 = sqlParameter9;
      }
      else
      {
        sqlParameter17 = new SqlParameter("@Label", SqlDbType.NVarChar, 1000);
        sqlParameter17.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index16] = sqlParameter17;
      int index17 = 16;
      SqlParameter sqlParameter18;
      if (model.Title != null)
      {
        SqlParameter sqlParameter9 = new SqlParameter("@Title", SqlDbType.NVarChar, 1000);
        sqlParameter9.Value = (object) model.Title;
        sqlParameter18 = sqlParameter9;
      }
      else
      {
        sqlParameter18 = new SqlParameter("@Title", SqlDbType.NVarChar, 1000);
        sqlParameter18.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index17] = sqlParameter18;
      int index18 = 17;
      SqlParameter sqlParameter19;
      if (model.Description != null)
      {
        SqlParameter sqlParameter9 = new SqlParameter("@Description", SqlDbType.NVarChar, 2000);
        sqlParameter9.Value = (object) model.Description;
        sqlParameter19 = sqlParameter9;
      }
      else
      {
        sqlParameter19 = new SqlParameter("@Description", SqlDbType.NVarChar, 2000);
        sqlParameter19.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index18] = sqlParameter19;
      int index19 = 18;
      SqlParameter sqlParameter20 = new SqlParameter("@AddTime", SqlDbType.DateTime, 8);
      sqlParameter20.Value = (object) model.AddTime;
      sqlParameterArray[index19] = sqlParameter20;
      int index20 = 19;
      SqlParameter sqlParameter21 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter21.Value = (object) model.ID;
      sqlParameterArray[index20] = sqlParameter21;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM WeiXinMessage WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.WeiXinMessage> DataReaderToList(SqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.WeiXinMessage> weiXinMessageList = new List<RoadFlow.Data.Model.WeiXinMessage>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.WeiXinMessage weiXinMessage = new RoadFlow.Data.Model.WeiXinMessage();
        weiXinMessage.ID = dataReader.GetGuid(0);
        weiXinMessage.ToUserName = dataReader.GetString(1);
        weiXinMessage.CreateTime = dataReader.GetInt32(3);
        weiXinMessage.CreateTime1 = dataReader.GetDateTime(4);
        weiXinMessage.MsgType = dataReader.GetString(5);
        weiXinMessage.MsgId = dataReader.GetInt64(6);
        weiXinMessage.AgentID = dataReader.GetInt32(7);
        if (!dataReader.IsDBNull(8))
          weiXinMessage.Contents = dataReader.GetString(8);
        if (!dataReader.IsDBNull(9))
          weiXinMessage.PicUrl = dataReader.GetString(9);
        if (!dataReader.IsDBNull(10))
          weiXinMessage.MediaId = dataReader.GetString(10);
        if (!dataReader.IsDBNull(11))
          weiXinMessage.Format = dataReader.GetString(11);
        if (!dataReader.IsDBNull(12))
          weiXinMessage.ThumbMediaId = dataReader.GetString(12);
        if (!dataReader.IsDBNull(13))
          weiXinMessage.Location_X = dataReader.GetString(13);
        if (!dataReader.IsDBNull(14))
          weiXinMessage.Location_Y = dataReader.GetString(14);
        if (!dataReader.IsDBNull(15))
          weiXinMessage.Scale = dataReader.GetString(15);
        if (!dataReader.IsDBNull(16))
          weiXinMessage.Label = dataReader.GetString(16);
        if (!dataReader.IsDBNull(17))
          weiXinMessage.Title = dataReader.GetString(17);
        if (!dataReader.IsDBNull(18))
          weiXinMessage.Description = dataReader.GetString(18);
        weiXinMessage.AddTime = dataReader.GetDateTime(19);
        weiXinMessageList.Add(weiXinMessage);
      }
      return weiXinMessageList;
    }

    public List<RoadFlow.Data.Model.WeiXinMessage> GetAll()
    {
      SqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM WeiXinMessage");
      List<RoadFlow.Data.Model.WeiXinMessage> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM WeiXinMessage"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.WeiXinMessage Get(Guid id)
    {
      string sql = "SELECT * FROM WeiXinMessage WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WeiXinMessage> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.WeiXinMessage) null;
      return list[0];
    }
  }
}
