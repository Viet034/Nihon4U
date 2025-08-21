namespace Nihon4U.Models.Entities;

public class FlashcardProgress : BaseEntity
{
    public string Status { get; set; }
    public int CustomerId { get; set; }
    public int FlashcardId { get; set; }
    public int CorrectCount { get; set; }
    public int IncorrectCount { get; set; }
    public DateTime? LastReviewedAt { get; set; }
    public virtual Customer Customer { get; set; }
    public virtual Flashcard Flashcard { get; set; }
}
