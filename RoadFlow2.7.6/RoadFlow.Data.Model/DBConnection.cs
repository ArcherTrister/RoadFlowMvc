// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.Model.DBConnection
// Assembly: RoadFlow.Data.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B924143B-AEC1-4AFA-B627-1D84458A850C
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.Model.dll

using System;
using System.ComponentModel;

namespace RoadFlow.Data.Model
{
  [Serializable]
  public class DBConnection
  {
    [DisplayName("ID")]
    public Guid ID { get; set; }

    [DisplayName("连接名称")]
    public string Name { get; set; }

    [DisplayName("连接类型")]
    public string Type { get; set; }

    [DisplayName("连接字符串")]
    public string ConnectionString { get; set; }

    [DisplayName("备注")]
    public string Note { get; set; }
  }
}
