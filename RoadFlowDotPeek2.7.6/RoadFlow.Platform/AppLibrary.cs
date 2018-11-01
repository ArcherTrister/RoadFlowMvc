// Decompiled with JetBrains decompiler
// Type: RoadFlow.Platform.AppLibrary
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

namespace RoadFlow.Platform
{
  public class AppLibrary
  {
    private string cacheKey = Keys.CacheKeys.AppLibrary.ToString();
    private IAppLibrary dataAppLibrary;

    public AppLibrary()
    {
      this.dataAppLibrary = RoadFlow.Data.Factory.Factory.GetAppLibrary();
    }

    public int Add(RoadFlow.Data.Model.AppLibrary model)
    {
      return this.dataAppLibrary.Add(model);
    }

    public int Update(RoadFlow.Data.Model.AppLibrary model)
    {
      return this.dataAppLibrary.Update(model);
    }

    public List<RoadFlow.Data.Model.AppLibrary> GetAll(bool fromCache = false)
    {
      if (!fromCache)
        return this.dataAppLibrary.GetAll();
      object obj = Opation.Get(this.cacheKey);
      if (obj != null && obj is List<RoadFlow.Data.Model.AppLibrary>)
        return (List<RoadFlow.Data.Model.AppLibrary>) obj;
      List<RoadFlow.Data.Model.AppLibrary> all = this.dataAppLibrary.GetAll();
      Opation.Set(this.cacheKey, (object) all);
      return all;
    }

    public RoadFlow.Data.Model.AppLibrary Get(Guid id, bool fromCache = false)
    {
      if (!fromCache)
        return this.dataAppLibrary.Get(id);
      return this.GetAll(true).Find((Predicate<RoadFlow.Data.Model.AppLibrary>) (p => p.ID == id)) ?? this.dataAppLibrary.Get(id);
    }

    public void ClearCache()
    {
      Opation.Remove(this.cacheKey);
    }

    public int Delete(Guid id)
    {
      return this.dataAppLibrary.Delete(id);
    }

    public long GetCount()
    {
      return this.dataAppLibrary.GetCount();
    }

    public List<RoadFlow.Data.Model.AppLibrary> GetPagerData(out string pager, string query = "", string title = "", string type = "", string address = "")
    {
      return this.dataAppLibrary.GetPagerData(out pager, query, "Type,Title", Tools.GetPageSize(), Tools.GetPageNumber(), title, type, address);
    }

    public List<RoadFlow.Data.Model.AppLibrary> GetPagerData(out long count, int size = 15, int number = 1, string title = "", string type = "", string address = "", string order = "")
    {
      return this.dataAppLibrary.GetPagerData(out count, size, number, title, type, address, order);
    }

    public List<RoadFlow.Data.Model.AppLibrary> GetAllByType(Guid type)
    {
      if (type.IsEmptyGuid())
        return new List<RoadFlow.Data.Model.AppLibrary>();
      return this.dataAppLibrary.GetAllByType(this.GetAllChildsIDString(type, true)).OrderBy<RoadFlow.Data.Model.AppLibrary, string>((Func<RoadFlow.Data.Model.AppLibrary, string>) (p => p.Title)).ToList<RoadFlow.Data.Model.AppLibrary>();
    }

    public int Delete(string[] idArray)
    {
      return this.dataAppLibrary.Delete(idArray);
    }

    public int Delete(string idstring)
    {
      if (idstring.IsNullOrEmpty())
        return 0;
      return this.dataAppLibrary.Delete(idstring.Split(','));
    }

    public string GetTypeOptions(string value = "")
    {
      return new Dictionary().GetOptionsByCode("AppLibraryTypes", Dictionary.OptionValueField.ID, value, "", true);
    }

    public string GetAllChildsIDString(Guid id, bool isSelf = true)
    {
      return new Dictionary().GetAllChildsIDString(id, true);
    }

    public string GetAppsOptions(Guid type, string value = "")
    {
      if (type.IsEmptyGuid())
        return "";
      List<RoadFlow.Data.Model.AppLibrary> allByType = this.GetAllByType(type);
      StringBuilder stringBuilder = new StringBuilder();
      foreach (RoadFlow.Data.Model.AppLibrary appLibrary in allByType)
        stringBuilder.AppendFormat("<option value=\"{0}\" {1}>{2}</option>", (object) appLibrary.ID, string.Compare(appLibrary.ID.ToString(), value, true) == 0 ? (object) "selected=\"selected\"" : (object) "", (object) appLibrary.Title);
      return stringBuilder.ToString();
    }

    public string GetTypeByID(Guid id)
    {
      RoadFlow.Data.Model.AppLibrary appLibrary = this.Get(id, false);
      if (appLibrary != null)
        return appLibrary.Type.ToString();
      return "";
    }

    public RoadFlow.Data.Model.AppLibrary GetByCode(string code, bool formCache = true)
    {
      if (code.IsNullOrEmpty())
        return (RoadFlow.Data.Model.AppLibrary) null;
      if (formCache)
        return this.GetAll(true).Find((Predicate<RoadFlow.Data.Model.AppLibrary>) (p =>
        {
          if (!p.Code.IsNullOrEmpty())
            return p.Code.Equals(code.Trim1(), StringComparison.CurrentCultureIgnoreCase);
          return false;
        })) ?? this.dataAppLibrary.GetByCode(code.Trim1());
      return this.dataAppLibrary.GetByCode(code.Trim1());
    }

    public string GetFlowRunAddress(RoadFlow.Data.Model.AppLibrary app, string query = "")
    {
      StringBuilder stringBuilder = new StringBuilder();
      if (app.Params.IsNullOrEmpty())
      {
        if (!app.Address.Contains("?"))
        {
          stringBuilder.Append(app.Address);
          stringBuilder.Append("?1=1");
        }
      }
      else if (app.Address.Contains("?"))
      {
        stringBuilder.Append(app.Address);
        stringBuilder.Append("&");
        stringBuilder.Append(app.Params.TrimStart('?').TrimStart('&'));
      }
      else
      {
        stringBuilder.Append(app.Address);
        stringBuilder.Append("?");
        stringBuilder.Append(app.Params.TrimStart('?').TrimStart('&'));
      }
      if (!query.IsNullOrEmpty())
      {
        stringBuilder.Append("&");
        stringBuilder.Append(query.TrimStart('?').TrimStart('&'));
      }
      return stringBuilder.ToString();
    }
  }
}
