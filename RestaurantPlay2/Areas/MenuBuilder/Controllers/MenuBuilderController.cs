using System.Web.Http.Results;
using System.Web.Mvc;
using RestaurantPlay2.Areas.MenuBuilder.ViewModels;

namespace RestaurantPlay2.Areas.MenuBuilder.Controllers
{
    public class MenuBuilderController : Controller
    {
        // GET: MenuCreator/MenuBuilder
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SaveMenuItem(SaveMenuItemViewModel saveViewModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Error", "The data you supplied was incorrect, please review your data and try again.");
                return View("_MenuBuilderForm", saveViewModel);
            }



            return View("_MenuBuilderForm");
        }
    }
}