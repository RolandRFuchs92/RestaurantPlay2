using RestaurantPlay2.Areas.BookNow.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantPlay2.Areas.BookNow.Controllers
{
    public class BookNowController : Controller
    {
        // GET: BookNow/BookNow
        public ActionResult Index()
        {
            return View();
        }

				/// <summary>
				/// Get the form view model, meant for client side viewing.
				/// </summary>
				/// <returns></returns>
				public ActionResult BookNowForm()
				{
						var model = new BookNowFormViewModel();
						return PartialView(model);
				}

				public ActionResult BookingsForToday()
				{
						return View();
				}

    }
}