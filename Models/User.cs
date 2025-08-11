namespace Nihon4U.Models;

public class User
{
    public int Id { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public string Status { get; set; }
    public string RefreshToken { get; set; }
    public string RefreshTokenExpriedTime { get; set; }
    public string ResetPasswordToken { get; set; }
    public string ResetPasswordTokenExpiredTime { get; set; }
    public virtual ICollection<User_Role> User_Roles { get; set; } = new List<User_Role>();
    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

}
