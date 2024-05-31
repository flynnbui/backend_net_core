using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using backend.Habits.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Users.Entities;

public class User {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserId { get; set; }
    [Required]
    [EmailAddress]
    public string Email {get; set; } = default!;
    public string? Name { get; set; }
    public string Password { get; set; } = default!;
    public ICollection<Habit> Habits { get; set; } = null!;

}