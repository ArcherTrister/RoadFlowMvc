// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.Model.HomeItems
// Assembly: RoadFlow.Data.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B924143B-AEC1-4AFA-B627-1D84458A850C
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.Model.dll

using System;
using System.ComponentModel;

namespace RoadFlow.Data.Model
{
  [Serializable]
  public class HomeItems
  {
    [DisplayName("ID")]
    public Guid ID { get; set; }

    [DisplayName("模块类型 0上方信息提示模块 1左边模块 2右边模块")]
    public int Type { get; set; }

    [DisplayName("名称")]
    public string Name { get; set; }

    [DisplayName("显示标题")]
    public string Title { get; set; }

    [DisplayName("数据来源 0:sql,1:c#方法 2:url")]
    public int DataSourceType { get; set; }

    [DisplayName("DataSource")]
    public string DataSource { get; set; }

    [DisplayName("图标")]
    public string Ico { get; set; }

    [DisplayName("背景色")]
    public string BgColor { get; set; }

    [DisplayName("字体色")]
    public string Color { get; set; }

    [DisplayName("数据连接ID")]
    public Guid? DBConnID { get; set; }

    [DisplayName("连接地址")]
    public string LinkURL { get; set; }

    [DisplayName("使用对象")]
    public string UseOrganizes { get; set; }

    [DisplayName("使用人员")]
    public string UseUsers { get; set; }

    [DisplayName("排序")]
    public int? Sort { get; set; }

    [DisplayName("备注")]
    public string Note { get; set; }
  }
}
