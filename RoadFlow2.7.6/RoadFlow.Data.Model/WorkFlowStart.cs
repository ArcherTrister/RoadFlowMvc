// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.Model.WorkFlowStart
// Assembly: RoadFlow.Data.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B924143B-AEC1-4AFA-B627-1D84458A850C
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.Model.dll

using System;

namespace RoadFlow.Data.Model
{
  [Serializable]
  public class WorkFlowStart
  {
    public Guid ID { get; set; }

    public string Name { get; set; }

    public string StartUsers { get; set; }

    public string Type { get; set; }

    public string InstallDate { get; set; }

    public string InstallUserName { get; set; }

    public int OpenMode { get; set; }

    public int WindowWidth { get; set; }

    public int WindowHeight { get; set; }

    public string Params { get; set; }
  }
}
