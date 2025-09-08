namespace Nihon4U.Models.DTO.ResponseDTO;

public class AuthResponseDTO
{
    public string AccessToken { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
    public DateTime ExpiresAt { get; set; }
    public UserResponseDTO User { get; set; } = new();
    public string Message { get; set; } = string.Empty;
    public bool Success { get; set; }
}
