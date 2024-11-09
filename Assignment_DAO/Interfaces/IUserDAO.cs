using Assignment_BusinessObjects;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_DAO.Interfaces
{
    public interface IUserDAO : IGenericDAO<User>
    {
        Task<IdentityResult> CreateUserByUserManagerAsync(User user, string password);
        Task<IdentityResult> UpdateUserByUserManagerAsync(User user);
        Task<IdentityResult> DeleteUserByUserManagerAsync(User user);
        Task<IEnumerable<string>> GetRolesByUserManagerAsync(User user);
    }
}
