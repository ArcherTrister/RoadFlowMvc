// Decompiled with JetBrains decompiler
// Type: RoadFlow.Platform.ProgramBuilderExport
// Assembly: RoadFlow.Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07F26AFD-DE3B-4003-89AF-01A62494BA58
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Platform.dll

using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoadFlow.Platform
{
  public class ProgramBuilderExport
  {
    private IProgramBuilderExport dataProgramBuilderExport;

    public ProgramBuilderExport()
    {
      this.dataProgramBuilderExport = RoadFlow.Data.Factory.Factory.GetProgramBuilderExport();
    }

    public int Add(RoadFlow.Data.Model.ProgramBuilderExport model)
    {
      return this.dataProgramBuilderExport.Add(model);
    }

    public int Update(RoadFlow.Data.Model.ProgramBuilderExport model)
    {
      return this.dataProgramBuilderExport.Update(model);
    }

    public List<RoadFlow.Data.Model.ProgramBuilderExport> GetAll()
    {
      return this.dataProgramBuilderExport.GetAll();
    }

    public RoadFlow.Data.Model.ProgramBuilderExport Get(Guid id)
    {
      return this.dataProgramBuilderExport.Get(id);
    }

    public int Delete(Guid id)
    {
      return this.dataProgramBuilderExport.Delete(id);
    }

    public long GetCount()
    {
      return this.dataProgramBuilderExport.GetCount();
    }

    public List<RoadFlow.Data.Model.ProgramBuilderExport> GetAll(Guid programID)
    {
      return this.dataProgramBuilderExport.GetAll(programID);
    }

    public string GetDataTypeOptions(string value)
    {
      System.Collections.Generic.Dictionary<int, string> dictionary = new System.Collections.Generic.Dictionary<int, string>();
      dictionary.Add(0, "常规");
      dictionary.Add(1, "文本");
      dictionary.Add(2, "数字");
      dictionary.Add(3, "日期时间");
      StringBuilder stringBuilder = new StringBuilder();
      foreach (KeyValuePair<int, string> keyValuePair in dictionary)
        stringBuilder.Append("<option value=\"" + dictionary.Keys.ToString() + "\"" + (dictionary.Keys.ToString() == value ? " selected=\"selected\"" : "") + ">" + keyValuePair.Value + "</option>");
      return stringBuilder.ToString();
    }
  }
}
