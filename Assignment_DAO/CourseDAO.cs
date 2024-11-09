using Assignment_BusinessObjects;
using Assignment_DAO.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_DAO
{
    public class CourseDAO : GenericDAO<Course>, ICourseDAO
    {
        private readonly ApplicationDbContext _context;

        public CourseDAO(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> GetCoursesByInstructorAsync(string instructor)
        {
            return await _context.Courses
                .Where(c => c.Instructor == instructor)
                .ToListAsync();
        }

        public async Task<IEnumerable<Course>> GetActiveCoursesAsync()
        {
            return await _context.Courses
                .Where(c => c.IsActive)
                .ToListAsync();
        }

        public async Task<bool> DeleteCourse(string id)
        {
           Course existingCourse =  await _context.Courses.FindAsync(id);
            if (existingCourse != null)
            {
                existingCourse.IsActive = false;
                _context.Courses.Update(existingCourse);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

    }
}
