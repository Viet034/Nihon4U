namespace Nihon4U.Models.Entities;

public class Course : BaseEntity
{
    public string Status { get; set; }  
    public string? Description { get; set; } 
    public string? Level { get; set; } // N5-N1
    public bool IsCombo { get; set; } // True if combo course
    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>(); 
    public virtual ICollection<CourseComboItem> ComboItems { get; set; } = new List<CourseComboItem>(); 
    public virtual ICollection<CourseComboItem> IncludedInCombos { get; set; } = new List<CourseComboItem>(); 
    public virtual ICollection<Test> Tests { get; set; } = new List<Test>(); 
    public virtual ICollection<CourseEnrollment> Enrollments { get; set; } = new List<CourseEnrollment>(); 
}
