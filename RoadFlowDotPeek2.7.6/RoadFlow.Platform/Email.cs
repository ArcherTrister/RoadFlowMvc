// Decompiled with JetBrains decompiler
// Type: RoadFlow.Platform.Email
// Assembly: RoadFlow.Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07F26AFD-DE3B-4003-89AF-01A62494BA58
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Platform.dll

using System;

namespace RoadFlow.Platform
{
  public class Email
  {
    public static void Send(string addrss, string title, string contents, string files = "")
    {
    }

    public static void Send(Guid userID, string title, string contents, string files = "")
    {
    }
  }
}
