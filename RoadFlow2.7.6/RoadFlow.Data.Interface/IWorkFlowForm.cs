// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.Interface.IWorkFlowForm
// Assembly: RoadFlow.Data.Interface, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2109DD37-8E2D-4F7C-8293-6084646C162F
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.Interface.dll

using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.Interface
{
  public interface IWorkFlowForm
  {
    int Add(WorkFlowForm model);

    int Update(WorkFlowForm model);

    List<WorkFlowForm> GetAll();

    WorkFlowForm Get(Guid id);

    int Delete(Guid id);

    long GetCount();

    List<WorkFlowForm> GetAllByType(string types);

    List<WorkFlowForm> GetPagerData(out string pager, string query = "", string userid = "", string typeid = "", string name = "", int pagesize = 15);

    List<WorkFlowForm> GetPagerData(out long count, int pageSize, int pageNumber, string userid = "", string typeid = "", string name = "", string order = "");
  }
}
