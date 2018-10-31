// Decompiled with JetBrains decompiler
// Type: RoadFlow.Platform.DocumentsReadUsers
// Assembly: RoadFlow.Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07F26AFD-DE3B-4003-89AF-01A62494BA58
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Platform.dll

using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;

namespace RoadFlow.Platform
{
  public class DocumentsReadUsers
  {
    private IDocumentsReadUsers dataDocumentsReadUsers;

    public DocumentsReadUsers()
    {
      this.dataDocumentsReadUsers = RoadFlow.Data.Factory.Factory.GetDocumentsReadUsers();
    }

    public int Add(RoadFlow.Data.Model.DocumentsReadUsers model)
    {
      return this.dataDocumentsReadUsers.Add(model);
    }

    public int Update(RoadFlow.Data.Model.DocumentsReadUsers model)
    {
      return this.dataDocumentsReadUsers.Update(model);
    }

    public List<RoadFlow.Data.Model.DocumentsReadUsers> GetAll()
    {
      return this.dataDocumentsReadUsers.GetAll();
    }

    public RoadFlow.Data.Model.DocumentsReadUsers Get(Guid documentid, Guid userid)
    {
      return this.dataDocumentsReadUsers.Get(documentid, userid);
    }

    public int Delete(Guid documentid, Guid userid)
    {
      return this.dataDocumentsReadUsers.Delete(documentid, userid);
    }

    public long GetCount()
    {
      return this.dataDocumentsReadUsers.GetCount();
    }

    public int Delete(Guid documentid)
    {
      return this.dataDocumentsReadUsers.Delete(documentid);
    }

    public void UpdateRead(Guid docID, Guid userID)
    {
      this.dataDocumentsReadUsers.UpdateRead(docID, userID);
    }
  }
}
