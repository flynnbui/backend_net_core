// using backend.Users.Dtos;

using AutoMapper;
using backend.Data;
using backend.Users.Dtos;
using backend.Users.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
//Route Group for UsersAPIs
public static class UsersApi {
    //Route Group for UserAPIs
    public static RouteGroupBuilder MapUsers(this IEndpointRouteBuilder routes) {
        var group = routes.MapGroup("/users")
                    .WithParameterValidation()
                    .DisableAntiforgery();

        group.MapPost("register", async Task<Results<Ok, ValidationProblem>> ([FromForm] CreateUsersDto newUserDto,
            UserManager<ApplicationUser> userManager, 
            IMapper mapper) =>
        {
            Console.WriteLine(newUserDto);
            Console.WriteLine(newUserDto.GetType());
            //Map the DTO to the entity
            var newUser = mapper.Map<ApplicationUser>(newUserDto);
            var result = await userManager.CreateAsync(newUser);
            if (result.Succeeded)
            {
                return TypedResults.Ok();
            }
            return TypedResults.ValidationProblem(result.Errors.ToDictionary(e => e.Code, e => new[] { e.Description }));
        });

        return group;
    }
}





