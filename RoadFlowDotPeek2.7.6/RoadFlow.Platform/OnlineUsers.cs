// Decompiled with JetBrains decompiler
// Type: RoadFlow.Platform.OnlineUsers
// Assembly: RoadFlow.Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07F26AFD-DE3B-4003-89AF-01A62494BA58
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Platform.dll

using RoadFlow.Cache.IO;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;

namespace RoadFlow.Platform
{
  public class OnlineUsers
  {
    private string key = Keys.CacheKeys.OnlineUsers.ToString();

    public List<RoadFlow.Data.Model.OnlineUsers> GetAll()
    {
      object obj = Opation.Get(this.key);
      if (obj == null || !(obj is List<RoadFlow.Data.Model.OnlineUsers>))
        return new List<RoadFlow.Data.Model.OnlineUsers>();
      return (List<RoadFlow.Data.Model.OnlineUsers>) obj;
    }

    private void set(List<RoadFlow.Data.Model.OnlineUsers> list)
    {
      if (list == null)
        return;
      Opation.Set(this.key, (object) list);
    }

    public bool Add(RoadFlow.Data.Model.Users user, Guid uniqueID)
    {
      if (user == null)
        return false;
      List<RoadFlow.Data.Model.OnlineUsers> all = this.GetAll();
      bool flag = false;
      RoadFlow.Data.Model.OnlineUsers onlineUsers = all.Find((Predicate<RoadFlow.Data.Model.OnlineUsers>) (p => p.ID == user.ID));
      if (onlineUsers == null)
      {
        flag = true;
        onlineUsers = new RoadFlow.Data.Model.OnlineUsers();
        RoadFlow.Data.Model.UsersRelation mainByUserId = new UsersRelation().GetMainByUserID(user.ID);
        if (mainByUserId != null)
          onlineUsers.OrgName = new Organize().GetAllParentNames(mainByUserId.OrganizeID, false, " / ");
      }
      onlineUsers.ID = user.ID;
      onlineUsers.ClientInfo = "操作系统：" + Tools.GetOSName() + "  浏览器：" + Tools.GetBrowse();
      onlineUsers.IP = Tools.GetIPAddress();
      onlineUsers.LastPage = "";
      onlineUsers.LoginTime = DateTimeNew.Now;
      onlineUsers.UniqueID = uniqueID;
      onlineUsers.UserName = user.Name;
      if (flag)
        all.Add(onlineUsers);
      this.set(all);
      return true;
    }

    public bool Remove(Guid userID)
    {
      List<RoadFlow.Data.Model.OnlineUsers> all = this.GetAll();
      RoadFlow.Data.Model.OnlineUsers onlineUsers = all.Find((Predicate<RoadFlow.Data.Model.OnlineUsers>) (p => p.ID == userID));
      if (onlineUsers != null)
        all.Remove(onlineUsers);
      this.set(all);
      return true;
    }

    public bool RemoveAll()
    {
      Opation.Set(this.key, (object) new List<RoadFlow.Data.Model.OnlineUsers>());
      return true;
    }

    public RoadFlow.Data.Model.OnlineUsers Get(Guid userID)
    {
      return this.GetAll().Find((Predicate<RoadFlow.Data.Model.OnlineUsers>) (p => p.ID == userID));
    }
  }
}
