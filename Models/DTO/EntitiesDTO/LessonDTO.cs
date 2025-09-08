namespace Nihon4U.Models.DTO.EntitiesDTO;

public class LessonDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string Status { get; set; }
    public int CourseId { get; set; }
    public int OrderIndex { get; set; }
    public bool IsFreePreview { get; set; } // free trial?
    public string? VideoUrl { get; set; } // Link video Ytb
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public string CreateBy { get; set; }
    public string UpdateBy { get; set; }
}
