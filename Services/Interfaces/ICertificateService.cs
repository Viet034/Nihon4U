using Nihon4U.Models.DTO.EntitiesDTO;
using Nihon4U.Models.DTO.RequestDTO.Certificate;
using Nihon4U.Models.DTO.ResponseDTO;

namespace Nihon4U.Services.Interfaces;

public interface ICertificateService
{
    Task<IEnumerable<CertificateResponseDTO>> GetAllCertificatesAsync();
    Task<CertificateResponseDTO?> GetCertificateByIdAsync(int id);
    Task<IEnumerable<CertificateResponseDTO>> GetCertificatesByCourseIdAsync(int courseId);
    Task<CertificateResponseDTO> CreateCertificateAsync(CertificateDTO certificateDto);
    Task<CertificateResponseDTO?> UpdateCertificateAsync(int id, CertificateDTO certificateDto);
    Task<bool> DeleteCertificateAsync(int id);
    Task<CustomerCertificateResponseDTO> IssueCertificateAsync(int customerId, int courseId, CertificateIssueRequestDTO issueRequest);
    Task<IEnumerable<CustomerCertificateResponseDTO>> GetCustomerCertificatesAsync(int customerId);
    Task<CustomerCertificateResponseDTO?> GetCustomerCertificateByIdAsync(int id);
    Task<bool> RevokeCertificateAsync(int certificateId, string reason);
    Task<bool> VerifyCertificateAsync(string certificateNumber);
    Task<CertificateVerificationResponseDTO> GetCertificateVerificationAsync(string certificateNumber);
    Task<byte[]> GenerateCertificatePDFAsync(int customerCertificateId);
    Task<string> GetCertificateDownloadUrlAsync(int customerCertificateId);
}

