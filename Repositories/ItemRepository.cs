using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyEatWebApp.Models;

namespace YummyEatWebApp.Repositories
{
    public class ItemRepository
    {
        private RestaurantDBEntities objRestaurantEntities;
        public ItemRepository()
        {
            objRestaurantEntities = new RestaurantDBEntities();
        }

        public IEnumerable<SelectListItem> GetAllItems()
        {
            var listItems = new List<SelectListItem>();
            listItems = (from obj in objRestaurantEntities.Items
                         select new SelectListItem()
                         {
                             Text = obj.ItemName,
                             Value = obj.ItemId.ToString(),
                             Selected = true
                         }).ToList();

            return listItems;
        }
    }
}