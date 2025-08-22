namespace Nihon4U.Models.Entities;

public class Question : BaseEntity
{
    public string Status { get; set; } 
    public int? QuizzId { get; set; } 
    public int? TestId { get; set; } 
    public string Prompt { get; set; } 
    public string OptionA { get; set; } 
    public string OptionB { get; set; } 
    public string? OptionC { get; set; } 
    public string? OptionD { get; set; } 
    public string CorrectOption { get; set; } // correct option (A/B/C/D)
    public int Points { get; set; } // score 
    public virtual Quizz Quizz { get; set; } 
    public virtual Test Test { get; set; } 
}
