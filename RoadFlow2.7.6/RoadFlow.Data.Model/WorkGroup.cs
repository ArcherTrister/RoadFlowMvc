// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.Model.WorkGroup
// Assembly: RoadFlow.Data.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B924143B-AEC1-4AFA-B627-1D84458A850C
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.Model.dll

using System;
using System.ComponentModel;

namespace RoadFlow.Data.Model
{
  [Serializable]
  public class WorkGroup
  {
    [DisplayName("ID")]
    public Guid ID { get; set; }

    [DisplayName("工作组名称")]
    public string Name { get; set; }

    [DisplayName("工作组成员")]
    public string Members { get; set; }

    [DisplayName("备注")]
    public string Note { get; set; }

    [DisplayName("数字ID，用于微信")]
    public int IntID { get; set; }
  }
}
