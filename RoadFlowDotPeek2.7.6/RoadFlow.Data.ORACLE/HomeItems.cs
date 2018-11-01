// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.ORACLE.HomeItems
// Assembly: RoadFlow.Data.ORACLE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C9018AA1-E48E-4231-92A9-CD6F0F275D11
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.ORACLE.dll

using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoadFlow.Data.ORACLE
{
  public class HomeItems : IHomeItems
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.HomeItems model)
    {
      string sql = "INSERT INTO HomeItems\r\n\t\t\t\t(ID,Type,Name,Title,DataSourceType,DataSource,Ico,BgColor,Color,DBConnID,LinkURL,UseOrganizes,UseUsers,Sort,Note) \r\n\t\t\t\tVALUES(:ID,:Type,:Name,:Title,:DataSourceType,:DataSource,:Ico,:BgColor,:Color,:DBConnID,:LinkURL,:UseOrganizes,:UseUsers,:Sort,:Note)";
      OracleParameter[] oracleParameterArray = new OracleParameter[15];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter1.Value = (object) model.ID;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":Type", OracleDbType.Int32);
      oracleParameter2.Value = (object) model.Type;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3 = new OracleParameter(":Name", OracleDbType.Varchar2);
      oracleParameter3.Value = (object) model.Name;
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter4 = new OracleParameter(":Title", OracleDbType.Varchar2);
      oracleParameter4.Value = (object) model.Title;
      oracleParameterArray[index4] = oracleParameter4;
      int index5 = 4;
      OracleParameter oracleParameter5 = new OracleParameter(":DataSourceType", OracleDbType.Int32);
      oracleParameter5.Value = (object) model.DataSourceType;
      oracleParameterArray[index5] = oracleParameter5;
      int index6 = 5;
      OracleParameter oracleParameter6;
      if (model.DataSource != null)
      {
        OracleParameter oracleParameter7 = new OracleParameter(":DataSource", OracleDbType.Varchar2);
        oracleParameter7.Value = (object) model.DataSource;
        oracleParameter6 = oracleParameter7;
      }
      else
      {
        oracleParameter6 = new OracleParameter(":DataSource", OracleDbType.Varchar2);
        oracleParameter6.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index6] = oracleParameter6;
      int index7 = 6;
      OracleParameter oracleParameter8;
      if (model.Ico != null)
      {
        OracleParameter oracleParameter7 = new OracleParameter(":Ico", OracleDbType.Varchar2);
        oracleParameter7.Value = (object) model.Ico;
        oracleParameter8 = oracleParameter7;
      }
      else
      {
        oracleParameter8 = new OracleParameter(":Ico", OracleDbType.Varchar2);
        oracleParameter8.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index7] = oracleParameter8;
      int index8 = 7;
      OracleParameter oracleParameter9;
      if (model.BgColor != null)
      {
        OracleParameter oracleParameter7 = new OracleParameter(":BgColor", OracleDbType.Varchar2);
        oracleParameter7.Value = (object) model.BgColor;
        oracleParameter9 = oracleParameter7;
      }
      else
      {
        oracleParameter9 = new OracleParameter(":BgColor", OracleDbType.Varchar2);
        oracleParameter9.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index8] = oracleParameter9;
      int index9 = 8;
      OracleParameter oracleParameter10;
      if (model.Color != null)
      {
        OracleParameter oracleParameter7 = new OracleParameter(":Color", OracleDbType.Varchar2);
        oracleParameter7.Value = (object) model.Color;
        oracleParameter10 = oracleParameter7;
      }
      else
      {
        oracleParameter10 = new OracleParameter(":Color", OracleDbType.Varchar2);
        oracleParameter10.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index9] = oracleParameter10;
      int index10 = 9;
      OracleParameter oracleParameter11;
      if (model.DBConnID.HasValue)
      {
        OracleParameter oracleParameter7 = new OracleParameter(":DBConnID", OracleDbType.Varchar2);
        oracleParameter7.Value = (object) model.DBConnID;
        oracleParameter11 = oracleParameter7;
      }
      else
      {
        oracleParameter11 = new OracleParameter(":DBConnID", OracleDbType.Varchar2);
        oracleParameter11.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index10] = oracleParameter11;
      int index11 = 10;
      OracleParameter oracleParameter12;
      if (model.LinkURL != null)
      {
        OracleParameter oracleParameter7 = new OracleParameter(":LinkURL", OracleDbType.Varchar2);
        oracleParameter7.Value = (object) model.LinkURL;
        oracleParameter12 = oracleParameter7;
      }
      else
      {
        oracleParameter12 = new OracleParameter(":LinkURL", OracleDbType.Varchar2);
        oracleParameter12.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index11] = oracleParameter12;
      int index12 = 11;
      OracleParameter oracleParameter13;
      if (model.UseOrganizes != null)
      {
        OracleParameter oracleParameter7 = new OracleParameter(":UseOrganizes", OracleDbType.Varchar2);
        oracleParameter7.Value = (object) model.UseOrganizes;
        oracleParameter13 = oracleParameter7;
      }
      else
      {
        oracleParameter13 = new OracleParameter(":UseOrganizes", OracleDbType.Varchar2);
        oracleParameter13.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index12] = oracleParameter13;
      int index13 = 12;
      OracleParameter oracleParameter14;
      if (model.UseUsers != null)
      {
        OracleParameter oracleParameter7 = new OracleParameter(":UseUsers", OracleDbType.Varchar2);
        oracleParameter7.Value = (object) model.UseUsers;
        oracleParameter14 = oracleParameter7;
      }
      else
      {
        oracleParameter14 = new OracleParameter(":UseUsers", OracleDbType.Varchar2);
        oracleParameter14.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index13] = oracleParameter14;
      int index14 = 13;
      OracleParameter oracleParameter15;
      if (model.Sort.HasValue)
      {
        OracleParameter oracleParameter7 = new OracleParameter(":Sort", OracleDbType.Int32);
        oracleParameter7.Value = (object) model.Sort;
        oracleParameter15 = oracleParameter7;
      }
      else
      {
        oracleParameter15 = new OracleParameter(":Sort", OracleDbType.Int32);
        oracleParameter15.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index14] = oracleParameter15;
      int index15 = 14;
      OracleParameter oracleParameter16;
      if (model.Note != null)
      {
        OracleParameter oracleParameter7 = new OracleParameter(":Note", OracleDbType.Varchar2);
        oracleParameter7.Value = (object) model.Note;
        oracleParameter16 = oracleParameter7;
      }
      else
      {
        oracleParameter16 = new OracleParameter(":Note", OracleDbType.Varchar2);
        oracleParameter16.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index15] = oracleParameter16;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Update(RoadFlow.Data.Model.HomeItems model)
    {
      string sql = "UPDATE HomeItems SET \r\n\t\t\t\tType=:Type,Name=:Name,Title=:Title,DataSourceType=:DataSourceType,DataSource=:DataSource,Ico=:Ico,BgColor=:BgColor,Color=:Color,DBConnID=:DBConnID,LinkURL=:LinkURL,UseOrganizes=:UseOrganizes,UseUsers=:UseUsers,Sort=:Sort,Note=:Note\r\n\t\t\t\tWHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[15];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":Type", OracleDbType.Int32);
      oracleParameter1.Value = (object) model.Type;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":Name", OracleDbType.Varchar2);
      oracleParameter2.Value = (object) model.Name;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3 = new OracleParameter(":Title", OracleDbType.Varchar2);
      oracleParameter3.Value = (object) model.Title;
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter4 = new OracleParameter(":DataSourceType", OracleDbType.Int32);
      oracleParameter4.Value = (object) model.DataSourceType;
      oracleParameterArray[index4] = oracleParameter4;
      int index5 = 4;
      OracleParameter oracleParameter5;
      if (model.DataSource != null)
      {
        OracleParameter oracleParameter6 = new OracleParameter(":DataSource", OracleDbType.Varchar2);
        oracleParameter6.Value = (object) model.DataSource;
        oracleParameter5 = oracleParameter6;
      }
      else
      {
        oracleParameter5 = new OracleParameter(":DataSource", OracleDbType.Varchar2);
        oracleParameter5.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index5] = oracleParameter5;
      int index6 = 5;
      OracleParameter oracleParameter7;
      if (model.Ico != null)
      {
        OracleParameter oracleParameter6 = new OracleParameter(":Ico", OracleDbType.Varchar2);
        oracleParameter6.Value = (object) model.Ico;
        oracleParameter7 = oracleParameter6;
      }
      else
      {
        oracleParameter7 = new OracleParameter(":Ico", OracleDbType.Varchar2);
        oracleParameter7.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index6] = oracleParameter7;
      int index7 = 6;
      OracleParameter oracleParameter8;
      if (model.BgColor != null)
      {
        OracleParameter oracleParameter6 = new OracleParameter(":BgColor", OracleDbType.Varchar2);
        oracleParameter6.Value = (object) model.BgColor;
        oracleParameter8 = oracleParameter6;
      }
      else
      {
        oracleParameter8 = new OracleParameter(":BgColor", OracleDbType.Varchar2);
        oracleParameter8.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index7] = oracleParameter8;
      int index8 = 7;
      OracleParameter oracleParameter9;
      if (model.Color != null)
      {
        OracleParameter oracleParameter6 = new OracleParameter(":Color", OracleDbType.Varchar2);
        oracleParameter6.Value = (object) model.Color;
        oracleParameter9 = oracleParameter6;
      }
      else
      {
        oracleParameter9 = new OracleParameter(":Color", OracleDbType.Varchar2);
        oracleParameter9.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index8] = oracleParameter9;
      int index9 = 8;
      OracleParameter oracleParameter10;
      if (model.DBConnID.HasValue)
      {
        OracleParameter oracleParameter6 = new OracleParameter(":DBConnID", OracleDbType.Varchar2);
        oracleParameter6.Value = (object) model.DBConnID;
        oracleParameter10 = oracleParameter6;
      }
      else
      {
        oracleParameter10 = new OracleParameter(":DBConnID", OracleDbType.Varchar2);
        oracleParameter10.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index9] = oracleParameter10;
      int index10 = 9;
      OracleParameter oracleParameter11;
      if (model.LinkURL != null)
      {
        OracleParameter oracleParameter6 = new OracleParameter(":LinkURL", OracleDbType.Varchar2);
        oracleParameter6.Value = (object) model.LinkURL;
        oracleParameter11 = oracleParameter6;
      }
      else
      {
        oracleParameter11 = new OracleParameter(":LinkURL", OracleDbType.Varchar2);
        oracleParameter11.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index10] = oracleParameter11;
      int index11 = 10;
      OracleParameter oracleParameter12;
      if (model.UseOrganizes != null)
      {
        OracleParameter oracleParameter6 = new OracleParameter(":UseOrganizes", OracleDbType.Varchar2);
        oracleParameter6.Value = (object) model.UseOrganizes;
        oracleParameter12 = oracleParameter6;
      }
      else
      {
        oracleParameter12 = new OracleParameter(":UseOrganizes", OracleDbType.Varchar2);
        oracleParameter12.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index11] = oracleParameter12;
      int index12 = 11;
      OracleParameter oracleParameter13;
      if (model.UseUsers != null)
      {
        OracleParameter oracleParameter6 = new OracleParameter(":UseUsers", OracleDbType.Varchar2);
        oracleParameter6.Value = (object) model.UseUsers;
        oracleParameter13 = oracleParameter6;
      }
      else
      {
        oracleParameter13 = new OracleParameter(":UseUsers", OracleDbType.Varchar2);
        oracleParameter13.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index12] = oracleParameter13;
      int index13 = 12;
      OracleParameter oracleParameter14;
      if (model.Sort.HasValue)
      {
        OracleParameter oracleParameter6 = new OracleParameter(":Sort", OracleDbType.Int32);
        oracleParameter6.Value = (object) model.Sort;
        oracleParameter14 = oracleParameter6;
      }
      else
      {
        oracleParameter14 = new OracleParameter(":Sort", OracleDbType.Int32);
        oracleParameter14.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index13] = oracleParameter14;
      int index14 = 13;
      OracleParameter oracleParameter15;
      if (model.Note != null)
      {
        OracleParameter oracleParameter6 = new OracleParameter(":Note", OracleDbType.Varchar2);
        oracleParameter6.Value = (object) model.Note;
        oracleParameter15 = oracleParameter6;
      }
      else
      {
        oracleParameter15 = new OracleParameter(":Note", OracleDbType.Varchar2);
        oracleParameter15.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index14] = oracleParameter15;
      int index15 = 14;
      OracleParameter oracleParameter16 = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter16.Value = (object) model.ID;
      oracleParameterArray[index15] = oracleParameter16;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM HomeItems WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    private List<RoadFlow.Data.Model.HomeItems> DataReaderToList(OracleDataReader dataReader)
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
      OracleDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM HomeItems");
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
      string sql = "SELECT * FROM HomeItems WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.HomeItems> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.HomeItems) null;
      return list[0];
    }

    public List<RoadFlow.Data.Model.HomeItems> GetList(out string pager, string query = "", string name = "", string title = "", string type = "")
    {
      List<OracleParameter> oracleParameterList = new List<OracleParameter>();
      StringBuilder stringBuilder = new StringBuilder("SELECT PagerTempTable.*,ROWNUM AS PagerAutoRowNumber FROM (SELECT * FROM HomeItems WHERE 1=1 ");
      if (!name.IsNullOrEmpty())
      {
        stringBuilder.Append(" AND AND INSTR(Name,:Name,1,1)>0");
        oracleParameterList.Add(new OracleParameter(":Name", (object) name));
      }
      if (!title.IsNullOrEmpty())
      {
        stringBuilder.Append(" AND INSTR(Title,:Title,1,1)>0");
        oracleParameterList.Add(new OracleParameter(":Title", (object) title));
      }
      if (!type.IsNullOrEmpty())
      {
        stringBuilder.Append(" AND Type=:Type");
        oracleParameterList.Add(new OracleParameter(":Type", (object) type));
      }
      stringBuilder.Append(" ORDER BY Type,Sort) PagerTempTable");
      int pageSize = Tools.GetPageSize();
      int pageNumber = Tools.GetPageNumber();
      long count;
      string paerSql = this.dbHelper.GetPaerSql(stringBuilder.ToString(), pageSize, pageNumber, out count, oracleParameterList.ToArray());
      pager = Tools.GetPagerHtml(count, pageSize, pageNumber, query);
      OracleDataReader dataReader = this.dbHelper.GetDataReader(paerSql, oracleParameterList.ToArray());
      List<RoadFlow.Data.Model.HomeItems> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.HomeItems> GetList(out long count, int size, int number, string name = "", string title = "", string type = "", string order = "")
    {
      List<OracleParameter> oracleParameterList = new List<OracleParameter>();
      StringBuilder stringBuilder = new StringBuilder("SELECT PagerTempTable.*,ROWNUM AS PagerAutoRowNumber FROM (SELECT * FROM HomeItems WHERE 1=1 ");
      if (!name.IsNullOrEmpty())
      {
        stringBuilder.Append(" AND AND INSTR(Name,:Name,1,1)>0");
        oracleParameterList.Add(new OracleParameter(":Name", (object) name));
      }
      if (!title.IsNullOrEmpty())
      {
        stringBuilder.Append(" AND INSTR(Title,:Title,1,1)>0");
        oracleParameterList.Add(new OracleParameter(":Title", (object) title));
      }
      if (!type.IsNullOrEmpty())
      {
        stringBuilder.Append(" AND Type=:Type");
        oracleParameterList.Add(new OracleParameter(":Type", (object) type));
      }
      stringBuilder.Append((order.IsNullOrEmpty() ? " ORDER BY Type,Sort" : " ORDER BY " + order) + ") PagerTempTable");
      OracleDataReader dataReader = this.dbHelper.GetDataReader(this.dbHelper.GetPaerSql(stringBuilder.ToString(), size, number, out count, oracleParameterList.ToArray()), oracleParameterList.ToArray());
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
