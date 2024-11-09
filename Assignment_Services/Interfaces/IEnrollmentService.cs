using Assignment_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_Services.Interfaces
{
    public interface IEnrollmentService
    {
        Task<IEnumerable<Enrollment>> GetAllEnrollmentsAsync();
        Task<Enrollment> GetEnrollmentByIdAsync(string id);

        Task<IEnumerable<Enrollment>> GetEnrollmentsByUserAsync(string userId);
        Task<IEnumerable<Enrollment>> GetEnrollmentsByCourseAsync(string courseId);
        Task<IEnumerable<Enrollment>> GetEnrollmentsByStatusAsync(EnrollmentStatus status);
        Task<bool> DeleteEnrollmentAsync(string userId, string courseId);
        Task<Enrollment> AddEnrollmentAsync(Enrollment enrollment);
        Task<Enrollment> UpdateEnrollmentAsync(Enrollment enrollment);
        Task<AppResponse<object>> UserEnrollIntoCourse(string userId, string courseId);

        Task<bool> IsUserEnrollmented(string userId, string courseId);

        Task<AppResponse<object>> UserUnenrollFromCourse(string userId, string courseId);
        Task<AppResponse<object>> UpdateEnrollmentStatus(string userId, string courseId, EnrollmentStatus status);

    }

}
