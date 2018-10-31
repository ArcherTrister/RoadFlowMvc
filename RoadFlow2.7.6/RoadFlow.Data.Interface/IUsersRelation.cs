// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.Interface.IUsersRelation
// Assembly: RoadFlow.Data.Interface, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2109DD37-8E2D-4F7C-8293-6084646C162F
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.Interface.dll

using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.Interface
{
  public interface IUsersRelation
  {
    int Add(UsersRelation model);

    int Update(UsersRelation model);

    List<UsersRelation> GetAll();

    UsersRelation Get(Guid userid, Guid organizeid);

    int Delete(Guid userid, Guid organizeid);

    long GetCount();

    List<UsersRelation> GetAllByOrganizeID(Guid organizeID);

    List<UsersRelation> GetAllByUserID(Guid userID);

    UsersRelation GetMainByUserID(Guid userID);

    int DeleteByUserID(Guid userID);

    int DeleteNotIsMainByUserID(Guid userID);

    int DeleteByOrganizeID(Guid organizeID);

    int GetMaxSort(Guid organizeID);
  }
}
