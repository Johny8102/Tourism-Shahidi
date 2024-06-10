using Final_project_2.Models;
using Final_project_2.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final_project_2.Controllers
{
    [Route("Comments/[action]")]
    public class CommentsController : Controller
    {
        private readonly ITourismRepository<Comments> _CommentsRepo;

        public CommentsController(ITourismRepository<Comments> CommentsRepo)
        {
            _CommentsRepo = CommentsRepo;
        }

        public IEnumerable<Comments> GetAllComment() => _CommentsRepo.GetAll();


        public  string  AddComment(Comments comment)
        {
            comment.Time = DateTime.Now;
            _CommentsRepo.Create(comment);
            return "Added Successfully";
        }

        public Comments GetComment(int id)=>  _CommentsRepo.GetById(id);

        public string  DeleteComment(Comments comment)
        {
            _CommentsRepo.Delete(comment.Id);
            return "Deleted Successfully";
        }

        public Comments UpdateComment(Comments comment)
        {
            comment.Time = DateTime.Now;
            _CommentsRepo.Update(comment);
            return comment;

        }


    }
}
