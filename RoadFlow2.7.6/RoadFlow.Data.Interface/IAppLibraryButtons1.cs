// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.Interface.IAppLibraryButtons1
// Assembly: RoadFlow.Data.Interface, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2109DD37-8E2D-4F7C-8293-6084646C162F
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.Interface.dll

using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.Interface
{
  public interface IAppLibraryButtons1
  {
    int Add(AppLibraryButtons1 model);

    int Update(AppLibraryButtons1 model);

    List<AppLibraryButtons1> GetAll();

    AppLibraryButtons1 Get(Guid id);

    int Delete(Guid id);

    long GetCount();

    int DeleteByAppID(Guid id);

    List<AppLibraryButtons1> GetAllByAppID(Guid id);
  }
}
