// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.ORACLE.UserShortcut
// Assembly: RoadFlow.Data.ORACLE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C9018AA1-E48E-4231-92A9-CD6F0F275D11
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.ORACLE.dll

using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;
using System.Data;

namespace RoadFlow.Data.ORACLE
{
  public class UserShortcut : IUserShortcut
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.UserShortcut model)
    {
      string sql = "INSERT INTO UserShortcut\r\n\t\t\t\t(ID,MenuID,UserID,Sort) \r\n\t\t\t\tVALUES(:ID,:MenuID,:UserID,:Sort)";
      OracleParameter[] oracleParameterArray = new OracleParameter[4];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter1.Value = (object) model.ID;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":MenuID", OracleDbType.Varchar2);
      oracleParameter2.Value = (object) model.MenuID;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3 = new OracleParameter(":UserID", OracleDbType.Varchar2);
      oracleParameter3.Value = (object) model.UserID;
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter4 = new OracleParameter(":Sort", OracleDbType.Int32);
      oracleParameter4.Value = (object) model.Sort;
      oracleParameterArray[index4] = oracleParameter4;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Update(RoadFlow.Data.Model.UserShortcut model)
    {
      string sql = "UPDATE UserShortcut SET \r\n\t\t\t\tMenuID=:MenuID,UserID=:UserID,Sort=:Sort\r\n\t\t\t\tWHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[4];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":MenuID", OracleDbType.Varchar2);
      oracleParameter1.Value = (object) model.MenuID;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":UserID", OracleDbType.Varchar2);
      oracleParameter2.Value = (object) model.UserID;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3 = new OracleParameter(":Sort", OracleDbType.Int32);
      oracleParameter3.Value = (object) model.Sort;
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter4 = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter4.Value = (object) model.ID;
      oracleParameterArray[index4] = oracleParameter4;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM UserShortcut WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    private List<RoadFlow.Data.Model.UserShortcut> DataReaderToList(OracleDataReader dataReader)
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
      OracleDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM UserShortcut");
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
      string sql = "SELECT * FROM UserShortcut WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.UserShortcut> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.UserShortcut) null;
      return list[0];
    }

    public int DeleteByUserID(Guid userID)
    {
      string sql = "DELETE FROM UserShortcut WHERE UserID=:UserID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":UserID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) userID;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public List<RoadFlow.Data.Model.UserShortcut> GetAllByUserID(Guid userID)
    {
      string sql = "SELECT * FROM UserShortcut WHERE UserID=:UserID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":UserID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) userID;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.UserShortcut> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public DataTable GetDataTableByUserID(Guid userID)
    {
      string sql = "SELECT * FROM UserShortcut WHERE UserID=:UserID ORDER BY Sort";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":UserID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) userID;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.GetDataTable(sql, parameter);
    }

    public int DeleteByMenuID(Guid menuID)
    {
      string sql = "DELETE FROM UserShortcut WHERE MenuID=:MenuID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":MenuID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) menuID.ToString();
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }
  }
}
