using BilimHeal.Server.DAL.IRepositories;
using BilimHeal.Server.Domain.Entities;
using BilimHeal.Server.Service.Commons.Exceptions;
using BilimHeal.Server.Service.Commons.Helpers;
using BilimHeal.Server.Service.DTOs.Users.Logins;
using BilimHeal.Server.Service.Interfaces.Users;

namespace BilimHeal.Server.Service.Services.Users;

public class AccountService : IAccountService
{
    private readonly IAuthService authService;
    private readonly IRepository<User> userRepository;

    public AccountService(IRepository<User> userRepository, IAuthService authService)
    {
        this.authService = authService;
        this.userRepository = userRepository;
    }
    public async Task<string> LoginAsync(LoginDto loginDto)
    {
        var user = await userRepository.SelectAsync(x => x.PhoneNumber == loginDto.PhoneNumber);
        if (user is null)
            throw new CustomException(404, "Phone number or password entered wrong!");

        var hasherResult = PasswordHelper.Verify(loginDto.Password, user.Salt, user.Password);
        if (hasherResult == false)
            throw new CustomException(404, "Phone number or password entered wrong!");

        return authService.GenerateToken(user);
    }
}
