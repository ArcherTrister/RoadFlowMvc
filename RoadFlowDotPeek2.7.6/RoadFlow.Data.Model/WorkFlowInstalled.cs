// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.Model.WorkFlowInstalled
// Assembly: RoadFlow.Data.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B924143B-AEC1-4AFA-B627-1D84458A850C
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.Model.dll

using RoadFlow.Data.Model.WorkFlowInstalledSub;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.Model
{
  [Serializable]
  public class WorkFlowInstalled
  {
    public Guid ID { get; set; }

    public string Name { get; set; }

    public string Type { get; set; }

    public int FlowType { get; set; }

    public string Manager { get; set; }

    public string InstanceManager { get; set; }

    public Guid FirstStepID { get; set; }

    public DateTime CreateTime { get; set; }

    public string CreateUser { get; set; }

    public string DesignJSON { get; set; }

    public DateTime InstallTime { get; set; }

    public string InstallUser { get; set; }

    public string RunJSON { get; set; }

    public int Status { get; set; }

    public int RemoveCompleted { get; set; }

    public string Note { get; set; }

    public int Debug { get; set; }

    public List<Users> DebugUsers { get; set; }

    public IEnumerable<RoadFlow.Data.Model.WorkFlowInstalledSub.DataBases> DataBases { get; set; }

    public TitleField TitleField { get; set; }

    public IEnumerable<Step> Steps { get; set; }

    public IEnumerable<Line> Lines { get; set; }
  }
}
