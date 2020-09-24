using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using YummyEatWebApp.Models;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Web.UI.WebControls;

namespace YummyEatWebApp.Repositories
{
    public class PaymentTypeRepository
    {
        private RestaurantDBEntities objRestaurantEntities;
       public PaymentTypeRepository()
        {
            objRestaurantEntities = new RestaurantDBEntities();
        }

        public IEnumerable<SelectListItem> GetAllPaymentTypes()
        {
            var listItems = new List<SelectListItem>();
            listItems = (from obj in objRestaurantEntities.PaymentTypes
                         select new SelectListItem()
                         {
                             Text = obj.PaymentTypeName,
                             Value = obj.PaymentTypeId.ToString(),
                             Selected = true
                         }).ToList();

            return listItems;
        }

    }
}