// Decompiled with JetBrains decompiler
// Type: RoadFlow.Platform.Menu
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
  public class Menu
  {
    private IMenu dataMenu;

    public Menu()
    {
      this.dataMenu = RoadFlow.Data.Factory.Factory.GetMenu();
    }

    public int Add(RoadFlow.Data.Model.Menu model)
    {
      this.ClearAllDataTableCache();
      return this.dataMenu.Add(model);
    }

    public int Update(RoadFlow.Data.Model.Menu model)
    {
      this.ClearAllDataTableCache();
      return this.dataMenu.Update(model);
    }

    public List<RoadFlow.Data.Model.Menu> GetAll()
    {
      return this.dataMenu.GetAll();
    }

    public RoadFlow.Data.Model.Menu Get(Guid id)
    {
      return this.dataMenu.Get(id);
    }

    public DataRow GetFromCache(Guid id)
    {
      DataRow[] dataRowArray = this.GetAllDataTable(true).Select("ID='" + (object) id + "'");
      if (dataRowArray.Length == 0)
        return (DataRow) null;
      return dataRowArray[0];
    }

    public int Delete(Guid id)
    {
      this.ClearAllDataTableCache();
      return this.dataMenu.Delete(id);
    }

    public long GetCount()
    {
      return this.dataMenu.GetCount();
    }

    public void ClearAllDataTableCache()
    {
      Opation.Remove(Keys.CacheKeys.MenuTable.ToString());
    }

    public DataTable GetAllDataTable(bool cache = true)
    {
      if (!cache)
        return this.dataMenu.GetAllDataTable();
      string key = Keys.CacheKeys.MenuTable.ToString();
      object obj = Opation.Get(key);
      if (obj != null && obj is DataTable)
        return (DataTable) obj;
      DataTable allDataTable = this.dataMenu.GetAllDataTable();
      Opation.Set(key, (object) allDataTable);
      return allDataTable;
    }

    public List<RoadFlow.Data.Model.Menu> GetChild(Guid id)
    {
      return this.dataMenu.GetChild(id);
    }

    public bool HasChild(Guid id)
    {
      return this.dataMenu.HasChild(id);
    }

    public int UpdateSort(Guid id, int sort)
    {
      return this.dataMenu.UpdateSort(id, sort);
    }

    public List<RoadFlow.Data.Model.Menu> GetAllChild(Guid id)
    {
      List<RoadFlow.Data.Model.Menu> list = new List<RoadFlow.Data.Model.Menu>();
      foreach (RoadFlow.Data.Model.Menu menu in this.GetChild(id))
      {
        list.Add(menu);
        this.addChilds(list, menu.ID);
      }
      return list;
    }

    private void addChilds(List<RoadFlow.Data.Model.Menu> list, Guid id)
    {
      foreach (RoadFlow.Data.Model.Menu menu in this.GetChild(id))
      {
        list.Add(menu);
        this.addChilds(list, menu.ID);
      }
    }

    public int DeleteAndAllChilds(Guid id)
    {
      List<RoadFlow.Data.Model.Menu> allChild = this.GetAllChild(id);
      int num1 = 0;
      foreach (RoadFlow.Data.Model.Menu menu in allChild)
        num1 += this.Delete(menu.ID);
      int num2 = num1 + this.Delete(id);
      this.ClearAllDataTableCache();
      return num2;
    }

    public int GetMaxSort(Guid id)
    {
      return this.dataMenu.GetMaxSort(id);
    }

    private string getAddress(DataRow dr, string paramsMenuUsers = "")
    {
      string str1 = dr["Address"].ToString().Trim();
      string str2 = dr["Params"].ToString().Trim();
      string str3 = dr["Params1"].ToString().Trim();
      StringBuilder stringBuilder = new StringBuilder();
      if (str2.IsNullOrEmpty() && str3.IsNullOrEmpty() && paramsMenuUsers.IsNullOrEmpty())
        return str1;
      if (!str3.IsNullOrEmpty())
        stringBuilder.Append(str3.TrimStart('?').TrimStart('&').TrimEnd('&').TrimEnd('?'));
      if (!str2.IsNullOrEmpty())
      {
        if (stringBuilder.Length > 0)
          stringBuilder.Append('&');
        stringBuilder.Append(str2.TrimStart('?').TrimStart('&').TrimEnd('&').TrimEnd('?'));
      }
      if (!paramsMenuUsers.IsNullOrEmpty())
      {
        if (stringBuilder.Length > 0)
          stringBuilder.Append('&');
        stringBuilder.Append(paramsMenuUsers.TrimStart('?').TrimStart('&').TrimEnd('&').TrimEnd('?'));
      }
      return (str1.Contains("?") ? str1 + "&" + stringBuilder.ToString() : str1 + "?" + stringBuilder.ToString()).FilterWildcard(Users.CurrentUserID.ToString());
    }

    public string GetUserMenu(Guid userID)
    {
      Menu menu = new Menu();
      AppLibrary appLibrary = new AppLibrary();
      int num = 1;
      DataTable allDataTable = menu.GetAllDataTable(num != 0);
      if (allDataTable.Rows.Count == 0)
        return "";
      StringBuilder stringBuilder1 = new StringBuilder();
      string source = string.Empty;
      List<RoadFlow.Data.Model.MenuUser> all1 = new MenuUser().GetAll(true);
      foreach (RoadFlow.Data.Model.UserShortcut userShortcut in new UserShortcut().GetAllByUserID(userID, true))
      {
        RoadFlow.Data.Model.UserShortcut shortcut = userShortcut;
        string params1 = string.Empty;
        List<RoadFlow.Data.Model.MenuUser> all2 = all1.FindAll((Predicate<RoadFlow.Data.Model.MenuUser>) (p =>
        {
          if (p.MenuID == shortcut.MenuID && p.SubPageID == Guid.Empty)
            return p.Users.Contains(userID.ToString(), StringComparison.CurrentCultureIgnoreCase);
          return false;
        }));
        if (all2.Count > 0)
        {
          StringBuilder stringBuilder2 = new StringBuilder();
          foreach (IGrouping<string, RoadFlow.Data.Model.MenuUser> grouping in all2.FindAll((Predicate<RoadFlow.Data.Model.MenuUser>) (p => !p.Params.IsNullOrEmpty())).GroupBy<RoadFlow.Data.Model.MenuUser, string>((Func<RoadFlow.Data.Model.MenuUser, string>) (p => p.Params)))
          {
            stringBuilder2.Append(grouping.Key.Trim1());
            stringBuilder2.Append("&");
          }
          params1 = stringBuilder2.ToString().TrimEnd('&');
        }
        if (this.HasUse(shortcut.MenuID, userID, all1, out source, out params1, false))
        {
          DataTable dataTable = allDataTable;
          string format = "ID='{0}'";
          Guid guid = shortcut.MenuID;
          string str1 = guid.ToString();
          string filterExpression = string.Format(format, (object) str1);
          DataRow[] dataRowArray1 = dataTable.Select(filterExpression);
          if (dataRowArray1.Length != 0)
          {
            DataRow dr = dataRowArray1[0];
            string str2 = dr["IcoColor"].ToString();
            if (str2.IsNullOrEmpty())
              str2 = dr["IcoColor1"].ToString();
            DataRow[] dataRowArray2 = allDataTable.Select("ParentID='" + dr["ID"].ToString() + "'");
            StringBuilder stringBuilder2 = stringBuilder1;
            string[] strArray = new string[19]{ "<div class=\"menulistdiv\" onclick=\"menuClick(this);\" data-id=\"", dr["ID"].ToString(), "\" data-title=\"", dr["Title"].ToString().Trim(), "\" data-model=\"", dr["OpenMode"].ToString(), "\" data-width=\"", dr["Width"].ToString(), "\" data-height=\"", dr["Height"].ToString(), "\" data-childs=\"", dataRowArray2.Length != 0 ? "1" : "0", "\" data-url=\"", this.getAddress(dr, params1), "\" data-parent=\"", null, null, null, null };
            int index = 15;
            guid = Guid.Empty;
            string str3 = guid.ToString();
            strArray[index] = str3;
            strArray[16] = "\" style=\"";
            strArray[17] = str2.IsNullOrEmpty() ? "" : "color:" + str2.Trim1() + ";";
            strArray[18] = "\">";
            string str4 = string.Concat(strArray);
            stringBuilder2.Append(str4);
            stringBuilder1.Append("<div class=\"menulistdiv1\">");
            string str5 = dr["Ico"].ToString();
            if (str5.IsNullOrEmpty())
              str5 = dr["AppIco"].ToString();
            if (str5.IsNullOrEmpty())
              stringBuilder1.Append("<i class=\"fa fa-list-ul\" style=\"font-size:14px;margin-right:3px;vertical-align:middle\"></i>");
            else if (str5.IsFontIco())
              stringBuilder1.Append("<i class=\"fa " + str5 + "\" style=\"font-size:14px;margin-right:3px;vertical-align:middle\"></i>");
            else
              stringBuilder1.Append("<img src=\"" + Config.BaseUrl + str5 + "\" style=\"vertical-align:middle\" alt=\"\"/>");
            stringBuilder1.Append("<span style=\"vertical-align:middle\">" + dr["Title"].ToString().Trim1() + "</span>");
            stringBuilder1.Append("</div>");
            if (dataRowArray2.Length != 0)
              stringBuilder1.Append("<div class=\"menulistdiv2\"><i class=\"fa fa-angle-left\"></i></div>");
            stringBuilder1.Append("</div>");
          }
        }
      }
      DataTable dataTable1 = allDataTable;
      string format1 = "ParentID='{0}'";
      Guid empty = Guid.Empty;
      string str6 = empty.ToString();
      string filterExpression1 = string.Format(format1, (object) str6);
      DataRow[] dataRowArray3 = dataTable1.Select(filterExpression1);
      if (dataRowArray3.Length == 0)
        return stringBuilder1.ToString();
      foreach (DataRow dataRow1 in allDataTable.Select(string.Format("ParentID='{0}'", (object) dataRowArray3[0]["ID"].ToString())))
      {
        string params1 = string.Empty;
        DataRow dr = dataRow1;
        if (this.HasUse(dr["ID"].ToString().ToGuid(), userID, all1, out source, out params1, false))
        {
          DataRow[] dataRowArray1 = allDataTable.Select("ParentID='" + dr["ID"].ToString() + "'");
          bool flag = false;
          foreach (DataRow dataRow2 in dataRowArray1)
          {
            if (this.HasUse(dataRow2["ID"].ToString().ToGuid(), userID, all1, out source, out params1, false))
            {
              flag = true;
              break;
            }
          }
          string str1 = dr["IcoColor"].ToString();
          if (str1.IsNullOrEmpty())
            str1 = dr["IcoColor1"].ToString();
          StringBuilder stringBuilder2 = stringBuilder1;
          string[] strArray = new string[19]{ "<div class=\"menulistdiv\" onclick=\"menuClick(this);\" data-id=\"", dr["ID"].ToString(), "\" data-title=\"", dr["Title"].ToString().Trim(), "\" data-model=\"", dr["OpenMode"].ToString(), "\" data-width=\"", dr["Width"].ToString(), "\" data-height=\"", dr["Height"].ToString(), "\" data-childs=\"", flag ? "1" : "0", "\" data-url=\"", this.getAddress(dr, params1), "\" data-parent=\"", null, null, null, null };
          int index = 15;
          empty = Guid.Empty;
          string str2 = empty.ToString();
          strArray[index] = str2;
          strArray[16] = "\" style=\"";
          strArray[17] = str1.IsNullOrEmpty() ? "" : "color:" + str1.Trim1() + ";";
          strArray[18] = "\">";
          string str3 = string.Concat(strArray);
          stringBuilder2.Append(str3);
          stringBuilder1.Append("<div class=\"menulistdiv1\">");
          string str4 = dr["Ico"].ToString();
          if (str4.IsNullOrEmpty())
            str4 = dr["AppIco"].ToString();
          if (str4.IsNullOrEmpty())
            stringBuilder1.Append("<i class=\"fa fa-th-list\" style=\"font-size:14px;margin-right:3px;vertical-align:middle\"></i>");
          else if (str4.IsFontIco())
            stringBuilder1.Append("<i class=\"fa " + str4 + "\" style=\"font-size:14px;margin-right:3px;vertical-align:middle\"></i>");
          else
            stringBuilder1.Append("<img src=\"" + Config.BaseUrl + str4 + "\" style=\"vertical-align:middle\" alt=\"\"/>");
          stringBuilder1.Append("<span style=\"vertical-align:middle\">" + dr["Title"].ToString().Trim1() + "</span>");
          stringBuilder1.Append("</div>");
          if (flag)
            stringBuilder1.Append("<div class=\"menulistdiv2\"><i class=\"fa fa-angle-left\"></i></div>");
          stringBuilder1.Append("</div>");
        }
      }
      return stringBuilder1.ToString();
    }

    public string GetUserMenuChilds(Guid userID, Guid refreshID, string rootDir = "", string isrefresh1 = "0")
    {
      StringBuilder stringBuilder1 = new StringBuilder();
      DataTable allDataTable = this.GetAllDataTable(true);
      DataView defaultView = allDataTable.DefaultView;
      defaultView.RowFilter = string.Format("ParentID='{0}'", (object) refreshID);
      defaultView.Sort = "Sort";
      DataTable table = defaultView.ToTable();
      if (table.Rows.Count == 0)
        return "[]";
      StringBuilder stringBuilder2 = new StringBuilder("[", table.Rows.Count * 100);
      List<RoadFlow.Data.Model.MenuUser> all = new MenuUser().GetAll(true);
      string source = string.Empty;
      foreach (DataRow row in (InternalDataCollectionBase) table.Rows)
      {
        string params1 = string.Empty;
        if (this.HasUse(row["ID"].ToString().ToGuid(), userID, all, out source, out params1, false))
        {
          DataRow[] dataRowArray = allDataTable.Select(string.Format("ParentID='{0}'", (object) row["id"].ToString()));
          bool flag = false;
          foreach (DataRow dataRow in dataRowArray)
          {
            if (this.HasUse(dataRow["ID"].ToString().ToGuid(), userID, all, out source, out params1, false))
            {
              flag = true;
              break;
            }
          }
          string str1 = row["IcoColor"].ToString();
          if (str1.IsNullOrEmpty())
            str1 = row["IcoColor1"].ToString();
          stringBuilder1.Append("<div class=\"menulistdiv\" " + ("1" == isrefresh1 ? "data-isrefresh1=\"1\"" : "") + " onclick=\"" + ("1" == isrefresh1 ? "menuClick(this, 1);" : "menuClick(this, 0);") + "\" data-id=\"" + row["ID"].ToString() + "\" data-title=\"" + row["Title"].ToString().Trim() + "\" data-model=\"" + row["OpenMode"].ToString() + "\" data-width=\"" + row["Width"].ToString() + "\" data-height=\"" + row["Height"].ToString() + "\" data-childs=\"" + (flag ? "1" : "0") + "\" data-url=\"" + this.getAddress(row, params1) + "\" data-parent=\"" + refreshID.ToString() + "\" style=\"" + (str1.IsNullOrEmpty() ? "" : "color:" + str1.Trim1() + ";") + "\">");
          stringBuilder1.Append("<div class=\"menulistdiv1\">");
          string str2 = row["Ico"].ToString();
          if (str2.IsNullOrEmpty())
            str2 = row["AppIco"].ToString();
          if (str2.IsNullOrEmpty())
            stringBuilder1.Append("<i class=\"fa fa-file-text-o\" style=\"font-size:14px;margin-right:3px;vertical-align:middle\"></i>");
          else if (str2.IsFontIco())
            stringBuilder1.Append("<i class=\"fa " + str2 + "\" style=\"font-size:14px;margin-right:3px;vertical-align:middle\"></i>");
          else
            stringBuilder1.Append("<img src=\"" + Config.BaseUrl + str2 + "\" style=\"vertical-align:middle\" alt=\"\"/>");
          stringBuilder1.Append("<span style=\"vertical-align:middle\">" + row["Title"].ToString().Trim1() + "</span>");
          stringBuilder1.Append("</div>");
          if (flag)
            stringBuilder1.Append("<div class=\"menulistdiv2\"><i class=\"fa fa-angle-left\"></i></div>");
          stringBuilder1.Append("</div>");
        }
      }
      return stringBuilder1.ToString();
    }

    public string GetUserMenu1(Guid userID)
    {
      Menu menu = new Menu();
      AppLibrary appLibrary = new AppLibrary();
      int num = 1;
      DataTable allDataTable = menu.GetAllDataTable(num != 0);
      if (allDataTable.Rows.Count == 0)
        return "";
      StringBuilder stringBuilder1 = new StringBuilder();
      string source = string.Empty;
      List<RoadFlow.Data.Model.MenuUser> all1 = new MenuUser().GetAll(true);
      foreach (RoadFlow.Data.Model.UserShortcut userShortcut in new UserShortcut().GetAllByUserID(userID, true))
      {
        RoadFlow.Data.Model.UserShortcut shortcut = userShortcut;
        string params1 = string.Empty;
        List<RoadFlow.Data.Model.MenuUser> all2 = all1.FindAll((Predicate<RoadFlow.Data.Model.MenuUser>) (p =>
        {
          if (p.MenuID == shortcut.MenuID && p.SubPageID == Guid.Empty)
            return p.Users.Contains(userID.ToString(), StringComparison.CurrentCultureIgnoreCase);
          return false;
        }));
        if (all2.Count > 0)
        {
          StringBuilder stringBuilder2 = new StringBuilder();
          foreach (IGrouping<string, RoadFlow.Data.Model.MenuUser> grouping in all2.FindAll((Predicate<RoadFlow.Data.Model.MenuUser>) (p => !p.Params.IsNullOrEmpty())).GroupBy<RoadFlow.Data.Model.MenuUser, string>((Func<RoadFlow.Data.Model.MenuUser, string>) (p => p.Params)))
          {
            stringBuilder2.Append(grouping.Key.Trim1());
            stringBuilder2.Append("&");
          }
          params1 = stringBuilder2.ToString().TrimEnd('&');
        }
        if (this.HasUse(shortcut.MenuID, userID, all1, out source, out params1, false))
        {
          DataTable dataTable = allDataTable;
          string format = "ID='{0}'";
          Guid guid = shortcut.MenuID;
          string str1 = guid.ToString();
          string filterExpression = string.Format(format, (object) str1);
          DataRow[] dataRowArray1 = dataTable.Select(filterExpression);
          if (dataRowArray1.Length != 0)
          {
            DataRow dr = dataRowArray1[0];
            string str2 = dr["IcoColor"].ToString();
            if (str2.IsNullOrEmpty())
              str2 = dr["IcoColor1"].ToString();
            DataRow[] dataRowArray2 = allDataTable.Select("ParentID='" + dr["ID"].ToString() + "'");
            StringBuilder stringBuilder2 = stringBuilder1;
            string[] strArray = new string[21]{ "<div class=\"menulistdiv11\" title=\"", dr["Title"].ToString().Trim1(), "\" onclick=\"menuClick1(this);\" data-id=\"", dr["ID"].ToString(), "\" data-title=\"", dr["Title"].ToString().Trim(), "\" data-model=\"", dr["OpenMode"].ToString(), "\" data-width=\"", dr["Width"].ToString(), "\" data-height=\"", dr["Height"].ToString(), "\" data-childs=\"", dataRowArray2.Length != 0 ? "1" : "0", "\" data-url=\"", this.getAddress(dr, params1), "\" data-parent=\"", null, null, null, null };
            int index = 17;
            guid = Guid.Empty;
            string str3 = guid.ToString();
            strArray[index] = str3;
            strArray[18] = "\" style=\"";
            strArray[19] = str2.IsNullOrEmpty() ? "" : "color:" + str2.Trim1() + ";";
            strArray[20] = "\">";
            string str4 = string.Concat(strArray);
            stringBuilder2.Append(str4);
            stringBuilder1.Append("<div class=\"menulistdiv1\">");
            string str5 = dr["Ico"].ToString();
            if (str5.IsNullOrEmpty())
              str5 = dr["AppIco"].ToString();
            if (str5.IsNullOrEmpty())
              stringBuilder1.Append("<i class=\"fa fa-list-ul\" style=\"margin-right:3px;vertical-align:middle\"></i>");
            else if (str5.IsFontIco())
              stringBuilder1.Append("<i class=\"fa " + str5 + "\" style=\"margin-right:3px;vertical-align:middle\"></i>");
            else
              stringBuilder1.Append("<img src=\"" + Config.BaseUrl + str5 + "\" style=\"vertical-align:middle\" alt=\"\"/>");
            stringBuilder1.Append("</div>");
            stringBuilder1.Append("</div>");
          }
        }
      }
      DataTable dataTable1 = allDataTable;
      string format1 = "ParentID='{0}'";
      Guid empty = Guid.Empty;
      string str6 = empty.ToString();
      string filterExpression1 = string.Format(format1, (object) str6);
      DataRow[] dataRowArray3 = dataTable1.Select(filterExpression1);
      if (dataRowArray3.Length == 0)
        return stringBuilder1.ToString();
      foreach (DataRow dataRow1 in allDataTable.Select(string.Format("ParentID='{0}'", (object) dataRowArray3[0]["ID"].ToString())))
      {
        string params1 = string.Empty;
        DataRow dr = dataRow1;
        if (this.HasUse(dr["ID"].ToString().ToGuid(), userID, all1, out source, out params1, false))
        {
          DataRow[] dataRowArray1 = allDataTable.Select("ParentID='" + dr["ID"].ToString() + "'");
          bool flag = false;
          foreach (DataRow dataRow2 in dataRowArray1)
          {
            if (this.HasUse(dataRow2["ID"].ToString().ToGuid(), userID, all1, out source, out params1, false))
            {
              flag = true;
              break;
            }
          }
          string str1 = dr["IcoColor"].ToString();
          if (str1.IsNullOrEmpty())
            str1 = dr["IcoColor1"].ToString();
          StringBuilder stringBuilder2 = stringBuilder1;
          string[] strArray = new string[21]{ "<div class=\"menulistdiv11\" title=\"", dr["Title"].ToString().Trim1(), "\" onclick=\"menuClick1(this);\" data-id=\"", dr["ID"].ToString(), "\" data-title=\"", dr["Title"].ToString().Trim(), "\" data-model=\"", dr["OpenMode"].ToString(), "\" data-width=\"", dr["Width"].ToString(), "\" data-height=\"", dr["Height"].ToString(), "\" data-childs=\"", flag ? "1" : "0", "\" data-url=\"", this.getAddress(dr, params1), "\" data-parent=\"", null, null, null, null };
          int index = 17;
          empty = Guid.Empty;
          string str2 = empty.ToString();
          strArray[index] = str2;
          strArray[18] = "\" style=\"";
          strArray[19] = str1.IsNullOrEmpty() ? "" : "color:" + str1.Trim1() + ";";
          strArray[20] = "\">";
          string str3 = string.Concat(strArray);
          stringBuilder2.Append(str3);
          stringBuilder1.Append("<div class=\"menulistdiv1\">");
          string str4 = dr["Ico"].ToString();
          if (str4.IsNullOrEmpty())
            str4 = dr["AppIco"].ToString();
          if (str4.IsNullOrEmpty())
            stringBuilder1.Append("<i class=\"fa fa-th-list\" style=\"margin-right:3px;vertical-align:middle\"></i>");
          else if (str4.IsFontIco())
            stringBuilder1.Append("<i class=\"fa " + str4 + "\" style=\"margin-right:3px;vertical-align:middle\"></i>");
          else
            stringBuilder1.Append("<img src=\"" + Config.BaseUrl + str4 + "\" style=\"vertical-align:middle\" alt=\"\"/>");
          stringBuilder1.Append("</div>");
          stringBuilder1.Append("</div>");
        }
      }
      return stringBuilder1.ToString();
    }

    public string GetUserMenuJsonString(Guid userID, string rootDir = "", bool showSource = false)
    {
      Menu menu = new Menu();
      AppLibrary appLibrary = new AppLibrary();
      int num = 1;
      DataTable allDataTable = menu.GetAllDataTable(num != 0);
      if (allDataTable.Rows.Count == 0)
        return "[]";
      DataTable dataTable1 = allDataTable;
      string format1 = "ParentID='{0}'";
      Guid guid = Guid.Empty;
      string str1 = guid.ToString();
      string filterExpression1 = string.Format(format1, (object) str1);
      DataRow[] dataRowArray1 = dataTable1.Select(filterExpression1);
      if (dataRowArray1.Length == 0)
        return "[]";
      List<RoadFlow.Data.Model.MenuUser> all1 = new MenuUser().GetAll(true);
      DataRow[] dataRowArray2 = allDataTable.Select(string.Format("ParentID='{0}'", (object) dataRowArray1[0]["ID"].ToString()));
      StringBuilder stringBuilder1 = new StringBuilder("", 1000);
      DataRow dr1 = dataRowArray1[0];
      string empty = string.Empty;
      stringBuilder1.Append("{");
      stringBuilder1.AppendFormat("\"id\":\"{0}\",", (object) dr1["ID"].ToString());
      stringBuilder1.AppendFormat("\"title\":\"{0}\",", (object) dr1["Title"].ToString().Trim());
      stringBuilder1.AppendFormat("\"ico\":\"{0}\",", (object) dr1["AppIco"].ToString());
      stringBuilder1.AppendFormat("\"color\":\"{0}\",", (object) dr1["IcoColor"].ToString());
      stringBuilder1.AppendFormat("\"link\":\"{0}\",", (object) this.getAddress(dr1, "").ToString(), (object) empty);
      stringBuilder1.AppendFormat("\"model\":\"{0}\",", (object) dr1["OpenMode"].ToString());
      stringBuilder1.AppendFormat("\"width\":\"{0}\",", (object) dr1["Width"].ToString());
      stringBuilder1.AppendFormat("\"height\":\"{0}\",", (object) dr1["Height"].ToString());
      stringBuilder1.AppendFormat("\"hasChilds\":\"{0}\",", dataRowArray2.Length != 0 ? (object) "1" : (object) "0");
      stringBuilder1.AppendFormat("\"childs\":[");
      StringBuilder stringBuilder2 = new StringBuilder(dataRowArray2.Length * 100);
      string source = string.Empty;
      if (!showSource)
      {
        List<RoadFlow.Data.Model.UserShortcut> allByUserId = new UserShortcut().GetAllByUserID(userID, true);
        if (allByUserId.Count > 0)
        {
          stringBuilder2.Append("{");
          stringBuilder2.AppendFormat("\"id\":\"{0}\",", (object) Guid.NewGuid());
          stringBuilder2.AppendFormat("\"title\":\"{0}\",", (object) "快捷菜单");
          stringBuilder2.AppendFormat("\"ico\":\"{0}\",", (object) "");
          stringBuilder2.AppendFormat("\"color\":\"{0}\",", (object) "");
          stringBuilder2.AppendFormat("\"link\":\"{0}\",", (object) "");
          stringBuilder2.AppendFormat("\"model\":\"{0}\",", (object) "");
          stringBuilder2.AppendFormat("\"width\":\"{0}\",", (object) "");
          stringBuilder2.AppendFormat("\"height\":\"{0}\",", (object) "");
          stringBuilder2.AppendFormat("\"hasChilds\":\"1\",");
          stringBuilder2.AppendFormat("\"childs\":[");
          StringBuilder stringBuilder3 = new StringBuilder();
          foreach (RoadFlow.Data.Model.UserShortcut userShortcut in allByUserId)
          {
            RoadFlow.Data.Model.UserShortcut shortcut = userShortcut;
            string params1 = string.Empty;
            List<RoadFlow.Data.Model.MenuUser> all2 = all1.FindAll((Predicate<RoadFlow.Data.Model.MenuUser>) (p =>
            {
              if (p.MenuID == shortcut.MenuID && p.SubPageID == Guid.Empty)
                return p.Users.Contains(userID.ToString(), StringComparison.CurrentCultureIgnoreCase);
              return false;
            }));
            if (all2.Count > 0)
            {
              StringBuilder stringBuilder4 = new StringBuilder();
              foreach (IGrouping<string, RoadFlow.Data.Model.MenuUser> grouping in all2.FindAll((Predicate<RoadFlow.Data.Model.MenuUser>) (p => !p.Params.IsNullOrEmpty())).GroupBy<RoadFlow.Data.Model.MenuUser, string>((Func<RoadFlow.Data.Model.MenuUser, string>) (p => p.Params)))
              {
                stringBuilder4.Append(grouping.Key.Trim1());
                stringBuilder4.Append("&");
              }
              params1 = stringBuilder4.ToString().TrimEnd('&');
            }
            if (this.HasUse(shortcut.MenuID, userID, all1, out source, out params1, showSource))
            {
              DataTable dataTable2 = allDataTable;
              string format2 = "ID='{0}'";
              guid = shortcut.MenuID;
              string str2 = guid.ToString();
              string filterExpression2 = string.Format(format2, (object) str2);
              DataRow[] dataRowArray3 = dataTable2.Select(filterExpression2);
              if (dataRowArray3.Length != 0)
              {
                DataRow dr2 = dataRowArray3[0];
                DataRow[] dataRowArray4 = allDataTable.Select("ParentID='" + dr2["ID"].ToString() + "'");
                stringBuilder3.Append("{");
                stringBuilder3.AppendFormat("\"id\":\"{0}\",", (object) dr2["ID"].ToString());
                stringBuilder3.AppendFormat("\"title\":\"{0}\",", (object) dr2["Title"].ToString().Trim1());
                stringBuilder3.AppendFormat("\"ico\":\"{0}\",", (object) dr2["AppIco"].ToString());
                stringBuilder3.AppendFormat("\"color\":\"{0}\",", (object) dr2["IcoColor"].ToString());
                stringBuilder3.AppendFormat("\"link\":\"{0}\",", (object) this.getAddress(dr2, params1));
                stringBuilder3.AppendFormat("\"model\":\"{0}\",", (object) dr2["OpenMode"].ToString());
                stringBuilder3.AppendFormat("\"width\":\"{0}\",", (object) dr2["Width"].ToString());
                stringBuilder3.AppendFormat("\"height\":\"{0}\",", (object) dr2["Height"].ToString());
                stringBuilder3.AppendFormat("\"hasChilds\":\"{0}\",", dataRowArray4.Length != 0 ? (object) "1" : (object) "0");
                stringBuilder3.AppendFormat("\"childs\":[]");
                stringBuilder3.Append("},");
              }
            }
          }
          StringBuilder stringBuilder5 = stringBuilder2;
          string str3;
          if (stringBuilder3.Length <= 0)
            str3 = "";
          else
            str3 = stringBuilder3.ToString().TrimEnd(',');
          stringBuilder5.Append(str3);
          stringBuilder2.Append("]");
          stringBuilder2.Append("}");
          if (dataRowArray2.Length != 0)
            stringBuilder2.Append(",");
        }
      }
      for (int index = 0; index < dataRowArray2.Length; ++index)
      {
        string params1 = string.Empty;
        DataRow dr2 = dataRowArray2[index];
        if (this.HasUse(dr2["ID"].ToString().ToGuid(), userID, all1, out source, out params1, showSource))
        {
          DataRow[] dataRowArray3 = allDataTable.Select("ParentID='" + dr2["ID"].ToString() + "'");
          bool flag = false;
          foreach (DataRow dataRow in dataRowArray3)
          {
            if (this.HasUse(dataRow["ID"].ToString().ToGuid(), userID, all1, out source, out params1, showSource))
            {
              flag = true;
              break;
            }
          }
          stringBuilder2.Append("{");
          stringBuilder2.AppendFormat("\"id\":\"{0}\",", (object) dr2["ID"].ToString());
          stringBuilder2.AppendFormat("\"title\":\"{0}{1}\",", (object) dr2["Title"].ToString().Trim1(), showSource ? (object) ("<span style='margin-left:4px;color:#666;'>[" + source + "]</span>") : (object) "");
          stringBuilder2.AppendFormat("\"ico\":\"{0}\",", (object) dr2["AppIco"].ToString());
          stringBuilder2.AppendFormat("\"color\":\"{0}\",", (object) dr2["IcoColor"].ToString());
          stringBuilder2.AppendFormat("\"link\":\"{0}\",", (object) this.getAddress(dr2, params1));
          stringBuilder2.AppendFormat("\"model\":\"{0}\",", (object) dr2["OpenMode"].ToString());
          stringBuilder2.AppendFormat("\"width\":\"{0}\",", (object) dr2["Width"].ToString());
          stringBuilder2.AppendFormat("\"height\":\"{0}\",", (object) dr2["Height"].ToString());
          stringBuilder2.AppendFormat("\"hasChilds\":\"{0}\",", flag ? (object) "1" : (object) "0");
          stringBuilder2.AppendFormat("\"childs\":[");
          stringBuilder2.Append("]");
          stringBuilder2.Append("}");
          stringBuilder2.Append(",");
        }
      }
      stringBuilder1.Append(stringBuilder2.ToString().TrimEnd(','));
      stringBuilder1.Append("]");
      stringBuilder1.Append("}");
      return stringBuilder1.ToString();
    }

    public string GetUserMenuRefreshJsonString(Guid userID, Guid refreshID, string rootDir = "", bool showSource = false)
    {
      DataTable allDataTable = this.GetAllDataTable(true);
      DataView defaultView = allDataTable.DefaultView;
      defaultView.RowFilter = string.Format("ParentID='{0}'", (object) refreshID);
      defaultView.Sort = "Sort";
      DataTable table = defaultView.ToTable();
      if (table.Rows.Count == 0)
        return "[]";
      StringBuilder stringBuilder = new StringBuilder("[", table.Rows.Count * 100);
      List<RoadFlow.Data.Model.MenuUser> all = new MenuUser().GetAll(true);
      string source = string.Empty;
      foreach (DataRow row in (InternalDataCollectionBase) table.Rows)
      {
        string params1 = string.Empty;
        if (this.HasUse(row["ID"].ToString().ToGuid(), userID, all, out source, out params1, showSource))
        {
          DataRow[] dataRowArray = allDataTable.Select(string.Format("ParentID='{0}'", (object) row["id"].ToString()));
          bool flag = false;
          foreach (DataRow dataRow in dataRowArray)
          {
            if (this.HasUse(dataRow["ID"].ToString().ToGuid(), userID, all, out source, out params1, showSource))
            {
              flag = true;
              break;
            }
          }
          stringBuilder.Append("{");
          stringBuilder.AppendFormat("\"id\":\"{0}\",", (object) row["ID"].ToString());
          stringBuilder.AppendFormat("\"title\":\"{0}{1}\",", (object) row["Title"].ToString().Trim1(), showSource ? (object) ("<span style='margin-left:4px;color:#666;'>[" + source + "]</span>") : (object) "");
          stringBuilder.AppendFormat("\"ico\":\"{0}\",", (object) row["AppIco"].ToString());
          stringBuilder.AppendFormat("\"color\":\"{0}\",", (object) row["IcoColor"].ToString());
          stringBuilder.AppendFormat("\"link\":\"{0}\",", (object) this.getAddress(row, params1));
          stringBuilder.AppendFormat("\"model\":\"{0}\",", (object) row["OpenMode"].ToString());
          stringBuilder.AppendFormat("\"width\":\"{0}\",", (object) row["Width"].ToString());
          stringBuilder.AppendFormat("\"height\":\"{0}\",", (object) row["Height"].ToString());
          stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", flag ? (object) "1" : (object) "0");
          stringBuilder.AppendFormat("\"childs\":[");
          stringBuilder.Append("]");
          stringBuilder.Append("}");
          stringBuilder.Append(",");
        }
      }
      return stringBuilder.ToString().TrimEnd(',') + "]";
    }

    public bool HasUse(Guid menuID, Guid userID, List<RoadFlow.Data.Model.MenuUser> menuusers, out string source, out string params1, bool showSource = false)
    {
      source = string.Empty;
      params1 = string.Empty;
      List<RoadFlow.Data.Model.MenuUser> all = menuusers.FindAll((Predicate<RoadFlow.Data.Model.MenuUser>) (p =>
      {
        if (p.MenuID == menuID && p.SubPageID == Guid.Empty)
          return p.Users.Contains(userID.ToString(), StringComparison.CurrentCultureIgnoreCase);
        return false;
      }));
      if (all.Count <= 0)
        return false;
      StringBuilder stringBuilder1 = new StringBuilder();
      foreach (RoadFlow.Data.Model.MenuUser menuUser in all)
      {
        stringBuilder1.Append(menuUser.Organizes);
        stringBuilder1.Append(",");
        if (!menuUser.Params.IsNullOrEmpty())
          params1 = menuUser.Params;
      }
      Organize organize = new Organize();
      source = organize.GetNames(stringBuilder1.ToString().TrimEnd(','), ",");
      StringBuilder stringBuilder2 = new StringBuilder();
      foreach (IGrouping<string, RoadFlow.Data.Model.MenuUser> grouping in all.FindAll((Predicate<RoadFlow.Data.Model.MenuUser>) (p => !p.Params.IsNullOrEmpty())).GroupBy<RoadFlow.Data.Model.MenuUser, string>((Func<RoadFlow.Data.Model.MenuUser, string>) (p => p.Params)))
      {
        stringBuilder2.Append(grouping.Key.Trim1());
        stringBuilder2.Append("&");
      }
      params1 = stringBuilder2.ToString().TrimEnd('&');
      return true;
    }

    public string GetMenuTreeTableHtml(string orgID, Guid? userId = null)
    {
      DataTable allDataTable = new Menu().GetAllDataTable(true);
      List<RoadFlow.Data.Model.MenuUser> all = new MenuUser().GetAll(true);
      StringBuilder sb = new StringBuilder();
      this.getMenuTreeTableHtml(sb, allDataTable, Guid.Empty, all, orgID, userId);
      return sb.ToString();
    }

    private void getMenuTreeTableHtml(StringBuilder sb, DataTable appDt, Guid parentID, List<RoadFlow.Data.Model.MenuUser> menuUsers, string orgID, Guid? userId = null)
    {
      DataRow[] dataRowArray = appDt.Select("ParentID='" + parentID.ToString() + "'");
      string orgid = orgID;
      foreach (DataRow dataRow in dataRowArray)
      {
        DataRow dr = dataRow;
        string source;
        string params1;
        if (!userId.HasValue || !userId.HasValue || (userId.Value.IsEmptyGuid() || this.HasUse(dr["ID"].ToString().ToGuid(), userId.Value, menuUsers, out source, out params1, false)))
        {
          RoadFlow.Data.Model.MenuUser menuUser1 = menuUsers.Find((Predicate<RoadFlow.Data.Model.MenuUser>) (p =>
          {
            if (p.MenuID == dr["ID"].ToString().ToGuid() && p.SubPageID.IsEmptyGuid())
              return p.Organizes.Contains(orgid, StringComparison.CurrentCultureIgnoreCase);
            return false;
          }));
          string str1 = menuUser1 != null ? " checked=\"checked\"" : "";
          sb.Append("<tr id=\"" + dr["ID"] + "\" data-pid=\"" + dr["ParentID"] + "\">");
          sb.Append("<td>" + dr["Title"] + "</td>");
          if (!dr["Ico"].ToString().IsNullOrEmpty())
            sb.Append("<td><input type=\"hidden\" name=\"apptype\" value=\"0\"/>" + (dr["Ico"].ToString().IsFontIco() ? "<i class=\"fa " + dr["Ico"].ToString() + "\" style=\"font-size:14px;\"></i>" : "<img src=\"" + dr["Ico"] + "\" style=\"vertical-align:middle;\"/>") + "</td>");
          else
            sb.Append("<td><input type=\"hidden\" name=\"apptype\" value=\"0\"/>" + (dr["AppIco"].ToString().IsNullOrEmpty() ? "" : (dr["AppIco"].ToString().IsFontIco() ? "<i class=\"fa " + dr["AppIco"].ToString() + "\" style=\"font-size:14px;\"></i>" : "<img src=\"" + dr["AppIco"] + "\" style=\"vertical-align:middle;\"/>")) + "</td>");
          sb.Append("<td style=\"text-align:center\"><input type=\"checkbox\" " + str1 + " onclick=\"appboxclick(this);\" name=\"menuid\" value=\"" + dr["ID"] + "\"/></td>");
          sb.Append("<td>");
          bool flag = dr["AppLibraryID"].ToString().IsGuid();
          if (flag)
          {
            foreach (RoadFlow.Data.Model.AppLibraryButtons1 appLibraryButtons1 in (IEnumerable<RoadFlow.Data.Model.AppLibraryButtons1>) new AppLibraryButtons1().GetAllByAppID(dr["AppLibraryID"].ToString().ToGuid()).OrderBy<RoadFlow.Data.Model.AppLibraryButtons1, int>((Func<RoadFlow.Data.Model.AppLibraryButtons1, int>) (p => p.ShowType)).ThenBy<RoadFlow.Data.Model.AppLibraryButtons1, int>((Func<RoadFlow.Data.Model.AppLibraryButtons1, int>) (p => p.Sort)))
            {
              string str2 = menuUser1 == null || !menuUser1.Buttons.Contains(appLibraryButtons1.ID.ToString(), StringComparison.CurrentCultureIgnoreCase) ? "" : " checked=\"checked\"";
              sb.Append("<input type=\"checkbox\" " + str2 + " onclick=\"buttonboxclick(this);\" style=\"vertical-align:middle;\" id=\"button_" + dr["ID"] + "_" + (object) appLibraryButtons1.ID + "\" name=\"button_" + dr["ID"] + "\" value=\"" + (object) appLibraryButtons1.ID + "\"/>");
              sb.Append("<label style=\"vertical-align:middle;\" for=\"button_" + dr["ID"] + "_" + (object) appLibraryButtons1.ID + "\">" + appLibraryButtons1.Name + "</label>");
            }
          }
          sb.Append("</td>");
          if (flag)
            sb.Append("<td><input type=\"text\" class=\"mytext\" style=\"width:95%\" value=\"" + (menuUser1 != null ? (object) menuUser1.Params : (object) "") + "\" name=\"params_" + dr["id"] + "\"/></td>");
          else
            sb.Append("<td>&nbsp;</td>");
          sb.Append("</tr>");
          if (flag)
          {
            foreach (RoadFlow.Data.Model.AppLibrarySubPages appLibrarySubPages in (IEnumerable<RoadFlow.Data.Model.AppLibrarySubPages>) new AppLibrarySubPages().GetAllByAppID(dr["AppLibraryID"].ToString().ToGuid()).OrderBy<RoadFlow.Data.Model.AppLibrarySubPages, int>((Func<RoadFlow.Data.Model.AppLibrarySubPages, int>) (p => p.Sort)))
            {
              RoadFlow.Data.Model.AppLibrarySubPages page = appLibrarySubPages;
              RoadFlow.Data.Model.MenuUser menuUser2 = menuUsers.Find((Predicate<RoadFlow.Data.Model.MenuUser>) (p =>
              {
                if (p.MenuID == dr["ID"].ToString().ToGuid() && p.SubPageID == page.ID)
                  return p.Organizes.Contains(orgid, StringComparison.CurrentCultureIgnoreCase);
                return false;
              }));
              string str2 = menuUser2 != null ? " checked=\"checked\"" : "";
              sb.Append("<tr id=\"" + (object) page.ID + "\" data-pid=\"" + dr["ID"] + "\">");
              sb.Append("<td>" + page.Name + "</td>");
              sb.Append("<td><input type=\"hidden\" name=\"apptype\" value=\"1\"/></td>");
              sb.Append("<td style=\"text-align:center\"><input type=\"checkbox\" " + str2 + " onclick=\"appboxclick(this);\" name=\"subpage_" + dr["id"] + "\" value=\"" + (object) page.ID + "\"/></td>");
              sb.Append("<td>");
              foreach (RoadFlow.Data.Model.AppLibraryButtons1 appLibraryButtons1 in (IEnumerable<RoadFlow.Data.Model.AppLibraryButtons1>) new AppLibraryButtons1().GetAllByAppID(page.ID).OrderBy<RoadFlow.Data.Model.AppLibraryButtons1, int>((Func<RoadFlow.Data.Model.AppLibraryButtons1, int>) (p => p.ShowType)).ThenBy<RoadFlow.Data.Model.AppLibraryButtons1, int>((Func<RoadFlow.Data.Model.AppLibraryButtons1, int>) (p => p.Sort)))
              {
                string str3 = menuUser2 == null || !menuUser2.Buttons.Contains(appLibraryButtons1.ID.ToString(), StringComparison.CurrentCultureIgnoreCase) ? "" : " checked=\"checked\"";
                sb.Append("<input type=\"checkbox\" " + str3 + " onclick=\"buttonboxclick(this);\" style=\"vertical-align:middle;\" id=\"button_" + (object) page.ID + "_" + (object) appLibraryButtons1.ID + "\" name=\"button_" + dr["id"] + "_" + (object) page.ID + "\" value=\"" + (object) appLibraryButtons1.ID + "\"/>");
                sb.Append("<label style=\"vertical-align:middle;\" for=\"button_" + (object) page.ID + "_" + (object) appLibraryButtons1.ID + "\">" + appLibraryButtons1.Name + "</label>");
              }
              sb.Append("</td>");
              sb.Append("<td>&nbsp;</td>");
              sb.Append("</tr>");
            }
          }
          this.getMenuTreeTableHtml(sb, appDt, dr["ID"].ToString().ToGuid(), menuUsers, orgID, userId);
        }
      }
    }

    public List<RoadFlow.Data.Model.Menu> GetAllByApplibaryID(Guid applibaryID)
    {
      return this.dataMenu.GetAllByApplibaryID(applibaryID);
    }
  }
}
