namespace Nihon4U.Models.DTO.EntitiesDTO;

public class EmployeeDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public string CreateBy { get; set; }
    public string UpdateBy { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string Gender { get; set; }
    public string? ImageURL { get; set; }
    public string Status { get; set; }
    public int UserId { get; set; }
}
