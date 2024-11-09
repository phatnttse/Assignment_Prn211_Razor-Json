using Assignment_BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Utils; 

namespace Assignment_RazorWeb.Pages.Courses
{
    public class DetailModel : PageModel
    {
        private readonly IWebHostEnvironment _environment;

        public DetailModel(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public Course? Course { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            // Đường dẫn tới tệp JSON
            var filePath = Path.Combine(_environment.WebRootPath, "jsons", "courses.json");

            var courses = JsonUtils.ReadFromFile<Course>(filePath);

            Course = courses?.FirstOrDefault(c => c.Id == id);

            if (Course == null || !Course.IsActive)
            {
                return NotFound();
            }

            await Task.CompletedTask; 
            return Page();
        }
    }
}
