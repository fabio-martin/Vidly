using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.App_Start;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class RentalsController : ApiController
    {

        private ApplicationDbContext _context;

        private readonly IMapper mapper;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
            mapper = AutoMapperConfig.Mapper;
        }


        [HttpPost]
        public IHttpActionResult CreateNewRental(NewRentalDto newRental)
        {
            var customer = _context.Customers.Single(c => c.Id == newRental.CustomerId);

            List<Movie> moviesList = new List<Movie>();

            var movies = _context.Movies.Where(
                m => newRental.MovieIds.Contains(m.Id));


            foreach (var movie in movies)
            {
                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }


            return Ok();
        }
    }
}
