using Assignment_BusinessObjects;
using Assignment_DAO.Interfaces;
using Assignment_Repositories.Interfaces;


namespace Assignment_Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IGenericDAO<T> _dao;

        public GenericRepository(IGenericDAO<T> dao)
        {
            _dao = dao;
        }

        public async Task<T> AddAsync(T entity)
        {
            return await _dao.AddAsync(entity);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            return await _dao.UpdateAsync(entity);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var entity = await _dao.FindAsync(id);
            if (entity != null)
            {
                return await _dao.DeleteAsync(entity);
            }
            return false; 
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _dao.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dao.GetAllAsync();
        }
    }
}
