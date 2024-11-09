using Assignment_BusinessObjects;
using Microsoft.AspNetCore.Identity;


namespace Assignment_Repositories.Interfaces
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        Task<Role> GetRoleByNameAsync(string roleName);
        Task<IdentityResult> CreateRoleAsync(string roleName);
        Task<IdentityResult> DeleteRoleAsync(Role role);
        Task<IEnumerable<User>> GetUsersInRoleAsync(string roleName);
    }
}
