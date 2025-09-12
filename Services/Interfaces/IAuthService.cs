using Nihon4U.Models.DTO.EntitiesDTO;
using Nihon4U.Models.DTO.RequestDTO.Auth;
using Nihon4U.Models.DTO.ResponseDTO;

namespace Nihon4U.Services.Interfaces;

public interface IAuthService
{
    Task<AuthResponseDTO?> LoginAsync(LoginRequestDTO loginRequest);
    Task<AuthResponseDTO?> RegisterAsync(RegisterRequestDTO registerRequest);
    Task<bool> LogoutAsync(string token);
    Task<AuthResponseDTO?> RefreshTokenAsync(string refreshToken);
    Task<bool> ChangePasswordAsync(int userId, ChangePasswordRequestDTO changePasswordRequest);
    Task<bool> ForgotPasswordAsync(string email);
    Task<bool> ResetPasswordAsync(ResetPasswordRequestDTO resetPasswordRequest);
    Task<bool> VerifyEmailAsync(string token);
    Task<UserResponseDTO?> GetCurrentUserAsync(string token);
    Task<bool> UpdateProfileAsync(int userId, UpdateProfileRequestDTO updateProfileRequest);
}
