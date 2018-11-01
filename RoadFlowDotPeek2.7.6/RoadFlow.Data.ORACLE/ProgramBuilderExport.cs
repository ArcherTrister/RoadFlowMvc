// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.ORACLE.ProgramBuilderExport
// Assembly: RoadFlow.Data.ORACLE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C9018AA1-E48E-4231-92A9-CD6F0F275D11
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.ORACLE.dll

using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.ORACLE
{
  public class ProgramBuilderExport : IProgramBuilderExport
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.ProgramBuilderExport model)
    {
      string sql = "INSERT INTO programbuilderexport\r\n\t\t\t\t(ID,ProgramID,Field,ShowTitle,Align,Width,ShowType,DataType,ShowFormat,CustomString,Sort) \r\n\t\t\t\tVALUES(:ID,:ProgramID,:Field,:ShowTitle,:Align,:Width,:ShowType,:DataType,:ShowFormat,:CustomString,:Sort)";
      OracleParameter[] oracleParameterArray = new OracleParameter[11];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":ID", OracleDbType.Varchar2, 36);
      oracleParameter1.Value = (object) model.ID;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":ProgramID", OracleDbType.Varchar2, 36);
      oracleParameter2.Value = (object) model.ProgramID;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3 = new OracleParameter(":Field", OracleDbType.Blob, -1);
      oracleParameter3.Value = (object) model.Field;
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter4;
      if (model.ShowTitle != null)
      {
        OracleParameter oracleParameter5 = new OracleParameter(":ShowTitle", OracleDbType.Blob, -1);
        oracleParameter5.Value = (object) model.ShowTitle;
        oracleParameter4 = oracleParameter5;
      }
      else
      {
        oracleParameter4 = new OracleParameter(":ShowTitle", OracleDbType.Blob, -1);
        oracleParameter4.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index4] = oracleParameter4;
      int index5 = 4;
      OracleParameter oracleParameter6 = new OracleParameter(":Align", OracleDbType.Int32, 11);
      oracleParameter6.Value = (object) model.Align;
      oracleParameterArray[index5] = oracleParameter6;
      int index6 = 5;
      int? nullable = model.Width;
      OracleParameter oracleParameter7;
      if (nullable.HasValue)
      {
        OracleParameter oracleParameter5 = new OracleParameter(":Width", OracleDbType.Int32, 11);
        oracleParameter5.Value = (object) model.Width;
        oracleParameter7 = oracleParameter5;
      }
      else
      {
        oracleParameter7 = new OracleParameter(":Width", OracleDbType.Int32, 11);
        oracleParameter7.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index6] = oracleParameter7;
      int index7 = 6;
      nullable = model.ShowType;
      OracleParameter oracleParameter8;
      if (nullable.HasValue)
      {
        OracleParameter oracleParameter5 = new OracleParameter(":ShowType", OracleDbType.Int32, 11);
        oracleParameter5.Value = (object) model.ShowType;
        oracleParameter8 = oracleParameter5;
      }
      else
      {
        oracleParameter8 = new OracleParameter(":ShowType", OracleDbType.Int32, 11);
        oracleParameter8.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index7] = oracleParameter8;
      int index8 = 7;
      nullable = model.DataType;
      OracleParameter oracleParameter9;
      if (nullable.HasValue)
      {
        OracleParameter oracleParameter5 = new OracleParameter(":DataType", OracleDbType.Int32, 11);
        oracleParameter5.Value = (object) model.DataType;
        oracleParameter9 = oracleParameter5;
      }
      else
      {
        oracleParameter9 = new OracleParameter(":DataType", OracleDbType.Int32, 11);
        oracleParameter9.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index8] = oracleParameter9;
      int index9 = 8;
      OracleParameter oracleParameter10;
      if (model.ShowFormat != null)
      {
        OracleParameter oracleParameter5 = new OracleParameter(":ShowFormat", OracleDbType.Varchar2, 50);
        oracleParameter5.Value = (object) model.ShowFormat;
        oracleParameter10 = oracleParameter5;
      }
      else
      {
        oracleParameter10 = new OracleParameter(":ShowFormat", OracleDbType.Varchar2, 50);
        oracleParameter10.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index9] = oracleParameter10;
      int index10 = 9;
      OracleParameter oracleParameter11;
      if (model.CustomString != null)
      {
        OracleParameter oracleParameter5 = new OracleParameter(":CustomString", OracleDbType.Blob, -1);
        oracleParameter5.Value = (object) model.CustomString;
        oracleParameter11 = oracleParameter5;
      }
      else
      {
        oracleParameter11 = new OracleParameter(":CustomString", OracleDbType.Blob, -1);
        oracleParameter11.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index10] = oracleParameter11;
      int index11 = 10;
      OracleParameter oracleParameter12 = new OracleParameter(":Sort", OracleDbType.Int32, 11);
      oracleParameter12.Value = (object) model.Sort;
      oracleParameterArray[index11] = oracleParameter12;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Update(RoadFlow.Data.Model.ProgramBuilderExport model)
    {
      string sql = "UPDATE programbuilderexport SET \r\n\t\t\t\tProgramID=:ProgramID,Field=:Field,ShowTitle=:ShowTitle,Align=:Align,Width=:Width,ShowType=:ShowType,DataType=:DataType,ShowFormat=:ShowFormat,CustomString=:CustomString,Sort=:Sort\r\n\t\t\t\tWHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[11];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":ProgramID", OracleDbType.Varchar2, 36);
      oracleParameter1.Value = (object) model.ProgramID;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":Field", OracleDbType.Blob, -1);
      oracleParameter2.Value = (object) model.Field;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3;
      if (model.ShowTitle != null)
      {
        OracleParameter oracleParameter4 = new OracleParameter(":ShowTitle", OracleDbType.Blob, -1);
        oracleParameter4.Value = (object) model.ShowTitle;
        oracleParameter3 = oracleParameter4;
      }
      else
      {
        oracleParameter3 = new OracleParameter(":ShowTitle", OracleDbType.Blob, -1);
        oracleParameter3.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter5 = new OracleParameter(":Align", OracleDbType.Int32, 11);
      oracleParameter5.Value = (object) model.Align;
      oracleParameterArray[index4] = oracleParameter5;
      int index5 = 4;
      int? nullable = model.Width;
      OracleParameter oracleParameter6;
      if (nullable.HasValue)
      {
        OracleParameter oracleParameter4 = new OracleParameter(":Width", OracleDbType.Int32, 11);
        oracleParameter4.Value = (object) model.Width;
        oracleParameter6 = oracleParameter4;
      }
      else
      {
        oracleParameter6 = new OracleParameter(":Width", OracleDbType.Int32, 11);
        oracleParameter6.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index5] = oracleParameter6;
      int index6 = 5;
      nullable = model.ShowType;
      OracleParameter oracleParameter7;
      if (nullable.HasValue)
      {
        OracleParameter oracleParameter4 = new OracleParameter(":ShowType", OracleDbType.Int32, 11);
        oracleParameter4.Value = (object) model.ShowType;
        oracleParameter7 = oracleParameter4;
      }
      else
      {
        oracleParameter7 = new OracleParameter(":ShowType", OracleDbType.Int32, 11);
        oracleParameter7.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index6] = oracleParameter7;
      int index7 = 6;
      nullable = model.DataType;
      OracleParameter oracleParameter8;
      if (nullable.HasValue)
      {
        OracleParameter oracleParameter4 = new OracleParameter(":DataType", OracleDbType.Int32, 11);
        oracleParameter4.Value = (object) model.DataType;
        oracleParameter8 = oracleParameter4;
      }
      else
      {
        oracleParameter8 = new OracleParameter(":DataType", OracleDbType.Int32, 11);
        oracleParameter8.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index7] = oracleParameter8;
      int index8 = 7;
      OracleParameter oracleParameter9;
      if (model.ShowFormat != null)
      {
        OracleParameter oracleParameter4 = new OracleParameter(":ShowFormat", OracleDbType.Varchar2, 50);
        oracleParameter4.Value = (object) model.ShowFormat;
        oracleParameter9 = oracleParameter4;
      }
      else
      {
        oracleParameter9 = new OracleParameter(":ShowFormat", OracleDbType.Varchar2, 50);
        oracleParameter9.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index8] = oracleParameter9;
      int index9 = 8;
      OracleParameter oracleParameter10;
      if (model.CustomString != null)
      {
        OracleParameter oracleParameter4 = new OracleParameter(":CustomString", OracleDbType.Blob, -1);
        oracleParameter4.Value = (object) model.CustomString;
        oracleParameter10 = oracleParameter4;
      }
      else
      {
        oracleParameter10 = new OracleParameter(":CustomString", OracleDbType.Blob, -1);
        oracleParameter10.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index9] = oracleParameter10;
      int index10 = 9;
      OracleParameter oracleParameter11 = new OracleParameter(":Sort", OracleDbType.Int32, 11);
      oracleParameter11.Value = (object) model.Sort;
      oracleParameterArray[index10] = oracleParameter11;
      int index11 = 10;
      OracleParameter oracleParameter12 = new OracleParameter(":ID", OracleDbType.Varchar2, 36);
      oracleParameter12.Value = (object) model.ID;
      oracleParameterArray[index11] = oracleParameter12;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM programbuilderexport WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2, 36);
      oracleParameter.Value = (object) id.ToString();
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    private List<RoadFlow.Data.Model.ProgramBuilderExport> DataReaderToList(OracleDataReader dataReader)
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
      OracleDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM programbuilderexport");
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
      string sql = "SELECT * FROM programbuilderexport WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2, 36);
      oracleParameter.Value = (object) id.ToString();
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.ProgramBuilderExport> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.ProgramBuilderExport) null;
      return list[0];
    }

    public List<RoadFlow.Data.Model.ProgramBuilderExport> GetAll(Guid programID)
    {
      string sql = "SELECT * FROM ProgramBuilderExport WHERE ProgramID=:ProgramID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ProgramID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) programID;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.ProgramBuilderExport> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }
  }
}
