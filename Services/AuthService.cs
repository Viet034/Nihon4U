using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Nihon4U.Data;
using Nihon4U.Models.DTO.EntitiesDTO;
using Nihon4U.Models.DTO.RequestDTO.Auth;
using Nihon4U.Models.DTO.ResponseDTO;
using Nihon4U.Models.Entities;
using Nihon4U.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using BCrypt.Net;

namespace Nihon4U.Services;

public class AuthService : IAuthService
{
    private readonly MyDbContext _context;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    public AuthService(MyDbContext context, IMapper mapper, IConfiguration configuration)
    {
        _context = context;
        _mapper = mapper;
        _configuration = configuration;
    }

    public async Task<AuthResponseDTO?> LoginAsync(LoginRequestDTO loginRequest)
    {
        var user = await _context.Users
            .Include(u => u.Customers)
            .FirstOrDefaultAsync(u => u.Email == loginRequest.Email);

        if (user == null || !BCrypt.Net.BCrypt.Verify(loginRequest.Password, user.Password))
            return null;

        var token = GenerateJwtToken(user);
        var refreshToken = GenerateRefreshToken();

        // Save refresh token to database
        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
        await _context.SaveChangesAsync();

        return new AuthResponseDTO
        {
            AccessToken = token,
            RefreshToken = refreshToken,
            ExpiresAt = DateTime.UtcNow.AddHours(24),
            User = _mapper.Map<UserResponseDTO>(user),
            Success = true,
            Message = "Login successful"
        };
    }

    public async Task<AuthResponseDTO?> RegisterAsync(RegisterRequestDTO registerRequest)
    {
        // Check if user already exists
        if (await _context.Users.AnyAsync(u => u.Email == registerRequest.Email))
            return null;

        var user = new User
        {
            Email = registerRequest.Email,
            Password = BCrypt.Net.BCrypt.HashPassword(registerRequest.Password),
            FirstName = registerRequest.FirstName,
            LastName = registerRequest.LastName,
            Phone = registerRequest.Phone,
            DateOfBirth = registerRequest.DateOfBirth,
            Gender = registerRequest.Gender,
            CreateDate = DateTime.UtcNow,
            UpdateDate = DateTime.UtcNow
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        // Create customer profile
        var customer = new Customer
        {
            Name = $"{registerRequest.FirstName} {registerRequest.LastName}",
            Phone = registerRequest.Phone ?? "",
            Address = "",
            Gender = registerRequest.Gender ?? "",
            UserId = user.Id,
            Status = Models.Enums.CustomerStatus.Pending,
            CreateDate = DateTime.UtcNow,
            UpdateDate = DateTime.UtcNow
        };

        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();

        var token = GenerateJwtToken(user);
        var refreshToken = GenerateRefreshToken();

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
        await _context.SaveChangesAsync();

        return new AuthResponseDTO
        {
            AccessToken = token,
            RefreshToken = refreshToken,
            ExpiresAt = DateTime.UtcNow.AddHours(24),
            User = _mapper.Map<UserResponseDTO>(user),
            Success = true,
            Message = "Registration successful"
        };
    }

    public async Task<bool> LogoutAsync(string token)
    {
        var user = await GetUserFromTokenAsync(token);
        if (user == null) return false;

        user.RefreshToken = null;
        user.RefreshTokenExpiryTime = null;
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<AuthResponseDTO?> RefreshTokenAsync(string refreshToken)
    {
        var user = await _context.Users
            .Include(u => u.Customers)
            .FirstOrDefaultAsync(u => u.RefreshToken == refreshToken && 
                                     u.RefreshTokenExpiryTime > DateTime.UtcNow);

        if (user == null) return null;

        var newToken = GenerateJwtToken(user);
        var newRefreshToken = GenerateRefreshToken();

        user.RefreshToken = newRefreshToken;
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
        await _context.SaveChangesAsync();

        return new AuthResponseDTO
        {
            AccessToken = newToken,
            RefreshToken = newRefreshToken,
            ExpiresAt = DateTime.UtcNow.AddHours(24),
            User = _mapper.Map<UserResponseDTO>(user),
            Success = true,
            Message = "Token refreshed successfully"
        };
    }

    public async Task<bool> ChangePasswordAsync(int userId, ChangePasswordRequestDTO changePasswordRequest)
    {
        var user = await _context.Users.FindAsync(userId);
        if (user == null || !BCrypt.Net.BCrypt.Verify(changePasswordRequest.CurrentPassword, user.Password))
            return false;

        user.Password = BCrypt.Net.BCrypt.HashPassword(changePasswordRequest.NewPassword);
        user.UpdateDate = DateTime.UtcNow;
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> ForgotPasswordAsync(string email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        if (user == null) return false;

        // Generate reset token
        var resetToken = GenerateResetToken();
        user.ResetPasswordToken = resetToken;
        user.ResetPasswordExpiry = DateTime.UtcNow.AddHours(1);
        await _context.SaveChangesAsync();

        // TODO: Send email with reset token
        return true;
    }

    public async Task<bool> ResetPasswordAsync(ResetPasswordRequestDTO resetPasswordRequest)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => 
            u.Email == resetPasswordRequest.Email && 
            u.ResetPasswordToken == resetPasswordRequest.Token &&
            u.ResetPasswordExpiry > DateTime.UtcNow);

        if (user == null) return false;

        user.Password = BCrypt.Net.BCrypt.HashPassword(resetPasswordRequest.NewPassword);
        user.ResetPasswordToken = null;
        user.ResetPasswordExpiry = null;
        user.UpdateDate = DateTime.UtcNow;
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> VerifyEmailAsync(string token)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.EmailVerificationToken == token);
        if (user == null) return false;

        user.IsEmailVerified = true;
        user.EmailVerificationToken = null;
        user.UpdateDate = DateTime.UtcNow;
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<UserResponseDTO?> GetCurrentUserAsync(string token)
    {
        var user = await GetUserFromTokenAsync(token);
        return user != null ? _mapper.Map<UserResponseDTO>(user) : null;
    }

    public async Task<bool> UpdateProfileAsync(int userId, UpdateProfileRequestDTO updateProfileRequest)
    {
        var user = await _context.Users.FindAsync(userId);
        if (user == null) return false;

        _mapper.Map(updateProfileRequest, user);
        user.UpdateDate = DateTime.UtcNow;
        await _context.SaveChangesAsync();

        return true;
    }

    private string GenerateJwtToken(User user)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}")
        };

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(24),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    private string GenerateResetToken()
    {
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    private async Task<User?> GetUserFromTokenAsync(string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!);
            
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidIssuer = _configuration["Jwt:Issuer"],
                ValidateAudience = true,
                ValidAudience = _configuration["Jwt:Audience"],
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var userId = int.Parse(jwtToken.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);

            return await _context.Users.FindAsync(userId);
        }
        catch
        {
            return null;
        }
    }
}
