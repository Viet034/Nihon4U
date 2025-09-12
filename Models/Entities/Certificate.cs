using Nihon4U.Models.Enums;

namespace Nihon4U.Models.Entities;

public class Certificate : BaseEntity
{
    public CertificateStatus Status { get; set; } 
    public int CourseId { get; set; } 
    public string TemplateUrl { get; set; } // PDF template URL
    public double MinPassPercentage { get; set; } // Default >= 70
    public virtual Course Course { get; set; } 
    public virtual ICollection<Customer_Certificate> Customer_Certificates { get; set; } = new List<Customer_Certificate>(); 
}
