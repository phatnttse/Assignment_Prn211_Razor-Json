using Assignment_BusinessObjects;
using Assignment_Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Utils;

namespace Assignment_RazorWeb.Pages
{
    public class MyEnrollmentModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IUserIdAccessor _userIdAccessor;
        private readonly IWebHostEnvironment _environment;


        [BindProperty]
        public string CourseId { get; set; }
        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }
        public IList<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

        public MyEnrollmentModel(ILogger<IndexModel> logger, IUserIdAccessor userIdAccessor, IWebHostEnvironment environment)
        {
            _logger = logger;
            _userIdAccessor = userIdAccessor;
            _environment = environment;
        }

        public async Task OnGetAsync()
        {
            string userId = _userIdAccessor.GetCurrentUserId();  
            var filePath = Path.Combine(_environment.WebRootPath, "jsons", "enrollments.json");

            var enrollments = JsonUtils.ReadFromFile<Enrollment>(filePath) ?? new List<Enrollment>();

            Enrollments = enrollments.Where(e => e.UserId == userId).ToList();

            await Task.CompletedTask;
        }


        public async Task OnPostAsync()
        {
            string userId = _userIdAccessor.GetCurrentUserId();
            var filePath = Path.Combine(_environment.WebRootPath, "jsons", "enrollments.json");

            // Đọc tất cả enrollments từ file
            var enrollments = JsonUtils.ReadFromFile<Enrollment>(filePath) ?? new List<Enrollment>();

            var enrollmentToRemove = enrollments.FirstOrDefault(e => e.UserId == userId && e.CourseId == CourseId);

            if (enrollmentToRemove != null)
            {
                enrollments.Remove(enrollmentToRemove);

                JsonUtils.WriteToFile(filePath, enrollments);

                SuccessMessage = "You have successfully unenrolled from the course!";

            }
            else
            {
                ErrorMessage = "Enrollment not found!";
            }

            Enrollments = enrollments;
        }

    }
}
