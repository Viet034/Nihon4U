using Nihon4U.Models.Enums;

namespace Nihon4U.Models.Entities;

public class Order : BaseEntity
{
    public OrderStatus Status { get; set; }
    public int CustomerId { get; set; }
    public int EmployeeId { get; set; }
    public decimal TotalAmount { get; set; }
    public string Currency { get; set; }
    public string PaymentProvider { get; set; } // e.g., Stripe
    public PaymentStatus PaymentStatus { get; set; } // e.g., Paid, Pending
    public DateTime OrderedAt { get; set; }
    public virtual Employee Employee { get; set; }
    public virtual Customer Customer { get; set; }
    public virtual ICollection<Order_Detail> OrderDetails { get; set; } = new List<Order_Detail>();
    public virtual ICollection<CourseEnrollment> CourseEnrollments { get; set; } = new List<CourseEnrollment>();
}
