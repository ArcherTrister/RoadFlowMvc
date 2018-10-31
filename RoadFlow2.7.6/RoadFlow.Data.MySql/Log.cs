// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MySql.Log
// Assembly: RoadFlow.Data.MySql, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 29B652D7-5F6F-4A7D-AD1C-9F2C643FD784
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.MySql.dll

using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace RoadFlow.Data.MySql
{
  public class Log : ILog
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.Log model)
    {
      string sql = "INSERT INTO log\r\n\t\t\t\t(ID,Title,Type,WriteTime,UserID,UserName,IPAddress,URL,Contents,Others,OldXml,NewXml) \r\n\t\t\t\tVALUES(@ID,@Title,@Type,@WriteTime,@UserID,@UserName,@IPAddress,@URL,@Contents,@Others,@OldXml,@NewXml)";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[12];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter1.Value = (object) model.ID;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@Title", MySqlDbType.LongText, -1);
      mySqlParameter2.Value = (object) model.Title;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@Type", MySqlDbType.VarChar, 50);
      mySqlParameter3.Value = (object) model.Type;
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter4 = new MySqlParameter("@WriteTime", MySqlDbType.DateTime, -1);
      mySqlParameter4.Value = (object) model.WriteTime;
      mySqlParameterArray[index4] = mySqlParameter4;
      int index5 = 4;
      MySqlParameter mySqlParameter5;
      if (model.UserID.HasValue)
      {
        MySqlParameter mySqlParameter6 = new MySqlParameter("@UserID", MySqlDbType.VarChar, 36);
        mySqlParameter6.Value = (object) model.UserID;
        mySqlParameter5 = mySqlParameter6;
      }
      else
      {
        mySqlParameter5 = new MySqlParameter("@UserID", MySqlDbType.VarChar, 36);
        mySqlParameter5.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index5] = mySqlParameter5;
      int index6 = 5;
      MySqlParameter mySqlParameter7;
      if (model.UserName != null)
      {
        MySqlParameter mySqlParameter6 = new MySqlParameter("@UserName", MySqlDbType.VarChar, 50);
        mySqlParameter6.Value = (object) model.UserName;
        mySqlParameter7 = mySqlParameter6;
      }
      else
      {
        mySqlParameter7 = new MySqlParameter("@UserName", MySqlDbType.VarChar, 50);
        mySqlParameter7.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index6] = mySqlParameter7;
      int index7 = 6;
      MySqlParameter mySqlParameter8;
      if (model.IPAddress != null)
      {
        MySqlParameter mySqlParameter6 = new MySqlParameter("@IPAddress", MySqlDbType.VarChar, 50);
        mySqlParameter6.Value = (object) model.IPAddress;
        mySqlParameter8 = mySqlParameter6;
      }
      else
      {
        mySqlParameter8 = new MySqlParameter("@IPAddress", MySqlDbType.VarChar, 50);
        mySqlParameter8.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index7] = mySqlParameter8;
      int index8 = 7;
      MySqlParameter mySqlParameter9;
      if (model.URL != null)
      {
        MySqlParameter mySqlParameter6 = new MySqlParameter("@URL", MySqlDbType.LongText, -1);
        mySqlParameter6.Value = (object) model.URL;
        mySqlParameter9 = mySqlParameter6;
      }
      else
      {
        mySqlParameter9 = new MySqlParameter("@URL", MySqlDbType.LongText, -1);
        mySqlParameter9.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index8] = mySqlParameter9;
      int index9 = 8;
      MySqlParameter mySqlParameter10;
      if (model.Contents != null)
      {
        MySqlParameter mySqlParameter6 = new MySqlParameter("@Contents", MySqlDbType.LongText, -1);
        mySqlParameter6.Value = (object) model.Contents;
        mySqlParameter10 = mySqlParameter6;
      }
      else
      {
        mySqlParameter10 = new MySqlParameter("@Contents", MySqlDbType.LongText, -1);
        mySqlParameter10.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index9] = mySqlParameter10;
      int index10 = 9;
      MySqlParameter mySqlParameter11;
      if (model.Others != null)
      {
        MySqlParameter mySqlParameter6 = new MySqlParameter("@Others", MySqlDbType.LongText, -1);
        mySqlParameter6.Value = (object) model.Others;
        mySqlParameter11 = mySqlParameter6;
      }
      else
      {
        mySqlParameter11 = new MySqlParameter("@Others", MySqlDbType.LongText, -1);
        mySqlParameter11.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index10] = mySqlParameter11;
      int index11 = 10;
      MySqlParameter mySqlParameter12;
      if (model.OldXml != null)
      {
        MySqlParameter mySqlParameter6 = new MySqlParameter("@OldXml", MySqlDbType.LongText, -1);
        mySqlParameter6.Value = (object) model.OldXml;
        mySqlParameter12 = mySqlParameter6;
      }
      else
      {
        mySqlParameter12 = new MySqlParameter("@OldXml", MySqlDbType.LongText, -1);
        mySqlParameter12.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index11] = mySqlParameter12;
      int index12 = 11;
      MySqlParameter mySqlParameter13;
      if (model.NewXml != null)
      {
        MySqlParameter mySqlParameter6 = new MySqlParameter("@NewXml", MySqlDbType.LongText, -1);
        mySqlParameter6.Value = (object) model.NewXml;
        mySqlParameter13 = mySqlParameter6;
      }
      else
      {
        mySqlParameter13 = new MySqlParameter("@NewXml", MySqlDbType.LongText, -1);
        mySqlParameter13.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index12] = mySqlParameter13;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.Log model)
    {
      string sql = "UPDATE log SET \r\n\t\t\t\tTitle=@Title,Type=@Type,WriteTime=@WriteTime,UserID=@UserID,UserName=@UserName,IPAddress=@IPAddress,URL=@URL,Contents=@Contents,Others=@Others,OldXml=@OldXml,NewXml=@NewXml\r\n\t\t\t\tWHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[12];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@Title", MySqlDbType.LongText, -1);
      mySqlParameter1.Value = (object) model.Title;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@Type", MySqlDbType.VarChar, 50);
      mySqlParameter2.Value = (object) model.Type;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@WriteTime", MySqlDbType.DateTime, -1);
      mySqlParameter3.Value = (object) model.WriteTime;
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter4;
      if (model.UserID.HasValue)
      {
        MySqlParameter mySqlParameter5 = new MySqlParameter("@UserID", MySqlDbType.VarChar, 36);
        mySqlParameter5.Value = (object) model.UserID;
        mySqlParameter4 = mySqlParameter5;
      }
      else
      {
        mySqlParameter4 = new MySqlParameter("@UserID", MySqlDbType.VarChar, 36);
        mySqlParameter4.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index4] = mySqlParameter4;
      int index5 = 4;
      MySqlParameter mySqlParameter6;
      if (model.UserName != null)
      {
        MySqlParameter mySqlParameter5 = new MySqlParameter("@UserName", MySqlDbType.VarChar, 50);
        mySqlParameter5.Value = (object) model.UserName;
        mySqlParameter6 = mySqlParameter5;
      }
      else
      {
        mySqlParameter6 = new MySqlParameter("@UserName", MySqlDbType.VarChar, 50);
        mySqlParameter6.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index5] = mySqlParameter6;
      int index6 = 5;
      MySqlParameter mySqlParameter7;
      if (model.IPAddress != null)
      {
        MySqlParameter mySqlParameter5 = new MySqlParameter("@IPAddress", MySqlDbType.VarChar, 50);
        mySqlParameter5.Value = (object) model.IPAddress;
        mySqlParameter7 = mySqlParameter5;
      }
      else
      {
        mySqlParameter7 = new MySqlParameter("@IPAddress", MySqlDbType.VarChar, 50);
        mySqlParameter7.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index6] = mySqlParameter7;
      int index7 = 6;
      MySqlParameter mySqlParameter8;
      if (model.URL != null)
      {
        MySqlParameter mySqlParameter5 = new MySqlParameter("@URL", MySqlDbType.LongText, -1);
        mySqlParameter5.Value = (object) model.URL;
        mySqlParameter8 = mySqlParameter5;
      }
      else
      {
        mySqlParameter8 = new MySqlParameter("@URL", MySqlDbType.LongText, -1);
        mySqlParameter8.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index7] = mySqlParameter8;
      int index8 = 7;
      MySqlParameter mySqlParameter9;
      if (model.Contents != null)
      {
        MySqlParameter mySqlParameter5 = new MySqlParameter("@Contents", MySqlDbType.LongText, -1);
        mySqlParameter5.Value = (object) model.Contents;
        mySqlParameter9 = mySqlParameter5;
      }
      else
      {
        mySqlParameter9 = new MySqlParameter("@Contents", MySqlDbType.LongText, -1);
        mySqlParameter9.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index8] = mySqlParameter9;
      int index9 = 8;
      MySqlParameter mySqlParameter10;
      if (model.Others != null)
      {
        MySqlParameter mySqlParameter5 = new MySqlParameter("@Others", MySqlDbType.LongText, -1);
        mySqlParameter5.Value = (object) model.Others;
        mySqlParameter10 = mySqlParameter5;
      }
      else
      {
        mySqlParameter10 = new MySqlParameter("@Others", MySqlDbType.LongText, -1);
        mySqlParameter10.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index9] = mySqlParameter10;
      int index10 = 9;
      MySqlParameter mySqlParameter11;
      if (model.OldXml != null)
      {
        MySqlParameter mySqlParameter5 = new MySqlParameter("@OldXml", MySqlDbType.LongText, -1);
        mySqlParameter5.Value = (object) model.OldXml;
        mySqlParameter11 = mySqlParameter5;
      }
      else
      {
        mySqlParameter11 = new MySqlParameter("@OldXml", MySqlDbType.LongText, -1);
        mySqlParameter11.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index10] = mySqlParameter11;
      int index11 = 10;
      MySqlParameter mySqlParameter12;
      if (model.NewXml != null)
      {
        MySqlParameter mySqlParameter5 = new MySqlParameter("@NewXml", MySqlDbType.LongText, -1);
        mySqlParameter5.Value = (object) model.NewXml;
        mySqlParameter12 = mySqlParameter5;
      }
      else
      {
        mySqlParameter12 = new MySqlParameter("@NewXml", MySqlDbType.LongText, -1);
        mySqlParameter12.Value = (object) DBNull.Value;
      }
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
      string sql = "DELETE FROM log WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.Log> DataReaderToList(MySqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.Log> logList = new List<RoadFlow.Data.Model.Log>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.Log log = new RoadFlow.Data.Model.Log();
        log.ID = dataReader.GetString(0).ToGuid();
        log.Title = dataReader.GetString(1);
        log.Type = dataReader.GetString(2);
        log.WriteTime = dataReader.GetDateTime(3);
        if (!dataReader.IsDBNull(4))
          log.UserID = new Guid?(dataReader.GetString(4).ToGuid());
        if (!dataReader.IsDBNull(5))
          log.UserName = dataReader.GetString(5);
        if (!dataReader.IsDBNull(6))
          log.IPAddress = dataReader.GetString(6);
        if (!dataReader.IsDBNull(7))
          log.URL = dataReader.GetString(7);
        if (!dataReader.IsDBNull(8))
          log.Contents = dataReader.GetString(8);
        if (!dataReader.IsDBNull(9))
          log.Others = dataReader.GetString(9);
        if (!dataReader.IsDBNull(10))
          log.OldXml = dataReader.GetString(10);
        if (!dataReader.IsDBNull(11))
          log.NewXml = dataReader.GetString(11);
        logList.Add(log);
      }
      return logList;
    }

    public List<RoadFlow.Data.Model.Log> GetAll()
    {
      MySqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM log");
      List<RoadFlow.Data.Model.Log> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM log"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.Log Get(Guid id)
    {
      string sql = "SELECT * FROM log WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.Log> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.Log) null;
      return list[0];
    }

    public DataTable GetPagerData(out string pager, string query = "", int size = 15, int number = 1, string title = "", string type = "", string date1 = "", string date2 = "", string userID = "")
    {
      StringBuilder stringBuilder = new StringBuilder();
      List<MySqlParameter> mySqlParameterList1 = new List<MySqlParameter>();
      if (!title.IsNullOrEmpty())
      {
        stringBuilder.Append("AND INSTR(Title,@Title)>0 ");
        List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
        MySqlParameter mySqlParameter = new MySqlParameter("@Title", MySqlDbType.VarChar);
        mySqlParameter.Value = (object) title;
        mySqlParameterList2.Add(mySqlParameter);
      }
      if (!type.IsNullOrEmpty())
      {
        stringBuilder.Append("AND Type=@Type ");
        List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
        MySqlParameter mySqlParameter = new MySqlParameter("@Type", MySqlDbType.VarChar);
        mySqlParameter.Value = (object) type;
        mySqlParameterList2.Add(mySqlParameter);
      }
      DateTime dateTime;
      if (date1.IsDateTime())
      {
        stringBuilder.Append("AND WriteTime>=@Date1 ");
        List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
        MySqlParameter mySqlParameter = new MySqlParameter("@Date1", MySqlDbType.DateTime);
        dateTime = date1.ToDateTime();
        mySqlParameter.Value = (object) dateTime.ToString("yyyy-MM-dd 00:00:00");
        mySqlParameterList2.Add(mySqlParameter);
      }
      if (date2.IsDateTime())
      {
        stringBuilder.Append("AND WriteTime<=@Date2 ");
        List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
        MySqlParameter mySqlParameter = new MySqlParameter("@Date2", MySqlDbType.DateTime);
        dateTime = date2.ToDateTime();
        dateTime = dateTime.AddDays(1.0);
        mySqlParameter.Value = (object) dateTime.ToString("yyyy-MM-dd 00:00:00");
        mySqlParameterList2.Add(mySqlParameter);
      }
      if (userID.IsGuid())
      {
        stringBuilder.Append("AND UserID=@UserID ");
        List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
        MySqlParameter mySqlParameter = new MySqlParameter("@UserID", MySqlDbType.VarChar);
        mySqlParameter.Value = (object) userID.ToGuid();
        mySqlParameterList2.Add(mySqlParameter);
      }
      long count;
      string paerSql = this.dbHelper.GetPaerSql(nameof (Log), "ID,Title,Type,WriteTime,UserName,IPAddress", stringBuilder.ToString(), "WriteTime DESC", size, number, out count, mySqlParameterList1.ToArray());
      pager = Tools.GetPagerHtml(count, size, number, query);
      return this.dbHelper.GetDataTable(paerSql.ToString(), mySqlParameterList1.ToArray());
    }

    public DataTable GetPagerData(out long count, int size = 15, int number = 1, string title = "", string type = "", string date1 = "", string date2 = "", string userID = "", string order = "")
    {
      StringBuilder stringBuilder = new StringBuilder();
      List<MySqlParameter> mySqlParameterList1 = new List<MySqlParameter>();
      if (!title.IsNullOrEmpty())
      {
        stringBuilder.Append("AND INSTR(Title,@Title)>0 ");
        List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
        MySqlParameter mySqlParameter = new MySqlParameter("@Title", MySqlDbType.VarChar);
        mySqlParameter.Value = (object) title;
        mySqlParameterList2.Add(mySqlParameter);
      }
      if (!type.IsNullOrEmpty())
      {
        stringBuilder.Append("AND Type=@Type ");
        List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
        MySqlParameter mySqlParameter = new MySqlParameter("@Type", MySqlDbType.VarChar);
        mySqlParameter.Value = (object) type;
        mySqlParameterList2.Add(mySqlParameter);
      }
      DateTime dateTime;
      if (date1.IsDateTime())
      {
        stringBuilder.Append("AND WriteTime>=@Date1 ");
        List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
        MySqlParameter mySqlParameter = new MySqlParameter("@Date1", MySqlDbType.DateTime);
        dateTime = date1.ToDateTime();
        mySqlParameter.Value = (object) dateTime.ToString("yyyy-MM-dd 00:00:00");
        mySqlParameterList2.Add(mySqlParameter);
      }
      if (date2.IsDateTime())
      {
        stringBuilder.Append("AND WriteTime<=@Date2 ");
        List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
        MySqlParameter mySqlParameter = new MySqlParameter("@Date2", MySqlDbType.DateTime);
        dateTime = date2.ToDateTime();
        dateTime = dateTime.AddDays(1.0);
        mySqlParameter.Value = (object) dateTime.ToString("yyyy-MM-dd 00:00:00");
        mySqlParameterList2.Add(mySqlParameter);
      }
      if (userID.IsGuid())
      {
        stringBuilder.Append("AND UserID=@UserID ");
        List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
        MySqlParameter mySqlParameter = new MySqlParameter("@UserID", MySqlDbType.VarChar);
        mySqlParameter.Value = (object) userID;
        mySqlParameterList2.Add(mySqlParameter);
      }
      return this.dbHelper.GetDataTable(this.dbHelper.GetPaerSql(nameof (Log), "ID,Title,Type,WriteTime,UserName,IPAddress", stringBuilder.ToString(), order.IsNullOrEmpty() ? "WriteTime DESC" : order, size, number, out count, mySqlParameterList1.ToArray()).ToString(), mySqlParameterList1.ToArray());
    }
  }
}
