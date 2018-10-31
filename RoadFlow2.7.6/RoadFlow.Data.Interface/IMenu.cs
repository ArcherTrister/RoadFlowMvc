// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.Interface.IMenu
// Assembly: RoadFlow.Data.Interface, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2109DD37-8E2D-4F7C-8293-6084646C162F
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.Interface.dll

using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace RoadFlow.Data.Interface
{
  public interface IMenu
  {
    int Add(Menu model);

    int Update(Menu model);

    List<Menu> GetAll();

    Menu Get(Guid id);

    int Delete(Guid id);

    long GetCount();

    DataTable GetAllDataTable();

    List<Menu> GetChild(Guid id);

    bool HasChild(Guid id);

    int UpdateSort(Guid id, int sort);

    int GetMaxSort(Guid id);

    List<Menu> GetAllByApplibaryID(Guid applibaryID);
  }
}
