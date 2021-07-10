using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;
using AutoMapper;
using Vidly.App_Start;
using Vidly.Dtos;
using Vidly.Models;
using Vidly.ViewModels;


namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private readonly MyDbContext _context;

        private readonly IMapper mapper;


        public MoviesController()
        {
            _context = new MyDbContext();
            mapper = AutoMapperConfig.Mapper;
        }

        
        // GET /api/movies
        public IHttpActionResult GetMovies()
        {

            var moviesDto = _context.Movies
                .Include(m => m.Genre)
                .ToList()
                .Select(mapper.Map<MovieDto>);

            return Ok(moviesDto);
        }

        // GET /api/movies/{id}
        public IHttpActionResult GetMovie(int id)
        {

            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(mapper.Map<MovieDto>(movie));
        }

        // POST /api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = mapper.Map<Movie>(movieDto);

            _context.Movies.Add(movie);
            _context.SaveChanges();


            var uri = new Uri(Request.RequestUri + "/" + movie.Id);

            movieDto.Id = movie.Id;

            return Created(uri, movieDto);
        }


        // PUT /api/movies/{id}
        [HttpPut]

        public void EditMovie(int id, MovieDto movieDto)
        {

            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            mapper.Map(movieDto, movieInDb);

            _context.SaveChanges();

        }

        // PUT /api/movies/{id}
        [HttpDelete]

        public void DeleteMovie(int id)
        {

            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

        }


    }
}
