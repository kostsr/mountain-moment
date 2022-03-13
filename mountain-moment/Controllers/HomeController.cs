using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mountain_moment.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace mountain_moment.Controllers
{
    public class HomeController : Controller
    {
        GalleryContext db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, GalleryContext context)
        {
            _logger = logger;
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public List<Album> get_albums()
        {
            return db.Albums.ToList();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
