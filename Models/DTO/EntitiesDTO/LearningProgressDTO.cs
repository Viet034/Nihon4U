namespace Nihon4U.Models.DTO.EntitiesDTO;

public class LearningProgressDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string Status { get; set; }
    public int CustomerId { get; set; }
    public int CourseId { get; set; }
    public int CompletedLessons { get; set; }
    public int TotalLessons { get; set; }
    public double CompletionPercentage { get; set; }
    public DateTime LastActivityAt { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public string CreateBy { get; set; }
    public string UpdateBy { get; set; }
}
