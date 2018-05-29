using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess.Context;
using RestaurantPlay2.Areas.BookNow.ViewModels;
using DataAccess;

namespace RestaurantPlay2.Areas.BookNow.BusinessLogic
{
		public class BookNow
		{
				private readonly int _CategoryId = 1;
				public List<ListCategoryViewModel> GetListCategoryViewModel()
				{
						var db = new AppsContext();
						var itemList = new ItemListRepo(db).GetListItemsByCateogry(_CategoryId);
						var model = (from item in itemList
												 select new ListCategoryViewModel
												 {
														 Id = item.ListId,
														 Name = item.ListData
												 }).ToList();

						return model;
				}

				private List<BookNowViewModel> GetTodaysBookings()
				{
						var db = new AppsContext();
						var bookingRepo = new BookingRepo(db);
						var ItemListRepo = new ItemListRepo(db);

						var model = (from booking in bookingRepo.GetTodaysBookings()
												 join occasion in ItemListRepo.GetListItemsByCateogry(1) on booking.BookingOccassionId equals occasion.ListId
												 select new BookNowViewModel
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
														 Occasion = occasion.ListData
												 }).ToList();

						return model;
				}

		}
}