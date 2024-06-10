using Final_project_2.Models;
using Final_project_2.Repository;
using System.Collections;


namespace Final_project_2.Services
{
    public class Repository<T> :ITourismRepository<T> where T:class
    {
        private readonly Tourism _context;

        public Repository(Tourism tourism)
        {
            _context = tourism;
        }


        public IEnumerable<T> GetAll() => _context.Set<T>();


        public async Task Create(T data)
        {
            
            await _context.Set<T>().AddAsync(data);
            await _context.SaveChangesAsync();

        }

        public T GetById(int id)=> _context.Set<T>().Find(id);
        

        public async Task Delete(int id)
        {
            _context.Set<T>().Remove(GetById(id));
            await _context.SaveChangesAsync();
        }

        public async Task Update(T data)
        {
            _context.Set<T>().Update(data);
            await _context.SaveChangesAsync();

        }
    }



}
