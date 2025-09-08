using Nihon4U.Models.DTO.EntitiesDTO;
using Nihon4U.Models.DTO.RequestDTO.Progress;
using Nihon4U.Models.DTO.ResponseDTO;

namespace Nihon4U.Services.Interfaces;

public interface IProgressTrackingService
{
    Task<LearningProgressResponseDTO> UpdateLessonProgressAsync(int customerId, int lessonId, LessonProgressUpdateDTO progressDto);
    Task<LearningProgressResponseDTO?> GetLessonProgressAsync(int customerId, int lessonId);
    Task<IEnumerable<LearningProgressResponseDTO>> GetCourseProgressAsync(int customerId, int courseId);
    Task<LearningProgressResponseDTO> MarkLessonAsCompletedAsync(int customerId, int lessonId);
    Task<LearningProgressResponseDTO> MarkLessonAsInProgressAsync(int customerId, int lessonId);
    Task<CourseProgressSummaryDTO> GetCourseProgressSummaryAsync(int customerId, int courseId);
    Task<IEnumerable<CourseProgressSummaryDTO>> GetAllCourseProgressAsync(int customerId);
    Task<LearningStreakResponseDTO> UpdateLearningStreakAsync(int customerId);
    Task<LearningStreakResponseDTO?> GetLearningStreakAsync(int customerId);
    Task<IEnumerable<LearningStreakResponseDTO>> GetTopLearningStreaksAsync(int count = 10);
    Task<OverallProgressDTO> GetOverallProgressAsync(int customerId);
    Task<bool> ResetCourseProgressAsync(int customerId, int courseId);
}
