using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace backend.Users.Dtos;

public  record class UserCreate
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = default!;

    [Required]
    [PasswordPropertyText]
    public string Password { get; set; } = default!;
}

public record class UserDto(
  int Id,
  string Name,
  string HashPassword);

