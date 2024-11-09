using Assignment_BusinessObjects;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_DAO.Interfaces
{
    public interface IRoleDAO : IGenericDAO<Role>
    {
        Task<IdentityResult> CreateRoleAsync(string roleName);
        Task<IdentityResult> DeleteRoleAsync(Role role);
        Task<Role> GetRoleByNameAsync(string roleName);

    }
}
