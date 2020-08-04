using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Houseplants.Models;

namespace Houseplants.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IHouseplantRepository repoHouseplants;

        public HomeController(ILogger<HomeController> logger, IHouseplantRepository repo)
        {
            _logger = logger;
            repoHouseplants = repo;
        }

        public IActionResult Index()
        {
            return View(repoHouseplants.Houseplants);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
