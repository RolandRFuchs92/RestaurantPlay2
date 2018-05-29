﻿using DataAccess.Context;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
						return (from booking in _db.Bookings
										where booking.BookingDate.Date == DateTime.Today
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
				public bool CancelBooking(int bookingId)
				{
						try
						{
								var booking = _db.Bookings.FirstOrDefault(i => i.BookingId == bookingId);
								booking.IsCanceled = true;
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
				public bool ConfirmBooking(int bookingId)
				{
						try
						{
								var booking = _db.Bookings.FirstOrDefault(i => i.BookingId == bookingId);

								booking.IsConfirmed = true;
								_db.SaveChanges();
								return true;
						}
						catch(Exception e)
						{
								return false;
						}
				}

				/// <summary>
				/// Save a booking
				/// </summary>
				/// <param name="booking"></param>
				/// <returns></returns>
				public bool SaveBooking(Booking booking)
				{
						try
						{
								if (booking.BookingId == 0)
								{
										_db.Bookings.Attach(booking);
										_db.SaveChanges();
								}
								else
								{
										_db.Bookings.Add(booking);
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
