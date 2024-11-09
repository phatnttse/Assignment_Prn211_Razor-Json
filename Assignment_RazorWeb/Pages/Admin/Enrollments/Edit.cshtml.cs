using Assignment_BusinessObjects;
using Assignment_DAO.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Assignment_RazorWeb.Pages.Admin.Enrollments
{
    public class EditModel : PageModel
    {
        private readonly IEnrollmentDAO _enrollmentDAO;

        public EditModel(IEnrollmentDAO enrollmentDAO)
        {
            _enrollmentDAO = enrollmentDAO;
        }

        [BindProperty]
        public Enrollment Enrollment { get; set; }

        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(string userId, string courseId)
        {
            Enrollment = await _enrollmentDAO.GetEnrollmentByIdAsync($"{userId}-{courseId}");
            if (Enrollment == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostApproveAsync()
        {
            var result = await _enrollmentDAO.UpdateEnrollmentStatus(Enrollment.UserId, Enrollment.CourseId, EnrollmentStatus.Approved);
            if (result.Succeeded)
            {
                SuccessMessage = "Enrollment approved successfully!";
            }
            else
            {
                ErrorMessage = result.Message;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostRejectAsync()
        {
            var result = await _enrollmentDAO.UpdateEnrollmentStatus(Enrollment.UserId, Enrollment.CourseId, EnrollmentStatus.Rejected);
            if (result.Succeeded)
            {
                SuccessMessage = "Enrollment rejected successfully!";
            }
            else
            {
                ErrorMessage = result.Message;
            }

            return Page();
        }
    }
}
