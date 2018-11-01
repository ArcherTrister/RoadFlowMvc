// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.Interface.IHomeItems
// Assembly: RoadFlow.Data.Interface, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2109DD37-8E2D-4F7C-8293-6084646C162F
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.Interface.dll

using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.Interface
{
  public interface IHomeItems
  {
    int Add(HomeItems model);

    int Update(HomeItems model);

    List<HomeItems> GetAll();

    HomeItems Get(Guid id);

    int Delete(Guid id);

    long GetCount();

    List<HomeItems> GetList(out string pager, string query = "", string name = "", string title = "", string type = "");

    List<HomeItems> GetList(out long count, int size, int number, string name = "", string title = "", string type = "", string order = "");

    int GetMaxSort(int type);
  }
}
