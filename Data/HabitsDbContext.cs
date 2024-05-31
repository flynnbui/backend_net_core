using backend.Habits.Entities;
using backend.Users.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace backend.Data;

public class HabitsDbContext : IdentityDbContext<ApplicationUser> 
{
    public HabitsDbContext(DbContextOptions<HabitsDbContext> options) : base(options)
    {
    }
    public DbSet<Habit> Habits { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApplicationUser>()
            .HasMany(u => u.Habits)
            .WithOne(h => h.ApplicationUser)
            .HasForeignKey(h => h.OwnerId);

        base.OnModelCreating(modelBuilder);
        SeedRoles(modelBuilder);
    }

    private void SeedRoles(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdentityRole>().HasData
            (
            new IdentityRole() { Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
            new IdentityRole() { Name = "User", ConcurrencyStamp = "2", NormalizedName = "User" }
            );
    }
}
