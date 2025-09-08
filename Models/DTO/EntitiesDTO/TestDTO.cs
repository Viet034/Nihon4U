namespace Nihon4U.Models.DTO.EntitiesDTO;

public class TestDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    
    public string Status { get; set; }
    public int CourseId { get; set; }
    public bool IsFinal { get; set; }
    public double PassPercentage { get; set; } // pass percentage
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public string CreateBy { get; set; }
    public string UpdateBy { get; set; }
}
