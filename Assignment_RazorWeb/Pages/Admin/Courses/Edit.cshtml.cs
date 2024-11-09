using Assignment_BusinessObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Utils;

namespace Assignment_RazorWeb.Pages.Courses
{
    public class EditModel : PageModel
    {
        private readonly IWebHostEnvironment _environment;

        public EditModel(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [BindProperty]
        public Course Course { get; set; }

        [BindProperty]
        public IFormFile ImageFile { get; set; } // Trường cho hình ảnh mới

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
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Xử lý tải ảnh nếu người dùng chọn hình ảnh mới
            if (ImageFile != null && ImageFile.Length > 0)
            {
                var fileName = Path.GetFileName(ImageFile.FileName);
                var filePath = Path.Combine(_environment.WebRootPath, "images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                }

                var domain = $"{Request.Scheme}://{Request.Host}";
                Course.ImageUrl = $"{domain}/images/{fileName}";
            }

            // Đọc danh sách khóa học từ file JSON
            var filePathJson = Path.Combine(_environment.WebRootPath, "jsons", "courses.json");
            var courses = JsonUtils.ReadFromFile<Course>(filePathJson);

            // Tìm khóa học và cập nhật
            var existingCourse = courses?.FirstOrDefault(c => c.Id == Course.Id);
            if (existingCourse != null)
            {
                // Cập nhật thông tin khóa học
                existingCourse.Title = Course.Title;
                existingCourse.Instructor = Course.Instructor;
                existingCourse.StartDate = Course.StartDate;
                existingCourse.EndDate = Course.EndDate;
                existingCourse.Description = Course.Description;
                existingCourse.ImageUrl = Course.ImageUrl;
                existingCourse.IsActive = Course.IsActive;
            }

            // Lưu danh sách khóa học đã cập nhật lại vào file JSON
            JsonUtils.WriteToFile(filePathJson, courses);

            return RedirectToPage("Index");
        }
    }
}
