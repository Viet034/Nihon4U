using System.ComponentModel.DataAnnotations;

namespace Nihon4U.Models.DTO.RequestDTO.Quiz;

public class QuizAnswerRequestDTO
{
    [Required]
    public int CustomerId { get; set; }

    [Required]
    public List<QuestionAnswerDTO> Answers { get; set; } = new();
}

public class QuestionAnswerDTO
{
    [Required]
    public int QuestionId { get; set; }

    [Required]
    public string SelectedAnswer { get; set; } = string.Empty;

    public int TimeSpent { get; set; } // seconds
}
