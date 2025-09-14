using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nihon4U.Data;
using Nihon4U.Models.DTO.EntitiesDTO;
using Nihon4U.Models.DTO.ResponseDTO;
using Nihon4U.Models.Entities;
using Nihon4U.Models.Enums;
using Nihon4U.Services.Interfaces;

namespace Nihon4U.Services;

public class OrderService : IOrderService
{
    private readonly MyDbContext _context;
    private readonly IMapper _mapper;

    public OrderService(MyDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<OrderResponseDTO>> GetAllOrdersAsync()
    {
        var orders = await _context.Orders
            .Include(o => o.Customer)
            .ThenInclude(c => c.User)
            .Include(o => o.Employee)
            .Include(o => o.OrderDetails)
            .ToListAsync();

        return _mapper.Map<IEnumerable<OrderResponseDTO>>(orders);
    }

    public async Task<OrderResponseDTO?> GetOrderByIdAsync(int id)
    {
        var order = await _context.Orders
            .Include(o => o.Customer)
            .ThenInclude(c => c.User)
            .Include(o => o.Employee)
            .Include(o => o.OrderDetails)
            .ThenInclude(od => od.Course)
            .FirstOrDefaultAsync(o => o.Id == id);

        return order != null ? _mapper.Map<OrderResponseDTO>(order) : null;
    }

    public async Task<IEnumerable<OrderResponseDTO>> GetOrdersByCustomerIdAsync(int customerId)
    {
        var orders = await _context.Orders
            .Include(o => o.Customer)
            .ThenInclude(c => c.User)
            .Include(o => o.Employee)
            .Include(o => o.OrderDetails)
            .Where(o => o.CustomerId == customerId)
            .ToListAsync();

        return _mapper.Map<IEnumerable<OrderResponseDTO>>(orders);
    }

    public async Task<IEnumerable<OrderResponseDTO>> GetOrdersByStatusAsync(OrderStatus status)
    {
        var orders = await _context.Orders
            .Include(o => o.Customer)
            .ThenInclude(c => c.User)
            .Include(o => o.Employee)
            .Include(o => o.OrderDetails)
            .Where(o => o.Status == status)
            .ToListAsync();

        return _mapper.Map<IEnumerable<OrderResponseDTO>>(orders);
    }

    public async Task<IEnumerable<OrderResponseDTO>> GetOrdersByPaymentStatusAsync(PaymentStatus paymentStatus)
    {
        var orders = await _context.Orders
            .Include(o => o.Customer)
            .ThenInclude(c => c.User)
            .Include(o => o.Employee)
            .Include(o => o.OrderDetails)
            .Where(o => o.PaymentStatus == paymentStatus)
            .ToListAsync();

        return _mapper.Map<IEnumerable<OrderResponseDTO>>(orders);
    }

    public async Task<OrderResponseDTO> CreateOrderAsync(OrderDTO orderDto)
    {
        var order = _mapper.Map<Order>(orderDto);
        order.CreateDate = DateTime.UtcNow;
        order.UpdateDate = DateTime.UtcNow;
        order.OrderedAt = DateTime.UtcNow;
        order.Status = OrderStatus.Pending;
        order.PaymentStatus = PaymentStatus.Pending;

        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        return _mapper.Map<OrderResponseDTO>(order);
    }

    public async Task<OrderResponseDTO?> UpdateOrderAsync(int id, OrderDTO orderDto)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order == null) return null;

        _mapper.Map(orderDto, order);
        order.UpdateDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return _mapper.Map<OrderResponseDTO>(order);
    }

    public async Task<bool> DeleteOrderAsync(int id)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order == null) return false;

        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ChangeOrderStatusAsync(int id, OrderStatus status)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order == null) return false;

        order.Status = status;
        order.UpdateDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ChangePaymentStatusAsync(int id, PaymentStatus paymentStatus)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order == null) return false;

        order.PaymentStatus = paymentStatus;
        order.UpdateDate = DateTime.UtcNow;

        // If payment is successful, change order status to confirmed
        if (paymentStatus == PaymentStatus.Paid)
        {
            order.Status = OrderStatus.Confirmed;
        }

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<OrderResponseDTO>> GetOrdersByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        var orders = await _context.Orders
            .Include(o => o.Customer)
            .ThenInclude(c => c.User)
            .Include(o => o.Employee)
            .Include(o => o.OrderDetails)
            .Where(o => o.OrderedAt >= startDate && o.OrderedAt <= endDate)
            .ToListAsync();

        return _mapper.Map<IEnumerable<OrderResponseDTO>>(orders);
    }

    public async Task<decimal> GetTotalRevenueAsync()
    {
        return await _context.Orders
            .Where(o => o.PaymentStatus == PaymentStatus.Paid)
            .SumAsync(o => o.TotalAmount);
    }

    public async Task<decimal> GetRevenueByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        return await _context.Orders
            .Where(o => o.PaymentStatus == PaymentStatus.Paid && 
                       o.OrderedAt >= startDate && 
                       o.OrderedAt <= endDate)
            .SumAsync(o => o.TotalAmount);
    }
}

