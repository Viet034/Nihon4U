namespace Nihon4U.Models.Entities;

public class Cart : BaseEntity
{
    public int UserId { get; set; } 
    public DateTime UpdatedAt { get; set; }
    public virtual User User { get; set; } 
    public virtual ICollection<CartItem> Items { get; set; } = new List<CartItem>(); 
}
