// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MSSQL.HomeItems
// Assembly: RoadFlow.Data.MSSQL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5107CDC7-8F84-4EE0-AC6D-E80FE4695340
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.MSSQL.dll

using RoadFlow.Data.Interface;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RoadFlow.Data.MSSQL
{
  public class HomeItems : IHomeItems
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.HomeItems model)
    {
      string sql = "INSERT INTO HomeItems\r\n\t\t\t\t(ID,Type,Name,Title,DataSourceType,DataSource,Ico,BgColor,Color,DBConnID,LinkURL,UseOrganizes,UseUsers,Sort,Note) \r\n\t\t\t\tVALUES(@ID,@Type,@Name,@Title,@DataSourceType,@DataSource,@Ico,@BgColor,@Color,@DBConnID,@LinkURL,@UseOrganizes,@UseUsers,@Sort,@Note)";
      SqlParameter[] sqlParameterArray = new SqlParameter[15];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter1.Value = (object) model.ID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@Type", SqlDbType.Int, -1);
      sqlParameter2.Value = (object) model.Type;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@Name", SqlDbType.NVarChar, 1000);
      sqlParameter3.Value = (object) model.Name;
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter4 = new SqlParameter("@Title", SqlDbType.NVarChar, 1000);
      sqlParameter4.Value = (object) model.Title;
      sqlParameterArray[index4] = sqlParameter4;
      int index5 = 4;
      SqlParameter sqlParameter5 = new SqlParameter("@DataSourceType", SqlDbType.Int, -1);
      sqlParameter5.Value = (object) model.DataSourceType;
      sqlParameterArray[index5] = sqlParameter5;
      int index6 = 5;
      SqlParameter sqlParameter6;
      if (model.DataSource != null)
      {
        SqlParameter sqlParameter7 = new SqlParameter("@DataSource", SqlDbType.VarChar, -1);
        sqlParameter7.Value = (object) model.DataSource;
        sqlParameter6 = sqlParameter7;
      }
      else
      {
        sqlParameter6 = new SqlParameter("@DataSource", SqlDbType.VarChar, -1);
        sqlParameter6.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index6] = sqlParameter6;
      int index7 = 6;
      SqlParameter sqlParameter8;
      if (model.Ico != null)
      {
        SqlParameter sqlParameter7 = new SqlParameter("@Ico", SqlDbType.VarChar, 2000);
        sqlParameter7.Value = (object) model.Ico;
        sqlParameter8 = sqlParameter7;
      }
      else
      {
        sqlParameter8 = new SqlParameter("@Ico", SqlDbType.VarChar, 2000);
        sqlParameter8.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index7] = sqlParameter8;
      int index8 = 7;
      SqlParameter sqlParameter9;
      if (model.BgColor != null)
      {
        SqlParameter sqlParameter7 = new SqlParameter("@BgColor", SqlDbType.VarChar, 50);
        sqlParameter7.Value = (object) model.BgColor;
        sqlParameter9 = sqlParameter7;
      }
      else
      {
        sqlParameter9 = new SqlParameter("@BgColor", SqlDbType.VarChar, 50);
        sqlParameter9.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index8] = sqlParameter9;
      int index9 = 8;
      SqlParameter sqlParameter10;
      if (model.Color != null)
      {
        SqlParameter sqlParameter7 = new SqlParameter("@Color", SqlDbType.VarChar, 50);
        sqlParameter7.Value = (object) model.Color;
        sqlParameter10 = sqlParameter7;
      }
      else
      {
        sqlParameter10 = new SqlParameter("@Color", SqlDbType.VarChar, 50);
        sqlParameter10.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index9] = sqlParameter10;
      int index10 = 9;
      SqlParameter sqlParameter11;
      if (model.DBConnID.HasValue)
      {
        SqlParameter sqlParameter7 = new SqlParameter("@DBConnID", SqlDbType.UniqueIdentifier, -1);
        sqlParameter7.Value = (object) model.DBConnID;
        sqlParameter11 = sqlParameter7;
      }
      else
      {
        sqlParameter11 = new SqlParameter("@DBConnID", SqlDbType.UniqueIdentifier, -1);
        sqlParameter11.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index10] = sqlParameter11;
      int index11 = 10;
      SqlParameter sqlParameter12;
      if (model.LinkURL != null)
      {
        SqlParameter sqlParameter7 = new SqlParameter("@LinkURL", SqlDbType.VarChar, 2000);
        sqlParameter7.Value = (object) model.LinkURL;
        sqlParameter12 = sqlParameter7;
      }
      else
      {
        sqlParameter12 = new SqlParameter("@LinkURL", SqlDbType.VarChar, 2000);
        sqlParameter12.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index11] = sqlParameter12;
      int index12 = 11;
      SqlParameter sqlParameter13;
      if (model.UseOrganizes != null)
      {
        SqlParameter sqlParameter7 = new SqlParameter("@UseOrganizes", SqlDbType.VarChar, -1);
        sqlParameter7.Value = (object) model.UseOrganizes;
        sqlParameter13 = sqlParameter7;
      }
      else
      {
        sqlParameter13 = new SqlParameter("@UseOrganizes", SqlDbType.VarChar, -1);
        sqlParameter13.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index12] = sqlParameter13;
      int index13 = 12;
      SqlParameter sqlParameter14;
      if (model.UseUsers != null)
      {
        SqlParameter sqlParameter7 = new SqlParameter("@UseUsers", SqlDbType.VarChar, -1);
        sqlParameter7.Value = (object) model.UseUsers;
        sqlParameter14 = sqlParameter7;
      }
      else
      {
        sqlParameter14 = new SqlParameter("@UseUsers", SqlDbType.VarChar, -1);
        sqlParameter14.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index13] = sqlParameter14;
      int index14 = 13;
      SqlParameter sqlParameter15;
      if (model.Sort.HasValue)
      {
        SqlParameter sqlParameter7 = new SqlParameter("@Sort", SqlDbType.Int, -1);
        sqlParameter7.Value = (object) model.Sort;
        sqlParameter15 = sqlParameter7;
      }
      else
      {
        sqlParameter15 = new SqlParameter("@Sort", SqlDbType.Int, -1);
        sqlParameter15.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index14] = sqlParameter15;
      int index15 = 14;
      SqlParameter sqlParameter16;
      if (model.Note != null)
      {
        SqlParameter sqlParameter7 = new SqlParameter("@Note", SqlDbType.NVarChar, 4000);
        sqlParameter7.Value = (object) model.Note;
        sqlParameter16 = sqlParameter7;
      }
      else
      {
        sqlParameter16 = new SqlParameter("@Note", SqlDbType.NVarChar, 4000);
        sqlParameter16.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index15] = sqlParameter16;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.HomeItems model)
    {
      string sql = "UPDATE HomeItems SET \r\n\t\t\t\tType=@Type,Name=@Name,Title=@Title,DataSourceType=@DataSourceType,DataSource=@DataSource,Ico=@Ico,BgColor=@BgColor,Color=@Color,DBConnID=@DBConnID,LinkURL=@LinkURL,UseOrganizes=@UseOrganizes,UseUsers=@UseUsers,Sort=@Sort,Note=@Note\r\n\t\t\t\tWHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[15];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@Type", SqlDbType.Int, -1);
      sqlParameter1.Value = (object) model.Type;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@Name", SqlDbType.NVarChar, 1000);
      sqlParameter2.Value = (object) model.Name;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@Title", SqlDbType.NVarChar, 1000);
      sqlParameter3.Value = (object) model.Title;
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter4 = new SqlParameter("@DataSourceType", SqlDbType.Int, -1);
      sqlParameter4.Value = (object) model.DataSourceType;
      sqlParameterArray[index4] = sqlParameter4;
      int index5 = 4;
      SqlParameter sqlParameter5;
      if (model.DataSource != null)
      {
        SqlParameter sqlParameter6 = new SqlParameter("@DataSource", SqlDbType.VarChar, -1);
        sqlParameter6.Value = (object) model.DataSource;
        sqlParameter5 = sqlParameter6;
      }
      else
      {
        sqlParameter5 = new SqlParameter("@DataSource", SqlDbType.VarChar, -1);
        sqlParameter5.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index5] = sqlParameter5;
      int index6 = 5;
      SqlParameter sqlParameter7;
      if (model.Ico != null)
      {
        SqlParameter sqlParameter6 = new SqlParameter("@Ico", SqlDbType.VarChar, 2000);
        sqlParameter6.Value = (object) model.Ico;
        sqlParameter7 = sqlParameter6;
      }
      else
      {
        sqlParameter7 = new SqlParameter("@Ico", SqlDbType.VarChar, 2000);
        sqlParameter7.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index6] = sqlParameter7;
      int index7 = 6;
      SqlParameter sqlParameter8;
      if (model.BgColor != null)
      {
        SqlParameter sqlParameter6 = new SqlParameter("@BgColor", SqlDbType.VarChar, 50);
        sqlParameter6.Value = (object) model.BgColor;
        sqlParameter8 = sqlParameter6;
      }
      else
      {
        sqlParameter8 = new SqlParameter("@BgColor", SqlDbType.VarChar, 50);
        sqlParameter8.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index7] = sqlParameter8;
      int index8 = 7;
      SqlParameter sqlParameter9;
      if (model.Color != null)
      {
        SqlParameter sqlParameter6 = new SqlParameter("@Color", SqlDbType.VarChar, 50);
        sqlParameter6.Value = (object) model.Color;
        sqlParameter9 = sqlParameter6;
      }
      else
      {
        sqlParameter9 = new SqlParameter("@Color", SqlDbType.VarChar, 50);
        sqlParameter9.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index8] = sqlParameter9;
      int index9 = 8;
      SqlParameter sqlParameter10;
      if (model.DBConnID.HasValue)
      {
        SqlParameter sqlParameter6 = new SqlParameter("@DBConnID", SqlDbType.UniqueIdentifier, -1);
        sqlParameter6.Value = (object) model.DBConnID;
        sqlParameter10 = sqlParameter6;
      }
      else
      {
        sqlParameter10 = new SqlParameter("@DBConnID", SqlDbType.UniqueIdentifier, -1);
        sqlParameter10.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index9] = sqlParameter10;
      int index10 = 9;
      SqlParameter sqlParameter11;
      if (model.LinkURL != null)
      {
        SqlParameter sqlParameter6 = new SqlParameter("@LinkURL", SqlDbType.VarChar, 2000);
        sqlParameter6.Value = (object) model.LinkURL;
        sqlParameter11 = sqlParameter6;
      }
      else
      {
        sqlParameter11 = new SqlParameter("@LinkURL", SqlDbType.VarChar, 2000);
        sqlParameter11.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index10] = sqlParameter11;
      int index11 = 10;
      SqlParameter sqlParameter12;
      if (model.UseOrganizes != null)
      {
        SqlParameter sqlParameter6 = new SqlParameter("@UseOrganizes", SqlDbType.VarChar, -1);
        sqlParameter6.Value = (object) model.UseOrganizes;
        sqlParameter12 = sqlParameter6;
      }
      else
      {
        sqlParameter12 = new SqlParameter("@UseOrganizes", SqlDbType.VarChar, -1);
        sqlParameter12.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index11] = sqlParameter12;
      int index12 = 11;
      SqlParameter sqlParameter13;
      if (model.UseUsers != null)
      {
        SqlParameter sqlParameter6 = new SqlParameter("@UseUsers", SqlDbType.VarChar, -1);
        sqlParameter6.Value = (object) model.UseUsers;
        sqlParameter13 = sqlParameter6;
      }
      else
      {
        sqlParameter13 = new SqlParameter("@UseUsers", SqlDbType.VarChar, -1);
        sqlParameter13.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index12] = sqlParameter13;
      int index13 = 12;
      SqlParameter sqlParameter14;
      if (model.Sort.HasValue)
      {
        SqlParameter sqlParameter6 = new SqlParameter("@Sort", SqlDbType.Int, -1);
        sqlParameter6.Value = (object) model.Sort;
        sqlParameter14 = sqlParameter6;
      }
      else
      {
        sqlParameter14 = new SqlParameter("@Sort", SqlDbType.Int, -1);
        sqlParameter14.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index13] = sqlParameter14;
      int index14 = 13;
      SqlParameter sqlParameter15;
      if (model.Note != null)
      {
        SqlParameter sqlParameter6 = new SqlParameter("@Note", SqlDbType.NVarChar, 4000);
        sqlParameter6.Value = (object) model.Note;
        sqlParameter15 = sqlParameter6;
      }
      else
      {
        sqlParameter15 = new SqlParameter("@Note", SqlDbType.NVarChar, 4000);
        sqlParameter15.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index14] = sqlParameter15;
      int index15 = 14;
      SqlParameter sqlParameter16 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter16.Value = (object) model.ID;
      sqlParameterArray[index15] = sqlParameter16;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM HomeItems WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.HomeItems> DataReaderToList(SqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.HomeItems> homeItemsList = new List<RoadFlow.Data.Model.HomeItems>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.HomeItems homeItems = new RoadFlow.Data.Model.HomeItems();
        homeItems.ID = dataReader.GetGuid(0);
        homeItems.Type = dataReader.GetInt32(1);
        homeItems.Name = dataReader.GetString(2);
        homeItems.Title = dataReader.GetString(3);
        homeItems.DataSourceType = dataReader.GetInt32(4);
        if (!dataReader.IsDBNull(5))
          homeItems.DataSource = dataReader.GetString(5);
        if (!dataReader.IsDBNull(6))
          homeItems.Ico = dataReader.GetString(6);
        if (!dataReader.IsDBNull(7))
          homeItems.BgColor = dataReader.GetString(7);
        if (!dataReader.IsDBNull(8))
          homeItems.Color = dataReader.GetString(8);
        if (!dataReader.IsDBNull(9))
          homeItems.DBConnID = new Guid?(dataReader.GetGuid(9));
        if (!dataReader.IsDBNull(10))
          homeItems.LinkURL = dataReader.GetString(10);
        if (!dataReader.IsDBNull(11))
          homeItems.UseOrganizes = dataReader.GetString(11);
        if (!dataReader.IsDBNull(12))
          homeItems.UseUsers = dataReader.GetString(12);
        if (!dataReader.IsDBNull(13))
          homeItems.Sort = new int?(dataReader.GetInt32(13));
        if (!dataReader.IsDBNull(14))
          homeItems.Note = dataReader.GetString(14);
        homeItemsList.Add(homeItems);
      }
      return homeItemsList;
    }

    public List<RoadFlow.Data.Model.HomeItems> GetAll()
    {
      SqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM HomeItems");
      List<RoadFlow.Data.Model.HomeItems> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM HomeItems"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.HomeItems Get(Guid id)
    {
      string sql = "SELECT * FROM HomeItems WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.HomeItems> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.HomeItems) null;
      return list[0];
    }

    public List<RoadFlow.Data.Model.HomeItems> GetList(out string pager, string query = "", string name = "", string title = "", string type = "")
    {
      List<SqlParameter> sqlParameterList = new List<SqlParameter>();
      StringBuilder stringBuilder = new StringBuilder("SELECT *,ROW_NUMBER() OVER(ORDER BY Type,Sort) AS PagerAutoRowNumber FROM HomeItems WHERE 1=1 ");
      if (!name.IsNullOrEmpty())
      {
        stringBuilder.Append(" AND CHARINDEX(@Name,Name)>0");
        sqlParameterList.Add(new SqlParameter("@Name", (object) name));
      }
      if (!title.IsNullOrEmpty())
      {
        stringBuilder.Append(" AND CHARINDEX(@Title,Title)>0");
        sqlParameterList.Add(new SqlParameter("@Title", (object) title));
      }
      if (!type.IsNullOrEmpty())
      {
        stringBuilder.Append(" AND Type=@Type");
        sqlParameterList.Add(new SqlParameter("@Type", (object) type));
      }
      int pageSize = Tools.GetPageSize();
      int pageNumber = Tools.GetPageNumber();
      long count;
      string paerSql = this.dbHelper.GetPaerSql(stringBuilder.ToString(), pageSize, pageNumber, out count, sqlParameterList.ToArray());
      pager = Tools.GetPagerHtml(count, pageSize, pageNumber, query);
      SqlDataReader dataReader = this.dbHelper.GetDataReader(paerSql, sqlParameterList.ToArray());
      List<RoadFlow.Data.Model.HomeItems> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.HomeItems> GetList(out long count, int size, int number, string name = "", string title = "", string type = "", string order = "")
    {
      List<SqlParameter> sqlParameterList = new List<SqlParameter>();
      StringBuilder stringBuilder = new StringBuilder("SELECT *,ROW_NUMBER() OVER(ORDER BY " + (order.IsNullOrEmpty() ? "Type,Sort" : order) + ") AS PagerAutoRowNumber FROM HomeItems WHERE 1=1 ");
      if (!name.IsNullOrEmpty())
      {
        stringBuilder.Append(" AND CHARINDEX(@Name,Name)>0");
        sqlParameterList.Add(new SqlParameter("@Name", (object) name));
      }
      if (!title.IsNullOrEmpty())
      {
        stringBuilder.Append(" AND CHARINDEX(@Title,Title)>0");
        sqlParameterList.Add(new SqlParameter("@Title", (object) title));
      }
      if (!type.IsNullOrEmpty())
      {
        stringBuilder.Append(" AND Type=@Type");
        sqlParameterList.Add(new SqlParameter("@Type", (object) type));
      }
      SqlDataReader dataReader = this.dbHelper.GetDataReader(this.dbHelper.GetPaerSql(stringBuilder.ToString(), size, number, out count, sqlParameterList.ToArray()), sqlParameterList.ToArray());
      List<RoadFlow.Data.Model.HomeItems> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public int GetMaxSort(int type)
    {
      return this.dbHelper.GetFieldValue("SELECT MAX(Sort) FROM HomeItems WHERE Type=" + (object) type).ToInt(0) + 5;
    }
  }
}
