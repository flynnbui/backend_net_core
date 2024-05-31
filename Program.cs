using backend.Data;
using backend.Habits.APIs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using backend.Users.Entities;

var builder = WebApplication.CreateBuilder(args);

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);

// Get the connection string from appsettings.json
var connString = builder.Configuration.GetConnectionString("DefaultConnection");
// Register the DbContext with the PostgreSQL provider
builder.Services.AddDbContext<HabitsDbContext>(options =>
    options.UseNpgsql(connString));

// For Entity Framework
builder.Services.AddIdentity<ApplicationUser
    , IdentityRole>()
    .AddEntityFrameworkStores<HabitsDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

});



var app = builder.Build();
await app.MigrateDbAsync();

// Configure the APIs
app.MapUsers();
app.MapHabits();



// Start
app.Run();
