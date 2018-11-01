// Decompiled with JetBrains decompiler
// Type: RoadFlow.Platform.UsersEqualityComparer
// Assembly: RoadFlow.Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07F26AFD-DE3B-4003-89AF-01A62494BA58
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Platform.dll

using System.Collections.Generic;

namespace RoadFlow.Platform
{
  public class UsersEqualityComparer : IEqualityComparer<RoadFlow.Data.Model.Users>
  {
    public bool Equals(RoadFlow.Data.Model.Users user1, RoadFlow.Data.Model.Users user2)
    {
      if (user1 != null && user2 != null)
        return user1.ID == user2.ID;
      return true;
    }

    public int GetHashCode(RoadFlow.Data.Model.Users user)
    {
      return user.ToString().GetHashCode();
    }
  }
}
