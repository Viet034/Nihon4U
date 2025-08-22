namespace Nihon4U.Models.Entities;

public class Order : BaseEntity
{
    public string Status { get; set; }
    public int UserId { get; set; }
    public decimal TotalAmount { get; set; }
    public string Currency { get; set; }
    public string PaymentProvider { get; set; } // e.g., Stripe
    public string PaymentStatus { get; set; } // e.g., Paid, Pending
    public DateTime OrderedAt { get; set; }
    public virtual User User { get; set; }
    public virtual ICollection<Order_Detail> OrderDetails { get; set; } = new List<Order_Detail>();
}
