// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.Model.SMSLog
// Assembly: RoadFlow.Data.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B924143B-AEC1-4AFA-B627-1D84458A850C
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.Model.dll

using System;
using System.ComponentModel;

namespace RoadFlow.Data.Model
{
  [Serializable]
  public class SMSLog
  {
    [DisplayName("ID")]
    public Guid ID { get; set; }

    [DisplayName("手机号码")]
    public string MobileNumber { get; set; }

    [DisplayName("内容")]
    public string Contents { get; set; }

    [DisplayName("发送人ID")]
    public Guid? SendUserID { get; set; }

    [DisplayName("发送人姓名")]
    public string SendUserName { get; set; }

    [DisplayName("发送时间")]
    public DateTime SendTime { get; set; }

    [DisplayName("状态")]
    public int Status { get; set; }

    [DisplayName("备注说明")]
    public string Note { get; set; }
  }
}
