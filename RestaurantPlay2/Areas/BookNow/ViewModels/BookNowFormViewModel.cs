using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Management;

namespace RestaurantPlay2.Areas.BookNow.ViewModels
{
		public class BookNowFormViewModel
		{
				public BookNowFormViewModel()
				{
						BookingId = 0;
				}
				public int BookingId { get; set; }
				[MaxLength(50)]
				[Required]
				public string Name { get; set; }
				[MaxLength(15)]
				[Required]
				public string MobileNumber { get; set; }
				[MaxLength(200)]
				public string EmailAddress { get; set; }
				[Required]
				public int HeadCount { get; set; }
				[MaxLength(250)]
				public string Comment { get; set; }
				[Required]
				public int OccasionId { get; set; }
				[Required]
				public bool IsConfirmed { get; set; }
		}
}