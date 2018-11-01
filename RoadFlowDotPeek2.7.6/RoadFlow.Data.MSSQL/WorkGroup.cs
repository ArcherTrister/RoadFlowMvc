// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MSSQL.WorkGroup
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
  public class WorkGroup : IWorkGroup
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.WorkGroup model)
    {
      string sql = "INSERT INTO WorkGroup\r\n\t\t\t\t(ID,Name,Members,Note,IntID) \r\n\t\t\t\tVALUES(@ID,@Name,@Members,@Note,@IntID)";
      SqlParameter[] sqlParameterArray = new SqlParameter[5];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter1.Value = (object) model.ID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@Name", SqlDbType.NVarChar, 1000);
      sqlParameter2.Value = (object) model.Name;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@Members", SqlDbType.VarChar, -1);
      sqlParameter3.Value = (object) model.Members;
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter4;
      if (model.Note != null)
      {
        SqlParameter sqlParameter5 = new SqlParameter("@Note", SqlDbType.NVarChar, -1);
        sqlParameter5.Value = (object) model.Note;
        sqlParameter4 = sqlParameter5;
      }
      else
      {
        sqlParameter4 = new SqlParameter("@Note", SqlDbType.NVarChar, -1);
        sqlParameter4.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index4] = sqlParameter4;
      int index5 = 4;
      SqlParameter sqlParameter6 = new SqlParameter("@IntID", SqlDbType.Int, -1);
      sqlParameter6.Value = (object) model.IntID;
      sqlParameterArray[index5] = sqlParameter6;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.WorkGroup model)
    {
      string sql = "UPDATE WorkGroup SET \r\n\t\t\t\tName=@Name,Members=@Members,Note=@Note,IntID=@IntID \r\n\t\t\t\tWHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[5];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@Name", SqlDbType.NVarChar, 1000);
      sqlParameter1.Value = (object) model.Name;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@Members", SqlDbType.VarChar, -1);
      sqlParameter2.Value = (object) model.Members;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3;
      if (model.Note != null)
      {
        SqlParameter sqlParameter4 = new SqlParameter("@Note", SqlDbType.NVarChar, -1);
        sqlParameter4.Value = (object) model.Note;
        sqlParameter3 = sqlParameter4;
      }
      else
      {
        sqlParameter3 = new SqlParameter("@Note", SqlDbType.NVarChar, -1);
        sqlParameter3.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter5 = new SqlParameter("@IntID", SqlDbType.Int, -1);
      sqlParameter5.Value = (object) model.IntID;
      sqlParameterArray[index4] = sqlParameter5;
      int index5 = 4;
      SqlParameter sqlParameter6 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter6.Value = (object) model.ID;
      sqlParameterArray[index5] = sqlParameter6;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM WorkGroup WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.WorkGroup> DataReaderToList(SqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.WorkGroup> workGroupList = new List<RoadFlow.Data.Model.WorkGroup>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.WorkGroup workGroup = new RoadFlow.Data.Model.WorkGroup();
        workGroup.ID = dataReader.GetGuid(0);
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
      SqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM WorkGroup");
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
      string sql = "SELECT * FROM WorkGroup WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkGroup> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.WorkGroup) null;
      return list[0];
    }
  }
}
