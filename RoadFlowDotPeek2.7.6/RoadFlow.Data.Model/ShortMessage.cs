// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.Model.ShortMessage
// Assembly: RoadFlow.Data.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B924143B-AEC1-4AFA-B627-1D84458A850C
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.Model.dll

using System;
using System.ComponentModel;

namespace RoadFlow.Data.Model
{
  [Serializable]
  public class ShortMessage
  {
    [DisplayName("ID")]
    public Guid ID { get; set; }

    [DisplayName("消息标题")]
    public string Title { get; set; }

    [DisplayName("消息内容")]
    public string Contents { get; set; }

    [DisplayName("发送人")]
    public Guid SendUserID { get; set; }

    [DisplayName("发送人姓名")]
    public string SendUserName { get; set; }

    [DisplayName("接收人")]
    public Guid ReceiveUserID { get; set; }

    [DisplayName("接收人姓名")]
    public string ReceiveUserName { get; set; }

    [DisplayName("发送时间")]
    public DateTime SendTime { get; set; }

    [DisplayName("消息连接地址")]
    public string LinkUrl { get; set; }

    [DisplayName("消息对应的ID，如:流程任务ID")]
    public string LinkID { get; set; }

    [DisplayName("0:用户发送消息 1：系统消息")]
    public int Type { get; set; }

    [DisplayName("相关附件")]
    public string Files { get; set; }

    public int Status { get; set; }
  }
}
