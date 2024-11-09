using Assignment_BusinessObjects;
using Assignment_DAO.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Assignment_DAO
{
    public class EnrollmentDAO : GenericDAO<Enrollment>, IEnrollmentDAO
    {
        private readonly ApplicationDbContext _context;

        public EnrollmentDAO(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }



        public async Task<bool> DeleteEnrollment(string userId, string courseId)
        {
            var enrollment = await _context.Enrollments
                .FirstOrDefaultAsync(e => e.UserId == userId && e.CourseId == courseId);
            if (enrollment == null)
            {
                return false;
            }

            _context.Enrollments.Remove(enrollment);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Enrollment>> GetAllEnrollmentsAsync()
        {
            return await _context.Enrollments.ToListAsync();
        }

        public async Task<Enrollment> GetEnrollmentByIdAsync(string id)
        {
            try
            {
                return await _context.Enrollments
                    .Include(e => e.Course)
                    .Include(e => e.User)
                    .FirstOrDefaultAsync(e => e.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Enrollment>> GetEnrollmentsByCourseAsync(string courseId)
        {
            return await _context.Enrollments
                .Where(e => e.CourseId == courseId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Enrollment>> GetEnrollmentsByStatusAsync(EnrollmentStatus status)
        {
            return await _context.Enrollments
                .Where(e => e.Status == status)
                .ToListAsync();
        }

        public async Task<IEnumerable<Enrollment>> GetEnrollmentsByUserAsync(string userId)
        {
            try
            {
                return await _context.Enrollments
                    .Where(e => e.UserId == userId)
                    .Include(e => e.Course)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> IsUserEnrollmented(string userId, string courseId)
        {
            try
            {
                return await _context.Enrollments.AnyAsync(e => e.UserId == userId && e.CourseId == courseId);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<AppResponse<object>> UpdateEnrollmentStatus(string userId, string courseId, EnrollmentStatus status)
        {
            try
            {
                var enrollment = await _context.Enrollments
                    .FirstOrDefaultAsync(e => e.UserId == userId && e.CourseId == courseId);
                if (enrollment == null)
                {
                    return new AppResponse<object>(false, "Enrollment not found", null);
                }
                else
                {
                    enrollment.Status = status;
                    _context.Enrollments.Update(enrollment);
                    await _context.SaveChangesAsync();
                    return new AppResponse<object>(true, "Enrollment status updated", null);
                }
            }
            catch (Exception ex)
            {
                return new AppResponse<object>(false, ex.Message, null);
            }
        }

        public async Task<AppResponse<object>> UserEnrollIntoCourse(string userId, string courseId)
        {
            try
            {
                Enrollment enrollment = new Enrollment
                {
                    UserId = userId,
                    CourseId = courseId,
                    EnrollmentDate = DateTime.Now,
                    Status = EnrollmentStatus.Pending
                };

                await _context.Enrollments.AddAsync(enrollment);
                await _context.SaveChangesAsync();

                return new AppResponse<object>(true, "Enrollment successful", null);
            }
            catch (Exception ex)
            {
                return new AppResponse<object>(false, ex.Message, null);
            }
        }

        public async Task<AppResponse<object>> UserUnenrollFromCourse(string userId, string courseId)
        {
            try
            {
                var enrollment = await _context.Enrollments
                    .FirstOrDefaultAsync(e => e.UserId == userId && e.CourseId == courseId);
                if (enrollment == null)
                {
                    return new AppResponse<object>(false, "Enrollment not found", null);
                }
                else
                {
                    _context.Enrollments.Remove(enrollment);
                    await _context.SaveChangesAsync();
                    return new AppResponse<object>(true, "Unenrollment successful", null);
                }
            }
            catch (Exception ex)
            {
                return new AppResponse<object>(false, ex.Message, null);
            }
        }
    }
}
