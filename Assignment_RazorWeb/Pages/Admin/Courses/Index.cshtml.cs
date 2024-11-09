using Assignment_BusinessObjects;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Utils; 

namespace Assignment_RazorWeb.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly IWebHostEnvironment _environment;

        public IndexModel(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public IList<Course> Courses { get; private set; }

        public async Task OnGetAsync()
        {
            var filePath = Path.Combine(_environment.WebRootPath, "jsons", "courses.json");

            Courses = JsonUtils.ReadFromFile<Course>(filePath);

            await Task.CompletedTask; // Nếu cần hỗ trợ async
        }
    }
}

