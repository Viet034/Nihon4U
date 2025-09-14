using System.ComponentModel.DataAnnotations;

namespace Nihon4U.Models.DTO.RequestDTO.Progress;

public class LessonProgressUpdateDTO
{
    [Required]
    public int CustomerId { get; set; }

    [Required]
    public int LessonId { get; set; }

    [Range(0, 100)]
    public double ProgressPercentage { get; set; }

    public int TimeSpent { get; set; } // seconds
    public bool IsCompleted { get; set; }
    public DateTime? CompletedAt { get; set; }
    public string? Notes { get; set; }
}

