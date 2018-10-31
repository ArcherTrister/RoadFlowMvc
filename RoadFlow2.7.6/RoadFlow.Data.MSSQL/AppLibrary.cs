// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MSSQL.AppLibrary
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
  public class AppLibrary : IAppLibrary
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.AppLibrary model)
    {
      string sql = "INSERT INTO AppLibrary\r\n\t\t\t\t(ID,Title,Address,Type,OpenMode,Width,Height,Params,Manager,Note,Code,Ico,Color) \r\n\t\t\t\tVALUES(@ID,@Title,@Address,@Type,@OpenMode,@Width,@Height,@Params,@Manager,@Note,@Code,@Ico,@Color)";
      SqlParameter[] sqlParameterArray = new SqlParameter[13];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter1.Value = (object) model.ID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@Title", SqlDbType.NVarChar, 510);
      sqlParameter2.Value = (object) model.Title;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@Address", SqlDbType.VarChar, 200);
      sqlParameter3.Value = (object) model.Address;
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter4 = new SqlParameter("@Type", SqlDbType.UniqueIdentifier, -1);
      sqlParameter4.Value = (object) model.Type;
      sqlParameterArray[index4] = sqlParameter4;
      int index5 = 4;
      SqlParameter sqlParameter5 = new SqlParameter("@OpenMode", SqlDbType.Int, -1);
      sqlParameter5.Value = (object) model.OpenMode;
      sqlParameterArray[index5] = sqlParameter5;
      int index6 = 5;
      SqlParameter sqlParameter6;
      if (model.Width.HasValue)
      {
        SqlParameter sqlParameter7 = new SqlParameter("@Width", SqlDbType.Int, -1);
        sqlParameter7.Value = (object) model.Width;
        sqlParameter6 = sqlParameter7;
      }
      else
      {
        sqlParameter6 = new SqlParameter("@Width", SqlDbType.Int, -1);
        sqlParameter6.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index6] = sqlParameter6;
      int index7 = 6;
      SqlParameter sqlParameter8;
      if (model.Height.HasValue)
      {
        SqlParameter sqlParameter7 = new SqlParameter("@Height", SqlDbType.Int, -1);
        sqlParameter7.Value = (object) model.Height;
        sqlParameter8 = sqlParameter7;
      }
      else
      {
        sqlParameter8 = new SqlParameter("@Height", SqlDbType.Int, -1);
        sqlParameter8.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index7] = sqlParameter8;
      int index8 = 7;
      SqlParameter sqlParameter9;
      if (model.Params != null)
      {
        SqlParameter sqlParameter7 = new SqlParameter("@Params", SqlDbType.VarChar, -1);
        sqlParameter7.Value = (object) model.Params;
        sqlParameter9 = sqlParameter7;
      }
      else
      {
        sqlParameter9 = new SqlParameter("@Params", SqlDbType.VarChar, -1);
        sqlParameter9.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index8] = sqlParameter9;
      int index9 = 8;
      SqlParameter sqlParameter10;
      if (model.Manager != null)
      {
        SqlParameter sqlParameter7 = new SqlParameter("@Manager", SqlDbType.VarChar, -1);
        sqlParameter7.Value = (object) model.Manager;
        sqlParameter10 = sqlParameter7;
      }
      else
      {
        sqlParameter10 = new SqlParameter("@Manager", SqlDbType.VarChar, -1);
        sqlParameter10.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index9] = sqlParameter10;
      int index10 = 9;
      SqlParameter sqlParameter11;
      if (model.Note != null)
      {
        SqlParameter sqlParameter7 = new SqlParameter("@Note", SqlDbType.VarChar, -1);
        sqlParameter7.Value = (object) model.Note;
        sqlParameter11 = sqlParameter7;
      }
      else
      {
        sqlParameter11 = new SqlParameter("@Note", SqlDbType.VarChar, -1);
        sqlParameter11.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index10] = sqlParameter11;
      int index11 = 10;
      SqlParameter sqlParameter12;
      if (model.Code != null)
      {
        SqlParameter sqlParameter7 = new SqlParameter("@Code", SqlDbType.VarChar, 50);
        sqlParameter7.Value = (object) model.Code;
        sqlParameter12 = sqlParameter7;
      }
      else
      {
        sqlParameter12 = new SqlParameter("@Code", SqlDbType.VarChar, 50);
        sqlParameter12.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index11] = sqlParameter12;
      int index12 = 11;
      SqlParameter sqlParameter13;
      if (model.Ico != null)
      {
        SqlParameter sqlParameter7 = new SqlParameter("@Ico", SqlDbType.VarChar, 2000);
        sqlParameter7.Value = (object) model.Ico;
        sqlParameter13 = sqlParameter7;
      }
      else
      {
        sqlParameter13 = new SqlParameter("@Ico", SqlDbType.VarChar, 2000);
        sqlParameter13.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index12] = sqlParameter13;
      int index13 = 12;
      SqlParameter sqlParameter14;
      if (model.Color != null)
      {
        SqlParameter sqlParameter7 = new SqlParameter("@Color", SqlDbType.VarChar, 50);
        sqlParameter7.Value = (object) model.Color;
        sqlParameter14 = sqlParameter7;
      }
      else
      {
        sqlParameter14 = new SqlParameter("@Color", SqlDbType.VarChar, 50);
        sqlParameter14.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index13] = sqlParameter14;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.AppLibrary model)
    {
      string sql = "UPDATE AppLibrary SET \r\n\t\t\t\tTitle=@Title,Address=@Address,Type=@Type,OpenMode=@OpenMode,Width=@Width,Height=@Height,Params=@Params,Manager=@Manager,Note=@Note,Code=@Code,Ico=@Ico,Color=@Color\r\n\t\t\t\tWHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[13];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@Title", SqlDbType.NVarChar, 510);
      sqlParameter1.Value = (object) model.Title;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@Address", SqlDbType.VarChar, 200);
      sqlParameter2.Value = (object) model.Address;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@Type", SqlDbType.UniqueIdentifier, -1);
      sqlParameter3.Value = (object) model.Type;
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter4 = new SqlParameter("@OpenMode", SqlDbType.Int, -1);
      sqlParameter4.Value = (object) model.OpenMode;
      sqlParameterArray[index4] = sqlParameter4;
      int index5 = 4;
      SqlParameter sqlParameter5;
      if (model.Width.HasValue)
      {
        SqlParameter sqlParameter6 = new SqlParameter("@Width", SqlDbType.Int, -1);
        sqlParameter6.Value = (object) model.Width;
        sqlParameter5 = sqlParameter6;
      }
      else
      {
        sqlParameter5 = new SqlParameter("@Width", SqlDbType.Int, -1);
        sqlParameter5.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index5] = sqlParameter5;
      int index6 = 5;
      SqlParameter sqlParameter7;
      if (model.Height.HasValue)
      {
        SqlParameter sqlParameter6 = new SqlParameter("@Height", SqlDbType.Int, -1);
        sqlParameter6.Value = (object) model.Height;
        sqlParameter7 = sqlParameter6;
      }
      else
      {
        sqlParameter7 = new SqlParameter("@Height", SqlDbType.Int, -1);
        sqlParameter7.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index6] = sqlParameter7;
      int index7 = 6;
      SqlParameter sqlParameter8;
      if (model.Params != null)
      {
        SqlParameter sqlParameter6 = new SqlParameter("@Params", SqlDbType.VarChar, -1);
        sqlParameter6.Value = (object) model.Params;
        sqlParameter8 = sqlParameter6;
      }
      else
      {
        sqlParameter8 = new SqlParameter("@Params", SqlDbType.VarChar, -1);
        sqlParameter8.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index7] = sqlParameter8;
      int index8 = 7;
      SqlParameter sqlParameter9;
      if (model.Manager != null)
      {
        SqlParameter sqlParameter6 = new SqlParameter("@Manager", SqlDbType.VarChar, -1);
        sqlParameter6.Value = (object) model.Manager;
        sqlParameter9 = sqlParameter6;
      }
      else
      {
        sqlParameter9 = new SqlParameter("@Manager", SqlDbType.VarChar, -1);
        sqlParameter9.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index8] = sqlParameter9;
      int index9 = 8;
      SqlParameter sqlParameter10;
      if (model.Note != null)
      {
        SqlParameter sqlParameter6 = new SqlParameter("@Note", SqlDbType.VarChar, -1);
        sqlParameter6.Value = (object) model.Note;
        sqlParameter10 = sqlParameter6;
      }
      else
      {
        sqlParameter10 = new SqlParameter("@Note", SqlDbType.VarChar, -1);
        sqlParameter10.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index9] = sqlParameter10;
      int index10 = 9;
      SqlParameter sqlParameter11;
      if (model.Code != null)
      {
        SqlParameter sqlParameter6 = new SqlParameter("@Code", SqlDbType.VarChar, 50);
        sqlParameter6.Value = (object) model.Code;
        sqlParameter11 = sqlParameter6;
      }
      else
      {
        sqlParameter11 = new SqlParameter("@Code", SqlDbType.VarChar, 50);
        sqlParameter11.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index10] = sqlParameter11;
      int index11 = 10;
      SqlParameter sqlParameter12;
      if (model.Ico != null)
      {
        SqlParameter sqlParameter6 = new SqlParameter("@Ico", SqlDbType.VarChar, 2000);
        sqlParameter6.Value = (object) model.Ico;
        sqlParameter12 = sqlParameter6;
      }
      else
      {
        sqlParameter12 = new SqlParameter("@Ico", SqlDbType.VarChar, 2000);
        sqlParameter12.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index11] = sqlParameter12;
      int index12 = 11;
      SqlParameter sqlParameter13;
      if (model.Color != null)
      {
        SqlParameter sqlParameter6 = new SqlParameter("@Color", SqlDbType.VarChar, 50);
        sqlParameter6.Value = (object) model.Color;
        sqlParameter13 = sqlParameter6;
      }
      else
      {
        sqlParameter13 = new SqlParameter("@Color", SqlDbType.VarChar, 50);
        sqlParameter13.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index12] = sqlParameter13;
      int index13 = 12;
      SqlParameter sqlParameter14 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter14.Value = (object) model.ID;
      sqlParameterArray[index13] = sqlParameter14;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM AppLibrary WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.AppLibrary> DataReaderToList(SqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.AppLibrary> appLibraryList = new List<RoadFlow.Data.Model.AppLibrary>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.AppLibrary appLibrary = new RoadFlow.Data.Model.AppLibrary();
        appLibrary.ID = dataReader.GetGuid(0);
        appLibrary.Title = dataReader.GetString(1);
        appLibrary.Address = dataReader.GetString(2);
        appLibrary.Type = dataReader.GetGuid(3);
        appLibrary.OpenMode = dataReader.GetInt32(4);
        if (!dataReader.IsDBNull(5))
          appLibrary.Width = new int?(dataReader.GetInt32(5));
        if (!dataReader.IsDBNull(6))
          appLibrary.Height = new int?(dataReader.GetInt32(6));
        if (!dataReader.IsDBNull(7))
          appLibrary.Params = dataReader.GetString(7);
        if (!dataReader.IsDBNull(8))
          appLibrary.Manager = dataReader.GetString(8);
        if (!dataReader.IsDBNull(9))
          appLibrary.Note = dataReader.GetString(9);
        if (!dataReader.IsDBNull(10))
          appLibrary.Code = dataReader.GetString(10);
        if (!dataReader.IsDBNull(11))
          appLibrary.Ico = dataReader.GetString(11);
        if (!dataReader.IsDBNull(12))
          appLibrary.Color = dataReader.GetString(12);
        appLibraryList.Add(appLibrary);
      }
      return appLibraryList;
    }

    public List<RoadFlow.Data.Model.AppLibrary> GetAll()
    {
      SqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM AppLibrary");
      List<RoadFlow.Data.Model.AppLibrary> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM AppLibrary"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.AppLibrary Get(Guid id)
    {
      string sql = "SELECT * FROM AppLibrary WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.AppLibrary> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.AppLibrary) null;
      return list[0];
    }

    public List<RoadFlow.Data.Model.AppLibrary> GetPagerData(out string pager, string query = "", string order = "Type,Title", int size = 15, int number = 1, string title = "", string type = "", string address = "")
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
        stringBuilder.AppendFormat("AND Type IN({0}) ", (object) Tools.GetSqlInString(type, true, ","));
      if (!address.IsNullOrEmpty())
      {
        stringBuilder.Append("AND CHARINDEX(@Address,Address)>0 ");
        List<SqlParameter> sqlParameterList2 = sqlParameterList1;
        SqlParameter sqlParameter = new SqlParameter("@Address", SqlDbType.VarChar);
        sqlParameter.Value = (object) address;
        sqlParameterList2.Add(sqlParameter);
      }
      long count;
      string paerSql = this.dbHelper.GetPaerSql(nameof (AppLibrary), "*", stringBuilder.ToString(), order, size, number, out count, sqlParameterList1.ToArray());
      pager = Tools.GetPagerHtml(count, size, number, query);
      SqlDataReader dataReader = this.dbHelper.GetDataReader(paerSql, sqlParameterList1.ToArray());
      List<RoadFlow.Data.Model.AppLibrary> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.AppLibrary> GetPagerData(out long count, int size = 15, int number = 1, string title = "", string type = "", string address = "", string order = "")
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
        stringBuilder.AppendFormat("AND Type IN({0}) ", (object) Tools.GetSqlInString(type, true, ","));
      if (!address.IsNullOrEmpty())
      {
        stringBuilder.Append("AND CHARINDEX(@Address,Address)>0 ");
        List<SqlParameter> sqlParameterList2 = sqlParameterList1;
        SqlParameter sqlParameter = new SqlParameter("@Address", SqlDbType.VarChar);
        sqlParameter.Value = (object) address;
        sqlParameterList2.Add(sqlParameter);
      }
      SqlDataReader dataReader = this.dbHelper.GetDataReader(this.dbHelper.GetPaerSql(nameof (AppLibrary), "*", stringBuilder.ToString(), order.IsNullOrEmpty() ? "Type,Title" : order, size, number, out count, sqlParameterList1.ToArray()), sqlParameterList1.ToArray());
      List<RoadFlow.Data.Model.AppLibrary> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.AppLibrary> GetAllByType(string types)
    {
      SqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM AppLibrary WHERE Type IN(" + Tools.GetSqlInString(types, true, ",") + ")");
      List<RoadFlow.Data.Model.AppLibrary> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public int Delete(string[] idArray)
    {
      return this.dbHelper.Execute("DELETE FROM AppLibrary WHERE ID in(" + Tools.GetSqlInString<string>(idArray, true) + ")");
    }

    public RoadFlow.Data.Model.AppLibrary GetByCode(string code)
    {
      string sql = "SELECT * FROM AppLibrary WHERE Code=@Code";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@Code", SqlDbType.VarChar, 50);
      sqlParameter.Value = (object) code;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.AppLibrary> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.AppLibrary) null;
      return list[0];
    }
  }
}
