using BilimHeal.Server.Domain.Commons;
using BilimHeal.Server.Domain.Enums;
using System.Text.Json.Serialization;

namespace BilimHeal.Server.Domain.Entities;

public class User : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public string Salt { get; set; }
    public UserRole Role { get; set; }
}
