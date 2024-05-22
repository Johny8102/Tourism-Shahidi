using Final_project_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final_project_2.Controllers
{
    public class CommentsController : Controller
    {
        private readonly Tourism _context;

        public CommentsController(Tourism tourism)
        {
            _context = tourism;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}


        public IEnumerable<Comments> GetAllComment() => _context.Comments;


        public async Task<string> AddComment(Comments comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();

            return "Added Successfully";
        }

        public Comments GetComment(int id)
        {

            return _context.Comments.FirstOrDefault(i => i.Id == id);
        }

        public async Task<string> DeleteComment(Comments comment)
        {
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return "Deleted Successfully";
        }

        public async Task<Comments> UpdateComment(Comments comment)
        {
            _context.Comments.Update(comment);
            await _context.SaveChangesAsync();
            return comment;

        }


    }
}
