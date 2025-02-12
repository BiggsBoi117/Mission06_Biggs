using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Biggs.Models;

namespace Mission06_Biggs.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult AddMovie()
        {
            return View();
        }
    }
}
