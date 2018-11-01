// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.Model.WorkTime
// Assembly: RoadFlow.Data.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B924143B-AEC1-4AFA-B627-1D84458A850C
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.Model.dll

using System;
using System.ComponentModel;

namespace RoadFlow.Data.Model
{
  [Serializable]
  public class WorkTime
  {
    [DisplayName("ID")]
    public Guid ID { get; set; }

    [DisplayName("年份")]
    public int Year { get; set; }

    [DisplayName("开始时间")]
    public DateTime Date1 { get; set; }

    [DisplayName("结束时间")]
    public DateTime Date2 { get; set; }

    [DisplayName("上午上班时间")]
    public string AmTime1 { get; set; }

    [DisplayName("上午下班时间")]
    public string AmTime2 { get; set; }

    [DisplayName("下午上班时间")]
    public string PmTime1 { get; set; }

    [DisplayName("下午下班时间")]
    public string PmTime2 { get; set; }
  }
}
