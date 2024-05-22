using Final_project_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Final_project_2.Controllers
{
    public class ActiveToursController : Controller
    {
        private readonly Tourism _context;

        public ActiveToursController(Tourism context)
        {
            _context = context;
        }

        public IEnumerable<Active_Tours> GetAllTour() => _context.Active_Tours;


        public async Task<string> AddTour(Active_Tours tour)
        {
            await _context.Active_Tours.AddAsync(tour);
            await _context.SaveChangesAsync();

            return "Added Successfully";
        }

        public Active_Tours GetTour(int id)
        {

            return _context.Active_Tours.FirstOrDefault(i => i.Id == id);
        }

        public async Task<string> DeleteTour(Active_Tours tour)
        {
            _context.Active_Tours.Remove(tour);
            await _context.SaveChangesAsync();
            return "Deleted Successfully";
        }

        public async Task<Active_Tours> UpdateTour(Active_Tours tour)
        {
            _context.Active_Tours.Update(tour);
            await _context.SaveChangesAsync();
            return tour;

        }
    }
}
