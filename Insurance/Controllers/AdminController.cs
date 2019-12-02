using Insurance.Models;
using Insurance.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Insurance.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            using (db_insuranceEntities1 db = new db_insuranceEntities1())
            {
                var customer = (from c in db.Customers
                                where c.FirstName != null
                               select c).ToList();
                var customerVms = new List<CustomerVm>();
                foreach (var quotes in customer)
                {
                    var customerVm = new CustomerVm();
                    customerVm.Id = quotes.Id;
                    customerVm.FirstName = quotes.FirstName;
                    customerVm.LastName = quotes.LastName;
                    customerVm.EmailAddress = quotes.EmailAddress;
                    customerVm.Quote = Convert.ToInt32(quotes.Quote);
                    customerVms.Add(customerVm);
                }

                return View(customerVms);
            }
        }
    }
}