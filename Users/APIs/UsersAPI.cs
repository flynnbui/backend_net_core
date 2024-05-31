// using backend.Users.Dtos;

using AutoMapper;
using backend.Data;
using backend.Users.Dtos;
using backend.Users.Entities;
using Microsoft.AspNetCore.Identity;
//Route Group for UsersAPIs
public static class UsersApi {
    //Route Group for UserAPIs
    public static RouteGroupBuilder MapUsers(this IEndpointRouteBuilder routes) {
        var group = routes.MapGroup("/users")
                    .WithParameterValidation();
        
        // Create new user - POST /users/register
        group.MapPost("register", async(CreateUsersDto newUserDto, 
        HabitsDbContext dbContext,
        IMapper mapper,
        IPasswordHasher<User> hasher
        ) => {
            //Map the DTO to the entity
            var newUser = mapper.Map<User>(newUserDto);
            newUser.Password = PasswordHasher(newUser,newUser.Password);

            //Add new user to the database
            dbContext.Users.Add(newUser);
            await dbContext.SaveChangesAsync();

            return Results.Created($"/users/{newUser.UserId}", newUser);
        });
        

        return group;
    }
}