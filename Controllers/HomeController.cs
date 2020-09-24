using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyEatWebApp.Models;
using YummyEatWebApp.Repositories;

namespace YummyEatWebApp.App_Start
{
    public class HomeController : Controller
    {
        private RestaurantDBEntities objEntities;
        public HomeController()
        {
            objEntities = new RestaurantDBEntities();
        }
        // GET: Home
        public ActionResult Index()
        {
            CustomerRepository customerRepo = new CustomerRepository();
            ItemRepository itemRepo = new ItemRepository();
            PaymentTypeRepository paymentTypeRepo = new PaymentTypeRepository();

            var objMultipleObjects = new Tuple<IEnumerable<SelectListItem>, IEnumerable<SelectListItem>, IEnumerable<SelectListItem>>
                (customerRepo.GetAllCustomers(), itemRepo.GetAllItems(), paymentTypeRepo.GetAllPaymentTypes());
            return View(objMultipleObjects);
        }

        [HttpGet]
        public JsonResult getItemPrice(int itemId)
        {
            decimal? itemPrice = objEntities.Items.Single(model => model.ItemId == itemId).ItemPrice;

            return Json(itemPrice, JsonRequestBehavior.AllowGet);

        }
    }
}