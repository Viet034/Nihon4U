namespace Nihon4U.Models.Entities;

public class LearningStreak : BaseEntity
{
    public string Status { get; set; }
    public int CustomerId { get; set; }
    public int CurrentStreakDays { get; set; }
    public int LongestStreakDays { get; set; }
    public DateTime? LastActiveDate { get; set; }
    public virtual Customer Customer { get; set; }
}
