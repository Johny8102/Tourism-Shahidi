using Final_project_2.Models;
using Final_project_2.Repository;
using Final_project_2.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Final_project_2.Controllers
{
    
    [Route("/ActiveTours/[action]")]
    public class ActiveToursController : Controller
    {
        private readonly ITourismRepository<Active_Tours> _Repository;
        private readonly ITourismRepository<Tour> _TourRepository;
        public ActiveToursController(ITourismRepository<Active_Tours> Repository , ITourismRepository<Tour> tourRepository)
        {
            _Repository = Repository;
            _TourRepository = tourRepository;
        }

        public IEnumerable<Active_Tours> GetAllActiveTour() => _Repository.GetAll();

        [HttpPost]
        public IActionResult AddTour(Active_Tours activetour)
        {
            
            //activetour.Tour = new TourController(new Repository<Tour>()).GetTour(activetour.fk_Tour);
            _Repository.Create(activetour);

            return RedirectToAction("Index", "Tour");
        }

        public Active_Tours GetActiveTour(int id)=> _Repository.GetById(id);


        [HttpPost]
        public string DeleteActiveTour(int id)
        {
            _Repository.Delete(id);
            return "Deleted Successfully";
        }

        public Active_Tours UpdateActiveTour(Active_Tours tour)
        {
            _Repository.Update(tour);
            return tour;

        }
    }
}
