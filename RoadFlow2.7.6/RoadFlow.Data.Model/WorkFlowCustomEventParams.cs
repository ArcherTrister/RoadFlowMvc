// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.Model.WorkFlowCustomEventParams
// Assembly: RoadFlow.Data.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B924143B-AEC1-4AFA-B627-1D84458A850C
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.Model.dll

using System;

namespace RoadFlow.Data.Model
{
  [Serializable]
  public struct WorkFlowCustomEventParams
  {
    public Guid FlowID { get; set; }

    public Guid StepID { get; set; }

    public Guid GroupID { get; set; }

    public Guid TaskID { get; set; }

    public string InstanceID { get; set; }

    public object Other { get; set; }
  }
}
