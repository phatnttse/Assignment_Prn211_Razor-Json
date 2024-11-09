using Assignment_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_DAO.Interfaces
{
    public interface ICourseDAO : IGenericDAO<Course>
    {
        Task<IEnumerable<Course>> GetCoursesByInstructorAsync(string instructor);
        Task<IEnumerable<Course>> GetActiveCoursesAsync();
        Task<bool> DeleteCourse(string id);
    }
}
