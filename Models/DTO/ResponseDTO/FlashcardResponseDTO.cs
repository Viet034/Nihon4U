namespace Nihon4U.Models.DTO.ResponseDTO;

public class FlashcardResponseDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }

    public string Status { get; set; }
    public int LessonId { get; set; }
    public string FrontText { get; set; } // Question
    public string BackText { get; set; } // Answer/translation
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public string CreateBy { get; set; }
    public string UpdateBy { get; set; }
}
