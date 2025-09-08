using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nihon4U.Data;
using Nihon4U.Models.DTO.EntitiesDTO;
using Nihon4U.Models.DTO.ResponseDTO;
using Nihon4U.Models.Entities;
using Nihon4U.Models.Enums;
using Nihon4U.Services.Interfaces;

namespace Nihon4U.Services;

public class CourseService : ICourseService
{
    private readonly MyDbContext _context;
    private readonly IMapper _mapper;

    public CourseService(MyDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CourseResponseDTO>> GetAllCoursesAsync()
    {
        var courses = await _context.Courses
            .Include(c => c.Lessons)
            .Include(c => c.Tests)
            .Include(c => c.Enrollments)
            .ToListAsync();

        return _mapper.Map<IEnumerable<CourseResponseDTO>>(courses);
    }

    public async Task<CourseResponseDTO?> GetCourseByIdAsync(int id)
    {
        var course = await _context.Courses
            .Include(c => c.Lessons)
            .Include(c => c.Tests)
            .Include(c => c.Enrollments)
            .Include(c => c.CourseComboItems)
            .FirstOrDefaultAsync(c => c.Id == id);

        return course != null ? _mapper.Map<CourseResponseDTO>(course) : null;
    }

    public async Task<IEnumerable<CourseResponseDTO>> GetCoursesByStatusAsync(CourseStatus status)
    {
        var courses = await _context.Courses
            .Include(c => c.Lessons)
            .Include(c => c.Tests)
            .Where(c => c.Status == status)
            .ToListAsync();

        return _mapper.Map<IEnumerable<CourseResponseDTO>>(courses);
    }

    public async Task<IEnumerable<CourseResponseDTO>> GetCoursesByLevelAsync(string level)
    {
        var courses = await _context.Courses
            .Include(c => c.Lessons)
            .Include(c => c.Tests)
            .Where(c => c.Level == level)
            .ToListAsync();

        return _mapper.Map<IEnumerable<CourseResponseDTO>>(courses);
    }

    public async Task<IEnumerable<CourseResponseDTO>> GetComboCoursesAsync()
    {
        var courses = await _context.Courses
            .Include(c => c.Lessons)
            .Include(c => c.CourseComboItems)
            .Where(c => c.IsCombo)
            .ToListAsync();

        return _mapper.Map<IEnumerable<CourseResponseDTO>>(courses);
    }

    public async Task<CourseResponseDTO> CreateCourseAsync(CourseDTO courseDto)
    {
        var course = _mapper.Map<Course>(courseDto);
        course.CreateDate = DateTime.UtcNow;
        course.UpdateDate = DateTime.UtcNow;

        _context.Courses.Add(course);
        await _context.SaveChangesAsync();

        return _mapper.Map<CourseResponseDTO>(course);
    }

    public async Task<CourseResponseDTO?> UpdateCourseAsync(int id, CourseDTO courseDto)
    {
        var course = await _context.Courses.FindAsync(id);
        if (course == null) return null;

        _mapper.Map(courseDto, course);
        course.UpdateDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return _mapper.Map<CourseResponseDTO>(course);
    }

    public async Task<bool> DeleteCourseAsync(int id)
    {
        var course = await _context.Courses.FindAsync(id);
        if (course == null) return false;

        _context.Courses.Remove(course);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ChangeCourseStatusAsync(int id, CourseStatus status)
    {
        var course = await _context.Courses.FindAsync(id);
        if (course == null) return false;

        course.Status = status;
        course.UpdateDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<CourseResponseDTO>> SearchCoursesAsync(string keyword)
    {
        var courses = await _context.Courses
            .Include(c => c.Lessons)
            .Include(c => c.Tests)
            .Where(c => c.Name.Contains(keyword) || 
                       c.Description!.Contains(keyword) ||
                       c.Level!.Contains(keyword))
            .ToListAsync();

        return _mapper.Map<IEnumerable<CourseResponseDTO>>(courses);
    }

    public async Task<IEnumerable<CourseResponseDTO>> GetCoursesByCustomerIdAsync(int customerId)
    {
        var enrollments = await _context.CourseEnrollments
            .Include(ce => ce.Course)
            .ThenInclude(c => c.Lessons)
            .Where(ce => ce.CustomerId == customerId && ce.Status == EnrollmentStatus.Active)
            .Select(ce => ce.Course)
            .ToListAsync();

        return _mapper.Map<IEnumerable<CourseResponseDTO>>(enrollments);
    }
}
