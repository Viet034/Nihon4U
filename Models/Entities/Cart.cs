namespace Nihon4U.Models.Entities;

public class Cart : BaseEntity
{
    public int CustomerId { get; set; } 
    public virtual Customer Customer { get; set; }
    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
}
