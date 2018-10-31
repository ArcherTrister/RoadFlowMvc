// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MSSQL.AppLibraryButtons1
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
  public class AppLibraryButtons1 : IAppLibraryButtons1
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.AppLibraryButtons1 model)
    {
      string sql = "INSERT INTO AppLibraryButtons1\r\n\t\t\t\t(ID,AppLibraryID,ButtonID,Name,Events,Ico,Sort,Type,ShowType,IsValidateShow) \r\n\t\t\t\tVALUES(@ID,@AppLibraryID,@ButtonID,@Name,@Events,@Ico,@Sort,@Type,@ShowType,@IsValidateShow)";
      SqlParameter[] sqlParameterArray = new SqlParameter[10];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter1.Value = (object) model.ID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@AppLibraryID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter2.Value = (object) model.AppLibraryID;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3;
      if (model.ButtonID.HasValue)
      {
        SqlParameter sqlParameter4 = new SqlParameter("@ButtonID", SqlDbType.UniqueIdentifier, -1);
        sqlParameter4.Value = (object) model.ButtonID;
        sqlParameter3 = sqlParameter4;
      }
      else
      {
        sqlParameter3 = new SqlParameter("@ButtonID", SqlDbType.UniqueIdentifier, -1);
        sqlParameter3.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter5 = new SqlParameter("@Name", SqlDbType.NVarChar, 1000);
      sqlParameter5.Value = (object) model.Name;
      sqlParameterArray[index4] = sqlParameter5;
      int index5 = 4;
      SqlParameter sqlParameter6 = new SqlParameter("@Events", SqlDbType.VarChar, 5000);
      sqlParameter6.Value = (object) model.Events;
      sqlParameterArray[index5] = sqlParameter6;
      int index6 = 5;
      SqlParameter sqlParameter7 = new SqlParameter("@Ico", SqlDbType.VarChar, 2000);
      sqlParameter7.Value = (object) model.Ico;
      sqlParameterArray[index6] = sqlParameter7;
      int index7 = 6;
      SqlParameter sqlParameter8 = new SqlParameter("@Sort", SqlDbType.Int, -1);
      sqlParameter8.Value = (object) model.Sort;
      sqlParameterArray[index7] = sqlParameter8;
      int index8 = 7;
      SqlParameter sqlParameter9 = new SqlParameter("@Type", SqlDbType.Int, -1);
      sqlParameter9.Value = (object) model.Type;
      sqlParameterArray[index8] = sqlParameter9;
      int index9 = 8;
      SqlParameter sqlParameter10 = new SqlParameter("@ShowType", SqlDbType.Int, -1);
      sqlParameter10.Value = (object) model.ShowType;
      sqlParameterArray[index9] = sqlParameter10;
      int index10 = 9;
      SqlParameter sqlParameter11 = new SqlParameter("@IsValidateShow", SqlDbType.Int, -1);
      sqlParameter11.Value = (object) model.IsValidateShow;
      sqlParameterArray[index10] = sqlParameter11;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.AppLibraryButtons1 model)
    {
      string sql = "UPDATE AppLibraryButtons1 SET \r\n\t\t\t\tAppLibraryID=@AppLibraryID,ButtonID=@ButtonID,Name=@Name,Events=@Events,Ico=@Ico,Sort=@Sort,Type=@Type,ShowType=@ShowType,IsValidateShow=@IsValidateShow\r\n\t\t\t\tWHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[10];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@AppLibraryID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter1.Value = (object) model.AppLibraryID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2;
      if (model.ButtonID.HasValue)
      {
        SqlParameter sqlParameter3 = new SqlParameter("@ButtonID", SqlDbType.UniqueIdentifier, -1);
        sqlParameter3.Value = (object) model.ButtonID;
        sqlParameter2 = sqlParameter3;
      }
      else
      {
        sqlParameter2 = new SqlParameter("@ButtonID", SqlDbType.UniqueIdentifier, -1);
        sqlParameter2.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter4 = new SqlParameter("@Name", SqlDbType.NVarChar, 1000);
      sqlParameter4.Value = (object) model.Name;
      sqlParameterArray[index3] = sqlParameter4;
      int index4 = 3;
      SqlParameter sqlParameter5 = new SqlParameter("@Events", SqlDbType.VarChar, 5000);
      sqlParameter5.Value = (object) model.Events;
      sqlParameterArray[index4] = sqlParameter5;
      int index5 = 4;
      SqlParameter sqlParameter6 = new SqlParameter("@Ico", SqlDbType.VarChar, 2000);
      sqlParameter6.Value = (object) model.Ico;
      sqlParameterArray[index5] = sqlParameter6;
      int index6 = 5;
      SqlParameter sqlParameter7 = new SqlParameter("@Sort", SqlDbType.Int, -1);
      sqlParameter7.Value = (object) model.Sort;
      sqlParameterArray[index6] = sqlParameter7;
      int index7 = 6;
      SqlParameter sqlParameter8 = new SqlParameter("@Type", SqlDbType.Int, -1);
      sqlParameter8.Value = (object) model.Type;
      sqlParameterArray[index7] = sqlParameter8;
      int index8 = 7;
      SqlParameter sqlParameter9 = new SqlParameter("@ShowType", SqlDbType.Int, -1);
      sqlParameter9.Value = (object) model.ShowType;
      sqlParameterArray[index8] = sqlParameter9;
      int index9 = 8;
      SqlParameter sqlParameter10 = new SqlParameter("@IsValidateShow", SqlDbType.Int, -1);
      sqlParameter10.Value = (object) model.IsValidateShow;
      sqlParameterArray[index9] = sqlParameter10;
      int index10 = 9;
      SqlParameter sqlParameter11 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter11.Value = (object) model.ID;
      sqlParameterArray[index10] = sqlParameter11;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM AppLibraryButtons1 WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.AppLibraryButtons1> DataReaderToList(SqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.AppLibraryButtons1> appLibraryButtons1List = new List<RoadFlow.Data.Model.AppLibraryButtons1>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.AppLibraryButtons1 appLibraryButtons1 = new RoadFlow.Data.Model.AppLibraryButtons1();
        appLibraryButtons1.ID = dataReader.GetGuid(0);
        appLibraryButtons1.AppLibraryID = dataReader.GetGuid(1);
        if (!dataReader.IsDBNull(2))
          appLibraryButtons1.ButtonID = new Guid?(dataReader.GetGuid(2));
        appLibraryButtons1.Name = dataReader.GetString(3);
        appLibraryButtons1.Events = dataReader.GetString(4);
        if (!dataReader.IsDBNull(5))
          appLibraryButtons1.Ico = dataReader.GetString(5);
        appLibraryButtons1.Sort = dataReader.GetInt32(6);
        appLibraryButtons1.Type = dataReader.GetInt32(7);
        appLibraryButtons1.ShowType = dataReader.GetInt32(8);
        appLibraryButtons1.IsValidateShow = dataReader.GetInt32(9);
        appLibraryButtons1List.Add(appLibraryButtons1);
      }
      return appLibraryButtons1List;
    }

    public List<RoadFlow.Data.Model.AppLibraryButtons1> GetAll()
    {
      SqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM AppLibraryButtons1");
      List<RoadFlow.Data.Model.AppLibraryButtons1> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM AppLibraryButtons1"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.AppLibraryButtons1 Get(Guid id)
    {
      string sql = "SELECT * FROM AppLibraryButtons1 WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.AppLibraryButtons1> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.AppLibraryButtons1) null;
      return list[0];
    }

    public int DeleteByAppID(Guid id)
    {
      string sql = "DELETE FROM AppLibraryButtons1 WHERE AppLibraryID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public List<RoadFlow.Data.Model.AppLibraryButtons1> GetAllByAppID(Guid id)
    {
      string sql = "SELECT * FROM AppLibraryButtons1 WHERE AppLibraryID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.AppLibraryButtons1> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }
  }
}
