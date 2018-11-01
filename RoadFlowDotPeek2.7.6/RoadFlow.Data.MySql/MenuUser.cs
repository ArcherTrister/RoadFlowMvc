// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MySql.MenuUser
// Assembly: RoadFlow.Data.MySql, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 29B652D7-5F6F-4A7D-AD1C-9F2C643FD784
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.MySql.dll

using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.MySql
{
  public class MenuUser : IMenuUser
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.MenuUser model)
    {
      string sql = "INSERT INTO menuuser\r\n\t\t\t\t(ID,MenuID,SubPageID,Organizes,Users,Buttons,Params) \r\n\t\t\t\tVALUES(@ID,@MenuID,@SubPageID,@Organizes,@Users,@Buttons,@Params)";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[7];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter1.Value = (object) model.ID;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@MenuID", MySqlDbType.VarChar, 36);
      mySqlParameter2.Value = (object) model.MenuID;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@SubPageID", MySqlDbType.VarChar, 36);
      mySqlParameter3.Value = (object) model.SubPageID;
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter4 = new MySqlParameter("@Organizes", MySqlDbType.VarChar, 100);
      mySqlParameter4.Value = (object) model.Organizes;
      mySqlParameterArray[index4] = mySqlParameter4;
      int index5 = 4;
      MySqlParameter mySqlParameter5 = new MySqlParameter("@Users", MySqlDbType.LongText, -1);
      mySqlParameter5.Value = (object) model.Users;
      mySqlParameterArray[index5] = mySqlParameter5;
      int index6 = 5;
      MySqlParameter mySqlParameter6;
      if (model.Buttons != null)
      {
        MySqlParameter mySqlParameter7 = new MySqlParameter("@Buttons", MySqlDbType.LongText, -1);
        mySqlParameter7.Value = (object) model.Buttons;
        mySqlParameter6 = mySqlParameter7;
      }
      else
      {
        mySqlParameter6 = new MySqlParameter("@Buttons", MySqlDbType.LongText, -1);
        mySqlParameter6.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index6] = mySqlParameter6;
      int index7 = 6;
      MySqlParameter mySqlParameter8;
      if (model.Params != null)
      {
        MySqlParameter mySqlParameter7 = new MySqlParameter("@Params", MySqlDbType.LongText, -1);
        mySqlParameter7.Value = (object) model.Params;
        mySqlParameter8 = mySqlParameter7;
      }
      else
      {
        mySqlParameter8 = new MySqlParameter("@Params", MySqlDbType.LongText, -1);
        mySqlParameter8.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index7] = mySqlParameter8;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.MenuUser model)
    {
      string sql = "UPDATE menuuser SET \r\n\t\t\t\tMenuID=@MenuID,SubPageID=@SubPageID,Organizes=@Organizes,Users=@Users,Buttons=@Buttons,Params=@Params\r\n\t\t\t\tWHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[7];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@MenuID", MySqlDbType.VarChar, 36);
      mySqlParameter1.Value = (object) model.MenuID;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@SubPageID", MySqlDbType.VarChar, 36);
      mySqlParameter2.Value = (object) model.SubPageID;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@Organizes", MySqlDbType.VarChar, 100);
      mySqlParameter3.Value = (object) model.Organizes;
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter4 = new MySqlParameter("@Users", MySqlDbType.LongText, -1);
      mySqlParameter4.Value = (object) model.Users;
      mySqlParameterArray[index4] = mySqlParameter4;
      int index5 = 4;
      MySqlParameter mySqlParameter5;
      if (model.Buttons != null)
      {
        MySqlParameter mySqlParameter6 = new MySqlParameter("@Buttons", MySqlDbType.LongText, -1);
        mySqlParameter6.Value = (object) model.Buttons;
        mySqlParameter5 = mySqlParameter6;
      }
      else
      {
        mySqlParameter5 = new MySqlParameter("@Buttons", MySqlDbType.LongText, -1);
        mySqlParameter5.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index5] = mySqlParameter5;
      int index6 = 5;
      MySqlParameter mySqlParameter7;
      if (model.Params != null)
      {
        MySqlParameter mySqlParameter6 = new MySqlParameter("@Params", MySqlDbType.LongText, -1);
        mySqlParameter6.Value = (object) model.Params;
        mySqlParameter7 = mySqlParameter6;
      }
      else
      {
        mySqlParameter7 = new MySqlParameter("@Params", MySqlDbType.LongText, -1);
        mySqlParameter7.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index6] = mySqlParameter7;
      int index7 = 6;
      MySqlParameter mySqlParameter8 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter8.Value = (object) model.ID;
      mySqlParameterArray[index7] = mySqlParameter8;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM menuuser WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.MenuUser> DataReaderToList(MySqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.MenuUser> menuUserList = new List<RoadFlow.Data.Model.MenuUser>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.MenuUser menuUser = new RoadFlow.Data.Model.MenuUser();
        menuUser.ID = dataReader.GetString(0).ToGuid();
        menuUser.MenuID = dataReader.GetString(1).ToGuid();
        menuUser.SubPageID = dataReader.GetString(2).ToGuid();
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
      MySqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM menuuser");
      List<RoadFlow.Data.Model.MenuUser> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM menuuser"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.MenuUser Get(Guid id)
    {
      string sql = "SELECT * FROM menuuser WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.MenuUser> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.MenuUser) null;
      return list[0];
    }

    public int DeleteByOrganizes(string organizes)
    {
      string sql = "DELETE FROM MenuUser WHERE Organizes=@Organizes";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@Organizes", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) organizes;
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int DeleteByMenuID(Guid menuID)
    {
      string sql = "DELETE FROM MenuUser WHERE MenuID=@MenuID";
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
