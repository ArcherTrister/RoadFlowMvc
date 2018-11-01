// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.ORACLE.ProgramBuilderButtons
// Assembly: RoadFlow.Data.ORACLE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C9018AA1-E48E-4231-92A9-CD6F0F275D11
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.ORACLE.dll

using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.ORACLE
{
  public class ProgramBuilderButtons : IProgramBuilderButtons
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.ProgramBuilderButtons model)
    {
      string sql = "INSERT INTO ProgramBuilderButtons\r\n\t\t\t\t(ID,ProgramID,ButtonID,ButtonName,ClientScript,Ico,ShowType,Sort,IsValidateShow) \r\n\t\t\t\tVALUES(:ID,:ProgramID,:ButtonID,:ButtonName,:ClientScript,:Ico,:ShowType,:Sort,:IsValidateShow)";
      OracleParameter[] oracleParameterArray = new OracleParameter[9];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter1.Value = (object) model.ID;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":ProgramID", OracleDbType.Varchar2);
      oracleParameter2.Value = (object) model.ProgramID;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3;
      if (model.ButtonID.HasValue)
      {
        OracleParameter oracleParameter4 = new OracleParameter(":ButtonID", OracleDbType.Varchar2);
        oracleParameter4.Value = (object) model.ButtonID;
        oracleParameter3 = oracleParameter4;
      }
      else
      {
        oracleParameter3 = new OracleParameter(":ButtonID", OracleDbType.Varchar2);
        oracleParameter3.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter5 = new OracleParameter(":ButtonName", OracleDbType.Varchar2);
      oracleParameter5.Value = (object) model.ButtonName;
      oracleParameterArray[index4] = oracleParameter5;
      int index5 = 4;
      OracleParameter oracleParameter6;
      if (model.ClientScript != null)
      {
        OracleParameter oracleParameter4 = new OracleParameter(":ClientScript", OracleDbType.Varchar2);
        oracleParameter4.Value = (object) model.ClientScript;
        oracleParameter6 = oracleParameter4;
      }
      else
      {
        oracleParameter6 = new OracleParameter(":ClientScript", OracleDbType.Varchar2);
        oracleParameter6.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index5] = oracleParameter6;
      int index6 = 5;
      OracleParameter oracleParameter7;
      if (model.Ico != null)
      {
        OracleParameter oracleParameter4 = new OracleParameter(":Ico", OracleDbType.Varchar2);
        oracleParameter4.Value = (object) model.Ico;
        oracleParameter7 = oracleParameter4;
      }
      else
      {
        oracleParameter7 = new OracleParameter(":Ico", OracleDbType.Varchar2);
        oracleParameter7.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index6] = oracleParameter7;
      int index7 = 6;
      OracleParameter oracleParameter8 = new OracleParameter(":ShowType", OracleDbType.Int32);
      oracleParameter8.Value = (object) model.ShowType;
      oracleParameterArray[index7] = oracleParameter8;
      int index8 = 7;
      OracleParameter oracleParameter9 = new OracleParameter(":Sort", OracleDbType.Int32);
      oracleParameter9.Value = (object) model.Sort;
      oracleParameterArray[index8] = oracleParameter9;
      int index9 = 8;
      OracleParameter oracleParameter10 = new OracleParameter(":IsValidateShow", OracleDbType.Int32);
      oracleParameter10.Value = (object) model.IsValidateShow;
      oracleParameterArray[index9] = oracleParameter10;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Update(RoadFlow.Data.Model.ProgramBuilderButtons model)
    {
      string sql = "UPDATE ProgramBuilderButtons SET \r\n\t\t\t\tProgramID=:ProgramID,ButtonID=:ButtonID,ButtonName=:ButtonName,ClientScript=:ClientScript,Ico=:Ico,ShowType=:ShowType,Sort=:Sort,IsValidateShow=:IsValidateShow\r\n\t\t\t\tWHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[9];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":ProgramID", OracleDbType.Varchar2);
      oracleParameter1.Value = (object) model.ProgramID;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2;
      if (model.ButtonID.HasValue)
      {
        OracleParameter oracleParameter3 = new OracleParameter(":ButtonID", OracleDbType.Varchar2);
        oracleParameter3.Value = (object) model.ButtonID;
        oracleParameter2 = oracleParameter3;
      }
      else
      {
        oracleParameter2 = new OracleParameter(":ButtonID", OracleDbType.Varchar2);
        oracleParameter2.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter4 = new OracleParameter(":ButtonName", OracleDbType.Varchar2);
      oracleParameter4.Value = (object) model.ButtonName;
      oracleParameterArray[index3] = oracleParameter4;
      int index4 = 3;
      OracleParameter oracleParameter5;
      if (model.ClientScript != null)
      {
        OracleParameter oracleParameter3 = new OracleParameter(":ClientScript", OracleDbType.Varchar2);
        oracleParameter3.Value = (object) model.ClientScript;
        oracleParameter5 = oracleParameter3;
      }
      else
      {
        oracleParameter5 = new OracleParameter(":ClientScript", OracleDbType.Varchar2);
        oracleParameter5.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index4] = oracleParameter5;
      int index5 = 4;
      OracleParameter oracleParameter6;
      if (model.Ico != null)
      {
        OracleParameter oracleParameter3 = new OracleParameter(":Ico", OracleDbType.Varchar2);
        oracleParameter3.Value = (object) model.Ico;
        oracleParameter6 = oracleParameter3;
      }
      else
      {
        oracleParameter6 = new OracleParameter(":Ico", OracleDbType.Varchar2);
        oracleParameter6.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index5] = oracleParameter6;
      int index6 = 5;
      OracleParameter oracleParameter7 = new OracleParameter(":ShowType", OracleDbType.Int32);
      oracleParameter7.Value = (object) model.ShowType;
      oracleParameterArray[index6] = oracleParameter7;
      int index7 = 6;
      OracleParameter oracleParameter8 = new OracleParameter(":Sort", OracleDbType.Int32);
      oracleParameter8.Value = (object) model.Sort;
      oracleParameterArray[index7] = oracleParameter8;
      int index8 = 7;
      OracleParameter oracleParameter9 = new OracleParameter(":IsValidateShow", OracleDbType.Int32);
      oracleParameter9.Value = (object) model.IsValidateShow;
      oracleParameterArray[index8] = oracleParameter9;
      int index9 = 8;
      OracleParameter oracleParameter10 = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter10.Value = (object) model.ID;
      oracleParameterArray[index9] = oracleParameter10;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM ProgramBuilderButtons WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    private List<RoadFlow.Data.Model.ProgramBuilderButtons> DataReaderToList(OracleDataReader dataReader)
    {
      List<RoadFlow.Data.Model.ProgramBuilderButtons> programBuilderButtonsList = new List<RoadFlow.Data.Model.ProgramBuilderButtons>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.ProgramBuilderButtons programBuilderButtons = new RoadFlow.Data.Model.ProgramBuilderButtons();
        programBuilderButtons.ID = dataReader.GetString(0).ToGuid();
        programBuilderButtons.ProgramID = dataReader.GetString(1).ToGuid();
        if (!dataReader.IsDBNull(2))
          programBuilderButtons.ButtonID = new Guid?(dataReader.GetString(2).ToGuid());
        programBuilderButtons.ButtonName = dataReader.GetString(3);
        if (!dataReader.IsDBNull(4))
          programBuilderButtons.ClientScript = dataReader.GetString(4);
        if (!dataReader.IsDBNull(5))
          programBuilderButtons.Ico = dataReader.GetString(5);
        programBuilderButtons.ShowType = dataReader.GetInt32(6);
        programBuilderButtons.Sort = dataReader.GetInt32(7);
        programBuilderButtons.IsValidateShow = dataReader.GetInt32(8);
        programBuilderButtonsList.Add(programBuilderButtons);
      }
      return programBuilderButtonsList;
    }

    public List<RoadFlow.Data.Model.ProgramBuilderButtons> GetAll()
    {
      OracleDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM ProgramBuilderButtons");
      List<RoadFlow.Data.Model.ProgramBuilderButtons> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM ProgramBuilderButtons"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.ProgramBuilderButtons Get(Guid id)
    {
      string sql = "SELECT * FROM ProgramBuilderButtons WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.ProgramBuilderButtons> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.ProgramBuilderButtons) null;
      return list[0];
    }

    public List<RoadFlow.Data.Model.ProgramBuilderButtons> GetAll(Guid id)
    {
      string sql = "SELECT * FROM ProgramBuilderButtons WHERE ProgramID=:ProgramID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ProgramID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.ProgramBuilderButtons> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }
  }
}
