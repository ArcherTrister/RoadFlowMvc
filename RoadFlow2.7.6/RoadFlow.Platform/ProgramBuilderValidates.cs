// Decompiled with JetBrains decompiler
// Type: RoadFlow.Platform.ProgramBuilderValidates
// Assembly: RoadFlow.Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07F26AFD-DE3B-4003-89AF-01A62494BA58
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Platform.dll

using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;

namespace RoadFlow.Platform
{
  public class ProgramBuilderValidates
  {
    private IProgramBuilderValidates dataProgramBuilderValidates;

    public ProgramBuilderValidates()
    {
      this.dataProgramBuilderValidates = RoadFlow.Data.Factory.Factory.GetProgramBuilderValidates();
    }

    public int Add(RoadFlow.Data.Model.ProgramBuilderValidates model)
    {
      return this.dataProgramBuilderValidates.Add(model);
    }

    public int Update(RoadFlow.Data.Model.ProgramBuilderValidates model)
    {
      return this.dataProgramBuilderValidates.Update(model);
    }

    public List<RoadFlow.Data.Model.ProgramBuilderValidates> GetAll()
    {
      return this.dataProgramBuilderValidates.GetAll();
    }

    public RoadFlow.Data.Model.ProgramBuilderValidates Get(Guid id)
    {
      return this.dataProgramBuilderValidates.Get(id);
    }

    public int Delete(Guid id)
    {
      return this.dataProgramBuilderValidates.Delete(id);
    }

    public long GetCount()
    {
      return this.dataProgramBuilderValidates.GetCount();
    }

    public List<RoadFlow.Data.Model.ProgramBuilderValidates> GetAll(Guid programID)
    {
      return this.dataProgramBuilderValidates.GetAll(programID);
    }

    public int DeleteByProgramID(Guid id)
    {
      return this.dataProgramBuilderValidates.DeleteByProgramID(id);
    }
  }
}
