using Assignment_BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Utils;

namespace Assignment_RazorWeb.Pages.Courses
{
    public class DeleteModel : PageModel
    {
        private readonly IWebHostEnvironment _environment;

        public DeleteModel(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [BindProperty]
        public Course Course { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            // Đường dẫn tới file JSON
            var filePath = Path.Combine(_environment.WebRootPath, "jsons", "courses.json");

            // Đọc danh sách khóa học từ file JSON sử dụng JsonUtils
            var courses = JsonUtils.ReadFromFile<Course>(filePath);

            // Tìm khóa học theo ID
            Course = courses?.FirstOrDefault(c => c.Id == id);

            if (Course == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Course != null)
            {
                // Đọc danh sách khóa học từ file JSON
                var filePathJson = Path.Combine(_environment.WebRootPath, "jsons", "courses.json");
                var courses = JsonUtils.ReadFromFile<Course>(filePathJson);

                // Tìm và xóa khóa học
                var courseToDelete = courses?.FirstOrDefault(c => c.Id == Course.Id);
                if (courseToDelete != null)
                {
                    courses.Remove(courseToDelete); 
                }

                // Lưu lại danh sách khóa học đã cập nhật vào file JSON
                JsonUtils.WriteToFile(filePathJson, courses);
            }

            return RedirectToPage("Index");
        }
    }
}
