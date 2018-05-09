using System;
using System.Web.Http.Results;
using System.Web.Mvc;
using DataAccess.MenuItem;
using RestaurantPlay2.Areas.MenuBuilder.ViewModels;


namespace RestaurantPlay2.Areas.MenuBuilder.Controllers
{
    public class MenuBuilderController : Controller
    {
        private readonly BusinessLogic.MenuBuilder _repo;

        public MenuBuilderController()
        {
            _repo = new BusinessLogic.MenuBuilder();    
        }
        // GET: MenuCreator/MenuBuilder
        public ActionResult Index()
        {
            var model = _repo.LoadMenuBuilderViewModel();

            return View(model);
        }

        public ActionResult SaveMenuItem(SaveMenuItemViewModel saveViewModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Error", "The data you supplied was incorrect, please review your data and try again.");
                return View("_MenuBuilderForm", saveViewModel);
            }
            var builder = new BusinessLogic.MenuBuilder();
            builder.SaveMenuItem(saveViewModel);
            ModelState.Clear();

            var model = _repo.LoadMenuBuilderViewModel();

            return View("Index", model);
        }

        public ActionResult DeleteMenuItem(int menuItemId)
        {
            if (!_repo.DeleteMenuItem(menuItemId))
            {
                ModelState.AddModelError("Unable to find menu item!", new Exception("No menu item found."));
                return null;
            }
            var model = _repo.LoadMenuBuilderViewModel();

            return View("Index", model);
        }
    }
}