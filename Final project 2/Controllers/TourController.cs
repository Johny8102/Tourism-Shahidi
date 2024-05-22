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








        public IActionResult CreateToor()
        {
            return View();
        }




        public IActionResult CreateTour()
        {
            return View();
        }

        [HttpPost]
        public async Task<string> CreateTour(Tour tour)
        {
            //if (file != null && file.Length > 0)
            //{
                
            //        if (file != null && file.Length > 0)
            //        {
            //            string fileName = Path.GetFileName(file.FileName);
            //            string path = Path.Combine("./wwwroot/Images/", fileName);
            //            file.CopyTo(new FileStream(fileName, FileMode.Create));

                        

            //        }
                
            //        //todo Reposiory
                
            //}








            //await _context.Tour.AddAsync(tour);
            //await _context.SaveChangesAsync();
            
            return "Added Successfully";
        }



        [HttpPost]
        public async Task<string> CreateToor(IFormFile file ,  Tour tour)
        {
            if (file != null && file.Length > 0)
            {
                if (file != null && file.Length > 0)
                {
                    string fileName = Path.GetFileName(file.FileName);
                    string path = Path.Combine("./wwwroot/Images/", fileName);
                    file.CopyTo(new FileStream(fileName, FileMode.Create));
                }
                //todo Reposiory
            }

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
