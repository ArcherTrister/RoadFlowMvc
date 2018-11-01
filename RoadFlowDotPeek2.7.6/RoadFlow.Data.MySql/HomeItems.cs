// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MySql.HomeItems
// Assembly: RoadFlow.Data.MySql, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 29B652D7-5F6F-4A7D-AD1C-9F2C643FD784
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.MySql.dll

using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoadFlow.Data.MySql
{
  public class HomeItems : IHomeItems
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.HomeItems model)
    {
      string sql = "INSERT INTO homeitems\r\n\t\t\t\t(ID,Type,Name,Title,DataSourceType,DataSource,Ico,BgColor,Color,DBConnID,LinkURL,UseOrganizes,UseUsers,Sort,Note) \r\n\t\t\t\tVALUES(@ID,@Type,@Name,@Title,@DataSourceType,@DataSource,@Ico,@BgColor,@Color,@DBConnID,@LinkURL,@UseOrganizes,@UseUsers,@Sort,@Note)";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[15];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter1.Value = (object) model.ID;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@Type", MySqlDbType.Int32, 11);
      mySqlParameter2.Value = (object) model.Type;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@Name", MySqlDbType.Text, -1);
      mySqlParameter3.Value = (object) model.Name;
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter4 = new MySqlParameter("@Title", MySqlDbType.Text, -1);
      mySqlParameter4.Value = (object) model.Title;
      mySqlParameterArray[index4] = mySqlParameter4;
      int index5 = 4;
      MySqlParameter mySqlParameter5 = new MySqlParameter("@DataSourceType", MySqlDbType.Int32, 11);
      mySqlParameter5.Value = (object) model.DataSourceType;
      mySqlParameterArray[index5] = mySqlParameter5;
      int index6 = 5;
      MySqlParameter mySqlParameter6;
      if (model.DataSource != null)
      {
        MySqlParameter mySqlParameter7 = new MySqlParameter("@DataSource", MySqlDbType.LongText, -1);
        mySqlParameter7.Value = (object) model.DataSource;
        mySqlParameter6 = mySqlParameter7;
      }
      else
      {
        mySqlParameter6 = new MySqlParameter("@DataSource", MySqlDbType.LongText, -1);
        mySqlParameter6.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index6] = mySqlParameter6;
      int index7 = 6;
      MySqlParameter mySqlParameter8;
      if (model.Ico != null)
      {
        MySqlParameter mySqlParameter7 = new MySqlParameter("@Ico", MySqlDbType.Text, -1);
        mySqlParameter7.Value = (object) model.Ico;
        mySqlParameter8 = mySqlParameter7;
      }
      else
      {
        mySqlParameter8 = new MySqlParameter("@Ico", MySqlDbType.Text, -1);
        mySqlParameter8.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index7] = mySqlParameter8;
      int index8 = 7;
      MySqlParameter mySqlParameter9;
      if (model.BgColor != null)
      {
        MySqlParameter mySqlParameter7 = new MySqlParameter("@BgColor", MySqlDbType.VarChar, 50);
        mySqlParameter7.Value = (object) model.BgColor;
        mySqlParameter9 = mySqlParameter7;
      }
      else
      {
        mySqlParameter9 = new MySqlParameter("@BgColor", MySqlDbType.VarChar, 50);
        mySqlParameter9.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index8] = mySqlParameter9;
      int index9 = 8;
      MySqlParameter mySqlParameter10;
      if (model.Color != null)
      {
        MySqlParameter mySqlParameter7 = new MySqlParameter("@Color", MySqlDbType.VarChar, 50);
        mySqlParameter7.Value = (object) model.Color;
        mySqlParameter10 = mySqlParameter7;
      }
      else
      {
        mySqlParameter10 = new MySqlParameter("@Color", MySqlDbType.VarChar, 50);
        mySqlParameter10.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index9] = mySqlParameter10;
      int index10 = 9;
      MySqlParameter mySqlParameter11;
      if (model.DBConnID.HasValue)
      {
        MySqlParameter mySqlParameter7 = new MySqlParameter("@DBConnID", MySqlDbType.VarChar, 36);
        mySqlParameter7.Value = (object) model.DBConnID;
        mySqlParameter11 = mySqlParameter7;
      }
      else
      {
        mySqlParameter11 = new MySqlParameter("@DBConnID", MySqlDbType.VarChar, 36);
        mySqlParameter11.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index10] = mySqlParameter11;
      int index11 = 10;
      MySqlParameter mySqlParameter12;
      if (model.LinkURL != null)
      {
        MySqlParameter mySqlParameter7 = new MySqlParameter("@LinkURL", MySqlDbType.Text, -1);
        mySqlParameter7.Value = (object) model.LinkURL;
        mySqlParameter12 = mySqlParameter7;
      }
      else
      {
        mySqlParameter12 = new MySqlParameter("@LinkURL", MySqlDbType.Text, -1);
        mySqlParameter12.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index11] = mySqlParameter12;
      int index12 = 11;
      MySqlParameter mySqlParameter13;
      if (model.UseOrganizes != null)
      {
        MySqlParameter mySqlParameter7 = new MySqlParameter("@UseOrganizes", MySqlDbType.LongText, -1);
        mySqlParameter7.Value = (object) model.UseOrganizes;
        mySqlParameter13 = mySqlParameter7;
      }
      else
      {
        mySqlParameter13 = new MySqlParameter("@UseOrganizes", MySqlDbType.LongText, -1);
        mySqlParameter13.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index12] = mySqlParameter13;
      int index13 = 12;
      MySqlParameter mySqlParameter14;
      if (model.UseUsers != null)
      {
        MySqlParameter mySqlParameter7 = new MySqlParameter("@UseUsers", MySqlDbType.LongText, -1);
        mySqlParameter7.Value = (object) model.UseUsers;
        mySqlParameter14 = mySqlParameter7;
      }
      else
      {
        mySqlParameter14 = new MySqlParameter("@UseUsers", MySqlDbType.LongText, -1);
        mySqlParameter14.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index13] = mySqlParameter14;
      int index14 = 13;
      MySqlParameter mySqlParameter15;
      if (model.Sort.HasValue)
      {
        MySqlParameter mySqlParameter7 = new MySqlParameter("@Sort", MySqlDbType.Int32, 11);
        mySqlParameter7.Value = (object) model.Sort;
        mySqlParameter15 = mySqlParameter7;
      }
      else
      {
        mySqlParameter15 = new MySqlParameter("@Sort", MySqlDbType.Int32, 11);
        mySqlParameter15.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index14] = mySqlParameter15;
      int index15 = 14;
      MySqlParameter mySqlParameter16;
      if (model.Note != null)
      {
        MySqlParameter mySqlParameter7 = new MySqlParameter("@Note", MySqlDbType.Text, -1);
        mySqlParameter7.Value = (object) model.Note;
        mySqlParameter16 = mySqlParameter7;
      }
      else
      {
        mySqlParameter16 = new MySqlParameter("@Note", MySqlDbType.Text, -1);
        mySqlParameter16.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index15] = mySqlParameter16;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.HomeItems model)
    {
      string sql = "UPDATE homeitems SET \r\n\t\t\t\tType=@Type,Name=@Name,Title=@Title,DataSourceType=@DataSourceType,DataSource=@DataSource,Ico=@Ico,BgColor=@BgColor,Color=@Color,DBConnID=@DBConnID,LinkURL=@LinkURL,UseOrganizes=@UseOrganizes,UseUsers=@UseUsers,Sort=@Sort,Note=@Note\r\n\t\t\t\tWHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[15];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@Type", MySqlDbType.Int32, 11);
      mySqlParameter1.Value = (object) model.Type;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@Name", MySqlDbType.Text, -1);
      mySqlParameter2.Value = (object) model.Name;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@Title", MySqlDbType.Text, -1);
      mySqlParameter3.Value = (object) model.Title;
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter4 = new MySqlParameter("@DataSourceType", MySqlDbType.Int32, 11);
      mySqlParameter4.Value = (object) model.DataSourceType;
      mySqlParameterArray[index4] = mySqlParameter4;
      int index5 = 4;
      MySqlParameter mySqlParameter5;
      if (model.DataSource != null)
      {
        MySqlParameter mySqlParameter6 = new MySqlParameter("@DataSource", MySqlDbType.LongText, -1);
        mySqlParameter6.Value = (object) model.DataSource;
        mySqlParameter5 = mySqlParameter6;
      }
      else
      {
        mySqlParameter5 = new MySqlParameter("@DataSource", MySqlDbType.LongText, -1);
        mySqlParameter5.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index5] = mySqlParameter5;
      int index6 = 5;
      MySqlParameter mySqlParameter7;
      if (model.Ico != null)
      {
        MySqlParameter mySqlParameter6 = new MySqlParameter("@Ico", MySqlDbType.Text, -1);
        mySqlParameter6.Value = (object) model.Ico;
        mySqlParameter7 = mySqlParameter6;
      }
      else
      {
        mySqlParameter7 = new MySqlParameter("@Ico", MySqlDbType.Text, -1);
        mySqlParameter7.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index6] = mySqlParameter7;
      int index7 = 6;
      MySqlParameter mySqlParameter8;
      if (model.BgColor != null)
      {
        MySqlParameter mySqlParameter6 = new MySqlParameter("@BgColor", MySqlDbType.VarChar, 50);
        mySqlParameter6.Value = (object) model.BgColor;
        mySqlParameter8 = mySqlParameter6;
      }
      else
      {
        mySqlParameter8 = new MySqlParameter("@BgColor", MySqlDbType.VarChar, 50);
        mySqlParameter8.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index7] = mySqlParameter8;
      int index8 = 7;
      MySqlParameter mySqlParameter9;
      if (model.Color != null)
      {
        MySqlParameter mySqlParameter6 = new MySqlParameter("@Color", MySqlDbType.VarChar, 50);
        mySqlParameter6.Value = (object) model.Color;
        mySqlParameter9 = mySqlParameter6;
      }
      else
      {
        mySqlParameter9 = new MySqlParameter("@Color", MySqlDbType.VarChar, 50);
        mySqlParameter9.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index8] = mySqlParameter9;
      int index9 = 8;
      MySqlParameter mySqlParameter10;
      if (model.DBConnID.HasValue)
      {
        MySqlParameter mySqlParameter6 = new MySqlParameter("@DBConnID", MySqlDbType.VarChar, 36);
        mySqlParameter6.Value = (object) model.DBConnID;
        mySqlParameter10 = mySqlParameter6;
      }
      else
      {
        mySqlParameter10 = new MySqlParameter("@DBConnID", MySqlDbType.VarChar, 36);
        mySqlParameter10.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index9] = mySqlParameter10;
      int index10 = 9;
      MySqlParameter mySqlParameter11;
      if (model.LinkURL != null)
      {
        MySqlParameter mySqlParameter6 = new MySqlParameter("@LinkURL", MySqlDbType.Text, -1);
        mySqlParameter6.Value = (object) model.LinkURL;
        mySqlParameter11 = mySqlParameter6;
      }
      else
      {
        mySqlParameter11 = new MySqlParameter("@LinkURL", MySqlDbType.Text, -1);
        mySqlParameter11.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index10] = mySqlParameter11;
      int index11 = 10;
      MySqlParameter mySqlParameter12;
      if (model.UseOrganizes != null)
      {
        MySqlParameter mySqlParameter6 = new MySqlParameter("@UseOrganizes", MySqlDbType.LongText, -1);
        mySqlParameter6.Value = (object) model.UseOrganizes;
        mySqlParameter12 = mySqlParameter6;
      }
      else
      {
        mySqlParameter12 = new MySqlParameter("@UseOrganizes", MySqlDbType.LongText, -1);
        mySqlParameter12.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index11] = mySqlParameter12;
      int index12 = 11;
      MySqlParameter mySqlParameter13;
      if (model.UseUsers != null)
      {
        MySqlParameter mySqlParameter6 = new MySqlParameter("@UseUsers", MySqlDbType.LongText, -1);
        mySqlParameter6.Value = (object) model.UseUsers;
        mySqlParameter13 = mySqlParameter6;
      }
      else
      {
        mySqlParameter13 = new MySqlParameter("@UseUsers", MySqlDbType.LongText, -1);
        mySqlParameter13.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index12] = mySqlParameter13;
      int index13 = 12;
      MySqlParameter mySqlParameter14;
      if (model.Sort.HasValue)
      {
        MySqlParameter mySqlParameter6 = new MySqlParameter("@Sort", MySqlDbType.Int32, 11);
        mySqlParameter6.Value = (object) model.Sort;
        mySqlParameter14 = mySqlParameter6;
      }
      else
      {
        mySqlParameter14 = new MySqlParameter("@Sort", MySqlDbType.Int32, 11);
        mySqlParameter14.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index13] = mySqlParameter14;
      int index14 = 13;
      MySqlParameter mySqlParameter15;
      if (model.Note != null)
      {
        MySqlParameter mySqlParameter6 = new MySqlParameter("@Note", MySqlDbType.Text, -1);
        mySqlParameter6.Value = (object) model.Note;
        mySqlParameter15 = mySqlParameter6;
      }
      else
      {
        mySqlParameter15 = new MySqlParameter("@Note", MySqlDbType.Text, -1);
        mySqlParameter15.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index14] = mySqlParameter15;
      int index15 = 14;
      MySqlParameter mySqlParameter16 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter16.Value = (object) model.ID;
      mySqlParameterArray[index15] = mySqlParameter16;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM homeitems WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.HomeItems> DataReaderToList(MySqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.HomeItems> homeItemsList = new List<RoadFlow.Data.Model.HomeItems>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.HomeItems homeItems = new RoadFlow.Data.Model.HomeItems();
        homeItems.ID = dataReader.GetString(0).ToGuid();
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
          homeItems.DBConnID = new Guid?(dataReader.GetString(9).ToGuid());
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
      MySqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM homeitems");
      List<RoadFlow.Data.Model.HomeItems> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM homeitems"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.HomeItems Get(Guid id)
    {
      string sql = "SELECT * FROM homeitems WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.HomeItems> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.HomeItems) null;
      return list[0];
    }

    public List<RoadFlow.Data.Model.HomeItems> GetList(out string pager, string query = "", string name = "", string title = "", string type = "")
    {
      List<MySqlParameter> mySqlParameterList = new List<MySqlParameter>();
      StringBuilder stringBuilder = new StringBuilder("SELECT * FROM HomeItems WHERE 1=1 ");
      if (!name.IsNullOrEmpty())
      {
        stringBuilder.Append(" AND INSTR(Name,@Name)>0");
        mySqlParameterList.Add(new MySqlParameter("@Name", (object) name));
      }
      if (!title.IsNullOrEmpty())
      {
        stringBuilder.Append(" AND INSTR(Title,@Title)>0");
        mySqlParameterList.Add(new MySqlParameter("@Title", (object) title));
      }
      if (!type.IsNullOrEmpty())
      {
        stringBuilder.Append(" AND Type=@Type");
        mySqlParameterList.Add(new MySqlParameter("@Type", (object) type));
      }
      stringBuilder.Append(" ORDER BY Type,Sort");
      int pageSize = Tools.GetPageSize();
      int pageNumber = Tools.GetPageNumber();
      long count;
      string paerSql = this.dbHelper.GetPaerSql(stringBuilder.ToString(), pageSize, pageNumber, out count, mySqlParameterList.ToArray());
      pager = Tools.GetPagerHtml(count, pageSize, pageNumber, query);
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(paerSql, mySqlParameterList.ToArray());
      List<RoadFlow.Data.Model.HomeItems> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.HomeItems> GetList(out long count, int size, int number, string name = "", string title = "", string type = "", string order = "")
    {
      List<MySqlParameter> mySqlParameterList = new List<MySqlParameter>();
      StringBuilder stringBuilder = new StringBuilder("SELECT * FROM HomeItems WHERE 1=1 ");
      if (!name.IsNullOrEmpty())
      {
        stringBuilder.Append(" AND INSTR(Name,@Name)>0");
        mySqlParameterList.Add(new MySqlParameter("@Name", (object) name));
      }
      if (!title.IsNullOrEmpty())
      {
        stringBuilder.Append(" AND INSTR(Title,@Title)>0");
        mySqlParameterList.Add(new MySqlParameter("@Title", (object) title));
      }
      if (!type.IsNullOrEmpty())
      {
        stringBuilder.Append(" AND Type=@Type");
        mySqlParameterList.Add(new MySqlParameter("@Type", (object) type));
      }
      stringBuilder.Append(order.IsNullOrEmpty() ? " ORDER BY Type,Sort" : " ORDER BY " + order);
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(this.dbHelper.GetPaerSql(stringBuilder.ToString(), size, number, out count, mySqlParameterList.ToArray()), mySqlParameterList.ToArray());
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
