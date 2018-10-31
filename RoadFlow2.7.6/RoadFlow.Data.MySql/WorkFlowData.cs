// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MySql.WorkFlowData
// Assembly: RoadFlow.Data.MySql, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 29B652D7-5F6F-4A7D-AD1C-9F2C643FD784
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.MySql.dll

using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.MySql
{
  public class WorkFlowData : IWorkFlowData
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.WorkFlowData model)
    {
      string sql = "INSERT INTO WorkFlowData\r\n\t\t\t\t(ID,InstanceID,LinkID,TableName,FieldName,Value) \r\n\t\t\t\tVALUES(@ID,@InstanceID,@LinkID,@TableName,@FieldName,@Value)";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[6];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@ID", MySqlDbType.VarChar, -1);
      mySqlParameter1.Value = (object) model.ID;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@InstanceID", MySqlDbType.VarChar, -1);
      mySqlParameter2.Value = (object) model.InstanceID;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@LinkID", MySqlDbType.VarChar, -1);
      mySqlParameter3.Value = (object) model.LinkID;
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter4 = new MySqlParameter("@TableName", MySqlDbType.VarChar, 500);
      mySqlParameter4.Value = (object) model.TableName;
      mySqlParameterArray[index4] = mySqlParameter4;
      int index5 = 4;
      MySqlParameter mySqlParameter5 = new MySqlParameter("@FieldName", MySqlDbType.VarChar, 500);
      mySqlParameter5.Value = (object) model.FieldName;
      mySqlParameterArray[index5] = mySqlParameter5;
      int index6 = 5;
      MySqlParameter mySqlParameter6 = new MySqlParameter("@Value", MySqlDbType.VarChar, 8000);
      mySqlParameter6.Value = (object) model.Value;
      mySqlParameterArray[index6] = mySqlParameter6;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.WorkFlowData model)
    {
      string sql = "UPDATE WorkFlowData SET \r\n\t\t\t\tInstanceID=@InstanceID,LinkID=@LinkID,TableName=@TableName,FieldName=@FieldName,Value=@Value\r\n\t\t\t\tWHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[6];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@InstanceID", MySqlDbType.VarChar, -1);
      mySqlParameter1.Value = (object) model.InstanceID;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@LinkID", MySqlDbType.VarChar, -1);
      mySqlParameter2.Value = (object) model.LinkID;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@TableName", MySqlDbType.VarChar, 500);
      mySqlParameter3.Value = (object) model.TableName;
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter4 = new MySqlParameter("@FieldName", MySqlDbType.VarChar, 500);
      mySqlParameter4.Value = (object) model.FieldName;
      mySqlParameterArray[index4] = mySqlParameter4;
      int index5 = 4;
      MySqlParameter mySqlParameter5 = new MySqlParameter("@Value", MySqlDbType.VarChar, 8000);
      mySqlParameter5.Value = (object) model.Value;
      mySqlParameterArray[index5] = mySqlParameter5;
      int index6 = 5;
      MySqlParameter mySqlParameter6 = new MySqlParameter("@ID", MySqlDbType.VarChar, -1);
      mySqlParameter6.Value = (object) model.ID;
      mySqlParameterArray[index6] = mySqlParameter6;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM WorkFlowData WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.WorkFlowData> DataReaderToList(MySqlDataReader dataReader)
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
      MySqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM WorkFlowData");
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
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkFlowData> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.WorkFlowData) null;
      return list[0];
    }

    public List<RoadFlow.Data.Model.WorkFlowData> GetAll(Guid instanceID)
    {
      string sql = "SELECT * FROM WorkFlowData WHERE InstanceID=@InstanceID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@InstanceID", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) instanceID.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkFlowData> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }
  }
}
