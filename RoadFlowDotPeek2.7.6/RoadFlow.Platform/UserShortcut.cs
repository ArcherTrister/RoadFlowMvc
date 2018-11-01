// Decompiled with JetBrains decompiler
// Type: RoadFlow.Platform.UserShortcut
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

namespace RoadFlow.Platform
{
  public class UserShortcut
  {
    private string cacheKey = Keys.CacheKeys.UserShortcut.ToString();
    private IUserShortcut dataUserShortcut;

    public UserShortcut()
    {
      this.dataUserShortcut = RoadFlow.Data.Factory.Factory.GetUserShortcut();
    }

    public int Add(RoadFlow.Data.Model.UserShortcut model)
    {
      return this.dataUserShortcut.Add(model);
    }

    public int Update(RoadFlow.Data.Model.UserShortcut model)
    {
      return this.dataUserShortcut.Update(model);
    }

    public List<RoadFlow.Data.Model.UserShortcut> GetAll(bool fromCache = false)
    {
      if (!fromCache)
        return this.dataUserShortcut.GetAll();
      object obj = Opation.Get(this.cacheKey);
      if (obj != null && obj is List<RoadFlow.Data.Model.UserShortcut>)
        return (List<RoadFlow.Data.Model.UserShortcut>) obj;
      List<RoadFlow.Data.Model.UserShortcut> all = this.dataUserShortcut.GetAll();
      Opation.Set(this.cacheKey, (object) all);
      return all;
    }

    public RoadFlow.Data.Model.UserShortcut Get(Guid id)
    {
      return this.dataUserShortcut.Get(id);
    }

    public int Delete(Guid id)
    {
      return this.dataUserShortcut.Delete(id);
    }

    public long GetCount()
    {
      return this.dataUserShortcut.GetCount();
    }

    public int DeleteByUserID(Guid userID)
    {
      return this.dataUserShortcut.DeleteByUserID(userID);
    }

    public List<RoadFlow.Data.Model.UserShortcut> GetAllByUserID(Guid userID, bool fromCache = false)
    {
      if (!fromCache)
        return this.dataUserShortcut.GetAllByUserID(userID);
      return this.GetAll(true).FindAll((Predicate<RoadFlow.Data.Model.UserShortcut>) (p => p.UserID == userID)).OrderBy<RoadFlow.Data.Model.UserShortcut, int>((Func<RoadFlow.Data.Model.UserShortcut, int>) (p => p.Sort)).ToList<RoadFlow.Data.Model.UserShortcut>();
    }

    public DataTable GetDataTableByUserID(Guid userID)
    {
      return this.dataUserShortcut.GetDataTableByUserID(userID);
    }

    public void ClearCache()
    {
      Opation.Remove(this.cacheKey);
    }

    public int DeleteByMenuID(Guid menuID)
    {
      return this.dataUserShortcut.DeleteByMenuID(menuID);
    }
  }
}
