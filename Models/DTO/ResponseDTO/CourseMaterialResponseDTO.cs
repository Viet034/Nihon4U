namespace Nihon4U.Models.DTO.ResponseDTO;

public class CourseMaterialResponseDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public string CreateBy { get; set; }
    public string UpdateBy { get; set; }
    public string Status { get; set; }
    public int LessonId { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public string? PdfUrl { get; set; } // pdf link
}
