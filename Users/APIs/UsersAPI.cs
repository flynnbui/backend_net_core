// using backend.Users.Dtos;

// public static class UsersApi {
//     readonly List<UserDto> user = [
//     new (
//         2,
//         "Flynn Bui",
//         "dsakjashdkjha"
//     )
// ];
//     //Route Group for UserAPIs
//     public static RouteGroupBuilder MapUsers(this IEndpointRouteBuilder routes) {
//         var group = routes.MapGroup("/users");

//         group.MapPost("/", (UserCreate newUser) => {
//         });
//         return group;
//     }
// }