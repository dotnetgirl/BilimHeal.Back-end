using BilimHeal.Server.Domain.Enums;

namespace BilimHeal.Server.Service.DTOs.QuizFormats;

public class QuizFormatForCreationDto
{
    public string Description { get; set; }
    public DifficultyLevel DifficultyLevel { get; set; }
    public QuestionFormat QuestionFormat { get; set; }
    public int QuestionCount { get; set; }
}
