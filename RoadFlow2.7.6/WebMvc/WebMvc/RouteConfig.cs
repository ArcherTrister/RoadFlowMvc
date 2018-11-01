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
			RouteCollectionExtensions.MapRoute(namespaces: new string[1]
			{
				"WebMvc.Controllers"
			}, routes: routes, name: "Default", url: "{controller}/{action}/{id}", defaults: new
			{
				controller = "Home",
				action = "Index",
				id = UrlParameter.Optional
			});
		}
	}
}
