// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MySql.Menu
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
  public class Menu : IMenu
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.Menu model)
    {
      string sql = "INSERT INTO menu\r\n\t\t\t\t(ID,ParentID,AppLibraryID,Title,Params,Ico,Sort,IcoColor) \r\n\t\t\t\tVALUES(@ID,@ParentID,@AppLibraryID,@Title,@Params,@Ico,@Sort,@IcoColor)";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[8];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter1.Value = (object) model.ID;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@ParentID", MySqlDbType.VarChar, 36);
      mySqlParameter2.Value = (object) model.ParentID;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3;
      if (model.AppLibraryID.HasValue)
      {
        MySqlParameter mySqlParameter4 = new MySqlParameter("@AppLibraryID", MySqlDbType.VarChar, 36);
        mySqlParameter4.Value = (object) model.AppLibraryID;
        mySqlParameter3 = mySqlParameter4;
      }
      else
      {
        mySqlParameter3 = new MySqlParameter("@AppLibraryID", MySqlDbType.VarChar, 36);
        mySqlParameter3.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter5 = new MySqlParameter("@Title", MySqlDbType.Text, -1);
      mySqlParameter5.Value = (object) model.Title;
      mySqlParameterArray[index4] = mySqlParameter5;
      int index5 = 4;
      MySqlParameter mySqlParameter6;
      if (model.Params != null)
      {
        MySqlParameter mySqlParameter4 = new MySqlParameter("@Params", MySqlDbType.Text, -1);
        mySqlParameter4.Value = (object) model.Params;
        mySqlParameter6 = mySqlParameter4;
      }
      else
      {
        mySqlParameter6 = new MySqlParameter("@Params", MySqlDbType.Text, -1);
        mySqlParameter6.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index5] = mySqlParameter6;
      int index6 = 5;
      MySqlParameter mySqlParameter7;
      if (model.Ico != null)
      {
        MySqlParameter mySqlParameter4 = new MySqlParameter("@Ico", MySqlDbType.Text, -1);
        mySqlParameter4.Value = (object) model.Ico;
        mySqlParameter7 = mySqlParameter4;
      }
      else
      {
        mySqlParameter7 = new MySqlParameter("@Ico", MySqlDbType.Text, -1);
        mySqlParameter7.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index6] = mySqlParameter7;
      int index7 = 6;
      MySqlParameter mySqlParameter8 = new MySqlParameter("@Sort", MySqlDbType.Int32, 11);
      mySqlParameter8.Value = (object) model.Sort;
      mySqlParameterArray[index7] = mySqlParameter8;
      int index8 = 7;
      MySqlParameter mySqlParameter9;
      if (model.IcoColor != null)
      {
        MySqlParameter mySqlParameter4 = new MySqlParameter("@IcoColor", MySqlDbType.VarChar, 50);
        mySqlParameter4.Value = (object) model.IcoColor;
        mySqlParameter9 = mySqlParameter4;
      }
      else
      {
        mySqlParameter9 = new MySqlParameter("@IcoColor", MySqlDbType.VarChar, 50);
        mySqlParameter9.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index8] = mySqlParameter9;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.Menu model)
    {
      string sql = "UPDATE menu SET \r\n\t\t\t\tParentID=@ParentID,AppLibraryID=@AppLibraryID,Title=@Title,Params=@Params,Ico=@Ico,Sort=@Sort,IcoColor=@IcoColor \r\n\t\t\t\tWHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[8];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@ParentID", MySqlDbType.VarChar, 36);
      mySqlParameter1.Value = (object) model.ParentID;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2;
      if (model.AppLibraryID.HasValue)
      {
        MySqlParameter mySqlParameter3 = new MySqlParameter("@AppLibraryID", MySqlDbType.VarChar, 36);
        mySqlParameter3.Value = (object) model.AppLibraryID;
        mySqlParameter2 = mySqlParameter3;
      }
      else
      {
        mySqlParameter2 = new MySqlParameter("@AppLibraryID", MySqlDbType.VarChar, 36);
        mySqlParameter2.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter4 = new MySqlParameter("@Title", MySqlDbType.Text, -1);
      mySqlParameter4.Value = (object) model.Title;
      mySqlParameterArray[index3] = mySqlParameter4;
      int index4 = 3;
      MySqlParameter mySqlParameter5;
      if (model.Params != null)
      {
        MySqlParameter mySqlParameter3 = new MySqlParameter("@Params", MySqlDbType.Text, -1);
        mySqlParameter3.Value = (object) model.Params;
        mySqlParameter5 = mySqlParameter3;
      }
      else
      {
        mySqlParameter5 = new MySqlParameter("@Params", MySqlDbType.Text, -1);
        mySqlParameter5.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index4] = mySqlParameter5;
      int index5 = 4;
      MySqlParameter mySqlParameter6;
      if (model.Ico != null)
      {
        MySqlParameter mySqlParameter3 = new MySqlParameter("@Ico", MySqlDbType.Text, -1);
        mySqlParameter3.Value = (object) model.Ico;
        mySqlParameter6 = mySqlParameter3;
      }
      else
      {
        mySqlParameter6 = new MySqlParameter("@Ico", MySqlDbType.Text, -1);
        mySqlParameter6.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index5] = mySqlParameter6;
      int index6 = 5;
      MySqlParameter mySqlParameter7 = new MySqlParameter("@Sort", MySqlDbType.Int32, 11);
      mySqlParameter7.Value = (object) model.Sort;
      mySqlParameterArray[index6] = mySqlParameter7;
      int index7 = 6;
      MySqlParameter mySqlParameter8;
      if (model.IcoColor != null)
      {
        MySqlParameter mySqlParameter3 = new MySqlParameter("@IcoColor", MySqlDbType.VarChar, 50);
        mySqlParameter3.Value = (object) model.IcoColor;
        mySqlParameter8 = mySqlParameter3;
      }
      else
      {
        mySqlParameter8 = new MySqlParameter("@IcoColor", MySqlDbType.VarChar, 50);
        mySqlParameter8.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index7] = mySqlParameter8;
      int index8 = 7;
      MySqlParameter mySqlParameter9 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter9.Value = (object) model.ID;
      mySqlParameterArray[index8] = mySqlParameter9;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM menu WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.Menu> DataReaderToList(MySqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.Menu> menuList = new List<RoadFlow.Data.Model.Menu>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.Menu menu = new RoadFlow.Data.Model.Menu();
        menu.ID = dataReader.GetString(0).ToGuid();
        menu.ParentID = dataReader.GetString(1).ToGuid();
        if (!dataReader.IsDBNull(2))
          menu.AppLibraryID = new Guid?(dataReader.GetString(2).ToGuid());
        menu.Title = dataReader.GetString(3);
        if (!dataReader.IsDBNull(4))
          menu.Params = dataReader.GetString(4);
        if (!dataReader.IsDBNull(5))
          menu.Ico = dataReader.GetString(5);
        menu.Sort = dataReader.GetInt32(6);
        if (!dataReader.IsDBNull(7))
          menu.IcoColor = dataReader.GetString(7);
        menuList.Add(menu);
      }
      return menuList;
    }

    public List<RoadFlow.Data.Model.Menu> GetAll()
    {
      MySqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM menu");
      List<RoadFlow.Data.Model.Menu> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM menu"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.Menu Get(Guid id)
    {
      string sql = "SELECT * FROM menu WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.Menu> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.Menu) null;
      return list[0];
    }

    public DataTable GetAllDataTable()
    {
      return this.dbHelper.GetDataTable("SELECT a.*,b.Address,b.OpenMode,b.Width,b.Height,b.Params AS Params1,b.Ico AS AppIco,b.Color AS IcoColor1 FROM Menu a LEFT JOIN AppLibrary b ON a.AppLibraryID=b.ID ORDER BY a.Sort");
    }

    public List<RoadFlow.Data.Model.Menu> GetChild(Guid id)
    {
      string sql = "SELECT * FROM Menu WHERE ParentID=@ParentID ORDER BY Sort";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ParentID", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) id;
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.Menu> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public bool HasChild(Guid id)
    {
      string sql = "SELECT ID FROM Menu WHERE ParentID=@ParentID LIMIT 0,1";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ParentID", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) id;
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      bool hasRows = dataReader.HasRows;
      dataReader.Close();
      return hasRows;
    }

    public int UpdateSort(Guid id, int sort)
    {
      string sql = "UPDATE Menu SET Sort=@Sort WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[2];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@Sort", MySqlDbType.Int32);
      mySqlParameter1.Value = (object) sort;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@ID", MySqlDbType.VarChar);
      mySqlParameter2.Value = (object) id;
      mySqlParameterArray[index2] = mySqlParameter2;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int GetMaxSort(Guid id)
    {
      string sql = "SELECT IFNULL(MAX(Sort),0)+1 FROM Menu WHERE ParentID=@ParentID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ParentID", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) id;
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      int test;
      if (!this.dbHelper.GetFieldValue(sql, parameter).IsInt(out test))
        return 1;
      return test;
    }

    public List<RoadFlow.Data.Model.Menu> GetAllByApplibaryID(Guid applibaryID)
    {
      string sql = "SELECT * FROM Menu WHERE AppLibraryID=@AppLibraryID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@AppLibraryID", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) applibaryID.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.Menu> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }
  }
}
