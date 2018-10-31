// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.Model.UserShortcut
// Assembly: RoadFlow.Data.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B924143B-AEC1-4AFA-B627-1D84458A850C
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.Model.dll

using System;
using System.ComponentModel;

namespace RoadFlow.Data.Model
{
  [Serializable]
  public class UserShortcut
  {
    [DisplayName("ID")]
    public Guid ID { get; set; }

    [DisplayName("MenuID")]
    public Guid MenuID { get; set; }

    [DisplayName("UserID")]
    public Guid UserID { get; set; }

    [DisplayName("Sort")]
    public int Sort { get; set; }
  }
}
