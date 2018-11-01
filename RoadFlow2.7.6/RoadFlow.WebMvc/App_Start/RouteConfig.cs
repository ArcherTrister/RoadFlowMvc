// Decompiled with JetBrains decompiler
// Type: WebMvc.RouteConfig
// Assembly: WebMvc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 43FD7615-6DC3-49FB-B263-7F7CC91AFA77
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\WebMvc.dll

using RoadFlow.Platform.SignalR;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebMvc
{
    public class RouteConfig
  {
        public static void RegisterRoutes(RouteCollection routes)
        {
            RouteTable.Routes.MapHubs();
            RouteTable.Routes.MapConnection<SignalRConnection>("roadflow", "roadflow");
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            System.Web.Mvc.RouteCollectionExtensions.MapRoute(namespaces: new string[1]
            {
                "WebMvc.Controllers"
            }, routes: routes, name: "Default", url: "{controller}/{action}/{id}", defaults: new
            {
                controller = "Home",
                action = "Index",
                id = UrlParameter.Optional
            });
        }

    //public static void RegisterRoutes(RouteCollection routes)
    //{
    //  RouteTable.Routes.MapHubs();
    //  RouteTable.Routes.MapConnection<SignalRConnection>("roadflow", "roadflow");
    //  routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
    //  RouteCollection routes1 = routes;
    //  string name = "Default";
    //  string url = "{controller}/{action}/{id}";
    //  string[] strArray = new string[1]{ "WebMvc.Controllers" };
    //  var data = new{ controller = "Home", action = "Index", id = UrlParameter.Optional };
    //  string[] namespaces = strArray;
    //  RouteCollectionExtensions.MapRoute(routes1, name, url, (object) data, namespaces);
    //}
  }
}
