using Assignment_BusinessObjects;
using Assignment_Repositories.Interfaces;
using Assignment_Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assignment_Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<Course> GetCourseByIdAsync(string id)
        {
            return await _courseRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return await _courseRepository.GetAllAsync();
        }

        public async Task<Course> AddCourseAsync(Course course)
        {
            return await _courseRepository.AddAsync(course);
        }

        public async Task<Course> UpdateCourseAsync(Course course)
        {
            return await _courseRepository.UpdateAsync(course);
        }

        public async Task<bool> DeleteCourseAsync(string id)
        {
            return await _courseRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Course>> GetCoursesByInstructorAsync(string instructor)
        {
            return await _courseRepository.GetCoursesByInstructorAsync(instructor);
        }

        public async Task<IEnumerable<Course>> GetActiveCoursesAsync()
        {
            return await _courseRepository.GetActiveCoursesAsync();
        }

        public async Task<bool> DeleteCourse(string id)
        {
            return await _courseRepository.DeleteCourse(id);
        }
    }
}
