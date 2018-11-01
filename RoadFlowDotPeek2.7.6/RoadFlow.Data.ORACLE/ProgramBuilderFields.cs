// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.ORACLE.ProgramBuilderFields
// Assembly: RoadFlow.Data.ORACLE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C9018AA1-E48E-4231-92A9-CD6F0F275D11
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.ORACLE.dll

using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.ORACLE
{
  public class ProgramBuilderFields : IProgramBuilderFields
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.ProgramBuilderFields model)
    {
      string sql = "INSERT INTO ProgramBuilderFields\r\n\t\t\t\t(ID,ProgramID,Field,ShowTitle,Align,Width,ShowType,ShowFormat,CustomString,Sort) \r\n\t\t\t\tVALUES(:ID,:ProgramID,:Field,:ShowTitle,:Align,:Width,:ShowType,:ShowFormat,:CustomString,:Sort)";
      OracleParameter[] oracleParameterArray = new OracleParameter[10];
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
      OracleParameter oracleParameter5 = new OracleParameter(":Align", OracleDbType.Varchar2);
      oracleParameter5.Value = (object) model.Align;
      oracleParameterArray[index5] = oracleParameter5;
      int index6 = 5;
      OracleParameter oracleParameter6;
      if (model.Width != null)
      {
        OracleParameter oracleParameter7 = new OracleParameter(":Width", OracleDbType.Varchar2);
        oracleParameter7.Value = (object) model.Width;
        oracleParameter6 = oracleParameter7;
      }
      else
      {
        oracleParameter6 = new OracleParameter(":Width", OracleDbType.Varchar2);
        oracleParameter6.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index6] = oracleParameter6;
      int index7 = 6;
      OracleParameter oracleParameter8 = new OracleParameter(":ShowType", OracleDbType.Int32);
      oracleParameter8.Value = (object) model.ShowType;
      oracleParameterArray[index7] = oracleParameter8;
      int index8 = 7;
      OracleParameter oracleParameter9;
      if (model.ShowFormat != null)
      {
        OracleParameter oracleParameter7 = new OracleParameter(":ShowFormat", OracleDbType.Varchar2);
        oracleParameter7.Value = (object) model.ShowFormat;
        oracleParameter9 = oracleParameter7;
      }
      else
      {
        oracleParameter9 = new OracleParameter(":ShowFormat", OracleDbType.Varchar2);
        oracleParameter9.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index8] = oracleParameter9;
      int index9 = 8;
      OracleParameter oracleParameter10;
      if (model.CustomString != null)
      {
        OracleParameter oracleParameter7 = new OracleParameter(":CustomString", OracleDbType.Varchar2);
        oracleParameter7.Value = (object) model.CustomString;
        oracleParameter10 = oracleParameter7;
      }
      else
      {
        oracleParameter10 = new OracleParameter(":CustomString", OracleDbType.Varchar2);
        oracleParameter10.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index9] = oracleParameter10;
      int index10 = 9;
      OracleParameter oracleParameter11 = new OracleParameter(":Sort", OracleDbType.Int32);
      oracleParameter11.Value = (object) model.Sort;
      oracleParameterArray[index10] = oracleParameter11;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Update(RoadFlow.Data.Model.ProgramBuilderFields model)
    {
      string sql = "UPDATE ProgramBuilderFields SET \r\n\t\t\t\tProgramID=:ProgramID,Field=:Field,ShowTitle=:ShowTitle,Align=:Align,Width=:Width,ShowType=:ShowType,ShowFormat=:ShowFormat,CustomString=:CustomString,Sort=:Sort\r\n\t\t\t\tWHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[10];
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
      OracleParameter oracleParameter4 = new OracleParameter(":Align", OracleDbType.Varchar2);
      oracleParameter4.Value = (object) model.Align;
      oracleParameterArray[index4] = oracleParameter4;
      int index5 = 4;
      OracleParameter oracleParameter5;
      if (model.Width != null)
      {
        OracleParameter oracleParameter6 = new OracleParameter(":Width", OracleDbType.Varchar2);
        oracleParameter6.Value = (object) model.Width;
        oracleParameter5 = oracleParameter6;
      }
      else
      {
        oracleParameter5 = new OracleParameter(":Width", OracleDbType.Varchar2);
        oracleParameter5.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index5] = oracleParameter5;
      int index6 = 5;
      OracleParameter oracleParameter7 = new OracleParameter(":ShowType", OracleDbType.Int32);
      oracleParameter7.Value = (object) model.ShowType;
      oracleParameterArray[index6] = oracleParameter7;
      int index7 = 6;
      OracleParameter oracleParameter8;
      if (model.ShowFormat != null)
      {
        OracleParameter oracleParameter6 = new OracleParameter(":ShowFormat", OracleDbType.Varchar2);
        oracleParameter6.Value = (object) model.ShowFormat;
        oracleParameter8 = oracleParameter6;
      }
      else
      {
        oracleParameter8 = new OracleParameter(":ShowFormat", OracleDbType.Varchar2);
        oracleParameter8.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index7] = oracleParameter8;
      int index8 = 7;
      OracleParameter oracleParameter9;
      if (model.CustomString != null)
      {
        OracleParameter oracleParameter6 = new OracleParameter(":CustomString", OracleDbType.Varchar2);
        oracleParameter6.Value = (object) model.CustomString;
        oracleParameter9 = oracleParameter6;
      }
      else
      {
        oracleParameter9 = new OracleParameter(":CustomString", OracleDbType.Varchar2);
        oracleParameter9.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index8] = oracleParameter9;
      int index9 = 8;
      OracleParameter oracleParameter10 = new OracleParameter(":Sort", OracleDbType.Int32);
      oracleParameter10.Value = (object) model.Sort;
      oracleParameterArray[index9] = oracleParameter10;
      int index10 = 9;
      OracleParameter oracleParameter11 = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter11.Value = (object) model.ID;
      oracleParameterArray[index10] = oracleParameter11;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM ProgramBuilderFields WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    private List<RoadFlow.Data.Model.ProgramBuilderFields> DataReaderToList(OracleDataReader dataReader)
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
      OracleDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM ProgramBuilderFields");
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
      string sql = "SELECT * FROM ProgramBuilderFields WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.ProgramBuilderFields> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.ProgramBuilderFields) null;
      return list[0];
    }

    public List<RoadFlow.Data.Model.ProgramBuilderFields> GetAll(Guid programID)
    {
      string sql = "SELECT * FROM ProgramBuilderFields WHERE ProgramID=:ProgramID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ProgramID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) programID;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.ProgramBuilderFields> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public int DeleteByProgramID(Guid id)
    {
      string sql = "DELETE FROM ProgramBuilderFields WHERE ProgramID=:ProgramID";
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
