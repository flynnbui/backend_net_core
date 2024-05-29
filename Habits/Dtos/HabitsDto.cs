using System.ComponentModel.DataAnnotations;

namespace backend.Habits.Dtos;

public record class CreateHabitsDto
(
    [Required]
    [StringLength(50)]
    string Name,

    string Description
);

public record class HabitsDto
(
    int Id,
    string Name,
    string Description,
    bool Status
);

public record class UpdateHabitDto(
  [Required]
  [StringLength(50)]
  string Name,

  [StringLength(1000)]
  string Description
);