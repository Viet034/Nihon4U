namespace Nihon4U.Models.Entities;

public class LearningProgress : BaseEntity
{
    public string Status { get; set; }
    public int CustomerId { get; set; }
    public int CourseId { get; set; }
    public int CompletedLessons { get; set; }
    public int TotalLessons { get; set; }
    public double CompletionPercentage { get; set; }
    public DateTime LastActivityAt { get; set; }
    public virtual Customer Customer { get; set; }
    public virtual Course Course { get; set; }
}
