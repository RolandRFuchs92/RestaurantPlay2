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
						ForDate = DateTime.Now;
						IsCanceled = false;
						IsConfirmed = false;
				}

				public int BookingId { get; set; }
				[MaxLength(50)]
				[Required]
				public string Name { get; set; }
				[MaxLength(15)]
				public string MobileNumber { get; set; }
				[MaxLength(200)]
				[Required]
				public string EmailAddress { get; set; }
				[Required]
				public int HeadCount { get; set; }
				[MaxLength(250)]
				public string Comment { get; set; }
				[Required]
				public int OccasionId { get; set; }
				[Required]
				public bool IsConfirmed { get; set; }
				[Required]
				public DateTime ForDate { get; set; }
				public bool IsCanceled { get; set; }
		}
}