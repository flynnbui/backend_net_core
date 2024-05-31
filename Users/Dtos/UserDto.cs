using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace backend.Users.Dtos;

public record class CreateUsersDto
(
  [Required]
  [EmailAddress]
  string Email,

  [Required]
  [PasswordPropertyText]
  string Password
);

public record class UserDto(
  int Id,
  string Name,
  string HashPassword,
  
  DateTime CreatedAt,
  DateTime LastUpdated
);

