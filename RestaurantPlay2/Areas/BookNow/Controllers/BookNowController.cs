using RestaurantPlay2.Areas.BookNow.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using DataAccess.Context;
using RestaurantPlay2.Areas.BookNow.BusinessLogic;

namespace RestaurantPlay2.Areas.BookNow.Controllers
{
		public class BookNowController : Controller
		{

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
						var db = new AppsContext();
						var model = new BookNowFormViewModel
						{
								SaveBookingViewModel = new SaveBookingViewModel(),
								ListCategoryViewModel = new BusinessLogic.BookNow().GetListItemOccasion()
						};

						return View("_BookNowForm", model);
				}

				/// <summary>
				/// Get All bookings that are available for today.
				/// </summary>
				/// <returns></returns>
				public ActionResult BookingsForToday()
				{
						var model = new BusinessLogic.BookNow().GetTodaysBookings();

						return View("_BookingReport", model);
				}

				/// <summary>
				/// Save or update a booking.
				/// </summary>
				/// <param name="model"></param>
				/// <returns></returns>
				public ActionResult SaveBooking(BookNowFormViewModel model)
				{
						if (!ModelState.IsValid)
						{
								Response.StatusCode = (int)HttpStatusCode.BadRequest;
								return Json(new
								{
										Message = "There are missing fields in the submitted data. Please correct these fields and try again."
								});
						}

						var isSaved = new BusinessLogic.BookNow().SaveBooking(model.SaveBookingViewModel);

						if (isSaved)
						{
								Response.StatusCode = (int)HttpStatusCode.OK;
								return Json(new { Message ="Your booking has been made! You will receive and email to confirm your booking!"});
						}
						else
						{
								Response.StatusCode = (int)HttpStatusCode.InternalServerError;
								return Json(new { Message = "There was an error saving your booking, please try again later." });
						}
				}
		}
}