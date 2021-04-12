using Microsoft.Ajax.Utilities;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vi.Models;
using vi.viewModel;

namespace vi.Controllers
{
    public class movieController : Controller
    {
        public ApplicationDbContext _context;
        public movieController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: movie
        public ActionResult random()
        {
            var movie = new movie() { name = "shrek" };
            var customer = new List<customer>
            {
                new customer{name="cust1"},
                new customer{name="cust2"}
            };
            var viewmodel = new RandomMovieViewModel
            {
                movie = movie,
                customers = customer,
            };
            return View(viewmodel);
        }
        [Route("movies/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult byreleased(int year, int month)
        {
            return Content(year + "/" + month);
        }
        [Route("movies")]
        public ActionResult movies()
        {
            var movie = _context.movies.Include(m => m.genreType).ToList();

            return View(movie);
        }
        [Route("movies/new")]
        public ActionResult New(){
            var movie = new AddMoviesViewModel
            {                
                Genres=_context.Genres.ToList(),
            };
            return View(movie);
        }
        [HttpPost]
        public ActionResult AddMovie(movie movie)
        {
            if (!ModelState.IsValid)
            {
                var Errmovie = new AddMoviesViewModel
                {
                    Movie= movie,
                    Genres = _context.Genres.ToList(),
                };
                return View("New",Errmovie);
                
            }
            if (movie.id == 0)
            {
                movie.dateAdded = DateTime.Now;
                _context.movies.Add(movie);
            }
            else
            {
                var MovieInDb = _context.movies.Single(m => m.id == movie.id);
                MovieInDb.dateReleased = movie.dateReleased;
                MovieInDb.name = movie.name;
                MovieInDb.genreTypeId = movie.genreTypeId;
                MovieInDb.stockAvailable = movie.stockAvailable;
            }
            _context.SaveChanges();
            return RedirectToAction("movies");
        }
        public ActionResult Edit(int id)
        {
            var movie = new AddMoviesViewModel
            {
                Movie = _context.movies.Single(m => m.id == id),
                Genres = _context.Genres.ToList(),
            };
            return View("New", movie);
        }
    }
}