namespace Nihon4U.Models;

public class Certificate : BaseEntity
{
    public string Status { get; set; }
    public virtual ICollection<Customer_Certificate> Customer_Certificates { get; set; } = new List<Customer_Certificate>();
}
