using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nihon4U.Data;
using Nihon4U.Models.DTO.EntitiesDTO;
using Nihon4U.Models.DTO.ResponseDTO;
using Nihon4U.Models.Entities;
using Nihon4U.Services.Interfaces;

namespace Nihon4U.Services;

public class CartService : ICartService
{
    private readonly MyDbContext _context;
    private readonly IMapper _mapper;

    public CartService(MyDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CartResponseDTO?> GetCartByCustomerIdAsync(int customerId)
    {
        var cart = await _context.Carts
            .Include(c => c.CartItems)
            .ThenInclude(ci => ci.Course)
            .FirstOrDefaultAsync(c => c.CustomerId == customerId);

        return cart != null ? _mapper.Map<CartResponseDTO>(cart) : null;
    }

    public async Task<CartResponseDTO> CreateCartAsync(int customerId)
    {
        var cart = new Cart
        {
            CustomerId = customerId,
            CreateDate = DateTime.UtcNow,
            UpdateDate = DateTime.UtcNow
        };

        _context.Carts.Add(cart);
        await _context.SaveChangesAsync();

        return _mapper.Map<CartResponseDTO>(cart);
    }

    public async Task<CartItemResponseDTO> AddItemToCartAsync(int customerId, int courseId, int quantity = 1)
    {
        // Get or create cart
        var cart = await _context.Carts
            .Include(c => c.CartItems)
            .FirstOrDefaultAsync(c => c.CustomerId == customerId);

        if (cart == null)
        {
            cart = new Cart
            {
                CustomerId = customerId,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow
            };
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();
        }

        // Check if item already exists in cart
        var existingItem = cart.CartItems.FirstOrDefault(ci => ci.CourseId == courseId);
        if (existingItem != null)
        {
            existingItem.Quantity += quantity;
            existingItem.UpdateDate = DateTime.UtcNow;
        }
        else
        {
            var cartItem = new CartItem
            {
                CartId = cart.Id,
                CourseId = courseId,
                Quantity = quantity,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow
            };
            _context.CartItems.Add(cartItem);
        }

        cart.UpdateDate = DateTime.UtcNow;
        await _context.SaveChangesAsync();

        var updatedItem = await _context.CartItems
            .Include(ci => ci.Course)
            .FirstOrDefaultAsync(ci => ci.CartId == cart.Id && ci.CourseId == courseId);

        return _mapper.Map<CartItemResponseDTO>(updatedItem!);
    }

    public async Task<CartItemResponseDTO?> UpdateCartItemQuantityAsync(int cartItemId, int quantity)
    {
        var cartItem = await _context.CartItems
            .Include(ci => ci.Course)
            .FirstOrDefaultAsync(ci => ci.Id == cartItemId);

        if (cartItem == null) return null;

        cartItem.Quantity = quantity;
        cartItem.UpdateDate = DateTime.UtcNow;

        // Update cart timestamp
        var cart = await _context.Carts.FindAsync(cartItem.CartId);
        if (cart != null)
        {
            cart.UpdateDate = DateTime.UtcNow;
        }

        await _context.SaveChangesAsync();
        return _mapper.Map<CartItemResponseDTO>(cartItem);
    }

    public async Task<bool> RemoveItemFromCartAsync(int cartItemId)
    {
        var cartItem = await _context.CartItems.FindAsync(cartItemId);
        if (cartItem == null) return false;

        _context.CartItems.Remove(cartItem);

        // Update cart timestamp
        var cart = await _context.Carts.FindAsync(cartItem.CartId);
        if (cart != null)
        {
            cart.UpdateDate = DateTime.UtcNow;
        }

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ClearCartAsync(int customerId)
    {
        var cart = await _context.Carts
            .Include(c => c.CartItems)
            .FirstOrDefaultAsync(c => c.CustomerId == customerId);

        if (cart == null) return false;

        _context.CartItems.RemoveRange(cart.CartItems);
        cart.UpdateDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<decimal> GetCartTotalAsync(int customerId)
    {
        var cart = await _context.Carts
            .Include(c => c.CartItems)
            .ThenInclude(ci => ci.Course)
            .FirstOrDefaultAsync(c => c.CustomerId == customerId);

        if (cart == null) return 0;

        return cart.CartItems.Sum(ci => ci.Quantity * (ci.Course?.Price ?? 0));
    }

    public async Task<int> GetCartItemCountAsync(int customerId)
    {
        var cart = await _context.Carts
            .Include(c => c.CartItems)
            .FirstOrDefaultAsync(c => c.CustomerId == customerId);

        return cart?.CartItems.Sum(ci => ci.Quantity) ?? 0;
    }

    public async Task<bool> CheckItemInCartAsync(int customerId, int courseId)
    {
        var cart = await _context.Carts
            .Include(c => c.CartItems)
            .FirstOrDefaultAsync(c => c.CustomerId == customerId);

        return cart?.CartItems.Any(ci => ci.CourseId == courseId) ?? false;
    }

    public async Task<CartResponseDTO?> GetCartWithItemsAsync(int customerId)
    {
        var cart = await _context.Carts
            .Include(c => c.CartItems)
            .ThenInclude(ci => ci.Course)
            .FirstOrDefaultAsync(c => c.CustomerId == customerId);

        return cart != null ? _mapper.Map<CartResponseDTO>(cart) : null;
    }
}

