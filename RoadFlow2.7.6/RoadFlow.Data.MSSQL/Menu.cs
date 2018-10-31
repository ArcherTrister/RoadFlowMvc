// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MSSQL.Menu
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
  public class Menu : IMenu
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.Menu model)
    {
      string sql = "INSERT INTO Menu\r\n\t\t\t\t(ID,ParentID,AppLibraryID,Title,Params,Ico,Sort,IcoColor) \r\n\t\t\t\tVALUES(@ID,@ParentID,@AppLibraryID,@Title,@Params,@Ico,@Sort,@IcoColor)";
      SqlParameter[] sqlParameterArray = new SqlParameter[8];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter1.Value = (object) model.ID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@ParentID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter2.Value = (object) model.ParentID;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3;
      if (model.AppLibraryID.HasValue)
      {
        SqlParameter sqlParameter4 = new SqlParameter("@AppLibraryID", SqlDbType.UniqueIdentifier, -1);
        sqlParameter4.Value = (object) model.AppLibraryID;
        sqlParameter3 = sqlParameter4;
      }
      else
      {
        sqlParameter3 = new SqlParameter("@AppLibraryID", SqlDbType.UniqueIdentifier, -1);
        sqlParameter3.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter5 = new SqlParameter("@Title", SqlDbType.NVarChar, 1000);
      sqlParameter5.Value = (object) model.Title;
      sqlParameterArray[index4] = sqlParameter5;
      int index5 = 4;
      SqlParameter sqlParameter6;
      if (model.Params != null)
      {
        SqlParameter sqlParameter4 = new SqlParameter("@Params", SqlDbType.VarChar, 5000);
        sqlParameter4.Value = (object) model.Params;
        sqlParameter6 = sqlParameter4;
      }
      else
      {
        sqlParameter6 = new SqlParameter("@Params", SqlDbType.VarChar, 5000);
        sqlParameter6.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index5] = sqlParameter6;
      int index6 = 5;
      SqlParameter sqlParameter7;
      if (model.Ico != null)
      {
        SqlParameter sqlParameter4 = new SqlParameter("@Ico", SqlDbType.VarChar, 500);
        sqlParameter4.Value = (object) model.Ico;
        sqlParameter7 = sqlParameter4;
      }
      else
      {
        sqlParameter7 = new SqlParameter("@Ico", SqlDbType.VarChar, 500);
        sqlParameter7.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index6] = sqlParameter7;
      int index7 = 6;
      SqlParameter sqlParameter8 = new SqlParameter("@Sort", SqlDbType.Int, -1);
      sqlParameter8.Value = (object) model.Sort;
      sqlParameterArray[index7] = sqlParameter8;
      int index8 = 7;
      SqlParameter sqlParameter9;
      if (model.IcoColor != null)
      {
        SqlParameter sqlParameter4 = new SqlParameter("@IcoColor", SqlDbType.VarChar, 50);
        sqlParameter4.Value = (object) model.IcoColor;
        sqlParameter9 = sqlParameter4;
      }
      else
      {
        sqlParameter9 = new SqlParameter("@IcoColor", SqlDbType.VarChar, 50);
        sqlParameter9.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index8] = sqlParameter9;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.Menu model)
    {
      string sql = "UPDATE Menu SET \r\n\t\t\t\tParentID=@ParentID,AppLibraryID=@AppLibraryID,Title=@Title,Params=@Params,Ico=@Ico,Sort=@Sort,IcoColor=@IcoColor \r\n\t\t\t\tWHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[8];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@ParentID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter1.Value = (object) model.ParentID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2;
      if (model.AppLibraryID.HasValue)
      {
        SqlParameter sqlParameter3 = new SqlParameter("@AppLibraryID", SqlDbType.UniqueIdentifier, -1);
        sqlParameter3.Value = (object) model.AppLibraryID;
        sqlParameter2 = sqlParameter3;
      }
      else
      {
        sqlParameter2 = new SqlParameter("@AppLibraryID", SqlDbType.UniqueIdentifier, -1);
        sqlParameter2.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter4 = new SqlParameter("@Title", SqlDbType.NVarChar, 1000);
      sqlParameter4.Value = (object) model.Title;
      sqlParameterArray[index3] = sqlParameter4;
      int index4 = 3;
      SqlParameter sqlParameter5;
      if (model.Params != null)
      {
        SqlParameter sqlParameter3 = new SqlParameter("@Params", SqlDbType.VarChar, 5000);
        sqlParameter3.Value = (object) model.Params;
        sqlParameter5 = sqlParameter3;
      }
      else
      {
        sqlParameter5 = new SqlParameter("@Params", SqlDbType.VarChar, 5000);
        sqlParameter5.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index4] = sqlParameter5;
      int index5 = 4;
      SqlParameter sqlParameter6;
      if (model.Ico != null)
      {
        SqlParameter sqlParameter3 = new SqlParameter("@Ico", SqlDbType.VarChar, 500);
        sqlParameter3.Value = (object) model.Ico;
        sqlParameter6 = sqlParameter3;
      }
      else
      {
        sqlParameter6 = new SqlParameter("@Ico", SqlDbType.VarChar, 500);
        sqlParameter6.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index5] = sqlParameter6;
      int index6 = 5;
      SqlParameter sqlParameter7 = new SqlParameter("@Sort", SqlDbType.Int, -1);
      sqlParameter7.Value = (object) model.Sort;
      sqlParameterArray[index6] = sqlParameter7;
      int index7 = 6;
      SqlParameter sqlParameter8;
      if (model.IcoColor != null)
      {
        SqlParameter sqlParameter3 = new SqlParameter("@IcoColor", SqlDbType.VarChar, 50);
        sqlParameter3.Value = (object) model.IcoColor;
        sqlParameter8 = sqlParameter3;
      }
      else
      {
        sqlParameter8 = new SqlParameter("@IcoColor", SqlDbType.VarChar, 50);
        sqlParameter8.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index7] = sqlParameter8;
      int index8 = 7;
      SqlParameter sqlParameter9 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter9.Value = (object) model.ID;
      sqlParameterArray[index8] = sqlParameter9;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM Menu WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.Menu> DataReaderToList(SqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.Menu> menuList = new List<RoadFlow.Data.Model.Menu>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.Menu menu = new RoadFlow.Data.Model.Menu();
        menu.ID = dataReader.GetGuid(0);
        menu.ParentID = dataReader.GetGuid(1);
        if (!dataReader.IsDBNull(2))
          menu.AppLibraryID = new Guid?(dataReader.GetGuid(2));
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
      SqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM Menu");
      List<RoadFlow.Data.Model.Menu> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM Menu"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.Menu Get(Guid id)
    {
      string sql = "SELECT * FROM Menu WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
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
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ParentID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.Menu> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public bool HasChild(Guid id)
    {
      string sql = "SELECT TOP 1 ID FROM Menu WHERE ParentID=@ParentID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ParentID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      bool hasRows = dataReader.HasRows;
      dataReader.Close();
      return hasRows;
    }

    public int UpdateSort(Guid id, int sort)
    {
      string sql = "UPDATE Menu SET Sort=@Sort WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[2];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@Sort", SqlDbType.Int);
      sqlParameter1.Value = (object) sort;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter2.Value = (object) id;
      sqlParameterArray[index2] = sqlParameter2;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int GetMaxSort(Guid id)
    {
      string sql = "SELECT ISNULL(MAX(Sort),0)+1 FROM Menu WHERE ParentID=@ParentID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ParentID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      int test;
      if (!this.dbHelper.GetFieldValue(sql, parameter).IsInt(out test))
        return 1;
      return test;
    }

    public List<RoadFlow.Data.Model.Menu> GetAllByApplibaryID(Guid applibaryID)
    {
      string sql = "SELECT * FROM Menu WHERE AppLibraryID=@AppLibraryID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@AppLibraryID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) applibaryID;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.Menu> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }
  }
}
