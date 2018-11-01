// Decompiled with JetBrains decompiler
// Type: RoadFlow.Platform.WorkFlowArchives
// Assembly: RoadFlow.Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07F26AFD-DE3B-4003-89AF-01A62494BA58
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Platform.dll

using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;
using System.Data;

namespace RoadFlow.Platform
{
  public class WorkFlowArchives
  {
    private IWorkFlowArchives dataWorkFlowArchives;

    public WorkFlowArchives()
    {
      this.dataWorkFlowArchives = RoadFlow.Data.Factory.Factory.GetWorkFlowArchives();
    }

    public int Add(RoadFlow.Data.Model.WorkFlowArchives model)
    {
      return this.dataWorkFlowArchives.Add(model);
    }

    public int Update(RoadFlow.Data.Model.WorkFlowArchives model)
    {
      return this.dataWorkFlowArchives.Update(model);
    }

    public List<RoadFlow.Data.Model.WorkFlowArchives> GetAll()
    {
      return this.dataWorkFlowArchives.GetAll();
    }

    public RoadFlow.Data.Model.WorkFlowArchives Get(Guid id)
    {
      return this.dataWorkFlowArchives.Get(id);
    }

    public int Delete(Guid id)
    {
      return this.dataWorkFlowArchives.Delete(id);
    }

    public long GetCount()
    {
      return this.dataWorkFlowArchives.GetCount();
    }

    public DataTable GetPagerData(out string pager, string query = "", string title = "", string flowIDString = "")
    {
      return this.dataWorkFlowArchives.GetPagerData(out pager, query, title, flowIDString);
    }

    public DataTable GetPagerData(out long count, int pageSize, int pageNumber, string title = "", string flowIDString = "", string date1 = "", string date2 = "", string order = "")
    {
      return this.dataWorkFlowArchives.GetPagerData(out count, pageSize, pageNumber, title, flowIDString, date1, date2, order);
    }
  }
}
