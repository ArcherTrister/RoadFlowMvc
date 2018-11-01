// Decompiled with JetBrains decompiler
// Type: RoadFlow.Platform.SignalR.SignalRHub
// Assembly: RoadFlow.Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07F26AFD-DE3B-4003-89AF-01A62494BA58
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Platform.dll

using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace RoadFlow.Platform.SignalR
{
    public class SignalRHub : Hub
    {
        public void SendMessage(string message, string userID = "")
        {
        }

        public override Task OnConnected()
        {
            return base.OnConnected();
        }
    }
}