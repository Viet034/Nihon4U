using Microsoft.AspNetCore.Mvc;
using Nihon4U.Models.DTO.EntitiesDTO;
using Nihon4U.Models.DTO.ResponseDTO;
using Nihon4U.Models.Enums;
using Nihon4U.Services.Interfaces;

namespace Nihon4U.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoursesController : ControllerBase
{
    private readonly ICourseService _courseService;

    public CoursesController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    /// <summary>
    /// Get all courses
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CourseResponseDTO>>> GetAllCourses()
    {
        var courses = await _courseService.GetAllCoursesAsync();
        return Ok(courses);
    }

    /// <summary>
    /// Get course by ID
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<CourseResponseDTO>> GetCourseById(int id)
    {
        var course = await _courseService.GetCourseByIdAsync(id);
        if (course == null)
            return NotFound($"Course with ID {id} not found");

        return Ok(course);
    }

    /// <summary>
    /// Get courses by status
    /// </summary>
    [HttpGet("status/{status}")]
    public async Task<ActionResult<IEnumerable<CourseResponseDTO>>> GetCoursesByStatus(CourseStatus status)
    {
        var courses = await _courseService.GetCoursesByStatusAsync(status);
        return Ok(courses);
    }

    /// <summary>
    /// Get courses by level (N5, N4, N3, N2, N1)
    /// </summary>
    [HttpGet("level/{level}")]
    public async Task<ActionResult<IEnumerable<CourseResponseDTO>>> GetCoursesByLevel(string level)
    {
        var courses = await _courseService.GetCoursesByLevelAsync(level);
        return Ok(courses);
    }

    /// <summary>
    /// Get combo courses
    /// </summary>
    [HttpGet("combo")]
    public async Task<ActionResult<IEnumerable<CourseResponseDTO>>> GetComboCourses()
    {
        var courses = await _courseService.GetComboCoursesAsync();
        return Ok(courses);
    }

    /// <summary>
    /// Search courses by keyword
    /// </summary>
    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<CourseResponseDTO>>> SearchCourses([FromQuery] string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword))
            return BadRequest("Keyword is required");

        var courses = await _courseService.SearchCoursesAsync(keyword);
        return Ok(courses);
    }

    /// <summary>
    /// Get courses enrolled by customer
    /// </summary>
    [HttpGet("customer/{customerId}")]
    public async Task<ActionResult<IEnumerable<CourseResponseDTO>>> GetCoursesByCustomerId(int customerId)
    {
        var courses = await _courseService.GetCoursesByCustomerIdAsync(customerId);
        return Ok(courses);
    }

    /// <summary>
    /// Create new course
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<CourseResponseDTO>> CreateCourse([FromBody] CourseDTO courseDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var course = await _courseService.CreateCourseAsync(courseDto);
        return CreatedAtAction(nameof(GetCourseById), new { id = course.Id }, course);
    }

    /// <summary>
    /// Update course
    /// </summary>
    [HttpPut("{id}")]
    public async Task<ActionResult<CourseResponseDTO>> UpdateCourse(int id, [FromBody] CourseDTO courseDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var course = await _courseService.UpdateCourseAsync(id, courseDto);
        if (course == null)
            return NotFound($"Course with ID {id} not found");

        return Ok(course);
    }

    /// <summary>
    /// Delete course
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCourse(int id)
    {
        var result = await _courseService.DeleteCourseAsync(id);
        if (!result)
            return NotFound($"Course with ID {id} not found");

        return NoContent();
    }

    /// <summary>
    /// Change course status
    /// </summary>
    [HttpPatch("{id}/status")]
    public async Task<ActionResult> ChangeCourseStatus(int id, [FromBody] CourseStatus status)
    {
        var result = await _courseService.ChangeCourseStatusAsync(id, status);
        if (!result)
            return NotFound($"Course with ID {id} not found");

        return Ok(new { message = "Course status updated successfully" });
    }
}

