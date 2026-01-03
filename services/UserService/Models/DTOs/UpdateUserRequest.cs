using System.ComponentModel.DataAnnotations;

namespace UserService.Models.DTOs;

public class UpdateUserRequest
{
    [MaxLength(100)]
    public string? FirstName { get; set; }

    [MaxLength(100)]
    public string? LastName { get; set; }
}

