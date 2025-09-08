using Nihon4U.Models.Enums;

namespace Nihon4U.Models.Entities;

public class CourseEnrollment : BaseEntity
{
    public EnrollmentStatus Status { get; set; }
    public int CustomerId { get; set; }
    public int CourseId { get; set; }
    public DateTime EnrolledAt { get; set; }
    public bool IsLifetimeAccess { get; set; }
    public DateTime? ExpiresAt { get; set; }
    public int? OrderId { get; set; }
    public virtual Customer Customer { get; set; }
    public virtual Course Course { get; set; }
    public virtual Order? Order { get; set; }
}
