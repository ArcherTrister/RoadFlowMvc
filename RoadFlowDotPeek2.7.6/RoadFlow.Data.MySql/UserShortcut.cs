// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MySql.UserShortcut
// Assembly: RoadFlow.Data.MySql, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 29B652D7-5F6F-4A7D-AD1C-9F2C643FD784
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.MySql.dll

using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;
using System.Data;

namespace RoadFlow.Data.MySql
{
  public class UserShortcut : IUserShortcut
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.UserShortcut model)
    {
      string sql = "INSERT INTO usershortcut\r\n\t\t\t\t(ID,MenuID,UserID,Sort) \r\n\t\t\t\tVALUES(@ID,@MenuID,@UserID,@Sort)";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[4];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter1.Value = (object) model.ID;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@MenuID", MySqlDbType.VarChar, 36);
      mySqlParameter2.Value = (object) model.MenuID;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@UserID", MySqlDbType.VarChar, 36);
      mySqlParameter3.Value = (object) model.UserID;
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter4 = new MySqlParameter("@Sort", MySqlDbType.Int32, 11);
      mySqlParameter4.Value = (object) model.Sort;
      mySqlParameterArray[index4] = mySqlParameter4;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.UserShortcut model)
    {
      string sql = "UPDATE usershortcut SET \r\n\t\t\t\tMenuID=@MenuID,UserID=@UserID,Sort=@Sort\r\n\t\t\t\tWHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[4];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@MenuID", MySqlDbType.VarChar, 36);
      mySqlParameter1.Value = (object) model.MenuID;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@UserID", MySqlDbType.VarChar, 36);
      mySqlParameter2.Value = (object) model.UserID;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@Sort", MySqlDbType.Int32, 11);
      mySqlParameter3.Value = (object) model.Sort;
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter4 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter4.Value = (object) model.ID;
      mySqlParameterArray[index4] = mySqlParameter4;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM usershortcut WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.UserShortcut> DataReaderToList(MySqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.UserShortcut> userShortcutList = new List<RoadFlow.Data.Model.UserShortcut>();
      while (dataReader.Read())
        userShortcutList.Add(new RoadFlow.Data.Model.UserShortcut()
        {
          ID = dataReader.GetString(0).ToGuid(),
          MenuID = dataReader.GetString(1).ToGuid(),
          UserID = dataReader.GetString(2).ToGuid(),
          Sort = dataReader.GetInt32(3)
        });
      return userShortcutList;
    }

    public List<RoadFlow.Data.Model.UserShortcut> GetAll()
    {
      MySqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM usershortcut");
      List<RoadFlow.Data.Model.UserShortcut> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM usershortcut"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.UserShortcut Get(Guid id)
    {
      string sql = "SELECT * FROM usershortcut WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.UserShortcut> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.UserShortcut) null;
      return list[0];
    }

    public int DeleteByUserID(Guid userID)
    {
      string sql = "DELETE FROM UserShortcut WHERE UserID=@UserID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@UserID", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) userID.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public List<RoadFlow.Data.Model.UserShortcut> GetAllByUserID(Guid userID)
    {
      string sql = "SELECT * FROM UserShortcut WHERE UserID=@UserID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@UserID", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) userID.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.UserShortcut> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public DataTable GetDataTableByUserID(Guid userID)
    {
      string sql = "SELECT * FROM UserShortcut WHERE UserID=@UserID ORDER BY Sort";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@UserID", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) userID.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.GetDataTable(sql, parameter);
    }

    public int DeleteByMenuID(Guid menuID)
    {
      string sql = "DELETE FROM UserShortcut WHERE MenuID=@MenuID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@MenuID", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) menuID.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }
  }
}
