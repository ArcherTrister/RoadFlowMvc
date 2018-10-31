// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.Interface.IDocumentsReadUsers
// Assembly: RoadFlow.Data.Interface, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2109DD37-8E2D-4F7C-8293-6084646C162F
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.Interface.dll

using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.Interface
{
  public interface IDocumentsReadUsers
  {
    int Add(DocumentsReadUsers model);

    int Update(DocumentsReadUsers model);

    List<DocumentsReadUsers> GetAll();

    DocumentsReadUsers Get(Guid documentid, Guid userid);

    int Delete(Guid documentid, Guid userid);

    long GetCount();

    int Delete(Guid documentid);

    void UpdateRead(Guid docID, Guid userID);
  }
}
