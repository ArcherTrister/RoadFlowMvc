// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.Model.UsersRelation
// Assembly: RoadFlow.Data.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B924143B-AEC1-4AFA-B627-1D84458A850C
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.Model.dll

using System;
using System.ComponentModel;

namespace RoadFlow.Data.Model
{
  [Serializable]
  public class UsersRelation
  {
    [DisplayName("人员ID")]
    public Guid UserID { get; set; }

    [DisplayName("组织机构ID")]
    public Guid OrganizeID { get; set; }

    [DisplayName("是否主要岗位/部门")]
    public int IsMain { get; set; }

    [DisplayName("排序")]
    public int Sort { get; set; }
  }
}
