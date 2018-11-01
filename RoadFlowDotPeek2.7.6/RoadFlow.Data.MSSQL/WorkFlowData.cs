// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MSSQL.WorkFlowData
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
  public class WorkFlowData : IWorkFlowData
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.WorkFlowData model)
    {
      string sql = "INSERT INTO WorkFlowData\r\n\t\t\t\t(ID,InstanceID,LinkID,TableName,FieldName,Value) \r\n\t\t\t\tVALUES(@ID,@InstanceID,@LinkID,@TableName,@FieldName,@Value)";
      SqlParameter[] sqlParameterArray = new SqlParameter[6];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter1.Value = (object) model.ID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@InstanceID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter2.Value = (object) model.InstanceID;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@LinkID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter3.Value = (object) model.LinkID;
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter4 = new SqlParameter("@TableName", SqlDbType.VarChar, 500);
      sqlParameter4.Value = (object) model.TableName;
      sqlParameterArray[index4] = sqlParameter4;
      int index5 = 4;
      SqlParameter sqlParameter5 = new SqlParameter("@FieldName", SqlDbType.VarChar, 500);
      sqlParameter5.Value = (object) model.FieldName;
      sqlParameterArray[index5] = sqlParameter5;
      int index6 = 5;
      SqlParameter sqlParameter6 = new SqlParameter("@Value", SqlDbType.VarChar, 8000);
      sqlParameter6.Value = (object) model.Value;
      sqlParameterArray[index6] = sqlParameter6;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.WorkFlowData model)
    {
      string sql = "UPDATE WorkFlowData SET \r\n\t\t\t\tInstanceID=@InstanceID,LinkID=@LinkID,TableName=@TableName,FieldName=@FieldName,Value=@Value\r\n\t\t\t\tWHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[6];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@InstanceID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter1.Value = (object) model.InstanceID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@LinkID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter2.Value = (object) model.LinkID;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@TableName", SqlDbType.VarChar, 500);
      sqlParameter3.Value = (object) model.TableName;
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter4 = new SqlParameter("@FieldName", SqlDbType.VarChar, 500);
      sqlParameter4.Value = (object) model.FieldName;
      sqlParameterArray[index4] = sqlParameter4;
      int index5 = 4;
      SqlParameter sqlParameter5 = new SqlParameter("@Value", SqlDbType.VarChar, 8000);
      sqlParameter5.Value = (object) model.Value;
      sqlParameterArray[index5] = sqlParameter5;
      int index6 = 5;
      SqlParameter sqlParameter6 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter6.Value = (object) model.ID;
      sqlParameterArray[index6] = sqlParameter6;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM WorkFlowData WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.WorkFlowData> DataReaderToList(SqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.WorkFlowData> workFlowDataList = new List<RoadFlow.Data.Model.WorkFlowData>();
      while (dataReader.Read())
        workFlowDataList.Add(new RoadFlow.Data.Model.WorkFlowData()
        {
          ID = dataReader.GetGuid(0),
          InstanceID = dataReader.GetGuid(1),
          LinkID = dataReader.GetGuid(2),
          TableName = dataReader.GetString(3),
          FieldName = dataReader.GetString(4),
          Value = dataReader.GetString(5)
        });
      return workFlowDataList;
    }

    public List<RoadFlow.Data.Model.WorkFlowData> GetAll()
    {
      SqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM WorkFlowData");
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
      string sql = "SELECT * FROM WorkFlowData WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkFlowData> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.WorkFlowData) null;
      return list[0];
    }

    public List<RoadFlow.Data.Model.WorkFlowData> GetAll(Guid instanceID)
    {
      string sql = "SELECT * FROM WorkFlowData WHERE InstanceID=@InstanceID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@InstanceID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) instanceID;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkFlowData> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }
  }
}
