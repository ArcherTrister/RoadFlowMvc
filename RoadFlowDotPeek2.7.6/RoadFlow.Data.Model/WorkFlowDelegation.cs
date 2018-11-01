// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.Model.WorkFlowDelegation
// Assembly: RoadFlow.Data.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B924143B-AEC1-4AFA-B627-1D84458A850C
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.Model.dll

using System;
using System.ComponentModel;

namespace RoadFlow.Data.Model
{
  [Serializable]
  public class WorkFlowDelegation
  {
    [DisplayName("ID")]
    public Guid ID { get; set; }

    [DisplayName("委托人")]
    public Guid UserID { get; set; }

    [DisplayName("开始时间")]
    public DateTime StartTime { get; set; }

    [DisplayName("结束时间")]
    public DateTime EndTime { get; set; }

    [DisplayName("委托流程ID,为空表示所有流程")]
    public Guid? FlowID { get; set; }

    [DisplayName("被委托人")]
    public Guid ToUserID { get; set; }

    [DisplayName("设置时间")]
    public DateTime WriteTime { get; set; }

    [DisplayName("备注说明")]
    public string Note { get; set; }
  }
}
