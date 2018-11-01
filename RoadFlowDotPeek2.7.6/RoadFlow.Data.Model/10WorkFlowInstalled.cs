// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.Model.WorkFlowInstalledSub.StepSet.Event
// Assembly: RoadFlow.Data.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B924143B-AEC1-4AFA-B627-1D84458A850C
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.Model.dll

using System;

namespace RoadFlow.Data.Model.WorkFlowInstalledSub.StepSet
{
  [Serializable]
  public class Event
  {
    public string SubmitBefore { get; set; }

    public string SubmitAfter { get; set; }

    public string BackBefore { get; set; }

    public string BackAfter { get; set; }

    public string SubFlowActivationBefore { get; set; }

    public string SubFlowCompletedBefore { get; set; }
  }
}
