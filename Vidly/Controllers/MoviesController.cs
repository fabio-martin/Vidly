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

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
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

        // movies
        public ActionResult New(int? Id)
        {
            var genres = _context.Genres.ToList();
            var movie = _context.Movies.SingleOrDefault(m => m.Id == Id) ?? new Movie();

            var viewModel = new MovieFormViewModel()
            {
                Movie = movie,
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }



        // movies
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now; 
                _context.Movies.Add(movie);

            }
            else
            {
                var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.Genre = movie.Genre;
                movieInDb.NumberInStock += movie.NumberInStock;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
    }
}