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

			return PartialView("_BookNowForm", model);
		}

		/// <summary>
		/// Get All bookings that are available for today.
		/// </summary>
		/// <returns></returns>
		public ActionResult BookingsForToday()
		{
			var model = new BusinessLogic.BookNow().GetTodaysBookings();

			return PartialView("_BookingReport", model);
		}

		public ActionResult GetAllBookings()
		{
			var model = new BusinessLogic.BookNow().GetBookingsList(new BookingFiltersViewModel());
			return View("_BookingReport", model);
		}

		public ActionResult GetBookingsAdminView()
		{
			return View("BookingAdminView");
		}

		public ActionResult GetBookings(BookingFiltersViewModel filters)
		{
			if (!ModelState.IsValid)
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "The filters passed were not valid, please try again.");


			var model = new BusinessLogic.BookNow().GetBookingsList(filters);
			return PartialView("_BookingReport", model);
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
				return Json(new { Message = "Your booking has been made! You will receive and email to confirm your booking!" });
			}
			return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "There was an error saving your booking, please try again later.");

		}

		public ActionResult CancelBooking(int bookingId)
		{
			if (new BusinessLogic.BookNow().IsCanceledBooking(bookingId)) 
				return Json(new { Message = "Book successfully canceled!" });

			return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "There was an error canceling this booking. Please try again later!");
		}

		public ActionResult ConfirmBooking(int bookingId)
		{
			if(new BusinessLogic.BookNow().IsConfirmedBooking(bookingId))
				return Json(new {Message = "Your booking has been confirmed!"});

			return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "There was an error confirming this booking. Please try again later.");
		}

		public JsonResult GetTodaysBookingsJSON()
		{
			return Json( new { data = new BusinessLogic.BookNow().GetTodaysBookings()});
		}
	}
}