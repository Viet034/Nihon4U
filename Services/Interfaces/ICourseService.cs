using Nihon4U.Models.DTO.EntitiesDTO;
using Nihon4U.Models.DTO.ResponseDTO;
using Nihon4U.Models.Enums;

namespace Nihon4U.Services.Interfaces;

public interface ICourseService
{
    Task<IEnumerable<CourseResponseDTO>> GetAllCoursesAsync();
    Task<CourseResponseDTO?> GetCourseByIdAsync(int id);
    Task<IEnumerable<CourseResponseDTO>> GetCoursesByStatusAsync(CourseStatus status);
    Task<IEnumerable<CourseResponseDTO>> GetCoursesByLevelAsync(string level);
    Task<IEnumerable<CourseResponseDTO>> GetComboCoursesAsync();
    Task<CourseResponseDTO> CreateCourseAsync(CourseDTO courseDto);
    Task<CourseResponseDTO?> UpdateCourseAsync(int id, CourseDTO courseDto);
    Task<bool> DeleteCourseAsync(int id);
    Task<bool> ChangeCourseStatusAsync(int id, CourseStatus status);
    Task<IEnumerable<CourseResponseDTO>> SearchCoursesAsync(string keyword);
    Task<IEnumerable<CourseResponseDTO>> GetCoursesByCustomerIdAsync(int customerId);
}

