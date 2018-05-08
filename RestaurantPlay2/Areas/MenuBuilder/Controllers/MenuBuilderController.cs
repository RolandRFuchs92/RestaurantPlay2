using RestaurantPlay2.Areas.MenuBuilder.ViewModels;
using System.Web.Mvc;
using RestaurantPlay2.Areas.MenuBuilder.BusinessLogic;


namespace RestaurantPlay2.Areas.MenuBuilder.Controllers
{
    public class MenuBuilderController : Controller
    {
        // GET: MenuCreator/MenuBuilder
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SaveMenuItem(SaveMenuItemViewModel savedViewModel)
        {
            var a = SaveMenuItem(savedViewModel);
            

            return View("_MenuBuilderForm");
        }
    }
}