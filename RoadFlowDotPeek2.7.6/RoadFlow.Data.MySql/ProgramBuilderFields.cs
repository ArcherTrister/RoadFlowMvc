// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MySql.ProgramBuilderFields
// Assembly: RoadFlow.Data.MySql, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 29B652D7-5F6F-4A7D-AD1C-9F2C643FD784
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.MySql.dll

using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.MySql
{
  public class ProgramBuilderFields : IProgramBuilderFields
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.ProgramBuilderFields model)
    {
      string sql = "INSERT INTO programbuilderfields\r\n\t\t\t\t(ID,ProgramID,Field,ShowTitle,Align,Width,ShowType,ShowFormat,CustomString,Sort) \r\n\t\t\t\tVALUES(@ID,@ProgramID,@Field,@ShowTitle,@Align,@Width,@ShowType,@ShowFormat,@CustomString,@Sort)";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[10];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter1.Value = (object) model.ID;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@ProgramID", MySqlDbType.VarChar, 36);
      mySqlParameter2.Value = (object) model.ProgramID;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3;
      if (model.Field != null)
      {
        MySqlParameter mySqlParameter4 = new MySqlParameter("@Field", MySqlDbType.Text, -1);
        mySqlParameter4.Value = (object) model.Field;
        mySqlParameter3 = mySqlParameter4;
      }
      else
      {
        mySqlParameter3 = new MySqlParameter("@Field", MySqlDbType.Text, -1);
        mySqlParameter3.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter5 = new MySqlParameter("@ShowTitle", MySqlDbType.LongText, -1);
      mySqlParameter5.Value = (object) model.ShowTitle;
      mySqlParameterArray[index4] = mySqlParameter5;
      int index5 = 4;
      MySqlParameter mySqlParameter6 = new MySqlParameter("@Align", MySqlDbType.VarChar, 50);
      mySqlParameter6.Value = (object) model.Align;
      mySqlParameterArray[index5] = mySqlParameter6;
      int index6 = 5;
      MySqlParameter mySqlParameter7;
      if (model.Width != null)
      {
        MySqlParameter mySqlParameter4 = new MySqlParameter("@Width", MySqlDbType.VarChar, 50);
        mySqlParameter4.Value = (object) model.Width;
        mySqlParameter7 = mySqlParameter4;
      }
      else
      {
        mySqlParameter7 = new MySqlParameter("@Width", MySqlDbType.VarChar, 50);
        mySqlParameter7.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index6] = mySqlParameter7;
      int index7 = 6;
      MySqlParameter mySqlParameter8 = new MySqlParameter("@ShowType", MySqlDbType.Int32, 11);
      mySqlParameter8.Value = (object) model.ShowType;
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
        MySqlParameter mySqlParameter4 = new MySqlParameter("@CustomString", MySqlDbType.LongText, -1);
        mySqlParameter4.Value = (object) model.CustomString;
        mySqlParameter10 = mySqlParameter4;
      }
      else
      {
        mySqlParameter10 = new MySqlParameter("@CustomString", MySqlDbType.LongText, -1);
        mySqlParameter10.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index9] = mySqlParameter10;
      int index10 = 9;
      MySqlParameter mySqlParameter11 = new MySqlParameter("@Sort", MySqlDbType.Int32, 11);
      mySqlParameter11.Value = (object) model.Sort;
      mySqlParameterArray[index10] = mySqlParameter11;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.ProgramBuilderFields model)
    {
      string sql = "UPDATE programbuilderfields SET \r\n\t\t\t\tProgramID=@ProgramID,Field=@Field,ShowTitle=@ShowTitle,Align=@Align,Width=@Width,ShowType=@ShowType,ShowFormat=@ShowFormat,CustomString=@CustomString,Sort=@Sort\r\n\t\t\t\tWHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[10];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@ProgramID", MySqlDbType.VarChar, 36);
      mySqlParameter1.Value = (object) model.ProgramID;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2;
      if (model.Field != null)
      {
        MySqlParameter mySqlParameter3 = new MySqlParameter("@Field", MySqlDbType.Text, -1);
        mySqlParameter3.Value = (object) model.Field;
        mySqlParameter2 = mySqlParameter3;
      }
      else
      {
        mySqlParameter2 = new MySqlParameter("@Field", MySqlDbType.Text, -1);
        mySqlParameter2.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter4 = new MySqlParameter("@ShowTitle", MySqlDbType.LongText, -1);
      mySqlParameter4.Value = (object) model.ShowTitle;
      mySqlParameterArray[index3] = mySqlParameter4;
      int index4 = 3;
      MySqlParameter mySqlParameter5 = new MySqlParameter("@Align", MySqlDbType.VarChar, 50);
      mySqlParameter5.Value = (object) model.Align;
      mySqlParameterArray[index4] = mySqlParameter5;
      int index5 = 4;
      MySqlParameter mySqlParameter6;
      if (model.Width != null)
      {
        MySqlParameter mySqlParameter3 = new MySqlParameter("@Width", MySqlDbType.VarChar, 50);
        mySqlParameter3.Value = (object) model.Width;
        mySqlParameter6 = mySqlParameter3;
      }
      else
      {
        mySqlParameter6 = new MySqlParameter("@Width", MySqlDbType.VarChar, 50);
        mySqlParameter6.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index5] = mySqlParameter6;
      int index6 = 5;
      MySqlParameter mySqlParameter7 = new MySqlParameter("@ShowType", MySqlDbType.Int32, 11);
      mySqlParameter7.Value = (object) model.ShowType;
      mySqlParameterArray[index6] = mySqlParameter7;
      int index7 = 6;
      MySqlParameter mySqlParameter8;
      if (model.ShowFormat != null)
      {
        MySqlParameter mySqlParameter3 = new MySqlParameter("@ShowFormat", MySqlDbType.VarChar, 50);
        mySqlParameter3.Value = (object) model.ShowFormat;
        mySqlParameter8 = mySqlParameter3;
      }
      else
      {
        mySqlParameter8 = new MySqlParameter("@ShowFormat", MySqlDbType.VarChar, 50);
        mySqlParameter8.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index7] = mySqlParameter8;
      int index8 = 7;
      MySqlParameter mySqlParameter9;
      if (model.CustomString != null)
      {
        MySqlParameter mySqlParameter3 = new MySqlParameter("@CustomString", MySqlDbType.LongText, -1);
        mySqlParameter3.Value = (object) model.CustomString;
        mySqlParameter9 = mySqlParameter3;
      }
      else
      {
        mySqlParameter9 = new MySqlParameter("@CustomString", MySqlDbType.LongText, -1);
        mySqlParameter9.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index8] = mySqlParameter9;
      int index9 = 8;
      MySqlParameter mySqlParameter10 = new MySqlParameter("@Sort", MySqlDbType.Int32, 11);
      mySqlParameter10.Value = (object) model.Sort;
      mySqlParameterArray[index9] = mySqlParameter10;
      int index10 = 9;
      MySqlParameter mySqlParameter11 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter11.Value = (object) model.ID;
      mySqlParameterArray[index10] = mySqlParameter11;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM programbuilderfields WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.ProgramBuilderFields> DataReaderToList(MySqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.ProgramBuilderFields> programBuilderFieldsList = new List<RoadFlow.Data.Model.ProgramBuilderFields>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.ProgramBuilderFields programBuilderFields = new RoadFlow.Data.Model.ProgramBuilderFields();
        programBuilderFields.ID = dataReader.GetString(0).ToGuid();
        programBuilderFields.ProgramID = dataReader.GetString(1).ToGuid();
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
      MySqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM programbuilderfields");
      List<RoadFlow.Data.Model.ProgramBuilderFields> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM programbuilderfields"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.ProgramBuilderFields Get(Guid id)
    {
      string sql = "SELECT * FROM programbuilderfields WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.ProgramBuilderFields> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.ProgramBuilderFields) null;
      return list[0];
    }

    public List<RoadFlow.Data.Model.ProgramBuilderFields> GetAll(Guid programID)
    {
      string sql = "SELECT * FROM ProgramBuilderFields WHERE ProgramID=@ProgramID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ProgramID", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) programID.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.ProgramBuilderFields> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public int DeleteByProgramID(Guid id)
    {
      string sql = "DELETE FROM ProgramBuilderFields WHERE ProgramID=@ProgramID";
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
