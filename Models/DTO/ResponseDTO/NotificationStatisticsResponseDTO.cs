namespace Nihon4U.Models.DTO.ResponseDTO;

public class NotificationStatisticsResponseDTO
{
    public int CustomerId { get; set; }
    public int TotalNotifications { get; set; }
    public int UnreadNotifications { get; set; }
    public int ReadNotifications { get; set; }
    public int ArchivedNotifications { get; set; }
    public List<NotificationTypeStatsDTO> TypeStatistics { get; set; } = new();
    public List<DailyNotificationStatsDTO> DailyStats { get; set; } = new();
}

public class NotificationTypeStatsDTO
{
    public string Type { get; set; } = string.Empty; // Course, Lesson, Certificate, Payment, etc.
    public int Count { get; set; }
    public int UnreadCount { get; set; }
}

public class DailyNotificationStatsDTO
{
    public DateTime Date { get; set; }
    public int Received { get; set; }
    public int Read { get; set; }
    public int Unread { get; set; }
}
