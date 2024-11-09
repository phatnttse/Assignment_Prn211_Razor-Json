using Assignment_BusinessObjects;
using Assignment_DAO.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_DAO
{
    public class RoleDAO : GenericDAO<Role>, IRoleDAO
    {
        private readonly RoleManager<Role> _roleManager;

        public RoleDAO(ApplicationDbContext context, RoleManager<Role> roleManager) : base(context)
        {
           _roleManager  = roleManager;
        }

        public async Task<IdentityResult> CreateRoleAsync(string roleName)
        {
            var role = new Role { Name = roleName };
            return await _roleManager.CreateAsync(role);
        }

        public async Task<IdentityResult> DeleteRoleAsync(Role role)
        {
            return await _roleManager.DeleteAsync(role);
        }

        public async Task<Role> GetRoleByNameAsync(string roleName)
        {
            return await _roleManager.FindByNameAsync(roleName);
        }
    }
}
