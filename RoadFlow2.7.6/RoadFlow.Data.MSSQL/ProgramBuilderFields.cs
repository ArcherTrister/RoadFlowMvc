// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MSSQL.ProgramBuilderFields
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
  public class ProgramBuilderFields : IProgramBuilderFields
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.ProgramBuilderFields model)
    {
      string sql = "INSERT INTO ProgramBuilderFields\r\n\t\t\t\t(ID,ProgramID,Field,ShowTitle,Align,Width,ShowType,ShowFormat,CustomString,Sort) \r\n\t\t\t\tVALUES(@ID,@ProgramID,@Field,@ShowTitle,@Align,@Width,@ShowType,@ShowFormat,@CustomString,@Sort)";
      SqlParameter[] sqlParameterArray = new SqlParameter[10];
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
      SqlParameter sqlParameter4 = new SqlParameter("@ShowTitle", SqlDbType.VarChar, -1);
      sqlParameter4.Value = (object) model.ShowTitle;
      sqlParameterArray[index4] = sqlParameter4;
      int index5 = 4;
      SqlParameter sqlParameter5 = new SqlParameter("@Align", SqlDbType.VarChar, 50);
      sqlParameter5.Value = (object) model.Align;
      sqlParameterArray[index5] = sqlParameter5;
      int index6 = 5;
      SqlParameter sqlParameter6;
      if (model.Width != null)
      {
        SqlParameter sqlParameter7 = new SqlParameter("@Width", SqlDbType.VarChar, 50);
        sqlParameter7.Value = (object) model.Width;
        sqlParameter6 = sqlParameter7;
      }
      else
      {
        sqlParameter6 = new SqlParameter("@Width", SqlDbType.VarChar, 50);
        sqlParameter6.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index6] = sqlParameter6;
      int index7 = 6;
      SqlParameter sqlParameter8 = new SqlParameter("@ShowType", SqlDbType.Int, -1);
      sqlParameter8.Value = (object) model.ShowType;
      sqlParameterArray[index7] = sqlParameter8;
      int index8 = 7;
      SqlParameter sqlParameter9;
      if (model.ShowFormat != null)
      {
        SqlParameter sqlParameter7 = new SqlParameter("@ShowFormat", SqlDbType.VarChar, 50);
        sqlParameter7.Value = (object) model.ShowFormat;
        sqlParameter9 = sqlParameter7;
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
        SqlParameter sqlParameter7 = new SqlParameter("@CustomString", SqlDbType.VarChar, -1);
        sqlParameter7.Value = (object) model.CustomString;
        sqlParameter10 = sqlParameter7;
      }
      else
      {
        sqlParameter10 = new SqlParameter("@CustomString", SqlDbType.VarChar, -1);
        sqlParameter10.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index9] = sqlParameter10;
      int index10 = 9;
      SqlParameter sqlParameter11 = new SqlParameter("@Sort", SqlDbType.Int, -1);
      sqlParameter11.Value = (object) model.Sort;
      sqlParameterArray[index10] = sqlParameter11;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.ProgramBuilderFields model)
    {
      string sql = "UPDATE ProgramBuilderFields SET \r\n\t\t\t\tProgramID=@ProgramID,Field=@Field,ShowTitle=@ShowTitle,Align=@Align,Width=@Width,ShowType=@ShowType,ShowFormat=@ShowFormat,CustomString=@CustomString,Sort=@Sort\r\n\t\t\t\tWHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[10];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@ProgramID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter1.Value = (object) model.ProgramID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@Field", SqlDbType.VarChar, 500);
      sqlParameter2.Value = (object) model.Field;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@ShowTitle", SqlDbType.VarChar, -1);
      sqlParameter3.Value = (object) model.ShowTitle;
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter4 = new SqlParameter("@Align", SqlDbType.VarChar, 50);
      sqlParameter4.Value = (object) model.Align;
      sqlParameterArray[index4] = sqlParameter4;
      int index5 = 4;
      SqlParameter sqlParameter5;
      if (model.Width != null)
      {
        SqlParameter sqlParameter6 = new SqlParameter("@Width", SqlDbType.VarChar, 50);
        sqlParameter6.Value = (object) model.Width;
        sqlParameter5 = sqlParameter6;
      }
      else
      {
        sqlParameter5 = new SqlParameter("@Width", SqlDbType.VarChar, 50);
        sqlParameter5.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index5] = sqlParameter5;
      int index6 = 5;
      SqlParameter sqlParameter7 = new SqlParameter("@ShowType", SqlDbType.Int, -1);
      sqlParameter7.Value = (object) model.ShowType;
      sqlParameterArray[index6] = sqlParameter7;
      int index7 = 6;
      SqlParameter sqlParameter8;
      if (model.ShowFormat != null)
      {
        SqlParameter sqlParameter6 = new SqlParameter("@ShowFormat", SqlDbType.VarChar, 50);
        sqlParameter6.Value = (object) model.ShowFormat;
        sqlParameter8 = sqlParameter6;
      }
      else
      {
        sqlParameter8 = new SqlParameter("@ShowFormat", SqlDbType.VarChar, 50);
        sqlParameter8.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index7] = sqlParameter8;
      int index8 = 7;
      SqlParameter sqlParameter9;
      if (model.CustomString != null)
      {
        SqlParameter sqlParameter6 = new SqlParameter("@CustomString", SqlDbType.VarChar, -1);
        sqlParameter6.Value = (object) model.CustomString;
        sqlParameter9 = sqlParameter6;
      }
      else
      {
        sqlParameter9 = new SqlParameter("@CustomString", SqlDbType.VarChar, -1);
        sqlParameter9.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index8] = sqlParameter9;
      int index9 = 8;
      SqlParameter sqlParameter10 = new SqlParameter("@Sort", SqlDbType.Int, -1);
      sqlParameter10.Value = (object) model.Sort;
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
      string sql = "DELETE FROM ProgramBuilderFields WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.ProgramBuilderFields> DataReaderToList(SqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.ProgramBuilderFields> programBuilderFieldsList = new List<RoadFlow.Data.Model.ProgramBuilderFields>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.ProgramBuilderFields programBuilderFields = new RoadFlow.Data.Model.ProgramBuilderFields();
        programBuilderFields.ID = dataReader.GetGuid(0);
        programBuilderFields.ProgramID = dataReader.GetGuid(1);
        if (!dataReader.IsDBNull(2))
          programBuilderFields.Field = dataReader.GetString(2);
        programBuilderFields.ShowTitle = dataReader.GetString(3);
        programBuilderFields.Align = dataReader.GetString(4);
        if (!dataReader.IsDBNull(5))
          programBuilderFields.Width = dataReader.GetString(5);
        programBuilderFields.ShowType = dataReader.GetInt32(6);
        if (!dataReader.IsDBNull(7))
          programBuilderFields.ShowFormat = dataReader.GetString(7);
        if (!dataReader.IsDBNull(8))
          programBuilderFields.CustomString = dataReader.GetString(8);
        programBuilderFields.Sort = dataReader.GetInt32(9);
        programBuilderFieldsList.Add(programBuilderFields);
      }
      return programBuilderFieldsList;
    }

    public List<RoadFlow.Data.Model.ProgramBuilderFields> GetAll()
    {
      SqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM ProgramBuilderFields");
      List<RoadFlow.Data.Model.ProgramBuilderFields> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM ProgramBuilderFields"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.ProgramBuilderFields Get(Guid id)
    {
      string sql = "SELECT * FROM ProgramBuilderFields WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.ProgramBuilderFields> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.ProgramBuilderFields) null;
      return list[0];
    }

    public List<RoadFlow.Data.Model.ProgramBuilderFields> GetAll(Guid programID)
    {
      string sql = "SELECT * FROM ProgramBuilderFields WHERE ProgramID=@ProgramID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ProgramID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) programID;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.ProgramBuilderFields> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public int DeleteByProgramID(Guid id)
    {
      string sql = "DELETE FROM ProgramBuilderFields WHERE ProgramID=@ProgramID";
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
