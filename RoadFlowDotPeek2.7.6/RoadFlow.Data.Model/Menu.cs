// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.Model.Menu
// Assembly: RoadFlow.Data.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B924143B-AEC1-4AFA-B627-1D84458A850C
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.Model.dll

using System;
using System.ComponentModel;

namespace RoadFlow.Data.Model
{
  [Serializable]
  public class Menu
  {
    [DisplayName("ID")]
    public Guid ID { get; set; }

    [DisplayName("ParentID")]
    public Guid ParentID { get; set; }

    [DisplayName("AppLibraryID")]
    public Guid? AppLibraryID { get; set; }

    [DisplayName("Title")]
    public string Title { get; set; }

    [DisplayName("Params")]
    public string Params { get; set; }

    [DisplayName("Ico")]
    public string Ico { get; set; }

    [DisplayName("Sort")]
    public int Sort { get; set; }

    [DisplayName("IcoColor")]
    public string IcoColor { get; set; }
  }
}
