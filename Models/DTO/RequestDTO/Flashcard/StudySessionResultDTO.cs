using System.ComponentModel.DataAnnotations;

namespace Nihon4U.Models.DTO.RequestDTO.Flashcard;

public class StudySessionResultDTO
{
    [Required]
    public int SessionId { get; set; }

    [Required]
    public List<FlashcardResultDTO> FlashcardResults { get; set; } = new();

    public int TotalTimeSpent { get; set; } // seconds
}

public class FlashcardResultDTO
{
    [Required]
    public int FlashcardId { get; set; }

    [Required]
    public string Difficulty { get; set; } = string.Empty; // Easy, Medium, Hard

    public int TimeSpent { get; set; } // seconds
    public bool WasCorrect { get; set; }
}

