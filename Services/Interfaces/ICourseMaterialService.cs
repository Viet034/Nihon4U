using Nihon4U.Models.DTO.EntitiesDTO;
using Nihon4U.Models.DTO.ResponseDTO;

namespace Nihon4U.Services.Interfaces;

public interface ICourseMaterialService
{
    Task<IEnumerable<CourseMaterialResponseDTO>> GetAllMaterialsAsync();
    Task<CourseMaterialResponseDTO?> GetMaterialByIdAsync(int id);
    Task<IEnumerable<CourseMaterialResponseDTO>> GetMaterialsByLessonIdAsync(int lessonId);
    Task<IEnumerable<CourseMaterialResponseDTO>> GetMaterialsByCourseIdAsync(int courseId);
    Task<CourseMaterialResponseDTO> CreateMaterialAsync(CourseMaterialDTO materialDto);
    Task<CourseMaterialResponseDTO?> UpdateMaterialAsync(int id, CourseMaterialDTO materialDto);
    Task<bool> DeleteMaterialAsync(int id);
    Task<IEnumerable<CourseMaterialResponseDTO>> GetMaterialsByTypeAsync(string materialType);
    Task<CourseMaterialResponseDTO> UploadMaterialFileAsync(int materialId, IFormFile file);
    Task<bool> DeleteMaterialFileAsync(int materialId);
    Task<string> GetMaterialDownloadUrlAsync(int materialId);
    Task<MaterialAccessResponseDTO> CheckMaterialAccessAsync(int customerId, int materialId);
}
