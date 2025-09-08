namespace Nihon4U.Models.Entities;

public class FavouriteCourse : BaseEntity
{
    public string Status { get; set; } 
    public int CustomerId { get; set; } 
    public int CourseId { get; set; } 
   
    public virtual Customer Customer { get; set; } 
    public virtual Course Course { get; set; } 
}
