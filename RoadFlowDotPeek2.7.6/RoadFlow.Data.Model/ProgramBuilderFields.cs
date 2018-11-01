// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.Model.ProgramBuilderFields
// Assembly: RoadFlow.Data.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B924143B-AEC1-4AFA-B627-1D84458A850C
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.Model.dll

using System;
using System.ComponentModel;

namespace RoadFlow.Data.Model
{
  [Serializable]
  public class ProgramBuilderFields
  {
    [DisplayName("ID")]
    public Guid ID { get; set; }

    [DisplayName("ProgramID")]
    public Guid ProgramID { get; set; }

    [DisplayName("字段")]
    public string Field { get; set; }

    [DisplayName("显示标题")]
    public string ShowTitle { get; set; }

    [DisplayName("对齐方式")]
    public string Align { get; set; }

    [DisplayName("宽度")]
    public string Width { get; set; }

    [DisplayName("0直接输出 1序号 2日期时间 3数字 4数据字典ID显示标题  5组织机构id显示为名称 6自定义 7按钮列")]
    public int ShowType { get; set; }

    [DisplayName("格式化字符串")]
    public string ShowFormat { get; set; }

    [DisplayName("自定义字符串")]
    public string CustomString { get; set; }

    [DisplayName("排序")]
    public int Sort { get; set; }
  }
}
