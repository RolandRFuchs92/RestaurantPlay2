using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DataAccess;
using DataAccess.Context;
using DataAccess.Entities;
using RestaurantPlay2.Areas.BookNow.ViewModels;

namespace RestaurantPlay2.Areas.BookNow.BusinessLogic
{
	public class BookNow
	{
		private readonly int _CategoryId = 1;
		private BookingRepo _bookingRepo;
		private AppsContext _db;

		public BookNow()
		{
			_db = new AppsContext();
			_bookingRepo = new BookingRepo(_db);
		}

		public SaveBookingViewModel GetBookingById(int bookingId)
		{
			var booking= _bookingRepo.GetBookingByBookingId(bookingId);
			if (booking == null)
				return new SaveBookingViewModel();

			var model = new SaveBookingViewModel()
			{
				Comment = booking.BookingComments,
				EmailAddress = booking.BookingEmailAddress,
				ForDate = booking.BookingDate,
				HeadCount = booking.BookingHeadCount,
				IsCanceled = booking.IsCanceled,
				BookingId = booking.BookingId,
				IsConfirmed = booking.IsConfirmed,
				MobileNumber = booking.BookingMobileNumber,
				Name = booking.BookingName,
				OccasionId = booking.BookingOccasionId
			};

			return model;
		}

		/// <summary>
		///     get a list of categories
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
		///     Get a list of bookings for today
		/// </summary>
		/// <returns></returns>
		public List<BookingViewModel> GetTodaysBookings()
		{
			var db = new AppsContext();
			var ItemListRepo = new ItemListRepo(db);

			var model = (from booking in _bookingRepo.GetTodaysBookings()
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
		/// Get Bookings based on the params passed.
		/// </summary>
		/// <param name="fromDate"></param>
		/// <param name="toDate"></param>
		/// <param name="isConfirmd"></param>
		/// <param name="isCancled"></param>
		/// <returns></returns>
		public List<BookingViewModel> GetBookingsList(BookingFiltersViewModel filters)
		{
			var results = _bookingRepo.GetBookings(filters.FromDate, filters.ToDate, filters.Keyword, filters.IsConfirmed, filters.IsCanceled);
			var model = (from booking in results
						 join occasion in new ItemListRepo(_db).GetListItemsByCateogry(1) on booking.BookingOccasionId equals occasion.ItemListId
						 select new BookingViewModel
						 {
							 Name = booking.BookingName,
							 Id = booking.BookingId,
							 EmailAddress = booking.BookingEmailAddress,
							 MobileNumber = booking.BookingMobileNumber,
							 CreatedOn = booking.CreatedOn,
							 IsConfirmed = booking.IsConfirmed,
							 HeadCount = booking.BookingHeadCount,
							 IsCanceled = booking.IsCanceled,
							 Comments = booking.BookingComments,
							 ForDate = booking.BookingDate,
							 Occasion = occasion.ItemListData
						 }).ToList();

			return model;
		}

		/// <summary>
		///     Get A list for the Occasion dropdown list
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
		///     translate the SaveBookingViewModel into an entity used for saving or updating a booking.
		/// </summary>
		/// <param name="booking"></param>
		/// <returns></returns>
		public bool SaveBooking(SaveBookingViewModel booking)
		{
			var db = new AppsContext();

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

			return _bookingRepo.IsSavedBooking(model);
		}

		public bool IsCanceledBooking(int bookingId)
		{
			return _bookingRepo.IsCanceledBooking(bookingId);
		}

		public bool IsConfirmedBooking(int bookingId)
		{
			return _bookingRepo.IsConfirmedBooking(bookingId);
		}
	}
}