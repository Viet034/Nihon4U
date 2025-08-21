namespace Nihon4U.Models.Entities;

public class Quizz : BaseEntity
{
    public string Status { get; set; } 
    public int LessonId { get; set; } 
    public int OrderIndex { get; set; } 
    public bool IsFinalLessonQuiz { get; set; } 
    public virtual Lesson Lesson { get; set; } 
    public virtual ICollection<Question> Questions { get; set; } = new List<Question>(); 
