using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Biggs.Models;

namespace Mission06_Biggs.Controllers
{
    public class HomeController : Controller
    {
        private MovieDBContext _context;

        public HomeController(MovieDBContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(MovieModel movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return View("Confirmation", movie);
        }

        public IActionResult MovieList()
        {
            var Movies = _context.Movies
                .OrderBy(x => x.Title)
                .ToList();

            return View(Movies);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movie = _context.Movies
                .Single(x => x.movieId == id);

            return View("AddMovie", movie);
        }

        [HttpPost]
        public IActionResult Edit(MovieModel movie)
        {
            _context.Update(movie);
            _context.SaveChanges();

            return View("Confirmation", movie);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = _context.Movies
                .Single(x => x.movieId == id);

            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(MovieModel movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }
     
    }
}
