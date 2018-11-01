// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.ORACLE.ProgramBuilderValidates
// Assembly: RoadFlow.Data.ORACLE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C9018AA1-E48E-4231-92A9-CD6F0F275D11
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.ORACLE.dll

using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.ORACLE
{
  public class ProgramBuilderValidates : IProgramBuilderValidates
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.ProgramBuilderValidates model)
    {
      string sql = "INSERT INTO ProgramBuilderValidates\r\n\t\t\t\t(ID,ProgramID,TableName,FieldName,FieldNote,Validate1) \r\n\t\t\t\tVALUES(:ID,:ProgramID,:TableName,:FieldName,:FieldNote,:Validate1)";
      OracleParameter[] oracleParameterArray = new OracleParameter[6];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter1.Value = (object) model.ID;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":ProgramID", OracleDbType.Varchar2);
      oracleParameter2.Value = (object) model.ProgramID;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3 = new OracleParameter(":TableName", OracleDbType.Varchar2);
      oracleParameter3.Value = (object) model.TableName;
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter4 = new OracleParameter(":FieldName", OracleDbType.Varchar2);
      oracleParameter4.Value = (object) model.FieldName;
      oracleParameterArray[index4] = oracleParameter4;
      int index5 = 4;
      OracleParameter oracleParameter5;
      if (model.FieldNote != null)
      {
        OracleParameter oracleParameter6 = new OracleParameter(":FieldNote", OracleDbType.Varchar2);
        oracleParameter6.Value = (object) model.FieldNote;
        oracleParameter5 = oracleParameter6;
      }
      else
      {
        oracleParameter5 = new OracleParameter(":FieldNote", OracleDbType.Varchar2);
        oracleParameter5.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index5] = oracleParameter5;
      int index6 = 5;
      OracleParameter oracleParameter7 = new OracleParameter(":Validate1", OracleDbType.Int32);
      oracleParameter7.Value = (object) model.Validate;
      oracleParameterArray[index6] = oracleParameter7;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Update(RoadFlow.Data.Model.ProgramBuilderValidates model)
    {
      string sql = "UPDATE ProgramBuilderValidates SET \r\n\t\t\t\tProgramID=:ProgramID,TableName=:TableName,FieldName=:FieldName,FieldNote=:FieldNote,Validate1=:Validate1\r\n\t\t\t\tWHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[6];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":ProgramID", OracleDbType.Varchar2);
      oracleParameter1.Value = (object) model.ProgramID;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":TableName", OracleDbType.Varchar2);
      oracleParameter2.Value = (object) model.TableName;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3 = new OracleParameter(":FieldName", OracleDbType.Varchar2);
      oracleParameter3.Value = (object) model.FieldName;
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter4;
      if (model.FieldNote != null)
      {
        OracleParameter oracleParameter5 = new OracleParameter(":FieldNote", OracleDbType.Varchar2);
        oracleParameter5.Value = (object) model.FieldNote;
        oracleParameter4 = oracleParameter5;
      }
      else
      {
        oracleParameter4 = new OracleParameter(":FieldNote", OracleDbType.Varchar2);
        oracleParameter4.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index4] = oracleParameter4;
      int index5 = 4;
      OracleParameter oracleParameter6 = new OracleParameter(":Validate1", OracleDbType.Int32);
      oracleParameter6.Value = (object) model.Validate;
      oracleParameterArray[index5] = oracleParameter6;
      int index6 = 5;
      OracleParameter oracleParameter7 = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter7.Value = (object) model.ID;
      oracleParameterArray[index6] = oracleParameter7;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM ProgramBuilderValidates WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    private List<RoadFlow.Data.Model.ProgramBuilderValidates> DataReaderToList(OracleDataReader dataReader)
    {
      List<RoadFlow.Data.Model.ProgramBuilderValidates> builderValidatesList = new List<RoadFlow.Data.Model.ProgramBuilderValidates>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.ProgramBuilderValidates builderValidates = new RoadFlow.Data.Model.ProgramBuilderValidates();
        builderValidates.ID = dataReader.GetString(0).ToGuid();
        builderValidates.ProgramID = dataReader.GetString(1).ToGuid();
        builderValidates.TableName = dataReader.GetString(2);
        builderValidates.FieldName = dataReader.GetString(3);
        if (!dataReader.IsDBNull(4))
          builderValidates.FieldNote = dataReader.GetString(4);
        builderValidates.Validate = dataReader.GetInt32(5);
        builderValidatesList.Add(builderValidates);
      }
      return builderValidatesList;
    }

    public List<RoadFlow.Data.Model.ProgramBuilderValidates> GetAll()
    {
      OracleDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM ProgramBuilderValidates");
      List<RoadFlow.Data.Model.ProgramBuilderValidates> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM ProgramBuilderValidates"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.ProgramBuilderValidates Get(Guid id)
    {
      string sql = "SELECT * FROM ProgramBuilderValidates WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.ProgramBuilderValidates> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.ProgramBuilderValidates) null;
      return list[0];
    }

    public List<RoadFlow.Data.Model.ProgramBuilderValidates> GetAll(Guid programID)
    {
      string sql = "SELECT * FROM ProgramBuilderValidates WHERE ProgramID=:ProgramID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ProgramID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) programID;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.ProgramBuilderValidates> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public int DeleteByProgramID(Guid id)
    {
      string sql = "DELETE FROM ProgramBuilderValidates WHERE ProgramID=:ProgramID";
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
