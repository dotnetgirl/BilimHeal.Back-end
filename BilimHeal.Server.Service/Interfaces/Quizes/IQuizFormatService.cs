using BilimHeal.Server.Service.DTOs.QuizFormats;
using BilimHeal.Server.Service.DTOs.Users;

namespace BilimHeal.Server.Service.Interfaces.Quizes;

public interface IQuizFormatService
{
    Task<dynamic> AddAsync(QuizFormatForCreationDto dto);
}
