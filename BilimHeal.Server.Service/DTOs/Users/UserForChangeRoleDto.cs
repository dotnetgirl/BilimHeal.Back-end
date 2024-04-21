using BilimHeal.Server.Domain.Enums;

namespace BilimHeal.Server.Service.DTOs.Users;

public class UserForChangeRoleDto
{
    public long Id { get; set; }
    public UserRole Role { get; set; }
}