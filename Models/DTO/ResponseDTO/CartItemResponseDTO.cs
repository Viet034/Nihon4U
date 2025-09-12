namespace Nihon4U.Models.DTO.ResponseDTO;

public class CartItemResponseDTO
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public string Status { get; set; }
    public int CourseDetailId { get; set; }
    public int CartId { get; set; }
}
