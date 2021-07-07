using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Vidly.Models;
using WebGrease.Activities;
using System.Data.Entity;


namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {

        private MyDbContext _context;

        public CustomersController()
        {
            _context = new MyDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        public ViewResult Index()
        {

            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            
            return View(customers);
        }

        public ActionResult Details(int? id)
        {
            
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            
            if (customer == null)
            {
                return HttpNotFound();
            }
            
            return View(customer);
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