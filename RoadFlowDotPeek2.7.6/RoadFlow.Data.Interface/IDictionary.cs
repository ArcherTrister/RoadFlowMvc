// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.Interface.IDictionary
// Assembly: RoadFlow.Data.Interface, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2109DD37-8E2D-4F7C-8293-6084646C162F
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.Interface.dll

using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.Interface
{
  public interface IDictionary
  {
    int Add(Dictionary model);

    int Update(Dictionary model);

    List<Dictionary> GetAll();

    Dictionary Get(Guid id);

    int Delete(Guid id);

    long GetCount();

    Dictionary GetRoot();

    List<Dictionary> GetChilds(Guid id);

    List<Dictionary> GetChilds(string code);

    Dictionary GetParent(Guid id);

    bool HasChilds(Guid id);

    int GetMaxSort(Guid id);

    int UpdateSort(Guid id, int sort);

    Dictionary GetByCode(string code);
  }
}
