// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.Model.WorkFlowExecute.Execute
// Assembly: RoadFlow.Data.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B924143B-AEC1-4AFA-B627-1D84458A850C
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.Model.dll

using System;
using System.Collections.Generic;

namespace RoadFlow.Data.Model.WorkFlowExecute
{
  [Serializable]
  public class Execute
  {
    public Execute()
    {
      this.Steps = new Dictionary<Guid, List<Users>>();
      this.StepCompletedTimes = new Dictionary<Guid, DateTime>();
      this.OtherType = 0;
    }

    public Guid FlowID { get; set; }

    public Guid StepID { get; set; }

    public Guid TaskID { get; set; }

    public string InstanceID { get; set; }

    public Guid GroupID { get; set; }

    public string Title { get; set; }

    public EnumType.ExecuteType ExecuteType { get; set; }

    public Users Sender { get; set; }

    public Dictionary<Guid, List<Users>> Steps { get; set; }

    public Dictionary<Guid, DateTime> StepCompletedTimes { get; set; }

    public string Comment { get; set; }

    public bool IsSign { get; set; }

    public string Note { get; set; }

    public int OtherType { get; set; }

    public string Files { get; set; }
  }
}
