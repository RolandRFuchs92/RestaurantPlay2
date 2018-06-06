using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using System.Data.Entity;
using DataAccess.Context;

namespace DataAccess
{
		public class ItemListRepo
		{
				public AppsContext _db { get; set; }
				public ItemListRepo(AppsContext db)
				{
						_db = db;
				}

				/// <summary>
				/// Get All list items regardless of what ever.
				/// </summary>
				/// <returns></returns>
				public List<ItemList> GetAllListItems()
				{
						return _db.ItemLists.ToList();
				}

				/// <summary>
				/// Get ListItems by their category, refernce the category and order by the priority, desc.
				/// </summary>
				/// <param name="litItemCategory"></param>
				/// <returns></returns>
				public List<ItemList> GetListItemsByCateogry(int litItemCategory)
				{
						return (from item in _db.ItemLists
										where item.ItemListCategoryId == litItemCategory
										orderby item.ItemListPriority
										select item).ToList();
				}
		}
}
