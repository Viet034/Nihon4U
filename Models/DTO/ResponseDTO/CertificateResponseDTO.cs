namespace Nihon4U.Models.DTO.ResponseDTO;

public class CertificateResponseDTO
{

    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public string CreateBy { get; set; }
    public string UpdateBy { get; set; }
    public string Status { get; set; }
    public int CourseId { get; set; }
    public string TemplateUrl { get; set; } // PDF template URL
    public double MinPassPercentage { get; set; } // Default >= 70
}
