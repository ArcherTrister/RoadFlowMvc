// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.Model.WorkFlowComment
// Assembly: RoadFlow.Data.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B924143B-AEC1-4AFA-B627-1D84458A850C
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.Model.dll

using System;
using System.ComponentModel;

namespace RoadFlow.Data.Model
{
  [Serializable]
  public class WorkFlowComment
  {
    [DisplayName("ID")]
    public Guid ID { get; set; }

    [DisplayName("使用者")]
    public string MemberID { get; set; }

    [DisplayName("意见")]
    public string Comment { get; set; }

    [DisplayName("类型 0管理员添加 1用户添加")]
    public int Type { get; set; }

    [DisplayName("排序")]
    public int Sort { get; set; }
  }
}
