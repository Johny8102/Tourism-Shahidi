using Final_project_2.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Final_project_2.Controllers
{
    
    [Route("/ActiveTours/[action]")]
    public class ActiveToursController : Controller
    {
        private readonly Tourism _context;

        public ActiveToursController(Tourism context)
        {
            _context = context;
        }

        public IEnumerable<Active_Tours> GetAllActiveTour() => _context.Active_Tours;

        [HttpPost]
        public async Task<string> AddTour(Active_Tours activetour)
        {
            activetour.Tour = new TourController(_context).GetTour(activetour.Tour_Id);
            await _context.Active_Tours.AddAsync(activetour);
            await _context.SaveChangesAsync();

            return "Added Successfully";
        }

        public Active_Tours GetActiveTour(int id)
        {

            return _context.Active_Tours.FirstOrDefault(i => i.Id == id);
        }

        public async Task<string> DeleteActiveTour(Active_Tours tour)
        {
            _context.Active_Tours.Remove(tour);
            await _context.SaveChangesAsync();
            return "Deleted Successfully";
        }

        public async Task<Active_Tours> UpdateActiveTour(Active_Tours tour)
        {
            _context.Active_Tours.Update(tour);
            await _context.SaveChangesAsync();
            return tour;

        }
    }
}
