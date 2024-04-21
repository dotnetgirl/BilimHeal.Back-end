﻿using System.ComponentModel.DataAnnotations;
using BilimHeal.Server.Domain.Enums;

namespace BilimHeal.Server.Service.DTOs.Users;

public class UserForCreationDto
{
    [Required(ErrorMessage = "FirstName is required")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "LastName is required")]
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [MinLength(8), MaxLength(32)]
    public string Password { get; set; }
    public UserRole Role { get; set; }
}
