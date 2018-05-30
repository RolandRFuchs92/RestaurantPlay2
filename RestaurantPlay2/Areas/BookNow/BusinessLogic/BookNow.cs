using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using DataAccess.Context;
using RestaurantPlay2.Areas.BookNow.ViewModels;
using DataAccess;
using DataAccess.Entities;

namespace RestaurantPlay2.Areas.BookNow.BusinessLogic
{
		public class BookNow
		{
				private readonly int _CategoryId = 1;

				/// <summary>
				/// get a list of categories
				/// </summary>
				/// <returns></returns>
				public List<ListCategoryViewModel> GetListCategoryViewModel()
				{
						var db = new AppsContext();
						var itemList = new ItemListRepo(db).GetListItemsByCateogry(_CategoryId);
						var model = (from item in itemList
												 select new ListCategoryViewModel
												 {
														 Id = item.ItemListId,
														 Name = item.ItemListData
												 }).ToList();

						return model;
				}

				/// <summary>
				/// Get a list of bookings for today
				/// </summary>
				/// <returns></returns>
				public List<BookingViewModel> GetTodaysBookings()
				{
						var db = new AppsContext();
						var bookingRepo = new BookingRepo(db);
						var ItemListRepo = new ItemListRepo(db);

						var model = (from booking in bookingRepo.GetTodaysBookings()
												 join occasion in ItemListRepo.GetListItemsByCateogry(1) on booking.BookingOccasionId equals occasion.ItemListId
												 select new BookingViewModel
												 {
														 Comments = booking.BookingComments,
														 CreatedOn = booking.CreatedOn,
														 EmailAddress = booking.BookingEmailAddress,
														 ForDate = booking.BookingDate,
														 HeadCount = booking.BookingHeadCount,
														 IsCanceled = booking.IsCanceled,
														 Id = booking.BookingId,
														 IsConfirmed = booking.IsConfirmed,
														 MobileNumber = booking.BookingMobileNumber,
														 Name = booking.BookingName,
														 Occasion = occasion.ItemListData
												 }).ToList();

						return model;
				}

				/// <summary>
			/// Get A list for the Occasion dropdown list
			/// </summary>
			/// <returns></returns>
				public List<SelectListItem> GetListItemOccasion()
				{
						var db = new AppsContext();
						var repo = new ItemListRepo(db);

						var model = (from item in repo.GetListItemsByCateogry(1)
												 select new SelectListItem
												 {
														 Value = item.ItemListId.ToString(),
														 Text = item.ItemListData
												 }).ToList();

						return model;
				}

				public bool SaveBooking(SaveBookingViewModel booking)
				{
						var db = new AppsContext();
						var repo = new BookingRepo(db);

						var model = new Booking
						{
								BookingId = booking.BookingId,
								BookingName = booking.Name,
								BookingMobileNumber = booking.MobileNumber,
								BookingEmailAddress = booking.EmailAddress,
								BookingHeadCount = booking.HeadCount,
								BookingComments = booking.Comment,
								BookingOccasionId = booking.OccasionId,
								IsCanceled = booking.IsCanceled,
								IsConfirmed = booking.IsConfirmed,
								BookingDate = booking.ForDate
						};

						return repo.SaveBooking(model);
				}

		}
}