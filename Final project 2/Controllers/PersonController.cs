using Final_project_2.Models;
using Final_project_2.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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

        //public IActionResult Login()
        //{
        //    return View();
        //}

        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Person person)
        {
            //if (ModelState.IsValid)
            //{
               
            //        var user = _PersonRepo.GetAll().Where(i=>i.Username == person.Username).FirstOrDefault();
                    
            //        if (user != null)
            //        {
            //            Person userModel = new Person()
            //            {
            //                Id = user.Id,
            //                Name = user.Name,
            //                Family = user.Family,
            //                Is_Admin = user.Is_Admin
            //                //UserId = user.UserId,
            //                //FirstName = user.FirstName,
            //                //LastName = user.LastName,
            //                //RoleName = user.Roles.Select(r => r.RoleName).ToList()
            //            };

            //            string userData = JsonConvert.SerializeObject(userModel);
            //            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket
            //                (
            //                1, loginView.UserName, DateTime.Now, DateTime.Now.AddMinutes(15), false, userData
            //                );

            //            string enTicket = FormsAuthentication.Encrypt(authTicket);
            //            HttpCookie faCookie = new HttpCookie("Cookie1", enTicket);
            //            Response.Cookies.Add(faCookie);
            //        }

            //        if (Url.IsLocalUrl(ReturnUrl))
            //        {
            //            return Redirect(ReturnUrl);
            //        }
            //        else
            //        {
            //            return RedirectToAction("Index");
            //        }
                
            //}
            //ModelState.AddModelError("", "Something Wrong : Username or Password invalid ^_^ ");
            //return View(loginView);

            return View();
        }

        public IActionResult Signup(Person person)
        {
            return View();
        }






        public IActionResult AdminPanel()
        {
            
            ViewBag.Tours = _TourRepo.GetAll().Take(4).Select(i => new Tour()
            {
                Id = i.Id,
                Title = i.Title,
                Tour_Name = i.Tour_Name,
                Description= i.Description,
                Touring_area = i.Touring_area
            });

            ViewBag.Person = _PersonRepo.GetAll().Take(4).Take(4).Select(i => new Person
            {
                Id = i.Id,
                Name = i.Name,
                Family = i.Family,
                Username = i.Username,
                Email = i.Email
            });

            ViewBag.Reservation = _ReservationsRepo.GetAll().Take(4).Select(i => new Reservation()
            {
                Id = i.Id,
                Reserved_Count = i.Reserved_Count,
                Tour_Name = _TourRepo.GetById(_ActiveToursRepo.GetById(i.fk_Active_Tour).fk_Tour).Tour_Name,
                Person_Name = _PersonRepo.GetById(i.fk_Person).Name,
                Is_Actived = i.Is_Actived,
            });
            
            ViewBag.Comments = _CommentsRepo.GetAll().Take(4).Select(i => new Comments()
            {
                Id = i.Id,
                Person_Name = _PersonRepo.GetById(i.fk_Person).Name,
                Tour_Name = _TourRepo.GetById(i.fk_Tour).Tour_Name,
                Time = i.Time,
                Text = i.Text,
                Is_Actived = i.Is_Actived
            });



            return View();
        }

        public IActionResult Index()
        {

            return View(GetAllPerson());
        }


        [HttpPost]
        public string CreatePerson(Person person)
        {
            _PersonRepo.Create(person);

            return "Added Successfully";
        }

        public IActionResult Profile(int id)
        {
            ViewBag.Person = GetPerson(id);
            ViewBag.Comments = _CommentsRepo.GetAll().Where(i => i.fk_Person == id).Select(i => new Comments()
            {
                Id = i.Id,
                Person_Name = _PersonRepo.GetById(i.fk_Person).Name,
                Tour_Name = _TourRepo.GetById(i.fk_Tour).Tour_Name,
                Time = i.Time,
                Text = i.Text,
                Is_Actived = i.Is_Actived
            });
            ViewBag.Reservation = _ReservationsRepo.GetAll().Where(i => i.fk_Person == id).Select(i => new Reservation()
            {
                Id = i.Id,
                Reserved_Count = i.Reserved_Count,
                Tour_Name = _TourRepo.GetById(_ActiveToursRepo.GetById(i.fk_Active_Tour).fk_Tour).Tour_Name,
                Person_Name = _PersonRepo.GetById(i.fk_Person).Name,
                Is_Actived = i.Is_Actived,
                fk_Tour = _ActiveToursRepo.GetById(i.fk_Active_Tour).fk_Tour
            });
            return View();
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
