// Decompiled with JetBrains decompiler
// Type: RoadFlow.Platform.MenuUser
// Assembly: RoadFlow.Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07F26AFD-DE3B-4003-89AF-01A62494BA58
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Platform.dll

using RoadFlow.Cache.IO;
using RoadFlow.Data.Interface;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace RoadFlow.Platform
{
  public class MenuUser
  {
    private static readonly string cachekey = Keys.CacheKeys.MenuTable.ToString() + "_MenuUsers";
    private IMenuUser dataMenuUser;

    public MenuUser()
    {
      this.dataMenuUser = RoadFlow.Data.Factory.Factory.GetMenuUser();
    }

    public int Add(RoadFlow.Data.Model.MenuUser model)
    {
      return this.dataMenuUser.Add(model);
    }

    public int Update(RoadFlow.Data.Model.MenuUser model)
    {
      return this.dataMenuUser.Update(model);
    }

    public List<RoadFlow.Data.Model.MenuUser> GetAll(bool cache = true)
    {
      if (!cache)
      {
        Organize organize = new Organize();
        List<RoadFlow.Data.Model.MenuUser> all = this.dataMenuUser.GetAll();
        foreach (RoadFlow.Data.Model.MenuUser menuUser in all)
          menuUser.Users = organize.GetAllUsersIdString(menuUser.Organizes);
        return all;
      }
      object obj = Opation.Get(MenuUser.cachekey);
      if (obj != null)
        return (List<RoadFlow.Data.Model.MenuUser>) obj;
      Organize organize1 = new Organize();
      List<RoadFlow.Data.Model.MenuUser> all1 = this.dataMenuUser.GetAll();
      foreach (RoadFlow.Data.Model.MenuUser menuUser in all1)
        menuUser.Users = organize1.GetAllUsersIdString(menuUser.Organizes);
      Opation.Set(MenuUser.cachekey, (object) all1);
      return all1;
    }

    public RoadFlow.Data.Model.MenuUser Get(Guid id)
    {
      return this.dataMenuUser.Get(id);
    }

    public int Delete(Guid id)
    {
      return this.dataMenuUser.Delete(id);
    }

    public long GetCount()
    {
      return this.dataMenuUser.GetCount();
    }

    public int DeleteByOrganizes(string organizes)
    {
      return this.dataMenuUser.DeleteByOrganizes(organizes);
    }

    public void ClearCache()
    {
      Opation.Remove(MenuUser.cachekey);
    }

    public void RefreshUsers()
    {
      MenuUser menuUser = new MenuUser();
      Organize organize = new Organize();
      foreach (RoadFlow.Data.Model.MenuUser model in menuUser.GetAll(false))
      {
        model.Users = organize.GetAllUsersIdList(model.Organizes).ToArray().Join1<Guid>(",");
        menuUser.Update(model);
      }
      this.ClearCache();
    }

    public static System.Collections.Generic.Dictionary<int, string> getButtonsHtml(string menuID = "", string subpageID = "", string programID = "")
    {
      Guid menuID1;
      if (menuID.IsNullOrEmpty() || !menuID.IsGuid(out menuID1))
        menuID1 = HttpContext.Current.Request.QueryString["appid"].ToGuid();
      Guid subpageID1;
      if (!subpageID.IsGuid(out subpageID1))
        subpageID1 = HttpContext.Current.Request.QueryString["subpageid"].ToGuid();
      System.Collections.Generic.Dictionary<int, string> dictionary = new System.Collections.Generic.Dictionary<int, string>();
      dictionary.Add(0, "");
      dictionary.Add(1, "");
      dictionary.Add(2, "");
      string str1 = HttpContext.Current.Request.QueryString["applibaryid"];
      List<Guid> guidList = new List<Guid>();
      if (str1.IsGuid())
      {
        foreach (RoadFlow.Data.Model.AppLibraryButtons1 appLibraryButtons1 in new AppLibraryButtons1().GetAllByAppID(str1.ToGuid()).FindAll((Predicate<RoadFlow.Data.Model.AppLibraryButtons1>) (p => p.IsValidateShow == 1)))
          guidList.Add(appLibraryButtons1.ID);
      }
      else
      {
        foreach (RoadFlow.Data.Model.MenuUser menuUser in new MenuUser().GetAll(true).FindAll((Predicate<RoadFlow.Data.Model.MenuUser>) (p =>
        {
          if (p.MenuID == menuID1 && p.SubPageID == subpageID1)
            return p.Users.Contains(Users.CurrentUserID.ToString(), StringComparison.CurrentCultureIgnoreCase);
          return false;
        })))
        {
          string buttons = menuUser.Buttons;
          char[] chArray = new char[1]{ ',' };
          foreach (string str2 in buttons.Split(chArray))
          {
            Guid test;
            if (str2.IsGuid(out test) && !guidList.Contains(test))
              guidList.Add(test);
          }
        }
      }
      List<RoadFlow.Data.Model.AppLibraryButtons1> source = new List<RoadFlow.Data.Model.AppLibraryButtons1>();
      RoadFlow.Data.Model.AppLibrary byCode = new AppLibrary().GetByCode(programID, true);
      if (byCode != null)
        source.AddRange((IEnumerable<RoadFlow.Data.Model.AppLibraryButtons1>) new AppLibraryButtons1().GetAllByAppID(byCode.ID).FindAll((Predicate<RoadFlow.Data.Model.AppLibraryButtons1>) (p => p.IsValidateShow == 0)));
      if (guidList.Count == 0 && source.Count == 0)
        return dictionary;
      StringBuilder stringBuilder1 = new StringBuilder();
      StringBuilder stringBuilder2 = new StringBuilder();
      StringBuilder stringBuilder3 = new StringBuilder();
      AppLibraryButtons1 appLibraryButtons1_1 = new AppLibraryButtons1();
      foreach (Guid id in guidList)
      {
        RoadFlow.Data.Model.AppLibraryButtons1 appLibraryButtons1_2 = appLibraryButtons1_1.Get(id, true);
        if (appLibraryButtons1_2 != null && appLibraryButtons1_2.IsValidateShow != 0)
          source.Add(appLibraryButtons1_2);
      }
      foreach (RoadFlow.Data.Model.AppLibraryButtons1 appLibraryButtons1_2 in (IEnumerable<RoadFlow.Data.Model.AppLibraryButtons1>) source.OrderBy<RoadFlow.Data.Model.AppLibraryButtons1, int>((Func<RoadFlow.Data.Model.AppLibraryButtons1, int>) (p => p.Sort)))
      {
        string userID = Users.CurrentUserID.ToString();
        if (appLibraryButtons1_2.ShowType == 0)
        {
          string str2 = "fun_" + Guid.NewGuid().ToString("N");
          stringBuilder1.Append("<a href=\"javascript:void(0);\" onclick=\"" + str2 + "();return false;\"><span style=\"" + (appLibraryButtons1_2.Ico.IsNullOrEmpty() || appLibraryButtons1_2.Ico.IsFontIco() ? "padding-left:0px;" : "background-image:url(" + Config.BaseUrl + appLibraryButtons1_2.Ico + ");") + "\">" + (appLibraryButtons1_2.Ico.IsNullOrEmpty() || !appLibraryButtons1_2.Ico.IsFontIco() ? "" : "<i class='fa " + appLibraryButtons1_2.Ico + "' style='font-size:14px;vertical-align:middle;margin-right:3px;'></i>") + appLibraryButtons1_2.Name + "</span></a>");
          stringBuilder1.Append("<script type=\"text/javascript\">function " + str2 + "(){" + appLibraryButtons1_2.Events.FilterWildcard(userID) + "}</script>");
        }
        else if (appLibraryButtons1_2.ShowType == 1)
        {
          string str2 = "fun_" + Guid.NewGuid().ToString("N");
          stringBuilder2.Append("<button type=\"button\" " + (appLibraryButtons1_2.Ico.IsNullOrEmpty() ? "style=\"margin-left:6px;\"" : "style=\"margin-left:6px;" + (appLibraryButtons1_2.Ico.IsNullOrEmpty() || appLibraryButtons1_2.Ico.IsFontIco() ? "" : "background-image:url(" + Config.BaseUrl + appLibraryButtons1_2.Ico + ");background-repeat:no-repeat;background-position-y:center;background-position-x:8px;padding-left:28px;") + "\"") + " onclick=\"" + str2 + "();return false;\" class=\"mybutton\">");
          if (!appLibraryButtons1_2.Ico.IsNullOrEmpty() && appLibraryButtons1_2.Ico.IsFontIco())
            stringBuilder2.Append("<i class=\"fa " + appLibraryButtons1_2.Ico + "\" style=\"font-size:14px;vertical-align:middle;margin-right:3px;\"></i>");
          stringBuilder2.Append("<span style=\"vertical-align:middle;\">" + appLibraryButtons1_2.Name + "</span>");
          stringBuilder2.Append("</button>");
          stringBuilder2.Append("<script type=\"text/javascript\">function " + str2 + "(){" + appLibraryButtons1_2.Events.FilterWildcard(userID) + "}</script>");
        }
        else if (appLibraryButtons1_2.ShowType == 2)
        {
          string str2 = "fun_" + Guid.NewGuid().ToString("N");
          stringBuilder3.Append("<a href=\"javascript:void(0);\" onclick=\"" + appLibraryButtons1_2.Events + ";return false;\" " + (appLibraryButtons1_2.Ico.IsNullOrEmpty() ? "style=\"margin-left:0px;\"" : "style=\"margin-left:0px;" + (!appLibraryButtons1_2.Ico.IsFontIco() ? "padding-left:26px;background-image:url(" + Config.BaseUrl + appLibraryButtons1_2.Ico + ");background-repeat:no-repeat;background-position-y:center;background-position-x:8px;" : "") + "\"") + ">" + (appLibraryButtons1_2.Ico.IsNullOrEmpty() || !appLibraryButtons1_2.Ico.IsFontIco() ? "" : "<i class='fa " + appLibraryButtons1_2.Ico + "' style='font-size:14px;vertical-align:middle;margin-right:3px;padding-left:10px;'></i>") + appLibraryButtons1_2.Name + "</a>");
        }
      }
      dictionary[0] = stringBuilder1.Length > 0 ? "<div class=\"toolbar\" style=\"margin-top:0; border-top:none 0; position:fixed; top:0; left:0; right:0; margin-left:auto; z-index:999; width:100%; margin-right:auto;\">" + stringBuilder1.ToString() + "</div>" : "";
      dictionary[1] = stringBuilder2.ToString();
      dictionary[2] = stringBuilder3.ToString();
      return dictionary;
    }

    public int DeleteByMenuID(Guid menuID)
    {
      return this.dataMenuUser.DeleteByMenuID(menuID);
    }
  }
}
