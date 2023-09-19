using DiscountManagementService.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiscountManagementService.Controllers
{

    [Route("api/Discount")]
    [ApiController]
    public class DiscountController : Controller
    {
        private IDiscountprocessor _discountprocessor = null;

        public DiscountController(IDiscountprocessor discountprocessor)
        {
            _discountprocessor = discountprocessor;
        }
        public ActionResult Index()
        {
            #region Customer DataPrep
            Customer customer1 = new Customer();
            customer1.ID = 1;
            customer1.Name = "Alex";
            customer1.CustomerType = "N";
            customer1.JoinedDate = new DateTime(2020, 1, 15);

            Customer customer2 = new Customer();
            customer2.ID = 2;
            customer2.Name = "Nayn";
            customer2.CustomerType = "S";
            customer2.JoinedDate = new DateTime(2022, 11, 15);

            Customer customer3 = new Customer();
            customer3.ID = 3;
            customer3.Name = "Rob";
            customer3.CustomerType = "G";
            customer3.JoinedDate = new DateTime(2023, 1, 15);

            Customer customer4 = new Customer();
            customer4.ID = 1;
            customer4.Name = "PLatip";
            customer4.CustomerType = "P";
            customer4.JoinedDate = new DateTime(2010, 1, 15);
            #endregion

            var a = _discountprocessor.GetBaseDiscount(customer1);
            var b = _discountprocessor.GetBaseDiscount(customer2);
            var c = _discountprocessor.GetBaseDiscount(customer3);
            var d = _discountprocessor.GetBaseDiscount(customer4);

            List<int> results = new List<int>();
            results.Add(a);
            results.Add(b);
            results.Add(c);
            results.Add(d);
            return Ok(results);
        }
    }
}
