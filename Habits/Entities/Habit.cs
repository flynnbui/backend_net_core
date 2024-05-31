﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using backend.Users.Entities;

namespace backend.Habits.Entities;

public class Habit {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public bool Status { get; set; }

    public string OwnerId { get; set; } = default!;

    public ApplicationUser ApplicationUser { get; set; } = default!;
}
