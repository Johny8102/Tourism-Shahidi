using Microsoft.AspNetCore.Mvc;

namespace Final_project_2.Controllers
{
    [Route("/Error/[Action]")]
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View("error");
        }

        
        public ViewResult NotFound()
        {
            Response.StatusCode = 404;  //you may want to set this to 200
            return View("NotFound");
        }

    }
}





