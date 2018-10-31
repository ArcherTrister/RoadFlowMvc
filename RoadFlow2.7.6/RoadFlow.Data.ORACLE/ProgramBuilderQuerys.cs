// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.ORACLE.ProgramBuilderQuerys
// Assembly: RoadFlow.Data.ORACLE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C9018AA1-E48E-4231-92A9-CD6F0F275D11
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.ORACLE.dll

using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.ORACLE
{
  public class ProgramBuilderQuerys : IProgramBuilderQuerys
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.ProgramBuilderQuerys model)
    {
      string sql = "INSERT INTO ProgramBuilderQuerys\r\n\t\t\t\t(ID,ProgramID,Field,ShowTitle,Operators,ControlName,InputType,Width,Sort,DataSource,DataSourceString,DataLinkID,IsQueryUsers,Value) \r\n\t\t\t\tVALUES(:ID,:ProgramID,:Field,:ShowTitle,:Operators,:ControlName,:InputType,:Width,:Sort,:DataSource,:DataSourceString,:DataLinkID,:IsQueryUsers,:Value)";
      OracleParameter[] oracleParameterArray = new OracleParameter[14];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter1.Value = (object) model.ID;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":ProgramID", OracleDbType.Varchar2);
      oracleParameter2.Value = (object) model.ProgramID;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3 = new OracleParameter(":Field", OracleDbType.Varchar2);
      oracleParameter3.Value = (object) model.Field;
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter4 = new OracleParameter(":ShowTitle", OracleDbType.Varchar2);
      oracleParameter4.Value = (object) model.ShowTitle;
      oracleParameterArray[index4] = oracleParameter4;
      int index5 = 4;
      OracleParameter oracleParameter5 = new OracleParameter(":Operators", OracleDbType.Varchar2);
      oracleParameter5.Value = (object) model.Operators;
      oracleParameterArray[index5] = oracleParameter5;
      int index6 = 5;
      OracleParameter oracleParameter6 = new OracleParameter(":ControlName", OracleDbType.Varchar2);
      oracleParameter6.Value = (object) model.ControlName;
      oracleParameterArray[index6] = oracleParameter6;
      int index7 = 6;
      OracleParameter oracleParameter7 = new OracleParameter(":InputType", OracleDbType.Int32);
      oracleParameter7.Value = (object) model.InputType;
      oracleParameterArray[index7] = oracleParameter7;
      int index8 = 7;
      OracleParameter oracleParameter8;
      if (model.Width != null)
      {
        OracleParameter oracleParameter9 = new OracleParameter(":Width", OracleDbType.Varchar2);
        oracleParameter9.Value = (object) model.Width;
        oracleParameter8 = oracleParameter9;
      }
      else
      {
        oracleParameter8 = new OracleParameter(":Width", OracleDbType.Varchar2);
        oracleParameter8.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index8] = oracleParameter8;
      int index9 = 8;
      OracleParameter oracleParameter10 = new OracleParameter(":Sort", OracleDbType.Int32);
      oracleParameter10.Value = (object) model.Sort;
      oracleParameterArray[index9] = oracleParameter10;
      int index10 = 9;
      int? nullable = model.DataSource;
      OracleParameter oracleParameter11;
      if (nullable.HasValue)
      {
        OracleParameter oracleParameter9 = new OracleParameter(":DataSource", OracleDbType.Int32);
        oracleParameter9.Value = (object) model.DataSource;
        oracleParameter11 = oracleParameter9;
      }
      else
      {
        oracleParameter11 = new OracleParameter(":DataSource", OracleDbType.Int32);
        oracleParameter11.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index10] = oracleParameter11;
      int index11 = 10;
      OracleParameter oracleParameter12;
      if (model.DataSourceString != null)
      {
        OracleParameter oracleParameter9 = new OracleParameter(":DataSourceString", OracleDbType.Varchar2);
        oracleParameter9.Value = (object) model.DataSourceString;
        oracleParameter12 = oracleParameter9;
      }
      else
      {
        oracleParameter12 = new OracleParameter(":DataSourceString", OracleDbType.Varchar2);
        oracleParameter12.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index11] = oracleParameter12;
      int index12 = 11;
      OracleParameter oracleParameter13;
      if (model.DataLinkID != null)
      {
        OracleParameter oracleParameter9 = new OracleParameter(":DataLinkID", OracleDbType.Varchar2);
        oracleParameter9.Value = (object) model.DataLinkID;
        oracleParameter13 = oracleParameter9;
      }
      else
      {
        oracleParameter13 = new OracleParameter(":DataLinkID", OracleDbType.Varchar2);
        oracleParameter13.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index12] = oracleParameter13;
      int index13 = 12;
      nullable = model.IsQueryUsers;
      OracleParameter oracleParameter14;
      if (nullable.HasValue)
      {
        OracleParameter oracleParameter9 = new OracleParameter(":IsQueryUsers", OracleDbType.Int32);
        oracleParameter9.Value = (object) model.IsQueryUsers;
        oracleParameter14 = oracleParameter9;
      }
      else
      {
        oracleParameter14 = new OracleParameter(":IsQueryUsers", OracleDbType.Int32);
        oracleParameter14.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index13] = oracleParameter14;
      int index14 = 13;
      OracleParameter oracleParameter15;
      if (model.Value != null)
      {
        OracleParameter oracleParameter9 = new OracleParameter(":Value", OracleDbType.Varchar2);
        oracleParameter9.Value = (object) model.Value;
        oracleParameter15 = oracleParameter9;
      }
      else
      {
        oracleParameter15 = new OracleParameter(":Value", OracleDbType.Varchar2);
        oracleParameter15.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index14] = oracleParameter15;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Update(RoadFlow.Data.Model.ProgramBuilderQuerys model)
    {
      string sql = "UPDATE ProgramBuilderQuerys SET \r\n\t\t\t\tProgramID=:ProgramID,Field=:Field,ShowTitle=:ShowTitle,Operators=:Operators,ControlName=:ControlName,InputType=:InputType,Width=:Width,Sort=:Sort,DataSource=:DataSource,DataSourceString=:DataSourceString,DataLinkID=:DataLinkID,IsQueryUsers=:IsQueryUsers,Value=:Value\r\n\t\t\t\tWHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[14];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":ProgramID", OracleDbType.Varchar2);
      oracleParameter1.Value = (object) model.ProgramID;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":Field", OracleDbType.Varchar2);
      oracleParameter2.Value = (object) model.Field;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3 = new OracleParameter(":ShowTitle", OracleDbType.Varchar2);
      oracleParameter3.Value = (object) model.ShowTitle;
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter4 = new OracleParameter(":Operators", OracleDbType.Varchar2);
      oracleParameter4.Value = (object) model.Operators;
      oracleParameterArray[index4] = oracleParameter4;
      int index5 = 4;
      OracleParameter oracleParameter5 = new OracleParameter(":ControlName", OracleDbType.Varchar2);
      oracleParameter5.Value = (object) model.ControlName;
      oracleParameterArray[index5] = oracleParameter5;
      int index6 = 5;
      OracleParameter oracleParameter6 = new OracleParameter(":InputType", OracleDbType.Int32);
      oracleParameter6.Value = (object) model.InputType;
      oracleParameterArray[index6] = oracleParameter6;
      int index7 = 6;
      OracleParameter oracleParameter7;
      if (model.Width != null)
      {
        OracleParameter oracleParameter8 = new OracleParameter(":Width", OracleDbType.Varchar2);
        oracleParameter8.Value = (object) model.Width;
        oracleParameter7 = oracleParameter8;
      }
      else
      {
        oracleParameter7 = new OracleParameter(":Width", OracleDbType.Varchar2);
        oracleParameter7.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index7] = oracleParameter7;
      int index8 = 7;
      OracleParameter oracleParameter9 = new OracleParameter(":Sort", OracleDbType.Int32, -1);
      oracleParameter9.Value = (object) model.Sort;
      oracleParameterArray[index8] = oracleParameter9;
      int index9 = 8;
      OracleParameter oracleParameter10;
      if (model.DataSource.HasValue)
      {
        OracleParameter oracleParameter8 = new OracleParameter(":DataSource", OracleDbType.Int32);
        oracleParameter8.Value = (object) model.DataSource;
        oracleParameter10 = oracleParameter8;
      }
      else
      {
        oracleParameter10 = new OracleParameter(":DataSource", OracleDbType.Int32);
        oracleParameter10.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index9] = oracleParameter10;
      int index10 = 9;
      OracleParameter oracleParameter11;
      if (model.DataSourceString != null)
      {
        OracleParameter oracleParameter8 = new OracleParameter(":DataSourceString", OracleDbType.Varchar2);
        oracleParameter8.Value = (object) model.DataSourceString;
        oracleParameter11 = oracleParameter8;
      }
      else
      {
        oracleParameter11 = new OracleParameter(":DataSourceString", OracleDbType.Varchar2);
        oracleParameter11.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index10] = oracleParameter11;
      int index11 = 10;
      OracleParameter oracleParameter12;
      if (model.DataLinkID != null)
      {
        OracleParameter oracleParameter8 = new OracleParameter(":DataLinkID", OracleDbType.Varchar2);
        oracleParameter8.Value = (object) model.DataLinkID;
        oracleParameter12 = oracleParameter8;
      }
      else
      {
        oracleParameter12 = new OracleParameter(":DataLinkID", OracleDbType.Varchar2);
        oracleParameter12.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index11] = oracleParameter12;
      int index12 = 11;
      OracleParameter oracleParameter13;
      if (model.IsQueryUsers.HasValue)
      {
        OracleParameter oracleParameter8 = new OracleParameter(":IsQueryUsers", OracleDbType.Int32);
        oracleParameter8.Value = (object) model.IsQueryUsers;
        oracleParameter13 = oracleParameter8;
      }
      else
      {
        oracleParameter13 = new OracleParameter(":IsQueryUsers", OracleDbType.Int32);
        oracleParameter13.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index12] = oracleParameter13;
      int index13 = 12;
      OracleParameter oracleParameter14;
      if (model.Value != null)
      {
        OracleParameter oracleParameter8 = new OracleParameter(":Value", OracleDbType.Varchar2);
        oracleParameter8.Value = (object) model.Value;
        oracleParameter14 = oracleParameter8;
      }
      else
      {
        oracleParameter14 = new OracleParameter(":Value", OracleDbType.Varchar2);
        oracleParameter14.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index13] = oracleParameter14;
      int index14 = 13;
      OracleParameter oracleParameter15 = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter15.Value = (object) model.ID;
      oracleParameterArray[index14] = oracleParameter15;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM ProgramBuilderQuerys WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    private List<RoadFlow.Data.Model.ProgramBuilderQuerys> DataReaderToList(OracleDataReader dataReader)
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
      OracleDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM ProgramBuilderQuerys");
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
      string sql = "SELECT * FROM ProgramBuilderQuerys WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.ProgramBuilderQuerys> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.ProgramBuilderQuerys) null;
      return list[0];
    }

    public List<RoadFlow.Data.Model.ProgramBuilderQuerys> GetAll(Guid programID)
    {
      string sql = "SELECT * FROM ProgramBuilderQuerys WHERE ProgramID=:ProgramID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ProgramID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) programID;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.ProgramBuilderQuerys> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public int DeleteByProgramID(Guid id)
    {
      string sql = "DELETE FROM ProgramBuilderQuerys WHERE ProgramID=:ProgramID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ProgramID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }
  }
}
