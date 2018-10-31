// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.Model.Organize
// Assembly: RoadFlow.Data.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B924143B-AEC1-4AFA-B627-1D84458A850C
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.Model.dll

using System;
using System.ComponentModel;

namespace RoadFlow.Data.Model
{
  [Serializable]
  public class Organize
  {
    [DisplayName("ID")]
    public Guid ID { get; set; }

    [DisplayName("名称")]
    public string Name { get; set; }

    [DisplayName("编号（包括所有上级ID）")]
    public string Number { get; set; }

    [DisplayName("类型:1 单位 2 部门 3 岗位")]
    public int Type { get; set; }

    [DisplayName("状态  0 正常 1 冻结")]
    public int Status { get; set; }

    [DisplayName("父ID")]
    public Guid ParentID { get; set; }

    [DisplayName("排序")]
    public int Sort { get; set; }

    [DisplayName("深度")]
    public int Depth { get; set; }

    [DisplayName("下级个数")]
    public int ChildsLength { get; set; }

    [DisplayName("分管领导")]
    public string ChargeLeader { get; set; }

    [DisplayName("部门或岗位主管")]
    public string Leader { get; set; }

    [DisplayName("备注")]
    public string Note { get; set; }

    [DisplayName("这里为了其他系统调用，比如微信")]
    public int IntID { get; set; }
  }
}
