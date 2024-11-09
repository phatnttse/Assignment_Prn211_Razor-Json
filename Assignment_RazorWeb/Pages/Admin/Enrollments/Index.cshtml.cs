using Assignment_BusinessObjects;
using Assignment_Services;
using Assignment_Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Assignment_RazorWeb.Pages.Admin.Enrollments
{
    public class IndexModel : PageModel
    {
        private readonly IEnrollmentService _enrollmentService;
        private readonly IUserIdAccessor _userIdAccessor;


        [BindProperty]
        public string CourseId { get; set; }

        public IndexModel(IEnrollmentService enrollmentService, IUserIdAccessor userIdAccessor)
        {
            _enrollmentService = enrollmentService;
            _userIdAccessor = userIdAccessor;
        }

        public IEnumerable<Enrollment> Enrollments { get; set; } = Enumerable.Empty<Enrollment>();

        public async Task OnGetAsync()
        {
            Enrollments = await _enrollmentService.GetAllEnrollmentsAsync();
        }

        public async Task<IActionResult> OnPostApproveAsync(string userId, string courseId)
        {
            string currentUserId = _userIdAccessor.GetCurrentUserId();

            if (string.IsNullOrEmpty(userId))
            {
                return Page();
            }

            var response = await _enrollmentService.UpdateEnrollmentStatus(userId, CourseId, EnrollmentStatus.Approved);
            if (response.Succeeded) // Check if the update was successful
            {
                return RedirectToPage();
            }
            // Handle the failure case (e.g., add a message or log)
            return RedirectToPage(); // Or return an error view/message
        }

        public async Task<IActionResult> OnPostRejectAsync(string userId, string courseId)
        {
            var response = await _enrollmentService.UpdateEnrollmentStatus(userId, courseId, EnrollmentStatus.Rejected);
            if (response.Succeeded) // Check if the update was successful
            {
                return RedirectToPage();
            }
            // Handle the failure case
            return RedirectToPage(); // Or return an error view/message
        }
    }
}
