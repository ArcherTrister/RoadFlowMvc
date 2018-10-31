// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MSSQL.Log
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
  public class Log : ILog
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.Log model)
    {
      string sql = "INSERT INTO Log\r\n\t\t\t\t(ID,Title,Type,WriteTime,UserID,UserName,IPAddress,URL,Contents,Others,OldXml,NewXml) \r\n\t\t\t\tVALUES(@ID,@Title,@Type,@WriteTime,@UserID,@UserName,@IPAddress,@URL,@Contents,@Others,@OldXml,@NewXml)";
      SqlParameter[] sqlParameterArray = new SqlParameter[12];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter1.Value = (object) model.ID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@Title", SqlDbType.NVarChar, -1);
      sqlParameter2.Value = (object) model.Title;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@Type", SqlDbType.NVarChar, 100);
      sqlParameter3.Value = (object) model.Type;
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter4 = new SqlParameter("@WriteTime", SqlDbType.DateTime, 8);
      sqlParameter4.Value = (object) model.WriteTime;
      sqlParameterArray[index4] = sqlParameter4;
      int index5 = 4;
      SqlParameter sqlParameter5;
      if (model.UserID.HasValue)
      {
        SqlParameter sqlParameter6 = new SqlParameter("@UserID", SqlDbType.UniqueIdentifier, -1);
        sqlParameter6.Value = (object) model.UserID;
        sqlParameter5 = sqlParameter6;
      }
      else
      {
        sqlParameter5 = new SqlParameter("@UserID", SqlDbType.UniqueIdentifier, -1);
        sqlParameter5.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index5] = sqlParameter5;
      int index6 = 5;
      SqlParameter sqlParameter7;
      if (model.UserName != null)
      {
        SqlParameter sqlParameter6 = new SqlParameter("@UserName", SqlDbType.NVarChar, 100);
        sqlParameter6.Value = (object) model.UserName;
        sqlParameter7 = sqlParameter6;
      }
      else
      {
        sqlParameter7 = new SqlParameter("@UserName", SqlDbType.NVarChar, 100);
        sqlParameter7.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index6] = sqlParameter7;
      int index7 = 6;
      SqlParameter sqlParameter8;
      if (model.IPAddress != null)
      {
        SqlParameter sqlParameter6 = new SqlParameter("@IPAddress", SqlDbType.VarChar, 50);
        sqlParameter6.Value = (object) model.IPAddress;
        sqlParameter8 = sqlParameter6;
      }
      else
      {
        sqlParameter8 = new SqlParameter("@IPAddress", SqlDbType.VarChar, 50);
        sqlParameter8.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index7] = sqlParameter8;
      int index8 = 7;
      SqlParameter sqlParameter9;
      if (model.URL != null)
      {
        SqlParameter sqlParameter6 = new SqlParameter("@URL", SqlDbType.VarChar, -1);
        sqlParameter6.Value = (object) model.URL;
        sqlParameter9 = sqlParameter6;
      }
      else
      {
        sqlParameter9 = new SqlParameter("@URL", SqlDbType.VarChar, -1);
        sqlParameter9.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index8] = sqlParameter9;
      int index9 = 8;
      SqlParameter sqlParameter10;
      if (model.Contents != null)
      {
        SqlParameter sqlParameter6 = new SqlParameter("@Contents", SqlDbType.VarChar, -1);
        sqlParameter6.Value = (object) model.Contents;
        sqlParameter10 = sqlParameter6;
      }
      else
      {
        sqlParameter10 = new SqlParameter("@Contents", SqlDbType.VarChar, -1);
        sqlParameter10.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index9] = sqlParameter10;
      int index10 = 9;
      SqlParameter sqlParameter11;
      if (model.Others != null)
      {
        SqlParameter sqlParameter6 = new SqlParameter("@Others", SqlDbType.VarChar, -1);
        sqlParameter6.Value = (object) model.Others;
        sqlParameter11 = sqlParameter6;
      }
      else
      {
        sqlParameter11 = new SqlParameter("@Others", SqlDbType.VarChar, -1);
        sqlParameter11.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index10] = sqlParameter11;
      int index11 = 10;
      SqlParameter sqlParameter12;
      if (model.OldXml != null)
      {
        SqlParameter sqlParameter6 = new SqlParameter("@OldXml", SqlDbType.VarChar, -1);
        sqlParameter6.Value = (object) model.OldXml;
        sqlParameter12 = sqlParameter6;
      }
      else
      {
        sqlParameter12 = new SqlParameter("@OldXml", SqlDbType.VarChar, -1);
        sqlParameter12.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index11] = sqlParameter12;
      int index12 = 11;
      SqlParameter sqlParameter13;
      if (model.NewXml != null)
      {
        SqlParameter sqlParameter6 = new SqlParameter("@NewXml", SqlDbType.VarChar, -1);
        sqlParameter6.Value = (object) model.NewXml;
        sqlParameter13 = sqlParameter6;
      }
      else
      {
        sqlParameter13 = new SqlParameter("@NewXml", SqlDbType.VarChar, -1);
        sqlParameter13.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index12] = sqlParameter13;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.Log model)
    {
      string sql = "UPDATE Log SET \r\n\t\t\t\tTitle=@Title,Type=@Type,WriteTime=@WriteTime,UserID=@UserID,UserName=@UserName,IPAddress=@IPAddress,URL=@URL,Contents=@Contents,Others=@Others,OldXml=@OldXml,NewXml=@NewXml\r\n\t\t\t\tWHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[12];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@Title", SqlDbType.NVarChar, -1);
      sqlParameter1.Value = (object) model.Title;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@Type", SqlDbType.NVarChar, 100);
      sqlParameter2.Value = (object) model.Type;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@WriteTime", SqlDbType.DateTime, 8);
      sqlParameter3.Value = (object) model.WriteTime;
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter4;
      if (model.UserID.HasValue)
      {
        SqlParameter sqlParameter5 = new SqlParameter("@UserID", SqlDbType.UniqueIdentifier, -1);
        sqlParameter5.Value = (object) model.UserID;
        sqlParameter4 = sqlParameter5;
      }
      else
      {
        sqlParameter4 = new SqlParameter("@UserID", SqlDbType.UniqueIdentifier, -1);
        sqlParameter4.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index4] = sqlParameter4;
      int index5 = 4;
      SqlParameter sqlParameter6;
      if (model.UserName != null)
      {
        SqlParameter sqlParameter5 = new SqlParameter("@UserName", SqlDbType.NVarChar, 100);
        sqlParameter5.Value = (object) model.UserName;
        sqlParameter6 = sqlParameter5;
      }
      else
      {
        sqlParameter6 = new SqlParameter("@UserName", SqlDbType.NVarChar, 100);
        sqlParameter6.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index5] = sqlParameter6;
      int index6 = 5;
      SqlParameter sqlParameter7;
      if (model.IPAddress != null)
      {
        SqlParameter sqlParameter5 = new SqlParameter("@IPAddress", SqlDbType.VarChar, 50);
        sqlParameter5.Value = (object) model.IPAddress;
        sqlParameter7 = sqlParameter5;
      }
      else
      {
        sqlParameter7 = new SqlParameter("@IPAddress", SqlDbType.VarChar, 50);
        sqlParameter7.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index6] = sqlParameter7;
      int index7 = 6;
      SqlParameter sqlParameter8;
      if (model.URL != null)
      {
        SqlParameter sqlParameter5 = new SqlParameter("@URL", SqlDbType.VarChar, -1);
        sqlParameter5.Value = (object) model.URL;
        sqlParameter8 = sqlParameter5;
      }
      else
      {
        sqlParameter8 = new SqlParameter("@URL", SqlDbType.VarChar, -1);
        sqlParameter8.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index7] = sqlParameter8;
      int index8 = 7;
      SqlParameter sqlParameter9;
      if (model.Contents != null)
      {
        SqlParameter sqlParameter5 = new SqlParameter("@Contents", SqlDbType.VarChar, -1);
        sqlParameter5.Value = (object) model.Contents;
        sqlParameter9 = sqlParameter5;
      }
      else
      {
        sqlParameter9 = new SqlParameter("@Contents", SqlDbType.VarChar, -1);
        sqlParameter9.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index8] = sqlParameter9;
      int index9 = 8;
      SqlParameter sqlParameter10;
      if (model.Others != null)
      {
        SqlParameter sqlParameter5 = new SqlParameter("@Others", SqlDbType.VarChar, -1);
        sqlParameter5.Value = (object) model.Others;
        sqlParameter10 = sqlParameter5;
      }
      else
      {
        sqlParameter10 = new SqlParameter("@Others", SqlDbType.VarChar, -1);
        sqlParameter10.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index9] = sqlParameter10;
      int index10 = 9;
      SqlParameter sqlParameter11;
      if (model.OldXml != null)
      {
        SqlParameter sqlParameter5 = new SqlParameter("@OldXml", SqlDbType.VarChar, -1);
        sqlParameter5.Value = (object) model.OldXml;
        sqlParameter11 = sqlParameter5;
      }
      else
      {
        sqlParameter11 = new SqlParameter("@OldXml", SqlDbType.VarChar, -1);
        sqlParameter11.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index10] = sqlParameter11;
      int index11 = 10;
      SqlParameter sqlParameter12;
      if (model.NewXml != null)
      {
        SqlParameter sqlParameter5 = new SqlParameter("@NewXml", SqlDbType.VarChar, -1);
        sqlParameter5.Value = (object) model.NewXml;
        sqlParameter12 = sqlParameter5;
      }
      else
      {
        sqlParameter12 = new SqlParameter("@NewXml", SqlDbType.VarChar, -1);
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
      string sql = "DELETE FROM Log WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.Log> DataReaderToList(SqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.Log> logList = new List<RoadFlow.Data.Model.Log>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.Log log = new RoadFlow.Data.Model.Log();
        log.ID = dataReader.GetGuid(0);
        log.Title = dataReader.GetString(1);
        log.Type = dataReader.GetString(2);
        log.WriteTime = dataReader.GetDateTime(3);
        if (!dataReader.IsDBNull(4))
          log.UserID = new Guid?(dataReader.GetGuid(4));
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
      SqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM Log");
      List<RoadFlow.Data.Model.Log> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM Log"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.Log Get(Guid id)
    {
      string sql = "SELECT * FROM Log WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.Log> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.Log) null;
      return list[0];
    }

    public DataTable GetPagerData(out string pager, string query = "", int size = 15, int number = 1, string title = "", string type = "", string date1 = "", string date2 = "", string userID = "")
    {
      StringBuilder stringBuilder = new StringBuilder();
      List<SqlParameter> sqlParameterList1 = new List<SqlParameter>();
      if (!title.IsNullOrEmpty())
      {
        stringBuilder.Append("AND CHARINDEX(@Title,Title)>0 ");
        List<SqlParameter> sqlParameterList2 = sqlParameterList1;
        SqlParameter sqlParameter = new SqlParameter("@Title", SqlDbType.NVarChar);
        sqlParameter.Value = (object) title;
        sqlParameterList2.Add(sqlParameter);
      }
      if (!type.IsNullOrEmpty())
      {
        stringBuilder.Append("AND Type=@Type ");
        List<SqlParameter> sqlParameterList2 = sqlParameterList1;
        SqlParameter sqlParameter = new SqlParameter("@Type", SqlDbType.NVarChar);
        sqlParameter.Value = (object) type;
        sqlParameterList2.Add(sqlParameter);
      }
      DateTime dateTime;
      if (date1.IsDateTime())
      {
        stringBuilder.Append("AND WriteTime>=@Date1 ");
        List<SqlParameter> sqlParameterList2 = sqlParameterList1;
        SqlParameter sqlParameter = new SqlParameter("@Date1", SqlDbType.DateTime);
        dateTime = date1.ToDateTime();
        sqlParameter.Value = (object) dateTime.ToString("yyyy-MM-dd 00:00:00");
        sqlParameterList2.Add(sqlParameter);
      }
      if (date2.IsDateTime())
      {
        stringBuilder.Append("AND WriteTime<=@Date2 ");
        List<SqlParameter> sqlParameterList2 = sqlParameterList1;
        SqlParameter sqlParameter = new SqlParameter("@Date2", SqlDbType.DateTime);
        dateTime = date2.ToDateTime();
        dateTime = dateTime.AddDays(1.0);
        sqlParameter.Value = (object) dateTime.ToString("yyyy-MM-dd 00:00:00");
        sqlParameterList2.Add(sqlParameter);
      }
      if (userID.IsGuid())
      {
        stringBuilder.Append("AND UserID=@UserID ");
        List<SqlParameter> sqlParameterList2 = sqlParameterList1;
        SqlParameter sqlParameter = new SqlParameter("@UserID", SqlDbType.UniqueIdentifier);
        sqlParameter.Value = (object) userID.ToGuid();
        sqlParameterList2.Add(sqlParameter);
      }
      long count;
      string paerSql = this.dbHelper.GetPaerSql(nameof (Log), "ID,Title,Type,WriteTime,UserName,IPAddress", stringBuilder.ToString(), "WriteTime DESC", size, number, out count, sqlParameterList1.ToArray());
      pager = Tools.GetPagerHtml(count, size, number, query);
      return this.dbHelper.GetDataTable(paerSql, sqlParameterList1.ToArray());
    }

    public DataTable GetPagerData(out long count, int size = 15, int number = 1, string title = "", string type = "", string date1 = "", string date2 = "", string userID = "", string order = "")
    {
      StringBuilder stringBuilder = new StringBuilder();
      List<SqlParameter> sqlParameterList1 = new List<SqlParameter>();
      if (!title.IsNullOrEmpty())
      {
        stringBuilder.Append("AND CHARINDEX(@Title,Title)>0 ");
        List<SqlParameter> sqlParameterList2 = sqlParameterList1;
        SqlParameter sqlParameter = new SqlParameter("@Title", SqlDbType.NVarChar);
        sqlParameter.Value = (object) title;
        sqlParameterList2.Add(sqlParameter);
      }
      if (!type.IsNullOrEmpty())
      {
        stringBuilder.Append("AND Type=@Type ");
        List<SqlParameter> sqlParameterList2 = sqlParameterList1;
        SqlParameter sqlParameter = new SqlParameter("@Type", SqlDbType.NVarChar);
        sqlParameter.Value = (object) type;
        sqlParameterList2.Add(sqlParameter);
      }
      DateTime dateTime;
      if (date1.IsDateTime())
      {
        stringBuilder.Append("AND WriteTime>=@Date1 ");
        List<SqlParameter> sqlParameterList2 = sqlParameterList1;
        SqlParameter sqlParameter = new SqlParameter("@Date1", SqlDbType.DateTime);
        dateTime = date1.ToDateTime();
        sqlParameter.Value = (object) dateTime.ToString("yyyy-MM-dd 00:00:00");
        sqlParameterList2.Add(sqlParameter);
      }
      if (date2.IsDateTime())
      {
        stringBuilder.Append("AND WriteTime<=@Date2 ");
        List<SqlParameter> sqlParameterList2 = sqlParameterList1;
        SqlParameter sqlParameter = new SqlParameter("@Date2", SqlDbType.DateTime);
        dateTime = date2.ToDateTime();
        dateTime = dateTime.AddDays(1.0);
        sqlParameter.Value = (object) dateTime.ToString("yyyy-MM-dd 00:00:00");
        sqlParameterList2.Add(sqlParameter);
      }
      if (userID.IsGuid())
      {
        stringBuilder.Append("AND UserID=@UserID ");
        List<SqlParameter> sqlParameterList2 = sqlParameterList1;
        SqlParameter sqlParameter = new SqlParameter("@UserID", SqlDbType.UniqueIdentifier);
        sqlParameter.Value = (object) userID.ToGuid();
        sqlParameterList2.Add(sqlParameter);
      }
      return this.dbHelper.GetDataTable(this.dbHelper.GetPaerSql(nameof (Log), "ID,Title,Type,WriteTime,UserName,IPAddress", stringBuilder.ToString(), order.IsNullOrEmpty() ? "WriteTime DESC" : order, size, number, out count, sqlParameterList1.ToArray()).ToString(), sqlParameterList1.ToArray());
    }
  }
}
