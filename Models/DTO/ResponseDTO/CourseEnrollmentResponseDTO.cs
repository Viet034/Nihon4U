namespace Nihon4U.Models.DTO.ResponseDTO;

public class CourseEnrollmentResponseDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public string CreateBy { get; set; }
    public string UpdateBy { get; set; }
    public string Status { get; set; }
    public int CustomerId { get; set; }
    public int CourseId { get; set; }
    public DateTime EnrolledAt { get; set; }
    public bool IsLifetimeAccess { get; set; }
    public DateTime? ExpiresAt { get; set; }
    public int? OrderId { get; set; }
}
