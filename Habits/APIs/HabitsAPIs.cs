using AutoMapper;
using backend.Data;
using backend.Habits.Dtos;
using backend.Habits.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Habits.APIs;

public static class HabitsAPIs
{
    //Route Group for HabitsAPIs
    public static RouteGroupBuilder MapHabits(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/habits")
                    .WithParameterValidation();
                    
        
        // Create new habit - POST /habits
        group.MapPost("/", async (CreateHabitsDto newHabitDto, HabitsDbContext dbContext, IMapper mapper) =>
        {   
            // Use AutoMapper to map the DTO directly to the entity
            var newHabit = mapper.Map<Habit>(newHabitDto);

            
            // Add the new habit to the database
            dbContext.Habits.Add(newHabit);
            await dbContext.SaveChangesAsync();

            return Results.Created($"/habits/{newHabit.Id}", newHabit);
        });

        // Get all the habits
        group.MapGet("/", async(HabitsDbContext dbContext) => {
            var habits = await dbContext.Habits.ToListAsync();
            return habits;
        });

        // Get habits by id
        group.MapGet("/{id}", async (int id, HabitsDbContext dbContext) => {
        Habit? habit = await dbContext.Habits.FindAsync(id);
            return habit is null?Results.NotFound():Results.Ok(habit); 
        });

        // Edit habit by Id
        group.MapPut("/{id}", async (int id, UpdateHabitDto updateHabit, HabitsDbContext dbContext,IMapper mapper) => {
            var habit = await dbContext.Habits.FindAsync(id);
            if (habit == null)
            {
                return Results.NotFound();
            }
            var updatedHabit = mapper.Map<Habit>(updateHabit);
            
            //Update the habit
            mapper.Map(updateHabit, habit);
            await dbContext.SaveChangesAsync();

            return Results.Accepted($"/habits/{habit.Id}", habit);
        });

        //Delete habit by Id
        group.MapDelete("/{id}", async (int id, HabitsDbContext dbContext) => {
            var habit = await dbContext.Habits.FindAsync(id);
            if (habit == null)
            {
                return Results.NotFound();
            }

            //Delete the habit
            dbContext.Habits.Remove(habit);
            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        return group;

    }
}