using BilimHeal.Server.Domain.Entities;

namespace BilimHeal.Server.Service.Interfaces.Users;

public interface IAuthService
{
    public string GenerateToken(User users);
}