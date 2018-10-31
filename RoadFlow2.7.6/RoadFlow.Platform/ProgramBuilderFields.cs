// Decompiled with JetBrains decompiler
// Type: RoadFlow.Platform.ProgramBuilderFields
// Assembly: RoadFlow.Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07F26AFD-DE3B-4003-89AF-01A62494BA58
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Platform.dll

using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;

namespace RoadFlow.Platform
{
  public class ProgramBuilderFields
  {
    private IProgramBuilderFields dataProgramBuilderFields;

    public ProgramBuilderFields()
    {
      this.dataProgramBuilderFields = RoadFlow.Data.Factory.Factory.GetProgramBuilderFields();
    }

    public int Add(RoadFlow.Data.Model.ProgramBuilderFields model)
    {
      return this.dataProgramBuilderFields.Add(model);
    }

    public int Update(RoadFlow.Data.Model.ProgramBuilderFields model)
    {
      return this.dataProgramBuilderFields.Update(model);
    }

    public List<RoadFlow.Data.Model.ProgramBuilderFields> GetAll()
    {
      return this.dataProgramBuilderFields.GetAll();
    }

    public RoadFlow.Data.Model.ProgramBuilderFields Get(Guid id)
    {
      return this.dataProgramBuilderFields.Get(id);
    }

    public int Delete(Guid id)
    {
      return this.dataProgramBuilderFields.Delete(id);
    }

    public long GetCount()
    {
      return this.dataProgramBuilderFields.GetCount();
    }

    public List<RoadFlow.Data.Model.ProgramBuilderFields> GetAll(Guid programID)
    {
      return this.dataProgramBuilderFields.GetAll(programID);
    }

    public int DeleteByProgramID(Guid id)
    {
      return this.dataProgramBuilderFields.DeleteByProgramID(id);
    }
  }
}
