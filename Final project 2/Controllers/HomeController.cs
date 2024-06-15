using Final_project_2.Models;
using Final_project_2.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Final_project_2.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        private readonly ITourismRepository<Tour> _TourRepo;
        //private readonly ILogger<HomeController> _logger;
        //private readonly ILogger<HomeController> _logger;
        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController(ITourismRepository<Tour>  TourRepo)
        {
            _TourRepo = TourRepo;
        }


        public IActionResult Index()
        {
            ViewBag.Tours = _TourRepo.GetAll(); 
            return View();
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
