using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using Vidly.Models;
using WebGrease.Activities;


namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Movies
        public ViewResult Index()
        {

            var customers = GetCustomers();
            
            return View(customers);
        }

        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "error");
            }
                

            return View(new Customer { Id = 1, Name = "John Smith" });
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "John Smith" },
                new Customer { Id = 2, Name = "Mary Williams" }
            };
        }
    }
}