// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MySql.ProgramBuilderQuerys
// Assembly: RoadFlow.Data.MySql, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 29B652D7-5F6F-4A7D-AD1C-9F2C643FD784
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.MySql.dll

using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.MySql
{
  public class ProgramBuilderQuerys : IProgramBuilderQuerys
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.ProgramBuilderQuerys model)
    {
      string sql = "INSERT INTO programbuilderquerys\r\n\t\t\t\t(ID,ProgramID,Field,ShowTitle,Operators,ControlName,InputType,Width,Sort,DataSource,DataSourceString,DataLinkID,IsQueryUsers,Value) \r\n\t\t\t\tVALUES(@ID,@ProgramID,@Field,@ShowTitle,@Operators,@ControlName,@InputType,@Width,@Sort,@DataSource,@DataSourceString,@DataLinkID,@IsQueryUsers,@Value)";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[14];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter1.Value = (object) model.ID;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@ProgramID", MySqlDbType.VarChar, 36);
      mySqlParameter2.Value = (object) model.ProgramID;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@Field", MySqlDbType.Text, -1);
      mySqlParameter3.Value = (object) model.Field;
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter4 = new MySqlParameter("@ShowTitle", MySqlDbType.Text, -1);
      mySqlParameter4.Value = (object) model.ShowTitle;
      mySqlParameterArray[index4] = mySqlParameter4;
      int index5 = 4;
      MySqlParameter mySqlParameter5 = new MySqlParameter("@Operators", MySqlDbType.VarChar, 50);
      mySqlParameter5.Value = (object) model.Operators;
      mySqlParameterArray[index5] = mySqlParameter5;
      int index6 = 5;
      MySqlParameter mySqlParameter6 = new MySqlParameter("@ControlName", MySqlDbType.VarChar, 50);
      mySqlParameter6.Value = (object) model.ControlName;
      mySqlParameterArray[index6] = mySqlParameter6;
      int index7 = 6;
      MySqlParameter mySqlParameter7 = new MySqlParameter("@InputType", MySqlDbType.Int32, 11);
      mySqlParameter7.Value = (object) model.InputType;
      mySqlParameterArray[index7] = mySqlParameter7;
      int index8 = 7;
      MySqlParameter mySqlParameter8;
      if (model.Width != null)
      {
        MySqlParameter mySqlParameter9 = new MySqlParameter("@Width", MySqlDbType.VarChar, 50);
        mySqlParameter9.Value = (object) model.Width;
        mySqlParameter8 = mySqlParameter9;
      }
      else
      {
        mySqlParameter8 = new MySqlParameter("@Width", MySqlDbType.VarChar, 50);
        mySqlParameter8.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index8] = mySqlParameter8;
      int index9 = 8;
      MySqlParameter mySqlParameter10 = new MySqlParameter("@Sort", MySqlDbType.Int32, 11);
      mySqlParameter10.Value = (object) model.Sort;
      mySqlParameterArray[index9] = mySqlParameter10;
      int index10 = 9;
      int? nullable = model.DataSource;
      MySqlParameter mySqlParameter11;
      if (nullable.HasValue)
      {
        MySqlParameter mySqlParameter9 = new MySqlParameter("@DataSource", MySqlDbType.Int32, 11);
        mySqlParameter9.Value = (object) model.DataSource;
        mySqlParameter11 = mySqlParameter9;
      }
      else
      {
        mySqlParameter11 = new MySqlParameter("@DataSource", MySqlDbType.Int32, 11);
        mySqlParameter11.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index10] = mySqlParameter11;
      int index11 = 10;
      MySqlParameter mySqlParameter12;
      if (model.DataSourceString != null)
      {
        MySqlParameter mySqlParameter9 = new MySqlParameter("@DataSourceString", MySqlDbType.LongText, -1);
        mySqlParameter9.Value = (object) model.DataSourceString;
        mySqlParameter12 = mySqlParameter9;
      }
      else
      {
        mySqlParameter12 = new MySqlParameter("@DataSourceString", MySqlDbType.LongText, -1);
        mySqlParameter12.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index11] = mySqlParameter12;
      int index12 = 11;
      MySqlParameter mySqlParameter13;
      if (model.DataLinkID != null)
      {
        MySqlParameter mySqlParameter9 = new MySqlParameter("@DataLinkID", MySqlDbType.VarChar, 50);
        mySqlParameter9.Value = (object) model.DataLinkID;
        mySqlParameter13 = mySqlParameter9;
      }
      else
      {
        mySqlParameter13 = new MySqlParameter("@DataLinkID", MySqlDbType.VarChar, 50);
        mySqlParameter13.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index12] = mySqlParameter13;
      int index13 = 12;
      nullable = model.IsQueryUsers;
      MySqlParameter mySqlParameter14;
      if (nullable.HasValue)
      {
        MySqlParameter mySqlParameter9 = new MySqlParameter("@IsQueryUsers", MySqlDbType.Int32, 11);
        mySqlParameter9.Value = (object) model.IsQueryUsers;
        mySqlParameter14 = mySqlParameter9;
      }
      else
      {
        mySqlParameter14 = new MySqlParameter("@IsQueryUsers", MySqlDbType.Int32, 11);
        mySqlParameter14.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index13] = mySqlParameter14;
      int index14 = 13;
      MySqlParameter mySqlParameter15;
      if (model.Value != null)
      {
        MySqlParameter mySqlParameter9 = new MySqlParameter("@Value", MySqlDbType.VarChar, 50);
        mySqlParameter9.Value = (object) model.Value;
        mySqlParameter15 = mySqlParameter9;
      }
      else
      {
        mySqlParameter15 = new MySqlParameter("@Value", MySqlDbType.VarChar, 50);
        mySqlParameter15.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index14] = mySqlParameter15;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.ProgramBuilderQuerys model)
    {
      string sql = "UPDATE programbuilderquerys SET \r\n\t\t\t\tProgramID=@ProgramID,Field=@Field,ShowTitle=@ShowTitle,Operators=@Operators,ControlName=@ControlName,InputType=@InputType,Width=@Width,Sort=@Sort,DataSource=@DataSource,DataSourceString=@DataSourceString,DataLinkID=@DataLinkID,IsQueryUsers=@IsQueryUsers,Value=@Value\r\n\t\t\t\tWHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[14];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@ProgramID", MySqlDbType.VarChar, 36);
      mySqlParameter1.Value = (object) model.ProgramID;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@Field", MySqlDbType.Text, -1);
      mySqlParameter2.Value = (object) model.Field;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@ShowTitle", MySqlDbType.Text, -1);
      mySqlParameter3.Value = (object) model.ShowTitle;
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter4 = new MySqlParameter("@Operators", MySqlDbType.VarChar, 50);
      mySqlParameter4.Value = (object) model.Operators;
      mySqlParameterArray[index4] = mySqlParameter4;
      int index5 = 4;
      MySqlParameter mySqlParameter5 = new MySqlParameter("@ControlName", MySqlDbType.VarChar, 50);
      mySqlParameter5.Value = (object) model.ControlName;
      mySqlParameterArray[index5] = mySqlParameter5;
      int index6 = 5;
      MySqlParameter mySqlParameter6 = new MySqlParameter("@InputType", MySqlDbType.Int32, 11);
      mySqlParameter6.Value = (object) model.InputType;
      mySqlParameterArray[index6] = mySqlParameter6;
      int index7 = 6;
      MySqlParameter mySqlParameter7;
      if (model.Width != null)
      {
        MySqlParameter mySqlParameter8 = new MySqlParameter("@Width", MySqlDbType.VarChar, 50);
        mySqlParameter8.Value = (object) model.Width;
        mySqlParameter7 = mySqlParameter8;
      }
      else
      {
        mySqlParameter7 = new MySqlParameter("@Width", MySqlDbType.VarChar, 50);
        mySqlParameter7.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index7] = mySqlParameter7;
      int index8 = 7;
      MySqlParameter mySqlParameter9 = new MySqlParameter("@Sort", MySqlDbType.Int32, 11);
      mySqlParameter9.Value = (object) model.Sort;
      mySqlParameterArray[index8] = mySqlParameter9;
      int index9 = 8;
      int? nullable = model.DataSource;
      MySqlParameter mySqlParameter10;
      if (nullable.HasValue)
      {
        MySqlParameter mySqlParameter8 = new MySqlParameter("@DataSource", MySqlDbType.Int32, 11);
        mySqlParameter8.Value = (object) model.DataSource;
        mySqlParameter10 = mySqlParameter8;
      }
      else
      {
        mySqlParameter10 = new MySqlParameter("@DataSource", MySqlDbType.Int32, 11);
        mySqlParameter10.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index9] = mySqlParameter10;
      int index10 = 9;
      MySqlParameter mySqlParameter11;
      if (model.DataSourceString != null)
      {
        MySqlParameter mySqlParameter8 = new MySqlParameter("@DataSourceString", MySqlDbType.LongText, -1);
        mySqlParameter8.Value = (object) model.DataSourceString;
        mySqlParameter11 = mySqlParameter8;
      }
      else
      {
        mySqlParameter11 = new MySqlParameter("@DataSourceString", MySqlDbType.LongText, -1);
        mySqlParameter11.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index10] = mySqlParameter11;
      int index11 = 10;
      MySqlParameter mySqlParameter12;
      if (model.DataLinkID != null)
      {
        MySqlParameter mySqlParameter8 = new MySqlParameter("@DataLinkID", MySqlDbType.VarChar, 50);
        mySqlParameter8.Value = (object) model.DataLinkID;
        mySqlParameter12 = mySqlParameter8;
      }
      else
      {
        mySqlParameter12 = new MySqlParameter("@DataLinkID", MySqlDbType.VarChar, 50);
        mySqlParameter12.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index11] = mySqlParameter12;
      int index12 = 11;
      nullable = model.IsQueryUsers;
      MySqlParameter mySqlParameter13;
      if (nullable.HasValue)
      {
        MySqlParameter mySqlParameter8 = new MySqlParameter("@IsQueryUsers", MySqlDbType.Int32, 11);
        mySqlParameter8.Value = (object) model.IsQueryUsers;
        mySqlParameter13 = mySqlParameter8;
      }
      else
      {
        mySqlParameter13 = new MySqlParameter("@IsQueryUsers", MySqlDbType.Int32, 11);
        mySqlParameter13.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index12] = mySqlParameter13;
      int index13 = 12;
      MySqlParameter mySqlParameter14;
      if (model.Value != null)
      {
        MySqlParameter mySqlParameter8 = new MySqlParameter("@Value", MySqlDbType.VarChar, 50);
        mySqlParameter8.Value = (object) model.Value;
        mySqlParameter14 = mySqlParameter8;
      }
      else
      {
        mySqlParameter14 = new MySqlParameter("@Value", MySqlDbType.VarChar, 50);
        mySqlParameter14.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index13] = mySqlParameter14;
      int index14 = 13;
      MySqlParameter mySqlParameter15 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter15.Value = (object) model.ID;
      mySqlParameterArray[index14] = mySqlParameter15;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM programbuilderquerys WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.ProgramBuilderQuerys> DataReaderToList(MySqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.ProgramBuilderQuerys> programBuilderQuerysList = new List<RoadFlow.Data.Model.ProgramBuilderQuerys>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.ProgramBuilderQuerys programBuilderQuerys = new RoadFlow.Data.Model.ProgramBuilderQuerys();
        programBuilderQuerys.ID = dataReader.GetString(0).ToGuid();
        programBuilderQuerys.ProgramID = dataReader.GetString(1).ToGuid();
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
      MySqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM programbuilderquerys");
      List<RoadFlow.Data.Model.ProgramBuilderQuerys> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM programbuilderquerys"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.ProgramBuilderQuerys Get(Guid id)
    {
      string sql = "SELECT * FROM programbuilderquerys WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.ProgramBuilderQuerys> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.ProgramBuilderQuerys) null;
      return list[0];
    }

    public List<RoadFlow.Data.Model.ProgramBuilderQuerys> GetAll(Guid programID)
    {
      string sql = "SELECT * FROM ProgramBuilderQuerys WHERE ProgramID=@ProgramID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ProgramID", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) programID.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.ProgramBuilderQuerys> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public int DeleteByProgramID(Guid id)
    {
      string sql = "DELETE FROM ProgramBuilderQuerys WHERE ProgramID=@ProgramID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ProgramID", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }
  }
}
