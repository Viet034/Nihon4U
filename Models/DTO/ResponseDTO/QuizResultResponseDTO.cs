namespace Nihon4U.Models.DTO.ResponseDTO;

public class QuizResultResponseDTO
{
    public int QuizId { get; set; }
    public int CustomerId { get; set; }
    public int TotalQuestions { get; set; }
    public int CorrectAnswers { get; set; }
    public int WrongAnswers { get; set; }
    public double Score { get; set; }
    public double Percentage { get; set; }
    public bool Passed { get; set; }
    public int TimeSpent { get; set; } // seconds
    public DateTime CompletedAt { get; set; }
    public List<QuestionResultDTO> QuestionResults { get; set; } = new();
}

public class QuestionResultDTO
{
    public int QuestionId { get; set; }
    public string QuestionText { get; set; } = string.Empty;
    public string SelectedAnswer { get; set; } = string.Empty;
    public string CorrectAnswer { get; set; } = string.Empty;
    public bool IsCorrect { get; set; }
    public int TimeSpent { get; set; }
}
