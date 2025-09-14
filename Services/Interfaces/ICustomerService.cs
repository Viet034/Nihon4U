using Nihon4U.Models.DTO.EntitiesDTO;
using Nihon4U.Models.DTO.RequestDTO.Customer;
using Nihon4U.Models.DTO.ResponseDTO;
using Nihon4U.Models.Enums;

namespace Nihon4U.Services.Interfaces;

public interface ICustomerService
{
    Task<IEnumerable<CustomerResponseDTO>> GetAllCustomersAsync();
    Task<CustomerResponseDTO?> GetCustomerByIdAsync(int id);
    Task<CustomerResponseDTO?> GetCustomerByUserIdAsync(int userId);
    Task<IEnumerable<CustomerResponseDTO>> GetCustomersByStatusAsync(CustomerStatus status);
    Task<CustomerResponseDTO> CreateCustomerAsync(CustomerCreateDTO customerCreateDto);
    Task<CustomerResponseDTO?> UpdateCustomerAsync(int id, CustomerUpdateDTO customerUpdateDto);
    Task<bool> DeleteCustomerAsync(int id);
    Task<bool> ChangeCustomerStatusAsync(int id, CustomerStatus status);
    Task<IEnumerable<CustomerResponseDTO>> SearchCustomersAsync(string keyword);
    Task<CustomerResponseDTO?> GetCustomerWithEnrollmentsAsync(int id);
    Task<CustomerResponseDTO?> GetCustomerWithOrdersAsync(int id);
}

