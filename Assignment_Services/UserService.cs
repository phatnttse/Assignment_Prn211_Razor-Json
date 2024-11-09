using Assignment_BusinessObjects;
using Assignment_Repositories.Interfaces;
using Assignment_Services.Interfaces;
using Microsoft.AspNetCore.Identity;


namespace Assignment_Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _userRepository.GetUserByEmailAsync(email);
        }

        public async Task<IEnumerable<Role>> GetUserRolesAsync(string userId)
        {
            return await _userRepository.GetUserRolesAsync(userId);
        }

        public async Task<IdentityResult> CreateUserAsync(User user, string password)
        {
            return await _userRepository.CreateUserByUserManagerAsync(user, password);
        }

        public async Task<IdentityResult> UpdateUserAsync(User user)
        {
            return await _userRepository.UpdateUserByUserManagerAsync(user);
        }

        public async Task<IdentityResult> DeleteUserAsync(User user)
        {
            return await _userRepository.DeleteUserByUserManagerAsync(user);
        }

        public async Task<IEnumerable<string>> GetRolesByUserAsync(User user)
        {
            return await _userRepository.GetRolesByUserManagerAsync(user);
        }
    }
}
