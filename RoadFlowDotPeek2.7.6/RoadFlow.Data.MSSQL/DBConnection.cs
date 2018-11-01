// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MSSQL.DBConnection
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
  public class DBConnection : IDBConnection
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.DBConnection model)
    {
      string sql = "INSERT INTO DBConnection\r\n\t\t\t\t(ID,Name,Type,ConnectionString,Note) \r\n\t\t\t\tVALUES(@ID,@Name,@Type,@ConnectionString,@Note)";
      SqlParameter[] sqlParameterArray = new SqlParameter[5];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter1.Value = (object) model.ID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@Name", SqlDbType.VarChar, 500);
      sqlParameter2.Value = (object) model.Name;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@Type", SqlDbType.VarChar, 500);
      sqlParameter3.Value = (object) model.Type;
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter4 = new SqlParameter("@ConnectionString", SqlDbType.VarChar, -1);
      sqlParameter4.Value = (object) model.ConnectionString;
      sqlParameterArray[index4] = sqlParameter4;
      int index5 = 4;
      SqlParameter sqlParameter5;
      if (model.Note != null)
      {
        SqlParameter sqlParameter6 = new SqlParameter("@Note", SqlDbType.VarChar, -1);
        sqlParameter6.Value = (object) model.Note;
        sqlParameter5 = sqlParameter6;
      }
      else
      {
        sqlParameter5 = new SqlParameter("@Note", SqlDbType.VarChar, -1);
        sqlParameter5.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index5] = sqlParameter5;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.DBConnection model)
    {
      string sql = "UPDATE DBConnection SET \r\n\t\t\t\tName=@Name,Type=@Type,ConnectionString=@ConnectionString,Note=@Note\r\n\t\t\t\tWHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[5];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@Name", SqlDbType.VarChar, 500);
      sqlParameter1.Value = (object) model.Name;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@Type", SqlDbType.VarChar, 500);
      sqlParameter2.Value = (object) model.Type;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@ConnectionString", SqlDbType.VarChar, -1);
      sqlParameter3.Value = (object) model.ConnectionString;
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter4;
      if (model.Note != null)
      {
        SqlParameter sqlParameter5 = new SqlParameter("@Note", SqlDbType.VarChar, -1);
        sqlParameter5.Value = (object) model.Note;
        sqlParameter4 = sqlParameter5;
      }
      else
      {
        sqlParameter4 = new SqlParameter("@Note", SqlDbType.VarChar, -1);
        sqlParameter4.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index4] = sqlParameter4;
      int index5 = 4;
      SqlParameter sqlParameter6 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter6.Value = (object) model.ID;
      sqlParameterArray[index5] = sqlParameter6;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM DBConnection WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.DBConnection> DataReaderToList(SqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.DBConnection> dbConnectionList = new List<RoadFlow.Data.Model.DBConnection>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.DBConnection dbConnection = new RoadFlow.Data.Model.DBConnection();
        dbConnection.ID = dataReader.GetGuid(0);
        dbConnection.Name = dataReader.GetString(1);
        dbConnection.Type = dataReader.GetString(2);
        dbConnection.ConnectionString = dataReader.GetString(3);
        if (!dataReader.IsDBNull(4))
          dbConnection.Note = dataReader.GetString(4);
        dbConnectionList.Add(dbConnection);
      }
      return dbConnectionList;
    }

    public List<RoadFlow.Data.Model.DBConnection> GetAll()
    {
      SqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM DBConnection");
      List<RoadFlow.Data.Model.DBConnection> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM DBConnection"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.DBConnection Get(Guid id)
    {
      string sql = "SELECT * FROM DBConnection WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.DBConnection> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.DBConnection) null;
      return list[0];
    }
  }
}
