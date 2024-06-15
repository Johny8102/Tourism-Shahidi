using Final_project_2.Models;
using Final_project_2.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final_project_2.Controllers
{
    [Route("/Reservation/[action]")]
    public class ReservationController : Controller
    {
        private readonly ITourismRepository<Reservation> _ReserveRepo;
        private readonly ITourismRepository<Person> _PersonRepo;
        private readonly ITourismRepository<Active_Tours> _ActiveTourRepo;
        private readonly ITourismRepository<Tour> _TourRepo;
        public ReservationController(ITourismRepository<Reservation> ReserveRepo , ITourismRepository<Person> PersonRepo , ITourismRepository<Active_Tours> Active_ToursRepo, ITourismRepository<Tour> TourRepo)
        {
            _ReserveRepo = ReserveRepo;
            _ActiveTourRepo = Active_ToursRepo;
            _TourRepo = TourRepo;
            _PersonRepo = PersonRepo;


        }


        public IEnumerable<Reservation> GetAllReserve() => _ReserveRepo.GetAll();

        public IActionResult Index()
        {
            return View(GetAllReserve().Select(i=>new Reservation
            {
                Id = i.Id,
                Reserved_Count = i.Reserved_Count,
                Is_Actived = i.Is_Actived,
                Person_Name = _PersonRepo.GetById(i.fk_Person).Username,
                Tour_Name = _TourRepo.GetById(_ActiveTourRepo.GetById(i.fk_Active_Tour).fk_Tour).Tour_Name,
                Active_Tour = _ActiveTourRepo.GetById(i.fk_Active_Tour),
            }));
        }

        public IActionResult Index(int personId)
        {
            return View(GetAllReserve().Where(o=>o.fk_Person==personId).Select(i => new Reservation
            {
                Id = i.Id,
                Reserved_Count = i.Reserved_Count,
                Is_Actived = i.Is_Actived,
                Person_Name = _PersonRepo.GetById(i.fk_Person).Username,
                Tour_Name = _TourRepo.GetById(_ActiveTourRepo.GetById(i.fk_Active_Tour).fk_Tour).Tour_Name,
                Active_Tour = _ActiveTourRepo.GetById(i.fk_Active_Tour),
            }));
        }



        public string AddReserve(Reservation reserve)
        {
            _ReserveRepo.Create(reserve);

            return "Added Successfully";
        }

        public Reservation GetReserve(int id)=> _ReserveRepo.GetById(id);
        

        public string DeleteReservation(int id)
        {
            _ReserveRepo.Delete(id);
            return "Deleted Successfully";
        }

        public IActionResult RegisterReserve(int id)
        {
            var Item = GetReserve(id);
            Item.Is_Actived = true;
            _ReserveRepo.Update(Item);
            return RedirectToAction("Index", "Reservation");

        }




        //ublic async Task<Reservation> UpdateReserve(Reservation reserve)
        //{
        //    _context.Reservations.Update(reserve);
        //    await _context.SaveChangesAsync();
        //    return reserve;

        //}


    }
}
