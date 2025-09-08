namespace Nihon4U.Models.Enums;

public enum CourseStatus
{
    Pending = 0,
    Active = 1,
    Inactive = 2,
    Draft = 3,
    Archived = 4
}

public enum CustomerStatus
{
    Pending = 0,
    Active = 1,
    Inactive = 2,
    Suspended = 3,
    Banned = 4
}

public enum OrderStatus
{
    Pending = 0,
    Confirmed = 1,
    Processing = 2,
    Shipped = 3,
    Delivered = 4,
    Cancelled = 5,
    Refunded = 6
}

public enum PaymentStatus
{
    Pending = 0,
    Paid = 1,
    Failed = 2,
    Refunded = 3,
    Cancelled = 4
}

public enum EnrollmentStatus
{
    Pending = 0,
    Active = 1,
    Completed = 2,
    Suspended = 3,
    Cancelled = 4
}

public enum LessonStatus
{
    Draft = 0,
    Published = 1,
    Archived = 2
}

public enum TestStatus
{
    Draft = 0,
    Published = 1,
    Archived = 2
}

public enum CertificateStatus
{
    Pending = 0,
    Issued = 1,
    Revoked = 2
}

public enum NotificationStatus
{
    Unread = 0,
    Read = 1,
    Archived = 2
}

public enum SupportRequestStatus
{
    Open = 0,
    InProgress = 1,
    Resolved = 2,
    Closed = 3
}
