using AutoMapper;
using backend.Habits.Dtos;
using backend.Habits.Entities;
using backend.Users.Dtos;
using backend.Users.Entities;

public class MappingProfile : Profile {
     public MappingProfile() {
         CreateMap<CreateHabitsDto, Habit>().ReverseMap();
         CreateMap<Habit, HabitsDto>().ReverseMap();
         CreateMap<UpdateHabitDto, Habit>().ReverseMap();
         CreateMap<CreateUsersDto, ApplicationUser>().ReverseMap();
     }
 }