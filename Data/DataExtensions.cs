using Microsoft.EntityFrameworkCore;

namespace backend.Data;

public static class DataExtensions
{
    public static async Task MigrateDbAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<HabitsDbContext>();
        await dbContext.Database.MigrateAsync();
    }
}
