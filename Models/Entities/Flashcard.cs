namespace Nihon4U.Models.Entities;

public class Flashcard : BaseEntity
{
    public string Status { get; set; }
    public int LessonId { get; set; } 
    public string FrontText { get; set; } // Question
    public string BackText { get; set; } // Answer/translation
    public virtual Lesson Lesson { get; set; } 
}
