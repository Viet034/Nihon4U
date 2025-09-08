using Nihon4U.Models.DTO.EntitiesDTO;
using Nihon4U.Models.DTO.ResponseDTO;
using Nihon4U.Models.Enums;

namespace Nihon4U.Services.Interfaces;

public interface IOrderService
{
    Task<IEnumerable<OrderResponseDTO>> GetAllOrdersAsync();
    Task<OrderResponseDTO?> GetOrderByIdAsync(int id);
    Task<IEnumerable<OrderResponseDTO>> GetOrdersByCustomerIdAsync(int customerId);
    Task<IEnumerable<OrderResponseDTO>> GetOrdersByStatusAsync(OrderStatus status);
    Task<IEnumerable<OrderResponseDTO>> GetOrdersByPaymentStatusAsync(PaymentStatus paymentStatus);
    Task<OrderResponseDTO> CreateOrderAsync(OrderDTO orderDto);
    Task<OrderResponseDTO?> UpdateOrderAsync(int id, OrderDTO orderDto);
    Task<bool> DeleteOrderAsync(int id);
    Task<bool> ChangeOrderStatusAsync(int id, OrderStatus status);
    Task<bool> ChangePaymentStatusAsync(int id, PaymentStatus paymentStatus);
    Task<IEnumerable<OrderResponseDTO>> GetOrdersByDateRangeAsync(DateTime startDate, DateTime endDate);
    Task<decimal> GetTotalRevenueAsync();
    Task<decimal> GetRevenueByDateRangeAsync(DateTime startDate, DateTime endDate);
}
