using Insurance.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Insurance.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Customer(string firstName, string lastName, string emailAddress,
                                    DateTime DOB, int CarYear, string CarMake, string CarModel,
                                    string DUI, int Tickets, string Coverage, double Quote)
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


                var today = DateTime.Now;
                var age = today.Year - DOB.Year;
                
                double quote = 50;
                if (age < 25 && age > 18)
                {
                    quote += 25;
                }
                else if (age < 18)
                {
                    quote += 100;
                }
                else if (age >100)
                {
                    quote += 25;
                }

                if (CarYear < 2000 || CarYear > 2015)
                {
                    quote += 25;
                }

                if (CarMake == "Porsche")
                {
                    quote += 25;
                }

                if (CarMake == "Porsche" && CarModel == "911 Carrera")
                {
                    quote += 25;
                }

                quote += Tickets * 10;

                if (DUI == "Yes")
                {
                    quote = quote * 1.25;
                }

                if (Coverage == "Full Coverage")
                {
                    quote = quote * 1.5;
                }

                customer.Quote = Convert.ToInt32(quote);

                ViewData["quote"] = quote;

                db.Customers.Add(customer);
                db.SaveChanges();
                return View("Quote");
            }
        }
    }
}