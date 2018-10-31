// Decompiled with JetBrains decompiler
// Type: RoadFlow.Platform.WorkGroup
// Assembly: RoadFlow.Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07F26AFD-DE3B-4003-89AF-01A62494BA58
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Platform.dll

using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoadFlow.Platform
{
  public class WorkGroup
  {
    public const string PREFIX = "w_";
    private IWorkGroup dataWorkGroup;

    public WorkGroup()
    {
      this.dataWorkGroup = RoadFlow.Data.Factory.Factory.GetWorkGroup();
    }

    public int Add(RoadFlow.Data.Model.WorkGroup model)
    {
      return this.dataWorkGroup.Add(model);
    }

    public int Update(RoadFlow.Data.Model.WorkGroup model)
    {
      return this.dataWorkGroup.Update(model);
    }

    public List<RoadFlow.Data.Model.WorkGroup> GetAll()
    {
      return this.dataWorkGroup.GetAll();
    }

    public RoadFlow.Data.Model.WorkGroup Get(Guid id)
    {
      return this.dataWorkGroup.Get(id);
    }

    public int Delete(Guid id)
    {
      return this.dataWorkGroup.Delete(id);
    }

    public long GetCount()
    {
      return this.dataWorkGroup.GetCount();
    }

    public string GetName(Guid id)
    {
      RoadFlow.Data.Model.WorkGroup workGroup = this.Get(id);
      if (workGroup != null)
        return workGroup.Name;
      return "";
    }

    public static string RemovePrefix(string id)
    {
      if (!id.IsNullOrEmpty())
        return id.Replace("w_", "");
      return "";
    }

    public string RemovePrefix1(string id)
    {
      if (!id.IsNullOrEmpty())
        return id.Replace("w_", "");
      return "";
    }

    public string GetUsersNames(string members, char split = ',')
    {
      if (members.IsNullOrEmpty())
        return "";
      StringBuilder stringBuilder = new StringBuilder();
      foreach (RoadFlow.Data.Model.Users allUser in new Organize().GetAllUsers(members))
      {
        stringBuilder.Append(allUser.Name);
        stringBuilder.Append(split);
      }
      return stringBuilder.ToString().TrimEnd(split);
    }

    public string GetUsersNames(RoadFlow.Data.Model.WorkGroup wg, char split = ',')
    {
      if (wg == null || wg.Members.IsNullOrEmpty())
        return "";
      return this.GetUsersNames(wg.Members, split);
    }

    public string GetUsersNames(Guid wgID, char split = ',')
    {
      return this.GetUsersNames(this.Get(wgID), split);
    }

    public List<RoadFlow.Data.Model.WorkGroup> GetAllByUserID(Guid userID)
    {
      List<RoadFlow.Data.Model.WorkGroup> all = this.GetAll();
      Organize organize = new Organize();
      List<RoadFlow.Data.Model.WorkGroup> workGroupList = new List<RoadFlow.Data.Model.WorkGroup>();
      foreach (RoadFlow.Data.Model.WorkGroup workGroup in all)
      {
        if (organize.GetAllUsers(workGroup.Members).Find((Predicate<RoadFlow.Data.Model.Users>) (p => p.ID == userID)) != null)
          workGroupList.Add(workGroup);
      }
      return workGroupList;
    }

    public string GetAllNamesByUserID(Guid userID)
    {
      List<RoadFlow.Data.Model.WorkGroup> allByUserId = this.GetAllByUserID(userID);
      StringBuilder stringBuilder = new StringBuilder();
      foreach (RoadFlow.Data.Model.WorkGroup workGroup in allByUserId)
      {
        stringBuilder.Append(workGroup.Name);
        stringBuilder.Append(",");
      }
      return stringBuilder.ToString().TrimEnd(',');
    }
  }
}
