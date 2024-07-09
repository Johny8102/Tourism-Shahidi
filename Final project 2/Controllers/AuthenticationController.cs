using Final_project_2.Models;
using Final_project_2.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Final_project_2.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly ITourismRepository<Person> _perosnRepository; 

        public AuthenticationController(ITourismRepository<Person> personRepo) { _perosnRepository = personRepo; }






        public IActionResult Index()
        {
            return View();
        }



      


    }
}
