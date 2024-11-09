using Assignment_BusinessObjects;
using Assignment_DAO.Interfaces;
using Assignment_Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Assignment_Repositories
{
    public class EnrollmentRepository : GenericRepository<Enrollment>, IEnrollmentRepository
    {
        private readonly IEnrollmentDAO _enrollmentDAO;

        public EnrollmentRepository(IEnrollmentDAO enrollmentDAO) : base(enrollmentDAO)
        {
            _enrollmentDAO = enrollmentDAO;
        }

        public async Task<bool> DeleteEnrollment(string userId, string courseId)
        {
            return await _enrollmentDAO.DeleteEnrollment(userId, courseId);
        }

        public async Task<IEnumerable<Enrollment>> GetAllEnrollmentsAsync()
        {
            return await _enrollmentDAO.GetAllEnrollmentsAsync();
        }

        public async Task<Enrollment> GetEnrollmentByIdAsync(string id)
        {
            return await _enrollmentDAO.GetEnrollmentByIdAsync(id);
        }

        public async Task<IEnumerable<Enrollment>> GetEnrollmentsByCourseAsync(string courseId)
        {
            return await _enrollmentDAO.GetEnrollmentsByCourseAsync(courseId);
        }

        public Task<IEnumerable<Enrollment>> GetEnrollmentsByStatusAsync(EnrollmentStatus status)
        {
            return _enrollmentDAO.GetEnrollmentsByStatusAsync(status);
        }

        public Task<IEnumerable<Enrollment>> GetEnrollmentsByUserAsync(string userId)
        {
            return _enrollmentDAO.GetEnrollmentsByUserAsync(userId);
        }

        public Task<bool> IsUserEnrollmented(string userId, string courseId)
        {
            return _enrollmentDAO.IsUserEnrollmented(userId, courseId);
        }

        public Task<AppResponse<object>> UpdateEnrollmentStatus(string userId, string courseId, EnrollmentStatus status)
        {
            return _enrollmentDAO.UpdateEnrollmentStatus(userId, courseId, status);
        }

        public async Task<AppResponse<object>> UserEnrollIntoCourse(string userId, string courseId)
        {
            return await _enrollmentDAO.UserEnrollIntoCourse(userId, courseId);
        }

        public Task<AppResponse<object>> UserUnenrollFromCourse(string userId, string courseId)
        {
            return _enrollmentDAO.UserUnenrollFromCourse(userId, courseId);
        }
    }
}
