// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.Model.WorkFlowExecute.Result
// Assembly: RoadFlow.Data.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B924143B-AEC1-4AFA-B627-1D84458A850C
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.Model.dll

using System;
using System.Collections.Generic;

namespace RoadFlow.Data.Model.WorkFlowExecute
{
  [Serializable]
  public class Result
  {
    public bool IsSuccess { get; set; }

    public string Messages { get; set; }

    public string DebugMessages { get; set; }

    public object[] Other { get; set; }

    public IEnumerable<WorkFlowTask> NextTasks { get; set; }
  }
}
