using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using backend.Habits.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace backend.Users.Entities;

public class ApplicationUser : IdentityUser
{
    public string? Name { get; set; }
    public ICollection<Habit> Habits { get; set; } = null!;
}