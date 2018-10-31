// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.Model.DocumentsReadUsers
// Assembly: RoadFlow.Data.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B924143B-AEC1-4AFA-B627-1D84458A850C
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.Model.dll

using System;
using System.ComponentModel;

namespace RoadFlow.Data.Model
{
  [Serializable]
  public class DocumentsReadUsers
  {
    [DisplayName("DocumentID")]
    public Guid DocumentID { get; set; }

    [DisplayName("UserID")]
    public Guid UserID { get; set; }

    [DisplayName("IsRead")]
    public int IsRead { get; set; }
  }
}
