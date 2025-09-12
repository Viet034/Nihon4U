namespace Nihon4U.Models.DTO.EntitiesDTO;

public class CartItemDTO
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public string Status { get; set; }
    public int CourseDetailId { get; set; }
    public int CartId { get; set; }
}
