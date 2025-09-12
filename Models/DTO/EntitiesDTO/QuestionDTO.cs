namespace Nihon4U.Models.DTO.EntitiesDTO;

public class QuestionDTO
{

    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    
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
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public string CreateBy { get; set; }
    public string UpdateBy { get; set; }
}
