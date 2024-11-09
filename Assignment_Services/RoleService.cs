using Assignment_BusinessObjects;
using Assignment_Repositories.Interfaces;
using Assignment_Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assignment_Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<Role> GetRoleByNameAsync(string roleName)
        {
            return await _roleRepository.GetRoleByNameAsync(roleName);
        }

        public async Task<IdentityResult> CreateRoleAsync(string roleName)
        {
            return await _roleRepository.CreateRoleAsync(roleName);
        }

        public async Task<IdentityResult> DeleteRoleAsync(Role role)
        {
            return await _roleRepository.DeleteRoleAsync(role);
        }

        public async Task<IEnumerable<User>> GetUsersInRoleAsync(string roleName)
        {
            return await _roleRepository.GetUsersInRoleAsync(roleName);
        }
    }
}
