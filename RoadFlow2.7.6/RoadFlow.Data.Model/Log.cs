// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.Model.Log
// Assembly: RoadFlow.Data.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B924143B-AEC1-4AFA-B627-1D84458A850C
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.Model.dll

using System;
using System.ComponentModel;

namespace RoadFlow.Data.Model
{
  [Serializable]
  public class Log
  {
    [DisplayName("ID")]
    public Guid ID { get; set; }

    [DisplayName("标题")]
    public string Title { get; set; }

    [DisplayName("类型")]
    public string Type { get; set; }

    [DisplayName("写入时间")]
    public DateTime WriteTime { get; set; }

    [DisplayName("用户ID")]
    public Guid? UserID { get; set; }

    [DisplayName("用户姓名")]
    public string UserName { get; set; }

    [DisplayName("IP")]
    public string IPAddress { get; set; }

    [DisplayName("发生URL")]
    public string URL { get; set; }

    [DisplayName("内容")]
    public string Contents { get; set; }

    [DisplayName("其它")]
    public string Others { get; set; }

    [DisplayName("更改前")]
    public string OldXml { get; set; }

    [DisplayName("更改后")]
    public string NewXml { get; set; }
  }
}
