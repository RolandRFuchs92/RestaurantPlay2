using DataAccess.Context;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
	public class BookingRepo
	{
		public AppsContext _db { get; set; }

		public BookingRepo(AppsContext db)
		{
			_db = db;
		}

		/// <summary>
		/// Get All bookings
		/// </summary>
		/// <returns></returns>
		public List<Booking> GetAllBookings()
		{
			return _db.Bookings.ToList();
		}

		/// <summary>
		/// Get Bookings only for today
		/// </summary>
		/// <returns></returns>
		public List<Booking> GetTodaysBookings()
		{
			var model = (from booking in _db.Bookings
						 where DbFunctions.TruncateTime(booking.BookingDate) == DateTime.Today
						 select booking).ToList();

			return model;
		}

		public List<Booking> GetBookings(DateTime? FromDate, DateTime? ToDate, string keyword, bool? isCanceled, bool? isConfirmed)
		{
			return (from booking in _db.Bookings
					join occasion in _db.ItemListCategories on booking.BookingOccasionId equals occasion.ItemListCategoryId
					where (FromDate == null || booking.BookingDate >= FromDate)
						  && (ToDate == null || booking.BookingDate <= ToDate)
						  && (isCanceled == null || booking.IsCanceled == isCanceled)
						  && (isConfirmed == null || booking.IsConfirmed == isConfirmed)
						  && (keyword == null
								|| booking.BookingComments.Contains(keyword)
								|| booking.BookingEmailAddress.Contains(keyword)
								|| booking.BookingName.Contains(keyword)
								|| booking.BookingMobileNumber.Contains(keyword)
								|| occasion.ItemListCategoryName.Contains(keyword))
					select booking).ToList();
		}

		/// <summary>
		/// Get a booking based on the Id
		/// </summary>
		/// <param name="bookingId"></param>
		/// <returns></returns>
		public Booking GetBookingByBookingId(int bookingId)
		{
			return (from booking in _db.Bookings
					where booking.BookingId == bookingId
					select booking).FirstOrDefault();
		}

		/// <summary>
		/// Cancel a booking based on the bookingId passed.
		/// </summary>
		/// <param name="bookingId"></param>
		/// <returns></returns>
		public bool IsCanceledBooking(int bookingId)
		{
			try
			{
				var booking = _db.Bookings.FirstOrDefault(i => i.BookingId == bookingId);
				booking.IsCanceled = !booking.IsCanceled;
				_db.SaveChanges();
				return true;
			}
			catch (Exception e)
			{
				return false;
			}
		}

		/// <summary>
		/// Confirm a booking based on the booking Id Supplied.
		/// </summary>
		/// <param name="bookingId"></param>
		/// <returns></returns>
		public bool IsConfirmedBooking(int bookingId)
		{
			try
			{
				var booking = _db.Bookings.FirstOrDefault(i => i.BookingId == bookingId);

				booking.IsConfirmed = !booking.IsConfirmed;
				_db.SaveChanges();
				return true;
			}
			catch (Exception e)
			{
				return false;
			}
		}

		/// <summary>
		/// Save a booking
		/// </summary>
		/// <param name="booking"></param>
		/// <returns></returns>
		public bool IsSavedBooking(Booking booking)
		{

			try
			{
				if (booking.BookingId == 0)
				{
					booking.CreatedOn = DateTime.Now;
					_db.Bookings.Add(booking);
					_db.SaveChanges();
				}
				else
				{
					var result = (from row in _db.Bookings
								  where row.BookingId == booking.BookingId
								  select row).FirstOrDefault();
					booking.CreatedOn = result.CreatedOn;
					_db.Entry(result).CurrentValues.SetValues(booking);

					_db.SaveChanges();
				}

				return true;
			}
			catch (Exception e)
			{
				return false;
			}
		}

	}
}