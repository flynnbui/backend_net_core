using backend.Habits.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Data;

public class HabitsDbContext : DbContext
{
    public HabitsDbContext(DbContextOptions<HabitsDbContext> options) : base(options)
    {
    }
    public DbSet<Habit> Habits { get; set; }

}
