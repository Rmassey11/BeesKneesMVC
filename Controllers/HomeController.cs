using BeesKneesMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BeesKneesMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult BKPage()
        {
            BeesKnees model = new();
            model.BeesValue = 3;
            model.KneesValue = 5;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BKPage(BeesKnees beesknees)
        {
            List<string> bkItems = new();
            bool bees;
            bool knees;
            for (int i = 1; i <= 100; i++)
            {
                bees = (i % beesknees.BeesValue == 0);
                knees = (i % beesknees.KneesValue == 0);
                if (bees == true && knees == true)
                {
                    bkItems.Add("BeesKnees");
                }
                else if (bees == true)
                {
                    bkItems.Add("Bees");
                }
                else if (knees == true)
                {
                    bkItems.Add("Knees");
                }
                else
                {
                    bkItems.Add(i.ToString());
                }
            }
            beesknees.Result = bkItems;
            return View(beesknees);
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