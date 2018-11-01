// Decompiled with JetBrains decompiler
// Type: RoadFlow.Platform.SignalR.SignalRConnection
// Assembly: RoadFlow.Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07F26AFD-DE3B-4003-89AF-01A62494BA58
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Platform.dll

using Microsoft.AspNet.SignalR;
using RoadFlow.Utility;
using System.Threading.Tasks;

namespace RoadFlow.Platform.SignalR
{
    public class SignalRConnection : PersistentConnection
    {
        protected override Task OnConnected(IRequest request, string connectionId)
        {
            string str = "";
            try
            {
                str = request.Cookies[Keys.SessionKeys.UserID.ToString()].Value.ToLower();
            }
            catch
            {
            }
            if (!str.IsNullOrEmpty())
                this.Groups.Add(connectionId, str);
            return base.OnConnected(request, connectionId);
        }

        protected override Task OnReceived(IRequest request, string connectionId, string data)
        {
            return base.OnReceived(request, connectionId, data);
        }

        protected override Task OnReconnected(IRequest request, string connectionId)
        {
            string str = "";
            try
            {
                str = request.Cookies[Keys.SessionKeys.UserID.ToString()].Value.ToLower();
            }
            catch
            {
            }
            if (!str.IsNullOrEmpty())
                this.Groups.Add(connectionId, str);
            return base.OnReconnected(request, connectionId);
        }
    }
}