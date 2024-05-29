using AutoMapper;
using backend.Habits.Dtos;
using backend.Habits.Entities;

public class MappingProfile : Profile {
     public MappingProfile() {
         CreateMap<CreateHabitsDto, Habit>().ReverseMap();
         CreateMap<Habit, HabitsDto>().ReverseMap();
         CreateMap<UpdateHabitDto, Habit>().ReverseMap();
     }
 }