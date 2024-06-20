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
        private readonly ITourismRepository<Person> _PersonRepo;
        private readonly ITourismRepository<Tour> _TourRepo;
        public CommentsController(ITourismRepository<Comments> CommentsRepo , ITourismRepository<Person> PersonRepo, ITourismRepository<Tour> TourRepo)
        {
            _CommentsRepo = CommentsRepo;
            _PersonRepo = PersonRepo;
            _TourRepo = TourRepo;
        }

        public IEnumerable<Comments> GetAllComment() => _CommentsRepo.GetAll();



        public IActionResult Index()
        {
            var result = View(GetAllComment().Select(x => new Comments()
            {
                Is_Actived = x.Is_Actived,
                Id = x.Id,
                Text = x.Text,
                Time = x.Time,
                Person_Name = _PersonRepo.GetById(x.fk_Person).Username,
                Tour_Name = _TourRepo.GetById(x.fk_Tour).Tour_Name,
                fk_Tour = x.fk_Tour
            }));
            return result;
        }

        public IActionResult IndexforPerson(int personId)
        {
            return View(GetAllComment().Where(i=>i.fk_Person == personId).Select(x => new Comments()
            {
                Is_Actived = x.Is_Actived,
                Id = x.Id,
                Text = x.Text,
                Time = x.Time,
                Person_Name = _PersonRepo.GetById(x.fk_Person).Username,
                Tour_Name = _TourRepo.GetById(x.fk_Tour).Tour_Name
            }));
        }



        public  IActionResult  AddComment(Comments comment)
        {
            comment.Time = DateTime.Now;
            _CommentsRepo.Create(comment);
            return RedirectToAction("Tour", "Tour", new { id = comment.fk_Tour });
        }

        public Comments GetComment(int id)=>  _CommentsRepo.GetById(id);

        public string  DeleteComment(int Id)
        {
            _CommentsRepo.Delete(Id);
            return "Deleted Successfully";
        }

        public IActionResult RegisterComment(int id)
        {
            var item = GetComment(id);
            item.Is_Actived = true;
            _CommentsRepo.Update(item);
            return RedirectToAction( "Index","Comments");

        }


       

    }
}
