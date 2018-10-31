// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.Model.ProgramBuilder
// Assembly: RoadFlow.Data.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B924143B-AEC1-4AFA-B627-1D84458A850C
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.Model.dll

using System;
using System.ComponentModel;

namespace RoadFlow.Data.Model
{
  [Serializable]
  public class ProgramBuilder
  {
    [DisplayName("ID")]
    public Guid ID { get; set; }

    [DisplayName("应用名称")]
    public string Name { get; set; }

    [DisplayName("分类")]
    public Guid Type { get; set; }

    [DisplayName("创建时间")]
    public DateTime CreateTime { get; set; }

    [DisplayName("发布时间")]
    public DateTime? PublishTime { get; set; }

    [DisplayName("创建人")]
    public Guid CreateUser { get; set; }

    [DisplayName("查询SQL")]
    public string SQL { get; set; }

    [DisplayName("是否显示新增按钮")]
    public int IsAdd { get; set; }

    [DisplayName("数据连接ID")]
    public Guid DBConnID { get; set; }

    [DisplayName("状态 0设计中 1已发布 2已作废")]
    public int Status { get; set; }

    [DisplayName("表单ID")]
    public string FormID { get; set; }

    [DisplayName("编辑模式 0，当前窗口 1，弹出层")]
    public int? EditModel { get; set; }

    [DisplayName("弹出层宽度")]
    public string Width { get; set; }

    [DisplayName("弹出层高度")]
    public string Height { get; set; }

    [DisplayName("按钮显示位置")]
    public int? ButtonLocation { get; set; }

    [DisplayName("是否分页")]
    public int? IsPager { get; set; }

    [DisplayName("页面脚本")]
    public string ClientScript { get; set; }

    [DisplayName("导出EXCEL模板")]
    public string ExportTemplate { get; set; }

    [DisplayName("导出Excel表头")]
    public string ExportHeaderText { get; set; }

    [DisplayName("导出EXCLE的文件名")]
    public string ExportFileName { get; set; }

    [DisplayName("导出EXCLE的文件名")]
    public string TableStyle { get; set; }

    [DisplayName("列表表头HTML")]
    public string TableHead { get; set; }

    [DisplayName("程序设计对应的表(用于数据导入时)")]
    public string TableName { get; set; }

    [DisplayName("导入EXCEL数据时的标识字段，每次导入生成一个编号区分")]
    public string InDataNumberFiledName { get; set; }
  }
}
