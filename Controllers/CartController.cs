using Microsoft.AspNetCore.Mvc;
using Nihon4U.Models.DTO.EntitiesDTO;
using Nihon4U.Models.DTO.ResponseDTO;
using Nihon4U.Services.Interfaces;

namespace Nihon4U.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CartController : ControllerBase
{
    private readonly ICartService _cartService;

    public CartController(ICartService cartService)
    {
        _cartService = cartService;
    }

    /// <summary>
    /// Get cart by customer ID
    /// </summary>
    [HttpGet("customer/{customerId}")]
    public async Task<ActionResult<CartResponseDTO>> GetCartByCustomerId(int customerId)
    {
        var cart = await _cartService.GetCartByCustomerIdAsync(customerId);
        if (cart == null)
            return NotFound($"Cart for customer ID {customerId} not found");

        return Ok(cart);
    }

    /// <summary>
    /// Get cart with items by customer ID
    /// </summary>
    [HttpGet("customer/{customerId}/items")]
    public async Task<ActionResult<CartResponseDTO>> GetCartWithItems(int customerId)
    {
        var cart = await _cartService.GetCartWithItemsAsync(customerId);
        if (cart == null)
            return NotFound($"Cart for customer ID {customerId} not found");

        return Ok(cart);
    }

    /// <summary>
    /// Create new cart for customer
    /// </summary>
    [HttpPost("customer/{customerId}")]
    public async Task<ActionResult<CartResponseDTO>> CreateCart(int customerId)
    {
        var cart = await _cartService.CreateCartAsync(customerId);
        return CreatedAtAction(nameof(GetCartByCustomerId), new { customerId }, cart);
    }

    /// <summary>
    /// Add item to cart
    /// </summary>
    [HttpPost("customer/{customerId}/items")]
    public async Task<ActionResult<CartItemResponseDTO>> AddItemToCart(int customerId, [FromBody] AddToCartRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var cartItem = await _cartService.AddItemToCartAsync(customerId, request.CourseId, request.Quantity);
        return Ok(cartItem);
    }

    /// <summary>
    /// Update cart item quantity
    /// </summary>
    [HttpPut("items/{cartItemId}")]
    public async Task<ActionResult<CartItemResponseDTO>> UpdateCartItemQuantity(int cartItemId, [FromBody] UpdateQuantityRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var cartItem = await _cartService.UpdateCartItemQuantityAsync(cartItemId, request.Quantity);
        if (cartItem == null)
            return NotFound($"Cart item with ID {cartItemId} not found");

        return Ok(cartItem);
    }

    /// <summary>
    /// Remove item from cart
    /// </summary>
    [HttpDelete("items/{cartItemId}")]
    public async Task<ActionResult> RemoveItemFromCart(int cartItemId)
    {
        var result = await _cartService.RemoveItemFromCartAsync(cartItemId);
        if (!result)
            return NotFound($"Cart item with ID {cartItemId} not found");

        return NoContent();
    }

    /// <summary>
    /// Clear cart
    /// </summary>
    [HttpDelete("customer/{customerId}")]
    public async Task<ActionResult> ClearCart(int customerId)
    {
        var result = await _cartService.ClearCartAsync(customerId);
        if (!result)
            return NotFound($"Cart for customer ID {customerId} not found");

        return NoContent();
    }

    /// <summary>
    /// Get cart total
    /// </summary>
    [HttpGet("customer/{customerId}/total")]
    public async Task<ActionResult<decimal>> GetCartTotal(int customerId)
    {
        var total = await _cartService.GetCartTotalAsync(customerId);
        return Ok(new { total });
    }

    /// <summary>
    /// Get cart item count
    /// </summary>
    [HttpGet("customer/{customerId}/count")]
    public async Task<ActionResult<int>> GetCartItemCount(int customerId)
    {
        var count = await _cartService.GetCartItemCountAsync(customerId);
        return Ok(new { count });
    }

    /// <summary>
    /// Check if item is in cart
    /// </summary>
    [HttpGet("customer/{customerId}/check")]
    public async Task<ActionResult<bool>> CheckItemInCart(int customerId, [FromQuery] int courseId)
    {
        var isInCart = await _cartService.CheckItemInCartAsync(customerId, courseId);
        return Ok(new { isInCart });
    }
}

public class AddToCartRequest
{
    public int CourseId { get; set; }
    public int Quantity { get; set; } = 1;
}

public class UpdateQuantityRequest
{
    public int Quantity { get; set; }
}

