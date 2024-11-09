using Assignment_BusinessObjects;
using Assignment_DAO.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_DAO
{
    public class UserDAO : GenericDAO<User>, IUserDAO
    {
        private readonly UserManager<User> _userManager;

        public UserDAO(ApplicationDbContext context, UserManager<User> userManager) : base(context)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> CreateUserByUserManagerAsync(User user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<IdentityResult> UpdateUserByUserManagerAsync(User user)
        {
            return await _userManager.UpdateAsync(user);
        }

        public async Task<IdentityResult> DeleteUserByUserManagerAsync(User user)
        {
            return await _userManager.DeleteAsync(user);
        }

        public async Task<IEnumerable<string>> GetRolesByUserManagerAsync(User user)
        {
            return await _userManager.GetRolesAsync(user);
        }
    }


}
