using Nihon4U.Models.DTO.EntitiesDTO;
using Nihon4U.Models.DTO.ResponseDTO;
using Nihon4U.Models.Enums;

namespace Nihon4U.Services.Interfaces;

public interface ICourseEnrollmentService
{
    Task<IEnumerable<CourseEnrollmentResponseDTO>> GetAllEnrollmentsAsync();
    Task<CourseEnrollmentResponseDTO?> GetEnrollmentByIdAsync(int id);
    Task<IEnumerable<CourseEnrollmentResponseDTO>> GetEnrollmentsByCustomerIdAsync(int customerId);
    Task<IEnumerable<CourseEnrollmentResponseDTO>> GetEnrollmentsByCourseIdAsync(int courseId);
    Task<IEnumerable<CourseEnrollmentResponseDTO>> GetEnrollmentsByStatusAsync(EnrollmentStatus status);
    Task<CourseEnrollmentResponseDTO> CreateEnrollmentAsync(CourseEnrollmentDTO enrollmentDto);
    Task<CourseEnrollmentResponseDTO?> UpdateEnrollmentAsync(int id, CourseEnrollmentDTO enrollmentDto);
    Task<bool> DeleteEnrollmentAsync(int id);
    Task<bool> ChangeEnrollmentStatusAsync(int id, EnrollmentStatus status);
    Task<bool> CheckCustomerEnrolledAsync(int customerId, int courseId);
    Task<IEnumerable<CourseEnrollmentResponseDTO>> GetActiveEnrollmentsByCustomerIdAsync(int customerId);
    Task<bool> EnrollCustomerToCourseAsync(int customerId, int courseId, int? orderId = null);
}

