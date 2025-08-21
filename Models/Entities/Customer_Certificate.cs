namespace Nihon4U.Models.Entities;

public class Customer_Certificate
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int CertificateId { get; set; }
    public virtual Customer Customer { get; set; }
    public virtual Certificate Certificate { get; set; }
}
