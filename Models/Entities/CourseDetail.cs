namespace Nihon4U.Models.Entities;

public class CourseDetail : BaseEntity
{
    public decimal Price { get; set; } 
    public string Status { get; set; } 
    public int CourseId { get; set; } 
    public string? Summary { get; set; } // Short summary
    public string? Language { get; set; } // Course language
    public int EstimatedHours { get; set; } // ETA
    public virtual Course Course { get; set; } 


}
