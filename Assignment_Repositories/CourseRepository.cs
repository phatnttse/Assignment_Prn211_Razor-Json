using Assignment_BusinessObjects;
using Assignment_DAO.Interfaces;
using Assignment_Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assignment_Repositories
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        private readonly ICourseDAO _courseDAO;

        public CourseRepository(ICourseDAO courseDAO) : base(courseDAO)
        {
            _courseDAO = courseDAO;
        }

        public async Task<IEnumerable<Course>> GetCoursesByInstructorAsync(string instructor)
        {
            return await _courseDAO.GetCoursesByInstructorAsync(instructor);
        }

        public async Task<IEnumerable<Course>> GetActiveCoursesAsync()
        {
            return await _courseDAO.GetActiveCoursesAsync();
        }

        public async Task<bool> DeleteCourse(string id)
        {
            return await _courseDAO.DeleteCourse(id); 
        }
    }
}
