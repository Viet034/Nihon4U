using Microsoft.AspNetCore.Mvc;
using Nihon4U.Models.DTO.EntitiesDTO;
using Nihon4U.Models.DTO.ResponseDTO;
using Nihon4U.Models.Enums;
using Nihon4U.Services.Interfaces;

namespace Nihon4U.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourseEnrollmentsController : ControllerBase
{
    private readonly ICourseEnrollmentService _enrollmentService;

    public CourseEnrollmentsController(ICourseEnrollmentService enrollmentService)
    {
        _enrollmentService = enrollmentService;
    }

    /// <summary>
    /// Get all enrollments
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CourseEnrollmentResponseDTO>>> GetAllEnrollments()
    {
        var enrollments = await _enrollmentService.GetAllEnrollmentsAsync();
        return Ok(enrollments);
    }

    /// <summary>
    /// Get enrollment by ID
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<CourseEnrollmentResponseDTO>> GetEnrollmentById(int id)
    {
        var enrollment = await _enrollmentService.GetEnrollmentByIdAsync(id);
        if (enrollment == null)
            return NotFound($"Enrollment with ID {id} not found");

        return Ok(enrollment);
    }

    /// <summary>
    /// Get enrollments by customer ID
    /// </summary>
    [HttpGet("customer/{customerId}")]
    public async Task<ActionResult<IEnumerable<CourseEnrollmentResponseDTO>>> GetEnrollmentsByCustomerId(int customerId)
    {
        var enrollments = await _enrollmentService.GetEnrollmentsByCustomerIdAsync(customerId);
        return Ok(enrollments);
    }

    /// <summary>
    /// Get active enrollments by customer ID
    /// </summary>
    [HttpGet("customer/{customerId}/active")]
    public async Task<ActionResult<IEnumerable<CourseEnrollmentResponseDTO>>> GetActiveEnrollmentsByCustomerId(int customerId)
    {
        var enrollments = await _enrollmentService.GetActiveEnrollmentsByCustomerIdAsync(customerId);
        return Ok(enrollments);
    }

    /// <summary>
    /// Get enrollments by course ID
    /// </summary>
    [HttpGet("course/{courseId}")]
    public async Task<ActionResult<IEnumerable<CourseEnrollmentResponseDTO>>> GetEnrollmentsByCourseId(int courseId)
    {
        var enrollments = await _enrollmentService.GetEnrollmentsByCourseIdAsync(courseId);
        return Ok(enrollments);
    }

    /// <summary>
    /// Get enrollments by status
    /// </summary>
    [HttpGet("status/{status}")]
    public async Task<ActionResult<IEnumerable<CourseEnrollmentResponseDTO>>> GetEnrollmentsByStatus(EnrollmentStatus status)
    {
        var enrollments = await _enrollmentService.GetEnrollmentsByStatusAsync(status);
        return Ok(enrollments);
    }

    /// <summary>
    /// Check if customer is enrolled in course
    /// </summary>
    [HttpGet("check")]
    public async Task<ActionResult<bool>> CheckCustomerEnrolled([FromQuery] int customerId, [FromQuery] int courseId)
    {
        var isEnrolled = await _enrollmentService.CheckCustomerEnrolledAsync(customerId, courseId);
        return Ok(new { isEnrolled });
    }

    /// <summary>
    /// Create new enrollment
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<CourseEnrollmentResponseDTO>> CreateEnrollment([FromBody] CourseEnrollmentDTO enrollmentDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var enrollment = await _enrollmentService.CreateEnrollmentAsync(enrollmentDto);
        return CreatedAtAction(nameof(GetEnrollmentById), new { id = enrollment.Id }, enrollment);
    }

    /// <summary>
    /// Enroll customer to course
    /// </summary>
    [HttpPost("enroll")]
    public async Task<ActionResult> EnrollCustomerToCourse([FromBody] EnrollRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _enrollmentService.EnrollCustomerToCourseAsync(request.CustomerId, request.CourseId, request.OrderId);
        if (!result)
            return BadRequest("Failed to enroll customer to course");

        return Ok(new { message = "Customer enrolled successfully" });
    }

    /// <summary>
    /// Update enrollment
    /// </summary>
    [HttpPut("{id}")]
    public async Task<ActionResult<CourseEnrollmentResponseDTO>> UpdateEnrollment(int id, [FromBody] CourseEnrollmentDTO enrollmentDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var enrollment = await _enrollmentService.UpdateEnrollmentAsync(id, enrollmentDto);
        if (enrollment == null)
            return NotFound($"Enrollment with ID {id} not found");

        return Ok(enrollment);
    }

    /// <summary>
    /// Delete enrollment
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteEnrollment(int id)
    {
        var result = await _enrollmentService.DeleteEnrollmentAsync(id);
        if (!result)
            return NotFound($"Enrollment with ID {id} not found");

        return NoContent();
    }

    /// <summary>
    /// Change enrollment status
    /// </summary>
    [HttpPatch("{id}/status")]
    public async Task<ActionResult> ChangeEnrollmentStatus(int id, [FromBody] EnrollmentStatus status)
    {
        var result = await _enrollmentService.ChangeEnrollmentStatusAsync(id, status);
        if (!result)
            return NotFound($"Enrollment with ID {id} not found");

        return Ok(new { message = "Enrollment status updated successfully" });
    }
}

public class EnrollRequest
{
    public int CustomerId { get; set; }
    public int CourseId { get; set; }
    public int? OrderId { get; set; }
}
