namespace Nihon4U.Models.DTO.ResponseDTO;

public class FlashcardStatisticsResponseDTO
{
    public int CustomerId { get; set; }
    public int? LessonId { get; set; }
    public int TotalFlashcards { get; set; }
    public int StudiedFlashcards { get; set; }
    public int MasteredFlashcards { get; set; }
    public int LearningFlashcards { get; set; }
    public int NewFlashcards { get; set; }
    public double MasteryRate { get; set; }
    public int TotalStudySessions { get; set; }
    public int TotalStudyTime { get; set; } // seconds
    public double AverageAccuracy { get; set; }
    public List<DailyStudyStatsDTO> DailyStats { get; set; } = new();
    public List<FlashcardMasteryDTO> FlashcardMastery { get; set; } = new();
}

public class DailyStudyStatsDTO
{
    public DateTime Date { get; set; }
    public int FlashcardsStudied { get; set; }
    public int StudyTime { get; set; } // seconds
    public double Accuracy { get; set; }
}

public class FlashcardMasteryDTO
{
    public int FlashcardId { get; set; }
    public string FrontText { get; set; } = string.Empty;
    public string BackText { get; set; } = string.Empty;
    public string MasteryLevel { get; set; } = string.Empty; // New, Learning, Mastered
    public int ReviewCount { get; set; }
    public DateTime LastReviewed { get; set; }
    public DateTime NextReview { get; set; }
}

