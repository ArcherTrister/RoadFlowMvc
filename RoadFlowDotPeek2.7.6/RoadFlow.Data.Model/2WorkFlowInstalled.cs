// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.Model.WorkFlowInstalledSub.TitleField
// Assembly: RoadFlow.Data.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B924143B-AEC1-4AFA-B627-1D84458A850C
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.Model.dll

using System;

namespace RoadFlow.Data.Model.WorkFlowInstalledSub
{
  [Serializable]
  public class TitleField
  {
    public Guid LinkID { get; set; }

    public string LinkName { get; set; }

    public string Table { get; set; }

    public string Field { get; set; }
  }
}
