namespace Nihon4U.Models.DTO.ResponseDTO;

public class CourseDetailResponseDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }

    public decimal Price { get; set; }
    public string Status { get; set; }
    public int CourseId { get; set; }
    public string? Summary { get; set; } // Short summary
    public string? Language { get; set; } // Course language
    public int EstimatedHours { get; set; } // ETA
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public string CreateBy { get; set; }
    public string UpdateBy { get; set; }
}
