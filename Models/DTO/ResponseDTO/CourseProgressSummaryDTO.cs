namespace Nihon4U.Models.DTO.ResponseDTO;

public class CourseProgressSummaryDTO
{
    public int CourseId { get; set; }
    public string CourseName { get; set; } = string.Empty;
    public string CourseLevel { get; set; } = string.Empty;
    public int TotalLessons { get; set; }
    public int CompletedLessons { get; set; }
    public int InProgressLessons { get; set; }
    public int NotStartedLessons { get; set; }
    public double OverallProgress { get; set; }
    public int TotalTimeSpent { get; set; } // seconds
    public DateTime? LastStudied { get; set; }
    public DateTime? EnrolledAt { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime? CompletedAt { get; set; }
    public List<LessonProgressSummaryDTO> LessonProgress { get; set; } = new();
}

public class LessonProgressSummaryDTO
{
    public int LessonId { get; set; }
    public string LessonName { get; set; } = string.Empty;
    public int OrderIndex { get; set; }
    public double ProgressPercentage { get; set; }
    public bool IsCompleted { get; set; }
    public bool IsInProgress { get; set; }
    public int TimeSpent { get; set; } // seconds
    public DateTime? LastAccessed { get; set; }
    public DateTime? CompletedAt { get; set; }
}
