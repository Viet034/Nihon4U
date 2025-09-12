namespace Nihon4U.Models.DTO.ResponseDTO;

public class UserResponseDTO
{
    public int Id { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public string Status { get; set; }
    public string RefreshToken { get; set; }
    public string RefreshTokenExpriedTime { get; set; }
    public string ResetPasswordToken { get; set; }
    public string ResetPasswordTokenExpiredTime { get; set; }
}
