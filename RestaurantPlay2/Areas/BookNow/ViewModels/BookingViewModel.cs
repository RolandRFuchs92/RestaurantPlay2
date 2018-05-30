using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestaurantPlay2.Areas.BookNow.ViewModels
{
	public class BookingViewModel
	{
		[Display(Name = "Booking Id :")]
		public int Id { get; set; }
		[Display(Name = "Booked for :")]
		public string Name { get; set; }
		[Display(Name="Mobile Number :")]
		public string MobileNumber { get; set; }
		[Display(Name ="Email Address :")]
		public string EmailAddress { get; set; }
		[Display(Name ="Number Attending :")]
		public int HeadCount { get; set; }
		[Display(Name="Comments")]
		public string Comments { get; set; }
		[Display(Name="The Occasion :")]
		public string Occasion { get; set; }
		[Display(Name="Is Confirmed :")]
		public bool IsConfirmed { get; set; }
		[Display(Name="Is Canceled :")]
		public bool IsCanceled { get; set; }
		[Display(Name="Date and Time Booked :")]
		public DateTime ForDate { get; set; }
		[Display(Name="Booking made on :")]
		public DateTime CreatedOn { get; set; }
	}
}