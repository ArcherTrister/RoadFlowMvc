// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.Interface.IAppLibrarySubPages
// Assembly: RoadFlow.Data.Interface, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2109DD37-8E2D-4F7C-8293-6084646C162F
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.Interface.dll

using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.Interface
{
  public interface IAppLibrarySubPages
  {
    int Add(AppLibrarySubPages model);

    int Update(AppLibrarySubPages model);

    List<AppLibrarySubPages> GetAll();

    AppLibrarySubPages Get(Guid id);

    int Delete(Guid id);

    long GetCount();

    int DeleteByAppID(Guid id);

    List<AppLibrarySubPages> GetAllByAppID(Guid id);
  }
}
