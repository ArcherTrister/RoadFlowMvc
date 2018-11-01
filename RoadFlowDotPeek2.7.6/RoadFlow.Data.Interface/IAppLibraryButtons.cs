// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.Interface.IAppLibraryButtons
// Assembly: RoadFlow.Data.Interface, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2109DD37-8E2D-4F7C-8293-6084646C162F
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.Interface.dll

using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.Interface
{
  public interface IAppLibraryButtons
  {
    int Add(AppLibraryButtons model);

    int Update(AppLibraryButtons model);

    List<AppLibraryButtons> GetAll();

    AppLibraryButtons Get(Guid id);

    int Delete(Guid id);

    long GetCount();

    List<AppLibraryButtons> GetPagerData(out string pager, string query = "", int size = 15, int number = 1, string title = "");

    List<AppLibraryButtons> GetPagerData(out long count, int size, int number, string title = "", string order = "");

    int GetMaxSort();
  }
}
