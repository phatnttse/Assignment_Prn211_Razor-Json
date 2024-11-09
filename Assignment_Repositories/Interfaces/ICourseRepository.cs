using Assignment_BusinessObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assignment_Repositories.Interfaces
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
        Task<IEnumerable<Course>> GetCoursesByInstructorAsync(string instructor);
        Task<IEnumerable<Course>> GetActiveCoursesAsync();
        Task<bool> DeleteCourse(string id);

    }
}
