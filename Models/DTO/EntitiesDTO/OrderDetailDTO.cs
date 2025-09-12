namespace Nihon4U.Models.DTO.EntitiesDTO;

public class OrderDetailDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }

    public string Status { get; set; }
    public int OrderId { get; set; }
    public int CourseId { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public string CreateBy { get; set; }
    public string UpdateBy { get; set; }
}
