using CA_MVC_Customer.Models;
using Microsoft.AspNetCore.Mvc;

namespace CA_MVC_Customer.Controllers
{
    public class CustomerController : Controller
    {
        ICustomer _customerrp;

        public CustomerController(ICustomer customerrp)
        {
            _customerrp = customerrp;
        }

        public IActionResult Index()
        {
            var customerList = _customerrp.GetAllCustomers();

            return View(customerList);
        }

    }
}
