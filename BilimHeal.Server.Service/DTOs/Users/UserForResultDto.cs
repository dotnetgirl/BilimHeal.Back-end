using BilimHeal.Server.Domain.Enums;
using BilimHeal.Server.Service.DTOs.QuizResults;

namespace BilimHeal.Server.Service.DTOs.Users;

public class UserForResultDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public UserRole Role { get; set; }
}
