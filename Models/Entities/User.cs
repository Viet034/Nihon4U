namespace Nihon4U.Models.Entities;

public class User 
{
    public int Id { get; set; }
    public string Email { get; set; }   
    public string PasswordHash { get; set; } 
    public string Role { get; set; } 
    public string RefreshToken { get; set; } 
    public string RefreshTokenExpriedTime { get; set; } 
    public string ResetPasswordToken { get; set; } 
    public string ResetPasswordTokenExpiredTime { get; set; } 
    public virtual ICollection<User_Role> User_Roles { get; set; } = new List<User_Role>(); 
    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>(); 
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>(); 
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>(); 
}
