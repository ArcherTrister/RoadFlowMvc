﻿// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.Model.AppLibrarySubPages
// Assembly: RoadFlow.Data.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B924143B-AEC1-4AFA-B627-1D84458A850C
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.Model.dll

using System;
using System.ComponentModel;

namespace RoadFlow.Data.Model
{
  [Serializable]
  public class AppLibrarySubPages
  {
    [DisplayName("ID")]
    public Guid ID { get; set; }

    [DisplayName("AppLibraryID")]
    public Guid AppLibraryID { get; set; }

    [DisplayName("Name")]
    public string Name { get; set; }

    [DisplayName("Address")]
    public string Address { get; set; }

    [DisplayName("Ico")]
    public string Ico { get; set; }

    [DisplayName("Sort")]
    public int Sort { get; set; }

    [DisplayName("Note")]
    public string Note { get; set; }
  }
}
