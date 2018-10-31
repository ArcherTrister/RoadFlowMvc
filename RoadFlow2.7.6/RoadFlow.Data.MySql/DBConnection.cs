// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MySql.DBConnection
// Assembly: RoadFlow.Data.MySql, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 29B652D7-5F6F-4A7D-AD1C-9F2C643FD784
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.MySql.dll

using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.MySql
{
  public class DBConnection : IDBConnection
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.DBConnection model)
    {
      string sql = "INSERT INTO dbconnection\r\n\t\t\t\t(ID,Name,Type,ConnectionString,Note) \r\n\t\t\t\tVALUES(@ID,@Name,@Type,@ConnectionString,@Note)";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[5];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter1.Value = (object) model.ID;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@Name", MySqlDbType.Text, -1);
      mySqlParameter2.Value = (object) model.Name;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@Type", MySqlDbType.Text, -1);
      mySqlParameter3.Value = (object) model.Type;
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter4 = new MySqlParameter("@ConnectionString", MySqlDbType.LongText, -1);
      mySqlParameter4.Value = (object) model.ConnectionString;
      mySqlParameterArray[index4] = mySqlParameter4;
      int index5 = 4;
      MySqlParameter mySqlParameter5;
      if (model.Note != null)
      {
        MySqlParameter mySqlParameter6 = new MySqlParameter("@Note", MySqlDbType.LongText, -1);
        mySqlParameter6.Value = (object) model.Note;
        mySqlParameter5 = mySqlParameter6;
      }
      else
      {
        mySqlParameter5 = new MySqlParameter("@Note", MySqlDbType.LongText, -1);
        mySqlParameter5.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index5] = mySqlParameter5;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.DBConnection model)
    {
      string sql = "UPDATE dbconnection SET \r\n\t\t\t\tName=@Name,Type=@Type,ConnectionString=@ConnectionString,Note=@Note\r\n\t\t\t\tWHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[5];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@Name", MySqlDbType.Text, -1);
      mySqlParameter1.Value = (object) model.Name;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@Type", MySqlDbType.Text, -1);
      mySqlParameter2.Value = (object) model.Type;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@ConnectionString", MySqlDbType.LongText, -1);
      mySqlParameter3.Value = (object) model.ConnectionString;
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter4;
      if (model.Note != null)
      {
        MySqlParameter mySqlParameter5 = new MySqlParameter("@Note", MySqlDbType.LongText, -1);
        mySqlParameter5.Value = (object) model.Note;
        mySqlParameter4 = mySqlParameter5;
      }
      else
      {
        mySqlParameter4 = new MySqlParameter("@Note", MySqlDbType.LongText, -1);
        mySqlParameter4.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index4] = mySqlParameter4;
      int index5 = 4;
      MySqlParameter mySqlParameter6 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter6.Value = (object) model.ID;
      mySqlParameterArray[index5] = mySqlParameter6;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM dbconnection WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.DBConnection> DataReaderToList(MySqlDataReader dataReader)
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
      MySqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM dbconnection");
      List<RoadFlow.Data.Model.DBConnection> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM dbconnection"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.DBConnection Get(Guid id)
    {
      string sql = "SELECT * FROM dbconnection WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.DBConnection> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.DBConnection) null;
      return list[0];
    }
  }
}
