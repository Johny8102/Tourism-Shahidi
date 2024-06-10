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

        public ReservationController(ITourismRepository<Reservation> ReserveRepo)
        {
            _ReserveRepo = ReserveRepo;
        }


        public IEnumerable<Reservation> GetAllReserve() => _ReserveRepo.GetAll();


        public string AddReserve(Reservation reserve)
        {
            _ReserveRepo.Create(reserve);

            return "Added Successfully";
        }

        public Reservation GetReserve(int id)=> _ReserveRepo.GetById(id);
        

        public string DeleteReservation(Reservation reserve)
        {
            _ReserveRepo.Delete(reserve.Id);
            return "Deleted Successfully";
        }

        public Reservation UpdateReserve(Reservation reserve)
        {
            _ReserveRepo.Update(reserve);
            return reserve;

        }

        //ublic async Task<Reservation> UpdateReserve(Reservation reserve)
        //{
        //    _context.Reservations.Update(reserve);
        //    await _context.SaveChangesAsync();
        //    return reserve;

        //}


    }
}
