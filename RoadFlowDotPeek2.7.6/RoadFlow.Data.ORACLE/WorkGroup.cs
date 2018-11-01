// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.ORACLE.WorkGroup
// Assembly: RoadFlow.Data.ORACLE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C9018AA1-E48E-4231-92A9-CD6F0F275D11
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.ORACLE.dll

using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.ORACLE
{
  public class WorkGroup : IWorkGroup
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.WorkGroup model)
    {
      string sql = "INSERT INTO WorkGroup\r\n\t\t\t\t(ID,Name,Members,Note,IntID) \r\n\t\t\t\tVALUES(:ID,:Name,:Members,:Note,:IntID)";
      OracleParameter[] oracleParameterArray = new OracleParameter[5];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":ID", OracleDbType.Varchar2, 40);
      oracleParameter1.Value = (object) model.ID;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":Name", OracleDbType.NVarchar2, 1000);
      oracleParameter2.Value = (object) model.Name;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3 = new OracleParameter(":Members", OracleDbType.Clob);
      oracleParameter3.Value = (object) model.Members;
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter4;
      if (model.Note != null)
      {
        OracleParameter oracleParameter5 = new OracleParameter(":Note", OracleDbType.NVarchar2);
        oracleParameter5.Value = (object) model.Note;
        oracleParameter4 = oracleParameter5;
      }
      else
      {
        oracleParameter4 = new OracleParameter(":Note", OracleDbType.NVarchar2);
        oracleParameter4.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index4] = oracleParameter4;
      int index5 = 4;
      OracleParameter oracleParameter6 = new OracleParameter(":IntID", OracleDbType.Int32);
      oracleParameter6.Value = (object) model.IntID;
      oracleParameterArray[index5] = oracleParameter6;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Update(RoadFlow.Data.Model.WorkGroup model)
    {
      string sql = "UPDATE WorkGroup SET \r\n\t\t\t\tName=:Name,Members=:Members,Note=:Note,IntID=:IntID \r\n\t\t\t\tWHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[5];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":Name", OracleDbType.NVarchar2, 1000);
      oracleParameter1.Value = (object) model.Name;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":Members", OracleDbType.Clob);
      oracleParameter2.Value = (object) model.Members;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3;
      if (model.Note != null)
      {
        OracleParameter oracleParameter4 = new OracleParameter(":Note", OracleDbType.NVarchar2);
        oracleParameter4.Value = (object) model.Note;
        oracleParameter3 = oracleParameter4;
      }
      else
      {
        oracleParameter3 = new OracleParameter(":Note", OracleDbType.NVarchar2);
        oracleParameter3.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter5 = new OracleParameter(":IntID", OracleDbType.Int32);
      oracleParameter5.Value = (object) model.IntID;
      oracleParameterArray[index4] = oracleParameter5;
      int index5 = 4;
      OracleParameter oracleParameter6 = new OracleParameter(":ID", OracleDbType.Varchar2, 40);
      oracleParameter6.Value = (object) model.ID;
      oracleParameterArray[index5] = oracleParameter6;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM WorkGroup WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    private List<RoadFlow.Data.Model.WorkGroup> DataReaderToList(OracleDataReader dataReader)
    {
      List<RoadFlow.Data.Model.WorkGroup> workGroupList = new List<RoadFlow.Data.Model.WorkGroup>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.WorkGroup workGroup = new RoadFlow.Data.Model.WorkGroup();
        workGroup.ID = dataReader.GetString(0).ToGuid();
        workGroup.Name = dataReader.GetString(1);
        workGroup.Members = dataReader.GetString(2);
        if (!dataReader.IsDBNull(3))
          workGroup.Note = dataReader.GetString(3);
        workGroup.IntID = dataReader.GetInt32(4);
        workGroupList.Add(workGroup);
      }
      return workGroupList;
    }

    public List<RoadFlow.Data.Model.WorkGroup> GetAll()
    {
      OracleDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM WorkGroup");
      List<RoadFlow.Data.Model.WorkGroup> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM WorkGroup"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.WorkGroup Get(Guid id)
    {
      string sql = "SELECT * FROM WorkGroup WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkGroup> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.WorkGroup) null;
      return list[0];
    }
  }
}
