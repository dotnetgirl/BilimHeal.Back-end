using BilimHeal.Server.API.Controllers.Commons;
using BilimHeal.Server.API.Models;
using BilimHeal.Server.Domain.Configurations;
using BilimHeal.Server.Service.DTOs.Users;
using BilimHeal.Server.Service.Interfaces.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BilimHeal.Server.API.Controllers.Users;

public class UsersController : BaseController
{
        private readonly IUserService userService;
        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        /// <summary>
        /// Create new users
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<UserForResultDto>> PostAsync([FromBody] UserForCreationDto dto)
            => Ok(new Response
            {
                Code = 200,
                Message = "Success",
                Data = await userService.AddAsync(dto)
            });

        /// <summary>
        /// Get all users
        /// </summary>
        /// <param name="params"></param>
        /// <returns></returns>
        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
            => Ok(new Response
            {
                Code = 200,
                Message = "Success",
                Data = await userService.RetrieveAllAsync(@params)
            });

        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute(Name = "id")] long id)
            => Ok(new Response
            {
                Code = 200,
                Message = "Success",
                Data = await userService.RetrieveByIdAsync(id)
            });


        /// <summary>
        /// Update users info
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        //[Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult<UserForResultDto>> PutAsync([FromRoute(Name = "id")] long id, [FromBody] UserForUpdateDto dto)
            => Ok(new Response
            {
                Code = 200,
                Message = "Success",
                Data = await userService.ModifyAsync(id, dto)
            });

        /// <summary>
        /// Delete by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteAsync([FromRoute(Name = "id")] long id)
            => Ok(new Response
            {
                Code = 200,
                Message = "Success",
                Data = await userService.RemoveAsync(id)
            });

        /// <summary>
        /// Change user password
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>

        [HttpPut("change-password")]
        public async Task<ActionResult<UserForResultDto>> ChangePasswordAsync(long id, UserForChangePasswordDto dto)
            => Ok(new Response
            {
                Code = 200,
                Message = "Success",
                Data = await userService.ChangePasswordAsync(id, dto)
            });

        [AllowAnonymous]
        [HttpPut("forget-password")]
        public async Task<IActionResult> ForgetPasswordAsync([Required] string PhoneNumber, [Required] string NewPassword, [Required] string ConfirmPassword)
            => Ok(new Response
            {
                Code = 200,
                Message = "Success",
                Data = await userService.ForgetPasswordAsync(PhoneNumber, NewPassword, ConfirmPassword)
            });


        [AllowAnonymous]
        [HttpGet("phone-number")]
        public async Task<IActionResult> RetrievePhoneNumberAsync(string phoneNumber)
            => Ok(new Response
            {
                Code = 200,
                Message = "Success",
                Data = await this.userService.RetrieveByPhoneNumberAsync(phoneNumber)
            });
}
