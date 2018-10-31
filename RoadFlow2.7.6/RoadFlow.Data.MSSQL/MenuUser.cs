// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MSSQL.MenuUser
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
  public class MenuUser : IMenuUser
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.MenuUser model)
    {
      string sql = "INSERT INTO MenuUser\r\n\t\t\t\t(ID,MenuID,SubPageID,Organizes,Users,Buttons,Params) \r\n\t\t\t\tVALUES(@ID,@MenuID,@SubPageID,@Organizes,@Users,@Buttons,@Params)";
      SqlParameter[] sqlParameterArray = new SqlParameter[7];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter1.Value = (object) model.ID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@MenuID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter2.Value = (object) model.MenuID;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@SubPageID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter3.Value = (object) model.SubPageID;
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter4 = new SqlParameter("@Organizes", SqlDbType.VarChar, 100);
      sqlParameter4.Value = (object) model.Organizes;
      sqlParameterArray[index4] = sqlParameter4;
      int index5 = 4;
      SqlParameter sqlParameter5 = new SqlParameter("@Users", SqlDbType.VarChar, -1);
      sqlParameter5.Value = (object) model.Users;
      sqlParameterArray[index5] = sqlParameter5;
      int index6 = 5;
      SqlParameter sqlParameter6;
      if (model.Buttons != null)
      {
        SqlParameter sqlParameter7 = new SqlParameter("@Buttons", SqlDbType.VarChar, -1);
        sqlParameter7.Value = (object) model.Buttons;
        sqlParameter6 = sqlParameter7;
      }
      else
      {
        sqlParameter6 = new SqlParameter("@Buttons", SqlDbType.VarChar, -1);
        sqlParameter6.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index6] = sqlParameter6;
      int index7 = 6;
      SqlParameter sqlParameter8;
      if (model.Params != null)
      {
        SqlParameter sqlParameter7 = new SqlParameter("@Params", SqlDbType.VarChar, -1);
        sqlParameter7.Value = (object) model.Params;
        sqlParameter8 = sqlParameter7;
      }
      else
      {
        sqlParameter8 = new SqlParameter("@Params", SqlDbType.VarChar, -1);
        sqlParameter8.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index7] = sqlParameter8;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.MenuUser model)
    {
      string sql = "UPDATE MenuUser SET \r\n\t\t\t\tMenuID=@MenuID,SubPageID=@SubPageID,Organizes=@Organizes,Users=@Users,Buttons=@Buttons,Params=@Params\r\n\t\t\t\tWHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[7];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@MenuID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter1.Value = (object) model.MenuID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@SubPageID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter2.Value = (object) model.SubPageID;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@Organizes", SqlDbType.VarChar, 100);
      sqlParameter3.Value = (object) model.Organizes;
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter4 = new SqlParameter("@Users", SqlDbType.VarChar, -1);
      sqlParameter4.Value = (object) model.Users;
      sqlParameterArray[index4] = sqlParameter4;
      int index5 = 4;
      SqlParameter sqlParameter5;
      if (model.Buttons != null)
      {
        SqlParameter sqlParameter6 = new SqlParameter("@Buttons", SqlDbType.VarChar, -1);
        sqlParameter6.Value = (object) model.Buttons;
        sqlParameter5 = sqlParameter6;
      }
      else
      {
        sqlParameter5 = new SqlParameter("@Buttons", SqlDbType.VarChar, -1);
        sqlParameter5.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index5] = sqlParameter5;
      int index6 = 5;
      SqlParameter sqlParameter7;
      if (model.Params != null)
      {
        SqlParameter sqlParameter6 = new SqlParameter("@Params", SqlDbType.VarChar, -1);
        sqlParameter6.Value = (object) model.Params;
        sqlParameter7 = sqlParameter6;
      }
      else
      {
        sqlParameter7 = new SqlParameter("@Params", SqlDbType.VarChar, -1);
        sqlParameter7.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index6] = sqlParameter7;
      int index7 = 6;
      SqlParameter sqlParameter8 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter8.Value = (object) model.ID;
      sqlParameterArray[index7] = sqlParameter8;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM MenuUser WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.MenuUser> DataReaderToList(SqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.MenuUser> menuUserList = new List<RoadFlow.Data.Model.MenuUser>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.MenuUser menuUser = new RoadFlow.Data.Model.MenuUser();
        menuUser.ID = dataReader.GetGuid(0);
        menuUser.MenuID = dataReader.GetGuid(1);
        menuUser.SubPageID = dataReader.GetGuid(2);
        menuUser.Organizes = dataReader.GetString(3);
        menuUser.Users = dataReader.GetString(4);
        if (!dataReader.IsDBNull(5))
          menuUser.Buttons = dataReader.GetString(5);
        if (!dataReader.IsDBNull(6))
          menuUser.Params = dataReader.GetString(6);
        menuUserList.Add(menuUser);
      }
      return menuUserList;
    }

    public List<RoadFlow.Data.Model.MenuUser> GetAll()
    {
      SqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM MenuUser");
      List<RoadFlow.Data.Model.MenuUser> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM MenuUser"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.MenuUser Get(Guid id)
    {
      string sql = "SELECT * FROM MenuUser WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.MenuUser> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.MenuUser) null;
      return list[0];
    }

    public int DeleteByOrganizes(string organizes)
    {
      string sql = "DELETE FROM MenuUser WHERE Organizes=@Organizes";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@Organizes", SqlDbType.VarChar);
      sqlParameter.Value = (object) organizes;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int DeleteByMenuID(Guid menuID)
    {
      string sql = "DELETE FROM MenuUser WHERE MenuID=@MenuID";
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
