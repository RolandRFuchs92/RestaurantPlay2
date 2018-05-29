using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestaurantPlay2.Areas.BookNow.ViewModels
{
		public class SaveBookingViewModel
		{
			public SaveBookingViewModel()
			{
				BookingId = 0;
			}

			public int BookingId { get; set; }
			[MaxLength(50)]
			[Required]
			[Display(Name = "Your Name")]
			public string Name { get; set; }
			[MaxLength(15)]
			[Required]
			[Display(Name = "Mobile No.")]
			public string MobileNumber { get; set; }
			[MaxLength(200)]
			[Display(Name="Email Addr.")]
			public string EmailAddress { get; set; }
			[Required]
			[Display(Name = "No. Attending")]
			public int HeadCount { get; set; }
			[MaxLength(250)]
			public string Comment { get; set; }
			[Required]
			[Display(Name = "The Occasion")]
			public int OccasionId { get; set; }
			[Required]
			public bool IsConfirmed { get; set; }
			[Required]
			[Display(Name = "Book For")]
			public DateTime DateFor { get; set; }
		}
}