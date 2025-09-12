using Microsoft.AspNetCore.Mvc;
using Nihon4U.Models.DTO.EntitiesDTO;
using Nihon4U.Models.DTO.RequestDTO.Customer;
using Nihon4U.Models.DTO.ResponseDTO;
using Nihon4U.Models.Enums;
using Nihon4U.Services.Interfaces;

namespace Nihon4U.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomersController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    /// <summary>
    /// Get all customers
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerResponseDTO>>> GetAllCustomers()
    {
        var customers = await _customerService.GetAllCustomersAsync();
        return Ok(customers);
    }

    /// <summary>
    /// Get customer by ID
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerResponseDTO>> GetCustomerById(int id)
    {
        var customer = await _customerService.GetCustomerByIdAsync(id);
        if (customer == null)
            return NotFound($"Customer with ID {id} not found");

        return Ok(customer);
    }

    /// <summary>
    /// Get customer by user ID
    /// </summary>
    [HttpGet("user/{userId}")]
    public async Task<ActionResult<CustomerResponseDTO>> GetCustomerByUserId(int userId)
    {
        var customer = await _customerService.GetCustomerByUserIdAsync(userId);
        if (customer == null)
            return NotFound($"Customer with User ID {userId} not found");

        return Ok(customer);
    }

    /// <summary>
    /// Get customers by status
    /// </summary>
    [HttpGet("status/{status}")]
    public async Task<ActionResult<IEnumerable<CustomerResponseDTO>>> GetCustomersByStatus(CustomerStatus status)
    {
        var customers = await _customerService.GetCustomersByStatusAsync(status);
        return Ok(customers);
    }

    /// <summary>
    /// Search customers by keyword
    /// </summary>
    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<CustomerResponseDTO>>> SearchCustomers([FromQuery] string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword))
            return BadRequest("Keyword is required");

        var customers = await _customerService.SearchCustomersAsync(keyword);
        return Ok(customers);
    }

    /// <summary>
    /// Get customer with enrollments
    /// </summary>
    [HttpGet("{id}/enrollments")]
    public async Task<ActionResult<CustomerResponseDTO>> GetCustomerWithEnrollments(int id)
    {
        var customer = await _customerService.GetCustomerWithEnrollmentsAsync(id);
        if (customer == null)
            return NotFound($"Customer with ID {id} not found");

        return Ok(customer);
    }

    /// <summary>
    /// Get customer with orders
    /// </summary>
    [HttpGet("{id}/orders")]
    public async Task<ActionResult<CustomerResponseDTO>> GetCustomerWithOrders(int id)
    {
        var customer = await _customerService.GetCustomerWithOrdersAsync(id);
        if (customer == null)
            return NotFound($"Customer with ID {id} not found");

        return Ok(customer);
    }

    /// <summary>
    /// Create new customer
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<CustomerResponseDTO>> CreateCustomer([FromBody] CustomerCreateDTO customerCreateDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var customer = await _customerService.CreateCustomerAsync(customerCreateDto);
        return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Id }, customer);
    }

    /// <summary>
    /// Update customer
    /// </summary>
    [HttpPut("{id}")]
    public async Task<ActionResult<CustomerResponseDTO>> UpdateCustomer(int id, [FromBody] CustomerUpdateDTO customerUpdateDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var customer = await _customerService.UpdateCustomerAsync(id, customerUpdateDto);
        if (customer == null)
            return NotFound($"Customer with ID {id} not found");

        return Ok(customer);
    }

    /// <summary>
    /// Delete customer
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCustomer(int id)
    {
        var result = await _customerService.DeleteCustomerAsync(id);
        if (!result)
            return NotFound($"Customer with ID {id} not found");

        return NoContent();
    }

    /// <summary>
    /// Change customer status
    /// </summary>
    [HttpPatch("{id}/status")]
    public async Task<ActionResult> ChangeCustomerStatus(int id, [FromBody] CustomerStatus status)
    {
        var result = await _customerService.ChangeCustomerStatusAsync(id, status);
        if (!result)
            return NotFound($"Customer with ID {id} not found");

        return Ok(new { message = "Customer status updated successfully" });
    }
}
