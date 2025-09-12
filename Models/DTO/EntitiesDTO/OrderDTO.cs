namespace Nihon4U.Models.DTO.EntitiesDTO;

public class OrderDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }

    public string Status { get; set; }
    public int CustomerId { get; set; }
    public int EmployeeId { get; set; }
    public decimal TotalAmount { get; set; }
    public string Currency { get; set; }
    public string PaymentProvider { get; set; } // e.g., Stripe
    public string PaymentStatus { get; set; } // e.g., Paid, Pending
  
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public string CreateBy { get; set; }
    public string UpdateBy { get; set; }
}
