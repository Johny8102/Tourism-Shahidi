﻿using Final_project_2.Models;
using Final_project_2.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Drawing;

namespace Final_project_2.Controllers
{
    [Route("/Tour/[action]")]
    public class TourController : Controller
    {
        private readonly ITourismRepository<Tour> _ToursRepo;
        private readonly ITourismRepository<Active_Tours> _ActiveToursRepo;
        private readonly ITourismRepository<Comments> _CommentsRepo;
        private readonly ITourismRepository<Person> _PersonRepo;

        public TourController(ITourismRepository<Tour> ToursRepo, ITourismRepository<Active_Tours> ActiveToursRepo, ITourismRepository<Comments> CommentsRepo, ITourismRepository<Person> PersonRepo)
        {
            _ToursRepo = ToursRepo;
            _ActiveToursRepo = ActiveToursRepo;
            _CommentsRepo = CommentsRepo;
            _PersonRepo = PersonRepo;
        }

        public string ImageAdder(IFormFile file)
        {
            
            if (file != null && file.Length > 0)
            { 
                //string fileName = Path.GetFileName(file.FileName);
                string fileName = $@"{Guid.NewGuid()}.PNG";
                string path = Path.Combine("./wwwroot/Images/", fileName);
                file.CopyTo(new FileStream(path, FileMode.Create));
                //$@"{Guid.NewGuid()}.txt";

                return fileName;
            }

            return string.Empty;

            //todo Reposiory

            
        }


        public IActionResult Index()
        {
            return View(GetAllTour());
        }






        public IActionResult CreateTour()
        {
            return View();
        }

        [HttpPost]
        public string CreateTour(Tour_Items tour)
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
                Image_bg = ImageAdder(tour.Image_holderbg)
            };


            _ToursRepo.Create(tour_obj);

            return "Added Successfully";
        }







        public Tour GetTour(int id) => _ToursRepo.GetById(id);

        public IActionResult Tour(int id)
        {
            if (id <= 0) return NotFound();
            ViewBag.Tour = _ToursRepo.GetById(id);
            ViewBag.Active_Tours = _ActiveToursRepo.GetAll().Where(i=>i.fk_Tour == id);
            ViewBag.Comments = GetCommentsWithRep(id);



            return View();
        }

        public IEnumerable<Comments> GetCommentsWithRep(int fk_tour, int? fk_Comment = null)
        {
            var result =  _CommentsRepo.GetAll().Where(i => i.fk_Tour == fk_tour).Where(u => u.Is_Actived).Where(i => i.fk_comment == fk_Comment).Select(i => new Comments
            {
                Id = i.Id,
                Person_Name = _PersonRepo.GetById(i.fk_Person).Username,
                Text = i.Text,
                Time = i.Time,
               
                Replies = GetCommentsWithRep(fk_tour,i.Id)
            });
            return result;
        }



        public IEnumerable<Tour> GetAllTour() => _ToursRepo.GetAll();



        public IActionResult DeleteTour(int id)=>  View(GetTour(id));
        

        [HttpPost]
        public string DeleteTour(Tour tour)
        {
            _ToursRepo.Delete(tour.Id);
            return "Deleted Successfully";
        }

        private Image findImage(string image_name)
        {
            string path = Path.Combine("./wwwroot/Images/", image_name);
            var formFile = Image.FromFile(path);

            
            return formFile;

        }

        public IActionResult UpdateTour(int id)
        {
            if (id == 0) return View("/Error/NotFound");
            var temp_data = GetTour(id);
            Tour_Items form_data = new()
            {
                Capacity = temp_data.Capacity,
                Description = temp_data.Description,
                Is_Acive = temp_data.Is_Acive,
                Price_per_person = temp_data.Price_per_person,
                Quality_level = temp_data.Quality_level,
                Rules = temp_data.Rules,
                Status_limit = temp_data.Status_limit,
                Title = temp_data.Title,
                Touring_area = temp_data.Touring_area,
                Tour_Name = temp_data.Tour_Name,
                //Image_propertie0 = findImage(temp_data.Image_bg),
                //Image_propertie1 = findImage(temp_data.Image1),
                //Image_propertie2 = findImage(temp_data.Image2),
                //Image_propertie3 = findImage(temp_data.Image3),
                //Image_propertie4 = findImage(temp_data.Image4),
                //Image_propertie5 = findImage(temp_data.Image5),
                Image_bg = temp_data.Image_bg,
                Image1 = temp_data.Image1,
                Image2 = temp_data.Image2,
                Image3 = temp_data.Image3,
                Image4 = temp_data.Image4,
                Image5 = temp_data.Image5,
                Id = id
            };



            return View(form_data);
        }

        [HttpPost]
        public Tour UpdateTour(Tour_Items tour)
        {
            var tour_temp = new Tour()
            {
                Capacity = tour.Capacity,
                Description = tour.Description,
                Image1 = tour.Image_holder1==null ? tour.Image1 : ImageAdder(tour.Image_holder1),
                Image2 = tour.Image_holder2 == null ? tour.Image2 : ImageAdder(tour.Image_holder2),
                Image3 = tour.Image_holder3 == null ? tour.Image3 : ImageAdder(tour.Image_holder3),
                Image4 = tour.Image_holder4 == null ? tour.Image4 : ImageAdder(tour.Image_holder4),
                Image5 = tour.Image_holder5 == null ? tour.Image5 : ImageAdder(tour.Image_holder5),
                Image_bg = tour.Image_holderbg == null ? tour.Image_bg : ImageAdder(tour.Image_holderbg),
                Is_Acive = tour.Is_Acive,
                Price_per_person = tour.Price_per_person,
                Quality_level = tour.Quality_level,
                Rules = tour.Rules,
                Status_limit = tour.Status_limit,
                Title = tour.Title,
                Touring_area = tour.Touring_area,
                Tour_Name = tour.Tour_Name,
                Id = tour.Id


            };


            _ToursRepo.Update(tour_temp);
            return tour_temp;

        }



        //public IActionResult<List<Tour>> Index()
        //{
        //    var _db = _context.Tour

        //    return View();
        //}
    }
}
