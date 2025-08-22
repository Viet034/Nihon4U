namespace Nihon4U.Models.Entities;

public class SupportRequest : BaseEntity
{
    public string Status { get; set; }
    public string Email { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ResolvedAt { get; set; }
}


