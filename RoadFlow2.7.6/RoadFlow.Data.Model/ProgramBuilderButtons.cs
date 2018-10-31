// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.Model.ProgramBuilderButtons
// Assembly: RoadFlow.Data.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B924143B-AEC1-4AFA-B627-1D84458A850C
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.Model.dll

using System;
using System.ComponentModel;

namespace RoadFlow.Data.Model
{
  [Serializable]
  public class ProgramBuilderButtons
  {
    [DisplayName("ID")]
    public Guid ID { get; set; }

    [DisplayName("ProgramID")]
    public Guid ProgramID { get; set; }

    [DisplayName("按钮库ID")]
    public Guid? ButtonID { get; set; }

    [DisplayName("ButtonName")]
    public string ButtonName { get; set; }

    [DisplayName("ClientScript")]
    public string ClientScript { get; set; }

    [DisplayName("Ico")]
    public string Ico { get; set; }

    [DisplayName("显示类型 0工具栏按钮 1普通按钮 2列表按键")]
    public int ShowType { get; set; }

    [DisplayName("Sort")]
    public int Sort { get; set; }

    [DisplayName("IsValidateShow")]
    public int IsValidateShow { get; set; }
  }
}
