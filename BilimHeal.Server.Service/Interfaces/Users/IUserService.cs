using BilimHeal.Server.Domain.Configurations;
using BilimHeal.Server.Service.DTOs.Users;

namespace BilimHeal.Server.Service.Interfaces.Users;

public interface IUserService
{
    Task<bool> RemoveAsync(long id);
    Task<UserForResultDto> RetrieveByIdAsync(long id);
    Task<UserForResultDto> AddAsync(UserForCreationDto dto);
    Task<UserForResultDto> ModifyAsync(long id, UserForUpdateDto dto);
    Task<bool> ChangePasswordAsync(long id, UserForChangePasswordDto dto);
    Task<UserForResultDto> RetrieveByPhoneNumberAsync(string phoneNumber);
    Task<IEnumerable<UserForResultDto>> RetrieveAllAsync(PaginationParams @params);
    Task<bool> ForgetPasswordAsync(string PhoneNumber, string NewPassword, string ConfirmPassword);
}
