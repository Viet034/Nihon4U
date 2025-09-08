namespace Nihon4U.Models.Entities;

public class Customer_Certificate : BaseEntity
{

    public int CustomerId { get; set; } 
    
    public int CertificateId { get; set; } 
    public DateTime IssuedAt { get; set; } 
    public double ScorePercentage { get; set; } 
    public string PdfUrl { get; set; } 
    public virtual Customer Customer { get; set; } 
    public virtual Certificate Certificate { get; set; } 
}
