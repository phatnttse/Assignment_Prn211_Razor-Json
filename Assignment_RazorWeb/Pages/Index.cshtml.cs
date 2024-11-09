using Assignment_BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Assignment_Services.Interfaces;

namespace Assignment_RazorWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IUserIdAccessor _userIdAccessor;
        private readonly IWebHostEnvironment _environment;

        [BindProperty]
        public string CourseId { get; set; }

        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }
        public IEnumerable<Course> Courses { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IUserIdAccessor userIdAccessor, IWebHostEnvironment environment)
        {
            _logger = logger;
            _userIdAccessor = userIdAccessor;
            _environment = environment;
        }

        public async Task OnGetAsync()
        {
            var filePath = Path.Combine(_environment.WebRootPath, "jsons", "courses.json");
            Courses = JsonUtils.ReadFromFile<Course>(filePath) ?? new List<Course>();
            await Task.CompletedTask;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrEmpty(CourseId))
            {
                ErrorMessage = "Course ID is required.";
                return Page();
            }

            try
            {
                var userId = _userIdAccessor.GetCurrentUserId();

                var courseFilePath = Path.Combine(_environment.WebRootPath, "jsons", "courses.json");
                var courses = JsonUtils.ReadFromFile<Course>(courseFilePath);

                var course = courses?.FirstOrDefault(c => c.Id == CourseId);

                if (course == null)
                {
                    ErrorMessage = "Course not found.";
                    return Page();
                }

                var enrollmentFilePath = Path.Combine(_environment.WebRootPath, "jsons", "enrollments.json");
                var enrollments = JsonUtils.ReadFromFile<Enrollment>(enrollmentFilePath);

                if (enrollments?.FirstOrDefault(e => e.UserId == userId && e.CourseId == CourseId) == null)
                {
                    var enrollment = new Enrollment
                    {
                        UserId = userId,
                        CourseId = CourseId,
                        EnrollmentDate = DateTime.Now,
                        Status = EnrollmentStatus.Pending,
                        Course = course
                    };

                    enrollments.Add(enrollment);

                    JsonUtils.WriteToFile(enrollmentFilePath, enrollments);

                    SuccessMessage = "You have successfully enrolled in the course!";
                }
                else
                {
                    ErrorMessage = "You have already enrolled in this course!";

                }

                Courses = courses;


            }
            catch (Exception ex)
            {
                ErrorMessage = $"An error occurred: {ex.Message}";
            }

            return Page();
        }
    }
}
