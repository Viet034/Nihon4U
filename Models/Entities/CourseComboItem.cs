namespace Nihon4U.Models.Entities;

public class CourseComboItem : BaseEntity
{
    public int ComboCourseId { get; set; } 
    public int IncludedCourseId { get; set; } 
    public virtual Course ComboCourse { get; set; } 
    public virtual Course IncludedCourse { get; set; } 
}


