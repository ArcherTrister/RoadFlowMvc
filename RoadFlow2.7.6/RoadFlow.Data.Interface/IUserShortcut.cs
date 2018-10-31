// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.Interface.IUserShortcut
// Assembly: RoadFlow.Data.Interface, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2109DD37-8E2D-4F7C-8293-6084646C162F
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.Interface.dll

using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace RoadFlow.Data.Interface
{
  public interface IUserShortcut
  {
    int Add(UserShortcut model);

    int Update(UserShortcut model);

    List<UserShortcut> GetAll();

    UserShortcut Get(Guid id);

    int Delete(Guid id);

    long GetCount();

    int DeleteByUserID(Guid userID);

    List<UserShortcut> GetAllByUserID(Guid userID);

    DataTable GetDataTableByUserID(Guid userID);

    int DeleteByMenuID(Guid menuID);
  }
}
