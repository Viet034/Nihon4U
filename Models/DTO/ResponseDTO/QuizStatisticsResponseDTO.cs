namespace Nihon4U.Models.DTO.ResponseDTO;

public class QuizStatisticsResponseDTO
{
    public int QuizId { get; set; }
    public string QuizName { get; set; } = string.Empty;
    public int TotalAttempts { get; set; }
    public double AverageScore { get; set; }
    public double PassRate { get; set; }
    public int TotalParticipants { get; set; }
    public List<QuestionStatisticsDTO> QuestionStatistics { get; set; } = new();
    public List<ScoreDistributionDTO> ScoreDistribution { get; set; } = new();
}

public class QuestionStatisticsDTO
{
    public int QuestionId { get; set; }
    public string QuestionText { get; set; } = string.Empty;
    public double CorrectRate { get; set; }
    public int TotalAttempts { get; set; }
    public int CorrectAttempts { get; set; }
}

public class ScoreDistributionDTO
{
    public string Range { get; set; } = string.Empty; // e.g., "0-20", "21-40", etc.
    public int Count { get; set; }
    public double Percentage { get; set; }
}

