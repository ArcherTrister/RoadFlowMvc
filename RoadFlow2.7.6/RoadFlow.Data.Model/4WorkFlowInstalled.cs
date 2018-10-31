// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.Model.WorkFlowInstalledSub.Line
// Assembly: RoadFlow.Data.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B924143B-AEC1-4AFA-B627-1D84458A850C
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.Model.dll

using System;

namespace RoadFlow.Data.Model.WorkFlowInstalledSub
{
  public class Line
  {
    public Guid ID { get; set; }

    public Guid FromID { get; set; }

    public Guid ToID { get; set; }

    public string CustomMethod { get; set; }

    public string SqlWhere { get; set; }

    public string NoAccordMsg { get; set; }

    public string Organize { get; set; }
  }
}
