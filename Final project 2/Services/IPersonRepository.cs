using Final_project_2.Models;
using Final_project_2.Repository;

namespace Final_project_2.Services
{
    public interface IPersonRepository : ITourismRepository<Person>
    {
        public bool CheckUsernameAndPassword(LoginModel loginModel);
    }
}
