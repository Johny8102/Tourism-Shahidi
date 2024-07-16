using Final_project_2.Models;
using Final_project_2.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Final_project_2.Services;



namespace Final_project_2.Controllers
{
    [Route("/Home/[action]")]
    //[SessionAuthorize]
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
    
        
        public IActionResult chngLng(string lang)
        {
            if (!string.IsNullOrEmpty(lang))
            {
                Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(lang);
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);
            }
            else
            {
                Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en");
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
                lang = "en";
            }
            Response.Cookies.Append("Language", lang);
            return Redirect(Request.GetTypedHeaders().Referer.ToString());

        }


    
    }
}
