using CarInsurance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarInsurance.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Customer(string firstName, string lastName, string emailAddress,
                                    string DOB, int CarYear, string CarMake, string CarModel,
                                    string DUI, int Tickets, string Coverage, int Quote)
        {
            using (db_insuranceEntities1 db = new db_insuranceEntities1())
            {
                var customer = new Customer();
                customer.FirstName = firstName;
                customer.LastName = lastName;
                customer.EmailAddress = emailAddress;
                customer.DOB = Convert.ToDateTime(DOB).Date;
                customer.CarYear = Convert.ToInt32(CarYear);
                customer.CarMake = CarMake;
                customer.CarModel = CarModel;
                customer.DUI = DUI;
                customer.Tickets = Convert.ToInt32(Tickets);
                customer.Coverage = Coverage;
                customer.Quote = Convert.ToInt32(Quote);

                db.Customers.Add(customer);
                db.SaveChanges();
                return View("Quote");
            }
        }
    }
}