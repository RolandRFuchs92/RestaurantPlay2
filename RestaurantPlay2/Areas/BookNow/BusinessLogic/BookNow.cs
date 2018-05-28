using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess.Context;
using RestaurantPlay2.Areas.BookNow.ViewModels;

namespace RestaurantPlay2.Areas.BookNow.BusinessLogic
{
    public class BookNow
    {
        public List<ListCategoryViewModel> GetListCategoryViewModel()
        {
            

            return new AppsContext().ItemLists.Where(i => i.ListCategoryId == 1).ToList();
        }
    }
}