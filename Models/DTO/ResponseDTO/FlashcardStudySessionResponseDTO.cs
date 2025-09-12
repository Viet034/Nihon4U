namespace Nihon4U.Models.DTO.ResponseDTO;

public class FlashcardStudySessionResponseDTO
{
    public int SessionId { get; set; }
    public int CustomerId { get; set; }
    public int LessonId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public int TotalFlashcards { get; set; }
    public int CompletedFlashcards { get; set; }
    public int CorrectAnswers { get; set; }
    public int WrongAnswers { get; set; }
    public double Accuracy { get; set; }
    public int TotalTimeSpent { get; set; } // seconds
    public string Status { get; set; } = string.Empty; // Active, Completed
    public List<FlashcardResponseDTO> Flashcards { get; set; } = new();
}
