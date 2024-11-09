using Assignment_BusinessObjects;
using Assignment_Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Assignment_RazorWeb.Pages
{
    public class SignInModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public SignInModel(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        public async Task OnGetAsync()
        {
            if (User.Identity.IsAuthenticated)
            {
                var email = User.Identity.Name;
                User user = await _userService.GetUserByEmailAsync(email);

                if (user != null)
                {
                    IEnumerable<string> roles = await _userService.GetRolesByUserAsync(user);

                    // Chuyển hướng dựa trên vai trò
                    if (roles.Contains(RoleName.Admin.ToString()))
                    {
                        Response.Redirect("/Admin/Courses/Index");
                    }
                    else
                    {
                        Response.Redirect("/Index");
                    }
                }
            }
        }

        public async Task<IActionResult> OnPostSignInAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Đăng nhập với email và password
            var result = await _authService.SignIn(Email, Password);

            if (result.Succeeded)
            {
                User user = await _userService.GetUserByEmailAsync(Email);
                if (user == null)
                {
                    ErrorMessage = "User not found";
                    return Page();
                }

                IEnumerable<string> roles = await _userService.GetRolesByUserAsync(user);

                if (roles.Contains(RoleName.Admin.ToString()))
                {
                    return RedirectToPage("/Admin/Courses/Index");
                }else
                {
                    return RedirectToPage("/Index");
                }
            }
            else
            {
                ErrorMessage = result.Message;
                return Page(); 
            }
        }
    }
}
