// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MySql.ProgramBuilderExport
// Assembly: RoadFlow.Data.MySql, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 29B652D7-5F6F-4A7D-AD1C-9F2C643FD784
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.MySql.dll

using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.MySql
{
  public class ProgramBuilderExport : IProgramBuilderExport
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.ProgramBuilderExport model)
    {
      string sql = "INSERT INTO programbuilderexport\r\n\t\t\t\t(ID,ProgramID,Field,ShowTitle,Align,Width,ShowType,DataType,ShowFormat,CustomString,Sort) \r\n\t\t\t\tVALUES(@ID,@ProgramID,@Field,@ShowTitle,@Align,@Width,@ShowType,@DataType,@ShowFormat,@CustomString,@Sort)";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[11];
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
      MySqlParameter mySqlParameter4;
      if (model.ShowTitle != null)
      {
        MySqlParameter mySqlParameter5 = new MySqlParameter("@ShowTitle", MySqlDbType.Text, -1);
        mySqlParameter5.Value = (object) model.ShowTitle;
        mySqlParameter4 = mySqlParameter5;
      }
      else
      {
        mySqlParameter4 = new MySqlParameter("@ShowTitle", MySqlDbType.Text, -1);
        mySqlParameter4.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index4] = mySqlParameter4;
      int index5 = 4;
      MySqlParameter mySqlParameter6 = new MySqlParameter("@Align", MySqlDbType.Int32, 11);
      mySqlParameter6.Value = (object) model.Align;
      mySqlParameterArray[index5] = mySqlParameter6;
      int index6 = 5;
      int? nullable = model.Width;
      MySqlParameter mySqlParameter7;
      if (nullable.HasValue)
      {
        MySqlParameter mySqlParameter5 = new MySqlParameter("@Width", MySqlDbType.Int32, 11);
        mySqlParameter5.Value = (object) model.Width;
        mySqlParameter7 = mySqlParameter5;
      }
      else
      {
        mySqlParameter7 = new MySqlParameter("@Width", MySqlDbType.Int32, 11);
        mySqlParameter7.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index6] = mySqlParameter7;
      int index7 = 6;
      nullable = model.ShowType;
      MySqlParameter mySqlParameter8;
      if (nullable.HasValue)
      {
        MySqlParameter mySqlParameter5 = new MySqlParameter("@ShowType", MySqlDbType.Int32, 11);
        mySqlParameter5.Value = (object) model.ShowType;
        mySqlParameter8 = mySqlParameter5;
      }
      else
      {
        mySqlParameter8 = new MySqlParameter("@ShowType", MySqlDbType.Int32, 11);
        mySqlParameter8.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index7] = mySqlParameter8;
      int index8 = 7;
      nullable = model.DataType;
      MySqlParameter mySqlParameter9;
      if (nullable.HasValue)
      {
        MySqlParameter mySqlParameter5 = new MySqlParameter("@DataType", MySqlDbType.Int32, 11);
        mySqlParameter5.Value = (object) model.DataType;
        mySqlParameter9 = mySqlParameter5;
      }
      else
      {
        mySqlParameter9 = new MySqlParameter("@DataType", MySqlDbType.Int32, 11);
        mySqlParameter9.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index8] = mySqlParameter9;
      int index9 = 8;
      MySqlParameter mySqlParameter10;
      if (model.ShowFormat != null)
      {
        MySqlParameter mySqlParameter5 = new MySqlParameter("@ShowFormat", MySqlDbType.VarChar, 50);
        mySqlParameter5.Value = (object) model.ShowFormat;
        mySqlParameter10 = mySqlParameter5;
      }
      else
      {
        mySqlParameter10 = new MySqlParameter("@ShowFormat", MySqlDbType.VarChar, 50);
        mySqlParameter10.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index9] = mySqlParameter10;
      int index10 = 9;
      MySqlParameter mySqlParameter11;
      if (model.CustomString != null)
      {
        MySqlParameter mySqlParameter5 = new MySqlParameter("@CustomString", MySqlDbType.Text, -1);
        mySqlParameter5.Value = (object) model.CustomString;
        mySqlParameter11 = mySqlParameter5;
      }
      else
      {
        mySqlParameter11 = new MySqlParameter("@CustomString", MySqlDbType.Text, -1);
        mySqlParameter11.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index10] = mySqlParameter11;
      int index11 = 10;
      MySqlParameter mySqlParameter12 = new MySqlParameter("@Sort", MySqlDbType.Int32, 11);
      mySqlParameter12.Value = (object) model.Sort;
      mySqlParameterArray[index11] = mySqlParameter12;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.ProgramBuilderExport model)
    {
      string sql = "UPDATE programbuilderexport SET \r\n\t\t\t\tProgramID=@ProgramID,Field=@Field,ShowTitle=@ShowTitle,Align=@Align,Width=@Width,ShowType=@ShowType,DataType=@DataType,ShowFormat=@ShowFormat,CustomString=@CustomString,Sort=@Sort\r\n\t\t\t\tWHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[11];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@ProgramID", MySqlDbType.VarChar, 36);
      mySqlParameter1.Value = (object) model.ProgramID;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@Field", MySqlDbType.Text, -1);
      mySqlParameter2.Value = (object) model.Field;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3;
      if (model.ShowTitle != null)
      {
        MySqlParameter mySqlParameter4 = new MySqlParameter("@ShowTitle", MySqlDbType.Text, -1);
        mySqlParameter4.Value = (object) model.ShowTitle;
        mySqlParameter3 = mySqlParameter4;
      }
      else
      {
        mySqlParameter3 = new MySqlParameter("@ShowTitle", MySqlDbType.Text, -1);
        mySqlParameter3.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter5 = new MySqlParameter("@Align", MySqlDbType.Int32, 11);
      mySqlParameter5.Value = (object) model.Align;
      mySqlParameterArray[index4] = mySqlParameter5;
      int index5 = 4;
      int? nullable = model.Width;
      MySqlParameter mySqlParameter6;
      if (nullable.HasValue)
      {
        MySqlParameter mySqlParameter4 = new MySqlParameter("@Width", MySqlDbType.Int32, 11);
        mySqlParameter4.Value = (object) model.Width;
        mySqlParameter6 = mySqlParameter4;
      }
      else
      {
        mySqlParameter6 = new MySqlParameter("@Width", MySqlDbType.Int32, 11);
        mySqlParameter6.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index5] = mySqlParameter6;
      int index6 = 5;
      nullable = model.ShowType;
      MySqlParameter mySqlParameter7;
      if (nullable.HasValue)
      {
        MySqlParameter mySqlParameter4 = new MySqlParameter("@ShowType", MySqlDbType.Int32, 11);
        mySqlParameter4.Value = (object) model.ShowType;
        mySqlParameter7 = mySqlParameter4;
      }
      else
      {
        mySqlParameter7 = new MySqlParameter("@ShowType", MySqlDbType.Int32, 11);
        mySqlParameter7.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index6] = mySqlParameter7;
      int index7 = 6;
      nullable = model.DataType;
      MySqlParameter mySqlParameter8;
      if (nullable.HasValue)
      {
        MySqlParameter mySqlParameter4 = new MySqlParameter("@DataType", MySqlDbType.Int32, 11);
        mySqlParameter4.Value = (object) model.DataType;
        mySqlParameter8 = mySqlParameter4;
      }
      else
      {
        mySqlParameter8 = new MySqlParameter("@DataType", MySqlDbType.Int32, 11);
        mySqlParameter8.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index7] = mySqlParameter8;
      int index8 = 7;
      MySqlParameter mySqlParameter9;
      if (model.ShowFormat != null)
      {
        MySqlParameter mySqlParameter4 = new MySqlParameter("@ShowFormat", MySqlDbType.VarChar, 50);
        mySqlParameter4.Value = (object) model.ShowFormat;
        mySqlParameter9 = mySqlParameter4;
      }
      else
      {
        mySqlParameter9 = new MySqlParameter("@ShowFormat", MySqlDbType.VarChar, 50);
        mySqlParameter9.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index8] = mySqlParameter9;
      int index9 = 8;
      MySqlParameter mySqlParameter10;
      if (model.CustomString != null)
      {
        MySqlParameter mySqlParameter4 = new MySqlParameter("@CustomString", MySqlDbType.Text, -1);
        mySqlParameter4.Value = (object) model.CustomString;
        mySqlParameter10 = mySqlParameter4;
      }
      else
      {
        mySqlParameter10 = new MySqlParameter("@CustomString", MySqlDbType.Text, -1);
        mySqlParameter10.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index9] = mySqlParameter10;
      int index10 = 9;
      MySqlParameter mySqlParameter11 = new MySqlParameter("@Sort", MySqlDbType.Int32, 11);
      mySqlParameter11.Value = (object) model.Sort;
      mySqlParameterArray[index10] = mySqlParameter11;
      int index11 = 10;
      MySqlParameter mySqlParameter12 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter12.Value = (object) model.ID;
      mySqlParameterArray[index11] = mySqlParameter12;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM programbuilderexport WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.ProgramBuilderExport> DataReaderToList(MySqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.ProgramBuilderExport> programBuilderExportList = new List<RoadFlow.Data.Model.ProgramBuilderExport>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.ProgramBuilderExport programBuilderExport = new RoadFlow.Data.Model.ProgramBuilderExport();
        programBuilderExport.ID = dataReader.GetString(0).ToGuid();
        programBuilderExport.ProgramID = dataReader.GetString(1).ToGuid();
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
      MySqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM programbuilderexport");
      List<RoadFlow.Data.Model.ProgramBuilderExport> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM programbuilderexport"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.ProgramBuilderExport Get(Guid id)
    {
      string sql = "SELECT * FROM programbuilderexport WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.ProgramBuilderExport> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.ProgramBuilderExport) null;
      return list[0];
    }

    public List<RoadFlow.Data.Model.ProgramBuilderExport> GetAll(Guid programID)
    {
      string sql = "SELECT * FROM ProgramBuilderExport WHERE ProgramID=@ProgramID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ProgramID", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) programID.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.ProgramBuilderExport> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }
  }
}
