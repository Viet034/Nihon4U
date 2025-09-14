namespace Nihon4U.Models.DTO.ResponseDTO;

public class MaterialAccessResponseDTO
{
    public int MaterialId { get; set; }
    public int CustomerId { get; set; }
    public bool HasAccess { get; set; }
    public string AccessReason { get; set; } = string.Empty; // "Enrolled", "Free Preview", "No Access"
    public DateTime? AccessGrantedAt { get; set; }
    public DateTime? AccessExpiresAt { get; set; }
    public bool IsFreePreview { get; set; }
}

