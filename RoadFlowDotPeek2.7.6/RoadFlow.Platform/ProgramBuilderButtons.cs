// Decompiled with JetBrains decompiler
// Type: RoadFlow.Platform.ProgramBuilderButtons
// Assembly: RoadFlow.Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07F26AFD-DE3B-4003-89AF-01A62494BA58
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Platform.dll

using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;

namespace RoadFlow.Platform
{
  public class ProgramBuilderButtons
  {
    private IProgramBuilderButtons dataProgramBuilderButtons;

    public ProgramBuilderButtons()
    {
      this.dataProgramBuilderButtons = RoadFlow.Data.Factory.Factory.GetProgramBuilderButtons();
    }

    public int Add(RoadFlow.Data.Model.ProgramBuilderButtons model)
    {
      return this.dataProgramBuilderButtons.Add(model);
    }

    public int Update(RoadFlow.Data.Model.ProgramBuilderButtons model)
    {
      return this.dataProgramBuilderButtons.Update(model);
    }

    public List<RoadFlow.Data.Model.ProgramBuilderButtons> GetAll()
    {
      return this.dataProgramBuilderButtons.GetAll();
    }

    public RoadFlow.Data.Model.ProgramBuilderButtons Get(Guid id)
    {
      return this.dataProgramBuilderButtons.Get(id);
    }

    public int Delete(Guid id)
    {
      return this.dataProgramBuilderButtons.Delete(id);
    }

    public long GetCount()
    {
      return this.dataProgramBuilderButtons.GetCount();
    }

    public List<RoadFlow.Data.Model.ProgramBuilderButtons> GetAll(Guid programID)
    {
      return this.dataProgramBuilderButtons.GetAll(programID);
    }
  }
}
