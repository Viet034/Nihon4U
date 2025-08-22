namespace Nihon4U.Models.Entities;

public class Lesson : BaseEntity
{
    public string Status { get; set; }
    public int CourseId { get; set; } 
    public int OrderIndex { get; set; } 
    public bool IsFreePreview { get; set; } // free trial?
    public string? VideoUrl { get; set; } // Link video Ytb
    public virtual Course Course { get; set; } 
    public virtual ICollection<CourseMaterial> Materials { get; set; } = new List<CourseMaterial>();
    public virtual ICollection<Quizz> Quizzes { get; set; } = new List<Quizz>(); 
    public virtual ICollection<Flashcard> Flashcards { get; set; } = new List<Flashcard>(); 
}
