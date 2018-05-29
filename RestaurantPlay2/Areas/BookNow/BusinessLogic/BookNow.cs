using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess.Context;
using RestaurantPlay2.Areas.BookNow.ViewModels;
using DataAccess;

namespace RestaurantPlay2.Areas.BookNow.BusinessLogic
{
		public class BookNow
		{
				private readonly int _CategoryId = 1;
				public List<ListCategoryViewModel> GetListCategoryViewModel()
				{
						var db = new AppsContext();
						var itemList = new ItemListRepo(db).GetListItemsByCateogry(_CategoryId);
						var model = (from item in itemList
												 select new ListCategoryViewModel
												 {
														 Id = item.ListId,
														 Name = item.ListData
												 }).ToList();

						return model;
				}
		}
}