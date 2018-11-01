// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.Interface.IUsers
// Assembly: RoadFlow.Data.Interface, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2109DD37-8E2D-4F7C-8293-6084646C162F
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.Interface.dll

using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.Interface
{
  public interface IUsers
  {
    int Add(Users model);

    int Update(Users model);

    List<Users> GetAll();

    Users Get(Guid id);

    int Delete(Guid id);

    long GetCount();

    Users GetByAccount(string account);

    List<Users> GetAllByOrganizeID(Guid organizeID);

    List<Users> GetAllByOrganizeIDArray(Guid[] organizeIDArray);

    bool HasAccount(string account, string userID = "");

    bool UpdatePassword(string password, Guid userID);

    int UpdateSort(Guid userID, int sort);

    List<Users> GetAllByIDString(string idString);

    List<Users> GetAllByWorkGroupID(Guid workgroupid);
  }
}
