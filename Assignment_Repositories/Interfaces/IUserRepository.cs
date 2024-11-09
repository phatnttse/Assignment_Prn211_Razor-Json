using Assignment_BusinessObjects;
using Microsoft.AspNetCore.Identity;


namespace Assignment_Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetUserByEmailAsync(string email);
        Task<IEnumerable<Role>> GetUserRolesAsync(string userId);
        Task<IdentityResult> CreateUserByUserManagerAsync(User user, string password);
        Task<IdentityResult> UpdateUserByUserManagerAsync(User user);
        Task<IdentityResult> DeleteUserByUserManagerAsync(User user);
        Task<IEnumerable<string>> GetRolesByUserManagerAsync(User user);
    }
}
