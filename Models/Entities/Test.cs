using Nihon4U.Models.Enums;

namespace Nihon4U.Models.Entities;

public class Test : BaseEntity
{
    public TestStatus Status { get; set; } 
    public int CourseId { get; set; } 
    public bool IsFinal { get; set; }
    public double PassPercentage { get; set; } // pass percentage
    public virtual Course Course { get; set; } 
    public virtual ICollection<Question> Questions { get; set; } = new List<Question>(); 
}
