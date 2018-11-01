// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.Interface.IOrganize
// Assembly: RoadFlow.Data.Interface, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2109DD37-8E2D-4F7C-8293-6084646C162F
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.Interface.dll

using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.Interface
{
  public interface IOrganize
  {
    int Add(Organize model);

    int Update(Organize model);

    List<Organize> GetAll();

    Organize Get(Guid id);

    int Delete(Guid id);

    long GetCount();

    Organize GetRoot();

    List<Organize> GetChilds(Guid ID);

    int GetMaxSort(Guid id);

    int UpdateChildsLength(Guid id, int length);

    int UpdateSort(Guid id, int sort);

    List<Organize> GetAllParent(string number);

    List<Organize> GetAllChild(string number);
  }
}
