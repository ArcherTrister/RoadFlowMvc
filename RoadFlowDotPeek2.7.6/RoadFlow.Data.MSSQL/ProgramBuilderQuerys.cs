// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MSSQL.ProgramBuilderQuerys
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
  public class ProgramBuilderQuerys : IProgramBuilderQuerys
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.ProgramBuilderQuerys model)
    {
      string sql = "INSERT INTO ProgramBuilderQuerys\r\n\t\t\t\t(ID,ProgramID,Field,ShowTitle,Operators,ControlName,InputType,Width,Sort,DataSource,DataSourceString,DataLinkID,IsQueryUsers,Value) \r\n\t\t\t\tVALUES(@ID,@ProgramID,@Field,@ShowTitle,@Operators,@ControlName,@InputType,@Width,@Sort,@DataSource,@DataSourceString,@DataLinkID,@IsQueryUsers,@Value)";
      SqlParameter[] sqlParameterArray = new SqlParameter[14];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter1.Value = (object) model.ID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@ProgramID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter2.Value = (object) model.ProgramID;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@Field", SqlDbType.VarChar, 500);
      sqlParameter3.Value = (object) model.Field;
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter4 = new SqlParameter("@ShowTitle", SqlDbType.NVarChar, 1000);
      sqlParameter4.Value = (object) model.ShowTitle;
      sqlParameterArray[index4] = sqlParameter4;
      int index5 = 4;
      SqlParameter sqlParameter5 = new SqlParameter("@Operators", SqlDbType.VarChar, 50);
      sqlParameter5.Value = (object) model.Operators;
      sqlParameterArray[index5] = sqlParameter5;
      int index6 = 5;
      SqlParameter sqlParameter6 = new SqlParameter("@ControlName", SqlDbType.VarChar, 50);
      sqlParameter6.Value = (object) model.ControlName;
      sqlParameterArray[index6] = sqlParameter6;
      int index7 = 6;
      SqlParameter sqlParameter7 = new SqlParameter("@InputType", SqlDbType.Int, -1);
      sqlParameter7.Value = (object) model.InputType;
      sqlParameterArray[index7] = sqlParameter7;
      int index8 = 7;
      SqlParameter sqlParameter8;
      if (model.Width != null)
      {
        SqlParameter sqlParameter9 = new SqlParameter("@Width", SqlDbType.VarChar, 50);
        sqlParameter9.Value = (object) model.Width;
        sqlParameter8 = sqlParameter9;
      }
      else
      {
        sqlParameter8 = new SqlParameter("@Width", SqlDbType.VarChar, 50);
        sqlParameter8.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index8] = sqlParameter8;
      int index9 = 8;
      SqlParameter sqlParameter10 = new SqlParameter("@Sort", SqlDbType.Int, -1);
      sqlParameter10.Value = (object) model.Sort;
      sqlParameterArray[index9] = sqlParameter10;
      int index10 = 9;
      int? nullable = model.DataSource;
      SqlParameter sqlParameter11;
      if (nullable.HasValue)
      {
        SqlParameter sqlParameter9 = new SqlParameter("@DataSource", SqlDbType.Int, -1);
        sqlParameter9.Value = (object) model.DataSource;
        sqlParameter11 = sqlParameter9;
      }
      else
      {
        sqlParameter11 = new SqlParameter("@DataSource", SqlDbType.Int, -1);
        sqlParameter11.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index10] = sqlParameter11;
      int index11 = 10;
      SqlParameter sqlParameter12;
      if (model.DataSourceString != null)
      {
        SqlParameter sqlParameter9 = new SqlParameter("@DataSourceString", SqlDbType.VarChar, -1);
        sqlParameter9.Value = (object) model.DataSourceString;
        sqlParameter12 = sqlParameter9;
      }
      else
      {
        sqlParameter12 = new SqlParameter("@DataSourceString", SqlDbType.VarChar, -1);
        sqlParameter12.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index11] = sqlParameter12;
      int index12 = 11;
      SqlParameter sqlParameter13;
      if (model.DataLinkID != null)
      {
        SqlParameter sqlParameter9 = new SqlParameter("@DataLinkID", SqlDbType.VarChar, 50);
        sqlParameter9.Value = (object) model.DataLinkID;
        sqlParameter13 = sqlParameter9;
      }
      else
      {
        sqlParameter13 = new SqlParameter("@DataLinkID", SqlDbType.VarChar, 50);
        sqlParameter13.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index12] = sqlParameter13;
      int index13 = 12;
      nullable = model.IsQueryUsers;
      SqlParameter sqlParameter14;
      if (nullable.HasValue)
      {
        SqlParameter sqlParameter9 = new SqlParameter("@IsQueryUsers", SqlDbType.Int, -1);
        sqlParameter9.Value = (object) model.IsQueryUsers;
        sqlParameter14 = sqlParameter9;
      }
      else
      {
        sqlParameter14 = new SqlParameter("@IsQueryUsers", SqlDbType.Int, -1);
        sqlParameter14.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index13] = sqlParameter14;
      int index14 = 13;
      SqlParameter sqlParameter15;
      if (model.Value != null)
      {
        SqlParameter sqlParameter9 = new SqlParameter("@Value", SqlDbType.VarChar, 50);
        sqlParameter9.Value = (object) model.Value;
        sqlParameter15 = sqlParameter9;
      }
      else
      {
        sqlParameter15 = new SqlParameter("@Value", SqlDbType.VarChar, 50);
        sqlParameter15.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index14] = sqlParameter15;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.ProgramBuilderQuerys model)
    {
      string sql = "UPDATE ProgramBuilderQuerys SET \r\n\t\t\t\tProgramID=@ProgramID,Field=@Field,ShowTitle=@ShowTitle,Operators=@Operators,ControlName=@ControlName,InputType=@InputType,Width=@Width,Sort=@Sort,DataSource=@DataSource,DataSourceString=@DataSourceString,DataLinkID=@DataLinkID,IsQueryUsers=@IsQueryUsers,Value=@Value\r\n\t\t\t\tWHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[14];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@ProgramID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter1.Value = (object) model.ProgramID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@Field", SqlDbType.VarChar, 500);
      sqlParameter2.Value = (object) model.Field;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@ShowTitle", SqlDbType.NVarChar, 1000);
      sqlParameter3.Value = (object) model.ShowTitle;
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter4 = new SqlParameter("@Operators", SqlDbType.VarChar, 50);
      sqlParameter4.Value = (object) model.Operators;
      sqlParameterArray[index4] = sqlParameter4;
      int index5 = 4;
      SqlParameter sqlParameter5 = new SqlParameter("@ControlName", SqlDbType.VarChar, 50);
      sqlParameter5.Value = (object) model.ControlName;
      sqlParameterArray[index5] = sqlParameter5;
      int index6 = 5;
      SqlParameter sqlParameter6 = new SqlParameter("@InputType", SqlDbType.Int, -1);
      sqlParameter6.Value = (object) model.InputType;
      sqlParameterArray[index6] = sqlParameter6;
      int index7 = 6;
      SqlParameter sqlParameter7;
      if (model.Width != null)
      {
        SqlParameter sqlParameter8 = new SqlParameter("@Width", SqlDbType.VarChar, 50);
        sqlParameter8.Value = (object) model.Width;
        sqlParameter7 = sqlParameter8;
      }
      else
      {
        sqlParameter7 = new SqlParameter("@Width", SqlDbType.VarChar, 50);
        sqlParameter7.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index7] = sqlParameter7;
      int index8 = 7;
      SqlParameter sqlParameter9 = new SqlParameter("@Sort", SqlDbType.Int, -1);
      sqlParameter9.Value = (object) model.Sort;
      sqlParameterArray[index8] = sqlParameter9;
      int index9 = 8;
      int? nullable = model.DataSource;
      SqlParameter sqlParameter10;
      if (nullable.HasValue)
      {
        SqlParameter sqlParameter8 = new SqlParameter("@DataSource", SqlDbType.Int, -1);
        sqlParameter8.Value = (object) model.DataSource;
        sqlParameter10 = sqlParameter8;
      }
      else
      {
        sqlParameter10 = new SqlParameter("@DataSource", SqlDbType.Int, -1);
        sqlParameter10.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index9] = sqlParameter10;
      int index10 = 9;
      SqlParameter sqlParameter11;
      if (model.DataSourceString != null)
      {
        SqlParameter sqlParameter8 = new SqlParameter("@DataSourceString", SqlDbType.VarChar, -1);
        sqlParameter8.Value = (object) model.DataSourceString;
        sqlParameter11 = sqlParameter8;
      }
      else
      {
        sqlParameter11 = new SqlParameter("@DataSourceString", SqlDbType.VarChar, -1);
        sqlParameter11.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index10] = sqlParameter11;
      int index11 = 10;
      SqlParameter sqlParameter12;
      if (model.DataLinkID != null)
      {
        SqlParameter sqlParameter8 = new SqlParameter("@DataLinkID", SqlDbType.VarChar, 50);
        sqlParameter8.Value = (object) model.DataLinkID;
        sqlParameter12 = sqlParameter8;
      }
      else
      {
        sqlParameter12 = new SqlParameter("@DataLinkID", SqlDbType.VarChar, 50);
        sqlParameter12.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index11] = sqlParameter12;
      int index12 = 11;
      nullable = model.IsQueryUsers;
      SqlParameter sqlParameter13;
      if (nullable.HasValue)
      {
        SqlParameter sqlParameter8 = new SqlParameter("@IsQueryUsers", SqlDbType.Int, -1);
        sqlParameter8.Value = (object) model.IsQueryUsers;
        sqlParameter13 = sqlParameter8;
      }
      else
      {
        sqlParameter13 = new SqlParameter("@IsQueryUsers", SqlDbType.Int, -1);
        sqlParameter13.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index12] = sqlParameter13;
      int index13 = 12;
      SqlParameter sqlParameter14;
      if (model.Value != null)
      {
        SqlParameter sqlParameter8 = new SqlParameter("@Value", SqlDbType.VarChar, 50);
        sqlParameter8.Value = (object) model.Value;
        sqlParameter14 = sqlParameter8;
      }
      else
      {
        sqlParameter14 = new SqlParameter("@Value", SqlDbType.VarChar, 50);
        sqlParameter14.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index13] = sqlParameter14;
      int index14 = 13;
      SqlParameter sqlParameter15 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter15.Value = (object) model.ID;
      sqlParameterArray[index14] = sqlParameter15;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM ProgramBuilderQuerys WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.ProgramBuilderQuerys> DataReaderToList(SqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.ProgramBuilderQuerys> programBuilderQuerysList = new List<RoadFlow.Data.Model.ProgramBuilderQuerys>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.ProgramBuilderQuerys programBuilderQuerys = new RoadFlow.Data.Model.ProgramBuilderQuerys();
        programBuilderQuerys.ID = dataReader.GetGuid(0);
        programBuilderQuerys.ProgramID = dataReader.GetGuid(1);
        programBuilderQuerys.Field = dataReader.GetString(2);
        programBuilderQuerys.ShowTitle = dataReader.GetString(3);
        programBuilderQuerys.Operators = dataReader.GetString(4);
        programBuilderQuerys.ControlName = dataReader.GetString(5);
        programBuilderQuerys.InputType = dataReader.GetInt32(6);
        if (!dataReader.IsDBNull(7))
          programBuilderQuerys.Width = dataReader.GetString(7);
        programBuilderQuerys.Sort = dataReader.GetInt32(8);
        if (!dataReader.IsDBNull(9))
          programBuilderQuerys.DataSource = new int?(dataReader.GetInt32(9));
        if (!dataReader.IsDBNull(10))
          programBuilderQuerys.DataSourceString = dataReader.GetString(10);
        if (!dataReader.IsDBNull(11))
          programBuilderQuerys.DataLinkID = dataReader.GetString(11);
        if (!dataReader.IsDBNull(12))
          programBuilderQuerys.IsQueryUsers = new int?(dataReader.GetInt32(12));
        if (!dataReader.IsDBNull(13))
          programBuilderQuerys.Value = dataReader.GetString(13);
        programBuilderQuerysList.Add(programBuilderQuerys);
      }
      return programBuilderQuerysList;
    }

    public List<RoadFlow.Data.Model.ProgramBuilderQuerys> GetAll()
    {
      SqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM ProgramBuilderQuerys");
      List<RoadFlow.Data.Model.ProgramBuilderQuerys> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM ProgramBuilderQuerys"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.ProgramBuilderQuerys Get(Guid id)
    {
      string sql = "SELECT * FROM ProgramBuilderQuerys WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.ProgramBuilderQuerys> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.ProgramBuilderQuerys) null;
      return list[0];
    }

    public List<RoadFlow.Data.Model.ProgramBuilderQuerys> GetAll(Guid programID)
    {
      string sql = "SELECT * FROM ProgramBuilderQuerys WHERE ProgramID=@ProgramID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ProgramID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) programID;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.ProgramBuilderQuerys> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public int DeleteByProgramID(Guid id)
    {
      string sql = "DELETE FROM ProgramBuilderQuerys WHERE ProgramID=@ProgramID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ProgramID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }
  }
}
