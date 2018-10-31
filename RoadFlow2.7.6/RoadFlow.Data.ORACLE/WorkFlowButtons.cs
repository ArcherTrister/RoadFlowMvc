// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.ORACLE.WorkFlowButtons
// Assembly: RoadFlow.Data.ORACLE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C9018AA1-E48E-4231-92A9-CD6F0F275D11
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.ORACLE.dll

using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.ORACLE
{
  public class WorkFlowButtons : IWorkFlowButtons
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.WorkFlowButtons model)
    {
      string sql = "INSERT INTO WorkFlowButtons\r\n\t\t\t\t(ID,Title,Ico,Script,Note,Sort) \r\n\t\t\t\tVALUES(:ID,:Title,:Ico,:Script,:Note,:Sort)";
      OracleParameter[] oracleParameterArray = new OracleParameter[6];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":ID", OracleDbType.Varchar2, 40);
      oracleParameter1.Value = (object) model.ID;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":Title", OracleDbType.NVarchar2, 1000);
      oracleParameter2.Value = (object) model.Title;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3;
      if (model.Ico != null)
      {
        OracleParameter oracleParameter4 = new OracleParameter(":Ico", OracleDbType.Varchar2, 500);
        oracleParameter4.Value = (object) model.Ico;
        oracleParameter3 = oracleParameter4;
      }
      else
      {
        oracleParameter3 = new OracleParameter(":Ico", OracleDbType.Varchar2, 500);
        oracleParameter3.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter5;
      if (model.Script != null)
      {
        OracleParameter oracleParameter4 = new OracleParameter(":Script", OracleDbType.Clob);
        oracleParameter4.Value = (object) model.Script;
        oracleParameter5 = oracleParameter4;
      }
      else
      {
        oracleParameter5 = new OracleParameter(":Script", OracleDbType.Clob);
        oracleParameter5.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index4] = oracleParameter5;
      int index5 = 4;
      OracleParameter oracleParameter6;
      if (model.Note != null)
      {
        OracleParameter oracleParameter4 = new OracleParameter(":Note", OracleDbType.Clob);
        oracleParameter4.Value = (object) model.Note;
        oracleParameter6 = oracleParameter4;
      }
      else
      {
        oracleParameter6 = new OracleParameter(":Note", OracleDbType.Clob);
        oracleParameter6.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index5] = oracleParameter6;
      int index6 = 5;
      OracleParameter oracleParameter7 = new OracleParameter(":Sort", OracleDbType.Int32);
      oracleParameter7.Value = (object) model.Sort;
      oracleParameterArray[index6] = oracleParameter7;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Update(RoadFlow.Data.Model.WorkFlowButtons model)
    {
      string sql = "UPDATE WorkFlowButtons SET \r\n\t\t\t\tTitle=:Title,Ico=:Ico,Script=:Script,Note=:Note,Sort=:Sort\r\n\t\t\t\tWHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[6];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":Title", OracleDbType.NVarchar2, 1000);
      oracleParameter1.Value = (object) model.Title;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2;
      if (model.Ico != null)
      {
        OracleParameter oracleParameter3 = new OracleParameter(":Ico", OracleDbType.Varchar2, 500);
        oracleParameter3.Value = (object) model.Ico;
        oracleParameter2 = oracleParameter3;
      }
      else
      {
        oracleParameter2 = new OracleParameter(":Ico", OracleDbType.Varchar2, 500);
        oracleParameter2.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter4;
      if (model.Script != null)
      {
        OracleParameter oracleParameter3 = new OracleParameter(":Script", OracleDbType.Clob);
        oracleParameter3.Value = (object) model.Script;
        oracleParameter4 = oracleParameter3;
      }
      else
      {
        oracleParameter4 = new OracleParameter(":Script", OracleDbType.Clob);
        oracleParameter4.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index3] = oracleParameter4;
      int index4 = 3;
      OracleParameter oracleParameter5;
      if (model.Note != null)
      {
        OracleParameter oracleParameter3 = new OracleParameter(":Note", OracleDbType.Clob);
        oracleParameter3.Value = (object) model.Note;
        oracleParameter5 = oracleParameter3;
      }
      else
      {
        oracleParameter5 = new OracleParameter(":Note", OracleDbType.Clob);
        oracleParameter5.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index4] = oracleParameter5;
      int index5 = 4;
      OracleParameter oracleParameter6 = new OracleParameter(":Sort", OracleDbType.Int32);
      oracleParameter6.Value = (object) model.Sort;
      oracleParameterArray[index5] = oracleParameter6;
      int index6 = 5;
      OracleParameter oracleParameter7 = new OracleParameter(":ID", OracleDbType.Varchar2, 40);
      oracleParameter7.Value = (object) model.ID;
      oracleParameterArray[index6] = oracleParameter7;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM WorkFlowButtons WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    private List<RoadFlow.Data.Model.WorkFlowButtons> DataReaderToList(OracleDataReader dataReader)
    {
      List<RoadFlow.Data.Model.WorkFlowButtons> workFlowButtonsList = new List<RoadFlow.Data.Model.WorkFlowButtons>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.WorkFlowButtons workFlowButtons = new RoadFlow.Data.Model.WorkFlowButtons();
        workFlowButtons.ID = dataReader.GetString(0).ToGuid();
        workFlowButtons.Title = dataReader.GetString(1);
        if (!dataReader.IsDBNull(2))
          workFlowButtons.Ico = dataReader.GetString(2);
        if (!dataReader.IsDBNull(3))
          workFlowButtons.Script = dataReader.GetString(3);
        if (!dataReader.IsDBNull(4))
          workFlowButtons.Note = dataReader.GetString(4);
        workFlowButtons.Sort = dataReader.GetInt32(5);
        workFlowButtonsList.Add(workFlowButtons);
      }
      return workFlowButtonsList;
    }

    public List<RoadFlow.Data.Model.WorkFlowButtons> GetAll()
    {
      OracleDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM WorkFlowButtons");
      List<RoadFlow.Data.Model.WorkFlowButtons> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM WorkFlowButtons"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.WorkFlowButtons Get(Guid id)
    {
      string sql = "SELECT * FROM WorkFlowButtons WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkFlowButtons> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.WorkFlowButtons) null;
      return list[0];
    }

    public int GetMaxSort()
    {
      string fieldValue = this.dbHelper.GetFieldValue("SELECT nvl(MAX(Sort),0)+1 FROM WorkFlowButtons");
      if (!fieldValue.IsInt())
        return 1;
      return fieldValue.ToInt();
    }
  }
}
