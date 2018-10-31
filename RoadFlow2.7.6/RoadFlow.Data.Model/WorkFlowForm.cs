// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.Model.WorkFlowForm
// Assembly: RoadFlow.Data.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B924143B-AEC1-4AFA-B627-1D84458A850C
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.Model.dll

using System;
using System.ComponentModel;

namespace RoadFlow.Data.Model
{
  [Serializable]
  public class WorkFlowForm
  {
    [DisplayName("ID")]
    public Guid ID { get; set; }

    [DisplayName("表单名称")]
    public string Name { get; set; }

    [DisplayName("表单分类")]
    public Guid Type { get; set; }

    [DisplayName("创建人ID")]
    public Guid CreateUserID { get; set; }

    [DisplayName("创建人姓名")]
    public string CreateUserName { get; set; }

    [DisplayName("创建时间")]
    public DateTime CreateTime { get; set; }

    [DisplayName("最后修改时间")]
    public DateTime LastModifyTime { get; set; }

    [DisplayName("表单html")]
    public string Html { get; set; }

    [DisplayName("从表设置数据")]
    public string SubTableJson { get; set; }

    [DisplayName("事件设置")]
    public string EventsJson { get; set; }

    [DisplayName("相关属性")]
    public string Attribute { get; set; }

    [DisplayName("状态：0 保存 1 编译 2作废")]
    public int Status { get; set; }
  }
}
