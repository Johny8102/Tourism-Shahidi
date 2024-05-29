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
                Tour_Name = tour.Tour_Name,
                Capacity = tour.Capacity,
                Description = tour.Description,
                Touring_area = tour.Touring_area,
                Is_Acive = tour.Is_Acive,
                Price_per_person = tour.Price_per_person,
                Quality_level = tour.Quality_level,
                Rules = tour.Rules,
                Status_limit = tour.Status_limit,   
                Title = tour.Title,
                Image1 = ImageAdder(tour.Image_holder1),
                Image2 = ImageAdder(tour.Image_holder2),
                Image3 = ImageAdder(tour.Image_holder3),
                Image4 = ImageAdder(tour.Image_holder4),
                Image5 = ImageAdder(tour.Image_holder5),
                Image_bg = ImageAdder(tour.Image_bg)
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
