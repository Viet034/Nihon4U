using Nihon4U.Models.DTO.EntitiesDTO;
using Nihon4U.Models.DTO.ResponseDTO;
using Nihon4U.Models.Enums;

namespace Nihon4U.Services.Interfaces;

public interface INotificationService
{
    Task<IEnumerable<NotificationResponseDTO>> GetAllNotificationsAsync();
    Task<NotificationResponseDTO?> GetNotificationByIdAsync(int id);
    Task<IEnumerable<NotificationResponseDTO>> GetNotificationsByCustomerIdAsync(int customerId);
    Task<IEnumerable<NotificationResponseDTO>> GetUnreadNotificationsAsync(int customerId);
    Task<NotificationResponseDTO> CreateNotificationAsync(NotificationDTO notificationDto);
    Task<NotificationResponseDTO?> UpdateNotificationAsync(int id, NotificationDTO notificationDto);
    Task<bool> DeleteNotificationAsync(int id);
    Task<bool> MarkAsReadAsync(int notificationId);
    Task<bool> MarkAllAsReadAsync(int customerId);
    Task<bool> ChangeNotificationStatusAsync(int id, NotificationStatus status);
    Task<NotificationResponseDTO> SendCourseEnrollmentNotificationAsync(int customerId, int courseId);
    Task<NotificationResponseDTO> SendLessonCompletedNotificationAsync(int customerId, int lessonId);
    Task<NotificationResponseDTO> SendCertificateEarnedNotificationAsync(int customerId, int certificateId);
    Task<NotificationResponseDTO> SendPaymentSuccessNotificationAsync(int customerId, int orderId);
    Task<NotificationStatisticsResponseDTO> GetNotificationStatisticsAsync(int customerId);
}
