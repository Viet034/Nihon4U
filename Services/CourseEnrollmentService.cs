using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nihon4U.Data;
using Nihon4U.Models.DTO.EntitiesDTO;
using Nihon4U.Models.DTO.ResponseDTO;
using Nihon4U.Models.Entities;
using Nihon4U.Models.Enums;
using Nihon4U.Services.Interfaces;

namespace Nihon4U.Services;

public class CourseEnrollmentService : ICourseEnrollmentService
{
    private readonly MyDbContext _context;
    private readonly IMapper _mapper;

    public CourseEnrollmentService(MyDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CourseEnrollmentResponseDTO>> GetAllEnrollmentsAsync()
    {
        var enrollments = await _context.CourseEnrollments
            .Include(ce => ce.Customer)
            .ThenInclude(c => c.User)
            .Include(ce => ce.Course)
            .Include(ce => ce.Order)
            .ToListAsync();

        return _mapper.Map<IEnumerable<CourseEnrollmentResponseDTO>>(enrollments);
    }

    public async Task<CourseEnrollmentResponseDTO?> GetEnrollmentByIdAsync(int id)
    {
        var enrollment = await _context.CourseEnrollments
            .Include(ce => ce.Customer)
            .ThenInclude(c => c.User)
            .Include(ce => ce.Course)
            .Include(ce => ce.Order)
            .FirstOrDefaultAsync(ce => ce.Id == id);

        return enrollment != null ? _mapper.Map<CourseEnrollmentResponseDTO>(enrollment) : null;
    }

    public async Task<IEnumerable<CourseEnrollmentResponseDTO>> GetEnrollmentsByCustomerIdAsync(int customerId)
    {
        var enrollments = await _context.CourseEnrollments
            .Include(ce => ce.Customer)
            .ThenInclude(c => c.User)
            .Include(ce => ce.Course)
            .Include(ce => ce.Order)
            .Where(ce => ce.CustomerId == customerId)
            .ToListAsync();

        return _mapper.Map<IEnumerable<CourseEnrollmentResponseDTO>>(enrollments);
    }

    public async Task<IEnumerable<CourseEnrollmentResponseDTO>> GetEnrollmentsByCourseIdAsync(int courseId)
    {
        var enrollments = await _context.CourseEnrollments
            .Include(ce => ce.Customer)
            .ThenInclude(c => c.User)
            .Include(ce => ce.Course)
            .Include(ce => ce.Order)
            .Where(ce => ce.CourseId == courseId)
            .ToListAsync();

        return _mapper.Map<IEnumerable<CourseEnrollmentResponseDTO>>(enrollments);
    }

    public async Task<IEnumerable<CourseEnrollmentResponseDTO>> GetEnrollmentsByStatusAsync(EnrollmentStatus status)
    {
        var enrollments = await _context.CourseEnrollments
            .Include(ce => ce.Customer)
            .ThenInclude(c => c.User)
            .Include(ce => ce.Course)
            .Include(ce => ce.Order)
            .Where(ce => ce.Status == status)
            .ToListAsync();

        return _mapper.Map<IEnumerable<CourseEnrollmentResponseDTO>>(enrollments);
    }

    public async Task<CourseEnrollmentResponseDTO> CreateEnrollmentAsync(CourseEnrollmentDTO enrollmentDto)
    {
        var enrollment = _mapper.Map<CourseEnrollment>(enrollmentDto);
        enrollment.CreateDate = DateTime.UtcNow;
        enrollment.UpdateDate = DateTime.UtcNow;
        enrollment.EnrolledAt = DateTime.UtcNow;
        enrollment.Status = EnrollmentStatus.Pending;

        _context.CourseEnrollments.Add(enrollment);
        await _context.SaveChangesAsync();

        return _mapper.Map<CourseEnrollmentResponseDTO>(enrollment);
    }

    public async Task<CourseEnrollmentResponseDTO?> UpdateEnrollmentAsync(int id, CourseEnrollmentDTO enrollmentDto)
    {
        var enrollment = await _context.CourseEnrollments.FindAsync(id);
        if (enrollment == null) return null;

        _mapper.Map(enrollmentDto, enrollment);
        enrollment.UpdateDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return _mapper.Map<CourseEnrollmentResponseDTO>(enrollment);
    }

    public async Task<bool> DeleteEnrollmentAsync(int id)
    {
        var enrollment = await _context.CourseEnrollments.FindAsync(id);
        if (enrollment == null) return false;

        _context.CourseEnrollments.Remove(enrollment);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ChangeEnrollmentStatusAsync(int id, EnrollmentStatus status)
    {
        var enrollment = await _context.CourseEnrollments.FindAsync(id);
        if (enrollment == null) return false;

        enrollment.Status = status;
        enrollment.UpdateDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> CheckCustomerEnrolledAsync(int customerId, int courseId)
    {
        return await _context.CourseEnrollments
            .AnyAsync(ce => ce.CustomerId == customerId && 
                           ce.CourseId == courseId && 
                           ce.Status == EnrollmentStatus.Active);
    }

    public async Task<IEnumerable<CourseEnrollmentResponseDTO>> GetActiveEnrollmentsByCustomerIdAsync(int customerId)
    {
        var enrollments = await _context.CourseEnrollments
            .Include(ce => ce.Customer)
            .ThenInclude(c => c.User)
            .Include(ce => ce.Course)
            .Include(ce => ce.Order)
            .Where(ce => ce.CustomerId == customerId && ce.Status == EnrollmentStatus.Active)
            .ToListAsync();

        return _mapper.Map<IEnumerable<CourseEnrollmentResponseDTO>>(enrollments);
    }

    public async Task<bool> EnrollCustomerToCourseAsync(int customerId, int courseId, int? orderId = null)
    {
        // Check if customer is already enrolled
        var existingEnrollment = await _context.CourseEnrollments
            .FirstOrDefaultAsync(ce => ce.CustomerId == customerId && ce.CourseId == courseId);

        if (existingEnrollment != null)
        {
            // If already enrolled but inactive, reactivate
            if (existingEnrollment.Status != EnrollmentStatus.Active)
            {
                existingEnrollment.Status = EnrollmentStatus.Active;
                existingEnrollment.UpdateDate = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
            return true;
        }

        // Create new enrollment
        var enrollment = new CourseEnrollment
        {
            CustomerId = customerId,
            CourseId = courseId,
            OrderId = orderId,
            Status = EnrollmentStatus.Active,
            EnrolledAt = DateTime.UtcNow,
            IsLifetimeAccess = true, // Default to lifetime access
            CreateDate = DateTime.UtcNow,
            UpdateDate = DateTime.UtcNow
        };

        _context.CourseEnrollments.Add(enrollment);
        await _context.SaveChangesAsync();
        return true;
    }
}

