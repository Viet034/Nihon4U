namespace Nihon4U.Models.Entities;

public class Order_Detail : BaseEntity
{
    public string Status { get; set; }
    public int OrderId { get; set; }
    public int CourseId { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public virtual Order Order { get; set; }
    public virtual Course Course { get; set; }
}
