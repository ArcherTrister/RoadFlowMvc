// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.Model.Files
// Assembly: RoadFlow.Data.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B924143B-AEC1-4AFA-B627-1D84458A850C
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.Model.dll

using System;

namespace RoadFlow.Data.Model
{
  public class Files
  {
    public string Name { get; set; }

    public string FullName { get; set; }

    public int Type { get; set; }

    public DateTime CreateTime { get; set; }

    public DateTime ModifyTime { get; set; }

    public Decimal? Length { get; set; }

    public int? FileLength { get; set; }
  }
}
