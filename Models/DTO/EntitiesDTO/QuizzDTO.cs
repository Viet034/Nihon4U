namespace Nihon4U.Models.DTO.EntitiesDTO;

public class QuizzDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    
    public string Status { get; set; }
    public int LessonId { get; set; }
    public int OrderIndex { get; set; }
    public bool IsFinalLessonQuiz { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public string CreateBy { get; set; }
    public string UpdateBy { get; set; }
}
