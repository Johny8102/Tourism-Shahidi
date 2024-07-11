using Final_project_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Final_project_2.Controllers
{
    public class ImagesController : Controller
    {
        private readonly TourismDbcontext _context;

        public ImagesController(TourismDbcontext context)
        {
            _context = context;
        }

        public IEnumerable<Images> GetAllTour() => _context.Images;


        public async Task<string> AddTour(Images img)
        {
            await _context.Images.AddAsync(img);
            await _context.SaveChangesAsync();

            return "Added Successfully";
        }

        public Images GetTour(int id)
        {

            return _context.Images.FirstOrDefault(i => i.Id == id);
        }

        public async Task<string> DeleteTour(Images img)
        {
            _context.Images.Remove(img);
            await _context.SaveChangesAsync();
            return "Deleted Successfully";
        }

        public async Task<Images> UpdateTour(Images img)
        {
            _context.Images.Update(img);
            await _context.SaveChangesAsync();
            return img;

        }
    }
}
