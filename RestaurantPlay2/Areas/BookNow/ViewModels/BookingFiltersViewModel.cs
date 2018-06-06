using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestaurantPlay2.Areas.BookNow.ViewModels
{
	public class BookingFiltersViewModel
	{
		[Display(Name = "From When?")]
		public DateTime? FromDate { get; set; }
		[Display(Name = "To When?")]
		public DateTime? ToDate { get; set; }
		[Display(Name="Keyword")]
		public string Keyword { get; set; }
		public bool? IsConfirmed { get; set; }
		public bool? IsCanceled { get; set; }
	}
}