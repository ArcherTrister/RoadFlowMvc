// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.Model.MenuUser
// Assembly: RoadFlow.Data.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B924143B-AEC1-4AFA-B627-1D84458A850C
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.Model.dll

using System;
using System.ComponentModel;

namespace RoadFlow.Data.Model
{
  [Serializable]
  public class MenuUser
  {
    [DisplayName("ID")]
    public Guid ID { get; set; }

    [DisplayName("菜单ID")]
    public Guid MenuID { get; set; }

    [DisplayName("可使用的子页面")]
    public Guid SubPageID { get; set; }

    [DisplayName("使用对象（组织机构ID）")]
    public string Organizes { get; set; }

    [DisplayName("Users")]
    public string Users { get; set; }

    [DisplayName("可使用的按钮")]
    public string Buttons { get; set; }

    [DisplayName("参数")]
    public string Params { get; set; }
  }
}
