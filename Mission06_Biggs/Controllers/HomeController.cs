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
    }
}
