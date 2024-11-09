using Assignment_BusinessObjects;
using Assignment_DAO.Interfaces;
using Assignment_Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assignment_Repositories
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager; 

        public RoleRepository(IRoleDAO roleDao, RoleManager<Role> roleManager, UserManager<User> userManager) : base(roleDao)
        {
            _roleManager = roleManager;
            _userManager = userManager; 
        }

        public async Task<IdentityResult> CreateRoleAsync(string roleName)
        {
            var role = new Role { Name = roleName };
            return await _roleManager.CreateAsync(role);
        }

        public async Task<Role> GetRoleByNameAsync(string roleName)
        {
            return await _roleManager.FindByNameAsync(roleName);
        }

        public async Task<IdentityResult> DeleteRoleAsync(Role role)
        {
            return await _roleManager.DeleteAsync(role);
        }

        public async Task<IEnumerable<User>> GetUsersInRoleAsync(string roleName)
        {
            var users = await _userManager.GetUsersInRoleAsync(roleName); 
            return users;
        }
    }
}
