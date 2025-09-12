using Nihon4U.Models.DTO.EntitiesDTO;
using Nihon4U.Models.DTO.ResponseDTO;

namespace Nihon4U.Services.Interfaces;

public interface ICartService
{
    Task<CartResponseDTO?> GetCartByCustomerIdAsync(int customerId);
    Task<CartResponseDTO> CreateCartAsync(int customerId);
    Task<CartItemResponseDTO> AddItemToCartAsync(int customerId, int courseId, int quantity = 1);
    Task<CartItemResponseDTO?> UpdateCartItemQuantityAsync(int cartItemId, int quantity);
    Task<bool> RemoveItemFromCartAsync(int cartItemId);
    Task<bool> ClearCartAsync(int customerId);
    Task<decimal> GetCartTotalAsync(int customerId);
    Task<int> GetCartItemCountAsync(int customerId);
    Task<bool> CheckItemInCartAsync(int customerId, int courseId);
    Task<CartResponseDTO?> GetCartWithItemsAsync(int customerId);
}
