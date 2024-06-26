using Final_project_2.Models;
using Final_project_2.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;



namespace Final_project_2.Controllers
{
    [Route("/Home/[action]")]
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

        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Access" , "Index");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
