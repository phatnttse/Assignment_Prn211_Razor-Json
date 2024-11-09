using Assignment_BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Utils;

namespace Assignment_RazorWeb.Pages.Courses
{
    public class CreateModel : PageModel
    {
        private readonly IWebHostEnvironment _environment;

        public CreateModel(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [BindProperty]
        [Required(ErrorMessage = "Fields are required")]
        public Course Course { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Image is required")]
        public IFormFile ImageFile { get; set; }

        public string ErrorMessage { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                if (ImageFile != null && ImageFile.Length > 0)
                {
                    var fileName = Path.GetFileName(ImageFile.FileName);
                    var folderPath = Path.Combine("wwwroot", "images");

                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    var filePath = Path.Combine(folderPath, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await ImageFile.CopyToAsync(stream);
                    }

                    var domain = $"{Request.Scheme}://{Request.Host}";
                    Course.ImageUrl = $"{domain}/images/{fileName}";
                }

                var filePathJson = Path.Combine(_environment.WebRootPath, "jsons", "courses.json");
                var courses = JsonUtils.ReadFromFile<Course>(filePathJson);

                if (courses != null)
                {
                    courses.Add(Course);
                    JsonUtils.WriteToFile(filePathJson, courses);
                }

            }
            catch (Exception ex)
            {
                ErrorMessage = "An error occurred while creating the course: " + ex.Message;
                return Page();
            }

            return RedirectToPage("Index");
        }
    }
}
