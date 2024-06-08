using Final_project_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Final_project_2.Controllers
{
    [Route("/Person/[action]")]
    public class PersonController : Controller
    {

        private readonly Tourism _context;

        public PersonController(Tourism tourism)
        {
            _context = tourism;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IEnumerable<Person> GetAllPerson() => _context.Person;

        public IActionResult CreatePerson()
        {
            return View();
        }

        public IActionResult AdminPanel()
        {
            var tour = new TourController(_context);
            var person = new PersonController(_context);
            ViewBag.Tours = tour.GetAllTour().Select(i => new Tour()
            {
                Id = i.Id,
                Title = i.Title,
                Tour_Name = i.Tour_Name
            });

            ViewBag.Person = person.GetAllPerson().Select(i => new Person
            {
                Id = i.Id,
                Name = i.Name,
                Family = i.Family,
                Username = i.Username,
                Email = i.Email
            });

            ViewBag.Reservation = new ReservationController(_context).GetAllReserve().Select(i => new Reservation()
            {
                Id = i.Id,
                Reserved_Count = i.Reserved_Count,
                Tour_Name = tour.GetTour(new ActiveToursController(_context).GetActiveTour(i.fk_Active_Tour).fk_Tour).Tour_Name,
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
        public async Task<string> CreatePerson(Person person)
        {
            await _context.Person.AddAsync(person);
            await _context.SaveChangesAsync();

            return "Added Successfully";
        }

        public IActionResult Profile(int id)
        {
            
            return View(GetPerson(id));
        }


        public Person GetPerson(int id)
        {

            return _context.Person.FirstOrDefault(i => i.Id == id);
        }

        


        public async Task<string> DeletePerson(Person person)
        {
            _context.Person.Remove(person);
            await _context.SaveChangesAsync();
            return "Deleted Successfully";
        }

        public IActionResult EditPerson(int id)
        {
            return View(GetPerson(id));
        }

        public async Task<Person> UpdatePerson(Person person)
        {
            _context.Person.Update(person);
            await _context.SaveChangesAsync();
            return person;

        }


    }
}
