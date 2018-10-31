// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.Model.OnlineUsers
// Assembly: RoadFlow.Data.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B924143B-AEC1-4AFA-B627-1D84458A850C
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.Model.dll

using System;

namespace RoadFlow.Data.Model
{
  [Serializable]
  public class OnlineUsers
  {
    public Guid ID { get; set; }

    public string UserName { get; set; }

    public string OrgName { get; set; }

    public string IP { get; set; }

    public string ClientInfo { get; set; }

    public string LastPage { get; set; }

    public DateTime LoginTime { get; set; }

    public Guid UniqueID { get; set; }
  }
}
