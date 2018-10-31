// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.ORACLE.WorkFlowData
// Assembly: RoadFlow.Data.ORACLE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C9018AA1-E48E-4231-92A9-CD6F0F275D11
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.ORACLE.dll

using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.ORACLE
{
  public class WorkFlowData : IWorkFlowData
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.WorkFlowData model)
    {
      string sql = "INSERT INTO WorkFlowData\r\n\t\t\t\t(ID,InstanceID,LinkID,TableName,FieldName,Value) \r\n\t\t\t\tVALUES(:ID,:InstanceID,:LinkID,:TableName,:FieldName,:Value)";
      OracleParameter[] oracleParameterArray = new OracleParameter[6];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":ID", OracleDbType.Varchar2, 40);
      oracleParameter1.Value = (object) model.ID;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":InstanceID", OracleDbType.Varchar2, 40);
      oracleParameter2.Value = (object) model.InstanceID;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3 = new OracleParameter(":LinkID", OracleDbType.Varchar2, 40);
      oracleParameter3.Value = (object) model.LinkID;
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter4 = new OracleParameter(":TableName", OracleDbType.Varchar2, 500);
      oracleParameter4.Value = (object) model.TableName;
      oracleParameterArray[index4] = oracleParameter4;
      int index5 = 4;
      OracleParameter oracleParameter5 = new OracleParameter(":FieldName", OracleDbType.Varchar2, 500);
      oracleParameter5.Value = (object) model.FieldName;
      oracleParameterArray[index5] = oracleParameter5;
      int index6 = 5;
      OracleParameter oracleParameter6 = new OracleParameter(":Value", OracleDbType.Varchar2, 4000);
      oracleParameter6.Value = (object) model.Value;
      oracleParameterArray[index6] = oracleParameter6;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Update(RoadFlow.Data.Model.WorkFlowData model)
    {
      string sql = "UPDATE WorkFlowData SET \r\n\t\t\t\tInstanceID=:InstanceID,LinkID=:LinkID,TableName=:TableName,FieldName=:FieldName,Value=:Value\r\n\t\t\t\tWHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[6];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":InstanceID", OracleDbType.Varchar2, 40);
      oracleParameter1.Value = (object) model.InstanceID;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":LinkID", OracleDbType.Varchar2, 40);
      oracleParameter2.Value = (object) model.LinkID;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3 = new OracleParameter(":TableName", OracleDbType.Varchar2, 500);
      oracleParameter3.Value = (object) model.TableName;
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter4 = new OracleParameter(":FieldName", OracleDbType.Varchar2, 500);
      oracleParameter4.Value = (object) model.FieldName;
      oracleParameterArray[index4] = oracleParameter4;
      int index5 = 4;
      OracleParameter oracleParameter5 = new OracleParameter(":Value", OracleDbType.Varchar2, 4000);
      oracleParameter5.Value = (object) model.Value;
      oracleParameterArray[index5] = oracleParameter5;
      int index6 = 5;
      OracleParameter oracleParameter6 = new OracleParameter(":ID", OracleDbType.Varchar2, 40);
      oracleParameter6.Value = (object) model.ID;
      oracleParameterArray[index6] = oracleParameter6;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM WorkFlowData WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    private List<RoadFlow.Data.Model.WorkFlowData> DataReaderToList(OracleDataReader dataReader)
    {
      List<RoadFlow.Data.Model.WorkFlowData> workFlowDataList = new List<RoadFlow.Data.Model.WorkFlowData>();
      while (dataReader.Read())
        workFlowDataList.Add(new RoadFlow.Data.Model.WorkFlowData()
        {
          ID = dataReader.GetString(0).ToGuid(),
          InstanceID = dataReader.GetString(1).ToGuid(),
          LinkID = dataReader.GetString(2).ToGuid(),
          TableName = dataReader.GetString(3),
          FieldName = dataReader.GetString(4),
          Value = dataReader.GetString(5)
        });
      return workFlowDataList;
    }

    public List<RoadFlow.Data.Model.WorkFlowData> GetAll()
    {
      OracleDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM WorkFlowData");
      List<RoadFlow.Data.Model.WorkFlowData> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM WorkFlowData"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.WorkFlowData Get(Guid id)
    {
      string sql = "SELECT * FROM WorkFlowData WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkFlowData> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.WorkFlowData) null;
      return list[0];
    }

    public List<RoadFlow.Data.Model.WorkFlowData> GetAll(Guid instanceID)
    {
      string sql = "SELECT * FROM WorkFlowData WHERE InstanceID=:InstanceID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":InstanceID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) instanceID;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkFlowData> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }
  }
}
