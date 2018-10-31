// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MSSQL.UserShortcut
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
  public class UserShortcut : IUserShortcut
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.UserShortcut model)
    {
      string sql = "INSERT INTO UserShortcut\r\n\t\t\t\t(ID,MenuID,UserID,Sort) \r\n\t\t\t\tVALUES(@ID,@MenuID,@UserID,@Sort)";
      SqlParameter[] sqlParameterArray = new SqlParameter[4];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter1.Value = (object) model.ID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@MenuID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter2.Value = (object) model.MenuID;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@UserID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter3.Value = (object) model.UserID;
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter4 = new SqlParameter("@Sort", SqlDbType.Int, -1);
      sqlParameter4.Value = (object) model.Sort;
      sqlParameterArray[index4] = sqlParameter4;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.UserShortcut model)
    {
      string sql = "UPDATE UserShortcut SET \r\n\t\t\t\tMenuID=@MenuID,UserID=@UserID,Sort=@Sort\r\n\t\t\t\tWHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[4];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@MenuID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter1.Value = (object) model.MenuID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@UserID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter2.Value = (object) model.UserID;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@Sort", SqlDbType.Int, -1);
      sqlParameter3.Value = (object) model.Sort;
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter4 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter4.Value = (object) model.ID;
      sqlParameterArray[index4] = sqlParameter4;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM UserShortcut WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.UserShortcut> DataReaderToList(SqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.UserShortcut> userShortcutList = new List<RoadFlow.Data.Model.UserShortcut>();
      while (dataReader.Read())
        userShortcutList.Add(new RoadFlow.Data.Model.UserShortcut()
        {
          ID = dataReader.GetGuid(0),
          MenuID = dataReader.GetGuid(1),
          UserID = dataReader.GetGuid(2),
          Sort = dataReader.GetInt32(3)
        });
      return userShortcutList;
    }

    public List<RoadFlow.Data.Model.UserShortcut> GetAll()
    {
      SqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM UserShortcut");
      List<RoadFlow.Data.Model.UserShortcut> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM UserShortcut"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.UserShortcut Get(Guid id)
    {
      string sql = "SELECT * FROM UserShortcut WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.UserShortcut> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.UserShortcut) null;
      return list[0];
    }

    public int DeleteByUserID(Guid userID)
    {
      string sql = "DELETE FROM UserShortcut WHERE UserID=@UserID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@UserID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) userID;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public List<RoadFlow.Data.Model.UserShortcut> GetAllByUserID(Guid userID)
    {
      string sql = "SELECT * FROM UserShortcut WHERE UserID=@UserID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@UserID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) userID;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.UserShortcut> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public DataTable GetDataTableByUserID(Guid userID)
    {
      string sql = "SELECT * FROM UserShortcut WHERE UserID=@UserID ORDER BY Sort";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@UserID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) userID;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.GetDataTable(sql, parameter);
    }

    public int DeleteByMenuID(Guid menuID)
    {
      string sql = "DELETE FROM UserShortcut WHERE MenuID=@MenuID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@MenuID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) menuID;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }
  }
}
