using AutoMapper;
using BilimHeal.Server.DAL.IRepositories;
using BilimHeal.Server.Domain.Configurations;
using BilimHeal.Server.Domain.Entities;
using BilimHeal.Server.Domain.Enums;
using BilimHeal.Server.Service.Commons.Exceptions;
using BilimHeal.Server.Service.Commons.Extentions;
using BilimHeal.Server.Service.Commons.Helpers;
using BilimHeal.Server.Service.DTOs.Users;
using BilimHeal.Server.Service.Interfaces.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BilimHeal.Server.Service.Services.Users;

public class UserService : IUserService
{
    private readonly IMapper mapper;
    private readonly IConfiguration configuration;
    private readonly IUserService userService;
    private readonly IRepository<User> userRepository;

    public UserService(
        IMapper mapper,
        IConfiguration configuration,
        IRepository<User> userRepository)
    {
        this.mapper = mapper;
        this.configuration = configuration;
        this.userRepository = userRepository;
    }

    public async Task<UserForResultDto> AddAsync(UserForCreationDto dto)
    {
        var user = await this.userRepository.SelectAsync(u => u.PhoneNumber == dto.PhoneNumber);
        if (user is not null)
            throw new CustomException(403, "User is already exists");

        var hasherResult = PasswordHelper.Hash(dto.Password);
        var mapped = this.mapper.Map<User>(dto);

        mapped.CreatedAt = TimeHelper.GetCurrentServerTime();
        mapped.Salt = hasherResult.Salt;
        mapped.Password = hasherResult.Hash;

        var result = await this.userRepository.InsertAsync(mapped);
        await this.userRepository.SaveAsync();
        return this.mapper.Map<UserForResultDto>(result);
    }

    public async Task<bool> ChangePasswordAsync(long id, UserForChangePasswordDto dto)
    {
        var user = await this.userRepository.SelectAsync(u => u.Id == id);
        if (user is null || !PasswordHelper.Verify(dto.OldPassword, user.Salt, user.Password))
            throw new CustomException(404, "User or Password is incorrect");
        else if (dto.NewPassword != dto.ConfirmPassword)
            throw new CustomException(400, "New password and confir password aren't equal");

        var hash = PasswordHelper.Hash(dto.ConfirmPassword);
        user.Salt = hash.Salt;
        user.Password = hash.Hash;
        var updated = this.userRepository.Update(user);

        return await this.userRepository.SaveAsync();

    }

    public async Task<bool> ForgetPasswordAsync(string PhoneNumber, string NewPassword, string ConfirmPassword)
    {
        var user = await this.userRepository.SelectAsync(u => u.PhoneNumber == PhoneNumber);

        if (user is null)
            throw new CustomException(404, "User not found");

        if (NewPassword != ConfirmPassword)
            throw new CustomException(400, "New password and confirm password aren't equal");

        var hash = PasswordHelper.Hash(NewPassword);

        user.Salt = hash.Salt;
        user.Password = hash.Hash;

        var updated = this.userRepository.Update(user);

        return await this.userRepository.SaveAsync();
    }

    public async Task<UserForResultDto> ModifyAsync(long id, UserForUpdateDto dto)
    {
        var user = await this.userRepository.SelectAsync(u => u.Id == id);
        if (user is null)
            throw new CustomException(404, "User not found");

        if (dto is not null)
        {
            user.FirstName = string.IsNullOrEmpty(dto.FirstName) ? user.FirstName : dto.FirstName;
            user.LastName = string.IsNullOrEmpty(dto.LastName) ? user.LastName : dto.LastName;
            user.PhoneNumber = string.IsNullOrEmpty(dto.PhoneNumber) ? user.PhoneNumber : dto.PhoneNumber;

            user.UpdatedAt = TimeHelper.GetCurrentServerTime();
            this.userRepository.Update(user);
            var result = await this.userRepository.SaveAsync();
        }
        var person = this.mapper.Map(dto, user);
        /* await this.userRepository.SaveAsync();*/

        return this.mapper.Map<UserForResultDto>(person);
    }

    public async Task<UserForResultDto> ModifyTelegramId(long id, long telegramId)
    {
        var user = await this.userRepository.SelectAll()
            .Where(u => u.Id == id)
            .FirstOrDefaultAsync();
        if (user is null)
            throw new CustomException(404, "User is not found");

        await this.userRepository.SaveAsync();

        return this.mapper.Map<UserForResultDto>(user);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var user = await userRepository.SelectAsync(u => u.Id == id);
        if (user is null)
            throw new CustomException(404, "User not found");

        await userRepository.DeleteAsync(id);
        var result = await this.userRepository.SaveAsync();
        return result;
    }

    public async Task<IEnumerable<UserForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var users = await this.userRepository.SelectAll()
            .Where(x => x.Role.Equals((UserRole)0))
            .AsNoTracking()
            .ToPagedList(@params)
            .ToListAsync();

        var mappedUsers = this.mapper.Map<IEnumerable<UserForResultDto>>(users);

        return mappedUsers;
    }

    public async Task<UserForResultDto> RetrieveByIdAsync(long id)
    {
        var user = await this.userRepository.SelectAll()
        .Where(u => u.Id == id)
        .AsNoTracking()
        .FirstOrDefaultAsync();

        if (user is null)
            throw new CustomException(404, "User Not Found");

        var userDto = this.mapper.Map<UserForResultDto>(user);
        return userDto;
    }



    public async Task<UserForResultDto> RetrieveByPhoneNumberAsync(string phoneNumber)
    {
        var user = await this.userRepository.SelectAsync(u => u.PhoneNumber == phoneNumber);
        if (user is null)
            throw new CustomException(404, "User Not Found");

        return this.mapper.Map<UserForResultDto>(user);
    }
}