using backend.Habits.Entities;
using backend.Users.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Data;

public class HabitsDbContext : DbContext
{
    public HabitsDbContext(DbContextOptions<HabitsDbContext> options) : base(options)
    {
    }
    public DbSet<Habit> Habits { get; set; }
    public DbSet<User> Users {get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany(u => u.Habits)
            .WithOne(h => h.User)
            .HasForeignKey(h => h.UserId);
        
        modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
                
        base.OnModelCreating(modelBuilder);
    }

}
