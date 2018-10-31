// Decompiled with JetBrains decompiler
// Type: RoadFlow.Platform.UsersRelation
// Assembly: RoadFlow.Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07F26AFD-DE3B-4003-89AF-01A62494BA58
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Platform.dll

using RoadFlow.Data.Interface;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;

namespace RoadFlow.Platform
{
  public class UsersRelation
  {
    private IUsersRelation dataUsersRelation;

    public UsersRelation()
    {
      this.dataUsersRelation = RoadFlow.Data.Factory.Factory.GetUsersRelation();
    }

    public int Add(RoadFlow.Data.Model.UsersRelation model)
    {
      return this.dataUsersRelation.Add(model);
    }

    public int Update(RoadFlow.Data.Model.UsersRelation model)
    {
      return this.dataUsersRelation.Update(model);
    }

    public List<RoadFlow.Data.Model.UsersRelation> GetAll()
    {
      return this.dataUsersRelation.GetAll();
    }

    public RoadFlow.Data.Model.UsersRelation Get(Guid userid, Guid organizeid)
    {
      return this.dataUsersRelation.Get(userid, organizeid);
    }

    public int Delete(Guid userid, Guid organizeid)
    {
      if (Config.IsDemo)
        return 0;
      return this.dataUsersRelation.Delete(userid, organizeid);
    }

    public long GetCount()
    {
      return this.dataUsersRelation.GetCount();
    }

    public List<RoadFlow.Data.Model.UsersRelation> GetAllByOrganizeID(Guid organizeID)
    {
      return this.dataUsersRelation.GetAllByOrganizeID(organizeID);
    }

    public List<RoadFlow.Data.Model.UsersRelation> GetAllByUserID(Guid userID)
    {
      return this.dataUsersRelation.GetAllByUserID(userID);
    }

    public RoadFlow.Data.Model.UsersRelation GetMainByUserID(Guid userID)
    {
      return this.dataUsersRelation.GetMainByUserID(userID);
    }

    public int DeleteByUserID(Guid userID)
    {
      if (Config.IsDemo)
        return 0;
      return this.dataUsersRelation.DeleteByUserID(userID);
    }

    public int DeleteNotIsMainByUserID(Guid userID)
    {
      return this.dataUsersRelation.DeleteNotIsMainByUserID(userID);
    }

    public int DeleteByOrganizeID(Guid organizeID)
    {
      return this.dataUsersRelation.DeleteByOrganizeID(organizeID);
    }

    public int GetMaxSort(Guid organizeID)
    {
      return this.dataUsersRelation.GetMaxSort(organizeID);
    }
  }
}
