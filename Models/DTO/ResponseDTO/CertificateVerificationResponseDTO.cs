namespace Nihon4U.Models.DTO.ResponseDTO;

public class CertificateVerificationResponseDTO
{
    public string CertificateNumber { get; set; } = string.Empty;
    public bool IsValid { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string CourseName { get; set; } = string.Empty;
    public string CourseLevel { get; set; } = string.Empty;
    public double FinalScore { get; set; }
    public DateTime IssuedAt { get; set; }
    public DateTime? ExpiresAt { get; set; }
    public string Status { get; set; } = string.Empty; // Valid, Revoked, Expired
    public string? RevocationReason { get; set; }
}
