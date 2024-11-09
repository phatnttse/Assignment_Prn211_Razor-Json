using Assignment_BusinessObjects;
using Assignment_DAO.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Assignment_DAO
{
    public class GenericDAO<T> : IGenericDAO<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public GenericDAO(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity; 
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return entity; 
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync() > 0; 
        }

        public async Task<T> FindAsync(string id)
        {
            return await _context.Set<T>().FindAsync(id); 
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync(); 
        }
    }


}
