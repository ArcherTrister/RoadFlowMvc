// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MSSQL.ProgramBuilderExport
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
  public class ProgramBuilderExport : IProgramBuilderExport
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.ProgramBuilderExport model)
    {
      string sql = "INSERT INTO ProgramBuilderExport\r\n\t\t\t\t(ID,ProgramID,Field,ShowTitle,Align,Width,ShowType,DataType,ShowFormat,CustomString,Sort) \r\n\t\t\t\tVALUES(@ID,@ProgramID,@Field,@ShowTitle,@Align,@Width,@ShowType,@DataType,@ShowFormat,@CustomString,@Sort)";
      SqlParameter[] sqlParameterArray = new SqlParameter[11];
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
      SqlParameter sqlParameter4;
      if (model.ShowTitle != null)
      {
        SqlParameter sqlParameter5 = new SqlParameter("@ShowTitle", SqlDbType.NVarChar, 1000);
        sqlParameter5.Value = (object) model.ShowTitle;
        sqlParameter4 = sqlParameter5;
      }
      else
      {
        sqlParameter4 = new SqlParameter("@ShowTitle", SqlDbType.NVarChar, 1000);
        sqlParameter4.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index4] = sqlParameter4;
      int index5 = 4;
      SqlParameter sqlParameter6 = new SqlParameter("@Align", SqlDbType.Int, -1);
      sqlParameter6.Value = (object) model.Align;
      sqlParameterArray[index5] = sqlParameter6;
      int index6 = 5;
      int? nullable = model.Width;
      SqlParameter sqlParameter7;
      if (nullable.HasValue)
      {
        SqlParameter sqlParameter5 = new SqlParameter("@Width", SqlDbType.Int, -1);
        sqlParameter5.Value = (object) model.Width;
        sqlParameter7 = sqlParameter5;
      }
      else
      {
        sqlParameter7 = new SqlParameter("@Width", SqlDbType.Int, -1);
        sqlParameter7.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index6] = sqlParameter7;
      int index7 = 6;
      nullable = model.ShowType;
      SqlParameter sqlParameter8;
      if (nullable.HasValue)
      {
        SqlParameter sqlParameter5 = new SqlParameter("@ShowType", SqlDbType.Int, -1);
        sqlParameter5.Value = (object) model.ShowType;
        sqlParameter8 = sqlParameter5;
      }
      else
      {
        sqlParameter8 = new SqlParameter("@ShowType", SqlDbType.Int, -1);
        sqlParameter8.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index7] = sqlParameter8;
      int index8 = 7;
      nullable = model.DataType;
      SqlParameter sqlParameter9;
      if (nullable.HasValue)
      {
        SqlParameter sqlParameter5 = new SqlParameter("@DataType", SqlDbType.Int, -1);
        sqlParameter5.Value = (object) model.DataType;
        sqlParameter9 = sqlParameter5;
      }
      else
      {
        sqlParameter9 = new SqlParameter("@DataType", SqlDbType.Int, -1);
        sqlParameter9.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index8] = sqlParameter9;
      int index9 = 8;
      SqlParameter sqlParameter10;
      if (model.ShowFormat != null)
      {
        SqlParameter sqlParameter5 = new SqlParameter("@ShowFormat", SqlDbType.VarChar, 50);
        sqlParameter5.Value = (object) model.ShowFormat;
        sqlParameter10 = sqlParameter5;
      }
      else
      {
        sqlParameter10 = new SqlParameter("@ShowFormat", SqlDbType.VarChar, 50);
        sqlParameter10.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index9] = sqlParameter10;
      int index10 = 9;
      SqlParameter sqlParameter11;
      if (model.CustomString != null)
      {
        SqlParameter sqlParameter5 = new SqlParameter("@CustomString", SqlDbType.VarChar, 5000);
        sqlParameter5.Value = (object) model.CustomString;
        sqlParameter11 = sqlParameter5;
      }
      else
      {
        sqlParameter11 = new SqlParameter("@CustomString", SqlDbType.VarChar, 5000);
        sqlParameter11.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index10] = sqlParameter11;
      int index11 = 10;
      SqlParameter sqlParameter12 = new SqlParameter("@Sort", SqlDbType.Int, -1);
      sqlParameter12.Value = (object) model.Sort;
      sqlParameterArray[index11] = sqlParameter12;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.ProgramBuilderExport model)
    {
      string sql = "UPDATE ProgramBuilderExport SET \r\n\t\t\t\tProgramID=@ProgramID,Field=@Field,ShowTitle=@ShowTitle,Align=@Align,Width=@Width,ShowType=@ShowType,DataType=@DataType,ShowFormat=@ShowFormat,CustomString=@CustomString,Sort=@Sort\r\n\t\t\t\tWHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[11];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@ProgramID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter1.Value = (object) model.ProgramID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@Field", SqlDbType.VarChar, 500);
      sqlParameter2.Value = (object) model.Field;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3;
      if (model.ShowTitle != null)
      {
        SqlParameter sqlParameter4 = new SqlParameter("@ShowTitle", SqlDbType.NVarChar, 1000);
        sqlParameter4.Value = (object) model.ShowTitle;
        sqlParameter3 = sqlParameter4;
      }
      else
      {
        sqlParameter3 = new SqlParameter("@ShowTitle", SqlDbType.NVarChar, 1000);
        sqlParameter3.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter5 = new SqlParameter("@Align", SqlDbType.Int, -1);
      sqlParameter5.Value = (object) model.Align;
      sqlParameterArray[index4] = sqlParameter5;
      int index5 = 4;
      int? nullable = model.Width;
      SqlParameter sqlParameter6;
      if (nullable.HasValue)
      {
        SqlParameter sqlParameter4 = new SqlParameter("@Width", SqlDbType.Int, -1);
        sqlParameter4.Value = (object) model.Width;
        sqlParameter6 = sqlParameter4;
      }
      else
      {
        sqlParameter6 = new SqlParameter("@Width", SqlDbType.Int, -1);
        sqlParameter6.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index5] = sqlParameter6;
      int index6 = 5;
      nullable = model.ShowType;
      SqlParameter sqlParameter7;
      if (nullable.HasValue)
      {
        SqlParameter sqlParameter4 = new SqlParameter("@ShowType", SqlDbType.Int, -1);
        sqlParameter4.Value = (object) model.ShowType;
        sqlParameter7 = sqlParameter4;
      }
      else
      {
        sqlParameter7 = new SqlParameter("@ShowType", SqlDbType.Int, -1);
        sqlParameter7.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index6] = sqlParameter7;
      int index7 = 6;
      nullable = model.DataType;
      SqlParameter sqlParameter8;
      if (nullable.HasValue)
      {
        SqlParameter sqlParameter4 = new SqlParameter("@DataType", SqlDbType.Int, -1);
        sqlParameter4.Value = (object) model.DataType;
        sqlParameter8 = sqlParameter4;
      }
      else
      {
        sqlParameter8 = new SqlParameter("@DataType", SqlDbType.Int, -1);
        sqlParameter8.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index7] = sqlParameter8;
      int index8 = 7;
      SqlParameter sqlParameter9;
      if (model.ShowFormat != null)
      {
        SqlParameter sqlParameter4 = new SqlParameter("@ShowFormat", SqlDbType.VarChar, 50);
        sqlParameter4.Value = (object) model.ShowFormat;
        sqlParameter9 = sqlParameter4;
      }
      else
      {
        sqlParameter9 = new SqlParameter("@ShowFormat", SqlDbType.VarChar, 50);
        sqlParameter9.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index8] = sqlParameter9;
      int index9 = 8;
      SqlParameter sqlParameter10;
      if (model.CustomString != null)
      {
        SqlParameter sqlParameter4 = new SqlParameter("@CustomString", SqlDbType.VarChar, 5000);
        sqlParameter4.Value = (object) model.CustomString;
        sqlParameter10 = sqlParameter4;
      }
      else
      {
        sqlParameter10 = new SqlParameter("@CustomString", SqlDbType.VarChar, 5000);
        sqlParameter10.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index9] = sqlParameter10;
      int index10 = 9;
      SqlParameter sqlParameter11 = new SqlParameter("@Sort", SqlDbType.Int, -1);
      sqlParameter11.Value = (object) model.Sort;
      sqlParameterArray[index10] = sqlParameter11;
      int index11 = 10;
      SqlParameter sqlParameter12 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter12.Value = (object) model.ID;
      sqlParameterArray[index11] = sqlParameter12;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM ProgramBuilderExport WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.ProgramBuilderExport> DataReaderToList(SqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.ProgramBuilderExport> programBuilderExportList = new List<RoadFlow.Data.Model.ProgramBuilderExport>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.ProgramBuilderExport programBuilderExport = new RoadFlow.Data.Model.ProgramBuilderExport();
        programBuilderExport.ID = dataReader.GetGuid(0);
        programBuilderExport.ProgramID = dataReader.GetGuid(1);
        programBuilderExport.Field = dataReader.GetString(2);
        if (!dataReader.IsDBNull(3))
          programBuilderExport.ShowTitle = dataReader.GetString(3);
        programBuilderExport.Align = dataReader.GetInt32(4);
        if (!dataReader.IsDBNull(5))
          programBuilderExport.Width = new int?(dataReader.GetInt32(5));
        if (!dataReader.IsDBNull(6))
          programBuilderExport.ShowType = new int?(dataReader.GetInt32(6));
        if (!dataReader.IsDBNull(7))
          programBuilderExport.DataType = new int?(dataReader.GetInt32(7));
        if (!dataReader.IsDBNull(8))
          programBuilderExport.ShowFormat = dataReader.GetString(8);
        if (!dataReader.IsDBNull(9))
          programBuilderExport.CustomString = dataReader.GetString(9);
        programBuilderExport.Sort = dataReader.GetInt32(10);
        programBuilderExportList.Add(programBuilderExport);
      }
      return programBuilderExportList;
    }

    public List<RoadFlow.Data.Model.ProgramBuilderExport> GetAll()
    {
      SqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM ProgramBuilderExport");
      List<RoadFlow.Data.Model.ProgramBuilderExport> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM ProgramBuilderExport"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.ProgramBuilderExport Get(Guid id)
    {
      string sql = "SELECT * FROM ProgramBuilderExport WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.ProgramBuilderExport> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.ProgramBuilderExport) null;
      return list[0];
    }

    public List<RoadFlow.Data.Model.ProgramBuilderExport> GetAll(Guid programID)
    {
      string sql = "SELECT * FROM ProgramBuilderExport WHERE ProgramID=@ProgramID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ProgramID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) programID;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.ProgramBuilderExport> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }
  }
}
