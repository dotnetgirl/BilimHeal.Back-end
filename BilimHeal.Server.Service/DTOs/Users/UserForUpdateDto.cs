using System.ComponentModel.DataAnnotations;

namespace BilimHeal.Server.Service.DTOs.Users;

public class UserForUpdateDto
{

    [Required(ErrorMessage = "FirstName is required")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "LastName is required")]
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
}
