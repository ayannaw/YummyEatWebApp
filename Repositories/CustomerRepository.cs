using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyEatWebApp.Models;

namespace YummyEatWebApp.Repositories
{
    public class CustomerRepository
    {
        private RestaurantDBEntities objRestaurantEntities;
        public CustomerRepository()
        {
            objRestaurantEntities = new RestaurantDBEntities();
        }

        public IEnumerable<SelectListItem> GetAllCustomers()
        {
            var listItems = new List<SelectListItem>();
            listItems = (from obj in objRestaurantEntities.Customers
                         select new SelectListItem()
                         {
                             Text = obj.CustomerName,
                             Value = obj.CustomerId.ToString(),
                             Selected = true
                         }).ToList();

            return listItems;
        }
    }
}