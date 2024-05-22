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


        [HttpPost]
        public async Task<string> CreatePerson(Person person)
        {
            await _context.Person.AddAsync(person);
            await _context.SaveChangesAsync();

            return "Added Successfully";
        }

        public IActionResult Prfile(int id)
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
