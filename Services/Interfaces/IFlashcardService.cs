using Nihon4U.Models.DTO.EntitiesDTO;
using Nihon4U.Models.DTO.RequestDTO.Flashcard;
using Nihon4U.Models.DTO.ResponseDTO;

namespace Nihon4U.Services.Interfaces;

public interface IFlashcardService
{
    Task<IEnumerable<FlashcardResponseDTO>> GetAllFlashcardsAsync();
    Task<FlashcardResponseDTO?> GetFlashcardByIdAsync(int id);
    Task<IEnumerable<FlashcardResponseDTO>> GetFlashcardsByLessonIdAsync(int lessonId);
    Task<IEnumerable<FlashcardResponseDTO>> GetFlashcardsByCourseIdAsync(int courseId);
    Task<FlashcardResponseDTO> CreateFlashcardAsync(FlashcardDTO flashcardDto);
    Task<FlashcardResponseDTO?> UpdateFlashcardAsync(int id, FlashcardDTO flashcardDto);
    Task<bool> DeleteFlashcardAsync(int id);
 //   Task<FlashcardProgressResponseDTO> UpdateFlashcardProgressAsync(int customerId, int flashcardId, FlashcardProgressDTO progressDto);
    Task<IEnumerable<FlashcardProgressResponseDTO>> GetFlashcardProgressByCustomerAsync(int customerId);
    Task<IEnumerable<FlashcardResponseDTO>> GetFlashcardsForReviewAsync(int customerId, int lessonId);
    Task<FlashcardStudySessionResponseDTO> StartStudySessionAsync(int customerId, int lessonId);
    Task<FlashcardStudySessionResponseDTO> CompleteStudySessionAsync(int sessionId, StudySessionResultDTO resultDto);
    Task<FlashcardStatisticsResponseDTO> GetFlashcardStatisticsAsync(int customerId, int? lessonId = null);
}
