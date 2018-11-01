// Decompiled with JetBrains decompiler
// Type: RoadFlow.Platform.AppLibraryButtons1
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
  public class AppLibraryButtons1
  {
    private static readonly string cachekey = Keys.CacheKeys.MenuTable.ToString() + "_AppLibraryButtons1";
    private IAppLibraryButtons1 dataAppLibraryButtons1;

    public AppLibraryButtons1()
    {
      this.dataAppLibraryButtons1 = RoadFlow.Data.Factory.Factory.GetAppLibraryButtons1();
    }

    public int Add(RoadFlow.Data.Model.AppLibraryButtons1 model)
    {
      return this.dataAppLibraryButtons1.Add(model);
    }

    public int Update(RoadFlow.Data.Model.AppLibraryButtons1 model)
    {
      return this.dataAppLibraryButtons1.Update(model);
    }

    public List<RoadFlow.Data.Model.AppLibraryButtons1> GetAll(bool cache = true)
    {
      if (!cache)
        return this.dataAppLibraryButtons1.GetAll();
      object obj = Opation.Get(AppLibraryButtons1.cachekey);
      if (obj != null && obj is List<RoadFlow.Data.Model.AppLibraryButtons1>)
        return (List<RoadFlow.Data.Model.AppLibraryButtons1>) obj;
      List<RoadFlow.Data.Model.AppLibraryButtons1> all = this.dataAppLibraryButtons1.GetAll();
      Opation.Set(AppLibraryButtons1.cachekey, (object) all);
      return all;
    }

    public RoadFlow.Data.Model.AppLibraryButtons1 Get(Guid id, bool cache = false)
    {
      if (!cache)
        return this.dataAppLibraryButtons1.Get(id);
      return this.GetAll(true).Find((Predicate<RoadFlow.Data.Model.AppLibraryButtons1>) (p => p.ID == id));
    }

    public int Delete(Guid id)
    {
      return this.dataAppLibraryButtons1.Delete(id);
    }

    public long GetCount()
    {
      return this.dataAppLibraryButtons1.GetCount();
    }

    public int DeleteByAppID(Guid id)
    {
      return this.dataAppLibraryButtons1.DeleteByAppID(id);
    }

    public List<RoadFlow.Data.Model.AppLibraryButtons1> GetAllByAppID(Guid id)
    {
      return this.dataAppLibraryButtons1.GetAllByAppID(id);
    }

    public void ClearCache()
    {
      Opation.Remove(AppLibraryButtons1.cachekey);
    }
  }
}
