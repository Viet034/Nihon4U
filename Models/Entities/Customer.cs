using Nihon4U.Models.Enums;

namespace Nihon4U.Models.Entities;

public class Customer : BaseEntity
{
    public string Phone { get; set; }
    public string Address { get; set; }
    public string Gender { get; set; }
    public string? ImageURL { get; set; }
    public CustomerStatus Status { get; set; }
    public int UserId { get; set; }
    public virtual User User { get; set; }
    public virtual ICollection<Customer_Certificate> Customer_Certificates { get; set; } = new List<Customer_Certificate>();
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    public virtual ICollection<CourseEnrollment> CourseEnrollments { get; set; } = new List<CourseEnrollment>();
}
