// Decompiled with JetBrains decompiler
// Type: RoadFlow.Platform.WorkFlowButtons
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
  public class WorkFlowButtons
  {
    private IWorkFlowButtons dataWorkFlowButtons;

    public WorkFlowButtons()
    {
      this.dataWorkFlowButtons = RoadFlow.Data.Factory.Factory.GetWorkFlowButtons();
    }

    public int Add(RoadFlow.Data.Model.WorkFlowButtons model)
    {
      return this.dataWorkFlowButtons.Add(model);
    }

    public int Update(RoadFlow.Data.Model.WorkFlowButtons model)
    {
      return this.dataWorkFlowButtons.Update(model);
    }

    public List<RoadFlow.Data.Model.WorkFlowButtons> GetAll(bool fromCache = false)
    {
      if (!fromCache)
        return this.dataWorkFlowButtons.GetAll();
      string key = Keys.CacheKeys.WorkFlowButtons.ToString();
      object obj = Opation.Get(key);
      if (obj != null && obj is List<RoadFlow.Data.Model.WorkFlowButtons>)
        return (List<RoadFlow.Data.Model.WorkFlowButtons>) obj;
      List<RoadFlow.Data.Model.WorkFlowButtons> all = this.dataWorkFlowButtons.GetAll();
      Opation.Set(key, (object) all);
      return all;
    }

    public RoadFlow.Data.Model.WorkFlowButtons Get(Guid id, bool fromCache = false)
    {
      if (fromCache)
        return this.GetAll(true).Find((Predicate<RoadFlow.Data.Model.WorkFlowButtons>) (p => p.ID == id)) ?? this.dataWorkFlowButtons.Get(id);
      return this.dataWorkFlowButtons.Get(id);
    }

    public int Delete(Guid id)
    {
      return this.dataWorkFlowButtons.Delete(id);
    }

    public long GetCount()
    {
      return this.dataWorkFlowButtons.GetCount();
    }

    public void ClearCache()
    {
      Opation.Remove(Keys.CacheKeys.WorkFlowButtons.ToString());
    }

    public int GetMaxSort()
    {
      return this.dataWorkFlowButtons.GetMaxSort();
    }
  }
}
