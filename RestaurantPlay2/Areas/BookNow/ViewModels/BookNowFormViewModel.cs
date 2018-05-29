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
			public SaveBookingViewModel SaveBookingViewModel { get; set; }
			public ListCategoryViewModel ListCategoryViewModel { get; set; }
		}
}