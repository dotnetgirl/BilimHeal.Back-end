using BilimHeal.Server.API.Models;
using BilimHeal.Server.Service.DTOs.Users.Logins;
using BilimHeal.Server.Service.Interfaces.Users;
using Microsoft.AspNetCore.Mvc;

namespace BilimHeal.Server.API.Controllers.Commons;

public class AuthController : BaseController
{
    private readonly IAccountService accountService;

    public AuthController(IAccountService accountService, IAuthService authService)
    {
        this.accountService = accountService;
    }

    [HttpPost]
    [Route("login")]
    public async ValueTask<IActionResult> login([FromBody] LoginDto loginDto)
        => Ok(new Response
        {
            Code = 200,
            Message = "Success",
            Data = await accountService.LoginAsync(loginDto)
        });
}
