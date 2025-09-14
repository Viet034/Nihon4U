using Nihon4U.Models.DTO.EntitiesDTO;
using Nihon4U.Models.DTO.ResponseDTO;
using Nihon4U.Models.Enums;

namespace Nihon4U.Services.Interfaces;

public interface ILessonService
{
    Task<IEnumerable<LessonResponseDTO>> GetAllLessonsAsync();
    Task<LessonResponseDTO?> GetLessonByIdAsync(int id);
    Task<IEnumerable<LessonResponseDTO>> GetLessonsByCourseIdAsync(int courseId);
    Task<IEnumerable<LessonResponseDTO>> GetLessonsByStatusAsync(LessonStatus status);
    Task<LessonResponseDTO> CreateLessonAsync(LessonDTO lessonDto);
    Task<LessonResponseDTO?> UpdateLessonAsync(int id, LessonDTO lessonDto);
    Task<bool> DeleteLessonAsync(int id);
    Task<bool> ChangeLessonStatusAsync(int id, LessonStatus status);
    Task<IEnumerable<LessonResponseDTO>> GetLessonsByOrderIndexAsync(int courseId);
    Task<LessonResponseDTO?> GetNextLessonAsync(int currentLessonId);
    Task<LessonResponseDTO?> GetPreviousLessonAsync(int currentLessonId);
    Task<bool> UpdateLessonOrderAsync(int lessonId, int newOrderIndex);
    Task<IEnumerable<LessonResponseDTO>> GetFreePreviewLessonsAsync(int courseId);
}

