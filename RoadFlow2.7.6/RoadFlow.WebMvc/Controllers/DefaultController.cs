

using System.Web.Mvc;

namespace RoadFlow.WebMvc.Controllers
{
    public class DefaultController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}