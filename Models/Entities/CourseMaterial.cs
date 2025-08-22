namespace Nihon4U.Models.Entities;

public class CourseMaterial : BaseEntity
{
    public string Status { get; set; } 
    public int LessonId { get; set; } 
    public string Title { get; set; } 
    public string? Description { get; set; } 
    public string? PdfUrl { get; set; } // pdf link
    public virtual Lesson Lesson { get; set; } 
}
