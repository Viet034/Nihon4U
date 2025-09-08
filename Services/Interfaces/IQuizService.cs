using Nihon4U.Models.DTO.EntitiesDTO;
using Nihon4U.Models.DTO.RequestDTO.Quiz;
using Nihon4U.Models.DTO.ResponseDTO;

namespace Nihon4U.Services.Interfaces;

public interface IQuizService
{
    Task<IEnumerable<QuizzResponseDTO>> GetAllQuizzesAsync();
    Task<QuizzResponseDTO?> GetQuizByIdAsync(int id);
    Task<IEnumerable<QuizzResponseDTO>> GetQuizzesByLessonIdAsync(int lessonId);
    Task<QuizzResponseDTO> CreateQuizAsync(QuizzDTO quizDto);
    Task<QuizzResponseDTO?> UpdateQuizAsync(int id, QuizzDTO quizDto);
    Task<bool> DeleteQuizAsync(int id);
    Task<QuizResultResponseDTO> SubmitQuizAnswerAsync(int quizId, QuizAnswerRequestDTO answerRequest);
    Task<IEnumerable<QuestionResponseDTO>> GetQuizQuestionsAsync(int quizId);
    Task<QuestionResponseDTO> AddQuestionToQuizAsync(int quizId, QuestionDTO questionDto);
    Task<bool> RemoveQuestionFromQuizAsync(int quizId, int questionId);
    Task<QuizStatisticsResponseDTO> GetQuizStatisticsAsync(int quizId);
}
