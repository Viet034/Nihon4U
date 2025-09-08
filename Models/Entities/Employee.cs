namespace Nihon4U.Models.Entities;

public class Employee : BaseEntity
{
    public string Phone { get; set; }
    public string Address { get; set; }
    public string Gender { get; set; }
    public string? ImageURL { get; set; }
    public string Status { get; set; }
    public int UserId { get; set; }

    public virtual User User { get; set; }
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
