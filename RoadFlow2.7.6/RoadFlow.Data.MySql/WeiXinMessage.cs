// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MySql.WeiXinMessage
// Assembly: RoadFlow.Data.MySql, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 29B652D7-5F6F-4A7D-AD1C-9F2C643FD784
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.MySql.dll

using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.MySql
{
  public class WeiXinMessage : IWeiXinMessage
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.WeiXinMessage model)
    {
      string sql = "INSERT INTO WeiXinMessage\r\n\t\t\t\t(ID,ToUserName,FromUserName,CreateTime,CreateTime1,MsgType,MsgId,AgentID,Contents,PicUrl,MediaId,Format,ThumbMediaId,Location_X,Location_Y,Scale,Label,Title,Description,AddTime) \r\n\t\t\t\tVALUES(@ID,@ToUserName,@FromUserName,@CreateTime,@CreateTime1,@MsgType,@MsgId,@AgentID,@Contents,@PicUrl,@MediaId,@Format,@ThumbMediaId,@Location_X,@Location_Y,@Scale,@Label,@Title,@Description,@AddTime)";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[20];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter1.Value = (object) model.ID;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@ToUserName", MySqlDbType.VarChar, 200);
      mySqlParameter2.Value = (object) model.ToUserName;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@FromUserName", MySqlDbType.VarChar, 200);
      mySqlParameter3.Value = (object) model.FromUserName;
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter4 = new MySqlParameter("@CreateTime", MySqlDbType.Int32, -1);
      mySqlParameter4.Value = (object) model.CreateTime;
      mySqlParameterArray[index4] = mySqlParameter4;
      int index5 = 4;
      MySqlParameter mySqlParameter5 = new MySqlParameter("@CreateTime1", MySqlDbType.DateTime, 8);
      mySqlParameter5.Value = (object) model.CreateTime1;
      mySqlParameterArray[index5] = mySqlParameter5;
      int index6 = 5;
      MySqlParameter mySqlParameter6 = new MySqlParameter("@MsgType", MySqlDbType.VarChar, 50);
      mySqlParameter6.Value = (object) model.MsgType;
      mySqlParameterArray[index6] = mySqlParameter6;
      int index7 = 6;
      MySqlParameter mySqlParameter7 = new MySqlParameter("@MsgId", MySqlDbType.Int64, -1);
      mySqlParameter7.Value = (object) model.MsgId;
      mySqlParameterArray[index7] = mySqlParameter7;
      int index8 = 7;
      MySqlParameter mySqlParameter8 = new MySqlParameter("@AgentID", MySqlDbType.Int32, -1);
      mySqlParameter8.Value = (object) model.AgentID;
      mySqlParameterArray[index8] = mySqlParameter8;
      int index9 = 8;
      MySqlParameter mySqlParameter9;
      if (model.Contents != null)
      {
        MySqlParameter mySqlParameter10 = new MySqlParameter("@Contents", MySqlDbType.VarChar, -1);
        mySqlParameter10.Value = (object) model.Contents;
        mySqlParameter9 = mySqlParameter10;
      }
      else
      {
        mySqlParameter9 = new MySqlParameter("@Contents", MySqlDbType.VarChar, -1);
        mySqlParameter9.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index9] = mySqlParameter9;
      int index10 = 9;
      MySqlParameter mySqlParameter11;
      if (model.PicUrl != null)
      {
        MySqlParameter mySqlParameter10 = new MySqlParameter("@PicUrl", MySqlDbType.VarChar, 500);
        mySqlParameter10.Value = (object) model.PicUrl;
        mySqlParameter11 = mySqlParameter10;
      }
      else
      {
        mySqlParameter11 = new MySqlParameter("@PicUrl", MySqlDbType.VarChar, 500);
        mySqlParameter11.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index10] = mySqlParameter11;
      int index11 = 10;
      MySqlParameter mySqlParameter12;
      if (model.MediaId != null)
      {
        MySqlParameter mySqlParameter10 = new MySqlParameter("@MediaId", MySqlDbType.VarChar, 500);
        mySqlParameter10.Value = (object) model.MediaId;
        mySqlParameter12 = mySqlParameter10;
      }
      else
      {
        mySqlParameter12 = new MySqlParameter("@MediaId", MySqlDbType.VarChar, 500);
        mySqlParameter12.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index11] = mySqlParameter12;
      int index12 = 11;
      MySqlParameter mySqlParameter13;
      if (model.Format != null)
      {
        MySqlParameter mySqlParameter10 = new MySqlParameter("@Format", MySqlDbType.VarChar, 50);
        mySqlParameter10.Value = (object) model.Format;
        mySqlParameter13 = mySqlParameter10;
      }
      else
      {
        mySqlParameter13 = new MySqlParameter("@Format", MySqlDbType.VarChar, 50);
        mySqlParameter13.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index12] = mySqlParameter13;
      int index13 = 12;
      MySqlParameter mySqlParameter14;
      if (model.ThumbMediaId != null)
      {
        MySqlParameter mySqlParameter10 = new MySqlParameter("@ThumbMediaId", MySqlDbType.VarChar, 50);
        mySqlParameter10.Value = (object) model.ThumbMediaId;
        mySqlParameter14 = mySqlParameter10;
      }
      else
      {
        mySqlParameter14 = new MySqlParameter("@ThumbMediaId", MySqlDbType.VarChar, 50);
        mySqlParameter14.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index13] = mySqlParameter14;
      int index14 = 13;
      MySqlParameter mySqlParameter15;
      if (model.Location_X != null)
      {
        MySqlParameter mySqlParameter10 = new MySqlParameter("@Location_X", MySqlDbType.VarChar, 50);
        mySqlParameter10.Value = (object) model.Location_X;
        mySqlParameter15 = mySqlParameter10;
      }
      else
      {
        mySqlParameter15 = new MySqlParameter("@Location_X", MySqlDbType.VarChar, 50);
        mySqlParameter15.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index14] = mySqlParameter15;
      int index15 = 14;
      MySqlParameter mySqlParameter16;
      if (model.Location_Y != null)
      {
        MySqlParameter mySqlParameter10 = new MySqlParameter("@Location_Y", MySqlDbType.VarChar, 50);
        mySqlParameter10.Value = (object) model.Location_Y;
        mySqlParameter16 = mySqlParameter10;
      }
      else
      {
        mySqlParameter16 = new MySqlParameter("@Location_Y", MySqlDbType.VarChar, 50);
        mySqlParameter16.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index15] = mySqlParameter16;
      int index16 = 15;
      MySqlParameter mySqlParameter17;
      if (model.Scale != null)
      {
        MySqlParameter mySqlParameter10 = new MySqlParameter("@Scale", MySqlDbType.VarChar, 50);
        mySqlParameter10.Value = (object) model.Scale;
        mySqlParameter17 = mySqlParameter10;
      }
      else
      {
        mySqlParameter17 = new MySqlParameter("@Scale", MySqlDbType.VarChar, 50);
        mySqlParameter17.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index16] = mySqlParameter17;
      int index17 = 16;
      MySqlParameter mySqlParameter18;
      if (model.Label != null)
      {
        MySqlParameter mySqlParameter10 = new MySqlParameter("@Label", MySqlDbType.VarChar, 1000);
        mySqlParameter10.Value = (object) model.Label;
        mySqlParameter18 = mySqlParameter10;
      }
      else
      {
        mySqlParameter18 = new MySqlParameter("@Label", MySqlDbType.VarChar, 1000);
        mySqlParameter18.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index17] = mySqlParameter18;
      int index18 = 17;
      MySqlParameter mySqlParameter19;
      if (model.Title != null)
      {
        MySqlParameter mySqlParameter10 = new MySqlParameter("@Title", MySqlDbType.VarChar, 1000);
        mySqlParameter10.Value = (object) model.Title;
        mySqlParameter19 = mySqlParameter10;
      }
      else
      {
        mySqlParameter19 = new MySqlParameter("@Title", MySqlDbType.VarChar, 1000);
        mySqlParameter19.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index18] = mySqlParameter19;
      int index19 = 18;
      MySqlParameter mySqlParameter20;
      if (model.Description != null)
      {
        MySqlParameter mySqlParameter10 = new MySqlParameter("@Description", MySqlDbType.VarChar, 2000);
        mySqlParameter10.Value = (object) model.Description;
        mySqlParameter20 = mySqlParameter10;
      }
      else
      {
        mySqlParameter20 = new MySqlParameter("@Description", MySqlDbType.VarChar, 2000);
        mySqlParameter20.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index19] = mySqlParameter20;
      int index20 = 19;
      MySqlParameter mySqlParameter21 = new MySqlParameter("@AddTime", MySqlDbType.DateTime, 8);
      mySqlParameter21.Value = (object) model.AddTime;
      mySqlParameterArray[index20] = mySqlParameter21;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.WeiXinMessage model)
    {
      string sql = "UPDATE WeiXinMessage SET \r\n\t\t\t\tToUserName=@ToUserName,FromUserName=@FromUserName,CreateTime=@CreateTime,CreateTime1=@CreateTime1,MsgType=@MsgType,MsgId=@MsgId,AgentID=@AgentID,Contents=@Contents,PicUrl=@PicUrl,MediaId=@MediaId,Format=@Format,ThumbMediaId=@ThumbMediaId,Location_X=@Location_X,Location_Y=@Location_Y,Scale=@Scale,Label=@Label,Title=@Title,Description=@Description,AddTime=@AddTime\r\n\t\t\t\tWHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[20];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@ToUserName", MySqlDbType.VarChar, 200);
      mySqlParameter1.Value = (object) model.ToUserName;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@FromUserName", MySqlDbType.VarChar, 200);
      mySqlParameter2.Value = (object) model.FromUserName;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@CreateTime", MySqlDbType.Int32, -1);
      mySqlParameter3.Value = (object) model.CreateTime;
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter4 = new MySqlParameter("@CreateTime1", MySqlDbType.DateTime, 8);
      mySqlParameter4.Value = (object) model.CreateTime1;
      mySqlParameterArray[index4] = mySqlParameter4;
      int index5 = 4;
      MySqlParameter mySqlParameter5 = new MySqlParameter("@MsgType", MySqlDbType.VarChar, 50);
      mySqlParameter5.Value = (object) model.MsgType;
      mySqlParameterArray[index5] = mySqlParameter5;
      int index6 = 5;
      MySqlParameter mySqlParameter6 = new MySqlParameter("@MsgId", MySqlDbType.Int64, -1);
      mySqlParameter6.Value = (object) model.MsgId;
      mySqlParameterArray[index6] = mySqlParameter6;
      int index7 = 6;
      MySqlParameter mySqlParameter7 = new MySqlParameter("@AgentID", MySqlDbType.Int32, -1);
      mySqlParameter7.Value = (object) model.AgentID;
      mySqlParameterArray[index7] = mySqlParameter7;
      int index8 = 7;
      MySqlParameter mySqlParameter8;
      if (model.Contents != null)
      {
        MySqlParameter mySqlParameter9 = new MySqlParameter("@Contents", MySqlDbType.VarChar, -1);
        mySqlParameter9.Value = (object) model.Contents;
        mySqlParameter8 = mySqlParameter9;
      }
      else
      {
        mySqlParameter8 = new MySqlParameter("@Contents", MySqlDbType.VarChar, -1);
        mySqlParameter8.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index8] = mySqlParameter8;
      int index9 = 8;
      MySqlParameter mySqlParameter10;
      if (model.PicUrl != null)
      {
        MySqlParameter mySqlParameter9 = new MySqlParameter("@PicUrl", MySqlDbType.VarChar, 500);
        mySqlParameter9.Value = (object) model.PicUrl;
        mySqlParameter10 = mySqlParameter9;
      }
      else
      {
        mySqlParameter10 = new MySqlParameter("@PicUrl", MySqlDbType.VarChar, 500);
        mySqlParameter10.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index9] = mySqlParameter10;
      int index10 = 9;
      MySqlParameter mySqlParameter11;
      if (model.MediaId != null)
      {
        MySqlParameter mySqlParameter9 = new MySqlParameter("@MediaId", MySqlDbType.VarChar, 500);
        mySqlParameter9.Value = (object) model.MediaId;
        mySqlParameter11 = mySqlParameter9;
      }
      else
      {
        mySqlParameter11 = new MySqlParameter("@MediaId", MySqlDbType.VarChar, 500);
        mySqlParameter11.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index10] = mySqlParameter11;
      int index11 = 10;
      MySqlParameter mySqlParameter12;
      if (model.Format != null)
      {
        MySqlParameter mySqlParameter9 = new MySqlParameter("@Format", MySqlDbType.VarChar, 50);
        mySqlParameter9.Value = (object) model.Format;
        mySqlParameter12 = mySqlParameter9;
      }
      else
      {
        mySqlParameter12 = new MySqlParameter("@Format", MySqlDbType.VarChar, 50);
        mySqlParameter12.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index11] = mySqlParameter12;
      int index12 = 11;
      MySqlParameter mySqlParameter13;
      if (model.ThumbMediaId != null)
      {
        MySqlParameter mySqlParameter9 = new MySqlParameter("@ThumbMediaId", MySqlDbType.VarChar, 50);
        mySqlParameter9.Value = (object) model.ThumbMediaId;
        mySqlParameter13 = mySqlParameter9;
      }
      else
      {
        mySqlParameter13 = new MySqlParameter("@ThumbMediaId", MySqlDbType.VarChar, 50);
        mySqlParameter13.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index12] = mySqlParameter13;
      int index13 = 12;
      MySqlParameter mySqlParameter14;
      if (model.Location_X != null)
      {
        MySqlParameter mySqlParameter9 = new MySqlParameter("@Location_X", MySqlDbType.VarChar, 50);
        mySqlParameter9.Value = (object) model.Location_X;
        mySqlParameter14 = mySqlParameter9;
      }
      else
      {
        mySqlParameter14 = new MySqlParameter("@Location_X", MySqlDbType.VarChar, 50);
        mySqlParameter14.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index13] = mySqlParameter14;
      int index14 = 13;
      MySqlParameter mySqlParameter15;
      if (model.Location_Y != null)
      {
        MySqlParameter mySqlParameter9 = new MySqlParameter("@Location_Y", MySqlDbType.VarChar, 50);
        mySqlParameter9.Value = (object) model.Location_Y;
        mySqlParameter15 = mySqlParameter9;
      }
      else
      {
        mySqlParameter15 = new MySqlParameter("@Location_Y", MySqlDbType.VarChar, 50);
        mySqlParameter15.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index14] = mySqlParameter15;
      int index15 = 14;
      MySqlParameter mySqlParameter16;
      if (model.Scale != null)
      {
        MySqlParameter mySqlParameter9 = new MySqlParameter("@Scale", MySqlDbType.VarChar, 50);
        mySqlParameter9.Value = (object) model.Scale;
        mySqlParameter16 = mySqlParameter9;
      }
      else
      {
        mySqlParameter16 = new MySqlParameter("@Scale", MySqlDbType.VarChar, 50);
        mySqlParameter16.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index15] = mySqlParameter16;
      int index16 = 15;
      MySqlParameter mySqlParameter17;
      if (model.Label != null)
      {
        MySqlParameter mySqlParameter9 = new MySqlParameter("@Label", MySqlDbType.VarChar, 1000);
        mySqlParameter9.Value = (object) model.Label;
        mySqlParameter17 = mySqlParameter9;
      }
      else
      {
        mySqlParameter17 = new MySqlParameter("@Label", MySqlDbType.VarChar, 1000);
        mySqlParameter17.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index16] = mySqlParameter17;
      int index17 = 16;
      MySqlParameter mySqlParameter18;
      if (model.Title != null)
      {
        MySqlParameter mySqlParameter9 = new MySqlParameter("@Title", MySqlDbType.VarChar, 1000);
        mySqlParameter9.Value = (object) model.Title;
        mySqlParameter18 = mySqlParameter9;
      }
      else
      {
        mySqlParameter18 = new MySqlParameter("@Title", MySqlDbType.VarChar, 1000);
        mySqlParameter18.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index17] = mySqlParameter18;
      int index18 = 17;
      MySqlParameter mySqlParameter19;
      if (model.Description != null)
      {
        MySqlParameter mySqlParameter9 = new MySqlParameter("@Description", MySqlDbType.VarChar, 2000);
        mySqlParameter9.Value = (object) model.Description;
        mySqlParameter19 = mySqlParameter9;
      }
      else
      {
        mySqlParameter19 = new MySqlParameter("@Description", MySqlDbType.VarChar, 2000);
        mySqlParameter19.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index18] = mySqlParameter19;
      int index19 = 18;
      MySqlParameter mySqlParameter20 = new MySqlParameter("@AddTime", MySqlDbType.DateTime, 8);
      mySqlParameter20.Value = (object) model.AddTime;
      mySqlParameterArray[index19] = mySqlParameter20;
      int index20 = 19;
      MySqlParameter mySqlParameter21 = new MySqlParameter("@ID", MySqlDbType.VarChar, -1);
      mySqlParameter21.Value = (object) model.ID;
      mySqlParameterArray[index20] = mySqlParameter21;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM WeiXinMessage WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) id;
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.WeiXinMessage> DataReaderToList(MySqlDataReader dataReader)
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
      MySqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM WeiXinMessage");
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
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) id;
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WeiXinMessage> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.WeiXinMessage) null;
      return list[0];
    }
  }
}
