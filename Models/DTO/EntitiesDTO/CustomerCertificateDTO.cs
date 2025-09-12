namespace Nihon4U.Models.DTO.EntitiesDTO;

public class CustomerCertificateDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }

    public int CustomerId { get; set; }

    public int CertificateId { get; set; }
    public DateTime IssuedAt { get; set; }
    public double ScorePercentage { get; set; }
    public string PdfUrl { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public string CreateBy { get; set; }
    public string UpdateBy { get; set; }
}
