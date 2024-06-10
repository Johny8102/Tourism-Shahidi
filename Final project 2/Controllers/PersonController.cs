using Final_project_2.Models;
using Final_project_2.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Final_project_2.Controllers
{
    [Route("/Person/[action]")]
    public class PersonController : Controller
    {

        private readonly ITourismRepository<Person> _PersonRepo;
        private readonly ITourismRepository<Tour> _TourRepo;
        private readonly ITourismRepository<Comments> _CommentsRepo;
        private readonly ITourismRepository<Reservation> _ReservationsRepo;
        private readonly ITourismRepository<Active_Tours> _ActiveToursRepo;
        public PersonController(ITourismRepository<Person> Person , ITourismRepository<Tour> Tour, ITourismRepository<Comments> Comments , ITourismRepository<Reservation> Reserve , ITourismRepository<Active_Tours> ActiveToursRepo)
        {
            _PersonRepo = Person;
            _TourRepo = Tour;
            _CommentsRepo = Comments;
            _ReservationsRepo = Reserve;
            _ActiveToursRepo = ActiveToursRepo;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IEnumerable<Person> GetAllPerson() => _PersonRepo.GetAll();

        public IActionResult CreatePerson()
        {
            return View();
        }

        public IActionResult AdminPanel()
        {
            
            ViewBag.Tours = _TourRepo.GetAll().Select(i => new Tour()
            {
                Id = i.Id,
                Title = i.Title,
                Tour_Name = i.Tour_Name
            });

            ViewBag.Person = _PersonRepo.GetAll().Select(i => new Person
            {
                Id = i.Id,
                Name = i.Name,
                Family = i.Family,
                Username = i.Username,
                Email = i.Email
            });

            ViewBag.Reservation = _ReservationsRepo.GetAll().Select(i => new Reservation()
            {
                Id = i.Id,
                Reserved_Count = i.Reserved_Count,
                Tour_Name = _TourRepo.GetById(_ActiveToursRepo.GetById(i.fk_Active_Tour).fk_Tour).Tour_Name,
                Person_Name = i.Person.Username,
                Is_Actived = i.Is_Actived,
            });
            //i.Active_Tour.fk_Tour
            //ViewBag.Comments = new CommentsController(_context).GetAllComment().Select(i => new Comments()
            //{
            //    Id=i.Id,
            //    Person_Name= i.Person.Name,
            //    Tour_Name = i.Tour.Tour_Name,
            //    Text = i.Text,
            //    Is_Actived=i.Is_Actived
            //});



            return View();
        }

        [HttpPost]
        public string CreatePerson(Person person)
        {
            _PersonRepo.Create(person);

            return "Added Successfully";
        }

        public IActionResult Profile(int id)
        {
            
            return View(GetPerson(id));
        }


        public Person GetPerson(int id)
        {

            return _PersonRepo.GetById(id);
        }

        


        public string DeletePerson(Person person)
        {
            _PersonRepo.Delete(person.Id);
            return "Deleted Successfully";
        }

        public IActionResult EditPerson(int id)
        {
            return View(GetPerson(id));
        }

        public Person UpdatePerson(Person person)
        {
            _PersonRepo.Update(person);
            return person;

        }


    }
}
