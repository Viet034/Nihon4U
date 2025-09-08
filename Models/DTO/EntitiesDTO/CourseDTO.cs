namespace Nihon4U.Models.DTO.EntitiesDTO;

public class CourseDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public string CreateBy { get; set; }
    public string UpdateBy { get; set; }
    public string Status { get; set; }
    public string? Description { get; set; }
    public string? Level { get; set; } // N5-N1
    public bool IsCombo { get; set; } // True if combo course
}
