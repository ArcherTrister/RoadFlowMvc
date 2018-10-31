// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.Interface.IDocuments
// Assembly: RoadFlow.Data.Interface, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2109DD37-8E2D-4F7C-8293-6084646C162F
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.Interface.dll

using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace RoadFlow.Data.Interface
{
  public interface IDocuments
  {
    int Add(Documents model);

    int Update(Documents model);

    List<Documents> GetAll();

    Documents Get(Guid id);

    int Delete(Guid id);

    long GetCount();

    DataTable GetList(out string pager, string dirID, string userID, string query = "", string title = "", string date1 = "", string date2 = "", bool isNoRead = false);

    DataTable GetList(out long count, int size, int number, string dirID, string userID, string title = "", string date1 = "", string date2 = "", bool isNoRead = false, string order = "");

    void UpdateReadCount(Guid id);

    int DeleteByDirectoryID(Guid directoryID);
  }
}
