// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.Model.ProgramBuilderValidates
// Assembly: RoadFlow.Data.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B924143B-AEC1-4AFA-B627-1D84458A850C
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.Model.dll

using System;
using System.ComponentModel;

namespace RoadFlow.Data.Model
{
  [Serializable]
  public class ProgramBuilderValidates
  {
    [DisplayName("ID")]
    public Guid ID { get; set; }

    [DisplayName("ProgramID")]
    public Guid ProgramID { get; set; }

    [DisplayName("表名")]
    public string TableName { get; set; }

    [DisplayName("字段名")]
    public string FieldName { get; set; }

    [DisplayName("字段说明")]
    public string FieldNote { get; set; }

    [DisplayName("验证类型 0不检查 1允许为空,非空时检查 2不允许为空,并检查")]
    public int Validate { get; set; }
  }
}
