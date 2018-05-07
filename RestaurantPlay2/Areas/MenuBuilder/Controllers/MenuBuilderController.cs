using System.Web.Mvc;

namespace RestaurantPlay2.Areas.MenuBuilder.Controllers
{
    public class MenuBuilderController : Controller
    {
        // GET: MenuCreator/MenuBuilder
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SaveMenuItem()
        {
            return View("_MenuBuilderForm");
        }
    }
}