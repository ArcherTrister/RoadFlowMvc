// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.Model.WorkFlowInstalledSub.StepSet.Form
// Assembly: RoadFlow.Data.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B924143B-AEC1-4AFA-B627-1D84458A850C
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.Model.dll

using System;

namespace RoadFlow.Data.Model.WorkFlowInstalledSub.StepSet
{
  [Serializable]
  public class Form
  {
    public Guid ID { get; set; }

    public string Name { get; set; }

    public Guid IDApp { get; set; }

    public string NameApp { get; set; }

    public int Sort { get; set; }
  }
}
