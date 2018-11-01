// Decompiled with JetBrains decompiler
// Type: RoadFlow.Platform.WorkFlowData
// Assembly: RoadFlow.Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07F26AFD-DE3B-4003-89AF-01A62494BA58
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Platform.dll

using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using RoadFlow.Data.Model.WorkFlowInstalledSub;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RoadFlow.Platform
{
  public class WorkFlowData
  {
    private IWorkFlowData dataWorkFlowData;

    public WorkFlowData()
    {
      this.dataWorkFlowData = RoadFlow.Data.Factory.Factory.GetWorkFlowData();
    }

    public int Add(RoadFlow.Data.Model.WorkFlowData model)
    {
      return this.dataWorkFlowData.Add(model);
    }

    public int Update(RoadFlow.Data.Model.WorkFlowData model)
    {
      return this.dataWorkFlowData.Update(model);
    }

    public List<RoadFlow.Data.Model.WorkFlowData> GetAll()
    {
      return this.dataWorkFlowData.GetAll();
    }

    public RoadFlow.Data.Model.WorkFlowData Get(Guid id)
    {
      return this.dataWorkFlowData.Get(id);
    }

    public int Delete(Guid id)
    {
      return this.dataWorkFlowData.Delete(id);
    }

    public long GetCount()
    {
      return this.dataWorkFlowData.GetCount();
    }

    public List<RoadFlow.Data.Model.WorkFlowData> GetAll(Guid instanceID)
    {
      return this.dataWorkFlowData.GetAll(instanceID);
    }

    public string GetFirstPrimaryKeyValue(Guid instanceID)
    {
      List<RoadFlow.Data.Model.WorkFlowData> all = this.GetAll(instanceID);
      if (all.Count <= 0)
        return "";
      return all.First<RoadFlow.Data.Model.WorkFlowData>().Value;
    }

    public string GetLinkFieldValue(string linkString, Guid instanceID)
    {
      string str = "";
      string[] strArray = linkString.Split('.');
      if (strArray.Length == 3)
      {
        List<RoadFlow.Data.Model.WorkFlowData> all = this.GetAll(instanceID);
        System.Collections.Generic.Dictionary<string, string> pkFieldValue = new System.Collections.Generic.Dictionary<string, string>();
        foreach (RoadFlow.Data.Model.WorkFlowData workFlowData in all)
        {
          if (strArray[0].ToGuid() == workFlowData.LinkID && strArray[1] == workFlowData.TableName)
            pkFieldValue.Add(workFlowData.FieldName, workFlowData.Value);
        }
        str = new DBConnection().GetFieldValue(strArray[2], pkFieldValue);
      }
      return str;
    }

    public Guid CreateData(Guid flowID, string pkValue)
    {
      WorkFlowInstalled workFlowRunModel = new WorkFlow().GetWorkFlowRunModel(flowID, true);
      if (workFlowRunModel == null)
        return Guid.Empty;
      IEnumerable<DataBases> dataBases1 = workFlowRunModel.DataBases;
      if (dataBases1.Count<DataBases>() == 0)
        return Guid.Empty;
      DataBases dataBases2 = dataBases1.First<DataBases>();
      WorkFlowData workFlowData1 = new WorkFlowData();
      RoadFlow.Data.Model.WorkFlowData workFlowData2 = new RoadFlow.Data.Model.WorkFlowData();
      workFlowData2.ID = Guid.NewGuid();
      workFlowData2.InstanceID = Guid.NewGuid();
      workFlowData2.LinkID = dataBases2.LinkID;
      workFlowData2.TableName = dataBases2.Table;
      workFlowData2.FieldName = dataBases2.PrimaryKey;
      workFlowData2.Value = pkValue;
      RoadFlow.Data.Model.WorkFlowData model = workFlowData2;
      workFlowData1.Add(model);
      return workFlowData2.InstanceID;
    }
  }
}
