using Assignment_BusinessObjects;
using Assignment_Repositories.Interfaces;
using Assignment_Services.Interfaces;


namespace Assignment_Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _enrollmentRepository;

        public EnrollmentService(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        public async Task<IEnumerable<Enrollment>> GetEnrollmentsByUserAsync(string userId)
        {
            return await _enrollmentRepository.GetEnrollmentsByUserAsync(userId);
        }

        public async Task<Enrollment> GetEnrollmentByIdAsync(string id)
        {
            return await _enrollmentRepository.GetEnrollmentByIdAsync(id);
        }

        public async Task<IEnumerable<Enrollment>> GetEnrollmentsByCourseAsync(string courseId)
        {
            return await _enrollmentRepository.GetEnrollmentsByCourseAsync(courseId);
        }

        public async Task<IEnumerable<Enrollment>> GetEnrollmentsByStatusAsync(EnrollmentStatus status)
        {
            return await _enrollmentRepository.GetEnrollmentsByStatusAsync(status);
        }

        public async Task<bool> DeleteEnrollmentAsync(string userId, string courseId)
        {
            return await _enrollmentRepository.DeleteEnrollment(userId, courseId);
        }

        public async Task<Enrollment> AddEnrollmentAsync(Enrollment enrollment)
        {
            return await _enrollmentRepository.AddAsync(enrollment);
        }

        public async Task<Enrollment> UpdateEnrollmentAsync(Enrollment enrollment)
        {
            return await _enrollmentRepository.UpdateAsync(enrollment);
        }

        public async Task<AppResponse<object>> UserEnrollIntoCourse(string userId, string courseId)
        {
            return await _enrollmentRepository.UserEnrollIntoCourse(userId, courseId);
        }

        public async Task<bool> IsUserEnrollmented(string userId, string courseId)
        {
            return await _enrollmentRepository.IsUserEnrollmented(userId, courseId);
        }

        public async Task<AppResponse<object>> UserUnenrollFromCourse(string userId, string courseId)
        {
            return await _enrollmentRepository.UserUnenrollFromCourse(userId, courseId);
        }

        public async Task<AppResponse<object>> UpdateEnrollmentStatus(string userId, string courseId, EnrollmentStatus status)
        {
            return await _enrollmentRepository.UpdateEnrollmentStatus(userId, courseId, status);
        }

        public async Task<IEnumerable<Enrollment>> GetAllEnrollmentsAsync()
        {
            return await _enrollmentRepository.GetAllEnrollmentsAsync();
        }
    }
}
