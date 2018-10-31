// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.Model.WorkFlowInstalledSub.StepSet.Behavior
// Assembly: RoadFlow.Data.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B924143B-AEC1-4AFA-B627-1D84458A850C
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.Model.dll

using System;

namespace RoadFlow.Data.Model.WorkFlowInstalledSub.StepSet
{
  [Serializable]
  public class Behavior
  {
    public int FlowType { get; set; }

    public int RunSelect { get; set; }

    public int HandlerType { get; set; }

    public string SelectRange { get; set; }

    public Guid HandlerStepID { get; set; }

    public string ValueField { get; set; }

    public string DefaultHandler { get; set; }

    public int BackModel { get; set; }

    public int HanlderModel { get; set; }

    public int BackType { get; set; }

    public Decimal Percentage { get; set; }

    public Guid BackStepID { get; set; }

    public int Countersignature { get; set; }

    public Decimal CountersignaturePercentage { get; set; }

    public int SubFlowStrategy { get; set; }

    public string CopyFor { get; set; }

    public int ConcurrentModel { get; set; }

    public string DefaultHandlerSqlOrMethod { get; set; }
  }
}
