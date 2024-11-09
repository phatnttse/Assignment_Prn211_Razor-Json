using Assignment_BusinessObjects;
using Assignment_Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace Assignment_Services
{
    public class AuthService : IAuthService
    {
        private  UserManager<User> _userManager;
        private  SignInManager<User> _signInManager;
        private  RoleManager<Role> _roleManager;


        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<AppResponse<object>> SignIn(string email, string password)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(email);

                if (user == null)
                {
                    return new AppResponse<object>(false, "Email does not exist.");
                }

                var result = await _signInManager.PasswordSignInAsync(email, password, isPersistent: false, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    return new AppResponse<object>(true, "Login successful.");
                }
                else
                {
                    return new AppResponse<object>(false, "Password is incorrect.");
                }
            }
            catch (Exception ex)
            {
                return new AppResponse<object>(false, ex.Message);
            }
        }

        public async Task<AppResponse<object>> SignOut()
        {
            await _signInManager.SignOutAsync();
            return new AppResponse<object>(true, "Sign out successful.");
        }

        public async Task<AppResponse<object>> SignUp(string name, string email, string password)
        {
            try
            {
                if (await _userManager.Users.AnyAsync(x => x.Email == email))
                    throw new Exception($"Email {email} already taken");

                User user = new User { Email = email, UserName = email, Name = name };

                var result = await _userManager.CreateAsync(user, password);
            
                if (result.Succeeded)
                {
                    if (!await _roleManager.RoleExistsAsync("Admin"))
                    {
                        await _roleManager.CreateAsync(new Role { Name = RoleName.Admin.ToString() });

                        await _userManager.AddToRoleAsync(user, RoleName.Admin.ToString());
                    }
                    else
                    {
                        if (!await _roleManager.RoleExistsAsync(RoleName.Student.ToString()))
                            await _roleManager.CreateAsync(new Role { Name = RoleName.Student.ToString() });

                        await _userManager.AddToRoleAsync(user, RoleName.Student.ToString());

                    }

                    return new AppResponse<object>(true, "Sign up successful.");
                }
                else
                {
                    return new AppResponse<object>(false, "Sign up failed.");
                }

            }
            catch (Exception ex)
            {
                return new AppResponse<object>(false, ex.Message);
            }
        }
    }
}
