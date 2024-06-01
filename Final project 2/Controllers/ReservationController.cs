using Final_project_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final_project_2.Controllers
{
    public class ReservationController : Controller
    {
        private readonly Tourism _context;

        public ReservationController(Tourism tourism)
        {
            _context = tourism;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IEnumerable<Reservation> GetAllReserve() => _context.Reservations;


        public async Task<string> AddReserve(Reservation reserve)
        {
            await _context.Reservations.AddAsync(reserve);
            await _context.SaveChangesAsync();

            return "Added Successfully";
        }

        public Reservation GetReserve(int id)
        {

            return _context.Reservations.FirstOrDefault(i => i.Id == id);
        }

        public async Task<string> DeleteReservation(Reservation reserve)
        {
            _context.Reservations.Remove(reserve);
            await _context.SaveChangesAsync();
            return "Deleted Successfully";
        }

        public async Task<Reservation> UpdateReserve(Reservation reserve)
        {
            _context.Reservations.Update(reserve);
            await _context.SaveChangesAsync();
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
