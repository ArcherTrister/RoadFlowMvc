// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.Interface.IProgramBuilderQuerys
// Assembly: RoadFlow.Data.Interface, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2109DD37-8E2D-4F7C-8293-6084646C162F
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.Interface.dll

using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.Interface
{
  public interface IProgramBuilderQuerys
  {
    int Add(ProgramBuilderQuerys model);

    int Update(ProgramBuilderQuerys model);

    List<ProgramBuilderQuerys> GetAll();

    ProgramBuilderQuerys Get(Guid id);

    int Delete(Guid id);

    long GetCount();

    List<ProgramBuilderQuerys> GetAll(Guid programID);

    int DeleteByProgramID(Guid id);
  }
}
