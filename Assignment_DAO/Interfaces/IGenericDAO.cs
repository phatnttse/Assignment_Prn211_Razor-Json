using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_DAO.Interfaces
{
    public interface IGenericDAO<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity); 
        Task<T> FindAsync(string id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
