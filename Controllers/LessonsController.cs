using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nihon4U.Models.DTO.EntitiesDTO;
using Nihon4U.Models.DTO.ResponseDTO;
using Nihon4U.Models.Enums;
using Nihon4U.Services.Interfaces;

namespace Nihon4U.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LessonsController : ControllerBase
{
    private readonly ILessonService _lessonService;

    public LessonsController(ILessonService lessonService)
    {
        _lessonService = lessonService;
    }

    /// <summary>
    /// Get all lessons
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<LessonResponseDTO>>> GetAllLessons()
    {
        var lessons = await _lessonService.GetAllLessonsAsync();
        return Ok(lessons);
    }

    /// <summary>
    /// Get lesson by ID
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<LessonResponseDTO>> GetLessonById(int id)
    {
        var lesson = await _lessonService.GetLessonByIdAsync(id);
        if (lesson == null)
            return NotFound($"Lesson with ID {id} not found");

        return Ok(lesson);
    }

    /// <summary>
    /// Get lessons by course ID
    /// </summary>
    [HttpGet("course/{courseId}")]
    public async Task<ActionResult<IEnumerable<LessonResponseDTO>>> GetLessonsByCourseId(int courseId)
    {
        var lessons = await _lessonService.GetLessonsByCourseIdAsync(courseId);
        return Ok(lessons);
    }

    /// <summary>
    /// Get lessons by status
    /// </summary>
    [HttpGet("status/{status}")]
    public async Task<ActionResult<IEnumerable<LessonResponseDTO>>> GetLessonsByStatus(LessonStatus status)
    {
        var lessons = await _lessonService.GetLessonsByStatusAsync(status);
        return Ok(lessons);
    }

    /// <summary>
    /// Get lessons by order index
    /// </summary>
    [HttpGet("course/{courseId}/ordered")]
    public async Task<ActionResult<IEnumerable<LessonResponseDTO>>> GetLessonsByOrderIndex(int courseId)
    {
        var lessons = await _lessonService.GetLessonsByOrderIndexAsync(courseId);
        return Ok(lessons);
    }

    /// <summary>
    /// Get free preview lessons for a course
    /// </summary>
    [HttpGet("course/{courseId}/preview")]
    public async Task<ActionResult<IEnumerable<LessonResponseDTO>>> GetFreePreviewLessons(int courseId)
    {
        var lessons = await _lessonService.GetFreePreviewLessonsAsync(courseId);
        return Ok(lessons);
    }

    /// <summary>
    /// Get next lesson
    /// </summary>
    [HttpGet("{id}/next")]
    public async Task<ActionResult<LessonResponseDTO>> GetNextLesson(int id)
    {
        var lesson = await _lessonService.GetNextLessonAsync(id);
        if (lesson == null)
            return NotFound("No next lesson found");

        return Ok(lesson);
    }

    /// <summary>
    /// Get previous lesson
    /// </summary>
    [HttpGet("{id}/previous")]
    public async Task<ActionResult<LessonResponseDTO>> GetPreviousLesson(int id)
    {
        var lesson = await _lessonService.GetPreviousLessonAsync(id);
        if (lesson == null)
            return NotFound("No previous lesson found");

        return Ok(lesson);
    }

    /// <summary>
    /// Create new lesson
    /// </summary>
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<LessonResponseDTO>> CreateLesson([FromBody] LessonDTO lessonDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var lesson = await _lessonService.CreateLessonAsync(lessonDto);
        return CreatedAtAction(nameof(GetLessonById), new { id = lesson.Id }, lesson);
    }

    /// <summary>
    /// Update lesson
    /// </summary>
    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<LessonResponseDTO>> UpdateLesson(int id, [FromBody] LessonDTO lessonDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var lesson = await _lessonService.UpdateLessonAsync(id, lessonDto);
        if (lesson == null)
            return NotFound($"Lesson with ID {id} not found");

        return Ok(lesson);
    }

    /// <summary>
    /// Delete lesson
    /// </summary>
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult> DeleteLesson(int id)
    {
        var result = await _lessonService.DeleteLessonAsync(id);
        if (!result)
            return NotFound($"Lesson with ID {id} not found");

        return NoContent();
    }

    /// <summary>
    /// Change lesson status
    /// </summary>
    [HttpPatch("{id}/status")]
    [Authorize]
    public async Task<ActionResult> ChangeLessonStatus(int id, [FromBody] LessonStatus status)
    {
        var result = await _lessonService.ChangeLessonStatusAsync(id, status);
        if (!result)
            return NotFound($"Lesson with ID {id} not found");

        return Ok(new { message = "Lesson status updated successfully" });
    }

    /// <summary>
    /// Update lesson order
    /// </summary>
    [HttpPatch("{id}/order")]
    [Authorize]
    public async Task<ActionResult> UpdateLessonOrder(int id, [FromBody] UpdateOrderRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _lessonService.UpdateLessonOrderAsync(id, request.NewOrderIndex);
        if (!result)
            return NotFound($"Lesson with ID {id} not found");

        return Ok(new { message = "Lesson order updated successfully" });
    }
}

public class UpdateOrderRequest
{
    public int NewOrderIndex { get; set; }
}
