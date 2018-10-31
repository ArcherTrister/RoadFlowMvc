// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.Interface.IAppLibrary
// Assembly: RoadFlow.Data.Interface, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2109DD37-8E2D-4F7C-8293-6084646C162F
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.Interface.dll

using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.Interface
{
  public interface IAppLibrary
  {
    int Add(AppLibrary model);

    int Update(AppLibrary model);

    List<AppLibrary> GetAll();

    AppLibrary Get(Guid id);

    int Delete(Guid id);

    long GetCount();

    List<AppLibrary> GetPagerData(out string pager, string query = "", string order = "Type,Title", int size = 15, int number = 1, string title = "", string type = "", string address = "");

    List<AppLibrary> GetPagerData(out long count, int size = 15, int number = 1, string title = "", string type = "", string address = "", string order = "");

    List<AppLibrary> GetAllByType(string type);

    int Delete(string[] idArray);

    AppLibrary GetByCode(string code);
  }
}
