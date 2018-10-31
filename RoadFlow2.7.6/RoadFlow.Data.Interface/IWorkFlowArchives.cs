// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.Interface.IWorkFlowArchives
// Assembly: RoadFlow.Data.Interface, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2109DD37-8E2D-4F7C-8293-6084646C162F
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.Interface.dll

using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace RoadFlow.Data.Interface
{
  public interface IWorkFlowArchives
  {
    int Add(WorkFlowArchives model);

    int Update(WorkFlowArchives model);

    List<WorkFlowArchives> GetAll();

    WorkFlowArchives Get(Guid id);

    int Delete(Guid id);

    long GetCount();

    DataTable GetPagerData(out string pager, string query = "", string title = "", string flowIDString = "");

    DataTable GetPagerData(out long count, int pageSize, int pageNumber, string title = "", string flowIDString = "", string date1 = "", string date2 = "", string order = "");
  }
}
