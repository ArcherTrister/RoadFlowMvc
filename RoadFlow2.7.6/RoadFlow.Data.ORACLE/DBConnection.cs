// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.ORACLE.DBConnection
// Assembly: RoadFlow.Data.ORACLE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C9018AA1-E48E-4231-92A9-CD6F0F275D11
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.ORACLE.dll

using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.ORACLE
{
  public class DBConnection : IDBConnection
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.DBConnection model)
    {
      string sql = "INSERT INTO DBConnection\r\n\t\t\t\t(ID,Name,Type,ConnectionString,Note) \r\n\t\t\t\tVALUES(:ID,:Name,:Type,:ConnectionString,:Note)";
      OracleParameter[] oracleParameterArray = new OracleParameter[5];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":ID", OracleDbType.Varchar2, 40);
      oracleParameter1.Value = (object) model.ID;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":Name", OracleDbType.Varchar2, 500);
      oracleParameter2.Value = (object) model.Name;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3 = new OracleParameter(":Type", OracleDbType.Varchar2, 500);
      oracleParameter3.Value = (object) model.Type;
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter4 = new OracleParameter(":ConnectionString", OracleDbType.Clob);
      oracleParameter4.Value = (object) model.ConnectionString;
      oracleParameterArray[index4] = oracleParameter4;
      int index5 = 4;
      OracleParameter oracleParameter5;
      if (model.Note != null)
      {
        OracleParameter oracleParameter6 = new OracleParameter(":Note", OracleDbType.Clob);
        oracleParameter6.Value = (object) model.Note;
        oracleParameter5 = oracleParameter6;
      }
      else
      {
        oracleParameter5 = new OracleParameter(":Note", OracleDbType.Clob);
        oracleParameter5.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index5] = oracleParameter5;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Update(RoadFlow.Data.Model.DBConnection model)
    {
      string sql = "UPDATE DBConnection SET \r\n\t\t\t\tName=:Name,Type=:Type,ConnectionString=:ConnectionString,Note=:Note\r\n\t\t\t\tWHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[5];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":Name", OracleDbType.Varchar2, 500);
      oracleParameter1.Value = (object) model.Name;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":Type", OracleDbType.Varchar2, 500);
      oracleParameter2.Value = (object) model.Type;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3 = new OracleParameter(":ConnectionString", OracleDbType.Clob);
      oracleParameter3.Value = (object) model.ConnectionString;
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter4;
      if (model.Note != null)
      {
        OracleParameter oracleParameter5 = new OracleParameter(":Note", OracleDbType.Clob);
        oracleParameter5.Value = (object) model.Note;
        oracleParameter4 = oracleParameter5;
      }
      else
      {
        oracleParameter4 = new OracleParameter(":Note", OracleDbType.Clob);
        oracleParameter4.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index4] = oracleParameter4;
      int index5 = 4;
      OracleParameter oracleParameter6 = new OracleParameter(":ID", OracleDbType.Varchar2, 40);
      oracleParameter6.Value = (object) model.ID;
      oracleParameterArray[index5] = oracleParameter6;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM DBConnection WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    private List<RoadFlow.Data.Model.DBConnection> DataReaderToList(OracleDataReader dataReader)
    {
      List<RoadFlow.Data.Model.DBConnection> dbConnectionList = new List<RoadFlow.Data.Model.DBConnection>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.DBConnection dbConnection = new RoadFlow.Data.Model.DBConnection();
        dbConnection.ID = dataReader.GetString(0).ToGuid();
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
      OracleDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM DBConnection");
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
      string sql = "SELECT * FROM DBConnection WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.DBConnection> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.DBConnection) null;
      return list[0];
    }
  }
}
