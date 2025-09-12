namespace Nihon4U.Models.DTO.ResponseDTO;

public class FeedbackResponseDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string Status { get; set; }
    public int CustomerId { get; set; }
    public int CourseId { get; set; }
    public int Rating { get; set; } // 1-5 stars
    public string? Comment { get; set; } // Optional feedback text
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public string CreateBy { get; set; }
    public string UpdateBy { get; set; }
}
