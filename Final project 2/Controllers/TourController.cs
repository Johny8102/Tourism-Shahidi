using Final_project_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Final_project_2.Controllers
{
    [Route("/Tour/[action]")]
    public class TourController : Controller
    {
        private readonly Tourism _context;

        public TourController(Tourism context)
        {
            _context = context;
        }



        





        


        
        public IActionResult CreateTour()
        {
            return View();
        }

        public string ImageAdder(IFormFile file)
        {
            
            if (file != null && file.Length > 0)
            { 
                //string fileName = Path.GetFileName(file.FileName);
                string fileName = $@"{Guid.NewGuid()}.PNG";
                var tye = file.ContentType;
                string path = Path.Combine("./wwwroot/Images/", fileName);
                file.CopyTo(new FileStream(path, FileMode.Create));
                //$@"{Guid.NewGuid()}.txt";

                return fileName;
            }

            return string.Empty;

            //todo Reposiory

            
        }


        [HttpPost]
        public async Task<string> CreateTour(Tour_Items tour)
        {
            var tour_obj = new Tour()
            {
                Image1 = tour.Image1,
                Image2 = tour.Image2,
                Capacity = tour.Capacity,
                Description = tour.Description,
                Id = tour.Id,
                Image3 = tour.Image3,
                Image4 = tour.Image4,
                Image5 = tour.Image5,   
                Touring_area = tour.Touring_area,
                Image_bg = ImageAdder(tour.Image_bg),
                Is_Acive = tour.Is_Acive,
                Price_per_person = tour.Price_per_person,
                Quality_level = tour.Quality_level,
                Rules = tour.Rules,
                Status_limit = tour.Status_limit,   
                Title = tour.Title,
                Tour_Name= tour.Tour_Name
            };







            //await _context.Tour.AddAsync(tour);
            //await _context.SaveChangesAsync();

            return "Added Successfully";
        }



        [Route("/Tour")]
        [Route("/Tour/Index")]
        public IActionResult Index()
        {
            return View();
        }
        public Tour GetTour(int id)
        {
            
            return _context.Tour.FirstOrDefault(i => i.Id == id);
        }

        public IEnumerable<Tour> GetAllTour() => _context.Tour.Include(i => i.Is_Acive);



        public IActionResult DeleteTour()
        {
            return View("DeleteTour");
        }
        
        public async Task<string> DeleteTour(int id)
        {
            _context.Tour.Remove(GetTour(id));
            await _context.SaveChangesAsync();
            return "Deleted Successfully";
        }

        public async Task<Tour> UpdateTour(Tour tour)
        {
            _context.Tour.Update(tour);
            await _context.SaveChangesAsync();
            return tour;

        }



        //public IActionResult<List<Tour>> Index()
        //{
        //    var _db = _context.Tour

        //    return View();
        //}
    }
}
