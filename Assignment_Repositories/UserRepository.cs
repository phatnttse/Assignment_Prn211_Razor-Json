using Assignment_BusinessObjects;
using Assignment_DAO.Interfaces;
using Assignment_Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;


namespace Assignment_Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly IUserDAO _userDao;
        private readonly UserManager<User> _userManager;

        public UserRepository(IUserDAO userDao, UserManager<User> userManager) : base(userDao)
        {
            _userDao = userDao;
            _userManager = userManager;
        }

        public Task<IdentityResult> CreateUserByUserManagerAsync(User user, string password)
        {
            return _userDao.CreateUserByUserManagerAsync(user, password);
        }

        public Task<IdentityResult> DeleteUserByUserManagerAsync(User user)
        {
            return _userDao.DeleteUserByUserManagerAsync(user);
        }

        public Task<IEnumerable<string>> GetRolesByUserManagerAsync(User user)
        {
            return _userDao.GetRolesByUserManagerAsync(user);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<IEnumerable<Role>> GetUserRolesAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User not found");
            }

            var roleNames = await _userManager.GetRolesAsync(user);
            var roles = roleNames.Select(roleName => new Role { Name = roleName }).ToList();
            return roles;
        }

        public Task<IdentityResult> UpdateUserByUserManagerAsync(User user)
        {
            return _userDao.UpdateUserByUserManagerAsync(user);
        }
    }
}
