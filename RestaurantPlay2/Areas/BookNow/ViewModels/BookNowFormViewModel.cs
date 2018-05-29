using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace RestaurantPlay2.Areas.BookNow.ViewModels
{
		public class BookNowFormViewModel
		{
				public BookNowFormViewModel()
				{
						HeadCountList = (from i in Enumerable.Range(1, 25)
														 select new SelectListItem
														 {
																 Value = i.ToString(),
																 Text = i.ToString()
														 }).ToList();
				}
				public SaveBookingViewModel SaveBookingViewModel { get; set; }
				public List<SelectListItem> ListCategoryViewModel { get; set; }
				public List<SelectListItem> HeadCountList { get; set; }
		}
}