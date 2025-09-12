using Microsoft.AspNetCore.Mvc;
using Nihon4U.Models.DTO.EntitiesDTO;
using Nihon4U.Models.DTO.ResponseDTO;
using Nihon4U.Models.Enums;
using Nihon4U.Services.Interfaces;

namespace Nihon4U.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    /// <summary>
    /// Get all orders
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderResponseDTO>>> GetAllOrders()
    {
        var orders = await _orderService.GetAllOrdersAsync();
        return Ok(orders);
    }

    /// <summary>
    /// Get order by ID
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<OrderResponseDTO>> GetOrderById(int id)
    {
        var order = await _orderService.GetOrderByIdAsync(id);
        if (order == null)
            return NotFound($"Order with ID {id} not found");

        return Ok(order);
    }

    /// <summary>
    /// Get orders by customer ID
    /// </summary>
    [HttpGet("customer/{customerId}")]
    public async Task<ActionResult<IEnumerable<OrderResponseDTO>>> GetOrdersByCustomerId(int customerId)
    {
        var orders = await _orderService.GetOrdersByCustomerIdAsync(customerId);
        return Ok(orders);
    }

    /// <summary>
    /// Get orders by status
    /// </summary>
    [HttpGet("status/{status}")]
    public async Task<ActionResult<IEnumerable<OrderResponseDTO>>> GetOrdersByStatus(OrderStatus status)
    {
        var orders = await _orderService.GetOrdersByStatusAsync(status);
        return Ok(orders);
    }

    /// <summary>
    /// Get orders by payment status
    /// </summary>
    [HttpGet("payment-status/{paymentStatus}")]
    public async Task<ActionResult<IEnumerable<OrderResponseDTO>>> GetOrdersByPaymentStatus(PaymentStatus paymentStatus)
    {
        var orders = await _orderService.GetOrdersByPaymentStatusAsync(paymentStatus);
        return Ok(orders);
    }

    /// <summary>
    /// Get orders by date range
    /// </summary>
    [HttpGet("date-range")]
    public async Task<ActionResult<IEnumerable<OrderResponseDTO>>> GetOrdersByDateRange(
        [FromQuery] DateTime startDate, 
        [FromQuery] DateTime endDate)
    {
        var orders = await _orderService.GetOrdersByDateRangeAsync(startDate, endDate);
        return Ok(orders);
    }

    /// <summary>
    /// Get total revenue
    /// </summary>
    [HttpGet("revenue/total")]
    public async Task<ActionResult<decimal>> GetTotalRevenue()
    {
        var totalRevenue = await _orderService.GetTotalRevenueAsync();
        return Ok(new { totalRevenue });
    }

    /// <summary>
    /// Get revenue by date range
    /// </summary>
    [HttpGet("revenue/date-range")]
    public async Task<ActionResult<decimal>> GetRevenueByDateRange(
        [FromQuery] DateTime startDate, 
        [FromQuery] DateTime endDate)
    {
        var revenue = await _orderService.GetRevenueByDateRangeAsync(startDate, endDate);
        return Ok(new { revenue });
    }

    /// <summary>
    /// Create new order
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<OrderResponseDTO>> CreateOrder([FromBody] OrderDTO orderDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var order = await _orderService.CreateOrderAsync(orderDto);
        return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, order);
    }

    /// <summary>
    /// Update order
    /// </summary>
    [HttpPut("{id}")]
    public async Task<ActionResult<OrderResponseDTO>> UpdateOrder(int id, [FromBody] OrderDTO orderDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var order = await _orderService.UpdateOrderAsync(id, orderDto);
        if (order == null)
            return NotFound($"Order with ID {id} not found");

        return Ok(order);
    }

    /// <summary>
    /// Delete order
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteOrder(int id)
    {
        var result = await _orderService.DeleteOrderAsync(id);
        if (!result)
            return NotFound($"Order with ID {id} not found");

        return NoContent();
    }

    /// <summary>
    /// Change order status
    /// </summary>
    [HttpPatch("{id}/status")]
    public async Task<ActionResult> ChangeOrderStatus(int id, [FromBody] OrderStatus status)
    {
        var result = await _orderService.ChangeOrderStatusAsync(id, status);
        if (!result)
            return NotFound($"Order with ID {id} not found");

        return Ok(new { message = "Order status updated successfully" });
    }

    /// <summary>
    /// Change payment status
    /// </summary>
    [HttpPatch("{id}/payment-status")]
    public async Task<ActionResult> ChangePaymentStatus(int id, [FromBody] PaymentStatus paymentStatus)
    {
        var result = await _orderService.ChangePaymentStatusAsync(id, paymentStatus);
        if (!result)
            return NotFound($"Order with ID {id} not found");

        return Ok(new { message = "Payment status updated successfully" });
    }
}
