using BilimHeal.Server.Service.DTOs.Users.Logins;

namespace BilimHeal.Server.Service.Interfaces.Users;

public interface IAccountService
{
    public Task<string> LoginAsync(LoginDto loginDto);
}