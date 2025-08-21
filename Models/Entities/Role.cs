namespace Nihon4U.Models.Entities;

public class Role : BaseEntity
{
    public string Status { get; set; }
    public virtual ICollection<User_Role> User_Roles { get; set; } = new List<User_Role>();

}
