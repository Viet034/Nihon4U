using Nihon4U.Models.Enums;

namespace Nihon4U.Models.Entities;

public class Course : BaseEntity
{
    public CourseStatus Status { get; set; }  
    public string? Description { get; set; } 
    public string? Level { get; set; } // N5-N1
    public bool IsCombo { get; set; } // True if combo course
    public decimal Price { get; set; }
    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>(); 
    public virtual ICollection<CourseComboItem> CourseComboItems { get; set; } = new List<CourseComboItem>(); 
    public virtual ICollection<Test> Tests { get; set; } = new List<Test>(); 
    public virtual ICollection<CourseEnrollment> Enrollments { get; set; } = new List<CourseEnrollment>(); 
    public virtual ICollection<Order_Detail> Order_Details { get; set; } = new List<Order_Detail>(); 
}
