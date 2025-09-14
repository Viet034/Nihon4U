using System.ComponentModel.DataAnnotations;

namespace Nihon4U.Models.DTO.RequestDTO.Certificate;

public class CertificateIssueRequestDTO
{
    [Required]
    public int CustomerId { get; set; }

    [Required]
    public int CourseId { get; set; }

    [Required]
    [Range(0, 100)]
    public double FinalScore { get; set; }

    public DateTime? CompletedAt { get; set; }
    public string? Notes { get; set; }
}

