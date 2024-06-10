using Final_project_2.Controllers;

namespace Final_project_2.Repository
{
    public interface ITourismRepository<T> where T:class
    {
        public IEnumerable<T> GetAll();
        public Task Create(T data);

        T GetById(int id);
        public Task Update(T data);
        public Task Delete(int id);



    }

   




}
