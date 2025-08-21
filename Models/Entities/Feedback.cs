namespace Nihon4U.Models.Entities;

public class Feedback : BaseEntity
{
    public string Status { get; set; } 
    public int CustomerId { get; set; } 
    public int CourseId { get; set; } 
    public int Rating { get; set; } // 1-5 stars
    public string? Comment { get; set; } // Optional feedback text
    public virtual Customer Customer { get; set; } 
    public virtual Course Course { get; set; } 
}
