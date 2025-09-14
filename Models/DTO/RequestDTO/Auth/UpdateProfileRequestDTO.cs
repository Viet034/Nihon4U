using System.ComponentModel.DataAnnotations;

namespace Nihon4U.Models.DTO.RequestDTO.Auth;

public class UpdateProfileRequestDTO
{
    [MinLength(2)]
    public string? FirstName { get; set; }

    [MinLength(2)]
    public string? LastName { get; set; }

    public string? Phone { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? Gender { get; set; }
    public string? Address { get; set; }
    public string? ImageURL { get; set; }
}

