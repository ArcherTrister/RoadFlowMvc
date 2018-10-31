// Decompiled with JetBrains decompiler
// Type: RoadFlow.Platform.Documents
// Assembly: RoadFlow.Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07F26AFD-DE3B-4003-89AF-01A62494BA58
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Platform.dll

using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;
using System.Data;

namespace RoadFlow.Platform
{
  public class Documents
  {
    private IDocuments dataDocuments;

    public Documents()
    {
      this.dataDocuments = RoadFlow.Data.Factory.Factory.GetDocuments();
    }

    public int Add(RoadFlow.Data.Model.Documents model)
    {
      return this.dataDocuments.Add(model);
    }

    public int Update(RoadFlow.Data.Model.Documents model)
    {
      return this.dataDocuments.Update(model);
    }

    public List<RoadFlow.Data.Model.Documents> GetAll()
    {
      return this.dataDocuments.GetAll();
    }

    public RoadFlow.Data.Model.Documents Get(Guid id)
    {
      return this.dataDocuments.Get(id);
    }

    public int Delete(Guid id)
    {
      return this.dataDocuments.Delete(id);
    }

    public long GetCount()
    {
      return this.dataDocuments.GetCount();
    }

    public DataTable GetList(out string pager, string dirID, string userID, string query = "", string title = "", string date1 = "", string date2 = "", bool isNoRead = false)
    {
      return this.dataDocuments.GetList(out pager, dirID, userID, query, title, date1, date2, isNoRead);
    }

    public DataTable GetList(out long count, int size, int number, string dirID, string userID, string title = "", string date1 = "", string date2 = "", bool isNoRead = false, string order = "")
    {
      return this.dataDocuments.GetList(out count, size, number, dirID, userID, title, date1, date2, isNoRead, order);
    }

    public void UpdateReadCount(Guid id)
    {
      this.dataDocuments.UpdateReadCount(id);
    }

    public int DeleteByDirectoryID(Guid directoryID)
    {
      return this.dataDocuments.DeleteByDirectoryID(directoryID);
    }
  }
}
