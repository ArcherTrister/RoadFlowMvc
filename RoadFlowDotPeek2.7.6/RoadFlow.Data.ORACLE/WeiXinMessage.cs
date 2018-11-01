// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.ORACLE.WeiXinMessage
// Assembly: RoadFlow.Data.ORACLE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C9018AA1-E48E-4231-92A9-CD6F0F275D11
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.ORACLE.dll

using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.ORACLE
{
  public class WeiXinMessage : IWeiXinMessage
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.WeiXinMessage model)
    {
      string sql = "INSERT INTO WeiXinMessage\r\n\t\t\t\t(ID,ToUserName,FromUserName,CreateTime,CreateTime1,MsgType,MsgId,AgentID,Contents,PicUrl,MediaId,Format,ThumbMediaId,Location_X,Location_Y,Scale,Label,Title,Description,AddTime) \r\n\t\t\t\tVALUES(:ID,:ToUserName,:FromUserName,:CreateTime,:CreateTime1,:MsgType,:MsgId,:AgentID,:Contents,:PicUrl,:MediaId,:Format,:ThumbMediaId,:Location_X,:Location_Y,:Scale,:Label,:Title,:Description,:AddTime)";
      OracleParameter[] oracleParameterArray = new OracleParameter[20];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":ID", OracleDbType.Varchar2, 36);
      oracleParameter1.Value = (object) model.ID;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":ToUserName", OracleDbType.Varchar2, 200);
      oracleParameter2.Value = (object) model.ToUserName;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3 = new OracleParameter(":FromUserName", OracleDbType.Varchar2, 200);
      oracleParameter3.Value = (object) model.FromUserName;
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter4 = new OracleParameter(":CreateTime", OracleDbType.Int32, -1);
      oracleParameter4.Value = (object) model.CreateTime;
      oracleParameterArray[index4] = oracleParameter4;
      int index5 = 4;
      OracleParameter oracleParameter5 = new OracleParameter(":CreateTime1", OracleDbType.Date, 8);
      oracleParameter5.Value = (object) model.CreateTime1;
      oracleParameterArray[index5] = oracleParameter5;
      int index6 = 5;
      OracleParameter oracleParameter6 = new OracleParameter(":MsgType", OracleDbType.Varchar2, 50);
      oracleParameter6.Value = (object) model.MsgType;
      oracleParameterArray[index6] = oracleParameter6;
      int index7 = 6;
      OracleParameter oracleParameter7 = new OracleParameter(":MsgId", OracleDbType.Int64, -1);
      oracleParameter7.Value = (object) model.MsgId;
      oracleParameterArray[index7] = oracleParameter7;
      int index8 = 7;
      OracleParameter oracleParameter8 = new OracleParameter(":AgentID", OracleDbType.Int32, -1);
      oracleParameter8.Value = (object) model.AgentID;
      oracleParameterArray[index8] = oracleParameter8;
      int index9 = 8;
      OracleParameter oracleParameter9;
      if (model.Contents != null)
      {
        OracleParameter oracleParameter10 = new OracleParameter(":Contents", OracleDbType.NVarchar2, -1);
        oracleParameter10.Value = (object) model.Contents;
        oracleParameter9 = oracleParameter10;
      }
      else
      {
        oracleParameter9 = new OracleParameter(":Contents", OracleDbType.NVarchar2, -1);
        oracleParameter9.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index9] = oracleParameter9;
      int index10 = 9;
      OracleParameter oracleParameter11;
      if (model.PicUrl != null)
      {
        OracleParameter oracleParameter10 = new OracleParameter(":PicUrl", OracleDbType.Varchar2, 500);
        oracleParameter10.Value = (object) model.PicUrl;
        oracleParameter11 = oracleParameter10;
      }
      else
      {
        oracleParameter11 = new OracleParameter(":PicUrl", OracleDbType.Varchar2, 500);
        oracleParameter11.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index10] = oracleParameter11;
      int index11 = 10;
      OracleParameter oracleParameter12;
      if (model.MediaId != null)
      {
        OracleParameter oracleParameter10 = new OracleParameter(":MediaId", OracleDbType.Varchar2, 500);
        oracleParameter10.Value = (object) model.MediaId;
        oracleParameter12 = oracleParameter10;
      }
      else
      {
        oracleParameter12 = new OracleParameter(":MediaId", OracleDbType.Varchar2, 500);
        oracleParameter12.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index11] = oracleParameter12;
      int index12 = 11;
      OracleParameter oracleParameter13;
      if (model.Format != null)
      {
        OracleParameter oracleParameter10 = new OracleParameter(":Format", OracleDbType.Varchar2, 50);
        oracleParameter10.Value = (object) model.Format;
        oracleParameter13 = oracleParameter10;
      }
      else
      {
        oracleParameter13 = new OracleParameter(":Format", OracleDbType.Varchar2, 50);
        oracleParameter13.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index12] = oracleParameter13;
      int index13 = 12;
      OracleParameter oracleParameter14;
      if (model.ThumbMediaId != null)
      {
        OracleParameter oracleParameter10 = new OracleParameter(":ThumbMediaId", OracleDbType.Varchar2, 50);
        oracleParameter10.Value = (object) model.ThumbMediaId;
        oracleParameter14 = oracleParameter10;
      }
      else
      {
        oracleParameter14 = new OracleParameter(":ThumbMediaId", OracleDbType.Varchar2, 50);
        oracleParameter14.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index13] = oracleParameter14;
      int index14 = 13;
      OracleParameter oracleParameter15;
      if (model.Location_X != null)
      {
        OracleParameter oracleParameter10 = new OracleParameter(":Location_X", OracleDbType.Varchar2, 50);
        oracleParameter10.Value = (object) model.Location_X;
        oracleParameter15 = oracleParameter10;
      }
      else
      {
        oracleParameter15 = new OracleParameter(":Location_X", OracleDbType.Varchar2, 50);
        oracleParameter15.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index14] = oracleParameter15;
      int index15 = 14;
      OracleParameter oracleParameter16;
      if (model.Location_Y != null)
      {
        OracleParameter oracleParameter10 = new OracleParameter(":Location_Y", OracleDbType.Varchar2, 50);
        oracleParameter10.Value = (object) model.Location_Y;
        oracleParameter16 = oracleParameter10;
      }
      else
      {
        oracleParameter16 = new OracleParameter(":Location_Y", OracleDbType.Varchar2, 50);
        oracleParameter16.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index15] = oracleParameter16;
      int index16 = 15;
      OracleParameter oracleParameter17;
      if (model.Scale != null)
      {
        OracleParameter oracleParameter10 = new OracleParameter(":Scale", OracleDbType.Varchar2, 50);
        oracleParameter10.Value = (object) model.Scale;
        oracleParameter17 = oracleParameter10;
      }
      else
      {
        oracleParameter17 = new OracleParameter(":Scale", OracleDbType.Varchar2, 50);
        oracleParameter17.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index16] = oracleParameter17;
      int index17 = 16;
      OracleParameter oracleParameter18;
      if (model.Label != null)
      {
        OracleParameter oracleParameter10 = new OracleParameter(":Label", OracleDbType.NVarchar2, 1000);
        oracleParameter10.Value = (object) model.Label;
        oracleParameter18 = oracleParameter10;
      }
      else
      {
        oracleParameter18 = new OracleParameter(":Label", OracleDbType.NVarchar2, 1000);
        oracleParameter18.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index17] = oracleParameter18;
      int index18 = 17;
      OracleParameter oracleParameter19;
      if (model.Title != null)
      {
        OracleParameter oracleParameter10 = new OracleParameter(":Title", OracleDbType.NVarchar2, 1000);
        oracleParameter10.Value = (object) model.Title;
        oracleParameter19 = oracleParameter10;
      }
      else
      {
        oracleParameter19 = new OracleParameter(":Title", OracleDbType.NVarchar2, 1000);
        oracleParameter19.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index18] = oracleParameter19;
      int index19 = 18;
      OracleParameter oracleParameter20;
      if (model.Description != null)
      {
        OracleParameter oracleParameter10 = new OracleParameter(":Description", OracleDbType.NVarchar2, 2000);
        oracleParameter10.Value = (object) model.Description;
        oracleParameter20 = oracleParameter10;
      }
      else
      {
        oracleParameter20 = new OracleParameter(":Description", OracleDbType.NVarchar2, 2000);
        oracleParameter20.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index19] = oracleParameter20;
      int index20 = 19;
      OracleParameter oracleParameter21 = new OracleParameter(":AddTime", OracleDbType.Date, 8);
      oracleParameter21.Value = (object) model.AddTime;
      oracleParameterArray[index20] = oracleParameter21;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Update(RoadFlow.Data.Model.WeiXinMessage model)
    {
      string sql = "UPDATE WeiXinMessage SET \r\n\t\t\t\tToUserName=:ToUserName,FromUserName=:FromUserName,CreateTime=:CreateTime,CreateTime1=:CreateTime1,MsgType=:MsgType,MsgId=:MsgId,AgentID=:AgentID,Contents=:Contents,PicUrl=:PicUrl,MediaId=:MediaId,Format=:Format,ThumbMediaId=:ThumbMediaId,Location_X=:Location_X,Location_Y=:Location_Y,Scale=:Scale,Label=:Label,Title=:Title,Description=:Description,AddTime=:AddTime\r\n\t\t\t\tWHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[20];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":ToUserName", OracleDbType.Varchar2, 200);
      oracleParameter1.Value = (object) model.ToUserName;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":FromUserName", OracleDbType.Varchar2, 200);
      oracleParameter2.Value = (object) model.FromUserName;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3 = new OracleParameter(":CreateTime", OracleDbType.Int32, -1);
      oracleParameter3.Value = (object) model.CreateTime;
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter4 = new OracleParameter(":CreateTime1", OracleDbType.Date, 8);
      oracleParameter4.Value = (object) model.CreateTime1;
      oracleParameterArray[index4] = oracleParameter4;
      int index5 = 4;
      OracleParameter oracleParameter5 = new OracleParameter(":MsgType", OracleDbType.Varchar2, 50);
      oracleParameter5.Value = (object) model.MsgType;
      oracleParameterArray[index5] = oracleParameter5;
      int index6 = 5;
      OracleParameter oracleParameter6 = new OracleParameter(":MsgId", OracleDbType.Int64, -1);
      oracleParameter6.Value = (object) model.MsgId;
      oracleParameterArray[index6] = oracleParameter6;
      int index7 = 6;
      OracleParameter oracleParameter7 = new OracleParameter(":AgentID", OracleDbType.Int32, -1);
      oracleParameter7.Value = (object) model.AgentID;
      oracleParameterArray[index7] = oracleParameter7;
      int index8 = 7;
      OracleParameter oracleParameter8;
      if (model.Contents != null)
      {
        OracleParameter oracleParameter9 = new OracleParameter(":Contents", OracleDbType.NVarchar2, -1);
        oracleParameter9.Value = (object) model.Contents;
        oracleParameter8 = oracleParameter9;
      }
      else
      {
        oracleParameter8 = new OracleParameter(":Contents", OracleDbType.NVarchar2, -1);
        oracleParameter8.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index8] = oracleParameter8;
      int index9 = 8;
      OracleParameter oracleParameter10;
      if (model.PicUrl != null)
      {
        OracleParameter oracleParameter9 = new OracleParameter(":PicUrl", OracleDbType.Varchar2, 500);
        oracleParameter9.Value = (object) model.PicUrl;
        oracleParameter10 = oracleParameter9;
      }
      else
      {
        oracleParameter10 = new OracleParameter(":PicUrl", OracleDbType.Varchar2, 500);
        oracleParameter10.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index9] = oracleParameter10;
      int index10 = 9;
      OracleParameter oracleParameter11;
      if (model.MediaId != null)
      {
        OracleParameter oracleParameter9 = new OracleParameter(":MediaId", OracleDbType.Varchar2, 500);
        oracleParameter9.Value = (object) model.MediaId;
        oracleParameter11 = oracleParameter9;
      }
      else
      {
        oracleParameter11 = new OracleParameter(":MediaId", OracleDbType.Varchar2, 500);
        oracleParameter11.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index10] = oracleParameter11;
      int index11 = 10;
      OracleParameter oracleParameter12;
      if (model.Format != null)
      {
        OracleParameter oracleParameter9 = new OracleParameter(":Format", OracleDbType.Varchar2, 50);
        oracleParameter9.Value = (object) model.Format;
        oracleParameter12 = oracleParameter9;
      }
      else
      {
        oracleParameter12 = new OracleParameter(":Format", OracleDbType.Varchar2, 50);
        oracleParameter12.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index11] = oracleParameter12;
      int index12 = 11;
      OracleParameter oracleParameter13;
      if (model.ThumbMediaId != null)
      {
        OracleParameter oracleParameter9 = new OracleParameter(":ThumbMediaId", OracleDbType.Varchar2, 50);
        oracleParameter9.Value = (object) model.ThumbMediaId;
        oracleParameter13 = oracleParameter9;
      }
      else
      {
        oracleParameter13 = new OracleParameter(":ThumbMediaId", OracleDbType.Varchar2, 50);
        oracleParameter13.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index12] = oracleParameter13;
      int index13 = 12;
      OracleParameter oracleParameter14;
      if (model.Location_X != null)
      {
        OracleParameter oracleParameter9 = new OracleParameter(":Location_X", OracleDbType.Varchar2, 50);
        oracleParameter9.Value = (object) model.Location_X;
        oracleParameter14 = oracleParameter9;
      }
      else
      {
        oracleParameter14 = new OracleParameter(":Location_X", OracleDbType.Varchar2, 50);
        oracleParameter14.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index13] = oracleParameter14;
      int index14 = 13;
      OracleParameter oracleParameter15;
      if (model.Location_Y != null)
      {
        OracleParameter oracleParameter9 = new OracleParameter(":Location_Y", OracleDbType.Varchar2, 50);
        oracleParameter9.Value = (object) model.Location_Y;
        oracleParameter15 = oracleParameter9;
      }
      else
      {
        oracleParameter15 = new OracleParameter(":Location_Y", OracleDbType.Varchar2, 50);
        oracleParameter15.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index14] = oracleParameter15;
      int index15 = 14;
      OracleParameter oracleParameter16;
      if (model.Scale != null)
      {
        OracleParameter oracleParameter9 = new OracleParameter(":Scale", OracleDbType.Varchar2, 50);
        oracleParameter9.Value = (object) model.Scale;
        oracleParameter16 = oracleParameter9;
      }
      else
      {
        oracleParameter16 = new OracleParameter(":Scale", OracleDbType.Varchar2, 50);
        oracleParameter16.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index15] = oracleParameter16;
      int index16 = 15;
      OracleParameter oracleParameter17;
      if (model.Label != null)
      {
        OracleParameter oracleParameter9 = new OracleParameter(":Label", OracleDbType.NVarchar2, 1000);
        oracleParameter9.Value = (object) model.Label;
        oracleParameter17 = oracleParameter9;
      }
      else
      {
        oracleParameter17 = new OracleParameter(":Label", OracleDbType.NVarchar2, 1000);
        oracleParameter17.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index16] = oracleParameter17;
      int index17 = 16;
      OracleParameter oracleParameter18;
      if (model.Title != null)
      {
        OracleParameter oracleParameter9 = new OracleParameter(":Title", OracleDbType.NVarchar2, 1000);
        oracleParameter9.Value = (object) model.Title;
        oracleParameter18 = oracleParameter9;
      }
      else
      {
        oracleParameter18 = new OracleParameter(":Title", OracleDbType.NVarchar2, 1000);
        oracleParameter18.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index17] = oracleParameter18;
      int index18 = 17;
      OracleParameter oracleParameter19;
      if (model.Description != null)
      {
        OracleParameter oracleParameter9 = new OracleParameter(":Description", OracleDbType.NVarchar2, 2000);
        oracleParameter9.Value = (object) model.Description;
        oracleParameter19 = oracleParameter9;
      }
      else
      {
        oracleParameter19 = new OracleParameter(":Description", OracleDbType.NVarchar2, 2000);
        oracleParameter19.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index18] = oracleParameter19;
      int index19 = 18;
      OracleParameter oracleParameter20 = new OracleParameter(":AddTime", OracleDbType.Date, 8);
      oracleParameter20.Value = (object) model.AddTime;
      oracleParameterArray[index19] = oracleParameter20;
      int index20 = 19;
      OracleParameter oracleParameter21 = new OracleParameter(":ID", OracleDbType.Varchar2, -1);
      oracleParameter21.Value = (object) model.ID;
      oracleParameterArray[index20] = oracleParameter21;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM WeiXinMessage WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    private List<RoadFlow.Data.Model.WeiXinMessage> DataReaderToList(OracleDataReader dataReader)
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
      OracleDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM WeiXinMessage");
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
      string sql = "SELECT * FROM WeiXinMessage WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WeiXinMessage> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.WeiXinMessage) null;
      return list[0];
    }
  }
}
