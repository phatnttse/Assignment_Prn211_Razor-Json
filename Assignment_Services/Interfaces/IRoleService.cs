using Assignment_BusinessObjects;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_Services.Interfaces
{
    public interface IRoleService
    {
        Task<Role> GetRoleByNameAsync(string roleName);
        Task<IdentityResult> CreateRoleAsync(string roleName);
        Task<IdentityResult> DeleteRoleAsync(Role role);
        Task<IEnumerable<User>> GetUsersInRoleAsync(string roleName);
    }
}
