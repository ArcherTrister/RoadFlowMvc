// Decompiled with JetBrains decompiler
// Type: RoadFlow.Platform.WorkFlowDelegation
// Assembly: RoadFlow.Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07F26AFD-DE3B-4003-89AF-01A62494BA58
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Platform.dll

using RoadFlow.Cache.IO;
using RoadFlow.Data.Interface;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RoadFlow.Platform
{
  public class WorkFlowDelegation
  {
    private static string cacheKey = Keys.CacheKeys.WorkFlowDelegation.ToString();
    private IWorkFlowDelegation dataWorkFlowDelegation;

    public WorkFlowDelegation()
    {
      this.dataWorkFlowDelegation = RoadFlow.Data.Factory.Factory.GetWorkFlowDelegation();
    }

    public int Add(RoadFlow.Data.Model.WorkFlowDelegation model)
    {
      return this.dataWorkFlowDelegation.Add(model);
    }

    public int Update(RoadFlow.Data.Model.WorkFlowDelegation model)
    {
      return this.dataWorkFlowDelegation.Update(model);
    }

    public List<RoadFlow.Data.Model.WorkFlowDelegation> GetAll()
    {
      return this.dataWorkFlowDelegation.GetAll();
    }

    public RoadFlow.Data.Model.WorkFlowDelegation Get(Guid id)
    {
      return this.dataWorkFlowDelegation.Get(id);
    }

    public int Delete(Guid id)
    {
      return this.dataWorkFlowDelegation.Delete(id);
    }

    public long GetCount()
    {
      return this.dataWorkFlowDelegation.GetCount();
    }

    public List<RoadFlow.Data.Model.WorkFlowDelegation> GetByUserID(Guid userID)
    {
      return this.dataWorkFlowDelegation.GetByUserID(userID);
    }

    public List<RoadFlow.Data.Model.WorkFlowDelegation> GetPagerData(out string pager, string query = "", string userID = "", string startTime = "", string endTime = "")
    {
      return this.dataWorkFlowDelegation.GetPagerData(out pager, query, userID, startTime, endTime);
    }

    public List<RoadFlow.Data.Model.WorkFlowDelegation> GetPagerData(out long count, int pageSize, int pageNumber, string userID = "", string startTime = "", string endTime = "", string order = "")
    {
      return this.dataWorkFlowDelegation.GetPagerData(out count, pageSize, pageNumber, userID, startTime, endTime, order);
    }

    public List<RoadFlow.Data.Model.WorkFlowDelegation> GetNoExpiredList()
    {
      return this.dataWorkFlowDelegation.GetNoExpiredList();
    }

    public void RefreshCache()
    {
      List<RoadFlow.Data.Model.WorkFlowDelegation> noExpiredList = this.GetNoExpiredList();
      Opation.Set(WorkFlowDelegation.cacheKey, (object) noExpiredList);
    }

    public List<RoadFlow.Data.Model.WorkFlowDelegation> GetNoExpiredListFromCache()
    {
      object obj = Opation.Get(WorkFlowDelegation.cacheKey);
      if (obj != null && obj is List<RoadFlow.Data.Model.WorkFlowDelegation>)
        return (List<RoadFlow.Data.Model.WorkFlowDelegation>) obj;
      List<RoadFlow.Data.Model.WorkFlowDelegation> noExpiredList = this.GetNoExpiredList();
      Opation.Set(WorkFlowDelegation.cacheKey, (object) noExpiredList);
      return noExpiredList;
    }

    public Guid GetFlowDelegationByUserID(Guid flowID, Guid userID)
    {
      List<RoadFlow.Data.Model.WorkFlowDelegation> expiredListFromCache = this.GetNoExpiredListFromCache();
      if (expiredListFromCache.Count == 0)
        return Guid.Empty;
      Guid empty = Guid.Empty;
      IEnumerable<RoadFlow.Data.Model.WorkFlowDelegation> source = expiredListFromCache.Where<RoadFlow.Data.Model.WorkFlowDelegation>((Func<RoadFlow.Data.Model.WorkFlowDelegation, bool>) (p =>
      {
        if (p.UserID == userID && (!p.FlowID.HasValue || p.FlowID.Value == Guid.Empty || p.FlowID.Value == flowID) && p.StartTime <= DateTimeNew.Now)
          return p.EndTime >= DateTimeNew.Now;
        return false;
      }));
      Guid userID1 = source.Count<RoadFlow.Data.Model.WorkFlowDelegation>() != 0 ? source.OrderByDescending<RoadFlow.Data.Model.WorkFlowDelegation, DateTime>((Func<RoadFlow.Data.Model.WorkFlowDelegation, DateTime>) (p => p.WriteTime)).First<RoadFlow.Data.Model.WorkFlowDelegation>().ToUserID : Guid.Empty;
      return this.getFlowDelegationByUserID1(flowID, userID1, expiredListFromCache);
    }

    private Guid getFlowDelegationByUserID1(Guid flowID, Guid userID, List<RoadFlow.Data.Model.WorkFlowDelegation> list)
    {
      IEnumerable<RoadFlow.Data.Model.WorkFlowDelegation> source = list.Where<RoadFlow.Data.Model.WorkFlowDelegation>((Func<RoadFlow.Data.Model.WorkFlowDelegation, bool>) (p =>
      {
        if (p.UserID == userID && (!p.FlowID.HasValue || p.FlowID.Value == Guid.Empty || p.FlowID.Value == flowID) && p.StartTime <= DateTimeNew.Now)
          return p.EndTime >= DateTimeNew.Now;
        return false;
      }));
      if (source.Count<RoadFlow.Data.Model.WorkFlowDelegation>() == 0)
        return userID;
      userID = source.OrderByDescending<RoadFlow.Data.Model.WorkFlowDelegation, DateTime>((Func<RoadFlow.Data.Model.WorkFlowDelegation, DateTime>) (p => p.WriteTime)).First<RoadFlow.Data.Model.WorkFlowDelegation>().ToUserID;
      this.getFlowDelegationByUserID1(flowID, userID, list);
      return Guid.Empty;
    }
  }
}
