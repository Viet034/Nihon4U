using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nihon4U.Data;
using Nihon4U.Models.DTO.EntitiesDTO;
using Nihon4U.Models.DTO.RequestDTO.Customer;
using Nihon4U.Models.DTO.ResponseDTO;
using Nihon4U.Models.Entities;
using Nihon4U.Models.Enums;
using Nihon4U.Services.Interfaces;

namespace Nihon4U.Services;

public class CustomerService : ICustomerService
{
    private readonly MyDbContext _context;
    private readonly IMapper _mapper;

    public CustomerService(MyDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CustomerResponseDTO>> GetAllCustomersAsync()
    {
        var customers = await _context.Customers
            .Include(c => c.User)
            .Include(c => c.Orders)
            .Include(c => c.CourseEnrollments)
            .ToListAsync();

        return _mapper.Map<IEnumerable<CustomerResponseDTO>>(customers);
    }

    public async Task<CustomerResponseDTO?> GetCustomerByIdAsync(int id)
    {
        var customer = await _context.Customers
            .Include(c => c.User)
            .Include(c => c.Orders)
            .Include(c => c.CourseEnrollments)
            .Include(c => c.Customer_Certificates)
            .FirstOrDefaultAsync(c => c.Id == id);

        return customer != null ? _mapper.Map<CustomerResponseDTO>(customer) : null;
    }

    public async Task<CustomerResponseDTO?> GetCustomerByUserIdAsync(int userId)
    {
        var customer = await _context.Customers
            .Include(c => c.User)
            .Include(c => c.Orders)
            .Include(c => c.CourseEnrollments)
            .FirstOrDefaultAsync(c => c.UserId == userId);

        return customer != null ? _mapper.Map<CustomerResponseDTO>(customer) : null;
    }

    public async Task<IEnumerable<CustomerResponseDTO>> GetCustomersByStatusAsync(CustomerStatus status)
    {
        var customers = await _context.Customers
            .Include(c => c.User)
            .Include(c => c.Orders)
            .Where(c => c.Status == status)
            .ToListAsync();

        return _mapper.Map<IEnumerable<CustomerResponseDTO>>(customers);
    }

    public async Task<CustomerResponseDTO> CreateCustomerAsync(CustomerCreateDTO customerCreateDto)
    {
        var customer = _mapper.Map<Customer>(customerCreateDto);
        customer.CreateDate = DateTime.UtcNow;
        customer.UpdateDate = DateTime.UtcNow;
        customer.Status = CustomerStatus.Pending;

        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();

        return _mapper.Map<CustomerResponseDTO>(customer);
    }

    public async Task<CustomerResponseDTO?> UpdateCustomerAsync(int id, CustomerUpdateDTO customerUpdateDto)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer == null) return null;

        _mapper.Map(customerUpdateDto, customer);
        customer.UpdateDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return _mapper.Map<CustomerResponseDTO>(customer);
    }

    public async Task<bool> DeleteCustomerAsync(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer == null) return false;

        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ChangeCustomerStatusAsync(int id, CustomerStatus status)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer == null) return false;

        customer.Status = status;
        customer.UpdateDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<CustomerResponseDTO>> SearchCustomersAsync(string keyword)
    {
        var customers = await _context.Customers
            .Include(c => c.User)
            .Where(c => c.Name.Contains(keyword) || 
                       c.Phone.Contains(keyword) ||
                       c.Address.Contains(keyword) ||
                       c.User.Email!.Contains(keyword))
            .ToListAsync();

        return _mapper.Map<IEnumerable<CustomerResponseDTO>>(customers);
    }

    public async Task<CustomerResponseDTO?> GetCustomerWithEnrollmentsAsync(int id)
    {
        var customer = await _context.Customers
            .Include(c => c.User)
            .Include(c => c.CourseEnrollments)
            .ThenInclude(ce => ce.Course)
            .FirstOrDefaultAsync(c => c.Id == id);

        return customer != null ? _mapper.Map<CustomerResponseDTO>(customer) : null;
    }

    public async Task<CustomerResponseDTO?> GetCustomerWithOrdersAsync(int id)
    {
        var customer = await _context.Customers
            .Include(c => c.User)
            .Include(c => c.Orders)
            .ThenInclude(o => o.OrderDetails)
            .FirstOrDefaultAsync(c => c.Id == id);

        return customer != null ? _mapper.Map<CustomerResponseDTO>(customer) : null;
    }
}

