using Assignment_BusinessObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assignment_Services.Interfaces
{
    public interface ICourseService
    {
        Task<Course> GetCourseByIdAsync(string id);
        Task<IEnumerable<Course>> GetAllCoursesAsync();
        Task<Course> AddCourseAsync(Course course);
        Task<Course> UpdateCourseAsync(Course course);
        Task<bool> DeleteCourseAsync(string id);
        Task<IEnumerable<Course>> GetCoursesByInstructorAsync(string instructor);
        Task<IEnumerable<Course>> GetActiveCoursesAsync();
        Task<bool> DeleteCourse(string id);

    }
}
