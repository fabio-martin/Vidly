using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        private MyDbContext _context;

        public MoviesController()
        {
            _context = new MyDbContext();
        }
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };

            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"},
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);

        }

        // movies
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            var movies = _context.Movies
                .Include(c => c.Genre)
                .ToList();


            return View(movies);
        }

        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        [Route("movie/released/{year}/{month:regex(\\d(4)):range(1,12)}")]
        public ActionResult ByReleaseYear(int year, int month)
        {
            return Content(year + "/" + month);
        }

        // movies
        public ActionResult Details(int? Id)
        {
            var movie = _context.Movies
                .Include(c => c.Genre)
                .SingleOrDefault( c => c.Id == Id);


            return View(movie);
        }
    }
}