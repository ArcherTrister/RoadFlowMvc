// Decompiled with JetBrains decompiler
// Type: RoadFlow.Platform.HomeItems
// Assembly: RoadFlow.Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07F26AFD-DE3B-4003-89AF-01A62494BA58
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Platform.dll

using RoadFlow.Cache.IO;
using RoadFlow.Data.Interface;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace RoadFlow.Platform
{
  public class HomeItems
  {
    private System.Collections.Generic.Dictionary<int, string> types = new System.Collections.Generic.Dictionary<int, string>();
    private System.Collections.Generic.Dictionary<int, string> dstypes = new System.Collections.Generic.Dictionary<int, string>();
    private string cacheKey = string.Empty;
    private IHomeItems dataHomeItems;

    public HomeItems()
    {
      this.cacheKey = Keys.CacheKeys.HomeItems.ToString();
      this.dataHomeItems = RoadFlow.Data.Factory.Factory.GetHomeItems();
      this.types.Add(0, "顶部统计");
      this.types.Add(1, "左边列表");
      this.types.Add(2, "右边列表");
      this.dstypes.Add(0, "SQL语句");
      this.dstypes.Add(1, "C#方法");
      this.dstypes.Add(2, "URL地址");
    }

    public int Add(RoadFlow.Data.Model.HomeItems model)
    {
      return this.dataHomeItems.Add(model);
    }

    public int Update(RoadFlow.Data.Model.HomeItems model)
    {
      return this.dataHomeItems.Update(model);
    }

    public List<RoadFlow.Data.Model.HomeItems> GetAll()
    {
      return this.dataHomeItems.GetAll();
    }

    public RoadFlow.Data.Model.HomeItems Get(Guid id)
    {
      return this.dataHomeItems.Get(id);
    }

    public int Delete(Guid id)
    {
      return this.dataHomeItems.Delete(id);
    }

    public long GetCount()
    {
      return this.dataHomeItems.GetCount();
    }

    public List<RoadFlow.Data.Model.HomeItems> GetList(out string pager, string query = "", string name = "", string title = "", string type = "")
    {
      return this.dataHomeItems.GetList(out pager, query, name, title, type);
    }

    public List<RoadFlow.Data.Model.HomeItems> GetList(out long count, int size, int number, string name = "", string title = "", string type = "", string order = "")
    {
      return this.dataHomeItems.GetList(out count, size, number, name, title, type, order);
    }

    public string getTypeOptions(string value = "")
    {
      StringBuilder stringBuilder = new StringBuilder();
      foreach (KeyValuePair<int, string> type in this.types)
        stringBuilder.Append("<option value=\"" + type.Key.ToString() + "\"" + (type.Key.ToString().Equals(value) ? " selected=\"selected\"" : "") + ">" + type.Value + "</option>");
      return stringBuilder.ToString();
    }

    public string getDataSourceOptions(string value = "")
    {
      StringBuilder stringBuilder = new StringBuilder();
      foreach (KeyValuePair<int, string> dstype in this.dstypes)
        stringBuilder.Append("<option value=\"" + dstype.Key.ToString() + "\"" + (dstype.Key.ToString().Equals(value) ? " selected=\"selected\"" : "") + ">" + dstype.Value + "</option>");
      return stringBuilder.ToString();
    }

    public string GetTypeTitle(int type)
    {
      if (!this.types.ContainsKey(type))
        return "";
      return this.types[type];
    }

    public string GetDataSourceTitle(int type)
    {
      if (!this.dstypes.ContainsKey(type))
        return "";
      return this.dstypes[type];
    }

    public string GetDataSourceString(RoadFlow.Data.Model.HomeItems item)
    {
      if (item == null)
        return "";
      switch (item.DataSourceType)
      {
        case 0:
          Guid? dbConnId = item.DBConnID;
          if (!dbConnId.HasValue)
            return "";
          string dataSource = item.DataSource;
          int type = item.Type;
          dbConnId = item.DBConnID;
          Guid dbconnID = dbConnId.Value;
          return this.getSqlString(dataSource, type, dbconnID);
        case 1:
          return this.GetCsharpMethodString(item.DataSource, (object) null);
        case 2:
          return this.GetUrlString(item.DataSource);
        default:
          return "";
      }
    }

    private string getSqlString(string sql, int type, Guid dbconnID)
    {
      switch (type)
      {
        case 0:
          return new DBConnection().GetFieldValue(dbconnID, Wildcard.FilterWildcard(sql, "", (object) null), (IDbDataParameter[]) null);
        case 1:
        case 2:
          DataTable dataTable = new DBConnection().GetDataTable(dbconnID, Wildcard.FilterWildcard(sql, "", (object) null), (IDataParameter[]) null);
          StringBuilder stringBuilder = new StringBuilder();
          stringBuilder.Append("<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" class=\"hometable\"><thead><tr>");
          foreach (DataColumn column in (InternalDataCollectionBase) dataTable.Columns)
            stringBuilder.Append("<th>" + column.ColumnName + "</th>");
          stringBuilder.Append("</tr></thead><tbody>");
          foreach (DataRow row in (InternalDataCollectionBase) dataTable.Rows)
          {
            stringBuilder.Append("<tr>");
            foreach (DataColumn column in (InternalDataCollectionBase) dataTable.Columns)
              stringBuilder.Append("<td>" + row[column.ColumnName].ToString() + "</td>");
            stringBuilder.Append("</tr>");
          }
          stringBuilder.Append("</tbody></table>");
          return stringBuilder.ToString();
        default:
          return "";
      }
    }

    private string GetCsharpMethodString(string method, object param = null)
    {
      object obj = Tools.ExecuteCsharpMethod(method, param);
      if (obj != null)
        return obj.ToString();
      return "";
    }

    public string GetUrlString(string url)
    {
      return HttpHelper.SendGet(url);
    }

    public List<RoadFlow.Data.Model.HomeItems> GetAllByUserID(Guid userID)
    {
      object obj = Opation.Get(this.cacheKey);
      List<RoadFlow.Data.Model.HomeItems> homeItemsList1 = new List<RoadFlow.Data.Model.HomeItems>();
      List<RoadFlow.Data.Model.HomeItems> homeItemsList2;
      if (obj != null && obj is List<RoadFlow.Data.Model.HomeItems>)
      {
        homeItemsList2 = (List<RoadFlow.Data.Model.HomeItems>) obj;
      }
      else
      {
        Organize organize = new Organize();
        homeItemsList2 = this.GetAll();
        foreach (RoadFlow.Data.Model.HomeItems homeItems in homeItemsList2)
          homeItems.UseUsers = organize.GetAllUsersIdString(homeItems.UseOrganizes);
        Opation.Set(this.cacheKey, (object) homeItemsList2);
      }
      return homeItemsList2.FindAll((Predicate<RoadFlow.Data.Model.HomeItems>) (p => p.UseUsers.Contains(userID.ToString(), StringComparison.CurrentCultureIgnoreCase))).OrderBy<RoadFlow.Data.Model.HomeItems, int>((Func<RoadFlow.Data.Model.HomeItems, int>) (p => p.Type)).ThenBy<RoadFlow.Data.Model.HomeItems, int?>((Func<RoadFlow.Data.Model.HomeItems, int?>) (p => p.Sort)).ToList<RoadFlow.Data.Model.HomeItems>();
    }

    public int GetMaxSort(int type)
    {
      return this.dataHomeItems.GetMaxSort(type);
    }

    public void ClearCache()
    {
      Opation.Remove(this.cacheKey);
    }
  }
}
