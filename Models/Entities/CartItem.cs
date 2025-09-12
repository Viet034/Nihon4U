namespace Nihon4U.Models.Entities;

public class CartItem : BaseEntity
{
    public int Quantity { get; set; }
    public int CourseId { get; set; }
    public int CartId { get; set; }
    public virtual Course Course { get; set; }
    public virtual Cart Cart { get; set; }
}
