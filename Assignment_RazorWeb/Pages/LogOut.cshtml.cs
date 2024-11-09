using Assignment_Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Assignment_RazorWeb.Pages
{
    public class LogOutModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IAuthService _authService;

        public LogOutModel(ILogger<IndexModel> logger, IAuthService authService)
        {
            _logger = logger;
            _authService = authService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var result = await _authService.SignOut();
            if (result.Succeeded)
            {
                return RedirectToPage("/SignIn");
            }
            return Page();
        }

    }
}
