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
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View(new Movie());
            
        }

        [HttpPost]
        public IActionResult AddMovie(Movie movie)
        {
            
            if (ModelState.IsValid)
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();
            }
            else
            {
                ViewBag.Categories = _context.Categories
                    .OrderBy(x => x.CategoryName)
                    .ToList();
                return View("AddMovie", movie);
            }

            return View("Confirmation", movie);
        }

        public IActionResult MovieList()
        {
            var Movies = _context.Movies
                .OrderBy(x => x.Title)
                .ToList();

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View(Movies);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movieToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("AddMovie", movieToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Movie movieToEdit)
        {
            _context.Update(movieToEdit);
            _context.SaveChanges();

            return View("Confirmation", movieToEdit);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movieToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(movieToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movie movieToDelete)
        {
            _context.Movies.Remove(movieToDelete);
            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }
     
    }
}
