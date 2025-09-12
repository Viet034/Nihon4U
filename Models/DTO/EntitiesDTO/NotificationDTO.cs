namespace Nihon4U.Models.DTO.EntitiesDTO;

public class NotificationDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string Status { get; set; }
    public int UserId { get; set; }
    public string Type { get; set; } // System/Course/Order
    public string Title { get; set; } // Notification title
    public string Message { get; set; } // Notification body
    public bool IsRead { get; set; } // Read state
    public DateTime CreatedAt { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public string CreateBy { get; set; }
    public string UpdateBy { get; set; }
}
