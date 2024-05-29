using backend.Data;
using backend.Habits.APIs;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);


// Get the connection string from appsettings.json
var connString = builder.Configuration.GetConnectionString("DefaultConnection");
// Register the DbContext with the PostgreSQL provider
builder.Services.AddDbContext<HabitsDbContext>(options =>
    options.UseNpgsql(connString));


var app = builder.Build();
await app.MigrateDbAsync();

// Configure the APIs
app.MapHabits();



// Start
app.Run();
