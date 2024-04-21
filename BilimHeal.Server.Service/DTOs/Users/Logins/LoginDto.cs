using BilimHeal.Server.Service.Commons.Attributes;
using System.ComponentModel.DataAnnotations;

namespace BilimHeal.Server.Service.DTOs.Users.Logins;

public class LoginDto
{
    [Required(ErrorMessage = "Telefon raqamni kiriting"), PhoneNumber]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "Parolni kiriting"), StrongPassword]
    public string Password { get; set; }
}
