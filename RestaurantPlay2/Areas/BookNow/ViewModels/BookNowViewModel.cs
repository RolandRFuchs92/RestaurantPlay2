using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantPlay2.Areas.BookNow.ViewModels
{
		public class BookNowViewModel
		{
				public int Id { get; set; }
				public string  Name { get; set; }
				public string MobileNumber { get; set; }
				public string EmailAddress { get; set; }
				public int HeadCount { get; set; }
				public string Comments { get; set; }
				public string Occasion { get; set; }
				public bool IsConfirmed { get; set; }
				public bool IsCanceled { get; set; }
				public DateTime ForDate { get; set; }
				public DateTime CreatedOn { get; set; }
		}
}