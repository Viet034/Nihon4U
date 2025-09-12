using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nihon4U.Data;
using Nihon4U.Models.DTO.EntitiesDTO;
using Nihon4U.Models.DTO.ResponseDTO;
using Nihon4U.Models.Entities;
using Nihon4U.Models.Enums;
using Nihon4U.Services.Interfaces;

namespace Nihon4U.Services;

public class LessonService : ILessonService
{
    private readonly MyDbContext _context;
    private readonly IMapper _mapper;

    public LessonService(MyDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<LessonResponseDTO>> GetAllLessonsAsync()
    {
        var lessons = await _context.Lessons
            .Include(l => l.Course)
            .Include(l => l.Materials)
            .Include(l => l.Quizzes)
            .Include(l => l.Flashcards)
            .ToListAsync();

        return _mapper.Map<IEnumerable<LessonResponseDTO>>(lessons);
    }

    public async Task<LessonResponseDTO?> GetLessonByIdAsync(int id)
    {
        var lesson = await _context.Lessons
            .Include(l => l.Course)
            .Include(l => l.Materials)
            .Include(l => l.Quizzes)
            .Include(l => l.Flashcards)
            .FirstOrDefaultAsync(l => l.Id == id);

        return lesson != null ? _mapper.Map<LessonResponseDTO>(lesson) : null;
    }

    public async Task<IEnumerable<LessonResponseDTO>> GetLessonsByCourseIdAsync(int courseId)
    {
        var lessons = await _context.Lessons
            .Include(l => l.Course)
            .Include(l => l.Materials)
            .Include(l => l.Quizzes)
            .Include(l => l.Flashcards)
            .Where(l => l.CourseId == courseId)
            .OrderBy(l => l.OrderIndex)
            .ToListAsync();

        return _mapper.Map<IEnumerable<LessonResponseDTO>>(lessons);
    }

    public async Task<IEnumerable<LessonResponseDTO>> GetLessonsByStatusAsync(LessonStatus status)
    {
        var lessons = await _context.Lessons
            .Include(l => l.Course)
            .Include(l => l.Materials)
            .Include(l => l.Quizzes)
            .Include(l => l.Flashcards)
            .Where(l => l.Status == status)
            .ToListAsync();

        return _mapper.Map<IEnumerable<LessonResponseDTO>>(lessons);
    }

    public async Task<LessonResponseDTO> CreateLessonAsync(LessonDTO lessonDto)
    {
        var lesson = _mapper.Map<Lesson>(lessonDto);
        lesson.CreateDate = DateTime.UtcNow;
        lesson.UpdateDate = DateTime.UtcNow;
        lesson.Status = LessonStatus.Draft;

        // Set order index if not provided
        if (lesson.OrderIndex == 0)
        {
            var maxOrder = await _context.Lessons
                .Where(l => l.CourseId == lesson.CourseId)
                .MaxAsync(l => (int?)l.OrderIndex) ?? 0;
            lesson.OrderIndex = maxOrder + 1;
        }

        _context.Lessons.Add(lesson);
        await _context.SaveChangesAsync();

        return _mapper.Map<LessonResponseDTO>(lesson);
    }

    public async Task<LessonResponseDTO?> UpdateLessonAsync(int id, LessonDTO lessonDto)
    {
        var lesson = await _context.Lessons.FindAsync(id);
        if (lesson == null) return null;

        _mapper.Map(lessonDto, lesson);
        lesson.UpdateDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return _mapper.Map<LessonResponseDTO>(lesson);
    }

    public async Task<bool> DeleteLessonAsync(int id)
    {
        var lesson = await _context.Lessons.FindAsync(id);
        if (lesson == null) return false;

        _context.Lessons.Remove(lesson);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ChangeLessonStatusAsync(int id, LessonStatus status)
    {
        var lesson = await _context.Lessons.FindAsync(id);
        if (lesson == null) return false;

        lesson.Status = status;
        lesson.UpdateDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<LessonResponseDTO>> GetLessonsByOrderIndexAsync(int courseId)
    {
        var lessons = await _context.Lessons
            .Include(l => l.Course)
            .Include(l => l.Materials)
            .Include(l => l.Quizzes)
            .Include(l => l.Flashcards)
            .Where(l => l.CourseId == courseId)
            .OrderBy(l => l.OrderIndex)
            .ToListAsync();

        return _mapper.Map<IEnumerable<LessonResponseDTO>>(lessons);
    }

    public async Task<LessonResponseDTO?> GetNextLessonAsync(int currentLessonId)
    {
        var currentLesson = await _context.Lessons.FindAsync(currentLessonId);
        if (currentLesson == null) return null;

        var nextLesson = await _context.Lessons
            .Include(l => l.Course)
            .Include(l => l.Materials)
            .Include(l => l.Quizzes)
            .Include(l => l.Flashcards)
            .Where(l => l.CourseId == currentLesson.CourseId && 
                       l.OrderIndex > currentLesson.OrderIndex &&
                       l.Status == LessonStatus.Published)
            .OrderBy(l => l.OrderIndex)
            .FirstOrDefaultAsync();

        return nextLesson != null ? _mapper.Map<LessonResponseDTO>(nextLesson) : null;
    }

    public async Task<LessonResponseDTO?> GetPreviousLessonAsync(int currentLessonId)
    {
        var currentLesson = await _context.Lessons.FindAsync(currentLessonId);
        if (currentLesson == null) return null;

        var previousLesson = await _context.Lessons
            .Include(l => l.Course)
            .Include(l => l.Materials)
            .Include(l => l.Quizzes)
            .Include(l => l.Flashcards)
            .Where(l => l.CourseId == currentLesson.CourseId && 
                       l.OrderIndex < currentLesson.OrderIndex &&
                       l.Status == LessonStatus.Published)
            .OrderByDescending(l => l.OrderIndex)
            .FirstOrDefaultAsync();

        return previousLesson != null ? _mapper.Map<LessonResponseDTO>(previousLesson) : null;
    }

    public async Task<bool> UpdateLessonOrderAsync(int lessonId, int newOrderIndex)
    {
        var lesson = await _context.Lessons.FindAsync(lessonId);
        if (lesson == null) return false;

        var courseId = lesson.CourseId;
        var oldOrderIndex = lesson.OrderIndex;

        // Update other lessons' order indices
        if (newOrderIndex > oldOrderIndex)
        {
            var lessonsToUpdate = await _context.Lessons
                .Where(l => l.CourseId == courseId && 
                           l.OrderIndex > oldOrderIndex && 
                           l.OrderIndex <= newOrderIndex)
                .ToListAsync();

            foreach (var l in lessonsToUpdate)
            {
                l.OrderIndex--;
            }
        }
        else if (newOrderIndex < oldOrderIndex)
        {
            var lessonsToUpdate = await _context.Lessons
                .Where(l => l.CourseId == courseId && 
                           l.OrderIndex >= newOrderIndex && 
                           l.OrderIndex < oldOrderIndex)
                .ToListAsync();

            foreach (var l in lessonsToUpdate)
            {
                l.OrderIndex++;
            }
        }

        lesson.OrderIndex = newOrderIndex;
        lesson.UpdateDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<LessonResponseDTO>> GetFreePreviewLessonsAsync(int courseId)
    {
        var lessons = await _context.Lessons
            .Include(l => l.Course)
            .Include(l => l.Materials)
            .Include(l => l.Quizzes)
            .Include(l => l.Flashcards)
            .Where(l => l.CourseId == courseId && 
                       l.IsFreePreview && 
                       l.Status == LessonStatus.Published)
            .OrderBy(l => l.OrderIndex)
            .ToListAsync();

        return _mapper.Map<IEnumerable<LessonResponseDTO>>(lessons);
    }
}
