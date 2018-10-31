// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.Interface.IShortMessage
// Assembly: RoadFlow.Data.Interface, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2109DD37-8E2D-4F7C-8293-6084646C162F
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.Interface.dll

using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.Interface
{
  public interface IShortMessage
  {
    int Add(ShortMessage model);

    int Update(ShortMessage model);

    List<ShortMessage> GetAll();

    ShortMessage Get(Guid id);

    ShortMessage GetRead(Guid id);

    int Delete(Guid id);

    long GetCount();

    List<ShortMessage> GetAllNoRead();

    List<ShortMessage> GetAllNoReadByUserID(Guid userID);

    int UpdateStatus(Guid id);

    List<ShortMessage> GetList(out string pager, int[] status, string query = "", string title = "", string contents = "", string senderID = "", string date1 = "", string date2 = "", string receiveID = "");

    List<ShortMessage> GetList(out long count, int[] status, int size, int number, string title = "", string contents = "", string senderID = "", string date1 = "", string date2 = "", string receiveID = "", string order = "");

    int Delete(string linkID, int Type);
  }
}
