using BilimHeal.Server.Domain.Commons;
using BilimHeal.Server.Domain.Enums;

namespace BilimHeal.Server.Domain.Entities;

public class QuizFormat : Auditable
{
    public string Description { get; set; }
    public DifficultyLevel DifficultyLevel { get; set; }
    public QuestionFormat QuestionFormat { get; set; }
    public int QuestionCount { get; set; }
}
