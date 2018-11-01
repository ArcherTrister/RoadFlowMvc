// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.Model.ProgramBuilderCache
// Assembly: RoadFlow.Data.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B924143B-AEC1-4AFA-B627-1D84458A850C
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.Model.dll

using System;
using System.Collections.Generic;

namespace RoadFlow.Data.Model
{
  [Serializable]
  public class ProgramBuilderCache
  {
    public ProgramBuilder Program { get; set; }

    public List<ProgramBuilderFields> Fields { get; set; }

    public List<ProgramBuilderQuerys> Querys { get; set; }

    public List<ProgramBuilderButtons> Buttons { get; set; }

    public List<ProgramBuilderValidates> Validates { get; set; }

    public List<ProgramBuilderExport> Export { get; set; }
  }
}
