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
												 join occasion in ItemListRepo.GetListItemsByCateogry(1) on booking.BookingOccassionId equals occasion.ItemListId
												 select new BookingViewModel
												 {
														 Comments = booking.BookingComments,
														 CreatedOn = booking.CreateOn,
														 EmailAddress = booking.BookingEmailAddress,
														 ForDate = booking.BookingDate,
														 HeadCount = booking.BookingHeadCount,
														 IsCanceled = booking.IsCanceled,
														 Id = booking.BookingId,
														 IsConfirmed = booking.IsConfirmed,
														 MobileNumber = booking.BookingMobileNumber,
														 Name = booking.Name,
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

				/// <summary>
				/// Pass in the form model booking and this will translate it to what the repo requires inorder to save the booking.
				/// </summary>
				/// <param name="saveBooking"></param>
				/// <returns></returns>
				public bool IsSavedBooking(SaveBookingViewModel saveBooking)
				{
						var db = new AppsContext();
						var model = new Booking
						{
								Name = saveBooking.Name,
								IsConfirmed = saveBooking.IsConfirmed,
								BookingId = saveBooking.BookingId,
								BookingComments = saveBooking.Comment,
								BookingDate = saveBooking.DateFor,
								BookingEmailAddress = saveBooking.EmailAddress,
								BookingHeadCount = saveBooking.HeadCount,
								BookingMobileNumber = saveBooking.MobileNumber,
								BookingOccassionId = saveBooking.OccasionId
						};

						return new BookingRepo(db).IsSavedBooking(model);
				}
		}
}