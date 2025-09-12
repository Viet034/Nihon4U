namespace Nihon4U.Models.Entities;

public class Notification : BaseEntity
{
    public string Status { get; set; } 
    public int UserId { get; set; } 
    public string Type { get; set; } // System/Course/Order
    public string Title { get; set; } // Notification title
    public string Message { get; set; } // Notification body
    public bool IsRead { get; set; } // Read state
    public DateTime CreatedAt { get; set; }
    public virtual User User { get; set; } 
}
