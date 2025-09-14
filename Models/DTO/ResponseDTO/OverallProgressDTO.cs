namespace Nihon4U.Models.DTO.ResponseDTO;

public class OverallProgressDTO
{
    public int CustomerId { get; set; }
    public int TotalCourses { get; set; }
    public int EnrolledCourses { get; set; }
    public int CompletedCourses { get; set; }
    public int InProgressCourses { get; set; }
    public int TotalLessons { get; set; }
    public int CompletedLessons { get; set; }
    public int TotalTimeSpent { get; set; } // seconds
    public int CurrentStreak { get; set; } // days
    public int LongestStreak { get; set; } // days
    public DateTime? LastStudied { get; set; }
    public double OverallCompletionRate { get; set; }
    public List<LevelProgressDTO> LevelProgress { get; set; } = new();
    public List<MonthlyProgressDTO> MonthlyProgress { get; set; } = new();
}

public class LevelProgressDTO
{
    public string Level { get; set; } = string.Empty; // N5, N4, N3, N2, N1
    public int TotalCourses { get; set; }
    public int CompletedCourses { get; set; }
    public double CompletionRate { get; set; }
}

public class MonthlyProgressDTO
{
    public int Year { get; set; }
    public int Month { get; set; }
    public int LessonsCompleted { get; set; }
    public int TimeSpent { get; set; } // seconds
    public int StudyDays { get; set; }
}

