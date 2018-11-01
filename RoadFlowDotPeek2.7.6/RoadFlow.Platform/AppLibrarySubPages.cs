// Decompiled with JetBrains decompiler
// Type: RoadFlow.Platform.AppLibrarySubPages
// Assembly: RoadFlow.Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07F26AFD-DE3B-4003-89AF-01A62494BA58
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Platform.dll

using RoadFlow.Cache.IO;
using RoadFlow.Data.Interface;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;

namespace RoadFlow.Platform
{
  public class AppLibrarySubPages
  {
    private static readonly string cachekey = Keys.CacheKeys.MenuTable.ToString() + "_AppLibrarySubPages";
    private IAppLibrarySubPages dataAppLibrarySubPages;

    public AppLibrarySubPages()
    {
      this.dataAppLibrarySubPages = RoadFlow.Data.Factory.Factory.GetAppLibrarySubPages();
    }

    public int Add(RoadFlow.Data.Model.AppLibrarySubPages model)
    {
      return this.dataAppLibrarySubPages.Add(model);
    }

    public int Update(RoadFlow.Data.Model.AppLibrarySubPages model)
    {
      return this.dataAppLibrarySubPages.Update(model);
    }

    public List<RoadFlow.Data.Model.AppLibrarySubPages> GetAll(bool cache = true)
    {
      if (!cache)
        return this.dataAppLibrarySubPages.GetAll();
      object obj = Opation.Get(AppLibrarySubPages.cachekey);
      if (obj != null && obj is List<RoadFlow.Data.Model.AppLibrarySubPages>)
        return (List<RoadFlow.Data.Model.AppLibrarySubPages>) obj;
      List<RoadFlow.Data.Model.AppLibrarySubPages> all = this.dataAppLibrarySubPages.GetAll();
      Opation.Set(AppLibrarySubPages.cachekey, (object) all);
      return all;
    }

    public RoadFlow.Data.Model.AppLibrarySubPages Get(Guid id)
    {
      return this.dataAppLibrarySubPages.Get(id);
    }

    public int Delete(Guid id)
    {
      return this.dataAppLibrarySubPages.Delete(id);
    }

    public long GetCount()
    {
      return this.dataAppLibrarySubPages.GetCount();
    }

    public int DeleteByAppID(Guid id)
    {
      return this.dataAppLibrarySubPages.DeleteByAppID(id);
    }

    public List<RoadFlow.Data.Model.AppLibrarySubPages> GetAllByAppID(Guid id)
    {
      return this.dataAppLibrarySubPages.GetAllByAppID(id);
    }

    public void ClearCache()
    {
      Opation.Remove(AppLibrarySubPages.cachekey);
    }
  }
}
